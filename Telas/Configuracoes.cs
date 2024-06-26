using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GerarEtiquetas.Forms.Telas
{
    public partial class Configuracoes : Form
    {
        public Controller.Configuracoes controller;

        public Configuracoes()
        {
            InitializeComponent();

            controller = new Controller.Configuracoes(this);
        }

    }
}
