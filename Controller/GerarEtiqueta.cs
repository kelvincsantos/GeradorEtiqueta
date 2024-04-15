using Nucleo.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using GerarEtiquetas.Forms.Comum;
using System.Linq;
using Microsoft.VisualBasic;
using ClosedXML.Excel;

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

            form.btnVisualizarQRCode.Click += btnVisualizarQRCode_Click;
            form.btnImprimirEtiqueta.Click += BtnImprimirEtiqueta_Click;

            form.btnImportar.Click += btnImportar_Click;
            form.btnPlanilhaPadrao.Click += btnPlanilhaPadrao_Click;

            form.btnSalvar.Click += BtnSalvar_Click;
            form.btnExcluir.Click += BtnExcluir_Click;

            form.dgvEtiquetas.DoubleClick += dgvEtiquetas_DoubleClick;

            etiquetas = new List<Etiqueta>();
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

        private void BtnImprimirEtiqueta_Click(object? sender, EventArgs e)
        {
            Limpar();
        }

        private void Limpar()
        {
            form.txtDataCalibracao.Text = string.Empty;
            form.txtDiretorioLaudo.Text = string.Empty;
            form.txtNroCertificacao.Text = string.Empty;
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
            form.txtDataCalibracao.Text = e.DataCalibracao.GetValueOrDefault().ToShortDateString();
            form.txtProximaCalibracao.Text = e.ProximaCalibracao.GetValueOrDefault().ToShortDateString();

            form.txtDiretorioLaudo.Text = e.DiretorioLaudo;
            form.txtNroCertificacao.Text = e.NumeroCertificado;
            form.txtNumeroIdentificacao.Text = e.NumeroIdentificacao;

            form.pbPreVisualizacao.Image = Nucleo.Operacoes.Aplicacao.CodigoBarras.GenerateQRCode(form.txtDiretorioLaudo.Text);
            Editando = e;
        }

        private void Mostrar()
        {
            //CARREGAR UM GRID NA TELA COM AS ETIQUETAS JÁ ADICIONADAS NA LISTA


            if (etiquetas.Count == 0)
            {
                //Mensagem.Alerta("Registros não encontrados");

                return;
            }

            List<Telas.Controls.Grid.Column> Columns = new List<Telas.Controls.Grid.Column>();

            Columns.Add(new Telas.Controls.Grid.Column() { Titulo = "Pedido Applay", Referencia = "PedidoApp", Tamanho = 50 });
            Columns.Add(new Telas.Controls.Grid.Column() { Titulo = "CPF/CNPJ", Referencia = "Documento", Tamanho = 50 });
            Columns.Add(new Telas.Controls.Grid.Column() { Titulo = "Nome", Referencia = "NomeCliente", Tamanho = 120, Alinhamento = DataGridViewContentAlignment.MiddleLeft });
            Columns.Add(new Telas.Controls.Grid.Column() { Titulo = "Qtd. Produto", Referencia = "QuantidadeProdutos", Tamanho = 50, Alinhamento = DataGridViewContentAlignment.MiddleRight });
            Columns.Add(new Telas.Controls.Grid.Column() { Titulo = "Vl. Total", Referencia = "ValorProdutos", Tamanho = 50, Alinhamento = DataGridViewContentAlignment.MiddleRight });

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

            if (etiquetas == null)
                etiquetas = new List<Etiqueta>();

            if (Editando != null)
                etiquetas.Remove(Editando);
            else
                Editando = new Etiqueta() { ID = Guid.NewGuid().ToString() };


            Editando.DataCalibracao = Convert.ToDateTime(form.txtDataCalibracao.Text.Trim());
            Editando.DiretorioLaudo = form.txtDiretorioLaudo.Text.Trim();
            Editando.NumeroCertificado = form.txtNroCertificacao.Text.Trim();
            Editando.NumeroIdentificacao = form.txtNumeroIdentificacao.Text.Trim();
            Editando.ProximaCalibracao = Convert.ToDateTime(form.txtProximaCalibracao.Text.Trim());

            etiquetas.Add(Editando);
        }

        private void Excluir()
        {
            if (Editando == null)
                return;

            if (etiquetas == null)
                return;

            etiquetas.Remove(Editando);

            Limpar();
            Mostrar();
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
            Mostrar();
        }

        private void Importar()
        {
            string arquivo = ArquivoImportacao();

            if (string.IsNullOrEmpty(arquivo))
                return;

            XLWorkbook xls = new XLWorkbook(arquivo);
            IXLWorksheet? plan1 = xls.Worksheets.FirstOrDefault();

            if(plan1 == null)
            {
                Mensagem.Alerta("Nenhum registro encontrado no arquivo.");
                return;
            }

            if (plan1.Rows().Count() < 2)
            {
                Mensagem.Alerta("Nenhum registro encontrado no arquivo.");
                return;
            }

            foreach (IXLRows row in plan1.Rows())
            {
                Etiqueta item = new Etiqueta();

                //item.DataCalibracao = row.Cell().Value.ToString();
                //item.ProximaCalibracao = row.Cell().Value.ToString();
                //item.NumeroCertificado = row.Cell().Value.ToString();
                //item.NumeroIdentificacao = row.Cell().Value.ToString();
                //item.DiretorioLaudo = row.Cell().Value.ToString();

                //plan1.Cell(String.Format("U{0}", i)).Value.ToString;
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
    }
}
