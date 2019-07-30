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
    public partial class FrmAltaUsuarios : Form
    {
        public FrmAltaUsuarios()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtnombre.Text == "")
            {
                MessageBox.Show("Debe Completar el Nombre y Apelldido del nuevo Usuario", "Analytics",
                                         MessageBoxButtons.OK, MessageBoxIcon.Warning);


            }
            else if (txtusuario.Text == "")
            {
                MessageBox.Show("Debe Completar el campo Usuario", "Analytics",
                                         MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (txtpassword.Text == "")
            {
                MessageBox.Show("Debe cargar un Password para el nuevo usuario", "Analytics",
                                         MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }


            else
            {


                Usuarios d = new Usuarios();
                d.cargo_alta_usuarios(txtnombre.Text, txtusuario.Text, txtpassword.Text, txttipo.Text  );

            }
        }

        private void FrmAltaUsuarios_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
   

