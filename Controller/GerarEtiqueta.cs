using Nucleo.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using GerarEtiquetas.Comum;
using System.Linq;
using Microsoft.VisualBasic;
using ClosedXML.Excel;
using GerarEtiquetas.Forms.Comum;

namespace GerarEtiquetas.Forms.Controller
{
    public class GerarEtiqueta
    {
        private Forms.Telas.GerarEtiqueta form;

        private List<Etiqueta> etiquetas;
        private Etiqueta? Editando;

        public GerarEtiqueta(Forms.Telas.GerarEtiqueta e)
        {
            this.form = e;

            form.Load += Form_Load;

            form.btnVisualizarQRCode.Click += btnVisualizarQRCode_Click;
            form.btnEnviarEtiquetas.Click += btnEnviarEtiquetas_Click;

            form.btnImportar.Click += btnImportar_Click;
            form.btnPlanilhaPadrao.Click += btnPlanilhaPadrao_Click;

            form.btnSalvar.Click += BtnSalvar_Click;
            form.btnExcluir.Click += BtnExcluir_Click;


            form.txtDataCalibracao.KeyPress += Leiaute.TextBox.KeyPress_Data;
            form.txtDataCalibracao.LostFocus += Leiaute.TextBox.LostFocus_Data;

            form.txtProximaCalibracao.KeyPress += Leiaute.TextBox.KeyPress_Data;
            form.txtProximaCalibracao.LostFocus += Leiaute.TextBox.LostFocus_Data;

            form.txtNumeroIdentificacao.KeyPress += Leiaute.TextBox.KeyPress_Integer;
            form.txtNroCertificacao.KeyPress += Leiaute.TextBox.KeyPress_Integer;

            form.dgvEtiquetas.DoubleClick += dgvEtiquetas_DoubleClick;

            etiquetas = new List<Etiqueta>();
        }

        private void Form_Load(object? sender, EventArgs e)
        {
            CarregarEtiquetasPendentes();
        }

        private void BtnExcluir_Click(object? sender, EventArgs e)
        {
            Excluir();
        }

        private void dgvEtiquetas_DoubleClick(object? sender, EventArgs e)
        {
            Selecionar();
        }

        private void BtnSalvar_Click(object? sender, EventArgs e)
        {
            Adicionar();
        }

        private void btnImportar_Click(object? sender, EventArgs e)
        {
            CarregarLista();
        }

        private void btnPlanilhaPadrao_Click(object? sender, EventArgs e)
        {
            GerarArquivoPadrao();
        }

        private void btnVisualizarQRCode_Click(object? sender, EventArgs e)
        {
            Visualizar();
        }

        private void btnEnviarEtiquetas_Click(object? sender, EventArgs e)
        {
            Salvar();
            Limpar();
        }

        private void Limpar()
        {
            form.txtDataCalibracao.Text = string.Empty;
            form.txtDiretorioLaudo.Text = string.Empty;
            form.txtNroCertificacao.Text = string.Empty;
            form.txtNumeroIdentificacao.Text = string.Empty;
            form.txtProximaCalibracao.Text = string.Empty;
            form.pbPreVisualizacao.Image = null;
            Editando = null;
        }

        private void Selecionar()
        {
            foreach (DataGridViewRow Row in form.dgvEtiquetas.SelectedRows)
            {
                Etiqueta Item = (Etiqueta)Row.DataBoundItem;

                CarregarDetalhes(Item);
            }
        }

        private void CarregarDetalhes(Etiqueta e)
        {
            if (e == null)
            {
                Limpar();
                return;
            }


            form.txtDataCalibracao.Text = e.DataCalibracao.GetValueOrDefault().ToShortDateString();
            form.txtProximaCalibracao.Text = e.ProximaCalibracao.GetValueOrDefault().ToShortDateString();

            form.txtDiretorioLaudo.Text = e.DiretorioLaudo;
            form.txtNroCertificacao.Text = e.NumeroCertificado;
            form.txtNumeroIdentificacao.Text = e.NumeroIdentificacao;

            form.pbPreVisualizacao.Image = Nucleo.Operacoes.Aplicacao.CodigoBarras.GenerateQRCode(form.txtDiretorioLaudo.Text);
            Editando = e;
        }

