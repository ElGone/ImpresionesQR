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
    public partial class FrmActualizoLecturas : Form
    {
        public FrmActualizoLecturas()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Importar().ImportarExcelNuevo(dgvDatos, "Lecturas", button2);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            String evento, mifecha;

            foreach (DataGridViewRow row in dgvDatos.Rows)
            {
                evento = Convert.ToString(dgvDatos.Rows[0].Cells[0].Value);
                mifecha = Convert.ToString(dgvDatos.Rows[0].Cells[2].Value);
                new Importar().Importar_Lecturas(dgvDatos, mifecha, evento);
                break;

            }
        }
    }
}
