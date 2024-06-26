namespace GerarEtiquetas.Forms.Telas
{
    partial class Configuracoes
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
            tpCadastro = new TabPage();
            pnBotoes = new Panel();
            btnSalvar = new Button();
            btnExcluir = new Button();
            btnLimpar = new Button();
            dgvConfiguracoes = new DataGridView();
            gbDadosNovo = new GroupBox();
            cbCampo = new ComboBox();
            lblCampo = new Label();
            txtValorConfiguracao = new TextBox();
            lblCampoConfiguracao = new Label();
            ArquivoExterno = new OpenFileDialog();
            tcClientes.SuspendLayout();
            tpCadastro.SuspendLayout();
            pnBotoes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvConfiguracoes).BeginInit();
            gbDadosNovo.SuspendLayout();
            SuspendLayout();
            // 
            // tcClientes
            // 
            tcClientes.Controls.Add(tpCadastro);
            tcClientes.Dock = DockStyle.Fill;
            tcClientes.Location = new Point(0, 0);
            tcClientes.Margin = new Padding(3, 4, 3, 4);
            tcClientes.Name = "tcClientes";
            tcClientes.SelectedIndex = 0;
            tcClientes.Size = new Size(756, 600);
            tcClientes.TabIndex = 0;
            // 
            // tpCadastro
            // 
            tpCadastro.BackColor = SystemColors.Control;
            tpCadastro.Controls.Add(pnBotoes);
            tpCadastro.Controls.Add(dgvConfiguracoes);
            tpCadastro.Controls.Add(gbDadosNovo);
            tpCadastro.Location = new Point(4, 29);
            tpCadastro.Margin = new Padding(3, 4, 3, 4);
            tpCadastro.Name = "tpCadastro";
            tpCadastro.Padding = new Padding(3, 4, 3, 4);
            tpCadastro.Size = new Size(748, 567);
            tpCadastro.TabIndex = 0;
            tpCadastro.Text = "Cadastro";
            // 
            // pnBotoes
            // 
            pnBotoes.BackColor = SystemColors.ButtonShadow;
            pnBotoes.Controls.Add(btnSalvar);
            pnBotoes.Controls.Add(btnExcluir);
            pnBotoes.Controls.Add(btnLimpar);
            pnBotoes.Dock = DockStyle.Bottom;
            pnBotoes.Location = new Point(3, 500);
            pnBotoes.Margin = new Padding(3, 4, 3, 4);
            pnBotoes.Name = "pnBotoes";
            pnBotoes.Size = new Size(742, 63);
            pnBotoes.TabIndex = 100;
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(421, 4);
            btnSalvar.Margin = new Padding(3, 4, 3, 4);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(88, 54);
            btnSalvar.TabIndex = 6;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            // 
            // btnExcluir
            // 
            btnExcluir.Location = new Point(327, 4);
            btnExcluir.Margin = new Padding(3, 4, 3, 4);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(88, 55);
            btnExcluir.TabIndex = 7;
            btnExcluir.Text = "Excluir";
            btnExcluir.UseVisualStyleBackColor = true;
            // 
            // btnLimpar
            // 
            btnLimpar.Location = new Point(233, 4);
            btnLimpar.Margin = new Padding(3, 4, 3, 4);
            btnLimpar.Name = "btnLimpar";
            btnLimpar.Size = new Size(88, 54);
            btnLimpar.TabIndex = 1;
            btnLimpar.Text = "Limpar";
            btnLimpar.UseVisualStyleBackColor = true;
            // 
            // dgvConfiguracoes
            // 
            dgvConfiguracoes.BackgroundColor = SystemColors.Control;
            dgvConfiguracoes.BorderStyle = BorderStyle.None;
            dgvConfiguracoes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvConfiguracoes.Location = new Point(9, 118);
            dgvConfiguracoes.Margin = new Padding(3, 4, 3, 4);
            dgvConfiguracoes.Name = "dgvConfiguracoes";
            dgvConfiguracoes.RowHeadersWidth = 51;
            dgvConfiguracoes.Size = new Size(729, 370);
            dgvConfiguracoes.TabIndex = 2;
            // 
            // gbDadosNovo
            // 
            gbDadosNovo.Controls.Add(cbCampo);
            gbDadosNovo.Controls.Add(lblCampo);
            gbDadosNovo.Controls.Add(txtValorConfiguracao);
            gbDadosNovo.Controls.Add(lblCampoConfiguracao);
            gbDadosNovo.Location = new Point(9, 8);
            gbDadosNovo.Margin = new Padding(3, 4, 3, 4);
            gbDadosNovo.Name = "gbDadosNovo";
            gbDadosNovo.Padding = new Padding(3, 4, 3, 4);
            gbDadosNovo.Size = new Size(729, 102);
            gbDadosNovo.TabIndex = 0;
            gbDadosNovo.TabStop = false;
            gbDadosNovo.Text = "Dados da Configuração";
            // 
            // cbCampo
            // 
            cbCampo.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCampo.FormattingEnabled = true;
            cbCampo.Location = new Point(67, 57);
            cbCampo.Name = "cbCampo";
            cbCampo.Size = new Size(268, 28);
            cbCampo.TabIndex = 0;
            // 
            // lblCampo
            // 
            lblCampo.AutoSize = true;
            lblCampo.Location = new Point(67, 34);
            lblCampo.Name = "lblCampo";
            lblCampo.Size = new Size(173, 20);
            lblCampo.TabIndex = 10;
            lblCampo.Text = "Campo em configuração";
            // 
            // txtValorConfiguracao
            // 
            txtValorConfiguracao.Location = new Point(342, 58);
            txtValorConfiguracao.Margin = new Padding(3, 4, 3, 4);
            txtValorConfiguracao.Name = "txtValorConfiguracao";
            txtValorConfiguracao.Size = new Size(320, 27);
            txtValorConfiguracao.TabIndex = 1;
            // 
            // lblCampoConfiguracao
            // 
            lblCampoConfiguracao.AutoSize = true;
            lblCampoConfiguracao.Location = new Point(342, 34);
            lblCampoConfiguracao.Name = "lblCampoConfiguracao";
            lblCampoConfiguracao.Size = new Size(231, 20);
            lblCampoConfiguracao.TabIndex = 6;
            lblCampoConfiguracao.Text = "Valor do campo em configuração";
            // 
            // ArquivoExterno
            // 
            ArquivoExterno.FileName = "openFileDialog1";
            // 
            // Configuracoes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(756, 600);
            Controls.Add(tcClientes);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Configuracoes";
            Text = "Configurações";
            tcClientes.ResumeLayout(false);
            tpCadastro.ResumeLayout(false);
            pnBotoes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvConfiguracoes).EndInit();
            gbDadosNovo.ResumeLayout(false);
            gbDadosNovo.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        internal System.Windows.Forms.TabPage tpCadastro;
        internal System.Windows.Forms.TextBox txtValorConfiguracao;
        private System.Windows.Forms.Label lblCampoConfiguracao;
        private System.Windows.Forms.Label lblCampo;
        private GroupBox gbDadosNovo;
        internal DataGridView dgvConfiguracoes;
        internal TabControl tcClientes;
        internal Button btnExcluir;
        internal Button btnSalvar;
        internal OpenFileDialog ArquivoExterno;
        private Panel pnBotoes;
        internal Button btnLimpar;
        internal ComboBox cbCampo;
    }
}