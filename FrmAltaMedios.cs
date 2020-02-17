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
    public partial class FrmAltaMedios : Form
    {
        int flag = 2;
        public FrmAltaMedios()
        {
            InitializeComponent();  
            string criterio = "";
             
            Evento r = new Evento();
            criterio = "SELECT * FROM letras";
            r.cargo_combo_letras(cbletras, criterio);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtnombre.Text == "")
            {
                MessageBox.Show("Debe Completar el Nombre del Medio", "QR",
                                         MessageBoxButtons.OK, MessageBoxIcon.Warning);


            }
            else if (txtletras.Text == "")
            {
                MessageBox.Show("Debe Completar con las Letras correspondientes a ese medio", "QR",
                                         MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            else
            {


                Evento d = new Evento();
                d.alta_medios(txtnombre.Text, txtletras.Text);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void FrmAltaMedios_Load(object sender, EventArgs e)
        {
            string criterio;
            criterio = "SELECT Id_Medios, Nombre_Medio, Letras FROM  medios";
            Evento d = new Evento();
            d.traigo_datos_medios(dgvMedios, criterio);
            flag = 1;
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Evento d = new Evento();
            d.actualizo_medios(dgvMedios);
        }

        private void txtnombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvMedios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void cbletras_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (flag == 1)
            {
                this.dgvMedios.CurrentRow.Cells[2].Value = this.dgvMedios.CurrentRow.Cells[2].Value + cbletras.Text + "-";
            }
            
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
