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
    public partial class FrmActualizoMedios : Form
    {
        public FrmActualizoMedios()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Importar().ImportarExcelNuevo(dgvDatos, "Medios", button2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Importar().Importar_Medios(dgvDatos);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void FrmActualizoMedios_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
