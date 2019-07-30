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
    public partial class FrmRecorridos : Form
    {
        public FrmRecorridos()
        {
            InitializeComponent();
        }

        private void FrmRecorridos_Load(object sender, EventArgs e)
        {
            Recorridos d = new Recorridos();
            d.traigo_datos_recorridos(dgvrecorridos);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {

           // FrmModificoRecorridos frm = new FrmModificoRecorridos();
           // frm.ShowDialog();
           // this.Show();
           // Recorridos d = new Recorridos();
           // d.traigo_datos_recorridos(dgvrecorridos);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(" Esta seguro que quiere eliminar el Recorrido seleccionado ?", "eliminar Recorrido", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dgvrecorridos.Rows)
                {

                    if (Convert.ToBoolean(row.Cells[0].Value) == true)

                    {
                        Recorridos d = new Recorridos();
                        d.elimino_recorrido(Convert.ToString(row.Cells[2].Value));
                        dgvrecorridos.Rows.Clear();
                        d.traigo_datos_recorridos(dgvrecorridos);

                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string mifecha;
            foreach (DataGridViewRow row in dgvrecorridos.Rows)
            {

                if (Convert.ToBoolean(row.Cells[0].Value) == true)

                {
                    mifecha= Convert.ToDateTime(row.Cells[4].Value).ToString("yyyy-MM-dd");
                    FrmModificoRecorridos frm = new FrmModificoRecorridos(Convert.ToString(row.Cells[2].Value), Convert.ToString(row.Cells[3].Value), mifecha);
                    frm.ShowDialog();
                    this.Show();
                    Recorridos d = new Recorridos();
                    d.traigo_datos_recorridos(dgvrecorridos);


                    
                  

                }
            }
        }
    }
}
