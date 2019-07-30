using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ImpresionQR
{
    public partial class FrmLogin : Form
    {

        
        MySqlConnection conectar;
        public static string usu, nomfuente, nomfuentecampeonato, nomfuenterival, nomfuentemedio, nomfuentefecha, nomfuenteubicacion, nomfuentenombre;

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                string miusuario;
                Usuarios d = new Usuarios();
                miusuario = d.buscarusuario(txtUsuario.Text, txtPassword.Text);
                usu = txtUsuario.Text;


                if (string.IsNullOrEmpty(miusuario))
                {
                    MessageBox.Show("Usuario no Registrado, Verifique ");

                }

                else
                {

                    conectar = Conexion.ObtenerConexion();

                    DateTime mihora = DateTime.Now;
                    string lahora = mihora.ToString("yyyy-MM-dd hh:mm:ss");

                                                        

                    new Evento().Traigo_Desde_Hasta_Credenciales();

                    FrmPrincipal frm = new FrmPrincipal(miusuario.ToString(), txtUsuario.Text);
                    this.Hide();
                    frm.ShowDialog();
                    this.Close();
                }
            }
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                txtPassword.Focus();

            }
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {


        }

        public static int id_ingreso, tipo_usuario, CantRegImp = 0, sizefuente, credencial_desde, credencial_hasta, credencial_anual_desde, credencial_anual_hasta, sizecampeonato, sizerival, sizemedio, sizefecha, sizeubicacion, sizenombre, negritacampeonato, negritafecha, negritamedio, negritarival, negritaubicacion, negritanombre ;
        public static double totimpresiones=0,total_cabinas_impresas = 0, total_pupitres_impresos = 0, total_cabinas_faltantes=0, total_cabinas_entrantes=0, total_pupitres_faltantes=0, total_pupitres_entrantes=0;

        private void bindingNavigator1_RefreshItems(object sender, EventArgs e)
        {

        }

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string miusuario;
            Usuarios d = new Usuarios();
            miusuario = d.buscarusuario(txtUsuario.Text, txtPassword.Text);
            usu = txtUsuario.Text;


            if (string.IsNullOrEmpty(miusuario))
            {
                MessageBox.Show("Usuario no Registrado, Verifique ");

            }

            else
            {

                conectar = Conexion.ObtenerConexion();

                DateTime mihora = DateTime.Now;
                string lahora = mihora.ToString("yyyy-MM-dd hh:mm:ss");



                //cmd = new MySqlCommand("Insert into ingreso_sistema(Usuario, Fecha_Ingreso, Estado) values('" + txtUsuario.Text + "', '" + lahora + "', 1)", conectar);
                //cmd.ExecuteNonQuery();

                //cmd = new MySqlCommand("SELECT Max(Id_ingreso_usuario) FROM ingreso_sistema", conectar);
                //dr = cmd.ExecuteReader();
                //while (dr.Read())
                // {
                //    id_ingreso = dr.GetInt32(0);
                //}


                //conectar = Conexion.ObtenerConexion();
                //cmd = new MySqlCommand("SELECT Tipo, Categoria  FROM usuarios  WHERE usuario='" + Form1.usu + "'", conectar);
                //dr = cmd.ExecuteReader();
                //while (dr.Read())
                //{

                //                    tipo_usuario = dr.GetInt32(0);
                //                   categoria_usuario = dr.GetInt32(1);

                // }


                new Evento().Traigo_Desde_Hasta_Credenciales();

                FrmPrincipal frm = new FrmPrincipal(miusuario.ToString(), txtUsuario.Text);
                this.Hide();
                frm.ShowDialog();
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
