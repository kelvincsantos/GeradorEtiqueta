using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GerarEtiquetas.Comum
{
    public class Arquivos
    {
        public Nucleo.Base.Seguranca.Criptografia Criptografia { get; set; }
        private const string Diretorio = "Config";

        private const string Banco = "Caixa.conf";
        private const string Assinatura = "APIS.conf";

        private string dirBanco = Path.Combine(Diretorio, Banco);
        private string dirAssinatura = Path.Combine(Diretorio, Assinatura);

        public Arquivos()
        {
            if (!Directory.Exists(Diretorio))
                Directory.CreateDirectory(Diretorio);

            Criptografia = new Nucleo.Base.Seguranca.Criptografia();
        }

        public bool GravarBanco(string servidor, string banco, string senha)
        {
            string s = Criptografia.Codificar(string.Concat(servidor, "|", banco, "|", senha));

            return Gravar(dirBanco, s);
        }
        public string LerBanco()
        {
            return Criptografia.Decodificar(Ler(dirBanco));
        }
        public bool GravarAssinatura(string senha)
        {
            return Gravar(dirAssinatura, Criptografia.Codificar(senha));
        }
        public string LerAssinatura()
        {
            return Criptografia.Decodificar(Ler(dirAssinatura));
        }

        private string Ler(string arquivo, bool mensagem = false)
        {
            try
            {
                if (!File.Exists(arquivo))
                {
                    if (mensagem)
                        Mensagem.Erro(string.Concat("Arquivo inexistente: ", arquivo));

                    return string.Empty;
                }

                string conteudo = File.ReadAllText(arquivo);

                if (string.IsNullOrWhiteSpace(conteudo))
                {
                    if (mensagem)
                        Mensagem.Erro(string.Concat("Arquivo vazio: ", arquivo));

                    return string.Empty;
                }

                return conteudo;
            }
            catch (Exception ex)
            {
                Mensagem.Erro(string.Concat("Erro ao ler arquivo: ", arquivo), ex, true);
                return string.Empty;
            }
        }

        private List<string>? LerLinhas(string arquivo)
        {
            try
            {
                if (!File.Exists(arquivo))
                    return null;

                return File.ReadAllLines(arquivo).ToList();
            }
            catch (Exception ex)
            {
                Mensagem.Erro(string.Concat("Erro ao ler arquivo: ", arquivo), ex);
                return null;
            }
        }

        private bool Gravar(string arquivo, string conteudo)
        {
            try
            {
                if (File.Exists(arquivo))
                    File.Delete(arquivo);

                if (string.IsNullOrWhiteSpace(conteudo))
                    return true;

                using (StreamWriter escritor = new StreamWriter(arquivo))
                {
                    escritor.Write(conteudo);
                }

                return true;
            }
            catch (Exception ex)
            {
                Mensagem.Erro(string.Concat("Erro ao ler arquivo: ", arquivo), ex);
                return false;
            }
        }

        private bool Gravar(string arquivo, List<string> conteudo)
        {
            try
            {
                if (File.Exists(arquivo))
                    File.Delete(arquivo);

                if (conteudo == null)
                    return true;

                using (StreamWriter escritor = new StreamWriter(arquivo))
                {
                    foreach (string item in conteudo)
                    {
                        escritor.WriteLine(item);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                Mensagem.Erro(string.Concat("Erro ao ler arquivo: ", arquivo), ex);
                return false;
            }
        }
    }
}
