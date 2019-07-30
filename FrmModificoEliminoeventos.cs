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
    public partial class FrmModificoEliminoeventos : Form
    {
        public FrmModificoEliminoeventos(string idevento, string fecha, string nombreequipo, string rival)
        {
            InitializeComponent();
            string Idevento = idevento;
            string Fecha = fecha;
            string equipo = nombreequipo;
            string IdRival = rival;
            txtrival.Text = equipo;
            pdesde.Text = Fecha;
            txtIdRival.Text  = rival;
            IdEvento.Text = idevento;

            
            
            new Importar().traigo_escudo_rival(IdRival, pictureBox3, pictureBox2, nombreequipo1, cuadro);

        }

        private void FrmModificoEliminoeventos_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string criterio = "";
            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
            criterio = "Select Id_Equipo, Nombre_Equipo, Escudo From equipos Order By Nombre_Equipo";
            new Importar().muestro_rivales(dgvrivales, criterio);
           
            System.Windows.Forms.Cursor.Current = Cursors.Default;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(" Esta seguro que quiere Modificar el Evento ?", "Modificar Evento", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                new Evento().Modifico_Evento(pdesde.Text,txtrival.Text,txtIdRival.Text,IdEvento.Text);
                                            
            }
        }

        private void dgvrivales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtIdRival.Text  = Convert.ToString(this.dgvrivales.CurrentRow.Cells[2].Value);
            txtrival.Text = Convert.ToString(this.dgvrivales.CurrentRow.Cells[1].Value);
            new Importar().traigo_escudo_rival(txtIdRival.Text , pictureBox3, pictureBox2, nombreequipo1, cuadro);
            button1.Enabled = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(" Esta seguro que quiere eliminar el Evento ?", "Eliminar Evento", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                new Evento().Elimino_Evento(IdEvento.Text);

            }
        }
    }
}
