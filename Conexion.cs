using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;


namespace ImpresionQR
{

    public class Conexion
    {

        // MySqlConnection conectar;

        public static MySqlConnection ObtenerConexion()
        {
            
            //Conexion para estar en Red
            MySqlConnection conectar = new MySqlConnection("Server=192.168.192.62; Port=6603; Database=prensa; Uid=desarrollo; Pwd=d3s4rr0ll0; CharacterSet = utf8;");
                    

            //Conexion para estar en modo local
            //MySqlConnection conectar = new MySqlConnection("Server=localhost; Database=prensa; Uid =root; Password=''; CharacterSet=utf8;");
             
            conectar.Open();

            return conectar;
        }

        public static MySqlConnection ObtenerConexion_Analytics()
        {




             MySqlConnection conectar = new MySqlConnection("Server=192.168.192.62; Port=6603;  Database=importacionaz; Uid=desarrollo; Pwd=d3s4rr0ll0; CharacterSet=utf8;");
     

            //Conexion para estar en modo local
            //MySqlConnection conectar = new MySqlConnection("Server=localhost; Database=importacionaz; Uid =root; Password='';");

            conectar.Open();

            return conectar;
        }







    }

}












