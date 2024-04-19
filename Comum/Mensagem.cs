using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace GerarEtiquetas.Comum
{
    public static class Mensagem
    {
        public static void Sucesso(string mensagem)
        {
            MessageBox.Show(mensagem, "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void Aviso(string mensagem)
        {
            MessageBox.Show(mensagem, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }

        public static void Alerta(string mensagem)
        {
            MessageBox.Show(mensagem, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }

        public static void Erro(string mensagem)
        {
            MessageBox.Show(mensagem, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void Validacao(string mensagem)
        {
            MessageBox.Show(mensagem, "!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }

        public static bool QuestaoSimNao(string mensagem)
        {
            return MessageBox.Show(mensagem, "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        public static bool QuestaoSimNaoFocoNao(string mensagem)
        {
            return MessageBox.Show(mensagem, "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes;
        }

        public static bool QuestaoOkCancelar(string mensagem)
        {
            return MessageBox.Show(mensagem, "?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK;
        }

        public static void Erro(string content, System.Exception ex, bool fechar = false)
        {
            var stackTrace = new StackTrace();
            MethodBase? callingMethod = stackTrace.GetFrame(1)?.GetMethod();
            content += string.Concat(Environment.NewLine, "Fonte: ", callingMethod?.Name);


            string Message = ErrorExceptionMessage(content, ex);

            //string Comando = string.Concat("Caixa: ", Binding.Caixa.Propriedades.NumeroCaixa, " Status: ", Program.Environment.Contingencia ? "Offline" : "Online");

            //if (ex != null)
            //    Comando = string.Concat(Comando, System.Environment.NewLine, System.Environment.NewLine, "Rota do erro: ", ex.StackTrace);

            if (QuestaoSimNaoFocoNao("Erro de comunicação com o servidor, deseja ver o erro?"))
                Mensagem.Erro(Message);

            if (fechar)
                Program.Exit(true);
        }

        private static string ErrorExceptionMessage(string Message, Exception ex)
        {
            if (ex != null)
            {
                Message = string.Concat(Message, Environment.NewLine, Environment.NewLine, "Dados técnicos:", Environment.NewLine, ex.Message);

                Exception? ex2 = ex.InnerException;

                while (ex2 != null)
                {
                    if (ex2 != null)
                        Message = string.Concat(Message, Environment.NewLine, System.Environment.NewLine, "InnerException: ", ex2.Message);

                    ex2 = ex.InnerException;
                }
            }

            return Message;

        }
    }
}
