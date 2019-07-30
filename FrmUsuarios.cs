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
    public partial class FrmUsuarios : Form
    {
        public FrmUsuarios()
        {
            InitializeComponent();
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            Usuarios d = new Usuarios();
            d.traigo_datos_usuarios(dgvusuarios);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvusuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmAltaUsuarios frm = new FrmAltaUsuarios();

            frm.ShowDialog();
            this.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show(" Esta seguro que quiere eliminar el Usuario seleccionado ?", "eliminar Usuario", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dgvusuarios.Rows)
                {

                    if (Convert.ToBoolean(row.Cells[1].Value) == true)

                    {
                        Usuarios d = new Usuarios();
                        d.elimino_usuarios(Convert.ToString(row.Cells[2].Value));
                        dgvusuarios.Rows.Clear();
                        d.traigo_datos_usuarios(dgvusuarios);

                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow row in dgvusuarios.Rows)
            {

                if (Convert.ToBoolean(row.Cells[1].Value) == true)

                {

                    FrmModificarUsuarios frm = new FrmModificarUsuarios(Convert.ToString(row.Cells[2].Value));
                    frm.ShowDialog();
                    this.Show();
                    Usuarios d = new Usuarios();
                    dgvusuarios.Rows.Clear();
                    d.traigo_datos_usuarios(dgvusuarios);
                }
            }
            
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