        private void CarregarEtiquetasPendentes()
        {
            etiquetas = new List<Etiqueta>();

            Nucleo.Operacoes.BO.Etiquetas BO = new Nucleo.Operacoes.BO.Etiquetas(Program.Ambiente.Banco);

            etiquetas = BO.BuscarPendentesDeImpressao();

            Mostrar();
            form.txtDiretorioLaudo.Focus();
        }

        private void Mostrar()
        {
            form.dgvEtiquetas.DataSource = null;
            //CARREGAR UM GRID NA TELA COM AS ETIQUETAS JÁ ADICIONADAS NA LISTA


            if (etiquetas.Count == 0)
            {
                //Mensagem.Alerta("Registros não encontrados");

                return;
            }

            List<Telas.Controls.Grid.Column> Columns = new List<Telas.Controls.Grid.Column>();

            Columns.Add(new Telas.Controls.Grid.Column() { Titulo = "Data Calibração", Referencia = "DataCalibracao", Tamanho = 84 });
            Columns.Add(new Telas.Controls.Grid.Column() { Titulo = "Próx. Calibração", Referencia = "ProximaCalibracao", Tamanho = 84 });
            Columns.Add(new Telas.Controls.Grid.Column() { Titulo = "Nro. Certificado", Referencia = "NumeroCertificado", Tamanho = 120, Alinhamento = DataGridViewContentAlignment.MiddleLeft });
            Columns.Add(new Telas.Controls.Grid.Column() { Titulo = "Nro. Identificação", Referencia = "NumeroIdentificacao", Tamanho = 120, Alinhamento = DataGridViewContentAlignment.MiddleLeft });
            Columns.Add(new Telas.Controls.Grid.Column() { Titulo = "Laudo", Referencia = "DiretorioLaudo", Tamanho = 484, Alinhamento = DataGridViewContentAlignment.MiddleLeft });

            Telas.Controls.Grid.Init(form.dgvEtiquetas, Columns);

            form.dgvEtiquetas.DataSource = etiquetas;

            form.dgvEtiquetas.Focus();
        }

        private void Adicionar()
        {
            if (string.IsNullOrWhiteSpace(form.txtDataCalibracao.Text))
            {
                Mensagem.Alerta("Campo data de calibração obrigatório para gerar etiqueta.");
                return;
            }

            if (string.IsNullOrWhiteSpace(form.txtProximaCalibracao.Text))
            {
                Mensagem.Alerta("Campo próxima calibração obrigatório para gerar etiqueta.");
                return;
            }

            if (string.IsNullOrWhiteSpace(form.txtNumeroIdentificacao.Text))
            {
                Mensagem.Alerta("Campo núm. identificação obrigatório para gerar etiqueta.");
                return;
            }

            if (string.IsNullOrWhiteSpace(form.txtNroCertificacao.Text))
            {
                Mensagem.Alerta("Campo núm. Certificação obrigatório para gerar etiqueta.");
                return;
            }

            if (string.IsNullOrWhiteSpace(form.txtDiretorioLaudo.Text))
            {
                Mensagem.Alerta("Campo diretório do Laudo obrigatório para gerar etiqueta.");
                return;
            }

            if (Editando == null)
                Editando = new Etiqueta() { ID = Guid.NewGuid().ToString() };


            Editando.DataCalibracao = Convert.ToDateTime(form.txtDataCalibracao.Text.Trim());
            Editando.DiretorioLaudo = form.txtDiretorioLaudo.Text.Trim();
            Editando.NumeroCertificado = form.txtNroCertificacao.Text.Trim();
            Editando.NumeroIdentificacao = form.txtNumeroIdentificacao.Text.Trim();
            Editando.ProximaCalibracao = Convert.ToDateTime(form.txtProximaCalibracao.Text.Trim());

            Nucleo.Operacoes.BO.Etiquetas BO = new Nucleo.Operacoes.BO.Etiquetas(Program.Ambiente.Banco);
            if (BO.InserirOuAlterar(Editando))
                Mensagem.Sucesso("Etiqueta cadastrada com sucesso.");

            Limpar();
            CarregarEtiquetasPendentes();
        }

        private void Excluir()
        {
            if (Editando == null)
                return;

            if (etiquetas == null)
                return;


            Nucleo.Operacoes.BO.Etiquetas BO = new Nucleo.Operacoes.BO.Etiquetas(Program.Ambiente.Banco);
            if (BO.Deletar(Editando))
                Mensagem.Sucesso("Etiqueta excluída com sucesso.");

            Limpar();
            CarregarEtiquetasPendentes();
        }

