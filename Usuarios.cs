using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace ImpresionQR
{
    class Usuarios
    {
        MySqlCommand cmd;
        MySqlDataReader dr;
        MySqlConnection conectar;
        String nombre;



        public string buscarusuario(string usuario, string password)
        {

            try
            {

                conectar = Conexion.ObtenerConexion();

                cmd = new MySqlCommand("SELECT * FROM usuarios WHERE Usuario='" + usuario + "' and  Password='" + password + "'", conectar);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {

                    nombre = dr.GetString(2);
                    FrmLogin.tipo_usuario = dr.GetInt32(4);
                }
                dr.Close();
                conectar.Close();


            }
            catch (Exception ex)

            {
                MessageBox.Show("No se encontro Tabla Usuarios: " + ex.ToString());
            }

            return nombre;
        }




        public void traigo_datos_usuarios(DataGridView dgvDatos)

        {
            int contirow = 0;
         
            dgvDatos.Rows.Clear();

            conectar = Conexion.ObtenerConexion();
            cmd = new MySqlCommand("SELECT Id_Usuarios, Usuario, Password, Nombre, Tipo_Usuario FROM  usuarios WHERE Estado=1", conectar);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                dgvDatos.Rows.Add();
                dgvDatos.Rows[contirow].Cells[0].Value = ImpresionQR.Properties.Resources.usuario3_30;
                dgvDatos.Rows[contirow].Cells[2].Value = dr.GetString(0);
                dgvDatos.Rows[contirow].Cells[3].Value = dr.GetString(1);
                dgvDatos.Rows[contirow].Cells[4].Value = dr.GetString(3);
                dgvDatos.Rows[contirow].Cells[5].Value = dr.GetString(4);
                






                contirow++;

            }
            dr.Close();
        }

        public void cargo_alta_usuarios(string txtnombre, string txtusuario, string txtpassword, string tipo)
        {

        
            conectar = Conexion.ObtenerConexion();
            cmd = new MySqlCommand("Insert into usuarios(Usuario, Nombre, Password, Tipo_Usuario) values('" + txtusuario + "', '" + txtnombre + "', '" + txtpassword + "', 1)", conectar);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Se ha cargado un nuevo Usuario con exito");

        }

        public void elimino_usuarios(string usuario)
        {


            conectar = Conexion.ObtenerConexion();
            cmd = new MySqlCommand("UPDATE usuarios SET Estado = 9 Where Id_Usuarios=" + usuario , conectar);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Se ha dado de baja el Usuario");

        }


        public void muestro_usuario(string usuario, TextBox  txtnombre, TextBox txtpassword , TextBox txttipo , TextBox txtusuario  )
        {


            conectar = Conexion.ObtenerConexion();
            cmd = new MySqlCommand("SELECT Id_Usuarios, Usuario, Password, Nombre, Tipo_Usuario FROM  usuarios WHERE Estado=1 AND Id_Usuarios=" + usuario, conectar);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {

                txtnombre.Text  = dr.GetString(3);
                txtpassword.Text  = dr.GetString(2);
                txttipo.Text  = dr.GetString(4);
                txtusuario.Text  = dr.GetString(1);


            }

            


            }

        public void modificar_usuario(string usuario, TextBox txtnombre, TextBox txtpassword, TextBox txttipo, TextBox txtusuario)
        {
            conectar = Conexion.ObtenerConexion();
            cmd = new MySqlCommand("UPDATE usuarios SET Usuario ='" + txtusuario.Text  + "', Password='" + txtpassword.Text  + "', Nombre='" + txtnombre.Text  + "', Tipo_Usuario=" + txttipo.Text + " WHERE Id_Usuarios=" + usuario , conectar);
            cmd.ExecuteNonQuery();



            MessageBox.Show("Se han modificado correctamente los datos");
        }


    }
}

