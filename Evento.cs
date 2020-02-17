using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using Newtonsoft.Json;
using System.Drawing;

using System.Drawing.Printing;
using Gma.QrCodeNet.Encoding;                                                                                                                                                                                                                                            
using Gma.QrCodeNet.Encoding.Windows.Render;
using System.Drawing.Imaging;




namespace ImpresionQR
{


    class Evento
    {

        MySqlCommand cmd, cmd1;
        MySqlDataReader dr;
        MySqlConnection conectar, conectar1;



        public void Genero_Evento(String fecha, TextBox evento, TextBox torneo, TextBox url, TextBox numerofecha, TextBox rival, string id_rival)
        {

            conectar = Conexion.ObtenerConexion();

            cmd = new MySqlCommand("Insert into eventos(Nombre_Evento, Campeonato, Fecha, url, Numero_Fecha, Rival, Id_Rival, Estado, FuenteEvento, SizeEvento, CampeonatoFuente, CampeonatoSize, MedioFuente, MedioSize, FechaNFuente, FechaNSize, RivalNegrita, RivalFuente, RivalSize, NombreNegrita, NombreFuente, NombreSize, UbicacionNegrita, UbicacionFuente, UbicacionSize, CampeonatoNegrita, MedioNegrita, FechaNNegrita) values" +
                                         "('" + evento.Text + "', '" + torneo.Text + "', '" + fecha + "', '" + url.Text + "', '" + numerofecha.Text + "', '" + rival.Text + "', " + id_rival + ", " + "4"  +  ", '" +  "Arial Black" + "', " + "14" + ", '" + "Arial Black" + "', " + "14" + ", '" + "Arial Black" + "', " + "14" + ", '" + "Arial Black" + "', " + "14" + ", 1, '" + "Arial Black" + "', 14" + ",1, '" + "Arial Black" + "', 14" + ",1, '" + "Arial Black" + "', 14" + ", 1,1,1)", conectar);
            cmd.ExecuteNonQuery();
            conectar.Close();

            conectar = Conexion.ObtenerConexion();
            cmd = new MySqlCommand("SELECT Credencial_Moviles, Credencial_Cabinas, Credencial_Pupitres, Credencial_TV FROM setup", conectar);
            dr = cmd.ExecuteReader();
            while (dr.Read())

            {
                if (dr.GetInt32(0) > 999)
                {
                    conectar = Conexion.ObtenerConexion();
                    cmd = new MySqlCommand("UPDATE setup SET Credencial_Moviles = 1", conectar);
                    cmd.ExecuteNonQuery();
                    conectar.Close();
                }

                if (dr.GetInt32(1) > 999)
                {
                    conectar = Conexion.ObtenerConexion();
                    cmd = new MySqlCommand("UPDATE setup SET Credencial_Cabinas = 1", conectar);
                    cmd.ExecuteNonQuery();
                    conectar.Close();
                }

                if (dr.GetInt32(2) > 999)
                {
                    conectar = Conexion.ObtenerConexion();
                    cmd = new MySqlCommand("UPDATE setup SET Credencial_Pupitres = 1", conectar);
                    cmd.ExecuteNonQuery();
                    conectar.Close();
                }

                if (dr.GetInt32(3) > 999)
                {
                    conectar = Conexion.ObtenerConexion();
                    cmd = new MySqlCommand("UPDATE setup SET Credencial_TV = 1", conectar);
                    cmd.ExecuteNonQuery();
                    conectar.Close();
                }

                conectar = Conexion.ObtenerConexion();
                cmd = new MySqlCommand("UPDATE setup SET Desc_Evento = '" + evento.Text + "'", conectar);
                cmd.ExecuteNonQuery();
                conectar.Close();


            }
            dr.Close();

            conectar.Close();

            MessageBox.Show("Se Cargó el Evento Correctamente");




        }


        public void Traigo_Datos_Evento(TextBox torneo, TextBox evento, TextBox url, TextBox txtfechanumero, Label Id_evento, TextBox fecha, TextBox txtIdRival, Label estado_evento)
        {



            conectar = Conexion.ObtenerConexion();
            //cmd = new MySqlCommand("SELECT nombre_evento, campeonato, url, Numero_Fecha, Id_Evento, Fecha, Id_Rival FROM eventos ORDER BY Id_Evento DESC LIMIT 1", conectar);
            cmd = new MySqlCommand("SELECT nombre_evento, campeonato, url, Numero_Fecha, Id_Evento, Fecha, Id_Rival, Estado, FuenteEvento, SizeEvento FROM eventos WHERE Id_evento=" + Id_evento.Text , conectar);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                evento.Text = dr.GetString(0);
                torneo.Text = dr.GetString(1);
                url.Text = dr.GetString(2);
                txtfechanumero.Text = "Nº " + dr.GetString(3);
                Id_evento.Text = dr.GetString(4);
                DateTime mihora = Convert.ToDateTime(dr.GetString(5));
                fecha.Text = mihora.ToString("yyyy-MM-dd");
                txtIdRival.Text = dr.GetString(6);
                estado_evento.Text = dr.GetString(7);
                FrmLogin.nomfuente= dr.GetString(8);
                FrmLogin.sizefuente = Convert.ToInt16(dr.GetString(9));

            }
            dr.Close();

            conectar.Close();



        }






