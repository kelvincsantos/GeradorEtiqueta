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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GerarEtiqueta));
            tcClientes = new TabControl();
            tpPesquisar = new TabPage();
            gbImportacao = new GroupBox();
            btnPlanilhaPadrao = new Button();
            btnImportar = new Button();
            pnBotoes = new Panel();
            btnConfiguracoes = new Button();
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
            tcClientes.Margin = new Padding(3, 4, 3, 4);
            tcClientes.Name = "tcClientes";
            tcClientes.SelectedIndex = 0;
            tcClientes.Size = new Size(900, 600);
            tcClientes.TabIndex = 0;
            // 
            // tpPesquisar
            // 
            tpPesquisar.BackColor = SystemColors.Control;
            tpPesquisar.Controls.Add(gbImportacao);
            tpPesquisar.Controls.Add(pnBotoes);
            tpPesquisar.Controls.Add(dgvEtiquetas);
            tpPesquisar.Controls.Add(gbDadosNovo);
            tpPesquisar.Location = new Point(4, 29);
            tpPesquisar.Margin = new Padding(3, 4, 3, 4);
            tpPesquisar.Name = "tpPesquisar";
            tpPesquisar.Padding = new Padding(3, 4, 3, 4);
            tpPesquisar.Size = new Size(892, 567);
            tpPesquisar.TabIndex = 0;
            tpPesquisar.Text = "Pesquisa";
            // 
            // gbImportacao
            // 
            gbImportacao.Controls.Add(btnPlanilhaPadrao);
            gbImportacao.Controls.Add(btnImportar);
            gbImportacao.Location = new Point(739, 8);
            gbImportacao.Margin = new Padding(3, 4, 3, 4);
            gbImportacao.Name = "gbImportacao";
            gbImportacao.Padding = new Padding(3, 4, 3, 4);
            gbImportacao.Size = new Size(141, 192);
            gbImportacao.TabIndex = 1;
            gbImportacao.TabStop = false;
            gbImportacao.Text = "Importação";
            // 
            // btnPlanilhaPadrao
            // 
            btnPlanilhaPadrao.Location = new Point(7, 112);
            btnPlanilhaPadrao.Margin = new Padding(3, 4, 3, 4);
            btnPlanilhaPadrao.Name = "btnPlanilhaPadrao";
            btnPlanilhaPadrao.Size = new Size(127, 69);
            btnPlanilhaPadrao.TabIndex = 16;
            btnPlanilhaPadrao.Text = "Planilha Padrão\r\nde Importação";
            btnPlanilhaPadrao.UseVisualStyleBackColor = true;
            // 
            // btnImportar
            // 
            btnImportar.Location = new Point(7, 24);
            btnImportar.Margin = new Padding(3, 4, 3, 4);
            btnImportar.Name = "btnImportar";
            btnImportar.Size = new Size(127, 70);
            btnImportar.TabIndex = 15;
            btnImportar.Text = "Importar do Excel";
            btnImportar.UseVisualStyleBackColor = true;
            // 
            // pnBotoes
            // 
            pnBotoes.BackColor = SystemColors.ButtonShadow;
            pnBotoes.Controls.Add(btnConfiguracoes);
            pnBotoes.Controls.Add(btnEnviarEtiquetas);
            pnBotoes.Dock = DockStyle.Bottom;
            pnBotoes.Location = new Point(3, 500);
            pnBotoes.Margin = new Padding(3, 4, 3, 4);
            pnBotoes.Name = "pnBotoes";
            pnBotoes.Size = new Size(886, 63);
            pnBotoes.TabIndex = 3;
            // 
            // btnConfiguracoes
            // 
            btnConfiguracoes.Image = (Image)resources.GetObject("btnConfiguracoes.Image");
            btnConfiguracoes.Location = new Point(808, 4);
            btnConfiguracoes.Margin = new Padding(3, 4, 3, 4);
            btnConfiguracoes.Name = "btnConfiguracoes";
            btnConfiguracoes.Size = new Size(75, 54);
            btnConfiguracoes.TabIndex = 16;
            btnConfiguracoes.UseVisualStyleBackColor = true;
            // 
            // btnEnviarEtiquetas
            // 
            btnEnviarEtiquetas.Location = new Point(391, 4);
            btnEnviarEtiquetas.Margin = new Padding(3, 4, 3, 4);
            btnEnviarEtiquetas.Name = "btnEnviarEtiquetas";
            btnEnviarEtiquetas.Size = new Size(104, 54);
            btnEnviarEtiquetas.TabIndex = 1;
            btnEnviarEtiquetas.Text = "Enviar";
            btnEnviarEtiquetas.UseVisualStyleBackColor = true;
            // 
            // dgvEtiquetas
            // 
            dgvEtiquetas.BackgroundColor = SystemColors.Control;
            dgvEtiquetas.BorderStyle = BorderStyle.None;
            dgvEtiquetas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEtiquetas.Location = new Point(9, 208);
            dgvEtiquetas.Margin = new Padding(3, 4, 3, 4);
            dgvEtiquetas.Name = "dgvEtiquetas";
            dgvEtiquetas.RowHeadersWidth = 51;
            dgvEtiquetas.Size = new Size(871, 280);
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
            gbDadosNovo.Location = new Point(9, 8);
            gbDadosNovo.Margin = new Padding(3, 4, 3, 4);
            gbDadosNovo.Name = "gbDadosNovo";
            gbDadosNovo.Padding = new Padding(3, 4, 3, 4);
            gbDadosNovo.Size = new Size(723, 192);
            gbDadosNovo.TabIndex = 0;
            gbDadosNovo.TabStop = false;
            gbDadosNovo.Text = "Dados da Etiqueta";
            // 
            // btnExcluir
            // 
            btnExcluir.Location = new Point(455, 151);
            btnExcluir.Margin = new Padding(3, 4, 3, 4);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(88, 31);
            btnExcluir.TabIndex = 7;
            btnExcluir.Text = "Excluir";
            btnExcluir.UseVisualStyleBackColor = true;
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(360, 151);
            btnSalvar.Margin = new Padding(3, 4, 3, 4);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(88, 31);
            btnSalvar.TabIndex = 6;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            // 
            // txtDataCalibracao
            // 
            txtDataCalibracao.Location = new Point(7, 112);
            txtDataCalibracao.Margin = new Padding(3, 4, 3, 4);
            txtDataCalibracao.MaxLength = 10;
            txtDataCalibracao.Name = "txtDataCalibracao";
            txtDataCalibracao.Size = new Size(102, 27);
            txtDataCalibracao.TabIndex = 2;
            txtDataCalibracao.TextAlign = HorizontalAlignment.Center;
            // 
            // lblPreVisualizacao
            // 
            lblPreVisualizacao.AutoSize = true;
            lblPreVisualizacao.Location = new Point(550, 24);
            lblPreVisualizacao.Name = "lblPreVisualizacao";
            lblPreVisualizacao.Size = new Size(116, 20);
            lblPreVisualizacao.TabIndex = 13;
            lblPreVisualizacao.Text = "Pré Visualização";
            // 
            // lblDataCalibracao
            // 
            lblDataCalibracao.AutoSize = true;
            lblDataCalibracao.Location = new Point(7, 88);
            lblDataCalibracao.Name = "lblDataCalibracao";
            lblDataCalibracao.Size = new Size(116, 20);
            lblDataCalibracao.TabIndex = 2;
            lblDataCalibracao.Text = "Data Calibração";
            // 
            // pbPreVisualizacao
            // 
            pbPreVisualizacao.Location = new Point(550, 48);
            pbPreVisualizacao.Margin = new Padding(3, 4, 3, 4);
            pbPreVisualizacao.Name = "pbPreVisualizacao";
            pbPreVisualizacao.Size = new Size(158, 133);
            pbPreVisualizacao.TabIndex = 12;
            pbPreVisualizacao.TabStop = false;
            // 
            // txtNroCertificacao
            // 
            txtNroCertificacao.Location = new Point(225, 112);
            txtNroCertificacao.Margin = new Padding(3, 4, 3, 4);
            txtNroCertificacao.Name = "txtNroCertificacao";
            txtNroCertificacao.Size = new Size(156, 27);
            txtNroCertificacao.TabIndex = 4;
            // 
            // txtProximaCalibracao
            // 
            txtProximaCalibracao.Location = new Point(117, 112);
            txtProximaCalibracao.Margin = new Padding(3, 4, 3, 4);
            txtProximaCalibracao.MaxLength = 10;
            txtProximaCalibracao.Name = "txtProximaCalibracao";
            txtProximaCalibracao.Size = new Size(101, 27);
            txtProximaCalibracao.TabIndex = 3;
            txtProximaCalibracao.TextAlign = HorizontalAlignment.Center;
            // 
            // lblProximaCalibracao
            // 
            lblProximaCalibracao.AutoSize = true;
            lblProximaCalibracao.Location = new Point(117, 88);
            lblProximaCalibracao.Name = "lblProximaCalibracao";
            lblProximaCalibracao.Size = new Size(116, 20);
            lblProximaCalibracao.TabIndex = 8;
            lblProximaCalibracao.Text = "Prox. Calibração";
            // 
            // txtDiretorioLaudo
            // 
            txtDiretorioLaudo.Location = new Point(7, 48);
            txtDiretorioLaudo.Margin = new Padding(3, 4, 3, 4);
            txtDiretorioLaudo.Name = "txtDiretorioLaudo";
            txtDiretorioLaudo.Size = new Size(443, 27);
            txtDiretorioLaudo.TabIndex = 0;
            // 
            // lblDiretorioLaudo
            // 
            lblDiretorioLaudo.AutoSize = true;
            lblDiretorioLaudo.Location = new Point(7, 24);
            lblDiretorioLaudo.Name = "lblDiretorioLaudo";
            lblDiretorioLaudo.Size = new Size(114, 20);
            lblDiretorioLaudo.TabIndex = 10;
            lblDiretorioLaudo.Text = "Diretório Laudo";
            // 
            // txtNumeroIdentificacao
            // 
            txtNumeroIdentificacao.Location = new Point(389, 112);
            txtNumeroIdentificacao.Margin = new Padding(3, 4, 3, 4);
            txtNumeroIdentificacao.Name = "txtNumeroIdentificacao";
            txtNumeroIdentificacao.Size = new Size(154, 27);
            txtNumeroIdentificacao.TabIndex = 5;
            // 
            // lblNroIdentificacao
            // 
            lblNroIdentificacao.AutoSize = true;
            lblNroIdentificacao.Location = new Point(389, 88);
            lblNroIdentificacao.Name = "lblNroIdentificacao";
            lblNroIdentificacao.Size = new Size(124, 20);
            lblNroIdentificacao.TabIndex = 6;
            lblNroIdentificacao.Text = "Nro Identificação";
            // 
            // lblNumeroCertificacao
            // 
            lblNumeroCertificacao.AutoSize = true;
            lblNumeroCertificacao.Location = new Point(225, 88);
            lblNumeroCertificacao.Name = "lblNumeroCertificacao";
            lblNumeroCertificacao.Size = new Size(117, 20);
            lblNumeroCertificacao.TabIndex = 4;
            lblNumeroCertificacao.Text = "Nro Certificação";
            // 
            // btnVisualizarQRCode
            // 
            btnVisualizarQRCode.Location = new Point(457, 48);
            btnVisualizarQRCode.Margin = new Padding(3, 4, 3, 4);
            btnVisualizarQRCode.Name = "btnVisualizarQRCode";
            btnVisualizarQRCode.Size = new Size(86, 32);
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
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(900, 600);
            Controls.Add(tcClientes);
            Margin = new Padding(3, 4, 3, 4);
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
        internal Button btnConfiguracoes;
    }
}