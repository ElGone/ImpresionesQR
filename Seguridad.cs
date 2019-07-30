using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace ImpresionQR
{
    class Seguridad
    {
        SqlCommand cmd, cmd1;
        SqlDataReader dr, dr1;
        SqlConnection conectar, conectar1;

        public void cargo_alta_seguridad()
        {


            SqlConnection cn = new SqlConnection("Data Source=192.168.2.16 ; Initial Catalog=Desarrollo;  User Id=Desarrollo;  Password=r1v3rpl4t3");
            cn.Open();
            cmd = new SqlCommand("Insert into importarbaseseguridad(nombre, documento, empresa) values('Martin Salgan' , '17896561' ,'River Plate')", cn);
            cmd.ExecuteNonQuery();
            cn.Close();
             
            MessageBox.Show("Se ha cargado un nuevo Usuario con exito");

        }








    }




}
