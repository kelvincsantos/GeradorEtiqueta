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

            form.txtDadoSolicitado.KeyDown += TxtDadoSolicitado_KeyDown;

            Formato = dado;
            Formatar();
        }

        private void TxtDadoSolicitado_KeyDown(object? sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
                Salvar();
            else if(e.KeyCode == Keys.Escape)
                Cancelar();
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
            form.Text = "Assinatura";
            form.lblTextoSolicitado.Text = "Insira a chave de assinatura do sistema:";
            form.btnAcao1.Text = "Gerar nova chave";
            form.btnAcao1.Click += btnGerarChave;
            form.btnAcao1.Visible = true;
        }

        private void FormatarServidor()
        {
            form.Text = "Servidor de Banco de Dados";
            form.lblTextoSolicitado.Text = "Insira o endereço do banco de dados do sistema:";
            form.btnAcao1.Visible = false;
        }

        private void FormatarNomeBanco()
        {
            form.Text = "Nome do Banco de Dados";
            form.lblTextoSolicitado.Text = "Insira o nome do banco de dados do sistema:";
            form.btnAcao1.Visible = false;
        }

        private void FormatarSenhaBanco()
        {
            form.Text = "Senha do Banco de Dados";
            form.lblTextoSolicitado.Text = "Insira a senha do banco de dados do sistema:";
            form.btnAcao1.Visible = false;
            form.txtDadoSolicitado.PasswordChar = '*';
        }

        private void FormatarAssinaturaRepresentante()
        {
            form.Text = "Assinatura do representante";
            form.lblTextoSolicitado.Text = "Insira a assinatura:";
            form.btnAcao1.Visible = true;
            form.btnAcao1.Text = "Ver Assinatura";
            form.btnAcao1.Click += btnVerDados;
            form.txtDadoSolicitado.PasswordChar = '*';
        }

        private void Cancelar()
        {
            form.Close();
        }


        private void btnGerarChave(object? sender, EventArgs e)
        {
            form.txtDadoSolicitado.Text = Guid.NewGuid().ToString();
        }

        private void btnVerDados(object? sender, EventArgs e)
        {
            if(form.txtDadoSolicitado.PasswordChar == '*')
                form.txtDadoSolicitado.PasswordChar = '\0';
            else
                form.txtDadoSolicitado.PasswordChar = '*';            
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
            else if (Formato == Nucleo.Base.Enumeradores.Prompt.Dado.AssinaturaRepresentante)
                FormatarAssinaturaRepresentante();
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
