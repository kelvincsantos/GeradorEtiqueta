namespace GerarEtiquetas.Forms.Telas
{
    partial class GerarEtiqueta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tcClientes = new TabControl();
            tpPesquisar = new TabPage();
            gbImportacao = new GroupBox();
            btnPlanilhaPadrao = new Button();
            btnImportar = new Button();
            pnBotoes = new Panel();
            btnEnviarEtiquetas = new Button();
            dgvEtiquetas = new DataGridView();
            gbDadosNovo = new GroupBox();
            btnExcluir = new Button();
            btnSalvar = new Button();
            txtDataCalibracao = new TextBox();
            lblPreVisualizacao = new Label();
            lblDataCalibracao = new Label();
            pbPreVisualizacao = new PictureBox();
            txtNroCertificacao = new TextBox();
            txtProximaCalibracao = new TextBox();
            lblProximaCalibracao = new Label();
            txtDiretorioLaudo = new TextBox();
            lblDiretorioLaudo = new Label();
            txtNumeroIdentificacao = new TextBox();
            lblNroIdentificacao = new Label();
            lblNumeroCertificacao = new Label();
            btnVisualizarQRCode = new Button();
            ArquivoExterno = new OpenFileDialog();
            tcClientes.SuspendLayout();
            tpPesquisar.SuspendLayout();
            gbImportacao.SuspendLayout();
            pnBotoes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEtiquetas).BeginInit();
            gbDadosNovo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbPreVisualizacao).BeginInit();
            SuspendLayout();
            // 
            // tcClientes
            // 
            tcClientes.Controls.Add(tpPesquisar);
            tcClientes.Dock = DockStyle.Fill;
            tcClientes.Location = new Point(0, 0);
            tcClientes.Name = "tcClientes";
            tcClientes.SelectedIndex = 0;
            tcClientes.Size = new Size(788, 450);
            tcClientes.TabIndex = 0;
            // 
            // tpPesquisar
            // 
            tpPesquisar.BackColor = SystemColors.Control;
            tpPesquisar.Controls.Add(gbImportacao);
            tpPesquisar.Controls.Add(pnBotoes);
            tpPesquisar.Controls.Add(dgvEtiquetas);
            tpPesquisar.Controls.Add(gbDadosNovo);
            tpPesquisar.Location = new Point(4, 24);
            tpPesquisar.Name = "tpPesquisar";
            tpPesquisar.Padding = new Padding(3);
            tpPesquisar.Size = new Size(780, 422);
            tpPesquisar.TabIndex = 0;
            tpPesquisar.Text = "Pesquisa";
            // 
            // gbImportacao
            // 
            gbImportacao.Controls.Add(btnPlanilhaPadrao);
            gbImportacao.Controls.Add(btnImportar);
            gbImportacao.Location = new Point(647, 6);
            gbImportacao.Name = "gbImportacao";
            gbImportacao.Size = new Size(123, 144);
            gbImportacao.TabIndex = 1;
            gbImportacao.TabStop = false;
            gbImportacao.Text = "Importação";
            // 
            // btnPlanilhaPadrao
            // 
            btnPlanilhaPadrao.Location = new Point(6, 77);
            btnPlanilhaPadrao.Name = "btnPlanilhaPadrao";
            btnPlanilhaPadrao.Size = new Size(111, 59);
            btnPlanilhaPadrao.TabIndex = 16;
            btnPlanilhaPadrao.Text = "Planilha Padrão\r\nde Importação";
            btnPlanilhaPadrao.UseVisualStyleBackColor = true;
            // 
            // btnImportar
            // 
            btnImportar.Location = new Point(6, 22);
            btnImportar.Name = "btnImportar";
            btnImportar.Size = new Size(111, 49);
            btnImportar.TabIndex = 15;
            btnImportar.Text = "Importar do Excel";
            btnImportar.UseVisualStyleBackColor = true;
            // 
            // pnBotoes
            // 
            pnBotoes.BackColor = SystemColors.ButtonShadow;
            pnBotoes.Controls.Add(btnEnviarEtiquetas);
            pnBotoes.Dock = DockStyle.Bottom;
            pnBotoes.Location = new Point(3, 372);
            pnBotoes.Name = "pnBotoes";
            pnBotoes.Size = new Size(774, 47);
            pnBotoes.TabIndex = 3;
            // 
            // btnEnviarEtiquetas
            // 
            btnEnviarEtiquetas.Location = new Point(346, 3);
            btnEnviarEtiquetas.Name = "btnEnviarEtiquetas";
            btnEnviarEtiquetas.Size = new Size(94, 39);
            btnEnviarEtiquetas.TabIndex = 1;
            btnEnviarEtiquetas.Text = "Enviar";
            btnEnviarEtiquetas.UseVisualStyleBackColor = true;
            // 
            // dgvEtiquetas
            // 
            dgvEtiquetas.BackgroundColor = SystemColors.Control;
            dgvEtiquetas.BorderStyle = BorderStyle.None;
            dgvEtiquetas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEtiquetas.Location = new Point(8, 156);
            dgvEtiquetas.Name = "dgvEtiquetas";
            dgvEtiquetas.Size = new Size(762, 210);
            dgvEtiquetas.TabIndex = 2;
            // 
            // gbDadosNovo
            // 
            gbDadosNovo.Controls.Add(btnExcluir);
            gbDadosNovo.Controls.Add(btnSalvar);
            gbDadosNovo.Controls.Add(txtDataCalibracao);
            gbDadosNovo.Controls.Add(lblPreVisualizacao);
            gbDadosNovo.Controls.Add(lblDataCalibracao);
            gbDadosNovo.Controls.Add(pbPreVisualizacao);
            gbDadosNovo.Controls.Add(txtNroCertificacao);
            gbDadosNovo.Controls.Add(txtProximaCalibracao);
            gbDadosNovo.Controls.Add(lblProximaCalibracao);
            gbDadosNovo.Controls.Add(txtDiretorioLaudo);
            gbDadosNovo.Controls.Add(lblDiretorioLaudo);
            gbDadosNovo.Controls.Add(txtNumeroIdentificacao);
            gbDadosNovo.Controls.Add(lblNroIdentificacao);
            gbDadosNovo.Controls.Add(lblNumeroCertificacao);
            gbDadosNovo.Controls.Add(btnVisualizarQRCode);
            gbDadosNovo.Location = new Point(8, 6);
            gbDadosNovo.Name = "gbDadosNovo";
            gbDadosNovo.Size = new Size(633, 144);
            gbDadosNovo.TabIndex = 0;
            gbDadosNovo.TabStop = false;
            gbDadosNovo.Text = "Dados da Etiqueta";
            // 
            // btnExcluir
            // 
            btnExcluir.Location = new Point(398, 113);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(77, 23);
            btnExcluir.TabIndex = 7;
            btnExcluir.Text = "Excluir";
            btnExcluir.UseVisualStyleBackColor = true;
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(315, 113);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(77, 23);
            btnSalvar.TabIndex = 6;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            // 
            // txtDataCalibracao
            // 
            txtDataCalibracao.Location = new Point(6, 84);
            txtDataCalibracao.MaxLength = 10;
            txtDataCalibracao.Name = "txtDataCalibracao";
            txtDataCalibracao.Size = new Size(90, 23);
            txtDataCalibracao.TabIndex = 2;
            txtDataCalibracao.TextAlign = HorizontalAlignment.Center;
            // 
            // lblPreVisualizacao
            // 
            lblPreVisualizacao.AutoSize = true;
            lblPreVisualizacao.Location = new Point(481, 18);
            lblPreVisualizacao.Name = "lblPreVisualizacao";
            lblPreVisualizacao.Size = new Size(91, 15);
            lblPreVisualizacao.TabIndex = 13;
            lblPreVisualizacao.Text = "Pré Visualização";
            // 
            // lblDataCalibracao
            // 
            lblDataCalibracao.AutoSize = true;
            lblDataCalibracao.Location = new Point(6, 66);
            lblDataCalibracao.Name = "lblDataCalibracao";
            lblDataCalibracao.Size = new Size(90, 15);
            lblDataCalibracao.TabIndex = 2;
            lblDataCalibracao.Text = "Data Calibração";
            // 
            // pbPreVisualizacao
            // 
            pbPreVisualizacao.Location = new Point(481, 36);
            pbPreVisualizacao.Name = "pbPreVisualizacao";
            pbPreVisualizacao.Size = new Size(138, 100);
            pbPreVisualizacao.TabIndex = 12;
            pbPreVisualizacao.TabStop = false;
            // 
            // txtNroCertificacao
            // 
            txtNroCertificacao.Location = new Point(197, 84);
            txtNroCertificacao.Name = "txtNroCertificacao";
            txtNroCertificacao.Size = new Size(137, 23);
            txtNroCertificacao.TabIndex = 4;
            // 
            // txtProximaCalibracao
            // 
            txtProximaCalibracao.Location = new Point(102, 84);
            txtProximaCalibracao.MaxLength = 10;
            txtProximaCalibracao.Name = "txtProximaCalibracao";
            txtProximaCalibracao.Size = new Size(89, 23);
            txtProximaCalibracao.TabIndex = 3;
            txtProximaCalibracao.TextAlign = HorizontalAlignment.Center;
            // 
            // lblProximaCalibracao
            // 
            lblProximaCalibracao.AutoSize = true;
            lblProximaCalibracao.Location = new Point(102, 66);
            lblProximaCalibracao.Name = "lblProximaCalibracao";
            lblProximaCalibracao.Size = new Size(93, 15);
            lblProximaCalibracao.TabIndex = 8;
            lblProximaCalibracao.Text = "Prox. Calibração";
            // 
            // txtDiretorioLaudo
            // 
            txtDiretorioLaudo.Location = new Point(6, 36);
            txtDiretorioLaudo.Name = "txtDiretorioLaudo";
            txtDiretorioLaudo.Size = new Size(388, 23);
            txtDiretorioLaudo.TabIndex = 0;
            // 
            // lblDiretorioLaudo
            // 
            lblDiretorioLaudo.AutoSize = true;
            lblDiretorioLaudo.Location = new Point(6, 18);
            lblDiretorioLaudo.Name = "lblDiretorioLaudo";
            lblDiretorioLaudo.Size = new Size(89, 15);
            lblDiretorioLaudo.TabIndex = 10;
            lblDiretorioLaudo.Text = "Diretório Laudo";
            // 
            // txtNumeroIdentificacao
            // 
            txtNumeroIdentificacao.Location = new Point(340, 84);
            txtNumeroIdentificacao.Name = "txtNumeroIdentificacao";
            txtNumeroIdentificacao.Size = new Size(135, 23);
            txtNumeroIdentificacao.TabIndex = 5;
            // 
            // lblNroIdentificacao
            // 
            lblNroIdentificacao.AutoSize = true;
            lblNroIdentificacao.Location = new Point(340, 66);
            lblNroIdentificacao.Name = "lblNroIdentificacao";
            lblNroIdentificacao.Size = new Size(98, 15);
            lblNroIdentificacao.TabIndex = 6;
            lblNroIdentificacao.Text = "Nro Identificação";
            // 
            // lblNumeroCertificacao
            // 
            lblNumeroCertificacao.AutoSize = true;
            lblNumeroCertificacao.Location = new Point(197, 66);
            lblNumeroCertificacao.Name = "lblNumeroCertificacao";
            lblNumeroCertificacao.Size = new Size(93, 15);
            lblNumeroCertificacao.TabIndex = 4;
            lblNumeroCertificacao.Text = "Nro Certificação";
            // 
            // btnVisualizarQRCode
            // 
            btnVisualizarQRCode.Location = new Point(400, 36);
            btnVisualizarQRCode.Name = "btnVisualizarQRCode";
            btnVisualizarQRCode.Size = new Size(75, 24);
            btnVisualizarQRCode.TabIndex = 1;
            btnVisualizarQRCode.Text = "Visualizar";
            btnVisualizarQRCode.UseVisualStyleBackColor = true;
            // 
            // ArquivoExterno
            // 
            ArquivoExterno.FileName = "openFileDialog1";
            // 
            // GerarEtiqueta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(788, 450);
            Controls.Add(tcClientes);
            Name = "GerarEtiqueta";
            Text = "Gerar Etiquetas";
            tcClientes.ResumeLayout(false);
            tpPesquisar.ResumeLayout(false);
            gbImportacao.ResumeLayout(false);
            pnBotoes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvEtiquetas).EndInit();
            gbDadosNovo.ResumeLayout(false);
            gbDadosNovo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbPreVisualizacao).EndInit();
            ResumeLayout(false);
        }

        #endregion
        internal System.Windows.Forms.Button btnEnviarEtiquetas;
        internal System.Windows.Forms.Button btnVisualizarQRCode;
        internal System.Windows.Forms.TextBox txtDataCalibracao;
        private System.Windows.Forms.Label lblDataCalibracao;
        internal System.Windows.Forms.TabPage tpPesquisar;
        internal System.Windows.Forms.TextBox txtProximaCalibracao;
        private System.Windows.Forms.Label lblProximaCalibracao;
        internal System.Windows.Forms.TextBox txtNumeroIdentificacao;
        private System.Windows.Forms.Label lblNroIdentificacao;
        internal System.Windows.Forms.TextBox txtNroCertificacao;
        private System.Windows.Forms.Label lblNumeroCertificacao;
        internal System.Windows.Forms.TextBox txtDiretorioLaudo;
        private System.Windows.Forms.Label lblDiretorioLaudo;
        private System.Windows.Forms.Label lblPreVisualizacao;
        internal System.Windows.Forms.PictureBox pbPreVisualizacao;
        private GroupBox gbDadosNovo;
        private Panel pnBotoes;
        internal DataGridView dgvEtiquetas;
        internal TabControl tcClientes;
        internal Button btnExcluir;
        internal Button btnSalvar;
        private GroupBox gbImportacao;
        internal Button btnPlanilhaPadrao;
        internal Button btnImportar;
        internal OpenFileDialog ArquivoExterno;
    }
}