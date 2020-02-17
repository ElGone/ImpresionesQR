using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace ImpresionQR
{


    class Importar
    {
        OleDbConnection conn;
        OleDbDataAdapter MyDataAdapter;
        DataTable dt;

        MySqlCommand cmd, cmd1;
        MySqlDataReader dr, dr1;
        MySqlConnection conectar, conectar1;



        public void ImportarExcelNuevo(DataGridView dgv, String nombreHoja, Button importar)
        {
            string ruta = "";
            try
            {

                OpenFileDialog openfile1 = new OpenFileDialog();
                openfile1.Filter = "Excel Files | *.xlsx";
                openfile1.Title = "Seleccione el archivo a Importar";
                if (openfile1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                    if (openfile1.FileName.Equals("") == false)
                    {
                        ruta = openfile1.FileName;
                    }

                }

                conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;data source=" + ruta + ";Extended Properties='Excel 8.0;HDR=Yes'");
                MyDataAdapter = new OleDbDataAdapter("Select * From [" + nombreHoja + "$]", conn);
                dt = new DataTable();
                MyDataAdapter.Fill(dt);
                dgv.DataSource = dt;
                importar.Enabled = true;


            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }

        }
               
     


        public void Importar_Cabinas(DataGridView dgvDatos, DataGridView dgvCabinas, string torneo, string evento, Button imprimir, Button imprimir_nuevos, Button imprimir_fiesta)
        {



            string cabina, medio;
            int credencial = 0;


            DateTime mihora = DateTime.Now;
            string lahora = mihora.ToString("yyyy-MM-dd");
            int result;
            FrmPrincipal.contirow = 0;

            conectar = Conexion.ObtenerConexion();
            cmd = new MySqlCommand("SELECT Credencial_Cabinas  FROM setup", conectar);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                credencial = dr.GetInt32(0);
            }
            dr.Close();
            conectar.Close();




            foreach (DataGridViewRow row in dgvDatos.Rows)
            {
                if (int.TryParse(Convert.ToString(row.Cells[0].Value), out result))
                {

                    cabina = Convert.ToString(row.Cells[0].Value);
                    medio = Convert.ToString(row.Cells[1].Value);



                    dgvCabinas.Rows.Add();
                    dgvCabinas.Rows[FrmPrincipal.contirow].Cells[0].Value = true;
                    dgvCabinas.Rows[FrmPrincipal.contirow].Cells[1].Value = torneo;
                    dgvCabinas.Rows[FrmPrincipal.contirow].Cells[2].Value = evento;
                    dgvCabinas.Rows[FrmPrincipal.contirow].Cells[3].Value = medio;
                    dgvCabinas.Rows[FrmPrincipal.contirow].Cells[4].Value = cabina;
                    dgvCabinas.Rows[FrmPrincipal.contirow].Cells[5].Value = 1;
                    dgvCabinas.Rows[FrmPrincipal.contirow].Cells[8].Value = credencial;

                    conectar = Conexion.ObtenerConexion();
                    cmd = new MySqlCommand("SELECT Id_Medios, Nombre_Medio, Letras  FROM medios WHERE Nombre_Medio ='" + medio + "' COLLATE utf8_spanish_ci", conectar);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        dgvCabinas.Rows[FrmPrincipal.contirow].Cells[10].Value = dr.GetString(2);
                    }
                    dr.Close();
                    conectar.Close();


                    FrmPrincipal.contirow++;
                    credencial++;



                }





            }

            imprimir.Enabled = true;
            imprimir_nuevos.Enabled = true;
            imprimir_fiesta.Enabled = true;
            MessageBox.Show("Se cargaron los datos correctamente");

        }


        public void Importar_Pupitres_Fila1(DataGridView dgvDatos, DataGridView dgvPupitre, string torneo, string evento, Button imprimir, Button imprimir_nuevos, Button imprimir_fiesta)
        {


            string medio, fila, asiento;
            int credencial = 0, sigo = 1;


            DateTime mihora = DateTime.Now;
            string lahora = mihora.ToString("yyyy-MM-dd");

            int result = 0;
            fila = "1";
            FrmPrincipal.contirow = 0;

            conectar = Conexion.ObtenerConexion();
            cmd = new MySqlCommand("SELECT Credencial_Pupitres  FROM setup", conectar);
            dr = cmd.ExecuteReader();


            while (dr.Read())
            {
                credencial = dr.GetInt32(0);
            }
            dr.Close();
            conectar.Close();


            foreach (DataGridViewRow row in dgvDatos.Rows)
            {
                if (int.TryParse(Convert.ToString(row.Cells[0].Value), out result))
                {
                    asiento = Convert.ToString(row.Cells[0].Value);
                    medio = Convert.ToString(row.Cells[1].Value);

                    if (asiento != "")
                    {
                        conectar = Conexion.ObtenerConexion();
                        cmd1 = new MySqlCommand("SELECT Fila, Asiento  FROM anuales Where  Fila=1 AND Asiento=" + asiento, conectar);
                        dr1 = cmd1.ExecuteReader();
                        while (dr1.Read())
                        {
                            sigo = 2;
                        }
                        dr1.Close();
                        conectar.Close();



                        //      if (sigo == 1)
                        //     {

                        dgvPupitre.Rows.Add();
                        dgvPupitre.Rows[FrmPrincipal.contirow].Cells[0].Value = true;
                        dgvPupitre.Rows[FrmPrincipal.contirow].Cells[1].Value = torneo;
                        dgvPupitre.Rows[FrmPrincipal.contirow].Cells[2].Value = evento;
                        dgvPupitre.Rows[FrmPrincipal.contirow].Cells[3].Value = medio;
                        dgvPupitre.Rows[FrmPrincipal.contirow].Cells[4].Value = fila;
                        dgvPupitre.Rows[FrmPrincipal.contirow].Cells[5].Value = asiento;
                        dgvPupitre.Rows[FrmPrincipal.contirow].Cells[6].Value = 1;
                        dgvPupitre.Rows[FrmPrincipal.contirow].Cells[9].Value = credencial;

                        conectar = Conexion.ObtenerConexion();
                        cmd = new MySqlCommand("SELECT Id_Medios, Nombre_Medio, Letras  FROM medios WHERE Nombre_Medio ='" + medio + "' COLLATE utf8_spanish_ci", conectar);
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            dgvPupitre.Rows[FrmPrincipal.contirow].Cells[11].Value = dr.GetString(2);
                        }
                        dr.Close();
                        conectar.Close();




                        FrmPrincipal.contirow++;
                        credencial++;
                        //   }
                        //    else
                        //  {
                        //      sigo = 1;
                        //  }

                    }
                }








            }



        }



        public void Importar_Pupitres_Fila2(DataGridView dgvDatos, DataGridView dgvCabinas, string torneo, string evento, Button imprimir, Button imprimir_nuevos, Button imprimir_fiesta)
        {


            string medio, fila, asiento;
            int credencial = 0, sigo = 1;

            DateTime mihora = DateTime.Now;
            string lahora = mihora.ToString("yyyy-MM-dd");

            int result;
            fila = "2";



            conectar = Conexion.ObtenerConexion();
            cmd = new MySqlCommand("SELECT Credencial_Pupitres  FROM setup", conectar);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                credencial = dr.GetInt32(0);
            }
            dr.Close();
            conectar.Close();



            foreach (DataGridViewRow row in dgvDatos.Rows)
            {
                if (int.TryParse(Convert.ToString(row.Cells[0].Value), out result))
                {
                    asiento = Convert.ToString(row.Cells[4].Value);
                    medio = Convert.ToString(row.Cells[5].Value);

                    if (asiento != "")
                    {

                        conectar = Conexion.ObtenerConexion();
                        cmd1 = new MySqlCommand("SELECT Fila, Asiento  FROM anuales Where  Fila=2 AND Asiento=" + asiento, conectar);
                        dr1 = cmd1.ExecuteReader();
                        while (dr1.Read())
                        {
                            sigo = 2;
                        }
                        dr1.Close();
                        conectar.Close();


                        //      if (sigo == 1)
                        //      {

                        dgvCabinas.Rows.Add();
                        dgvCabinas.Rows[FrmPrincipal.contirow].Cells[0].Value = true;
                        dgvCabinas.Rows[FrmPrincipal.contirow].Cells[1].Value = torneo;
                        dgvCabinas.Rows[FrmPrincipal.contirow].Cells[2].Value = evento;
                        dgvCabinas.Rows[FrmPrincipal.contirow].Cells[3].Value = medio;
                        dgvCabinas.Rows[FrmPrincipal.contirow].Cells[4].Value = fila;
                        dgvCabinas.Rows[FrmPrincipal.contirow].Cells[5].Value = asiento;
                        dgvCabinas.Rows[FrmPrincipal.contirow].Cells[6].Value = 1;
                        dgvCabinas.Rows[FrmPrincipal.contirow].Cells[9].Value = credencial;

                        conectar = Conexion.ObtenerConexion();
                        cmd = new MySqlCommand("SELECT Id_Medios, Nombre_Medio, Letras  FROM medios WHERE Nombre_Medio ='" + medio + "' COLLATE utf8_spanish_ci", conectar);
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            dgvCabinas.Rows[FrmPrincipal.contirow].Cells[11].Value = dr.GetString(2);
                        }
                        dr.Close();
                        conectar.Close();

                        FrmPrincipal.contirow++;
                        credencial++;
                        //    }
                        //    else
                        //    {
                        //        sigo = 1;
                        //     }
                    }
                }






            }



            imprimir.Enabled = true;
            imprimir_nuevos.Enabled = true;
            imprimir_fiesta.Enabled = true;
            MessageBox.Show("Se cargaron los datos correctamente");

        }



        public void Importar_Pupitres_Fila3(DataGridView dgvDatos, DataGridView dgvCabinas, string torneo, string evento, Button imprimir, Button imprimir_nuevos, Button imprimir_fiesta)
        {


            string medio, fila, asiento;
            int credencial = 0, sigo = 1;



            DateTime mihora = DateTime.Now;
            string lahora = mihora.ToString("yyyy-MM-dd");

            int result;
            fila = "3";
            FrmPrincipal.contirow = 0;



            conectar = Conexion.ObtenerConexion();
            cmd = new MySqlCommand("SELECT Credencial_Pupitres  FROM setup", conectar);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                credencial = dr.GetInt32(0);
            }
            dr.Close();
            conectar.Close();




            foreach (DataGridViewRow row in dgvDatos.Rows)
            {
                if (int.TryParse(Convert.ToString(row.Cells[0].Value), out result))
                {
                    asiento = Convert.ToString(row.Cells[0].Value);
                    medio = Convert.ToString(row.Cells[1].Value);

                    if (asiento != "")
                    {
                        conectar = Conexion.ObtenerConexion();
                        cmd1 = new MySqlCommand("SELECT Fila, Asiento  FROM anuales Where  Fila=3 AND Asiento=" + asiento, conectar);
                        dr1 = cmd1.ExecuteReader();
                        while (dr1.Read())
                        {
                            sigo = 2;
                        }
                        dr1.Close();
                        conectar.Close();


                        //   if (sigo == 1)
                        //    {


                        dgvCabinas.Rows.Add();
                        dgvCabinas.Rows[FrmPrincipal.contirow].Cells[0].Value = true;
                        dgvCabinas.Rows[FrmPrincipal.contirow].Cells[1].Value = torneo;
                        dgvCabinas.Rows[FrmPrincipal.contirow].Cells[2].Value = evento;
                        dgvCabinas.Rows[FrmPrincipal.contirow].Cells[3].Value = medio;
                        dgvCabinas.Rows[FrmPrincipal.contirow].Cells[4].Value = fila;
                        dgvCabinas.Rows[FrmPrincipal.contirow].Cells[5].Value = asiento;
                        dgvCabinas.Rows[FrmPrincipal.contirow].Cells[6].Value = 1;
                        dgvCabinas.Rows[FrmPrincipal.contirow].Cells[9].Value = credencial;

                        conectar = Conexion.ObtenerConexion();
                        cmd = new MySqlCommand("SELECT Id_Medios, Nombre_Medio, Letras  FROM medios WHERE Nombre_Medio ='" + medio + "' COLLATE utf8_spanish_ci", conectar);
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            dgvCabinas.Rows[FrmPrincipal.contirow].Cells[11].Value = dr.GetString(2);
                        }
                        dr.Close();
                        conectar.Close();

                        FrmPrincipal.contirow++;
                        credencial++;

                        //  }
                        //   else
                        //    {
                        //      sigo = 1;
                        //   }
                    }

                }








            }



            conectar.Close();

        }


        public void Importar_Pupitres_Fila4(DataGridView dgvDatos, DataGridView dgvCabinas, string torneo, string evento, Button imprimir, Button imprimir_nuevos, Button imprimir_fiesta)
        {


            string medio, fila, asiento;
            int credencial = 0, sigo = 1;

            DateTime mihora = DateTime.Now;
            string lahora = mihora.ToString("yyyy-MM-dd");

            int result;
            fila = "4";



            conectar = Conexion.ObtenerConexion();
            cmd = new MySqlCommand("SELECT Credencial_Pupitres  FROM setup", conectar);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                credencial = dr.GetInt32(0);
            }
            dr.Close();
            conectar.Close();



            foreach (DataGridViewRow row in dgvDatos.Rows)
            {
                if (int.TryParse(Convert.ToString(row.Cells[4].Value), out result))
                {
                    asiento = Convert.ToString(row.Cells[4].Value);
                    medio = Convert.ToString(row.Cells[5].Value);

                    if (asiento != "")
                    {
                        conectar = Conexion.ObtenerConexion();
                        cmd1 = new MySqlCommand("SELECT Fila, Asiento  FROM anuales Where  Fila=4 AND Asiento=" + asiento, conectar);
                        dr1 = cmd1.ExecuteReader();
                        while (dr1.Read())
                        {
                            sigo = 2;
                        }
                        dr1.Close();
                        conectar.Close();


                        //     if (sigo == 1)
                        //   {

                        dgvCabinas.Rows.Add();
                        dgvCabinas.Rows[FrmPrincipal.contirow].Cells[0].Value = true;
                        dgvCabinas.Rows[FrmPrincipal.contirow].Cells[1].Value = torneo;
                        dgvCabinas.Rows[FrmPrincipal.contirow].Cells[2].Value = evento;
                        dgvCabinas.Rows[FrmPrincipal.contirow].Cells[3].Value = medio;
                        dgvCabinas.Rows[FrmPrincipal.contirow].Cells[4].Value = fila;
                        dgvCabinas.Rows[FrmPrincipal.contirow].Cells[5].Value = asiento;
                        dgvCabinas.Rows[FrmPrincipal.contirow].Cells[6].Value = 1;
                        dgvCabinas.Rows[FrmPrincipal.contirow].Cells[9].Value = credencial;

                        conectar = Conexion.ObtenerConexion();
                        cmd = new MySqlCommand("SELECT Id_Medios, Nombre_Medio, Letras  FROM medios WHERE Nombre_Medio ='" + medio + "' COLLATE utf8_spanish_ci", conectar);
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            dgvCabinas.Rows[FrmPrincipal.contirow].Cells[11].Value = dr.GetString(2);
                        }
                        dr.Close();
                        conectar.Close();

                        FrmPrincipal.contirow++;
                        credencial++;

                        // }
                        //  else
                        //   {
                        //       sigo = 1;
                        //  }
                    }
                }








            }



            imprimir.Enabled = true;
            imprimir_nuevos.Enabled = true;
            imprimir_fiesta.Enabled = true;
            MessageBox.Show("Se cargaron los datos correctamente");

        }

        public void Importar_Pupitres_Fila5(DataGridView dgvDatos, DataGridView dgvCabinas, string torneo, string evento, Button imprimir, Button imprimir_nuevos, Button imprimir_fiesta)
        {


            string medio, fila, asiento;
            int credencial = 0, sigo = 1;



            DateTime mihora = DateTime.Now;
            string lahora = mihora.ToString("yyyy-MM-dd");

            int result;
            fila = "5";
            FrmPrincipal.contirow = 0;



            conectar = Conexion.ObtenerConexion();
            cmd = new MySqlCommand("SELECT Credencial_Pupitres  FROM setup", conectar);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                credencial = dr.GetInt32(0);
            }
            dr.Close();
            conectar.Close();



            foreach (DataGridViewRow row in dgvDatos.Rows)
            {
                if (int.TryParse(Convert.ToString(row.Cells[0].Value), out result))
                {
                    asiento = Convert.ToString(row.Cells[0].Value);
                    medio = Convert.ToString(row.Cells[1].Value);


                    if (asiento != "")
                    {

                        conectar = Conexion.ObtenerConexion();
                        cmd1 = new MySqlCommand("SELECT Fila, Asiento  FROM anuales Where  Fila=5 AND Asiento=" + asiento, conectar);
                        dr1 = cmd1.ExecuteReader();
                        while (dr1.Read())
                        {
                            sigo = 2;
                        }
                        dr1.Close();
                        conectar.Close();


                        //   if (sigo == 1)
                        //   {

                        dgvCabinas.Rows.Add();
                        dgvCabinas.Rows[FrmPrincipal.contirow].Cells[0].Value = true;
                        dgvCabinas.Rows[FrmPrincipal.contirow].Cells[1].Value = torneo;
                        dgvCabinas.Rows[FrmPrincipal.contirow].Cells[2].Value = evento;
                        dgvCabinas.Rows[FrmPrincipal.contirow].Cells[3].Value = medio;
                        dgvCabinas.Rows[FrmPrincipal.contirow].Cells[4].Value = fila;
                        dgvCabinas.Rows[FrmPrincipal.contirow].Cells[5].Value = asiento;
                        dgvCabinas.Rows[FrmPrincipal.contirow].Cells[6].Value = 1;
                        dgvCabinas.Rows[FrmPrincipal.contirow].Cells[9].Value = credencial;

                        conectar = Conexion.ObtenerConexion();
                        cmd = new MySqlCommand("SELECT Id_Medios, Nombre_Medio, Letras  FROM medios WHERE Nombre_Medio ='" + medio + "' COLLATE utf8_spanish_ci", conectar);
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            dgvCabinas.Rows[FrmPrincipal.contirow].Cells[11].Value = dr.GetString(2);
                        }
                        dr.Close();
                        conectar.Close();

                        FrmPrincipal.contirow++;
                        credencial++;


                    }
                }








            }



            conectar.Close();

        }


        public void Importar_Pupitres_Fila6(DataGridView dgvDatos, DataGridView dgvCabinas, string torneo, string evento, Button imprimir, Button imprimir_nuevos, Button imprimir_fiesta)
        {


            string medio, fila, asiento;
            int credencial = 0, sigo = 1;

            DateTime mihora = DateTime.Now;
            string lahora = mihora.ToString("yyyy-MM-dd");
            int result;
            fila = "6";



            conectar = Conexion.ObtenerConexion();
            cmd = new MySqlCommand("SELECT Credencial_Pupitres  FROM setup", conectar);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                credencial = dr.GetInt32(0);
            }
            dr.Close();
            conectar.Close();



            foreach (DataGridViewRow row in dgvDatos.Rows)
            {
                if (int.TryParse(Convert.ToString(row.Cells[4].Value), out result))
                {
                    asiento = Convert.ToString(row.Cells[4].Value);
                    medio = Convert.ToString(row.Cells[5].Value);

                    if (asiento != "")
                    {

                        conectar = Conexion.ObtenerConexion();
                        cmd1 = new MySqlCommand("SELECT Fila, Asiento  FROM anuales Where  Fila=6 AND Asiento=" + asiento, conectar);
                        dr1 = cmd1.ExecuteReader();
                        while (dr1.Read())
                        {
                            sigo = 2;
                        }
                        dr1.Close();
                        conectar.Close();


                        //        if (sigo == 1)
                        //        {

                        dgvCabinas.Rows.Add();
                        dgvCabinas.Rows[FrmPrincipal.contirow].Cells[0].Value = true;
                        dgvCabinas.Rows[FrmPrincipal.contirow].Cells[1].Value = torneo;
                        dgvCabinas.Rows[FrmPrincipal.contirow].Cells[2].Value = evento;
                        dgvCabinas.Rows[FrmPrincipal.contirow].Cells[3].Value = medio;
                        dgvCabinas.Rows[FrmPrincipal.contirow].Cells[4].Value = fila;
                        dgvCabinas.Rows[FrmPrincipal.contirow].Cells[5].Value = asiento;
                        dgvCabinas.Rows[FrmPrincipal.contirow].Cells[6].Value = 1;
                        dgvCabinas.Rows[FrmPrincipal.contirow].Cells[9].Value = credencial;

                        conectar = Conexion.ObtenerConexion();
                        cmd = new MySqlCommand("SELECT Id_Medios, Nombre_Medio, Letras  FROM medios WHERE Nombre_Medio ='" + medio + "' COLLATE utf8_spanish_ci", conectar);
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            dgvCabinas.Rows[FrmPrincipal.contirow].Cells[11].Value = dr.GetString(2);
                        }
                        dr.Close();
                        conectar.Close();

                        FrmPrincipal.contirow++;
                        credencial++;


                        //      }
                        //      else
                        //    {
                        //         sigo = 1;
                        //     }
                    }
                }







            }



            conectar.Close();

        }


        public void Importar_Pupitres_Fila7(DataGridView dgvDatos, DataGridView dgvCabinas, string torneo, string evento, Button imprimir, Button imprimir_nuevos, Button imprimir_fiesta)
        {


            string medio, fila, asiento;
            int credencial = 0, sigo = 1, cont = 0;

            DateTime mihora = DateTime.Now;
            string lahora = mihora.ToString("yyyy-MM-dd");

            int result;
            fila = "7";



            conectar = Conexion.ObtenerConexion();
            cmd = new MySqlCommand("SELECT Credencial_Pupitres  FROM setup", conectar);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                credencial = dr.GetInt32(0);
            }
            dr.Close();
            conectar.Close();


            foreach (DataGridViewRow row in dgvDatos.Rows)
            {

                if (cont > 26)
                {
                    if (int.TryParse(Convert.ToString(row.Cells[0].Value), out result))
                    {
                        asiento = Convert.ToString(row.Cells[0].Value);
                        medio = Convert.ToString(row.Cells[1].Value);

                        if (asiento != "")
                        {

                            conectar = Conexion.ObtenerConexion();
                            cmd1 = new MySqlCommand("SELECT Fila, Asiento  FROM anuales Where  Fila=7 AND Asiento=" + asiento, conectar);
                            dr1 = cmd1.ExecuteReader();
                            while (dr1.Read())
                            {
                                sigo = 2;
                            }
                            dr1.Close();
                            conectar.Close();


                            //       if (sigo == 1)
                            //       {

                            dgvCabinas.Rows.Add();
                            dgvCabinas.Rows[FrmPrincipal.contirow].Cells[0].Value = true;
                            dgvCabinas.Rows[FrmPrincipal.contirow].Cells[1].Value = torneo;
                            dgvCabinas.Rows[FrmPrincipal.contirow].Cells[2].Value = evento;
                            dgvCabinas.Rows[FrmPrincipal.contirow].Cells[3].Value = medio;
                            dgvCabinas.Rows[FrmPrincipal.contirow].Cells[4].Value = fila;
                            dgvCabinas.Rows[FrmPrincipal.contirow].Cells[5].Value = asiento;
                            dgvCabinas.Rows[FrmPrincipal.contirow].Cells[6].Value = 1;
                            dgvCabinas.Rows[FrmPrincipal.contirow].Cells[9].Value = credencial;

                            conectar = Conexion.ObtenerConexion();
                            cmd = new MySqlCommand("SELECT Id_Medios, Nombre_Medio, Letras  FROM medios WHERE Nombre_Medio ='" + medio + "' COLLATE utf8_spanish_ci", conectar);
                            dr = cmd.ExecuteReader();
                            while (dr.Read())
                            {
                                dgvCabinas.Rows[FrmPrincipal.contirow].Cells[11].Value = dr.GetString(2);
                            }
                            dr.Close();
                            conectar.Close();

                            FrmPrincipal.contirow++;
                            credencial++;


                            //     }
                            //     else
                            //     {
                            //         sigo = 1;
                            //    }
                        }

                    }




                }
                cont++;

            }



            conectar.Close();
            imprimir.Enabled = true;
            imprimir_nuevos.Enabled = true;
            imprimir_fiesta.Enabled = true;
            MessageBox.Show("Se cargaron los datos correctamente");

        }





        public void Importar_Moviles(DataGridView dgvDatos, DataGridView dgvMovil, string torneo, string evento, Button imprimir, Button imprimir_nuevos, Button imprimir_fiesta)
        {



            string medio;
            int credencial = 0;

            DateTime mihora = DateTime.Now;
            string lahora = mihora.ToString("yyyy-MM-dd");
            int result;


            FrmPrincipal.contirow = 0;

            conectar = Conexion.ObtenerConexion();
            cmd = new MySqlCommand("SELECT Credencial_Moviles  FROM setup", conectar);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                credencial = dr.GetInt32(0);
            }
            dr.Close();
            conectar.Close();





            foreach (DataGridViewRow row in dgvDatos.Rows)
            {

                if (int.TryParse(Convert.ToString(row.Cells[0].Value), out result))
                {

                }

                else

                {


                    medio = Convert.ToString(row.Cells[0].Value);



                    dgvMovil.Rows.Add();
                    dgvMovil.Rows[FrmPrincipal.contirow].Cells[0].Value = true;
                    dgvMovil.Rows[FrmPrincipal.contirow].Cells[1].Value = torneo;
                    dgvMovil.Rows[FrmPrincipal.contirow].Cells[2].Value = evento;
                    dgvMovil.Rows[FrmPrincipal.contirow].Cells[3].Value = medio;
                    dgvMovil.Rows[FrmPrincipal.contirow].Cells[4].Value = 1;
                    dgvMovil.Rows[FrmPrincipal.contirow].Cells[7].Value = credencial;

                    conectar = Conexion.ObtenerConexion();
                    cmd = new MySqlCommand("SELECT Id_Medios, Nombre_Medio, Letras  FROM medios WHERE Nombre_Medio ='" + medio + "' COLLATE utf8_spanish_ci", conectar);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        dgvMovil.Rows[FrmPrincipal.contirow].Cells[9].Value = dr.GetString(2);
                    }
                    dr.Close();
                    conectar.Close();


                    FrmPrincipal.contirow++;
                    credencial++;


                }







            }

            imprimir.Enabled = true;
            imprimir_nuevos.Enabled = true;
            imprimir_fiesta.Enabled = true;
            MessageBox.Show("Se cargaron los datos correctamente");

        }


        public void Importar_TV(DataGridView dgvDatos, DataGridView dgvMovil, string torneo, string evento, Button imprimir, Button imprimir_nuevos, Button imprimir_fiesta)
        {



            string medio;
            int credencial = 0;

            DateTime mihora = DateTime.Now;
            string lahora = mihora.ToString("yyyy-MM-dd");
            int result;


            FrmPrincipal.contirow = 0;

            conectar = Conexion.ObtenerConexion();
            cmd = new MySqlCommand("SELECT Credencial_Moviles  FROM setup", conectar);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                credencial = dr.GetInt32(0);
            }
            dr.Close();
            conectar.Close();

            foreach (DataGridViewRow row in dgvDatos.Rows)
            {

                if (int.TryParse(Convert.ToString(row.Cells[0].Value), out result))
                {

                }

                else

                {

                    medio = Convert.ToString(row.Cells[0].Value);



                    dgvMovil.Rows.Add();
                    dgvMovil.Rows[FrmPrincipal.contirow].Cells[0].Value = true;
                    dgvMovil.Rows[FrmPrincipal.contirow].Cells[1].Value = torneo;
                    dgvMovil.Rows[FrmPrincipal.contirow].Cells[2].Value = evento;
                    dgvMovil.Rows[FrmPrincipal.contirow].Cells[3].Value = medio;
                    dgvMovil.Rows[FrmPrincipal.contirow].Cells[4].Value = 1;
                    dgvMovil.Rows[FrmPrincipal.contirow].Cells[7].Value = credencial;

                    conectar = Conexion.ObtenerConexion();
                    cmd = new MySqlCommand("SELECT Id_Medios, Nombre_Medio, Letras  FROM medios WHERE Nombre_Medio ='" + medio + "' COLLATE utf8_spanish_ci", conectar);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        dgvMovil.Rows[FrmPrincipal.contirow].Cells[9].Value = dr.GetString(2);
                    }
                    dr.Close();
                    conectar.Close();

                    FrmPrincipal.contirow++;
                    credencial++;


                }




            }

            imprimir.Enabled = true;
            imprimir_nuevos.Enabled = true;
            imprimir_fiesta.Enabled = true;
            MessageBox.Show("Se cargaron los datos correctamente");

        }

        public void muestro_rivales(DataGridView dgvDatos, string criterio)

        {
            int contirow = 0;
            string ruta = "", escudos = "";
            string miimagen;


            conectar = Conexion.ObtenerConexion_Analytics();
            cmd = new MySqlCommand("Select escudos From setup", conectar);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                escudos = dr.GetString(0);
            }


            dr.Close();

            dgvDatos.Rows.Clear();



            cmd = new MySqlCommand(criterio, conectar);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                ruta = escudos + dr.GetString(2);
                dgvDatos.Rows.Add();
                dgvDatos.Rows[contirow].Cells[0].Value = Image.FromFile(ruta);
                dgvDatos.Rows[contirow].Cells[1].Value = dr.GetString(1);
                dgvDatos.Rows[contirow].Cells[2].Value = dr.GetString(0);
                contirow++;

            }
            conectar.Close();

        }


        public void muestro_eventos(DataGridView dgvDatos, string criterio)

        {
            int contirow = 0, elequipo = 0;
            string ruta = "", escudos = "";
            DateTime mihora = DateTime.Now;
            string lahora = "";

            conectar1 = Conexion.ObtenerConexion_Analytics();
            cmd = new MySqlCommand("Select escudos From setup", conectar1);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                escudos = dr.GetString(0);
            }

            dr.Close();
            conectar1.Close();

            dgvDatos.Rows.Clear();
            conectar = Conexion.ObtenerConexion();
            cmd = new MySqlCommand(criterio, conectar);
            dr = cmd.ExecuteReader();


            while (dr.Read())
            {
                conectar1 = Conexion.ObtenerConexion_Analytics();
                elequipo = dr.GetInt32(7);
                cmd1 = new MySqlCommand("Select Id_Equipo, Nombre_Equipo, Escudo From equipos  Where Id_Equipo=" + elequipo, conectar1);
                dr1 = cmd1.ExecuteReader();

                while (dr1.Read())
                {
                    ruta = escudos + dr1.GetString(2);
                    dgvDatos.Rows.Add();
                    dgvDatos.Rows[contirow].Cells[0].Value = Image.FromFile(ruta);
                    dgvDatos.Rows[contirow].Cells[1].Value = dr1.GetString(1);
                    mihora = Convert.ToDateTime(dr.GetString(3));
                    lahora = mihora.ToString("yyyy-MM-dd");
                    dgvDatos.Rows[contirow].Cells[2].Value = lahora;
                    dgvDatos.Rows[contirow].Cells[3].Value = dr.GetString(0);
                    dgvDatos.Rows[contirow].Cells[4].Value = dr1.GetString(0);
                    dgvDatos.Rows[contirow].Cells[5].Value = dr.GetString(8);
                    dgvDatos.Rows[contirow].Cells[6].Value = dr.GetString(9);
                    dgvDatos.Rows[contirow].Cells[7].Value = dr.GetString(7);
                    contirow++;

                }
                dr1.Close();
                conectar1.Close();
            }
            conectar.Close();

        }




        public void traigo_escudo_rival(string rival, PictureBox imagen, PictureBox imagenriver, Label nombrerival, Panel cuadro)

        {

            string ruta = "", escudos = "";


            conectar = Conexion.ObtenerConexion_Analytics();
            cmd = new MySqlCommand("SELECT  escudos FROM setup", conectar);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                escudos = dr.GetString(0);
            }

            conectar.Close();


            conectar = Conexion.ObtenerConexion_Analytics();
            cmd = new MySqlCommand("SELECT Escudo_Full, Nombre_Equipo FROM equipos WHERE Id_Equipo=" + rival, conectar);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                ruta = escudos + dr.GetString(0);
                imagen.Image = Image.FromFile(ruta);
                nombrerival.Text = dr.GetString(1);
                imagen.Visible = true;
                imagenriver.Visible = true;
                cuadro.Visible = true;


            }
            conectar.Close();

        }




        public void Importar_Datos_Excel_Seguridad(DataGridView dgvDatos, System.Windows.Forms.ProgressBar progressBar, DataGridView dgvCabinas, string torneo, string evento, Button imprimir)
        {






            DateTime mihora = DateTime.Now;
            string lahora = mihora.ToString("yyyy-MM-dd");
            progressBar.Maximum = dgvDatos.RowCount;
            progressBar.Step = 1;
            string apellido, nombre, cargo, nivelacceso, status;
            FrmPrincipal.contirow = 0;



            foreach (DataGridViewRow row in dgvDatos.Rows)
            {

                apellido = Convert.ToString(row.Cells[0].Value);
                nombre = Convert.ToString(row.Cells[1].Value);
                cargo = Convert.ToString(row.Cells[2].Value);
                nivelacceso = Convert.ToString(row.Cells[3].Value);
                //   status = Convert.ToString(row.Cells[8].Value);


                dgvCabinas.Rows.Add();
                dgvCabinas.Rows[FrmPrincipal.contirow].Cells[0].Value = true;
                dgvCabinas.Rows[FrmPrincipal.contirow].Cells[1].Value = torneo;
                dgvCabinas.Rows[FrmPrincipal.contirow].Cells[2].Value = evento;
                dgvCabinas.Rows[FrmPrincipal.contirow].Cells[3].Value = nombre;
                dgvCabinas.Rows[FrmPrincipal.contirow].Cells[4].Value = apellido;
                dgvCabinas.Rows[FrmPrincipal.contirow].Cells[5].Value = cargo;
                dgvCabinas.Rows[FrmPrincipal.contirow].Cells[6].Value = nivelacceso;
                //  dgvCabinas.Rows[FrmPrincipal.contirow].Cells[7].Value = status;


                FrmPrincipal.contirow++;









                progressBar.PerformStep();

            }

            imprimir.Enabled = true;
            MessageBox.Show("Se cargaron los datos correctamente");

        }


        public void llenarcombonivelacceso(ComboBox cb, string criterio)

        {


            try
            {

                conectar = Conexion.ObtenerConexion();

                string query = criterio;
                MySqlCommand cmd = new MySqlCommand(query, conectar);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cb.ValueMember = "Id_Nivel_Acceso";
                cb.DisplayMember = "Descripcion";
                cb.DataSource = dt;



            }
            catch (Exception ex)
            {
                MessageBox.Show("No se lleno el Combo: " + ex.ToString());


            }

        }



        public void llenarcombotipopersona(ComboBox cb, string criterio)

        {


            try
            {

                conectar = Conexion.ObtenerConexion();

                string query = criterio;
                MySqlCommand cmd = new MySqlCommand(query, conectar);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cb.ValueMember = "Id_TipoPersona";
                cb.DisplayMember = "Descripcion";
                cb.DataSource = dt;



            }
            catch (Exception ex)
            {
                MessageBox.Show("No se lleno el Combo: " + ex.ToString());


            }

        }


        public void ExportarDataGridViewExcel(DataGridView dgvDatos)
        {

            SaveFileDialog fichero = new SaveFileDialog();
            fichero.Filter = "Excel (*.xls)|*.xls";
            if (fichero.ShowDialog() == DialogResult.OK)
            {
                Microsoft.Office.Interop.Excel.Application aplicacion;
                Microsoft.Office.Interop.Excel.Workbook libros_trabajo;
                Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;
                aplicacion = new Microsoft.Office.Interop.Excel.Application();
                libros_trabajo = aplicacion.Workbooks.Add();
                hoja_trabajo =
                    (Microsoft.Office.Interop.Excel.Worksheet)libros_trabajo.Worksheets.get_Item(1);

                hoja_trabajo.Cells[1, 1] = "Imp";
                hoja_trabajo.Cells[1, 2] = "TORNEO";
                hoja_trabajo.Cells[1, 3] = "EVENTO";
                hoja_trabajo.Cells[1, 4] = "APELLIDO";
                hoja_trabajo.Cells[1, 5] = "NOMBRE";
                hoja_trabajo.Cells[1, 6] = "CARGO";
                hoja_trabajo.Cells[1, 7] = "NIVEL DE ACCESO";
                hoja_trabajo.Cells[1, 8] = "TIPO PERSONA";



                //Recorremos el DataGridView rellenando la hoja de trabajo
                for (int i = 1; i < dgvDatos.Rows.Count - 1; i++)
                {
                    for (int j = 1; j < dgvDatos.Columns.Count; j++)
                    {
                        if (Convert.ToBoolean(dgvDatos.Rows[i].Cells[0].Value) == true)
                        {
                            hoja_trabajo.Cells[i + 1, j + 1] = dgvDatos.Rows[i].Cells[j].Value;
                        }
                    }
                }
                libros_trabajo.SaveAs(fichero.FileName,
                Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                libros_trabajo.Close(true);
                aplicacion.Quit();
            }
        }

        public void Guardo_Configuracion_Impresion(string txtfontcampeonato, string txtsizecampeonato, string txtfontrival, string txtsizerival, string txtfontmedio, string txtsizemedio, string txtfontfechan, string txtsizefechan, string evento, int Id_Evento, string txtfontubicacion, string txtsizeubicacion, CheckBox negritacampeonato, CheckBox negritamedio, CheckBox negritarival, CheckBox negritafecha, CheckBox negritaubicacion, string txtfontnombre, string txtsizenombre, CheckBox negritanombre)
        {


            int ncampeonato = 2, nmedio = 2, nrival = 2, nfecha = 2, nubicacion = 2, nnombre = 2;






            if (negritacampeonato.Checked == true)
            {
                ncampeonato = 1;

            }
            else
            {
                ncampeonato = 2;
            }

            if (negritamedio.Checked == true)
            {
                nmedio = 1;

            }
            else
            {
                nmedio = 2;
            }

            if (negritarival.Checked == true)
            {
                nrival = 1;

            }
            else
            {
                nrival = 2;
            }

            if (negritafecha.Checked == true)
            {
                nfecha = 1;

            }
            else
            {
                nfecha = 2;
            }

            if (negritaubicacion.Checked == true)
            {
                nubicacion = 1;

            }
            else
            {
                nubicacion = 2;
            }


            if (negritanombre.Checked == true)
            {
                nnombre = 1;

            }
            else
            {
                nnombre = 2;
            }

            conectar = Conexion.ObtenerConexion();
            cmd = new MySqlCommand("UPDATE eventos SET Nombre_Evento='" + evento + "', FuenteEvento='" + txtfontrival + "', SizeEvento=" + txtsizerival + ", CampeonatoFuente='" + txtfontcampeonato + "', CampeonatoSize=" + txtsizecampeonato + ", MedioFuente='" + txtfontmedio + "', MedioSize=" + txtsizemedio + ", FechaNFuente='" + txtfontfechan + "', FechaNSize=" + txtsizefechan + ", UbicacionFuente='" + txtfontubicacion + "', UbicacionSize=" + txtsizeubicacion + ", CampeonatoNegrita=" + ncampeonato + ", MedioNegrita=" + nmedio + ", FechaNNegrita=" + nfecha + ", RivalNegrita=" + nrival + ", UbicacionNegrita=" + nubicacion + ", RivalFuente='" + txtfontrival + "', RivalSize=" + txtsizerival + ", NombreFuente='" + txtfontnombre + "', NombreSize=" + txtsizenombre + ", NombreNegrita=" + nnombre + "  WHERE Id_Evento=" + Id_Evento, conectar);
            cmd.ExecuteNonQuery();

            conectar.Close();

            MessageBox.Show("Se Cargaron las Configuraciones de Impresion Correctamente");




        }

        public void Traigo_Configuracion_Impresiones(TextBox txtfontcampeonato, TextBox txtsizecampeonato, TextBox txtfontrival, TextBox txtsizerival, TextBox txtfontmedio, TextBox txtsizemedio, TextBox txtfontfechan, TextBox txtsizefechan, string Id_Evento, TextBox txtfontubicacion, TextBox txtsizeubicacion, CheckBox ncampeonato, CheckBox nrival, CheckBox nfecha, CheckBox nmedio, CheckBox nubicacion, TextBox txtCampeonato, TextBox txtRival, TextBox txtCanal, TextBox txtFecha, TextBox txtUbicacion, TextBox txtfontnombre, TextBox txtsizenombre, CheckBox nnombre, TextBox txtNombre)
        {

            conectar = Conexion.ObtenerConexion();
            cmd = new MySqlCommand("SELECT CampeonatoFuente, CampeonatoSize, RivalFuente, RivalSize, MedioFuente, MedioSize, FechaNFuente, FechaNSize, UbicacionFuente, UbicacionSize, CampeonatoNegrita, MedioNegrita, FechaNNegrita, UbicacionNegrita, RivalNegrita, NombreFuente, NombreSize, NombreNegrita FROM eventos WHERE Id_Evento=" + Id_Evento, conectar);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                txtfontcampeonato.Text = dr.GetString(0);

                txtsizecampeonato.Text = dr.GetString(1);
                txtfontrival.Text = dr.GetString(2);
                txtsizerival.Text = dr.GetString(3);
                txtfontmedio.Text = dr.GetString(4);
                txtsizemedio.Text = dr.GetString(5);
                txtfontfechan.Text = dr.GetString(6);
                txtsizefechan.Text = dr.GetString(7);
                txtfontubicacion.Text = dr.GetString(8);
                txtsizeubicacion.Text = dr.GetString(9);
                txtfontnombre.Text = dr.GetString(15);
                txtsizenombre.Text = dr.GetString(16);


                if (dr.GetInt32(10) == 1)
                {
                    ncampeonato.Checked = true;

                }
                if (dr.GetInt32(11) == 1)
                {
                    nmedio.Checked = true;

                }

                if (dr.GetInt32(12) == 1)
                {
                    nfecha.Checked = true;

                }

                if (dr.GetInt32(13) == 1)
                {
                    nubicacion.Checked = true;

                }

                if (dr.GetInt32(14) == 1)
                {
                    nrival.Checked = true;

                }

                if (dr.GetInt32(17) == 1)
                {
                    nnombre.Checked = true;

                }

                txtCampeonato.Font = new Font(dr.GetString(0), dr.GetInt32(1));
                txtRival.Font = new Font(dr.GetString(2), dr.GetInt32(3));
                txtCanal.Font = new Font(dr.GetString(4), dr.GetInt32(5));
                txtFecha.Font = new Font(dr.GetString(6), dr.GetInt32(7));
                txtUbicacion.Font = new Font(dr.GetString(8), dr.GetInt32(9));
                txtNombre.Font = new Font(dr.GetString(15), dr.GetInt32(16));


            }
            conectar.Close();

        }



        public void Traigo_Configuracion_Evento(string Id_Evento)
        {



            conectar = Conexion.ObtenerConexion();
            cmd = new MySqlCommand("SELECT FuenteEvento, SizeEvento, CampeonatoFuente, CampeonatoSize, CampeonatoNegrita, MedioFuente, MedioSize, MedioNegrita, FechaNFuente, FechaNSize, FechaNNegrita, UbicacionFuente, UbicacionSize, UbicacionNegrita, RivalFuente, RivalSize, RivalNegrita, NombreFuente, NombreSize, NombreNegrita  From eventos Where Id_Evento=" + Id_Evento, conectar);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                FrmLogin.nomfuente = dr.GetString(0);
                FrmLogin.sizefuente = Convert.ToUInt16(dr.GetString(1));
                FrmLogin.nomfuentecampeonato = dr.GetString(2);
                FrmLogin.sizecampeonato = dr.GetInt16(3);
                FrmLogin.negritacampeonato = dr.GetInt16(4);
                FrmLogin.nomfuentemedio = dr.GetString(5);
                FrmLogin.sizemedio = dr.GetInt16(6);
                FrmLogin.negritamedio = dr.GetInt16(7);
                FrmLogin.nomfuentefecha = dr.GetString(8);
                FrmLogin.sizefecha = dr.GetInt16(9);
                FrmLogin.negritafecha = dr.GetInt16(10);
                FrmLogin.nomfuenteubicacion = dr.GetString(11);
                FrmLogin.sizeubicacion = dr.GetInt16(12);
                FrmLogin.negritaubicacion = dr.GetInt16(13);
                FrmLogin.nomfuenterival = dr.GetString(14);
                FrmLogin.sizerival = dr.GetInt16(15);
                FrmLogin.negritarival = dr.GetInt16(16);
                FrmLogin.nomfuentenombre = dr.GetString(17);
                FrmLogin.sizenombre = dr.GetInt16(18);
                FrmLogin.negritanombre = dr.GetInt16(19);


            }
            conectar.Close();

        }

        public void Traigo_Fuentes_Evento(string Id_Evento)
        {

            conectar = Conexion.ObtenerConexion();
            cmd = new MySqlCommand("SELECT CampeonatoFuente, CampeonatoSize, RivalFuente, RivalSize, MedioFuente, MedioSize, FechaNFuente, fechaNSize,  UbicacionFuente, UbicacionSize From eventos Where Id_Evento=" + Id_Evento, conectar);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {

                FrmLogin.nomfuentecampeonato = dr.GetString(0);
                FrmLogin.sizecampeonato = Convert.ToInt32(dr.GetString(1));
                FrmLogin.nomfuenterival = dr.GetString(2);
                FrmLogin.sizerival = Convert.ToInt32(dr.GetString(3));
                FrmLogin.nomfuentemedio = dr.GetString(4);
                FrmLogin.sizemedio = Convert.ToInt32(dr.GetString(5));
                FrmLogin.nomfuentefecha = dr.GetString(6);
                FrmLogin.sizefecha = Convert.ToInt32(dr.GetString(7));
                FrmLogin.nomfuenteubicacion = dr.GetString(8);
                FrmLogin.sizeubicacion = Convert.ToInt32(dr.GetString(9));
                FrmLogin.nomfuentenombre = dr.GetString(8);
                FrmLogin.sizenombre = Convert.ToInt32(dr.GetString(9));

            }
            conectar.Close();

        }


        public void importarExcel(DataGridView dgv, String nombreHoja, Button importar)
        {
            string ruta = "";
            try
            {

                OpenFileDialog openfile1 = new OpenFileDialog();
                openfile1.Filter = "Excel Files | *.xlsx";
                openfile1.Title = "Seleccione el archivo a Importar";
                if (openfile1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                    if (openfile1.FileName.Equals("") == false)
                    {
                        ruta = openfile1.FileName;
                    }

                }

                conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;data source=" + ruta + ";Extended Properties='Excel 8.0;HDR=Yes'");
                MyDataAdapter = new OleDbDataAdapter("Select * From [" + nombreHoja + "$]", conn);
                dt = new DataTable();
                MyDataAdapter.Fill(dt);
                dgv.DataSource = dt;
                importar.Enabled = true;


            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }


          

        }

        public void Importar_Lecturas(DataGridView dgvDatos, System.Windows.Forms.ProgressBar progressBar, DataGridView dgvCabinas)
        {


            int contirow = 0;

            progressBar.Maximum = dgvDatos.RowCount;
            progressBar.Step = 1;

            conectar = Conexion.ObtenerConexion();


            foreach (DataGridViewRow row in dgvDatos.Rows)
            {


                cmd = new MySqlCommand("SELECT Id_Impresiones, Cabina, Asiento, Fila, Medio FROM impresiones  WHERE Id_Impresiones=" + Convert.ToString(row.Cells[3].Value), conectar);
                dr = cmd.ExecuteReader();

                while (dr.Read())


                dgvCabinas.Rows.Add();
                dgvCabinas.Rows[contirow].Cells[0].Value = Convert.ToString(row.Cells[0].Value);
                dgvCabinas.Rows[contirow].Cells[1].Value = Convert.ToString(row.Cells[1].Value);
                dgvCabinas.Rows[contirow].Cells[2].Value = Convert.ToString(row.Cells[2].Value);
                dgvCabinas.Rows[contirow].Cells[3].Value = Convert.ToString(row.Cells[3].Value);
                dgvCabinas.Rows[contirow].Cells[4].Value = Convert.ToString(row.Cells[4].Value);
                dgvCabinas.Rows[contirow].Cells[5].Value = Convert.ToString(row.Cells[5].Value);
                dgvCabinas.Rows[contirow].Cells[6].Value = Convert.ToString(dr.GetString(4));
                dgvCabinas.Rows[contirow].Cells[7].Value = Convert.ToString(dr.GetString(1));
                dgvCabinas.Rows[contirow].Cells[8].Value = Convert.ToString(dr.GetString(3));
                dgvCabinas.Rows[contirow].Cells[9].Value = Convert.ToString(dr.GetString(2));

                dr.Close();

                contirow++;

                progressBar.PerformStep();

            }
            conectar.Close();


            MessageBox.Show("Se cargaron los datos correctamente");

        }



        public void Traigo_Lecturas(DataGridView dgvCabinas)
        {

            int contirow = 0;


            conectar = Conexion.ObtenerConexion();
            cmd = new MySqlCommand("SELECT Evento, Lectura, Fecha, Sector,Hora, Medio, Cabina, Fila, Asiento FROM lecturas ORDER BY Evento, Medio", conectar);
            dr = cmd.ExecuteReader();

            while (dr.Read())

            {
                dgvCabinas.Rows.Add();
                dgvCabinas.Rows[contirow].Cells[0].Value = Convert.ToString(dr.GetString(0));
                dgvCabinas.Rows[contirow].Cells[1].Value = Convert.ToString(dr.GetString(1));
                dgvCabinas.Rows[contirow].Cells[2].Value = Convert.ToString(dr.GetString(2));
                dgvCabinas.Rows[contirow].Cells[3].Value = Convert.ToString(dr.GetString(3));
                dgvCabinas.Rows[contirow].Cells[4].Value = Convert.ToString(dr.GetString(4));
                dgvCabinas.Rows[contirow].Cells[5].Value = Convert.ToString(dr.GetString(5));
                dgvCabinas.Rows[contirow].Cells[6].Value = Convert.ToString(dr.GetString(6));
                dgvCabinas.Rows[contirow].Cells[7].Value = Convert.ToString(dr.GetString(7));
                dgvCabinas.Rows[contirow].Cells[8].Value = Convert.ToString(dr.GetString(8));

                contirow++;



            }
            conectar.Close();


            MessageBox.Show("Se cargaron los datos correctamente");

        }




    

       
        public void Importar_Medios(DataGridView dgvDatos)
        {



            int contirow = 0;
            string medios;


            foreach (DataGridViewRow row in dgvDatos.Rows)
            {
                medios = Convert.ToString(dgvDatos.Rows[contirow].Cells[0].Value);

                conectar = Conexion.ObtenerConexion();
                cmd = new MySqlCommand("SELECT Nombre_Medio FROM medios WHERE Nombre_Medio ='" + medios + "'", conectar);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {


                }

                else
                {
                    conectar1 = Conexion.ObtenerConexion();
                    cmd1 = new MySqlCommand("Insert into medios(Nombre_Medio) values('" + medios + "')", conectar1);
                    cmd1.ExecuteNonQuery();
                    conectar1.Close();
                }


                conectar.Close();
                contirow++;




            }


            MessageBox.Show("Se cargaron los datos correctamente");

        }





        public void Importar_DNI(DataGridView dgvDatos, TextBox lista, TextBox medio)
        {
            int contirow = 0;
            string dni;


            foreach (DataGridViewRow row in dgvDatos.Rows)
            {
                dni = Convert.ToString(dgvDatos.Rows[contirow].Cells[0].Value);
                //medio = Convert.ToString(dgvDatos.Rows[contirow].Cells[1].Value);


                conectar = Conexion.ObtenerConexion();
                cmd = new MySqlCommand("SELECT dni FROM dni_seguridad WHERE dni ='" + dni + "'", conectar);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {


                }

                else
                {
                    conectar1 = Conexion.ObtenerConexion();
                    cmd1 = new MySqlCommand("Insert into dni_seguridad(dni, medio, Lista, Estado) values('" + dni + "', '" + medio.Text + "', '" + lista.Text + "', 1)", conectar1);
                    cmd1.ExecuteNonQuery();
                    conectar1.Close();
                }


                conectar.Close();
                contirow++;




            }

            MessageBox.Show("Se cargaron los datos correctamente");

        }


     


        public void borrarbase()
        {

            conectar = Conexion.ObtenerConexion();
            cmd = new MySqlCommand("DELETE FROM dni_seguridad", conectar);
            cmd.ExecuteNonQuery();
            conectar.Close();
            MessageBox.Show("Los registros fueron eliminados");


        }

        public string importarEscudo(TextBox miruta, PictureBox escudo)
        {

            string archivo = "", ruta;
           




            OpenFileDialog openfile1 = new OpenFileDialog();
            openfile1.Filter = "Images(*.PNG; *.JPG; *.GIF)| *.PNG; *.JPG; *.GIF |" + "All files (*.*)|*.*";
            openfile1.Title = "Seleccione el archivo a Importar";
            if (openfile1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
               if (openfile1.FileName.Equals("") == false)
               {
                        ruta = Convert.ToString(openfile1.FileName);
                        miruta.Text= Convert.ToString(openfile1.FileName);
                        archivo = ruta.Substring(ruta.LastIndexOf("\\") + 1);
                        escudo.Image= Image.FromFile(ruta);
                        
               }
                



            }
            return archivo;


        }

        public string cargoequipo(string nombre, string pais, string escudo, int nacional, string ruta)
        {
            string escudo20="", destino="";

            try
            {

                conectar = Conexion.ObtenerConexion_Analytics();
                cmd = new MySqlCommand("Select Escudo_Blanco, Destino From setup", conectar);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    escudo20 = dr.GetString(0);
                    destino = dr.GetString(1) + escudo;
                }


                dr.Close();
                conectar.Close();

                System.IO.File.Copy(ruta, destino, true);
               
                conectar = Conexion.ObtenerConexion_Analytics();
                cmd = new MySqlCommand("Insert into equipos(Nombre_Equipo, Pais, Escudo, Escudo_Full, Nacional) values('" + nombre + "', '" + pais + "', '" + escudo20 + "', '" + escudo + "'," + nacional + ")", conectar);
                cmd.ExecuteNonQuery();
                conectar.Close();

                MessageBox.Show("Se ha cargado un nuevo Equipo con exito");


            }
            catch (Exception ex)

            {
                MessageBox.Show(ex.ToString());
            }

            return nombre;
        }

        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;

        }


        public void Importar_Lecturas(DataGridView dgvDatos, string mifecha, string evento)
        {

            string fecha;
            DateTime mihora;
            
            foreach (DataGridViewRow row in dgvDatos.Rows)
            {
                mihora = Convert.ToDateTime(mifecha);
                fecha = mihora.ToString("yyyy-MM-dd");
                
                conectar = Conexion.ObtenerConexion();
                cmd = new MySqlCommand("SELECT * FROM lecturas WHERE Evento ='" + evento + "' AND Fecha='" + fecha + "'" , conectar);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {


                    if (MessageBox.Show("Ya se ha actualizado este evento. Esta seguro que quiere volver a actualizarlo ?", "Actualizar Evento", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Actualizo_Lecturas(dgvDatos, fecha);
                    }

                }

                else
                {
                    Actualizo_Lecturas(dgvDatos, fecha);
                }


                conectar.Close();
                break;
            }

            

        }

        public void Actualizo_Lecturas(DataGridView dgvDatos, string fecha)
        {
            string evento, lectura, id, sector, hora, medio, asiento, fila, cabina;
            int conti = 0;
            foreach (DataGridViewRow row in dgvDatos.Rows)
            {
                evento = Convert.ToString(dgvDatos.Rows[conti].Cells[0].Value);
                lectura = Convert.ToString(dgvDatos.Rows[conti].Cells[1].Value);
                id = Convert.ToString(dgvDatos.Rows[conti].Cells[3].Value);
                sector = Convert.ToString(dgvDatos.Rows[conti].Cells[4].Value);
                hora = Convert.ToString(dgvDatos.Rows[conti].Cells[5].Value);
                medio = Convert.ToString(dgvDatos.Rows[conti].Cells[6].Value);
                cabina = Convert.ToString(dgvDatos.Rows[conti].Cells[7].Value);
                fila = Convert.ToString(dgvDatos.Rows[conti].Cells[8].Value);
                asiento = Convert.ToString(dgvDatos.Rows[conti].Cells[9].Value);




                conectar = Conexion.ObtenerConexion();
                cmd = new MySqlCommand("Insert into lecturas(Evento, Lectura, Fecha, Id_Impresiones, Sector, Hora, Medio, Asiento, Fila, Cabina) values('" + evento + "', '" + lectura + "', '" + fecha + "', " + id + ", '" + sector + "', '" + hora + "', '" + medio + "', " + asiento + ", " + fila + ", " + cabina + ")", conectar);
                cmd.ExecuteNonQuery();
                conectar.Close();
                conti++;
            }

            MessageBox.Show("Se han cargado las Nuevas Lecturas con exito");

        }
    }
}