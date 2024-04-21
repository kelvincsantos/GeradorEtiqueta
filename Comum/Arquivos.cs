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
        private const string Diretorio = "Config";

        private const string Banco = "Caixa.conf";
        private const string Assinatura = "APIS.conf";

        private readonly string dirBanco = Path.Combine(Diretorio, Banco);
        private readonly string dirAssinatura = Path.Combine(Diretorio, Assinatura);

        public Arquivos()
        {
            if (!Directory.Exists(Diretorio))
                Directory.CreateDirectory(Diretorio);
        }

        public bool GravarBanco(string dados)
        {
            string s = Program.Ambiente.Criptografia.Codificar(dados);

            return Gravar(dirBanco, s);
        }
        public string LerBanco()
        {
            return Program.Ambiente.Criptografia.Decodificar(Ler(dirBanco));
        }
        public bool GravarAssinatura(string assinatura)
        {
            return Gravar(dirAssinatura, Program.Ambiente.Criptografia.Codificar(assinatura));
        }
        public void DeletarAssinatura()
        {
            Deletar(dirAssinatura);
        }

        public string LerAssinatura()
        {
            return Program.Ambiente.Criptografia.Decodificar(Ler(dirAssinatura));
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
                Deletar(arquivo);
                
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

        private void Deletar(string arquivo)
        {
            if (File.Exists(arquivo))
                File.Delete(arquivo);
        }
    }
}
