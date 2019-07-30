using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;


namespace ImpresionQR
{
    class Recorridos
    {

        MySqlCommand cmd;
        MySqlDataReader dr;
        MySqlConnection conectar;

        public void traigo_datos_tarjetas(DataGridView dgvDatos)

        {
            int contirow = 0;

            dgvDatos.Rows.Clear();

            conectar = Conexion.ObtenerConexion();
            cmd = new MySqlCommand("SELECT Id_Tarjetas, Numero_Serie, Nombre_Tarjeta, Estado FROM  tarjetas WHERE Estado=1", conectar);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                dgvDatos.Rows.Add();
                dgvDatos.Rows[contirow].Cells[1].Value = ImpresionQR.Properties.Resources.nfc_20;
                dgvDatos.Rows[contirow].Cells[2].Value = dr.GetString(0);
                dgvDatos.Rows[contirow].Cells[3].Value = dr.GetString(2);
                dgvDatos.Rows[contirow].Cells[4].Value = dr.GetString(1);



                contirow++;

            }
            dr.Close();
        }


        public void cargo_alta_tarjetas(string txtnombre, string txtserie)
        {


            conectar = Conexion.ObtenerConexion();
            cmd = new MySqlCommand("Insert into tarjetas(Numero_Serie, Nombre_Tarjeta, Estado) values('" + txtserie + "', '" + txtnombre + "', 1)", conectar);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Se ha cargado una nueva Tarjeta con exito");

        }

        public void elimino_tarjeta(string tarjeta)
        {


            conectar = Conexion.ObtenerConexion();
            cmd = new MySqlCommand("UPDATE tarjetas SET Estado = 9 Where Id_Tarjetas=" + tarjeta, conectar);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Se ha dado de baja la Tarjeta");

        }


        public void muestro_tarjeta(string tarjeta, TextBox txtnombre, TextBox txtserie)
        {


            conectar = Conexion.ObtenerConexion();
            cmd = new MySqlCommand("SELECT Id_Tarjetas, Nombre_Tarjeta, Numero_Serie FROM  tarjetas WHERE Estado=1 AND Id_Tarjetas=" + tarjeta, conectar);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {

                txtnombre.Text = dr.GetString(1);
                txtserie.Text = dr.GetString(2);


            }




        }

        public void modificar_tarjeta(string tarjeta, TextBox txtnombre, TextBox txtserie)
        {
            conectar = Conexion.ObtenerConexion();
            cmd = new MySqlCommand("UPDATE tarjetas SET Nombre_Tarjeta ='" + txtnombre.Text + "', Numero_Serie='" + txtserie.Text + "' WHERE Id_Tarjetas=" + tarjeta, conectar);
            cmd.ExecuteNonQuery();



            MessageBox.Show("Se han modificado correctamente los datos");
        }



        public void traigo_datos_recorridos(DataGridView dgvDatos)

