using GerarEtiquetas.Forms.Comum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data = Nucleo.Data;
using GerarEtiquetas.Comum;
using BO = Nucleo.Operacoes.BO;
using Nucleo.Data;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Wordprocessing;

namespace GerarEtiquetas.Forms.Controller
{
    public class Configuracoes
    {
        private Telas.Configuracoes form;
        private BO.Configuracao BO;

        public Data.PropriedadeConfiguracao? configuracao;

        public Configuracoes(Telas.Configuracoes e)
        {
            form = e;

            BO = new BO.Configuracao(Program.Ambiente.Banco);

            form.Load += Form_Load;
            form.btnLimpar.Click += BtnLimpar_Click;
            form.btnSalvar.Click += BtnSalvar_Click;

            form.cbCampo.KeyPress += Leiaute.TextBox.KeyPress;
            form.txtValorConfiguracao.KeyPress += Leiaute.TextBox.KeyPress;

            form.txtValorConfiguracao.KeyDown += TxtDadoSolicitado_KeyDown;
        }

        private void TxtDadoSolicitado_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Salvar();
            else if (e.KeyCode == Keys.Escape)
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
            CarregarCombo();
            Carregar();
            //Caso tenha algum preparo para cada formato, fazer aqui
        }


        private void Cancelar()
        {
            form.Close();
        }

        private void Salvar()
        {
            try
            {
                //if (configuracao == null)
                //    return;

                if (string.IsNullOrWhiteSpace(form.cbCampo.Text))
                {
                    Mensagem.Validacao("O Campo da configuração é obrigatório.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(form.txtValorConfiguracao.Text))
                {
                    Mensagem.Validacao("O valor da configuração é obrigatório.");
                    return;
                }

                if (configuracao == null)
                {
                    configuracao = new PropriedadeConfiguracao()
                    {
                        Campo = form.cbCampo.Text,
                        Valor = form.txtValorConfiguracao.Text,
                    };
                }


                BO.Inserir(configuracao);
            }
            catch (Exception ex)
            {
                Mensagem.Erro("Erro ao salvar configuração. ", ex);
            }
            Carregar();
            Limpar();
        }

        private void Carregar()
        {
            form.dgvConfiguracoes.DataSource = null;

            List<Data.PropriedadeConfiguracao> propriedades = BO.Buscar();

            if (propriedades.Count == 0)
            {
                //Mensagem.Alerta("Registros não encontrados");

                return;
            }

            List<Telas.Controls.Grid.Column> Columns = new List<Telas.Controls.Grid.Column>();

            Columns.Add(new Telas.Controls.Grid.Column() { Titulo = "Configuração", Referencia = "Campo", Tamanho = 220 });
            Columns.Add(new Telas.Controls.Grid.Column() { Titulo = "Valor", Referencia = "Valor", Tamanho = 220 });

            Telas.Controls.Grid.Init(form.dgvConfiguracoes, Columns);

            form.dgvConfiguracoes.DataSource = propriedades;

            form.dgvConfiguracoes.Focus();

        }

        private void CarregarCombo()
        {
            List<Data.PropriedadeConfiguracao> propriedades = BO.Buscar();

            propriedades.AddRange(BO.BuscarDoObjeto().Where(x => !propriedades.Any(y => y.Campo == x.Campo)).ToList());

            List<Data.PropriedadeConfiguracao> source = new List<PropriedadeConfiguracao>();

            source.Add(new PropriedadeConfiguracao() { Campo = string.Empty, Valor = string.Empty });
            source.AddRange(propriedades);

            form.cbCampo.ValueMember = "Campo";
            form.cbCampo.DisplayMember = "Campo";
            form.cbCampo.DataSource = source;
        }

        private void Detalhes()
        {
            foreach (DataGridViewRow Row in form.dgvConfiguracoes.SelectedRows)
            {
                Data.PropriedadeConfiguracao Item = (Data.PropriedadeConfiguracao)Row.DataBoundItem;

                CarregarDetalhes(Item);
            }

        }

        private void CarregarDetalhes(Data.PropriedadeConfiguracao e)
        {
            configuracao = e;
            form.cbCampo.Text = e.Campo;
            form.txtValorConfiguracao.Text = e.Valor;
        }

        private void Limpar()
        {
            configuracao = null;
            form.cbCampo.Text = string.Empty;
            form.txtValorConfiguracao.Text = string.Empty;
            form.cbCampo.Focus();
        }


    }
}
