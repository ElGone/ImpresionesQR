using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImpresionQR
{
    public partial class FrmActualizoDNI : Form
    {
        public FrmActualizoDNI()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            if (txtPestaña.Text == "")
            {
                MessageBox.Show("Nombre de Pestaña en Blanco");
            }
            else
            {


                new Importar().importarExcelDNI(dgvDatos, txtPestaña.Text, button2);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtLista.Text.Trim() == "")
            {
                MessageBox.Show("Nombre de Lista en Blanco");
            }
            else
            {


                new Importar().Importar_DNI(dgvDatos, txtLista, txtProveedor);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(" Esta seguro que quiere borrar todos los registros de la base ?", "Borrar registros", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                new Importar().borrarbase();
            }
        }
    }
}
