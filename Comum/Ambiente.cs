using GerarEtiquetas.Forms.Comum;
using Microsoft.Win32;
using Nucleo.Base.Seguranca;
using Nucleo.Base.SQL;
using Nucleo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace GerarEtiquetas.Comum
{
    public class Ambiente
    {
        public Criptografia Criptografia;
        public Arquivos Arquivos;
        public SQL? Banco;
        public Configuracao Configuracao;
        public Ambiente()
        {
            Criptografia = new();
            Arquivos = new();
            Configuracao = Ambiente.Configurar();
        }

        public static bool ChecarAssinaturaRepresentante(string assinatura = "")
        {
            string valor = ChavesSistema.Buscar("config");

            if (string.IsNullOrWhiteSpace(valor))
            {
                valor = ChamarPrompt(Nucleo.Base.Enumeradores.Prompt.Dado.AssinaturaRepresentante);
                ChavesSistema.Registrar("config", valor);
                return true;
            }

            if (assinatura != valor)
                return false;


            return true;
        }

        public static bool ChecarAssinatura()
        {
            
            string assinatura = Program.Ambiente.Arquivos.LerAssinatura();
            string AssinaturaRepresentante = string.Empty;

            if (string.IsNullOrEmpty(assinatura))
            {
                Mensagem.Aviso("Não foi encontrado o arquivo de assinatura do sistema.");
                assinatura = ChamarPrompt(Nucleo.Base.Enumeradores.Prompt.Dado.Assinatura);
                AssinaturaRepresentante = ChamarPrompt(Nucleo.Base.Enumeradores.Prompt.Dado.AssinaturaRepresentante);

                assinatura = string.Concat(assinatura, "|", DateTime.Now.AddYears(1).ToString("dd/MM/yyyy"), "|", AssinaturaRepresentante);
                Program.Ambiente.Arquivos.GravarAssinatura(assinatura);
            }

            if (string.IsNullOrEmpty(assinatura))
            {
                Mensagem.Alerta("Assinatura não reconhecida, o sistema será fechado.");
                return false;
            }

            try
            {
                AssinaturaRepresentante = ChavesSistema.Buscar("config");

                string[] dado = assinatura.Split('|');
                string valor = ChavesSistema.Buscar("Asign");

                if (!ChecarAssinaturaRepresentante(AssinaturaRepresentante))
                {
                    Mensagem.Alerta("Assinatura do representante não reconhecida, o sistema será fechado.");
                    Program.Ambiente.Arquivos.DeletarAssinatura();
                    return false;
                }

                if (string.IsNullOrWhiteSpace(valor))
                {
                    valor = dado[0];

                    ChavesSistema.Registrar("Asign", valor);
                    return true;
                }                

                if (dado[0] != valor)
                {
                    Mensagem.Alerta("Assinatura não reconhecida, o sistema será fechado.");
                    return false;
                }

                DateTime dataVencimento = Convert.ToDateTime(dado[1]);

                if (dataVencimento < DateTime.Now)
                {
                    Mensagem.Alerta("Assinatura vencida, o sistema será fechado.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Mensagem.Erro("Erro ao registrar chave de assinatura do sistema, o sistema será fechado.", ex);
                return false;
            }

            return true;
        }

        public static bool ChecarBanco()
        {
            string dados = Program.Ambiente.Arquivos.LerBanco();
            string Servidor = string.Empty;
            string NomeBanco = string.Empty;
            string Senha = string.Empty;


            if (string.IsNullOrEmpty(dados))
            {
                Mensagem.Aviso("Não foi encontrado o arquivo de banco de dados do sistema.");

                Servidor = ChamarPrompt(Nucleo.Base.Enumeradores.Prompt.Dado.Servidor_BancoDados);
                NomeBanco = ChamarPrompt(Nucleo.Base.Enumeradores.Prompt.Dado.Nome_BancoDados);
                Senha = ChamarPrompt(Nucleo.Base.Enumeradores.Prompt.Dado.Senha_BancoDados);

                if (string.IsNullOrEmpty(Servidor))
                {
                    Mensagem.Alerta("servidor do banco de dados inconsistente, o sistema será fechado.");
                    return false;
                }

                if (string.IsNullOrEmpty(NomeBanco))
                {
                    Mensagem.Alerta("Nome do banco de dados inconsistente, o sistema será fechado.");
                    return false;
                }

                if (string.IsNullOrEmpty(Senha))
                {
                    Mensagem.Alerta("Senha do banco de dados inconsistente, o sistema será fechado.");
                    return false;
                }

                dados = string.Concat(Servidor, "|", NomeBanco, "|", Senha);
                Program.Ambiente.Arquivos.GravarBanco(dados);
            }

            try
            {
                Program.Ambiente.Banco = new SQL(new SQL.Conexao(dados));
            }
            catch (Exception ex)
            {
                Mensagem.Erro("Erro ao verificar banco de dados, o sistema será fechado.", ex);
                return false;
            }
            return true;
        }

        private static string ChamarPrompt(Nucleo.Base.Enumeradores.Prompt.Dado dado)
        {
            Telas.Prompt prompt = new Telas.Prompt(dado);

            Leiaute.Tela.Exibir(prompt);

            return prompt.controller.DadoRetornado;
        }

        private static Configuracao Configurar()
        {
            return new Nucleo.Operacoes.BO.Configuracao().BuscarConfiguracao();
        }
    }
}
