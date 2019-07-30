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
    public partial class FrmModificarUsuarios : Form
    {
        public FrmModificarUsuarios(string usuario)
        {
            InitializeComponent();
            string miusuario = usuario;
            Id_usuario.Text = usuario;
            Usuarios d = new Usuarios();
            d.muestro_usuario(miusuario, txtnombre, txtpassword , txttipo , txtusuario  );

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
             
        }

        private void FrmModificarUsuarios_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Usuarios d = new Usuarios();
            d.modificar_usuario(Id_usuario.Text, txtnombre, txtpassword, txttipo, txtusuario);
        }
    }
}