        public void Busco_Dato_Evento(TextBox torneo, TextBox fecnumero, TextBox url, string criterio, TextBox idevento, TextBox idrival)
        {

            conectar = Conexion.ObtenerConexion();
            cmd = new MySqlCommand(criterio, conectar);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                torneo.Text = dr.GetString(2);
                url.Text = dr.GetString(4);
                fecnumero.Text = dr.GetString(3);
                idevento.Text = dr.GetString(0);
                idrival.Text = dr.GetString(5);


            }
            dr.Close();

            conectar.Close();



        }

        public int traigo_numero_evento()

        {
            int ultimo_evento = 0;

            conectar = Conexion.ObtenerConexion();
            cmd = new MySqlCommand("SELECT MAX(Id_Evento)  FROM eventos", conectar);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ultimo_evento = dr.GetInt32(0);
            }
            dr.Close();

            conectar.Close();

            return ultimo_evento;
        }

        public int traigo_ultimo_Id()

        {
            int ultima_impresion = 0;

            conectar = Conexion.ObtenerConexion();
            cmd = new MySqlCommand("SELECT MAX(Id_Impresiones)  FROM impresiones", conectar);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ultima_impresion = dr.GetInt32(0);
            }
            dr.Close();

            conectar.Close();

            return ultima_impresion;
        }


        public void Traigo_Numeros_Credenciales(Label cabinas, Label pupitre12, Label movil, Label TV)
        {

            conectar = Conexion.ObtenerConexion();
            cmd = new MySqlCommand("SELECT Credencial_Cabinas, Credencial_Pupitres, Credencial_Moviles, Credencial_TV  FROM setup", conectar);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cabinas.Text = Convert.ToString(dr.GetInt32(0)).PadLeft(3, '0');
                pupitre12.Text = Convert.ToString(dr.GetInt32(1)).PadLeft(3, '0');
                movil.Text = Convert.ToString(dr.GetInt32(2)).PadLeft(3, '0');
                TV.Text = Convert.ToString(dr.GetInt32(3)).PadLeft(3, '0');



            }
            dr.Close();

            conectar.Close();



        }



        public void Traigo_Numeros_Credenciales_Anuales(Label cabinas, Label pupitre12, Label movil, Label TV)
        {

            conectar = Conexion.ObtenerConexion();
            cmd = new MySqlCommand("SELECT Credencial_Anual_Cabinas, Credencial_Anual_Pupitres, Credencial_Anual_Moviles, Credencial_Anual_TV  FROM setup", conectar);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cabinas.Text = Convert.ToString(dr.GetInt32(0)).PadLeft(3, '0');
                pupitre12.Text = Convert.ToString(dr.GetInt32(1)).PadLeft(3, '0');
                movil.Text = Convert.ToString(dr.GetInt32(2)).PadLeft(3, '0');
                TV.Text = Convert.ToString(dr.GetInt32(3)).PadLeft(3, '0');



            }
            dr.Close();

            conectar.Close();



        }



        public void llenarcombotipo(ComboBox cb, string criterio)

        {


            try
            {

                conectar = Conexion.ObtenerConexion();

                string query = criterio;
                MySqlCommand cmd = new MySqlCommand(query, conectar);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cb.ValueMember = "Id_Tipo";
                cb.DisplayMember = "Descripcion_Tipo";
                cb.DataSource = dt;
                conectar.Close();




            }
            catch (Exception ex)
            {
                MessageBox.Show("No se lleno el Combo: " + ex.ToString());


            }



        }



        public void llenarcomboeventos(ComboBox cb, string criterio)

        {


            try
            {

                conectar = Conexion.ObtenerConexion();

                string query = criterio;

                MySqlCommand cmd = new MySqlCommand(query, conectar);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cb.ValueMember = "Id_Evento";
                cb.DisplayMember = "Nombre_Evento";


                cb.DataSource = dt;
                conectar.Close();



            }
            catch (Exception ex)
            {
                MessageBox.Show("No se lleno el Combo: " + ex.ToString());


            }



        }

        public void Traigo_Consulta_Eventos(DataGridView dgvDatos, string criterio, int tipo)

        {

            int contirow = 0;

            conectar = Conexion.ObtenerConexion();
            cmd = new MySqlCommand(criterio, conectar);
            dr = cmd.ExecuteReader();

            try
            {

                if (tipo == 1)

                {


                    while (dr.Read())
                    {
                        dgvDatos.Rows.Add();
                        dgvDatos.Rows[contirow].Cells[2].Value = dr.GetString(2);
                        dgvDatos.Rows[contirow].Cells[3].Value = dr.GetString(3);
                        dgvDatos.Rows[contirow].Cells[4].Value = dr.GetString(8);
                        dgvDatos.Rows[contirow].Cells[5].Value = dr.GetString(4);
                        dgvDatos.Rows[contirow].Cells[6].Value = dr.GetString(5);
                        dgvDatos.Rows[contirow].Cells[7].Value = dr.GetString(6);
                        dgvDatos.Rows[contirow].Cells[8].Value = dr.GetString(7);
                        dgvDatos.Rows[contirow].Cells[9].Value = dr.GetString(12);
                        dgvDatos.Rows[contirow].Cells[10].Value = dr.GetString(0);
                        dgvDatos.Rows[contirow].Cells[11].Value = dr.GetString(13);

                        contirow++;

                    }

                }


                if (tipo == 2)

                {


                    while (dr.Read())
                    {
                        dgvDatos.Rows.Add();
                        dgvDatos.Rows[contirow].Cells[2].Value = dr.GetString(2);
                        dgvDatos.Rows[contirow].Cells[3].Value = dr.GetString(3);
                        dgvDatos.Rows[contirow].Cells[4].Value = dr.GetString(8);
                        dgvDatos.Rows[contirow].Cells[5].Value = dr.GetString(9);
                        dgvDatos.Rows[contirow].Cells[6].Value = dr.GetString(4);
                        dgvDatos.Rows[contirow].Cells[7].Value = dr.GetString(5);
                        dgvDatos.Rows[contirow].Cells[8].Value = dr.GetString(6);
                        dgvDatos.Rows[contirow].Cells[9].Value = dr.GetString(7);
                        dgvDatos.Rows[contirow].Cells[10].Value = dr.GetString(13);
                        dgvDatos.Rows[contirow].Cells[11].Value = dr.GetString(0);
                        dgvDatos.Rows[contirow].Cells[12].Value = dr.GetString(14);


                        contirow++;

                    }

                }



                if (tipo == 3)

                {


                    while (dr.Read())
                    {
                        dgvDatos.Rows.Add();
                        dgvDatos.Rows[contirow].Cells[2].Value = dr.GetString(2);
                        dgvDatos.Rows[contirow].Cells[3].Value = dr.GetString(3);
                        dgvDatos.Rows[contirow].Cells[4].Value = dr.GetString(4);
                        dgvDatos.Rows[contirow].Cells[5].Value = dr.GetString(5);
                        dgvDatos.Rows[contirow].Cells[6].Value = dr.GetString(6);
                        dgvDatos.Rows[contirow].Cells[7].Value = dr.GetString(7);
                        dgvDatos.Rows[contirow].Cells[8].Value = dr.GetString(11);
                        dgvDatos.Rows[contirow].Cells[9].Value = dr.GetString(0);
                        dgvDatos.Rows[contirow].Cells[10].Value = dr.GetString(12);

                        contirow++;

                    }

                }

                if (tipo == 4)

                {


                    while (dr.Read())
                    {
                        dgvDatos.Rows.Add();
                        dgvDatos.Rows[contirow].Cells[2].Value = dr.GetString(2);
                        dgvDatos.Rows[contirow].Cells[3].Value = dr.GetString(3);
                        dgvDatos.Rows[contirow].Cells[4].Value = dr.GetString(4);
                        dgvDatos.Rows[contirow].Cells[5].Value = dr.GetString(5);
                        dgvDatos.Rows[contirow].Cells[6].Value = dr.GetString(6);
                        dgvDatos.Rows[contirow].Cells[7].Value = dr.GetString(7);
                        dgvDatos.Rows[contirow].Cells[8].Value = dr.GetString(11);
                        dgvDatos.Rows[contirow].Cells[9].Value = dr.GetString(0);
                        dgvDatos.Rows[contirow].Cells[10].Value = dr.GetString(12);

                        contirow++;

                    }

                }
                conectar.Close();




            }
            catch (Exception ex)

            {
                MessageBox.Show("No se encontro la Tabla: " + ex.ToString());
            }







        }

        public void Busco_Impresos_Pupitres(string fecha, Button boton)

        {
            string criterio;
            string fila;
            string asiento, nombreboton;

            try
            {
                conectar = Conexion.ObtenerConexion();
                nombreboton = boton.Name;
                fila = nombreboton.Substring(1, 1);
                asiento = nombreboton.Substring(3, 2);
                criterio = "SELECT * FROM impresiones WHERE Fecha='" + fecha + "' AND Fila=" + fila + " AND Asiento=" + asiento;
                cmd = new MySqlCommand(criterio, conectar);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    boton.BackColor = System.Drawing.Color.Orange;
                    FrmLogin.total_pupitres_impresos++;

                }
                conectar.Close();


            }
            catch (Exception ex)

            {
                MessageBox.Show("No se encontro la Tabla: " + ex.ToString());
            }



        }







        public void Busco_Impresos_Cabinas(string fecha, Button boton)

        {
            string criterio;
            string cabina;
            string nombreboton;

            try
            {
                conectar = Conexion.ObtenerConexion();
                nombreboton = boton.Name;
                cabina = nombreboton.Substring(1, 2);

                criterio = "SELECT * FROM impresiones WHERE Fecha='" + fecha + "' AND Cabina=" + cabina;
                cmd = new MySqlCommand(criterio, conectar);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    boton.BackColor = System.Drawing.Color.Orange;
                    FrmLogin.total_cabinas_impresas++;


                }
                conectar.Close();


            }
            catch (Exception ex)

            {
                MessageBox.Show("No se encontro la Tabla: " + ex.ToString());
            }



        }

        public void Busco_Lecturas_Pupitres(string fecha, Button boton)

        {
            string criterio;
            string fila;
            string asiento, nombreboton;

            try
            {
                conectar = Conexion.ObtenerConexion();
                nombreboton = boton.Name;
                fila = nombreboton.Substring(1, 1);
                asiento = nombreboton.Substring(3, 2);
                criterio = "SELECT * FROM lecturas WHERE Fecha='" + fecha + "' AND Fila=" + fila + " AND Asiento=" + asiento;
                cmd = new MySqlCommand(criterio, conectar);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    boton.BackColor = System.Drawing.Color.Green ;
                    FrmLogin.total_pupitres_entrantes++;

                } else
                {
                   // boton.BackColor = System.Drawing.Color.Red ;

                }

                conectar.Close();


            }
            catch (Exception ex)

            {
                MessageBox.Show("No se encontro la Tabla: " + ex.ToString());
            }



        }

        public void Busco_Lecturas_Cabinas(string fecha, Button boton)

        {
            string criterio;
            string cabina;
            string nombreboton;

            try
            {
                conectar = Conexion.ObtenerConexion();
                nombreboton = boton.Name;
                cabina = nombreboton.Substring(1, 2);

                criterio = "SELECT * FROM lecturas WHERE Fecha='" + fecha + "' AND Cabina=" + cabina;
                cmd = new MySqlCommand(criterio, conectar);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    boton.BackColor = System.Drawing.Color.Green;
                    FrmLogin.total_cabinas_entrantes++;

                } else
                {
                    //boton.BackColor = System.Drawing.Color.Red;

                }
                conectar.Close();


            }
            catch (Exception ex)

            {
                MessageBox.Show("No se encontro la Tabla: " + ex.ToString());
            }



        }



        public void Limpio(Button boton)

        {

            boton.BackColor = System.Drawing.Color.White;

        }


        public void Limpio_Rojo(Button boton, string fecha, int tipo)

        {
            string criterio = "";
            int asiento = 0, cabina = 0, fila = 0;
            conectar = Conexion.ObtenerConexion();
            if (tipo == 1)
            {
                cabina = Convert.ToInt32(boton.Name.Substring(1, 2));
                criterio = "SELECT Id_Impresiones, Torneo, Evento, Medio, Cantidad, Nombre, DNI, Credencial, Asiento, Fila, Cabina, Fecha, Tipo, Id_Evento, Estado FROM impresiones WHERE Fecha='" + fecha + "' AND Cabina = " + cabina;
            }

            if (tipo == 2)
            {
                fila = Convert.ToInt32(boton.Name.Substring(1, 1));
                asiento = Convert.ToInt32(boton.Name.Substring(3, 2));
                criterio = "SELECT Id_Impresiones, Torneo, Evento, Medio, Cantidad, Nombre, DNI, Credencial, Asiento, Fila, Cabina, Fecha, Tipo, Id_Evento, Estado FROM impresiones WHERE Fecha='" + fecha + "' AND Fila =" + fila + " AND Asiento=" + asiento;
            }



            cmd = new MySqlCommand(criterio, conectar);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                boton.BackColor = System.Drawing.Color.Red;
                FrmLogin.total_pupitres_faltantes++;

            }

            conectar.Close();


        }



        public string Busco_Presentes(string Id_Impresiones)
        {
            string criterio = "", asiento = "";


            conectar = Conexion.ObtenerConexion();
            criterio = "SELECT Id_Impresiones, Torneo, Evento, Medio, Cantidad, Nombre, DNI, Credencial, Asiento, Fila, Cabina, Fecha, Tipo, Id_Evento, Estado FROM impresiones WHERE Id_Impresiones=" + Id_Impresiones;
            cmd = new MySqlCommand(criterio, conectar);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (dr.GetInt32(12) == 1)
                {
                    asiento = "C" + Convert.ToString(dr.GetInt32(10)).PadLeft(2, '0');
                    FrmLogin.total_cabinas_entrantes++;

                }

                if (dr.GetInt32(12) == 2)
                {
                    asiento = "F" + Convert.ToString(dr.GetInt32(9)) + "A" + Convert.ToString(dr.GetInt32(8)).PadLeft(2, '0');
                    FrmLogin.total_pupitres_entrantes++;


                }


            }
            conectar.Close();

            return asiento;


        }



        public void Traigo_Datos_Lugar(string boton, string fdesde, int tipo, TextBox txtevento, TextBox txttorneo, TextBox txtmedio, TextBox txtnombre, TextBox txtdni, TextBox txttipo, TextBox txtcabina, TextBox txtfila, TextBox txtasiento, string url, DataGridView dgvDatos)
        {

            int cabina = 0, fila = 0, asiento = 0, contirow=0;
            string criterio = "";

            conectar = Conexion.ObtenerConexion();
            if (tipo == 1)
            {
                cabina = Convert.ToInt32(boton.Substring(1, 2));
                criterio = "SELECT a.Id_Impresiones, a.Torneo, a.Evento, a.Medio, a.Cantidad, a.Nombre, a.DNI, a.Credencial, a.Asiento, a.Fila, a.Cabina, a.Fecha, a.Tipo, a.Id_Evento, a.Estado, b.Descripcion_Tipo FROM impresiones AS a INNER JOIN tipos AS b ON a.Tipo=b.Id_Tipo WHERE Fecha='" + fdesde + "' AND Cabina = " + cabina;
            }

            if (tipo == 2)
            {
                fila = Convert.ToInt32(boton.Substring(1, 1));
                asiento = Convert.ToInt32(boton.Substring(3, 2));
                criterio = "SELECT a.Id_Impresiones, a.Torneo, a.Evento, a.Medio, a.Cantidad, a.Nombre, a.DNI, a.Credencial, a.Asiento, a.Fila, a.Cabina, a.Fecha, a.Tipo, a.Id_Evento, a.Estado , b.Descripcion_Tipo FROM impresiones AS a INNER JOIN tipos AS b ON a.Tipo=b.Id_Tipo WHERE Fecha='" + fdesde + "' AND Fila =" + fila + " AND Asiento=" + asiento;
            }

            cmd = new MySqlCommand(criterio, conectar);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                txtevento.Text = dr.GetString(2);
                txttorneo.Text = dr.GetString(1);
                txtmedio.Text = dr.GetString(3);
                txtnombre.Text = dr.GetString(5);
                txtdni.Text = dr.GetString(6);
                txttipo.Text = dr.GetString(15);
                if (tipo == 1)
                {
                    txtasiento.Visible = false;
                    txtfila.Visible = false;
                    txtcabina.Visible = true;
                    txtcabina.Text = "Nº " + dr.GetString(10);
                }

                if (tipo == 2)
                {
                    txtasiento.Visible = true;
                    txtfila.Visible = true;
                    txtcabina.Visible = false;
                    txtfila.Text = "FILA Nº " + dr.GetString(9);
                    txtasiento.Text = "ASIENTO Nº " + dr.GetString(8);
                }




            }
            dr.Close();

            conectar.Close();


            conectar = Conexion.ObtenerConexion();
            cmd = new MySqlCommand("SELECT Fecha, Sector,Hora, Medio, Cabina, Fila, Asiento FROM lecturas  WHERE Medio='" + txtmedio.Text + "' AND Evento='" + txtevento.Text + "'  ORDER BY Hora", conectar);
            dr = cmd.ExecuteReader();

            while (dr.Read())

            {
                dgvDatos.Rows.Add();
                dgvDatos.Rows[contirow].Cells[3].Value = Convert.ToString(dr.GetString(0));
                dgvDatos.Rows[contirow].Cells[1].Value = Convert.ToString(dr.GetString(1));
                dgvDatos.Rows[contirow].Cells[2].Value = Convert.ToString(dr.GetString(2));
                dgvDatos.Rows[contirow].Cells[4].Value = Convert.ToString(dr.GetString(3));
                dgvDatos.Rows[contirow].Cells[5].Value = Convert.ToString(dr.GetString(4));
                dgvDatos.Rows[contirow].Cells[6].Value = Convert.ToString(dr.GetString(5));
                

                contirow++;



            }
            conectar.Close();









        }


        public void Busco_Comentario(string criterio, TextBox comentario)
        {

            conectar = Conexion.ObtenerConexion();
            cmd = new MySqlCommand(criterio, conectar);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comentario.Text = dr.GetString(0);
            }
            dr.Close();

            conectar.Close();



        }

        public void Guardo_Comentario(TextBox comentario, string evento)
        {

            conectar = Conexion.ObtenerConexion();

            cmd = new MySqlCommand("UPDATE eventos SET Comentarios ='" + comentario.Text + "' WHERE Id_Evento=" + evento, conectar);
            cmd.ExecuteNonQuery();
            conectar.Close();
            MessageBox.Show("Se guardaron los Comentarios");


        }


        public void Modifico_Cabinas(DataGridView dgvDatos)
        {
            string id_impre = "", cabina = "";
            int cantidad = 0;

            foreach (DataGridViewRow row in dgvDatos.Rows)
            {

                id_impre = Convert.ToString(row.Cells[10].Value);
                cabina = Convert.ToString(row.Cells[4].Value);
                cantidad = Convert.ToInt32(row.Cells[5].Value);




                if (cantidad != 0)
                {
                    conectar = Conexion.ObtenerConexion();

                    cmd = new MySqlCommand("UPDATE impresiones SET Cabina ='" + cabina + "', Cantidad=" + cantidad + " WHERE Id_Impresiones=" + id_impre, conectar);
                    cmd.ExecuteNonQuery();
                    conectar.Close();
                }

            }

            MessageBox.Show("Se Modificaron los Datos Correctamente");


        }



        public void Modifico_Moviles(DataGridView dgvDatos)
        {
            string id_impre = "";
            int cantidad = 0;

            foreach (DataGridViewRow row in dgvDatos.Rows)
            {

                id_impre = Convert.ToString(row.Cells[9].Value);
                cantidad = Convert.ToInt32(row.Cells[4].Value);




                if (cantidad != 0)
                {
                    conectar = Conexion.ObtenerConexion();

                    cmd = new MySqlCommand("UPDATE impresiones SET Cantidad=" + cantidad + " WHERE Id_Impresiones=" + id_impre, conectar);
                    cmd.ExecuteNonQuery();
                    conectar.Close();
                }

            }

            MessageBox.Show("Se Modificaron los Datos Correctamente");


        }



        public void Modifico_Pupitre(DataGridView dgvDatos)
        {
            string id_impre = "", fila = "", asiento = "";
            int cantidad = 0;

            foreach (DataGridViewRow row in dgvDatos.Rows)
            {

                id_impre = Convert.ToString(row.Cells[11].Value);
                fila = Convert.ToString(row.Cells[4].Value);
                asiento = Convert.ToString(row.Cells[5].Value);
                cantidad = Convert.ToInt32(row.Cells[6].Value);




                if (cantidad != 0)
                {
                    conectar = Conexion.ObtenerConexion();

                    cmd = new MySqlCommand("UPDATE impresiones SET Asiento ='" + asiento + "', Cantidad=" + cantidad + ", Fila='" + fila + "' WHERE Id_Impresiones=" + id_impre, conectar);
                    cmd.ExecuteNonQuery();
                    conectar.Close();
                }

            }

            MessageBox.Show("Se Modificaron los Datos Correctamente");


        }



        public void Modifico_TV(DataGridView dgvDatos)
        {
            string id_impre = "";
            int cantidad = 0;

            foreach (DataGridViewRow row in dgvDatos.Rows)
            {

                id_impre = Convert.ToString(row.Cells[9].Value);
                cantidad = Convert.ToInt32(row.Cells[4].Value);




                if (cantidad != 0)
                {
                    conectar = Conexion.ObtenerConexion();

                    cmd = new MySqlCommand("UPDATE impresiones SET Cantidad=" + cantidad + " WHERE Id_Impresiones=" + id_impre, conectar);
                    cmd.ExecuteNonQuery();
                    conectar.Close();
                }

                MessageBox.Show("Se Modificaron los Datos Correctamente");

            }


        }


        public int buscarcredenciallibre(int credencial, int tipo)

        {

            string criterio = "";
            int nrocred = 1;

            conectar = Conexion.ObtenerConexion();
            criterio = "SELECT Tipo, Numero  FROM excepciones WHERE Tipo=" + tipo + " AND Numero=" + credencial;
            cmd = new MySqlCommand(criterio, conectar);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                nrocred = 2;


            }
            dr.Close();
            conectar.Close();
            return nrocred;
        }



        public void Bajo_Cabinas(DataGridView dgvDatos)
        {
            string id_impre = "";

            foreach (DataGridViewRow row in dgvDatos.Rows)
            {

                if (Convert.ToBoolean(row.Cells[0].Value) == true)

                {
                    id_impre = Convert.ToString(row.Cells[10].Value);

                    conectar = Conexion.ObtenerConexion();
                    cmd = new MySqlCommand("UPDATE impresiones SET Estado =9 WHERE Id_Impresiones=" + id_impre, conectar);
                    cmd.ExecuteNonQuery();
                    conectar.Close();
                }

            }


            MessageBox.Show("Se Dieron de Baja los Datos Correctamente");


        }



        public void Bajo_Pupitres(DataGridView dgvDatos)
        {
            string id_impre = "";

            foreach (DataGridViewRow row in dgvDatos.Rows)
            {

                if (Convert.ToBoolean(row.Cells[0].Value) == true)

                {
                    id_impre = Convert.ToString(row.Cells[11].Value);

                    conectar = Conexion.ObtenerConexion();
                    cmd = new MySqlCommand("UPDATE impresiones SET Estado =9 WHERE Id_Impresiones=" + id_impre, conectar);
                    cmd.ExecuteNonQuery();
                    conectar.Close();
                }

            }


            MessageBox.Show("Se Dieron de Baja los Datos Correctamente");


        }

        public void Bajo_Moviles(DataGridView dgvDatos)
        {
            string id_impre = "";

            foreach (DataGridViewRow row in dgvDatos.Rows)
            {

                if (Convert.ToBoolean(row.Cells[0].Value) == true)

                {
                    id_impre = Convert.ToString(row.Cells[9].Value);

                    conectar = Conexion.ObtenerConexion();
                    cmd = new MySqlCommand("UPDATE impresiones SET Estado =9 WHERE Id_Impresiones=" + id_impre, conectar);
                    cmd.ExecuteNonQuery();
                    conectar.Close();
                }

            }


            MessageBox.Show("Se Dieron de Baja los Datos Correctamente");


        }
        public void Bajo_TV(DataGridView dgvDatos)
        {
            string id_impre = "";

            foreach (DataGridViewRow row in dgvDatos.Rows)
            {

                if (Convert.ToBoolean(row.Cells[0].Value) == true)

                {
                    id_impre = Convert.ToString(row.Cells[9].Value);

                    conectar = Conexion.ObtenerConexion();
                    cmd = new MySqlCommand("UPDATE impresiones SET Estado = 9 WHERE Id_Impresiones=" + id_impre, conectar);
                    cmd.ExecuteNonQuery();
                    conectar.Close();
                }

            }


            MessageBox.Show("Se Dieron de Baja los Datos Correctamente");


        }

        public void Traigo_Datos_Personas_viejo(DataGridView dgvDatos)
        {

            int contirow = 0;

            dgvDatos.Rows.Clear();
            conectar = Conexion.ObtenerConexion();
            cmd = new MySqlCommand("SELECT Id_Impresiones, Torneo, Evento, Nombre, Apellido, Cargo, Nivel_Acceso, Tipo_Persona ,Id_Evento FROM empleados ORDER BY Apellido, Nombre", conectar);
            dr = cmd.ExecuteReader();
            dgvDatos.Rows.Add();



            while (dr.Read())

            {

                dgvDatos.Rows[contirow].Cells[1].Value = dr.GetString(1);
                dgvDatos.Rows[contirow].Cells[2].Value = dr.GetString(2);
                dgvDatos.Rows[contirow].Cells[4].Value = dr.GetString(3);
                dgvDatos.Rows[contirow].Cells[3].Value = dr.GetString(4);
                dgvDatos.Rows[contirow].Cells[5].Value = dr.GetString(5);
                dgvDatos.Rows[contirow].Cells[6].Value = dr.GetString(6);
                dgvDatos.Rows[contirow].Cells[7].Value = dr.GetString(7);
                dgvDatos.Rows[contirow].Cells[8].Value = dr.GetString(0);

                dgvDatos.Rows.Add();


                contirow++;


            }


            conectar.Close();

        }





        public int Traigo_Datos_Personas(DataGridView dgvDatos, string evento)
        {

            int contirow = 0, encontro = 2;

            dgvDatos.Rows.Clear();
            conectar = Conexion.ObtenerConexion();
            cmd = new MySqlCommand("SELECT b.Id_Impresiones, b.Torneo, b.Evento, b.Nombre, b.Apellido, b.Cargo, b.Nivel_Acceso, b.Tipo_Persona , a.Id_Evento, a.Id_Empleado, b.DNI, b.Empresa FROM eventos_empleados As a INNER JOIN empleados AS b ON a.Id_Empleado = b.Id_Impresiones WHERE a.Id_Evento=" + evento + "  ORDER BY b.Apellido, b.Nombre", conectar);
            dr = cmd.ExecuteReader();
            dgvDatos.Rows.Add();



            while (dr.Read())

            {
                encontro = 1;
                dgvDatos.Rows[contirow].Cells[1].Value = dr.GetString(1);
                dgvDatos.Rows[contirow].Cells[2].Value = dr.GetString(2);
                dgvDatos.Rows[contirow].Cells[4].Value = dr.GetString(3);
                dgvDatos.Rows[contirow].Cells[3].Value = dr.GetString(4);
                dgvDatos.Rows[contirow].Cells[5].Value = dr.GetString(5);
                dgvDatos.Rows[contirow].Cells[6].Value = dr.GetString(6);
                dgvDatos.Rows[contirow].Cells[7].Value = dr.GetString(7);
                dgvDatos.Rows[contirow].Cells[8].Value = dr.GetString(0);
                dgvDatos.Rows[contirow].Cells[9].Value = dr.GetString(10);
                dgvDatos.Rows[contirow].Cells[10].Value = dr.GetString(11);

                dgvDatos.Rows.Add();


                contirow++;


            }


            conectar.Close();
            return encontro;
        }

        public void Guardo_personas_Evento(DataGridView dgvCabinas, Label evento, TextBox fecha)
        {
            
            string empleado = "";

            // DateTime mihora = DateTime.Now;
            // string lahora = mihora.ToString("yyyy-MM-dd");



            conectar = Conexion.ObtenerConexion();



            foreach (DataGridViewRow row in dgvCabinas.Rows)
            {

                if (Convert.ToBoolean(row.Cells[0].Value) == true)

                {
                    empleado = Convert.ToString(row.Cells[8].Value);
                    cmd = new MySqlCommand("SELECT COUNT(Id_evento) FROM eventos_empleados WHERE Id_Evento=" + evento.Text + " AND Id_Empleado=" + empleado, conectar);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {


                        if (dr.GetInt32(0) == 0)
                        {
                            conectar1 = Conexion.ObtenerConexion();
                            cmd1 = new MySqlCommand("Insert into eventos_empleados(Id_Evento, Id_Empleado, Fecha) values(" + evento.Text + ", " + empleado + ", '" + fecha.Text + "')", conectar1);
                            cmd1.ExecuteNonQuery();
                            conectar1.Close();
                        }



                    }
                    dr.Close();

                }

            }

            MessageBox.Show("Finalizo la Captura de Datos");
        }


        public void Traigo_Datos_Cartera(DataGridView dgvDatos, string criterio)
        {

            int contirow = 0;

            dgvDatos.Rows.Clear();
            conectar = Conexion.ObtenerConexion();
            cmd = new MySqlCommand(criterio, conectar);
            dr = cmd.ExecuteReader();
            dgvDatos.Rows.Add();



            while (dr.Read())

            {

                dgvDatos.Rows[contirow].Cells[1].Value = dr.GetString(1);
                dgvDatos.Rows[contirow].Cells[2].Value = dr.GetString(2);
                dgvDatos.Rows[contirow].Cells[4].Value = dr.GetString(3);
                dgvDatos.Rows[contirow].Cells[3].Value = dr.GetString(4);
                dgvDatos.Rows[contirow].Cells[5].Value = dr.GetString(5);
                dgvDatos.Rows[contirow].Cells[6].Value = dr.GetString(6);
                dgvDatos.Rows[contirow].Cells[7].Value = dr.GetString(7);
                dgvDatos.Rows[contirow].Cells[8].Value = dr.GetString(0);
                dgvDatos.Rows[contirow].Cells[9].Value = dr.GetString(8);
                dgvDatos.Rows[contirow].Cells[10].Value = dr.GetString(9);


                dgvDatos.Rows.Add();


                contirow++;


            }


            conectar.Close();

        }

        public void Cargo_Altas_Manuales_Seguridad(String txttorneo, String txtRival, String txtFecha, String txtFechaPartido, String txtNombre, String txtApellido, String txtcargo, String cbnivelacceso, String  cbtipopersona, string Id_evento, String dni, String empresa  )
        {





             
                    conectar = Conexion.ObtenerConexion();
                    cmd = new MySqlCommand("Insert into empleados(Torneo, Evento, Nombre, Apellido, Cargo, Nivel_Acceso, Tipo_Persona, Estado, usuario, Fecha, Id_Evento, DNI, Empresa) values('" + txttorneo.ToUpper()  + "', '" + txtRival.ToUpper() + "', '" + txtNombre.ToUpper() + "', '" + txtApellido.ToUpper() + "', '" + txtcargo.ToUpper() + "', '" + cbnivelacceso.ToUpper() + "', '" + cbtipopersona.ToUpper() + "', 1, '" + FrmLogin.usu + "', '" + txtFecha + "', " + Id_evento +  ", '" + dni + "', '" + empresa.ToUpper()  + "')", conectar);
                    cmd.ExecuteNonQuery();
                                


          

            MessageBox.Show("Se cargaron los Datos Correctamente");
        }

        public int CantRegImp(DataGridView dgvDatos)

        {
            int cant = 0;

            foreach (DataGridViewRow row in dgvDatos.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value) == true)

                {
                    if (FrmPrincipal.cabina == 1)
                        cant = cant + Convert.ToInt32(row.Cells[5].Value);

                    if (FrmPrincipal.pupitre == 1)
                        cant = cant + Convert.ToInt32(row.Cells[6].Value);

                    if (FrmPrincipal.pupitre34 == 1)
                        cant = cant + Convert.ToInt32(row.Cells[6].Value);

                    if (FrmPrincipal.pupitre567 == 1)
                        cant = cant + Convert.ToInt32(row.Cells[6].Value);

                    if (FrmPrincipal.movil == 1)
                        cant = cant + Convert.ToInt32(row.Cells[4].Value);

                    if (FrmPrincipal.TV == 1)
                        cant = cant + Convert.ToInt32(row.Cells[4].Value);

                }


            }

                    return cant;
        }


        public void Cerrar_Evento(String evento)
        {

            conectar = Conexion.ObtenerConexion();
                     
            cmd = new MySqlCommand("UPDATE eventos SET estado = 5  WHERE Id_Evento=" + evento, conectar);
            cmd.ExecuteNonQuery();
                     
            
            conectar.Close();

            MessageBox.Show("Se ha cerrado el Evento Correctamente");




        }


        public void ReAbro_Evento(String evento)
        {

            conectar = Conexion.ObtenerConexion();

            cmd = new MySqlCommand("UPDATE eventos SET estado = 4 WHERE Id_Evento=" + evento , conectar);
            cmd.ExecuteNonQuery();


            conectar.Close();

            MessageBox.Show("Se ha abierto nuevamente el Evento Seleccionado");




        }




        public void Traigo_Desde_Hasta_Credenciales()
        {

            

            
            conectar = Conexion.ObtenerConexion();
            cmd = new MySqlCommand("SELECT Credencial_Desde, Credencial_Hasta, Credencial_Anual_Desde, Credencial_Anual_Hasta  FROM setup", conectar);
            dr = cmd.ExecuteReader();
         



            while (dr.Read())

            {

                FrmLogin.credencial_desde = Convert.ToInt32(dr.GetString(0));
                FrmLogin.credencial_hasta = Convert.ToInt32(dr.GetString(1));
                FrmLogin.credencial_anual_desde = Convert.ToInt32(dr.GetString(2));
                FrmLogin.credencial_anual_hasta = Convert.ToInt32(dr.GetString(3));
                
            }


            conectar.Close();

        }


        public void alta_medios(string txtnombre, string txtletra)
        {


            conectar = Conexion.ObtenerConexion();
            cmd = new MySqlCommand("Insert into medios(Nombre_Medio, Letras) values('" + txtnombre + "', '" + txtletra + "')", conectar);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Se ha cargado un nuevo Medio con exito");

        }

        public void traigo_datos_medios(DataGridView dgvDatos, string criterio)

        {
            int contirow = 0;

            dgvDatos.Rows.Clear();

            conectar = Conexion.ObtenerConexion();
            cmd = new MySqlCommand(criterio , conectar);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                dgvDatos.Rows.Add();
                dgvDatos.Rows[contirow].Cells[0].Value = dr.GetString(0);
                dgvDatos.Rows[contirow].Cells[1].Value = dr.GetString(1);
                dgvDatos.Rows[contirow].Cells[2].Value = dr.GetString(2);



                contirow++;

            }
            dr.Close();
        }



        public void actualizo_medios(DataGridView dgvDatos)
        {

            string letras = "";
            int medio = 0;
            {

                foreach (DataGridViewRow row in dgvDatos.Rows)
                {

                    medio = (Convert.ToInt32(row.Cells[0].Value));
                    letras = Convert.ToString(row.Cells[2].Value);

                    conectar = Conexion.ObtenerConexion();
                    cmd = new MySqlCommand("UPDATE medios SET Letras ='" + letras + "' WHERE Id_Medios=" + medio , conectar);
                    cmd.ExecuteNonQuery();
                    conectar.Close();
                }


                MessageBox.Show("Se guardaron los Comentarios");



            }

        }


        public void cargo_combo_letras(ComboBox cb, string criterio)

        {


            try
            {

                conectar = Conexion.ObtenerConexion();

                string query = criterio;

                MySqlCommand cmd = new MySqlCommand(query, conectar);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cb.ValueMember = "letra";
                cb.DisplayMember = "letra";


                cb.DataSource = dt;
                conectar.Close();



            }
            catch (Exception ex)
            {
                MessageBox.Show("No se lleno el Combo: " + ex.ToString());


            }



        }

        public void Modifico_Evento(string pdesde, string txtrival, string txtIdRival, string IdEvento)
        {

            conectar = Conexion.ObtenerConexion();
            string nombreevento = "RIVER VS " + txtrival;
            cmd = new MySqlCommand("UPDATE eventos SET Fecha ='" + pdesde + "', Id_Rival=" + txtIdRival + ", Rival='" + txtrival + "', Nombre_Evento='" + nombreevento + "'  WHERE Id_Evento=" + IdEvento, conectar);
            cmd.ExecuteNonQuery();


            conectar.Close();

            MessageBox.Show("Se ha Modificado el Evento Correctamente");




        }



        public void Elimino_Evento(string IdEvento)
        {

            conectar = Conexion.ObtenerConexion();
            
            cmd = new MySqlCommand("DELETE from eventos WHERE Id_Evento=" + IdEvento , conectar);
            cmd.ExecuteNonQuery();


            conectar.Close();

            MessageBox.Show("Se ha dado de Baja el Evento");




        }




    }

}
   
   