        {
            int contirow = 0;

            dgvDatos.Rows.Clear();

            conectar = Conexion.ObtenerConexion();
            cmd = new MySqlCommand("SELECT Id_Recorrido, Nombre_Recorrido, Fecha_Recorrido, Estado FROM  recorridos WHERE Estado <> 9", conectar);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                dgvDatos.Rows.Add();
                dgvDatos.Rows[contirow].Cells[1].Value = ImpresionQR.Properties.Resources.check_30;
                dgvDatos.Rows[contirow].Cells[2].Value = dr.GetString(0);
                dgvDatos.Rows[contirow].Cells[3].Value = dr.GetString(1);
                dgvDatos.Rows[contirow].Cells[4].Value = Convert.ToDateTime(dr.GetString(2)).ToString("yyyy-MM-dd");



                contirow++;

            }
            dr.Close();
        }

        public void llenarcombotarjetas(ComboBox cb, string criterio)

        {


            try
            {

                conectar = Conexion.ObtenerConexion();

                string query = criterio;

                MySqlCommand cmd = new MySqlCommand(query, conectar);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cb.ValueMember = "Numero_Serie";
                cb.DisplayMember = "Nombre_Tarjeta";


                cb.DataSource = dt;
                conectar.Close();



            }
            catch (Exception ex)
            {
                MessageBox.Show("No se lleno el Combo: " + ex.ToString());


            }



        }

        public void cargoengrid(DataGridView dgvDatos, String nombre, string pdesde, NumericUpDown numec, string serie, string tarjetas)

        {

            int contirow = dgvDatos.RowCount;
            int Idtarjetas=0;

            conectar = Conexion.ObtenerConexion();
            cmd = new MySqlCommand("Select Id_tarjetas, Numero_Serie From Tarjetas Where Numero_Serie='" + serie + "'",  conectar);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Idtarjetas = dr.GetInt32(0);
            }

            numec.Value = numec.Value + 1;

            conectar.Close();

            dgvDatos.Rows.Add();
            dgvDatos.Rows[contirow].Cells[1].Value = ImpresionQR.Properties.Resources.nfc_20;
            dgvDatos.Rows[contirow].Cells[2].Value = tarjetas;
            dgvDatos.Rows[contirow].Cells[3].Value = serie;
            dgvDatos.Rows[contirow].Cells[4].Value = numec.Value;
            dgvDatos.Rows[contirow].Cells[5].Value = pdesde;
            dgvDatos.Rows[contirow].Cells[6].Value = Convert.ToString(Idtarjetas);




        }

        public void altaderecorrido(DataGridView dgvDatos, String nombre, string pdesde, string responsable)
        {
            string serie = "", posicion = "", tarjeta = "";
            string fecha, idtarjeta;
            string fecha_recorrido = Convert.ToDateTime(pdesde).ToString("yyyy-MM-dd");
            int ultimo_Id = 0;

            conectar = Conexion.ObtenerConexion();
            cmd = new MySqlCommand("UPDATE recorridos SET Estado = 0", conectar);
            cmd.ExecuteNonQuery();
            conectar.Close();

            conectar = Conexion.ObtenerConexion();
            cmd = new MySqlCommand("Insert into recorridos(Nombre_Recorrido, Fecha_Recorrido, Estado, Responsable) values('" + nombre + "', '" + fecha_recorrido + "', 1,'" + responsable +"')", conectar);
            cmd.ExecuteNonQuery();
            conectar.Close();

            conectar = Conexion.ObtenerConexion();
            cmd = new MySqlCommand("SELECT Max(Id_Recorrido) FROM recorridos", conectar);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ultimo_Id = dr.GetInt32(0);
            }

            foreach (DataGridViewRow row in dgvDatos.Rows)
            {

                tarjeta = Convert.ToString(row.Cells[2].Value);
                serie = Convert.ToString(row.Cells[3].Value);
                posicion = Convert.ToString(row.Cells[4].Value);
                idtarjeta = Convert.ToString(row.Cells[6].Value);

                fecha = Convert.ToDateTime(row.Cells[5].Value).ToString("yyyy-MM-dd HH:mm:ss");

                conectar = Conexion.ObtenerConexion();
                cmd = new MySqlCommand("Insert into recorridos_tarjetas(Id_Recorrido, Id_tarjetas, Orden, Hora, Estado) values(" + ultimo_Id + ", " + idtarjeta + ", " + posicion + ",'" + fecha + "', 0)", conectar);
                cmd.ExecuteNonQuery();
                conectar.Close();



            }
            MessageBox.Show("Se ha dado el alta con exito");

        }

        public void elimino_recorrido(string recorrido)
        {


            conectar = Conexion.ObtenerConexion();
            cmd = new MySqlCommand("UPDATE recorridos SET Estado = 9 Where Id_Recorrido=" + recorrido, conectar);
            cmd.ExecuteNonQuery();


            conectar = Conexion.ObtenerConexion();
            cmd = new MySqlCommand("UPDATE recorridos_tarjetas SET Estado = 9 Where Id_Recorrido=" + recorrido, conectar);
            cmd.ExecuteNonQuery();
            conectar.Close();

            MessageBox.Show("Se ha dado de baja el Recorrido");

        }

        public void modifico_recorrido(DataGridView dgvDatos, string recorrido, Label responsable)

        {

            int contirow = 0, dias, horas, minutos;
            string total;
            double diftotal = 0;
            
            conectar = Conexion.ObtenerConexion();
            cmd = new MySqlCommand("SELECT a.Id_Recorrido, a.Id_Tarjetas, b.Numero_Serie, a.Orden, a.Hora, a.Estado, b.Nombre_Tarjeta, c.Responsable, IFNULL(a.Observacion, '') , IFNULL(a.Hora_Pasada, '0') FROM recorridos_tarjetas AS a  INNER JOIN Tarjetas As b ON a.Id_Tarjetas=b.Id_Tarjetas  INNER JOIN Recorridos As c ON a.Id_recorrido=c.Id_recorrido  WHERE a.Id_Recorrido=" + recorrido + " AND a.Estado <> 9", conectar);
            dr = cmd.ExecuteReader();
                      

              
                while (dr.Read())
                {
                     responsable.Text = dr.GetString(7);
                
                    dgvDatos.Rows.Add();
                    dgvDatos.Rows[contirow].Cells[1].Value = dr.GetString(6);
                    dgvDatos.Rows[contirow].Cells[2].Value = dr.GetString(2);
                    dgvDatos.Rows[contirow].Cells[3].Value = dr.GetInt32(3);
                    dgvDatos.Rows[contirow].Cells[4].Value = dr.GetString(4);
                    dgvDatos.Rows[contirow].Cells[5].Value = dr.GetInt32(0);
                    dgvDatos.Rows[contirow].Cells[6].Value = dr.GetString(1);
                    dgvDatos.Rows[contirow].Cells[7].Value = dr.GetString(9);
                    dgvDatos.Rows[contirow].Cells[9].Value = dr.GetString(8);

                    if (Convert.ToString(dgvDatos.Rows[contirow].Cells[7].Value) == "0" )
                    { }
                   else
                   {
                    TimeSpan tSpan = Convert.ToDateTime(dr.GetString(4)) - Convert.ToDateTime(dr.GetString(9));
                    dias = tSpan.Days;
                    horas = tSpan.Hours;
                    minutos = tSpan.Minutes;
                    total = Convert.ToString(horas) + "." + Convert.ToString(Math.Abs(minutos) );
                    diftotal = Convert.ToDouble(total);

                    if (diftotal >= 0)
                    {
                        dgvDatos.Rows[contirow].Cells[10].Style.ForeColor = System.Drawing.Color.Green; 
                        dgvDatos.Rows[contirow].Cells[10].Value = "EN HORA";
                    }

                    else
                    {
                        dgvDatos.Rows[contirow].Cells[10].Style.ForeColor = System.Drawing.Color.Red;
                        dgvDatos.Rows[contirow].Cells[10].Value = "CON DEMORA";
                    }
                    dgvDatos.Rows[contirow].Cells[8].Value = diftotal;

                   }

               


                     

                contirow++;



               
            }
            conectar.Close();




        }


        public void elimino_parada_recorrido(string recorrido, string orden)
        {
                       

            conectar = Conexion.ObtenerConexion();
            cmd = new MySqlCommand("UPDATE recorridos_tarjetas SET Estado = 9 Where Id_Recorrido=" + recorrido + " AND Orden=" + orden , conectar);
            cmd.ExecuteNonQuery();
            conectar.Close();

            MessageBox.Show("Se ha dado de baja la parada seleccionada");

        }


        public void altadeparadacorreccion(string tarjeta , string recorrido, NumericUpDown numec, string lafecha, string hora )
        {
            string fecha, nserie="", idtarjeta="";


                conectar = Conexion.ObtenerConexion();
                cmd = new MySqlCommand("SELECT Nombre_Tarjeta, Numero_Serie, Id_Tarjetas FROM tarjetas WHERE Nombre_Tarjeta='" + tarjeta + "'", conectar);
                dr = cmd.ExecuteReader();

            while (dr.Read())
            {
              nserie = dr.GetString(1);
              idtarjeta= dr.GetString(2);
            }
            conectar.Close(); 

                fecha = Convert.ToDateTime(lafecha).ToString("yyyy-MM-dd") + " " + Convert.ToDateTime(hora).ToString("HH:mm:ss");

                conectar = Conexion.ObtenerConexion();
                cmd = new MySqlCommand("Insert into recorridos_tarjetas(Id_Recorrido, Id_Tarjetas, Orden, Hora, Estado) values(" + recorrido + ", " + idtarjeta + ", " + numec.Value   + ",'" + fecha + "', 1)", conectar);
                cmd.ExecuteNonQuery();
                conectar.Close();
                MessageBox.Show("Se ha dado el alta con exito");


        }


        }

    }