        private void Visualizar()
        {
            form.pbPreVisualizacao.Image = Nucleo.Operacoes.Aplicacao.CodigoBarras.GenerateQRCode(form.txtDiretorioLaudo.Text);
        }

        public string GerarArquivoPadrao()
        {
            try
            {
                string Arquivo = "C:\\ETQ Padrao\\LoteEtiquetas.csv";


                if (!Directory.Exists("C:\\ETQ Padrao"))
                    Directory.CreateDirectory("C:\\ETQ Padrao");

                StreamWriter sw = new StreamWriter(Arquivo, false);

                sw.WriteLine("NumeroIdentificacao;NumeroCertificado;DataCalibracao;ProximaCalibracao;DiretorioLaudo;");
                sw.WriteLine("                   ;                 ;              ;                 ;              ;");

                sw.Close();

                return Arquivo;
            }
            catch (Exception)
            {
                return string.Empty;
            }

        }

        private void CarregarLista()
        {
            Importar();
            CarregarEtiquetasPendentes();
        }

        private void Importar()
        {
            string arquivo = ArquivoImportacao();

            if (string.IsNullOrEmpty(arquivo))
                return;

            XLWorkbook xls = new XLWorkbook(arquivo);
            IXLWorksheet? plan1 = xls.Worksheets.FirstOrDefault();

            if (plan1 == null)
            {
                Mensagem.Alerta("Nenhum registro encontrado no arquivo.");
                return;
            }

            if (plan1.Rows().Count() < 2)
            {
                Mensagem.Alerta("Nenhum registro encontrado no arquivo.");
                return;
            }

            Nucleo.Operacoes.BO.Etiquetas BO = new Nucleo.Operacoes.BO.Etiquetas(Program.Ambiente.Banco);
            foreach (IXLRows row in plan1.Rows())
            {
                Etiqueta item = new Etiqueta();

                //item.DataCalibracao = row.Cell().Value.ToString();
                //item.ProximaCalibracao = row.Cell().Value.ToString();
                //item.NumeroCertificado = row.Cell().Value.ToString();
                //item.NumeroIdentificacao = row.Cell().Value.ToString();
                //item.DiretorioLaudo = row.Cell().Value.ToString();

                //plan1.Cell(String.Format("U{0}", i)).Value.ToString;

                if (!BO.InserirOuAlterar(item))
                {
                    Mensagem.Erro("Erro ao inserir etiqueta por importação.");
                    return;
                }
                    
            }
        }

        private string ArquivoImportacao()
        {
            string retorno = string.Empty;
            form.ArquivoExterno.Title = "Selecione caminho do Arquivo Excel";
            form.ArquivoExterno.InitialDirectory = Application.StartupPath + "\\";
            form.ArquivoExterno.Filter = "XLSX (*.xlsx)|*.xlsx|" + "Todos arquivos (*.*)|*.*";
            form.ArquivoExterno.CheckFileExists = true;
            form.ArquivoExterno.CheckPathExists = true;
            form.ArquivoExterno.FilterIndex = 2;
            form.ArquivoExterno.RestoreDirectory = true;
            form.ArquivoExterno.ReadOnlyChecked = true;
            form.ArquivoExterno.ShowReadOnly = true;

            if (form.ArquivoExterno.ShowDialog() == DialogResult.OK)
                retorno = form.ArquivoExterno.FileName;

            return retorno;
        }

        private void Salvar()
        {
            try
            {
                if (etiquetas.Count() <= 0)
                {
                    Mensagem.Alerta("Ñão foram encontradas etiquetas para impressão");
                    return;
                }

                Nucleo.Operacoes.BO.Etiquetas BO = new Nucleo.Operacoes.BO.Etiquetas(Program.Ambiente.Banco);
                foreach (Etiqueta item in etiquetas)
                {
                    if (BO.InserirOuAlterar(item))
                    {
                        Mensagem.Sucesso("Etiqueta inserida com sucesso.");
                        BO.GerarFilaImpressao(item);
                    }
                }
            }
            catch (Exception ex)
            {
                Mensagem.Erro("Erro ao salvar etiquetas para a fila de impressão", ex);
                throw;
            }


        }
    }
}
