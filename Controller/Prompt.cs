using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Nucleo.Base.Enumeradores.Prompt;

namespace GerarEtiquetas.Controller
{
    public class Prompt
    {
        private Telas.Prompt form;
        private Nucleo.Base.Enumeradores.Prompt.Dado Formato;

        public string DadoRetornado = string.Empty;

        public Prompt(Telas.Prompt e, Nucleo.Base.Enumeradores.Prompt.Dado dado)
        {
            form = e;

            form.Load += Form_Load;
            form.btnLimpar.Click += BtnLimpar_Click;
            form.btnSalvar.Click += BtnSalvar_Click;

            Formato = dado;
            Formatar();
        }

        private void BtnSalvar_Click(object? sender, EventArgs e)
        {
            Salvar();
        }

        private void BtnLimpar_Click(object? sender, EventArgs e)
        {
            Limpar();
        }

        private void Form_Load(object? sender, EventArgs e)
        {
            //Caso tenha algum preparo para cada formato, fazer aqui
        }

        private void FormatarAssinatura()
        {
            form.lblTextoSolicitado.Text = "Insira a chave de assinatura do sistema:";
            form.btnAcao1.Text = "Gerar nova chave";
            form.btnAcao1.Click += btnGerarChave;
            form.btnAcao1.Visible = true;
        }

        private void BtnAcao1_Click(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void FormatarServidor()
        {

        }

        private void FormatarNomeBanco()
        {

        }

        private void FormatarSenhaBanco()
        {

        }

        private void Cancelar()
        {
            form.Close();
        }


        private void btnGerarChave(object? sender, EventArgs e)
        {
            form.txtDadoSolicitado.Text = Guid.NewGuid().ToString();
        }

        private void Salvar()
        {
            DadoRetornado = form.txtDadoSolicitado.Text.Trim();
            form.Close();
        }

        private void Limpar()
        {
            form.txtDadoSolicitado.Text = string.Empty;
            Formatar();
        }

        private void Formatar()
        {
            if (Formato == Nucleo.Base.Enumeradores.Prompt.Dado.Assinatura)
                FormatarAssinatura();
            else if (Formato  == Nucleo.Base.Enumeradores.Prompt.Dado.Servidor_BancoDados)
                FormatarServidor();
            else if (Formato == Nucleo.Base.Enumeradores.Prompt.Dado.Nome_BancoDados)
                FormatarNomeBanco();
            else if (Formato == Nucleo.Base.Enumeradores.Prompt.Dado.Senha_BancoDados)
                FormatarSenhaBanco();
            else
                Cancelar();

        }
    }
}
