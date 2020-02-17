using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImpresionQR
{
    public partial class FrmCargaEquipos : Form
    {
        public FrmCargaEquipos()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string laruta = "";
            laruta= new Importar().importarEscudo(txtruta, escudo);
            txtEscudo.Text= laruta;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            int esnacional = 1;

            if (nacional.Checked==true)
            { esnacional = 1; }
            else
            { esnacional = 2; }
          
            new Importar().cargoequipo(txtEquipo.Text,  txtPais.Text, txtEscudo.Text ,esnacional, txtruta.Text);
        }
    }
}
