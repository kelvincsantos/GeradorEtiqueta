using DocumentFormat.OpenXml.Presentation;
using Google.Apis.Auth.OAuth2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace GerarEtiquetas.API
{
    public class Conector
    {
        public enum Metodo
        {
            GET,
            POST,
            PUT,
            DELETE,
            HEAD,
            OPTIONS,
            PATCH
        }

        private string baseURL { get; set; }

        public Conector(string BaseURL)
        {
            this.baseURL = BaseURL;
        }

        public async Task<Saida?> CallAsync(Entrada e)
        {
            HttpClient client;
            try
            {
                if (string.IsNullOrWhiteSpace(e.TipoConteudo))
                    e.TipoConteudo = "application/json";

                client = new HttpClient();
                client.BaseAddress = new Uri(baseURL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(e.TipoConteudo));




                if (e.Headers != null && e.Headers.Count > 0)
                    foreach (KeyValuePair<string, string> item in e.Headers)
                    {
                        client.DefaultRequestHeaders.Add(item.Key, item.Value);
                    }

                string endPoint = e.EndPointComParametros();



                HttpResponseMessage? httpResponse = null;
                if (e.Metodo == Metodo.POST)
                {
                    var content = new StringContent(e.Conteudo, Encoding.UTF8, e.TipoConteudo);
                    httpResponse = await client.PostAsync(endPoint, content);
                }
                else if (e.Metodo == Metodo.GET)
                    httpResponse = await client.GetAsync(endPoint);
                else if (e.Metodo == Metodo.PUT)
                    httpResponse = await client.PutAsync(endPoint, null);

                if (httpResponse == null)
                    return null;

                string result = await httpResponse.Content.ReadAsStringAsync();
                if (httpResponse.StatusCode == HttpStatusCode.OK || httpResponse.StatusCode == HttpStatusCode.PreconditionFailed)
                {
                    return new Saida()
                    {
                        Conteudo = result,
                    };
                }
                else
                {
                    return new Saida()
                    {
                        Conteudo = result,
                        Erro = new Saida._Erro()
                        {
                            Codigo = (int)httpResponse.StatusCode,
                            Erro = string.Concat("Erro no EndPoint:", e.EndPoint),
                        }
                    };
                }
            }
            catch (Exception ex)
            {
                return TratarExcecao(ex, e);
            }
        }

        private Saida TratarExcecao(Exception ex, Entrada e)
        {
            return new Saida()
            {
                Erro = new Saida._Erro()
                {
                    Codigo = -1,
                    Erro = string.Concat("Erro na comunicação com a API (", e.EndPoint, "): "),
                    excecao = ex,
                }
            };
        }

        public partial class Saida
        {
            public Saida()
            {
                this.Conteudo = string.Empty;
                this.Erro = new _Erro();
            }
            public string? Conteudo { get; set; }
            public _Erro Erro { get; set; }

            public partial class _Erro
            {
                public _Erro()
                {
                    this.Erro = string.Empty;
                    this.excecao = null;
                }

                public string Erro { get; set; }
                public int Codigo { get; set; }

                public Exception? excecao { get; set; }
            }
        }

        public partial class Entrada
        {
            public Entrada()
            {
                this.Conteudo = string.Empty;
                this.TipoConteudo = string.Empty;
                this.EndPoint = string.Empty;
                this.Headers = new Dictionary<string, string>();
                this.Parametros = new Dictionary<string, string>();
            }

            public Metodo Metodo { get; set; }
            public string Conteudo { get; set; }
            public string TipoConteudo { get; set; }
            public string EndPoint { get; set; }
            public Dictionary<string, string> Headers { get; set; }
            public Dictionary<string, string> Parametros { get; set; }



            public string EndPointComParametros()
            {
                string endPoint = EndPoint;
                if (Parametros != null && Parametros.Count > 0)
                {
                    string param = string.Empty;

                    foreach (KeyValuePair<string, string> item in Parametros)
                    {
                        if (!string.IsNullOrWhiteSpace(param))
                            param += "&";

                        param += string.Concat(param, item.Key, "=", item.Value);
                    }

                    endPoint = string.Concat(endPoint, param);
                }

                return endPoint;
            }
        }

    }
}
