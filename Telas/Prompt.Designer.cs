namespace GerarEtiquetas.Telas
{
    partial class Prompt
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
            txtDadoSolicitado = new TextBox();
            lblTextoSolicitado = new Label();
            btnAcao1 = new Button();
            pBotoes = new Panel();
            btnLimpar = new Button();
            btnSalvar = new Button();
            pBotoes.SuspendLayout();
            SuspendLayout();
            // 
            // txtDadoSolicitado
            // 
            txtDadoSolicitado.Location = new Point(91, 50);
            txtDadoSolicitado.Name = "txtDadoSolicitado";
            txtDadoSolicitado.Size = new Size(459, 23);
            txtDadoSolicitado.TabIndex = 0;
            txtDadoSolicitado.TextAlign = HorizontalAlignment.Center;
            // 
            // lblTextoSolicitado
            // 
            lblTextoSolicitado.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTextoSolicitado.ForeColor = Color.Blue;
            lblTextoSolicitado.Location = new Point(91, 23);
            lblTextoSolicitado.Name = "lblTextoSolicitado";
            lblTextoSolicitado.Size = new Size(459, 23);
            lblTextoSolicitado.TabIndex = 1;
            lblTextoSolicitado.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnAcao1
            // 
            btnAcao1.Location = new Point(260, 84);
            btnAcao1.Name = "btnAcao1";
            btnAcao1.Size = new Size(120, 23);
            btnAcao1.TabIndex = 2;
            btnAcao1.UseVisualStyleBackColor = true;
            btnAcao1.Visible = false;
            // 
            // pBotoes
            // 
            pBotoes.BackColor = SystemColors.ActiveCaption;
            pBotoes.Controls.Add(btnSalvar);
            pBotoes.Controls.Add(btnLimpar);
            pBotoes.Dock = DockStyle.Bottom;
            pBotoes.Location = new Point(0, 125);
            pBotoes.Name = "pBotoes";
            pBotoes.Size = new Size(640, 45);
            pBotoes.TabIndex = 3;
            // 
            // btnLimpar
            // 
            btnLimpar.Location = new Point(197, 10);
            btnLimpar.Name = "btnLimpar";
            btnLimpar.Size = new Size(120, 23);
            btnLimpar.TabIndex = 3;
            btnLimpar.Text = "Limpar";
            btnLimpar.UseVisualStyleBackColor = true;
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(323, 10);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(120, 23);
            btnSalvar.TabIndex = 4;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            // 
            // Prompt
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(640, 170);
            Controls.Add(pBotoes);
            Controls.Add(btnAcao1);
            Controls.Add(lblTextoSolicitado);
            Controls.Add(txtDadoSolicitado);
            Name = "Prompt";
            Text = "Prompt";
            pBotoes.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        internal TextBox txtDadoSolicitado;
        internal Label lblTextoSolicitado;
        internal Button btnAcao1;
        private Panel pBotoes;
        internal Button btnSalvar;
        internal Button btnLimpar;
    }
}