using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GerarEtiquetas.Telas
{
    public partial class Prompt : Form
    {
        public Controller.Prompt controller;

        public Prompt(Nucleo.Base.Enumeradores.Prompt.Dado e)
        {
            InitializeComponent();

            controller = new Controller.Prompt(this, e);
        }
    }
}
