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
    public partial class FrmTarjetas : Form
    {
        public FrmTarjetas()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmTarjetas_Load(object sender, EventArgs e)
        {
            Recorridos d = new Recorridos();
            d.traigo_datos_tarjetas(dgvtarjetas);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show(" Esta seguro que quiere eliminar la Tarjeta seleccionada ?", "eliminar Usuario", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dgvtarjetas.Rows)
                {

                    if (Convert.ToBoolean(row.Cells[0].Value) == true)

                    {
                        Recorridos d = new Recorridos();
                        d.elimino_tarjeta(Convert.ToString(row.Cells[2].Value));
                        dgvtarjetas.Rows.Clear();
                        d.traigo_datos_tarjetas(dgvtarjetas);

                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }
    }
}
