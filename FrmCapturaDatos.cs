using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace ImpresionQR
{
    public partial class FrmCapturaDatos : Form
    {

       DateTime fecha = DateTime.Now;
       MySqlCommand cmd;
       MySqlConnection conectar;
       MySqlDataReader dr;

        int cargo = 1;
        string txtideventos;


        public FrmCapturaDatos()
        {
            InitializeComponent();
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmPrincipal.cabina = 1;
            FrmPrincipal.pupitre34 = 2;
            FrmPrincipal.pupitre567 = 2;
            FrmPrincipal.pupitre = 2;
            FrmPrincipal.movil = 2;
            FrmPrincipal.TV = 2;

            new Importar().importarExcel(dgvDatos, "Cabinas", button5);
         

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmPrincipal.cabina = 2;
            FrmPrincipal.pupitre34 = 2;
            FrmPrincipal.pupitre567 = 2;
            FrmPrincipal.pupitre = 1;
            FrmPrincipal.movil = 2;
            FrmPrincipal.TV = 2;

            new Importar().importarExcel(dgvDatos, "Fila 1 y 2", button5);
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmPrincipal.cabina = 2;
            FrmPrincipal.pupitre34 = 2;
            FrmPrincipal.pupitre567 = 2;
            FrmPrincipal.pupitre = 2;
            FrmPrincipal.movil = 1;
            FrmPrincipal.TV = 2;

            new Importar().importarExcel(dgvDatos, "Programas Tv", button5);

          

        }

        private void button3_Click(object sender, EventArgs e)
        {

            FrmPrincipal.cabina = 2;
            FrmPrincipal.pupitre34 = 1;
            FrmPrincipal.pupitre567 = 2;
            FrmPrincipal.pupitre = 2;
            FrmPrincipal.movil = 2;
            new Importar().importarExcel(dgvDatos, "Fila 3 y 4", button5);

           

        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {

            Pen blackPen = new Pen(Color.Black, 3);
                        
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

           

            QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);

            //QrCode qrCode1 = new QrCode();
            //qrEncoder.TryEncode(txtCredencial.Text, out qrCode1);

            string cadena = "";
            int cantidad = 0, cantidad_fija=0, tipo=0, numero_evento=0, numero_id=0;
            DateTime mihora = DateTime.Now;
            string lahora = mihora.ToString("yyyy-MM-dd");
            int credencial = 0, buscocredencial=2;


            new Importar().Traigo_Configuracion_Evento(txtideventos);

           


           
                ////// CABINA ////////

                if (FrmPrincipal.cabina == 1)
                {

                    conectar = Conexion.ObtenerConexion();


                    cmd = new MySqlCommand("SELECT Credencial_Cabinas  FROM setup", conectar);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        credencial = dr.GetInt32(0);
                    }
                    dr.Close();

                     while (buscocredencial == 2)
                    {
                        Evento d = new Evento();
                        buscocredencial = d.buscarcredenciallibre(credencial, 1);
                        if (buscocredencial == 2)
                          {
                            credencial++;
                            if (credencial > FrmLogin.credencial_hasta  )
                            {
                                credencial = FrmLogin.credencial_desde  ;
                            }
                        }

                   }





                    foreach (DataGridViewRow row in dgvCabinas.Rows)
                    {

                        if (Convert.ToBoolean(row.Cells[0].Value) == true)

                        {


                            tipo = 1;
                            row.Cells[5].Value = Convert.ToString(Convert.ToInt32(row.Cells[5].Value) - 1);
                            cantidad = Convert.ToInt32(row.Cells[5].Value);
                            cantidad_fija = cantidad + 1;
                            Rectangle rect3 = new Rectangle(320, 230, 290, 70);
                            e.Graphics.DrawRectangle(Pens.White, rect3);

                            //credencial


       //                      Rectangle rect12 = new Rectangle(440, 390, 170, 40);
       //                      e.Graphics.DrawRectangle(Pens.White, rect12);
       //                      e.Graphics.DrawString(Convert.ToString(credencial).PadLeft(3, '0'), new Font("Arial Black", 14), Brushes.Black, rect12, stringFormat);


                            if (imprimiqr.Checked == true)

                            {

                                // Nombre y DNI


                                if (Convert.ToBoolean(row.Cells[9].Value) == true)
                                {
                                    e.Graphics.DrawString(Convert.ToString(row.Cells[6].Value), new Font("Arial Black", 14), Brushes.Black, rect3, stringFormat);
                                    if (Convert.ToString(row.Cells[7].Value) != "")
                                    {
                                        Rectangle rect6 = new Rectangle(320, 260, 290, 60);
                                        e.Graphics.DrawRectangle(Pens.White, rect6);
                                        e.Graphics.DrawString(Convert.ToString(row.Cells[7].Value), new Font("Arial Black", 14), Brushes.Black, rect6, stringFormat);
                                    }
                                    Rectangle rect4 = new Rectangle(320, 290, 290, 40);
                                    e.Graphics.DrawRectangle(Pens.White, rect4);
                                    e.Graphics.DrawString("CABINA Nº " + Convert.ToString(row.Cells[4].Value), new Font("Arial Black", 14), Brushes.Black, rect4, stringFormat);
                                }

                                else
                                {
                                    Rectangle rect4 = new Rectangle(320, 250, 290, 70);
                                    e.Graphics.DrawRectangle(Pens.White, rect4);
                                    e.Graphics.DrawString("CABINA Nº " + Convert.ToString(row.Cells[4].Value), new Font("Arial Black", 14), Brushes.Black, rect4, stringFormat);

                                }
                            } else
                            {
                                // Nombre y DNI

                                Rectangle rect999 = new Rectangle(220, 230, 390, 70);
                                e.Graphics.DrawRectangle(Pens.White, rect999);
                                if (Convert.ToBoolean(row.Cells[9].Value) == true)
                                {
                                    e.Graphics.DrawString(Convert.ToString(row.Cells[6].Value), new Font("Arial Black", 14), Brushes.Black, rect999, stringFormat);
                                    if (Convert.ToString(row.Cells[7].Value) != "")
                                    {
                                        Rectangle rect6 = new Rectangle(220, 260, 390, 60);
                                        e.Graphics.DrawRectangle(Pens.White, rect6);
                                        e.Graphics.DrawString(Convert.ToString(row.Cells[7].Value), new Font("Arial Black", 14), Brushes.Black, rect6, stringFormat);
                                    }
                                    Rectangle rect4 = new Rectangle(220, 290, 390, 40);
                                    e.Graphics.DrawRectangle(Pens.White, rect4);
                                    e.Graphics.DrawString("CABINA Nº " + Convert.ToString(row.Cells[4].Value), new Font("Arial Black", 14), Brushes.Black, rect4, stringFormat);
                                }

                                else
                                {
                                    Rectangle rect4 = new Rectangle(220, 250, 390, 70);
                                    e.Graphics.DrawRectangle(Pens.White, rect4);
                                    e.Graphics.DrawString("CABINA Nº " + Convert.ToString(row.Cells[4].Value), new Font("Arial Black", 14), Brushes.Black, rect4, stringFormat);

                                }

                                
                            }











                            Rectangle rect1 = new Rectangle(220, 90, 390, 45);
                     //       e.Graphics.DrawRectangle(Pens.Black, rect1);

                            e.Graphics.DrawString(Convert.ToString(row.Cells[1].Value) + " " + Convert.ToString(txtfechanumero.Text), new Font("Arial Black", 15), Brushes.Black, rect1, stringFormat);

                            Rectangle rect0 = new Rectangle(220, 140, 390, 45);
                     //       e.Graphics.DrawRectangle(Pens.Black, rect0);
                            e.Graphics.DrawString(Convert.ToString(row.Cells[2].Value), new Font(FrmLogin.nomfuente, FrmLogin.sizefuente), Brushes.Black, rect0, stringFormat);


                            if (imprimiqr.Checked == true)

                            {

                                Char delimiter = '-';
                                int num = 190;
                                String[] substrings = Convert.ToString(row.Cells[3].Value).Split(delimiter);
                                foreach (var substring in substrings)
                                {
                                    Rectangle rect2 = new Rectangle(320, num, 290, 30);
                                    e.Graphics.DrawRectangle(Pens.White, rect2);
                                    e.Graphics.DrawString(substring, new Font("Arial Black", 16), Brushes.Black, rect2, stringFormat);
                                    num = num + 30;
                                }

                            } else
                            {
                                Char delimiter = '-';
                                int num = 190;
                                String[] substrings = Convert.ToString(row.Cells[3].Value).Split(delimiter);
                                foreach (var substring in substrings)
                                {
                                    Rectangle rect2 = new Rectangle(220, num, 390, 30);
                                    e.Graphics.DrawRectangle(Pens.White, rect2);
                                    e.Graphics.DrawString(substring, new Font("Arial Black", 18), Brushes.Black, rect2, stringFormat);
                                    num = num + 30;
                                }
                                
                            }




                            //Rectangle rect5 = new Rectangle(200, 390, 390, 30);
                            // e.Graphics.DrawRectangle(Pens.White, rect5);

                            //    e.Graphics.DrawString(Convert.ToString(row.Cells[2].Value), new Font("Arial Black", 14), Brushes.Black, rect5, stringFormat);
                            //           float x11111 = 200.0F;
                            //          float y11111 = 352.0F;
                            //            float x22222 = 590.0F;
                            //            float y22222 = 352.0F;
                            //    e.Graphics.DrawLine(blackPen, x11111, y11111, x22222, y22222);

                            // Rectangle rect11 = new Rectangle(200, 200, 390, 230);
                            // e.Graphics.DrawRectangle(Pens.Black, rect11);




                            conectar = Conexion.ObtenerConexion();
                            Evento d = new Evento();
                            numero_evento = d.traigo_numero_evento();

                            cmd = new MySqlCommand("Insert into impresiones(Torneo, Evento, Medio, Cantidad, Nombre, DNI, Credencial, Asiento, Fila, Cabina, Fecha, Tipo, Id_Evento, Estado, Usuario) values('" + row.Cells[1].Value + "', '" + row.Cells[2].Value + "', '" + row.Cells[3].Value + "', '" + cantidad_fija + "', '" + row.Cells[6].Value + "', '" + row.Cells[7].Value + "', '" + credencial + "', " + 0 + ", " + 0 + ", " + row.Cells[4].Value + ", '" + txtFecha.Text + "', " + tipo + ", " + numero_evento + ", 1, '" + FrmLogin.usu + "')", conectar);
                            cmd.ExecuteNonQuery();


                            if (cantidad == 0)
                            {
                                row.Cells[0].Value = false;
                                cargo = 1;
                            }

                            // Actualizo el numero de credencial

                            credencial++;
                            conectar = Conexion.ObtenerConexion();

                            if (credencial > FrmLogin.credencial_hasta  )
                            {
                                cmd = new MySqlCommand("UPDATE setup SET Credencial_Cabinas = " + FrmLogin.credencial_desde  , conectar);
                                cmd.ExecuteNonQuery();
                                credencial = FrmLogin.credencial_desde  ;
                            }
                            else
                            {
                                cmd = new MySqlCommand("UPDATE setup SET Credencial_Cabinas =" + credencial, conectar);
                                cmd.ExecuteNonQuery();
                            }



                            if (imprimiqr.Checked == true)

                            {
                                // CODIGO QR

                                numero_id = d.traigo_ultimo_Id();

                                cadena = Convert.ToString(numero_id) + "#" + Convert.ToString(row.Cells[3].Value) + "*" + Convert.ToString(row.Cells[4].Value).PadLeft(2, '0') + "0000" + "^" + txturl.Text;
                                //cadena = txturl.Text + " " + Convert.ToString(numero_id);

                                QrCode qrCode = new QrCode();
                                qrEncoder.TryEncode(cadena, out qrCode);
                                GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.Black, Brushes.White);
                                MemoryStream ms = new MemoryStream();
                                renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
                                var imageTemporal = new Bitmap(ms);
                                var imagen = new Bitmap(imageTemporal, new Size(new Point(100, 100)));
                                panelResultado.BackgroundImage = imagen;

                                e.Graphics.DrawImage(panelResultado.BackgroundImage, 230, 190, 100, 100);

                            }

                            FrmLogin.CantRegImp--;
                            if (FrmLogin.CantRegImp != 0)
                            {
                                e.HasMorePages = true;
                                return;
                            }

                        }
                    }


                    foreach (DataGridViewRow row in dgvCabinas.Rows)
                    {
                        row.Cells[5].Value = 1;
                    }



                }


                //// PUPITRE ///////

                if (FrmPrincipal.pupitre == 1 | FrmPrincipal.pupitre34 == 1 | FrmPrincipal.pupitre567 == 1)

                {

                    conectar = Conexion.ObtenerConexion();


                    cmd = new MySqlCommand("SELECT Credencial_Pupitres FROM setup", conectar);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        credencial = dr.GetInt32(0);
                    }
                    dr.Close();


                               while (buscocredencial == 2)
                              {
                                  Evento d = new Evento();
                                  buscocredencial = d.buscarcredenciallibre(credencial, 1);
                                  if (buscocredencial == 2)
                                  {
                                   credencial++;
                                  if (credencial > FrmLogin.credencial_hasta)
                                  {
                                    credencial = FrmLogin.credencial_desde;
                                  }
                                }

                               }



                    foreach (DataGridViewRow row in dgvPupitre.Rows)
                    {

                        if (Convert.ToBoolean(row.Cells[0].Value) == true)

                        {

                            tipo = 2;
                            row.Cells[6].Value = Convert.ToString(Convert.ToInt32(row.Cells[6].Value) - 1);
                            cantidad = Convert.ToInt32(row.Cells[6].Value);
                            cantidad_fija = cantidad + 1;
                            Rectangle rect3 = new Rectangle(320, 230, 290, 70);
                            e.Graphics.DrawRectangle(Pens.White, rect3);

                            //credencial


                         //       Rectangle rect12 = new Rectangle(440, 410, 170, 40);
                         //       e.Graphics.DrawRectangle(Pens.White, rect12);
                         //       e.Graphics.DrawString(Convert.ToString(credencial).PadLeft(3, '0'), new Font("Arial Black", 14), Brushes.Black, rect12, stringFormat);



                            if (imprimiqr.Checked == true)

                            {


                                // Nombre y DNI


                                if (Convert.ToBoolean(row.Cells[10].Value) == true)
                                {
                                    e.Graphics.DrawString(Convert.ToString(row.Cells[7].Value), new Font("Arial Black", 14), Brushes.Black, rect3, stringFormat);
                                    if (Convert.ToString(row.Cells[8].Value) != "")
                                    {
                                        Rectangle rect6 = new Rectangle(320, 250, 290, 70);
                                        e.Graphics.DrawRectangle(Pens.White, rect6);
                                        e.Graphics.DrawString(Convert.ToString(row.Cells[8].Value), new Font("Arial Black", 14), Brushes.Black, rect6, stringFormat);
                                    }
                                    Rectangle rect4 = new Rectangle(320, 290, 290, 40);
                                    e.Graphics.DrawRectangle(Pens.White, rect4);
                                    e.Graphics.DrawString("FILA Nº " + Convert.ToString(row.Cells[4].Value) + " ASIENTO Nº " + Convert.ToString(row.Cells[5].Value), new Font("Arial Black", 14), Brushes.Black, rect4, stringFormat);
                                }



                                else
                                {
                                    Rectangle rect4 = new Rectangle(320, 250, 290, 70);
                                    e.Graphics.DrawRectangle(Pens.White, rect4);
                                    e.Graphics.DrawString("FILA Nº " + Convert.ToString(row.Cells[4].Value) + " ASIENTO Nº " + Convert.ToString(row.Cells[5].Value), new Font("Arial Black", 14), Brushes.Black, rect4, stringFormat);

                                }


                            } else
                            {

                                // Nombre y DNI

                                Rectangle rect999 = new Rectangle(220, 230, 390, 70);
                                e.Graphics.DrawRectangle(Pens.White, rect999);
                                if (Convert.ToBoolean(row.Cells[10].Value) == true)
                                {
                                    e.Graphics.DrawString(Convert.ToString(row.Cells[7].Value), new Font("Arial Black", 14), Brushes.Black, rect999, stringFormat);
                                    if (Convert.ToString(row.Cells[8].Value) != "")
                                    {
                                        Rectangle rect6 = new Rectangle(220, 250, 390, 70);
                                        e.Graphics.DrawRectangle(Pens.White, rect6);
                                        e.Graphics.DrawString(Convert.ToString(row.Cells[8].Value), new Font("Arial Black", 14), Brushes.Black, rect6, stringFormat);
                                    }
                                    Rectangle rect4 = new Rectangle(220, 290, 390, 40);
                                    e.Graphics.DrawRectangle(Pens.White, rect4);
                                    e.Graphics.DrawString("FILA Nº " + Convert.ToString(row.Cells[4].Value) + " ASIENTO Nº " + Convert.ToString(row.Cells[5].Value), new Font("Arial Black", 14), Brushes.Black, rect4, stringFormat);
                                }



                                else
                                {
                                    Rectangle rect4 = new Rectangle(220, 250, 390, 70);
                                    e.Graphics.DrawRectangle(Pens.White, rect4);
                                    e.Graphics.DrawString("FILA Nº " + Convert.ToString(row.Cells[4].Value) + " ASIENTO Nº " + Convert.ToString(row.Cells[5].Value), new Font("Arial Black", 14), Brushes.Black, rect4, stringFormat);

                                }







                            }



                            Rectangle rect1 = new Rectangle(220, 90, 390, 45);
                      //      e.Graphics.DrawRectangle(Pens.Black, rect1);


                            //CAMPEONATO
                            e.Graphics.DrawString(Convert.ToString(row.Cells[1].Value) + " - " + Convert.ToString(txtfechanumero.Text), new Font("Arial Black", 15), Brushes.Black, rect1, stringFormat);



                            //EVENTO
                            Rectangle rect0 = new Rectangle(220, 130, 390, 45);
                  //          e.Graphics.DrawRectangle(Pens.Black, rect0);
                            e.Graphics.DrawString(Convert.ToString(row.Cells[2].Value), new Font(FrmLogin.nomfuente, FrmLogin.sizefuente), Brushes.Black, rect0, stringFormat);

                            //MEDIO


                            if (imprimiqr.Checked == true)

                            {
                                Char delimiter = '-';
                                int num = 190;
                                String[] substrings = Convert.ToString(row.Cells[3].Value).Split(delimiter);
                                foreach (var substring in substrings)
                                {
                                    Rectangle rect2 = new Rectangle(320, num, 290, 30);
                                    e.Graphics.DrawRectangle(Pens.White, rect2);
                                    e.Graphics.DrawString(substring, new Font("Arial Black", 16), Brushes.Black, rect2, stringFormat);
                                    num = num + 30;
                                }

                            } else
                            {

                                Char delimiter = '-';
                                int num = 190;
                                String[] substrings = Convert.ToString(row.Cells[3].Value).Split(delimiter);
                                foreach (var substring in substrings)
                                {
                                    Rectangle rect2 = new Rectangle(220, num, 390, 30);
                                    e.Graphics.DrawRectangle(Pens.White, rect2);
                                    e.Graphics.DrawString(substring, new Font("Arial Black", 18), Brushes.Black, rect2, stringFormat);
                                    num = num + 30;
                                }






                            }


                            //Rectangle rect5 = new Rectangle(300, 410, 390, 30);
                            //e.Graphics.DrawRectangle(Pens.White, rect5);

                            //    e.Graphics.DrawString(Convert.ToString(row.Cells[2].Value), new Font("Arial Black", 14), Brushes.Black, rect5, stringFormat);
                            //    float x11111 = 200.0F;
                            //    float y11111 = 352.0F;
                            //    float x22222 = 590.0F;
                            //   e.Graphics.DrawLine(blackPen, x11111, y11
                            //    float y22222 = 352.0F;111, x22222, y22222);



                            //CUADRO CENTRAL
                            //  Rectangle rect11 = new Rectangle(200, 180, 390, 230);
                            //   e.Graphics.DrawRectangle(Pens.Black, rect11);


                            conectar = Conexion.ObtenerConexion();

                            Evento d = new Evento();
                            numero_evento = d.traigo_numero_evento();

                            cmd = new MySqlCommand("Insert into impresiones(Torneo, Evento, Medio, Cantidad, Nombre, DNI, Credencial, Asiento, Fila, Cabina, Fecha, Tipo, Id_Evento, Estado, Usuario ) values('" + row.Cells[1].Value + "', '" + row.Cells[2].Value + "', '" + row.Cells[3].Value + "', '" + cantidad_fija + "', '" + row.Cells[7].Value + "', '" + row.Cells[8].Value + "', '" + credencial + "', " + row.Cells[5].Value + ", " + row.Cells[4].Value + ", " + 0 + ", '" + txtFecha.Text + "', " + tipo + ", " + numero_evento + ", 1, '" + FrmLogin.usu + "')", conectar);
                            cmd.ExecuteNonQuery();


                            if (cantidad == 0)
                            {

                                row.Cells[0].Value = false;
                                cargo = 1;
                            }

                            // Actualizo el numero de credencial
                            credencial++;
                            conectar = Conexion.ObtenerConexion();

                            if (credencial > FrmLogin.credencial_hasta  )
                            {
                                cmd = new MySqlCommand("UPDATE setup SET Credencial_Pupitres = " + FrmLogin.credencial_desde  , conectar);
                                cmd.ExecuteNonQuery();
                                credencial = 1;
                            }
                            else
                            {
                                cmd = new MySqlCommand("UPDATE setup SET Credencial_Pupitres =" + credencial, conectar);
                                cmd.ExecuteNonQuery();
                            }

                            if (imprimiqr.Checked == true)

                            {
                                // CODIGO QR

                                numero_id = d.traigo_ultimo_Id();

                                cadena = Convert.ToString(numero_id) + "#" + Convert.ToString(row.Cells[3].Value) + "*" + "00" + string.Format("{00}", Convert.ToString(row.Cells[4].Value)) + Convert.ToString(row.Cells[5].Value).PadLeft(2, '0') + "^" + txturl.Text; ;
                                //cadena = txturl.Text + " " + Convert.ToString(numero_id);


                                QrCode qrCode = new QrCode();
                                qrEncoder.TryEncode(cadena, out qrCode);
                                GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.Black, Brushes.White);
                                MemoryStream ms = new MemoryStream();
                                renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
                                var imageTemporal = new Bitmap(ms);
                                var imagen = new Bitmap(imageTemporal, new Size(new Point(100, 100)));
                                panelResultado.BackgroundImage = imagen;

                                e.Graphics.DrawImage(panelResultado.BackgroundImage, 230, 190, 100, 100);

                            }


                            FrmLogin.CantRegImp--;
                            if (FrmLogin.CantRegImp != 0)
                            {
                                e.HasMorePages = true;
                                return;
                            }



                        }
                    }

                    foreach (DataGridViewRow row in dgvPupitre.Rows)
                    {
                        row.Cells[6].Value = 1;
                    }

                }

                //// MOVIL ///////

                if (FrmPrincipal.movil == 1)

                {
                    conectar = Conexion.ObtenerConexion();


                    cmd = new MySqlCommand("SELECT Credencial_Moviles FROM setup", conectar);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        credencial = dr.GetInt32(0);
                    }
                    dr.Close();


                               while (buscocredencial == 2)
                              {
                                  Evento d = new Evento();
                                  buscocredencial = d.buscarcredenciallibre(credencial, 1);
                                  if (buscocredencial == 2)
                                  {
                                  credencial++;
                                 if (credencial > FrmLogin.credencial_hasta)
                                  {
                                  credencial = FrmLogin.credencial_desde;
                                   }
                                      }

                               }



                    foreach (DataGridViewRow row in dgvMovil.Rows)
                    {

                        if (Convert.ToBoolean(row.Cells[0].Value) == true)

                            if (Convert.ToBoolean(row.Cells[0].Value) == true)

                            {

                                tipo = 3;
                                row.Cells[4].Value = Convert.ToString(Convert.ToInt32(row.Cells[4].Value) - 1);
                                cantidad = Convert.ToInt32(row.Cells[4].Value);
                                cantidad_fija = cantidad + 1;
                                Rectangle rect3 = new Rectangle(320, 210, 290, 70);
                                e.Graphics.DrawRectangle(Pens.White, rect3);

                                //credencial


                                   //     Rectangle rect12 = new Rectangle(440, 410, 170, 40);
                                   //     e.Graphics.DrawRectangle(Pens.White, rect12);
                                    //    e.Graphics.DrawString(Convert.ToString(credencial).PadLeft(3, '0'), new Font("Arial Black", 14), Brushes.Black, rect12, stringFormat);



                                if (imprimiqr.Checked == true)

                                {
                                    // Nombre y DNI
                                    if (Convert.ToBoolean(row.Cells[8].Value) == true)

                                    {

                                        e.Graphics.DrawString(Convert.ToString(row.Cells[5].Value), new Font("Arial Black", 14), Brushes.Black, rect3, stringFormat);
                                        if (Convert.ToString(row.Cells[6].Value) != "")
                                        {
                                            Rectangle rect6 = new Rectangle(320, 230, 290, 70);
                                            e.Graphics.DrawRectangle(Pens.White, rect6);
                                            e.Graphics.DrawString(Convert.ToString(row.Cells[6].Value), new Font("Arial Black", 14), Brushes.Black, rect6, stringFormat);

                                        }

                                        Rectangle rect4 = new Rectangle(300, 270, 290, 40);
                                        e.Graphics.DrawRectangle(Pens.White, rect4);
                                 //       e.Graphics.DrawString("MOVIL", new Font("Arial Black", 17), Brushes.Black, rect4, stringFormat);
                                        Rectangle rect99 = new Rectangle(300, 290, 290, 40);
                                        e.Graphics.DrawRectangle(Pens.White, rect99);
            //                            e.Graphics.DrawString("ACCESO A DESIGNAR", new Font("Arial Black", 15), Brushes.Black, rect99, stringFormat);


                                    }
                                    else
                                    {
                                        Rectangle rect4 = new Rectangle(300, 270, 290, 40);
                                        e.Graphics.DrawRectangle(Pens.White, rect4);
                            //            e.Graphics.DrawString("MOVIL", new Font("Arial Black", 17), Brushes.Black, rect4, stringFormat);
                                        Rectangle rect99 = new Rectangle(300, 290, 290, 40);
                                        e.Graphics.DrawRectangle(Pens.White, rect99);
              //                          e.Graphics.DrawString("ACCESO A DESIGNAR", new Font("Arial Black", 15), Brushes.Black, rect99, stringFormat);


                                    }

                                } else
                                {

                                    // Nombre y DNI

                                    Rectangle rect999 = new Rectangle(220, 210, 390, 70);
                                    e.Graphics.DrawRectangle(Pens.White, rect999);
                                    if (Convert.ToBoolean(row.Cells[8].Value) == true)

                                    {

                                        e.Graphics.DrawString(Convert.ToString(row.Cells[5].Value), new Font("Arial Black", 14), Brushes.Black, rect999, stringFormat);
                                        if (Convert.ToString(row.Cells[6].Value) != "")
                                        {
                                            Rectangle rect6 = new Rectangle(220, 230, 390, 70);
                                            e.Graphics.DrawRectangle(Pens.White, rect6);
                                            e.Graphics.DrawString(Convert.ToString(row.Cells[6].Value), new Font("Arial Black", 14), Brushes.Black, rect6, stringFormat);

                                        }

                                        Rectangle rect4 = new Rectangle(220, 270, 390, 40);
                                        e.Graphics.DrawRectangle(Pens.White, rect4);
                //                        e.Graphics.DrawString("MOVIL", new Font("Arial Black", 17), Brushes.Black, rect4, stringFormat);
                                        Rectangle rect99 = new Rectangle(220, 290, 390, 40);
                                        e.Graphics.DrawRectangle(Pens.White, rect99);
                  //                      e.Graphics.DrawString("ACCESO A DESIGNAR", new Font("Arial Black", 15), Brushes.Black, rect99, stringFormat);


                                    }
                                    else
                                    {
                                        Rectangle rect4 = new Rectangle(220, 270, 390, 40);
                                        e.Graphics.DrawRectangle(Pens.White, rect4);
                    //                    e.Graphics.DrawString("MOVIL", new Font("Arial Black", 17), Brushes.Black, rect4, stringFormat);
                                        Rectangle rect99 = new Rectangle(220, 290, 390, 40);
                                        e.Graphics.DrawRectangle(Pens.White, rect99);
                      //                  e.Graphics.DrawString("ACCESO A DESIGNAR", new Font("Arial Black", 15), Brushes.Black, rect99, stringFormat);


                                    }






                                }



                                Rectangle rect1 = new Rectangle(220, 90, 390, 45);
                          //      e.Graphics.DrawRectangle(Pens.Black, rect1);

                                e.Graphics.DrawString(Convert.ToString(row.Cells[1].Value) + " - " + Convert.ToString(txtfechanumero.Text), new Font("Arial Black", 15), Brushes.Black, rect1, stringFormat);

                                Rectangle rect0 = new Rectangle(220, 130, 390, 45);
                        //        e.Graphics.DrawRectangle(Pens.Black, rect0);
                                e.Graphics.DrawString(Convert.ToString(row.Cells[2].Value), new Font(FrmLogin.nomfuente, FrmLogin.sizefuente), Brushes.Black, rect0, stringFormat);


                                //MEDIO

                                if (imprimiqr.Checked == true)

                                {
                                    Char delimiter = '-';
                                    int num = 180;
                                    String[] substrings = Convert.ToString(row.Cells[3].Value).Split(delimiter);
                                    foreach (var substring in substrings)
                                    {
                                        Rectangle rect2 = new Rectangle(320, num, 290, 30);
                                        e.Graphics.DrawRectangle(Pens.White, rect2);
                                        e.Graphics.DrawString(substring, new Font("Arial Black", 16), Brushes.Black, rect2, stringFormat);
                                        num = num + 30;
                                    }
                                } else
                                {
                                    Char delimiter = '-';
                                    int num = 180;
                                    String[] substrings = Convert.ToString(row.Cells[3].Value).Split(delimiter);
                                    foreach (var substring in substrings)
                                    {
                                        Rectangle rect2 = new Rectangle(220, num, 390, 30);
                                        e.Graphics.DrawRectangle(Pens.White, rect2);
                                        e.Graphics.DrawString(substring, new Font("Arial Black", 18), Brushes.Black, rect2, stringFormat);
                                        num = num + 30;
                                    }




                                }


                                //Rectangle rect5 = new Rectangle(200, 410, 390, 30);
                                // e.Graphics.DrawRectangle(Pens.White, rect5);

                                //    e.Graphics.DrawString(Convert.ToString(row.Cells[2].Value), new Font("Arial Black", 14), Brushes.Black, rect5, stringFormat);
                                // float x11111 = 200.0F;
                                //   float y11111 = 352.0F;
                                //    float x22222 = 590.0F;
                                //     float y22222 = 352.0F;
                                //     e.Graphics.DrawLine(blackPen, x11111, y11111, x22222, y22222);

                                //     Rectangle rect11 = new Rectangle(200, 180, 390, 230);
                                //     e.Graphics.DrawRectangle(Pens.Black, rect11);


                                conectar = Conexion.ObtenerConexion();

                                Evento d = new Evento();
                                numero_evento = d.traigo_numero_evento();


                                cmd = new MySqlCommand("Insert into impresiones(Torneo, Evento, Medio, Cantidad, Nombre, DNI, Credencial, Asiento, Fila, Cabina, Fecha, Tipo, Id_Evento, Estado, Usuario) values('" + row.Cells[1].Value + "', '" + row.Cells[2].Value + "', '" + row.Cells[3].Value + "', '" + cantidad_fija + "', '" + row.Cells[5].Value + "', '" + row.Cells[6].Value + "', " + credencial + ", " + 0 + ", " + 0 + ", " + 0 + ", '" + txtFecha.Text + "', " + tipo + ", " + numero_evento + ", 1, '" + FrmLogin.usu + "')", conectar);
                                cmd.ExecuteNonQuery();



                                if (cantidad == 0)
                                {
                                    row.Cells[0].Value = false;
                                    cargo = 1;
                                }

                                // Actualizo el numero de credencial
                                credencial++;
                                conectar = Conexion.ObtenerConexion();

                                if (credencial > FrmLogin.credencial_hasta  )
                                {
                                    cmd = new MySqlCommand("UPDATE setup SET Credencial_Moviles = " + FrmLogin.credencial_desde  , conectar);
                                    cmd.ExecuteNonQuery();
                                    credencial = FrmLogin.credencial_desde  ;
                                }
                                else
                                {
                                    cmd = new MySqlCommand("UPDATE setup SET Credencial_Moviles =" + credencial, conectar);
                                    cmd.ExecuteNonQuery();
                                }


                                if (imprimiqr.Checked == true)

                                {
                                    // CODIGO QR

                                    numero_id = d.traigo_ultimo_Id();

                                    cadena = Convert.ToString(numero_id) + "#" + Convert.ToString(row.Cells[3].Value) + "*" + "000000" + "^" + txturl.Text; 
                                    //cadena = txturl.Text + " " + Convert.ToString(numero_id);

                                    QrCode qrCode = new QrCode();
                                    qrEncoder.TryEncode(cadena, out qrCode);
                                    GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.Black, Brushes.White);
                                    MemoryStream ms = new MemoryStream();
                                    renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
                                    var imageTemporal = new Bitmap(ms);
                                    var imagen = new Bitmap(imageTemporal, new Size(new Point(100, 100)));
                                    panelResultado.BackgroundImage = imagen;

                                    e.Graphics.DrawImage(panelResultado.BackgroundImage, 230, 190, 100, 100);

                                }

                                FrmLogin.CantRegImp--;
                                if (FrmLogin.CantRegImp != 0)
                                {
                                    e.HasMorePages = true;
                                    return;
                                }



                            }
                    }

                    foreach (DataGridViewRow row in dgvMovil.Rows)
                    {
                        row.Cells[4].Value = 1;
                    }

                }


            //// TV Movil 2 ///////

            if (FrmPrincipal.TV == 1)

            {
                conectar = Conexion.ObtenerConexion();


                cmd = new MySqlCommand("SELECT Credencial_Moviles FROM setup", conectar);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    credencial = dr.GetInt32(0);
                }
                dr.Close();


                while (buscocredencial == 2)
                {
                    Evento d = new Evento();
                    buscocredencial = d.buscarcredenciallibre(credencial, 1);
                    if (buscocredencial == 2)
                    {
                        credencial++;
                        if (credencial > FrmLogin.credencial_hasta)
                        {
                            credencial = FrmLogin.credencial_desde;
                        }
                    }

                }



                foreach (DataGridViewRow row in dgvMovil.Rows)
                {

                    if (Convert.ToBoolean(row.Cells[0].Value) == true)

                        if (Convert.ToBoolean(row.Cells[0].Value) == true)

                        {

                            tipo = 4;
                            row.Cells[4].Value = Convert.ToString(Convert.ToInt32(row.Cells[4].Value) - 1);
                            cantidad = Convert.ToInt32(row.Cells[4].Value);
                            cantidad_fija = cantidad + 1;
                            Rectangle rect3 = new Rectangle(320, 230, 290, 70);
                            e.Graphics.DrawRectangle(Pens.White, rect3);

                            //credencial


                            //                    Rectangle rect12 = new Rectangle(440, 410, 170, 40);
                            //                    e.Graphics.DrawRectangle(Pens.White, rect12);
                            //                    e.Graphics.DrawString(Convert.ToString(credencial).PadLeft(3, '0'), new Font("Arial Black", 14), Brushes.Black, rect12, stringFormat);



                            if (imprimiqr.Checked == true)

                            {
                                // Nombre y DNI
                                if (Convert.ToBoolean(row.Cells[8].Value) == true)

                                {

                                    e.Graphics.DrawString(Convert.ToString(row.Cells[5].Value), new Font("Arial Black", 14), Brushes.Black, rect3, stringFormat);
                                    if (Convert.ToString(row.Cells[6].Value) != "")
                                    {
                                        Rectangle rect6 = new Rectangle(320, 250, 290, 70);
                                        e.Graphics.DrawRectangle(Pens.White, rect6);
                                        e.Graphics.DrawString(Convert.ToString(row.Cells[6].Value), new Font("Arial Black", 14), Brushes.Black, rect6, stringFormat);
                                    }

                                    Rectangle rect4 = new Rectangle(320, 290, 290, 40);
                                    e.Graphics.DrawRectangle(Pens.White, rect4);
                                    //          e.Graphics.DrawString("MOVIL", new Font("Arial Black", 17), Brushes.Black, rect4, stringFormat);



                                }
                                else

                                {
                                    Rectangle rect4 = new Rectangle(320, 290, 290, 40);
                                    e.Graphics.DrawRectangle(Pens.White, rect4);
                                    //         e.Graphics.DrawString("MOVIL", new Font("Arial Black", 17), Brushes.Black, rect4, stringFormat);


                                }
                            }
                            else
                            {

                                // Nombre y DNI

                                Rectangle rect999 = new Rectangle(220, 230, 390, 70);
                                e.Graphics.DrawRectangle(Pens.White, rect999);
                                if (Convert.ToBoolean(row.Cells[8].Value) == true)

                                {

                                    e.Graphics.DrawString(Convert.ToString(row.Cells[5].Value), new Font("Arial Black", 14), Brushes.Black, rect999, stringFormat);
                                    if (Convert.ToString(row.Cells[6].Value) != "")
                                    {
                                        Rectangle rect6 = new Rectangle(220, 250, 390, 70);
                                        e.Graphics.DrawRectangle(Pens.White, rect6);
                                        e.Graphics.DrawString(Convert.ToString(row.Cells[6].Value), new Font("Arial Black", 14), Brushes.Black, rect6, stringFormat);
                                    }

                                    Rectangle rect4 = new Rectangle(220, 290, 390, 40);
                                    e.Graphics.DrawRectangle(Pens.White, rect4);
                                    //                e.Graphics.DrawString("MOVIL", new Font("Arial Black", 17), Brushes.Black, rect4, stringFormat);



                                }
                                else

                                {
                                    Rectangle rect4 = new Rectangle(220, 290, 390, 40);
                                    e.Graphics.DrawRectangle(Pens.White, rect4);
                                    //                 e.Graphics.DrawString("MOVIL", new Font("Arial Black", 17), Brushes.Black, rect4, stringFormat);


                                }





                            }



                            Rectangle rect1 = new Rectangle(220, 90, 390, 45);
                            //    e.Graphics.DrawRectangle(Pens.Black, rect1);

                            e.Graphics.DrawString(Convert.ToString(row.Cells[1].Value) + " - " + Convert.ToString(txtfechanumero.Text), new Font("Arial Black", 15), Brushes.Black, rect1, stringFormat);

                            Rectangle rect0 = new Rectangle(220, 130, 390, 45);
                            //      e.Graphics.DrawRectangle(Pens.Black, rect0);
                            e.Graphics.DrawString(Convert.ToString(row.Cells[2].Value), new Font(FrmLogin.nomfuente, FrmLogin.sizefuente), Brushes.Black, rect0, stringFormat);


                            //MEDIO

                            if (imprimiqr.Checked == true)

                            {
                                Char delimiter = '-';
                                int num = 190;
                                String[] substrings = Convert.ToString(row.Cells[3].Value).Split(delimiter);
                                foreach (var substring in substrings)
                                {
                                    Rectangle rect2 = new Rectangle(320, num, 290, 30);
                                    e.Graphics.DrawRectangle(Pens.White, rect2);
                                    e.Graphics.DrawString(substring, new Font("Arial Black", 16), Brushes.Black, rect2, stringFormat);
                                    num = num + 30;
                                }


                            }
                            else
                            {
                                Char delimiter = '-';
                                int num = 190;
                                String[] substrings = Convert.ToString(row.Cells[3].Value).Split(delimiter);
                                foreach (var substring in substrings)
                                {
                                    Rectangle rect2 = new Rectangle(220, num, 390, 30);
                                    e.Graphics.DrawRectangle(Pens.White, rect2);
                                    e.Graphics.DrawString(substring, new Font("Arial Black", 18), Brushes.Black, rect2, stringFormat);
                                    num = num + 30;
                                }



                            }


                            //Rectangle rect5 = new Rectangle(200, 410, 390, 30);
                            // e.Graphics.DrawRectangle(Pens.White, rect5);


                            //    e.Graphics.DrawString(Convert.ToString(row.Cells[2].Value), new Font("Arial Black", 14), Brushes.Black, rect5, stringFormat);
                            // float x11111 = 200.0F;
                            //   float y11111 = 352.0F;
                            //    float x22222 = 590.0F;
                            //     float y22222 = 352.0F;
                            //     e.Graphics.DrawLine(blackPen, x11111, y11111, x22222, y22222);

                            //     Rectangle rect11 = new Rectangle(200, 180, 390, 230);
                            //     e.Graphics.DrawRectangle(Pens.Black, rect11);


                            conectar = Conexion.ObtenerConexion();

                            Evento d = new Evento();
                            numero_evento = d.traigo_numero_evento();


                            cmd = new MySqlCommand("Insert into impresiones(Torneo, Evento, Medio, Cantidad, Nombre, DNI, Credencial, Asiento, Fila, Cabina, Fecha, Tipo, Id_Evento, Estado, Usuario) values('" + row.Cells[1].Value + "', '" + row.Cells[2].Value + "', '" + row.Cells[3].Value + "', '" + cantidad_fija + "', '" + row.Cells[5].Value + "', '" + row.Cells[6].Value + "', " + credencial + ", " + 0 + ", " + 0 + ", " + 0 + ", '" + txtFecha.Text + "', " + tipo + ", " + numero_evento + ", 1, '" + FrmLogin.usu + "')", conectar);
                            cmd.ExecuteNonQuery();



                            if (cantidad == 0)
                            {
                                row.Cells[0].Value = false;
                                cargo = 1;
                            }

                            // Actualizo el numero de credencial
                            credencial++;
                            conectar = Conexion.ObtenerConexion();

                            if (credencial > FrmLogin.credencial_hasta)
                            {
                                cmd = new MySqlCommand("UPDATE setup SET Credencial_Moviles = " + FrmLogin.credencial_desde, conectar);
                                cmd.ExecuteNonQuery();
                                credencial = FrmLogin.credencial_desde;
                            }
                            else
                            {
                                cmd = new MySqlCommand("UPDATE setup SET Credencial_Moviles =" + credencial, conectar);
                                cmd.ExecuteNonQuery();
                            }


                            if (imprimiqr.Checked == true)

                            {
                                // CODIGO QR

                                numero_id = d.traigo_ultimo_Id();

                                cadena = Convert.ToString(numero_id) + "#" + Convert.ToString(row.Cells[3].Value) + "*" + "000000" + "^" + txturl.Text;
                                //cadena = txturl.Text + " " + Convert.ToString(numero_id);


                                QrCode qrCode = new QrCode();
                                qrEncoder.TryEncode(cadena, out qrCode);
                                GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.Black, Brushes.White);
                                MemoryStream ms = new MemoryStream();
                                renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
                                var imageTemporal = new Bitmap(ms);
                                var imagen = new Bitmap(imageTemporal, new Size(new Point(100, 100)));
                                panelResultado.BackgroundImage = imagen;

                                e.Graphics.DrawImage(panelResultado.BackgroundImage, 230, 190, 100, 100);

                            }

                            FrmLogin.CantRegImp--;
                            if (FrmLogin.CantRegImp != 0)
                            {
                                e.HasMorePages = true;
                                return;
                            }



                        }
                }

                foreach (DataGridViewRow row in dgvMovil.Rows)
                {
                    row.Cells[4].Value = 1;
                }

            }


                new Evento().Traigo_Numeros_Credenciales(lbCabinas, lbPupitre12, lbMovil, lbTV);

                MessageBox.Show("Finalizo la Impresion");

            

        }

        private void button8_Click(object sender, EventArgs e)
        {

            if (FrmPrincipal.cabina == 1)
            {
                foreach (DataGridViewRow row in dgvCabinas.Rows)
                {
                    row.Cells[0].Value = true  ;
                }
            }

            if (FrmPrincipal.pupitre == 1)
            {
                foreach (DataGridViewRow row in dgvPupitre.Rows)
                {
                    row.Cells[0].Value = true ;
                }

            }

            if (FrmPrincipal.pupitre34 == 1)
            {
                foreach (DataGridViewRow row in dgvPupitre.Rows)
                {
                    row.Cells[0].Value = true;
                }

            }


            if (FrmPrincipal.pupitre567 == 1)
            {
                foreach (DataGridViewRow row in dgvPupitre.Rows)
                {
                    row.Cells[0].Value = true;
                }

            }

            if (FrmPrincipal.movil == 1)
            {
                foreach (DataGridViewRow row in dgvMovil.Rows)
                {
                    row.Cells[0].Value = true;
                }

            }

            if (FrmPrincipal.TV == 1)
            {
                foreach (DataGridViewRow row in dgvMovil.Rows)
                {
                    row.Cells[0].Value = true;
                }

            }

        }

        private void button9_Click(object sender, EventArgs e)
        {

            if (FrmPrincipal.cabina == 1)
            {
                foreach (DataGridViewRow row in dgvCabinas.Rows)
                {
                    row.Cells[0].Value = false;
                }
            }

            if (FrmPrincipal.pupitre  == 1)
                {
                    foreach (DataGridViewRow row in dgvPupitre.Rows)
                    {
                        row.Cells[0].Value = false;
                    }

                }

            if (FrmPrincipal.pupitre34 == 1)
            {
                foreach (DataGridViewRow row in dgvPupitre.Rows)
                {
                    row.Cells[0].Value = false;
                }

            }


            if (FrmPrincipal.pupitre567 == 1)
            {
                foreach (DataGridViewRow row in dgvPupitre.Rows)
                {
                    row.Cells[0].Value = false;
                }

            }

            if (FrmPrincipal.movil == 1)
            {
                foreach (DataGridViewRow row in dgvMovil.Rows)
                {
                    row.Cells[0].Value = false;
                }

            }

            if (FrmPrincipal.TV == 1)
            {
                foreach (DataGridViewRow row in dgvMovil.Rows)
                {
                    row.Cells[0].Value = false;
                }

            }



        }

        private void FrmCapturaDatos_Load(object sender, EventArgs e)
        {
           // txtFecha.Text = fecha.ToString("dd/MM/yyyy");
            imprimiqr.Checked  = true;
            
         //   new Evento().Traigo_Datos_Evento(txttorneo,txtevento,txturl, txtfechanumero, Id_Evento, txtFecha, txtidrival, estado_evento);
       //     new Evento().Traigo_Numeros_Credenciales(lbCabinas , lbPupitre12 ,lbMovil ,  lbTV );
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (FrmPrincipal.cabina == 1)
            {
                dgvCabinas.Visible = true;
                dgvPupitre.Visible = false;
                dgvMovil.Visible = false;
                dgvCabinas.Rows.Clear();
                new Importar().Importar_Cabinas(dgvDatos, dgvCabinas, txttorneo.Text, txtevento.Text, button7, button13, button15);
            }
            if (FrmPrincipal.pupitre == 1)
            {
                dgvCabinas.Visible = false;
                dgvPupitre.Visible = true;
                dgvMovil.Visible = false;
                dgvPupitre.Rows.Clear();
                new Importar().Importar_Pupitres_Fila1(dgvDatos, dgvPupitre, txttorneo.Text, txtevento.Text, button7, button13, button15);
                new Importar().Importar_Pupitres_Fila2(dgvDatos, dgvPupitre, txttorneo.Text, txtevento.Text, button7, button13, button15);

            }

            if (FrmPrincipal.pupitre34 == 1)
            {
                dgvCabinas.Visible = false;
                dgvPupitre.Visible = true;
                dgvMovil.Visible = false;
                dgvPupitre.Rows.Clear();
                new Importar().Importar_Pupitres_Fila3(dgvDatos, dgvPupitre, txttorneo.Text, txtevento.Text, button7, button13, button15);
                new Importar().Importar_Pupitres_Fila4(dgvDatos, dgvPupitre, txttorneo.Text, txtevento.Text, button7, button13, button15);

            }

            if (FrmPrincipal.pupitre567 == 1)
            {
                dgvCabinas.Visible = false;
                dgvPupitre.Visible = true;
                dgvMovil.Visible = false;
                dgvPupitre.Rows.Clear();

                new Importar().Importar_Pupitres_Fila5(dgvDatos, dgvPupitre, txttorneo.Text, txtevento.Text, button7, button13, button15);
                new Importar().Importar_Pupitres_Fila6(dgvDatos, dgvPupitre, txttorneo.Text, txtevento.Text, button7, button13, button15);
                new Importar().Importar_Pupitres_Fila7(dgvDatos, dgvPupitre, txttorneo.Text, txtevento.Text, button7, button13, button15);

            }


            if (FrmPrincipal.movil == 1)
            {
                dgvCabinas.Visible = false;
                dgvPupitre.Visible = false;
                dgvMovil.Visible = true;
                dgvMovil.Rows.Clear();
                new Importar().Importar_Moviles(dgvDatos, dgvMovil, txttorneo.Text, txtevento.Text, button7, button13, button15);


            }


            if (FrmPrincipal.TV == 1)
            {
                dgvCabinas.Visible = false;
                dgvPupitre.Visible = false;
                dgvMovil.Visible = true;
                dgvMovil.Rows.Clear();
                new Importar().Importar_TV(dgvDatos, dgvMovil, txttorneo.Text, txtevento.Text, button7, button13, button15);


            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show( " Esta seguro que quiere imprimir los registros seleccionado ?", "Imprimir registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                PrinterSettings settings = new PrinterSettings();
                PaperSize paperSize = new PaperSize("A4", 210, 297);
                printDocument1.PrinterSettings.DefaultPageSettings.PaperSize = paperSize;

                if (FrmPrincipal.cabina == 1)
                {
                    Evento d = new Evento();
                    FrmLogin.CantRegImp = d.CantRegImp(dgvCabinas);
                }

                if (FrmPrincipal.movil == 1)
                {
                    Evento d = new Evento();
                    FrmLogin.CantRegImp = d.CantRegImp(dgvMovil);
                }

                if (FrmPrincipal.pupitre == 1)
                {
                    Evento d = new Evento();
                    FrmLogin.CantRegImp = d.CantRegImp(dgvPupitre);
                }

                if (FrmPrincipal.pupitre34 == 1)
                {
                    Evento d = new Evento();
                    FrmLogin.CantRegImp = d.CantRegImp(dgvPupitre);
                }
                if (FrmPrincipal.pupitre567 == 1)
                {
                    Evento d = new Evento();
                    FrmLogin.CantRegImp = d.CantRegImp(dgvPupitre);
                }
              
                if (FrmPrincipal.TV == 1)
                {
                    Evento d = new Evento();
                    FrmLogin.CantRegImp = d.CantRegImp(dgvMovil);
                }


                printDocument1.Print();
                //printPreviewDialog1.Document = printDocument1;
                //printPreviewDialog1.ShowDialog();
               


            }

        }

        private void imprimiqr_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dgvCabinas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtFecha_TextChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            FrmPrincipal.cabina = 2;
            FrmPrincipal.pupitre34 = 2;
            FrmPrincipal.pupitre567 = 1;
            FrmPrincipal.pupitre = 2;
            FrmPrincipal.movil = 2;
            new Importar().importarExcel(dgvDatos, "Fila 5,6 y 7 y Comisión", button5);


           

        }

        private void dgvMovil_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
           
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            FrmPrincipal.cabina = 2;
            FrmPrincipal.pupitre34 = 2;
            FrmPrincipal.pupitre567 = 2;
            FrmPrincipal.pupitre = 2;
            FrmPrincipal.movil = 2;
            FrmPrincipal.TV = 1;

            new Importar().importarExcel(dgvDatos, "Movil2", button5);

           

        }

        private void printDocument2_PrintPage(object sender, PrintPageEventArgs e)
        {
            Pen blackPen = new Pen(Color.Black, 3);

            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;



            QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);

            //QrCode qrCode1 = new QrCode();
            //qrEncoder.TryEncode(txtCredencial.Text, out qrCode1);

            string cadena = "";
            int cantidad = 0, cantidad_fija = 0, tipo = 0, numero_evento = 0, numero_id = 0;
            DateTime mihora = DateTime.Now;
            string lahora = mihora.ToString("yyyy-MM-dd");
            int credencial = 0, buscocredencial = 2;


            new Importar().Traigo_Configuracion_Evento(txtideventos);

           

            //// CABINAS ///////


            if (FrmPrincipal.cabina == 1)
                {

                    conectar = Conexion.ObtenerConexion();


                    cmd = new MySqlCommand("SELECT Credencial_Cabinas  FROM setup", conectar);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        credencial = dr.GetInt32(0);
                    }
                    dr.Close();


                    while (buscocredencial == 2)
                    {
                        Evento d = new Evento();
                        buscocredencial = d.buscarcredenciallibre(credencial, 1);
                        if (buscocredencial == 2)
                        {
                            credencial++;
                            if (credencial > FrmLogin.credencial_hasta)
                            {
                                credencial = FrmLogin.credencial_desde;
                            }
                        }

                    }



                    foreach (DataGridViewRow row in dgvCabinas.Rows)
                    {

                        if (Convert.ToBoolean(row.Cells[0].Value) == true)

                        {

                            tipo = 1;
                            row.Cells[5].Value = Convert.ToString(Convert.ToInt32(row.Cells[5].Value) - 1);
                            cantidad = Convert.ToInt32(row.Cells[5].Value);
                            cantidad_fija = cantidad + 1;
                            Rectangle rect3 = new Rectangle(300, 230, 290, 70);
                            e.Graphics.DrawRectangle(Pens.White, rect3);


                            // fila 1

                            Rectangle rect1 = new Rectangle(190, 87, 410, 45);
                       


                        
                           /////////// IMPRIMO CAMPEONATO ////////////
                           if (FrmLogin.negritacampeonato == 1)
                            {
                            e.Graphics.DrawString(Convert.ToString(txttorneo.Text), new Font(FrmLogin.nomfuentecampeonato, FrmLogin.sizecampeonato, FontStyle.Bold), Brushes.Black, rect1, stringFormat);
                            }
                           else
                            {
                            e.Graphics.DrawString(Convert.ToString(txttorneo.Text), new Font(FrmLogin.nomfuentecampeonato, FrmLogin.sizecampeonato), Brushes.Black, rect1, stringFormat);
                            }

                        /////////// IMPRIMO FECHA ////////////

                        Rectangle rect111 = new Rectangle(190, 107, 410, 45);
                           if (FrmLogin.negritafecha == 1)
                            {
                                e.Graphics.DrawString(txtfechanumero.Text, new Font(FrmLogin.nomfuentefecha, FrmLogin.sizefecha, FontStyle.Bold), Brushes.Black, rect111, stringFormat);
                            }
                            else
                            {
                                e.Graphics.DrawString(txtfechanumero.Text, new Font(FrmLogin.nomfuentefecha, FrmLogin.sizefecha), Brushes.Black, rect111, stringFormat);
                            }


                           Rectangle rect0 = new Rectangle(190, 130, 410, 45);


                        /////////// IMPRIMO RIVAL ////////////

                        if (FrmLogin.negritarival == 1)
                        {
                            e.Graphics.DrawString(Convert.ToString(row.Cells[2].Value), new Font(FrmLogin.nomfuenterival, FrmLogin.sizerival, FontStyle.Bold), Brushes.Black, rect0, stringFormat);
                        }
                        else
                        {
                            e.Graphics.DrawString(Convert.ToString(row.Cells[2].Value), new Font(FrmLogin.nomfuenterival, FrmLogin.sizerival), Brushes.Black, rect0, stringFormat);

                        }

                           Pen mipen = new Pen(Color.Black, 7);
                           e.Graphics.DrawLine(mipen, 170, 170, 630, 170);


                            // fila 2

                            Char delimiter = '-';
                            int num = 190;
                            String[] substrings = Convert.ToString(row.Cells[3].Value).Split(delimiter);
                            foreach (var substring in substrings)
                            {
                                Rectangle rect2 = new Rectangle(170, num, 430, 30);
                                e.Graphics.DrawRectangle(Pens.White, rect2);


                            /////////// IMPRIMO MEDIO ////////////

                            if (FrmLogin.negritamedio == 1)
                            {
                                e.Graphics.DrawString(substring, new Font(FrmLogin.nomfuentemedio, FrmLogin.sizemedio, FontStyle.Bold), Brushes.Black, rect2, stringFormat);
                            }
                            else
                            {
                                e.Graphics.DrawString(substring, new Font(FrmLogin.nomfuentemedio, FrmLogin.sizemedio), Brushes.Black, rect2, stringFormat);

                            }


                                num = num + 30;
                            }
                            Pen mipen1 = new Pen(Color.Black, 7);
                            e.Graphics.DrawLine(mipen1, 170, 260, 630, 260);



                            // fila 3

                            Rectangle rect22 = new Rectangle(200, 250, 390, 60);
                            e.Graphics.DrawRectangle(Pens.White, rect22);

                        /////////// IMPRIMO UBICACION ////////////


                        if (FrmLogin.negritaubicacion== 1)
                           {
                            e.Graphics.DrawString("CABINA DE PRENSA", new Font(FrmLogin.nomfuenteubicacion, FrmLogin.sizeubicacion, FontStyle.Bold), Brushes.Black, rect22, stringFormat);
                           }
                        else
                        {
                            e.Graphics.DrawString("CABINA DE PRENSA", new Font(FrmLogin.nomfuenteubicacion, FrmLogin.sizeubicacion), Brushes.Black, rect22, stringFormat);
                        }


                            Rectangle rect4 = new Rectangle(200, 290, 390, 60);
                            e.Graphics.DrawRectangle(Pens.White, rect4);


                        if (FrmLogin.negritaubicacion == 1)
                        {
                            e.Graphics.DrawString("CABINA Nº " + Convert.ToString(row.Cells[4].Value), new Font(FrmLogin.nomfuenteubicacion, FrmLogin.sizeubicacion, FontStyle.Bold), Brushes.Black, rect4, stringFormat);
                        }
                        else
                        {

                            e.Graphics.DrawString("CABINA Nº " + Convert.ToString(row.Cells[4].Value), new Font(FrmLogin.nomfuenteubicacion, FrmLogin.sizeubicacion), Brushes.Black, rect4, stringFormat);

                        }


                        if (Convert.ToString(row.Cells[6].Value) != "")
                        {
                            Rectangle rect23 = new Rectangle(170, 340, 420, 60);
                            e.Graphics.DrawRectangle(Pens.White, rect23);
                            if (FrmLogin.negritanombre == 1)
                            {
                                e.Graphics.DrawString(Convert.ToString(row.Cells[6].Value), new Font(FrmLogin.nomfuentenombre, FrmLogin.sizenombre, FontStyle.Bold), Brushes.Black, rect23, stringFormat);
                                if (Convert.ToString(row.Cells[7].Value) != "")
                                {
                                    Rectangle rect6 = new Rectangle(170, 390, 420, 60);
                                    e.Graphics.DrawRectangle(Pens.White, rect6);
                                    e.Graphics.DrawString(Convert.ToString(row.Cells[7].Value), new Font(FrmLogin.nomfuentenombre, FrmLogin.sizenombre, FontStyle.Bold), Brushes.Black, rect6, stringFormat);
                                }
                                else
                                {
                                    e.Graphics.DrawString(Convert.ToString(row.Cells[6].Value), new Font(FrmLogin.nomfuentenombre, FrmLogin.sizenombre), Brushes.Black, rect23, stringFormat);
                                    if (Convert.ToString(row.Cells[7].Value) != "")
                                    {
                                        Rectangle rect6 = new Rectangle(170, 390, 420, 60);
                                        e.Graphics.DrawRectangle(Pens.White, rect6);
                                        e.Graphics.DrawString(Convert.ToString(row.Cells[7].Value), new Font(FrmLogin.nomfuentenombre, FrmLogin.sizenombre), Brushes.Black, rect6, stringFormat);


                                    }

                                }
                            }

                        }










                        if (Convert.ToString(row.Cells[6].Value) != "")
                            {
                                Rectangle rect23 = new Rectangle(170, 340, 390, 60);
                                e.Graphics.DrawRectangle(Pens.White, rect23);
                                e.Graphics.DrawString(Convert.ToString(row.Cells[6].Value), new Font("Stencil", 21), Brushes.Black, rect23, stringFormat);
                                if (Convert.ToString(row.Cells[7].Value) != "")
                                {
                                    Rectangle rect6 = new Rectangle(170, 390, 390, 60);
                                    e.Graphics.DrawRectangle(Pens.White, rect6);
                                    e.Graphics.DrawString(Convert.ToString(row.Cells[7].Value), new Font("Stencil", 21), Brushes.Black, rect6, stringFormat);
                                }


                            }


                        //credencial


                        Rectangle rect12 = new Rectangle(370, 420, 390, 40);
                        e.Graphics.DrawRectangle(Pens.White, rect12);
                        e.Graphics.DrawString("Nº " + Convert.ToString(credencial).PadLeft(3, '0'), new Font("Arial Black", 14), Brushes.Black, rect12, stringFormat);

                        conectar = Conexion.ObtenerConexion();
                            Evento d = new Evento();
                            numero_evento = d.traigo_numero_evento();

                            cmd = new MySqlCommand("Insert into impresiones(Torneo, Evento, Medio, Cantidad, Nombre, DNI, Credencial, Asiento, Fila, Cabina, Fecha, Tipo, Id_Evento, Estado, Usuario, Letras) values('" + row.Cells[1].Value + "', '" + row.Cells[2].Value + "', '" + row.Cells[3].Value + "', '" + cantidad_fija + "', '" + row.Cells[6].Value + "', '" + row.Cells[7].Value + "', '" + credencial + "', " + 0 + ", " + 0 + ", " + row.Cells[4].Value + ", '" + txtFecha.Text + "', " + tipo + ", " + numero_evento + ", 1, '" + FrmLogin.usu + "', '" + row.Cells[10].Value + "')", conectar);
                            cmd.ExecuteNonQuery();


                            if (cantidad == 0)
                            {
                                row.Cells[0].Value = false;
                                cargo = 1;
                            }

                            // Actualizo el numero de credencial

                            credencial++;
                            conectar = Conexion.ObtenerConexion();

                            if (credencial > FrmLogin.credencial_hasta  )
                            {
                                cmd = new MySqlCommand("UPDATE setup SET Credencial_Cabinas =" + FrmLogin.credencial_desde  , conectar);
                                cmd.ExecuteNonQuery();
                                credencial = FrmLogin.credencial_desde  ;
                            }
                            else
                            {
                                cmd = new MySqlCommand("UPDATE setup SET Credencial_Cabinas =" + credencial, conectar);
                                cmd.ExecuteNonQuery();
                            }



                            // QR

                            if (imprimiqr.Checked == true)

                            {
                                cadena = Convert.ToString(numero_id) + "#" + Convert.ToString(row.Cells[3].Value) + "*" + Convert.ToString(row.Cells[4].Value).PadLeft(2, '0') + "0000" + "^" + txturl.Text;
                                QrCode qrCode = new QrCode();
                                qrEncoder.TryEncode(cadena, out qrCode);
                                GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.Black, Brushes.White);
                                MemoryStream ms = new MemoryStream();
                                renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
                                var imageTemporal = new Bitmap(ms);
                                var imagen = new Bitmap(imageTemporal, new Size(new Point(100, 100)));
                                panelResultado.BackgroundImage = imagen;

                                //     e.Graphics.DrawImage(panelResultado.BackgroundImage, 220, 470, 100, 100);
                                e.Graphics.DrawImage(panelResultado.BackgroundImage, 190, 490, 100, 100);
                                
                            }

                            // Letras

                           // Rectangle rect27 = new Rectangle(240, 410, 390, 150);
                           // e.Graphics.DrawRectangle(Pens.White, rect27);
                           // e.Graphics.DrawString("SECTOR", new Font("Arial", 21), Brushes.Black, rect27, stringFormat);
                            Rectangle rect29 = new Rectangle(210, 470, 380, 100);
                            e.Graphics.DrawRectangle(Pens.White, rect29);
                            e.Graphics.DrawString(Convert.ToString(row.Cells[10].Value), new Font("Arial", 32), Brushes.Black, rect29, stringFormat);



                            if (cantidad == 0)
                            {
                                row.Cells[0].Value = false;
                                cargo = 1;
                            }

                            FrmLogin.CantRegImp--;
                            if (FrmLogin.CantRegImp != 0)
                            {
                                e.HasMorePages = true;
                                return;
                            }

                        }
                    }


                    foreach (DataGridViewRow row in dgvCabinas.Rows)
                    {
                        row.Cells[5].Value = 1;
                    }
                }



                //// PUPITRE ///////

                if (FrmPrincipal.pupitre == 1 | FrmPrincipal.pupitre34 == 1 | FrmPrincipal.pupitre567 == 1)

                {

                conectar = Conexion.ObtenerConexion();


                cmd = new MySqlCommand("SELECT Credencial_Pupitres  FROM setup", conectar);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    credencial = dr.GetInt32(0);
                }
                dr.Close();


                while (buscocredencial == 2)
                {
                    Evento d = new Evento();
                    buscocredencial = d.buscarcredenciallibre(credencial, 2);
                    if (buscocredencial == 2)
                    {
                        credencial++;
                        if (credencial > FrmLogin.credencial_hasta)
                        {
                            credencial = FrmLogin.credencial_desde;
                        }
                    }

                }



                foreach (DataGridViewRow row in dgvPupitre.Rows)
                {

                    if (Convert.ToBoolean(row.Cells[0].Value) == true)

                    {

                        tipo = 1;
                        row.Cells[6].Value = Convert.ToString(Convert.ToInt32(row.Cells[6].Value) - 1);
                        cantidad = Convert.ToInt32(row.Cells[6].Value);
                        cantidad_fija = cantidad + 1;
                        Rectangle rect3 = new Rectangle(300, 230, 290, 70);
                        e.Graphics.DrawRectangle(Pens.White, rect3);


                        // fila 1

                        Rectangle rect1 = new Rectangle(190, 87, 410, 45);




                        /////////// IMPRIMO CAMPEONATO ////////////
                        if (FrmLogin.negritacampeonato == 1)
                        {
                            e.Graphics.DrawString(Convert.ToString(txttorneo.Text), new Font(FrmLogin.nomfuentecampeonato, FrmLogin.sizecampeonato, FontStyle.Bold), Brushes.Black, rect1, stringFormat);
                        }
                        else
                        {
                            e.Graphics.DrawString(Convert.ToString(txttorneo.Text), new Font(FrmLogin.nomfuentecampeonato, FrmLogin.sizecampeonato), Brushes.Black, rect1, stringFormat);
                        }

                        /////////// IMPRIMO FECHA ////////////

                        Rectangle rect111 = new Rectangle(190, 107, 410, 45);
                        if (FrmLogin.negritafecha == 1)
                        {
                            e.Graphics.DrawString(txtfechanumero.Text, new Font(FrmLogin.nomfuentefecha, FrmLogin.sizefecha, FontStyle.Bold), Brushes.Black, rect111, stringFormat);
                        }
                        else
                        {
                            e.Graphics.DrawString(txtfechanumero.Text, new Font(FrmLogin.nomfuentefecha, FrmLogin.sizefecha), Brushes.Black, rect111, stringFormat);
                        }


                        Rectangle rect0 = new Rectangle(190, 130, 410, 45);


                        /////////// IMPRIMO RIVAL ////////////

                        if (FrmLogin.negritarival == 1)
                        {
                            e.Graphics.DrawString(Convert.ToString(row.Cells[2].Value), new Font(FrmLogin.nomfuenterival, FrmLogin.sizerival, FontStyle.Bold), Brushes.Black, rect0, stringFormat);
                        }
                        else
                        {
                            e.Graphics.DrawString(Convert.ToString(row.Cells[2].Value), new Font(FrmLogin.nomfuenterival, FrmLogin.sizerival), Brushes.Black, rect0, stringFormat);

                        }

                        Pen mipen = new Pen(Color.Black, 7);
                        e.Graphics.DrawLine(mipen, 170, 170, 630, 170);


                        // fila 2

                        Char delimiter = '-';
                        int num = 190;
                        String[] substrings = Convert.ToString(row.Cells[3].Value).Split(delimiter);
                        foreach (var substring in substrings)
                        {
                            Rectangle rect2 = new Rectangle(170, num, 430, 30);
                            e.Graphics.DrawRectangle(Pens.White, rect2);


                            /////////// IMPRIMO MEDIO ////////////

                            if (FrmLogin.negritamedio == 1)
                            {
                                e.Graphics.DrawString(substring, new Font(FrmLogin.nomfuentemedio, FrmLogin.sizemedio, FontStyle.Bold), Brushes.Black, rect2, stringFormat);
                            }
                            else
                            {
                                e.Graphics.DrawString(substring, new Font(FrmLogin.nomfuentemedio, FrmLogin.sizemedio), Brushes.Black, rect2, stringFormat);

                            }


                            num = num + 30;
                        }
                        Pen mipen1 = new Pen(Color.Black, 7);
                        e.Graphics.DrawLine(mipen1, 170, 260, 630, 260);



                        // fila 3

                        Rectangle rect22 = new Rectangle(200, 250, 390, 60);
                        e.Graphics.DrawRectangle(Pens.White, rect22);

                        /////////// IMPRIMO UBICACION ////////////
                                                 



                        Rectangle rect44 = new Rectangle(200, 250, 390, 60);
                        e.Graphics.DrawRectangle(Pens.White, rect44);


                        if (FrmLogin.negritaubicacion == 1)
                        {
                            e.Graphics.DrawString("PUPITRE DE PRENSA", new Font(FrmLogin.nomfuenteubicacion, FrmLogin.sizeubicacion, FontStyle.Bold), Brushes.Black, rect44, stringFormat);
                            Rectangle rect78 = new Rectangle(200, 290, 390, 60);
                            e.Graphics.DrawRectangle(Pens.White, rect78);
                            e.Graphics.DrawString("FILA Nº " + Convert.ToString(row.Cells[4].Value) + " ASIENTO Nº " + Convert.ToString(row.Cells[5].Value), new Font(FrmLogin.nomfuenteubicacion, 21, FontStyle.Bold), Brushes.Black, rect78, stringFormat);
                        }
                        else
                        {

                            e.Graphics.DrawString("PUPITRE DE PRENSA", new Font(FrmLogin.nomfuenteubicacion, FrmLogin.sizeubicacion), Brushes.Black, rect44, stringFormat);
                            Rectangle rect78 = new Rectangle(200, 290, 390, 60);
                            e.Graphics.DrawRectangle(Pens.White, rect78);
                            e.Graphics.DrawString("FILA Nº " + Convert.ToString(row.Cells[4].Value) + " ASIENTO Nº " + Convert.ToString(row.Cells[5].Value), new Font(FrmLogin.nomfuenteubicacion, 21), Brushes.Black, rect78, stringFormat);
                        }

                        if (Convert.ToString(row.Cells[6].Value) != "")
                        {
                            Rectangle rect23 = new Rectangle(170, 340, 420, 60);
                            e.Graphics.DrawRectangle(Pens.White, rect23);
                            if (FrmLogin.negritanombre == 1)
                            {
                                e.Graphics.DrawString(Convert.ToString(row.Cells[6].Value), new Font(FrmLogin.nomfuentenombre, FrmLogin.sizenombre, FontStyle.Bold), Brushes.Black, rect23, stringFormat);
                                if (Convert.ToString(row.Cells[7].Value) != "")
                                {
                                    Rectangle rect6 = new Rectangle(170, 390, 420, 60);
                                    e.Graphics.DrawRectangle(Pens.White, rect6);
                                    e.Graphics.DrawString(Convert.ToString(row.Cells[7].Value), new Font(FrmLogin.nomfuentenombre, FrmLogin.sizenombre, FontStyle.Bold), Brushes.Black, rect6, stringFormat);
                                }
                                else
                                {
                                    e.Graphics.DrawString(Convert.ToString(row.Cells[6].Value), new Font(FrmLogin.nomfuentenombre, FrmLogin.sizenombre), Brushes.Black, rect23, stringFormat);
                                    if (Convert.ToString(row.Cells[7].Value) != "")
                                    {
                                        Rectangle rect6 = new Rectangle(170, 390, 420, 60);
                                        e.Graphics.DrawRectangle(Pens.White, rect6);
                                        e.Graphics.DrawString(Convert.ToString(row.Cells[7].Value), new Font(FrmLogin.nomfuentenombre, FrmLogin.sizenombre), Brushes.Black, rect6, stringFormat);


                                    }

                                }
                            }

                        }


                        //credencial


                        Rectangle rect12 = new Rectangle(370, 420, 390, 40);
                        e.Graphics.DrawRectangle(Pens.White, rect12);
                        e.Graphics.DrawString("Nº " + Convert.ToString(credencial).PadLeft(3, '0'), new Font("Arial Black", 14), Brushes.Black, rect12, stringFormat);

                        conectar = Conexion.ObtenerConexion();
                        Evento d = new Evento();
                        numero_evento = d.traigo_numero_evento();

                        cmd = new MySqlCommand("Insert into impresiones(Torneo, Evento, Medio, Cantidad, Nombre, DNI, Credencial, Asiento, Fila, Cabina, Fecha, Tipo, Id_Evento, Estado, Usuario, Letras) values('" + row.Cells[1].Value + "', '" + row.Cells[2].Value + "', '" + row.Cells[3].Value + "', '" + cantidad_fija + "', '" + row.Cells[6].Value + "', '" + row.Cells[7].Value + "', '" + credencial + "', " + 0 + ", " + 0 + ", " + row.Cells[4].Value + ", '" + txtFecha.Text + "', " + tipo + ", " + numero_evento + ", 1, '" + FrmLogin.usu + "', '" + row.Cells[10].Value + "')", conectar);
                        cmd.ExecuteNonQuery();


                        if (cantidad == 0)
                        {
                            row.Cells[0].Value = false;
                            cargo = 1;
                        }

                        // Actualizo el numero de credencial

                        credencial++;
                        conectar = Conexion.ObtenerConexion();

                        if (credencial > FrmLogin.credencial_hasta)
                        {
                            cmd = new MySqlCommand("UPDATE setup SET Credencial_Pupitres =" + FrmLogin.credencial_desde, conectar);
                            cmd.ExecuteNonQuery();
                            credencial = FrmLogin.credencial_desde;
                        }
                        else
                        {
                            cmd = new MySqlCommand("UPDATE setup SET Credencial_Pupitres =" + credencial, conectar);
                            cmd.ExecuteNonQuery();
                        }



                        // QR

                        if (imprimiqr.Checked == true)

                        {
                            cadena = Convert.ToString(numero_id) + "#" + Convert.ToString(row.Cells[3].Value) + "*" + Convert.ToString(row.Cells[4].Value).PadLeft(2, '0') + "0000" + "^" + txturl.Text;
                            QrCode qrCode = new QrCode();
                            qrEncoder.TryEncode(cadena, out qrCode);
                            GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.Black, Brushes.White);
                            MemoryStream ms = new MemoryStream();
                            renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
                            var imageTemporal = new Bitmap(ms);
                            var imagen = new Bitmap(imageTemporal, new Size(new Point(100, 100)));
                            panelResultado.BackgroundImage = imagen;

                            //     e.Graphics.DrawImage(panelResultado.BackgroundImage, 220, 470, 100, 100);
                            e.Graphics.DrawImage(panelResultado.BackgroundImage, 190, 490, 100, 100);

                        }

                        // Letras

                        // Rectangle rect27 = new Rectangle(240, 410, 390, 150);
                        // e.Graphics.DrawRectangle(Pens.White, rect27);
                        // e.Graphics.DrawString("SECTOR", new Font("Arial", 21), Brushes.Black, rect27, stringFormat);
                        Rectangle rect29 = new Rectangle(210, 470, 380, 100);
                        e.Graphics.DrawRectangle(Pens.White, rect29);
                        e.Graphics.DrawString(Convert.ToString(row.Cells[11].Value), new Font("Arial", 32), Brushes.Black, rect29, stringFormat);



                        if (cantidad == 0)
                        {
                            row.Cells[0].Value = false;
                            cargo = 1;
                        }

                        FrmLogin.CantRegImp--;
                        if (FrmLogin.CantRegImp != 0)
                        {
                            e.HasMorePages = true;
                            return;
                        }

                    }
                }


                foreach (DataGridViewRow row in dgvCabinas.Rows)
                {
                    row.Cells[5].Value = 1;
                }

                                         


                
                     
            }




            //// MOVIL ///////



            if (FrmPrincipal.movil == 1)

           {
                conectar = Conexion.ObtenerConexion();


                cmd = new MySqlCommand("SELECT Credencial_Moviles  FROM setup", conectar);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    credencial = dr.GetInt32(0);
                }
                dr.Close();


                while (buscocredencial == 2)
                {
                    Evento d = new Evento();
                    buscocredencial = d.buscarcredenciallibre(credencial, 3);
                    if (buscocredencial == 2)
                    {
                        credencial++;
                        if (credencial > FrmLogin.credencial_hasta)
                        {
                            credencial = FrmLogin.credencial_desde;
                        }
                    }

                }



                foreach (DataGridViewRow row in dgvMovil.Rows)
                {

                    if (Convert.ToBoolean(row.Cells[0].Value) == true)

                    {

                        tipo = 1;
                        row.Cells[4].Value = Convert.ToString(Convert.ToInt32(row.Cells[4].Value) - 1);
                        cantidad = Convert.ToInt32(row.Cells[4].Value);
                        cantidad_fija = cantidad + 1;
                        Rectangle rect3 = new Rectangle(300, 230, 290, 70);
                        e.Graphics.DrawRectangle(Pens.White, rect3);


                        // fila 1

                        Rectangle rect1 = new Rectangle(190, 87, 410, 45);




                        /////////// IMPRIMO CAMPEONATO ////////////
                        if (FrmLogin.negritacampeonato == 1)
                        {
                            e.Graphics.DrawString(Convert.ToString(txttorneo.Text), new Font(FrmLogin.nomfuentecampeonato, FrmLogin.sizecampeonato, FontStyle.Bold), Brushes.Black, rect1, stringFormat);
                        }
                        else
                        {
                            e.Graphics.DrawString(Convert.ToString(txttorneo.Text), new Font(FrmLogin.nomfuentecampeonato, FrmLogin.sizecampeonato), Brushes.Black, rect1, stringFormat);
                        }

                        /////////// IMPRIMO FECHA ////////////

                        Rectangle rect111 = new Rectangle(190, 107, 410, 45);
                        if (FrmLogin.negritafecha == 1)
                        {
                            e.Graphics.DrawString(txtfechanumero.Text, new Font(FrmLogin.nomfuentefecha, FrmLogin.sizefecha, FontStyle.Bold), Brushes.Black, rect111, stringFormat);
                        }
                        else
                        {
                            e.Graphics.DrawString(txtfechanumero.Text, new Font(FrmLogin.nomfuentefecha, FrmLogin.sizefecha), Brushes.Black, rect111, stringFormat);
                        }


                        Rectangle rect0 = new Rectangle(190, 130, 410, 45);


                        /////////// IMPRIMO RIVAL ////////////

                        if (FrmLogin.negritarival == 1)
                        {
                            e.Graphics.DrawString(Convert.ToString(row.Cells[2].Value), new Font(FrmLogin.nomfuenterival, FrmLogin.sizerival, FontStyle.Bold), Brushes.Black, rect0, stringFormat);
                        }
                        else
                        {
                            e.Graphics.DrawString(Convert.ToString(row.Cells[2].Value), new Font(FrmLogin.nomfuenterival, FrmLogin.sizerival), Brushes.Black, rect0, stringFormat);

                        }

                        Pen mipen = new Pen(Color.Black, 7);
                        e.Graphics.DrawLine(mipen, 170, 170, 630, 170);


                        // fila 2

                        Char delimiter = '-';
                        int num = 190;
                        String[] substrings = Convert.ToString(row.Cells[3].Value).Split(delimiter);
                        foreach (var substring in substrings)
                        {
                            Rectangle rect2 = new Rectangle(170, num, 430, 30);
                            e.Graphics.DrawRectangle(Pens.White, rect2);


                            /////////// IMPRIMO MEDIO ////////////

                            if (FrmLogin.negritamedio == 1)
                            {
                                e.Graphics.DrawString(substring, new Font(FrmLogin.nomfuentemedio, FrmLogin.sizemedio, FontStyle.Bold), Brushes.Black, rect2, stringFormat);
                            }
                            else
                            {
                                e.Graphics.DrawString(substring, new Font(FrmLogin.nomfuentemedio, FrmLogin.sizemedio), Brushes.Black, rect2, stringFormat);

                            }


                            num = num + 30;
                        }
                        Pen mipen1 = new Pen(Color.Black, 7);
                        e.Graphics.DrawLine(mipen1, 170, 260, 630, 260);



                        // fila 3

                        Rectangle rect22 = new Rectangle(200, 250, 390, 60);
                        e.Graphics.DrawRectangle(Pens.White, rect22);

                        /////////// IMPRIMO UBICACION ////////////





                        if (Convert.ToString(row.Cells[6].Value) != "")
                        {
                            Rectangle rect23 = new Rectangle(170, 340, 420, 60);
                            e.Graphics.DrawRectangle(Pens.White, rect23);
                            if (FrmLogin.negritanombre == 1)
                            {
                                e.Graphics.DrawString(Convert.ToString(row.Cells[6].Value), new Font(FrmLogin.nomfuentenombre, FrmLogin.sizenombre, FontStyle.Bold), Brushes.Black, rect23, stringFormat);
                                if (Convert.ToString(row.Cells[7].Value) != "")
                                {
                                    Rectangle rect6 = new Rectangle(170, 390, 420, 60);
                                    e.Graphics.DrawRectangle(Pens.White, rect6);
                                    e.Graphics.DrawString(Convert.ToString(row.Cells[7].Value), new Font(FrmLogin.nomfuentenombre, FrmLogin.sizenombre, FontStyle.Bold), Brushes.Black, rect6, stringFormat);
                                }
                                else
                                {
                                    e.Graphics.DrawString(Convert.ToString(row.Cells[6].Value), new Font(FrmLogin.nomfuentenombre, FrmLogin.sizenombre), Brushes.Black, rect23, stringFormat);
                                    if (Convert.ToString(row.Cells[7].Value) != "")
                                    {
                                        Rectangle rect6 = new Rectangle(170, 390, 420, 60);
                                        e.Graphics.DrawRectangle(Pens.White, rect6);
                                        e.Graphics.DrawString(Convert.ToString(row.Cells[7].Value), new Font(FrmLogin.nomfuentenombre, FrmLogin.sizenombre), Brushes.Black, rect6, stringFormat);


                                    }

                                }
                            }

                        }


                        //credencial


                        Rectangle rect12 = new Rectangle(370, 420, 390, 40);
                        e.Graphics.DrawRectangle(Pens.White, rect12);
                        e.Graphics.DrawString("Nº " + Convert.ToString(credencial).PadLeft(3, '0'), new Font("Arial Black", 14), Brushes.Black, rect12, stringFormat);

                        conectar = Conexion.ObtenerConexion();
                        Evento d = new Evento();
                        numero_evento = d.traigo_numero_evento();

                        cmd = new MySqlCommand("Insert into impresiones(Torneo, Evento, Medio, Cantidad, Nombre, DNI, Credencial, Asiento, Fila, Cabina, Fecha, Tipo, Id_Evento, Estado, Usuario, Letras) values('" + row.Cells[1].Value + "', '" + row.Cells[2].Value + "', '" + row.Cells[3].Value + "', '" + cantidad_fija + "', '" + row.Cells[6].Value + "', '" + row.Cells[7].Value + "', '" + credencial + "', " + 0 + ", " + 0 + ", " + row.Cells[4].Value + ", '" + txtFecha.Text + "', " + tipo + ", " + numero_evento + ", 1, '" + FrmLogin.usu + "', '" + row.Cells[9].Value + "')", conectar);
                        cmd.ExecuteNonQuery();


                        if (cantidad == 0)
                        {
                            row.Cells[0].Value = false;
                            cargo = 1;
                        }

                        // Actualizo el numero de credencial

                        credencial++;
                        conectar = Conexion.ObtenerConexion();

                        if (credencial > FrmLogin.credencial_hasta)
                        {
                            cmd = new MySqlCommand("UPDATE setup SET Credencial_Moviles =" + FrmLogin.credencial_desde, conectar);
                            cmd.ExecuteNonQuery();
                            credencial = FrmLogin.credencial_desde;
                        }
                        else
                        {
                            cmd = new MySqlCommand("UPDATE setup SET Credencial_Moviles =" + credencial, conectar);
                            cmd.ExecuteNonQuery();
                        }



                        // QR

                        if (imprimiqr.Checked == true)

                        {
                            cadena = Convert.ToString(numero_id) + "#" + Convert.ToString(row.Cells[3].Value) + "*" + Convert.ToString(row.Cells[4].Value).PadLeft(2, '0') + "0000" + "^" + txturl.Text;
                            QrCode qrCode = new QrCode();
                            qrEncoder.TryEncode(cadena, out qrCode);
                            GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.Black, Brushes.White);
                            MemoryStream ms = new MemoryStream();
                            renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
                            var imageTemporal = new Bitmap(ms);
                            var imagen = new Bitmap(imageTemporal, new Size(new Point(100, 100)));
                            panelResultado.BackgroundImage = imagen;

                            //     e.Graphics.DrawImage(panelResultado.BackgroundImage, 220, 470, 100, 100);
                            e.Graphics.DrawImage(panelResultado.BackgroundImage, 190, 490, 100, 100);

                        }

                        // Letras

                        // Rectangle rect27 = new Rectangle(240, 410, 390, 150);
                        // e.Graphics.DrawRectangle(Pens.White, rect27);
                        // e.Graphics.DrawString("SECTOR", new Font("Arial", 21), Brushes.Black, rect27, stringFormat);
                        Rectangle rect29 = new Rectangle(210, 470, 380, 100);
                        e.Graphics.DrawRectangle(Pens.White, rect29);
                        e.Graphics.DrawString(Convert.ToString(row.Cells[9].Value), new Font("Arial", 32), Brushes.Black, rect29, stringFormat);



                        if (cantidad == 0)
                        {
                            row.Cells[0].Value = false;
                            cargo = 1;
                        }

                        FrmLogin.CantRegImp--;
                        if (FrmLogin.CantRegImp != 0)
                        {
                            e.HasMorePages = true;
                            return;
                        }

                    }
                }


                foreach (DataGridViewRow row in dgvCabinas.Rows)
                {
                    row.Cells[5].Value = 1;
                }
            }


                    //// TV Movil 2 ///////

             if (FrmPrincipal.TV == 1)

                    {
                conectar = Conexion.ObtenerConexion();


                cmd = new MySqlCommand("SELECT Credencial_TV  FROM setup", conectar);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    credencial = dr.GetInt32(0);
                }
                dr.Close();


                while (buscocredencial == 2)
                {
                    Evento d = new Evento();
                    buscocredencial = d.buscarcredenciallibre(credencial, 4);
                    if (buscocredencial == 2)
                    {
                        credencial++;
                        if (credencial > FrmLogin.credencial_hasta)
                        {
                            credencial = FrmLogin.credencial_desde;
                        }
                    }

                }



                foreach (DataGridViewRow row in dgvMovil.Rows)
                {

                    if (Convert.ToBoolean(row.Cells[0].Value) == true)

                    {

                        tipo = 1;
                        row.Cells[4].Value = Convert.ToString(Convert.ToInt32(row.Cells[4].Value) - 1);
                        cantidad = Convert.ToInt32(row.Cells[4].Value);
                        cantidad_fija = cantidad + 1;
                        Rectangle rect3 = new Rectangle(300, 230, 290, 70);
                        e.Graphics.DrawRectangle(Pens.White, rect3);


                        // fila 1

                        Rectangle rect1 = new Rectangle(190, 87, 410, 45);




                        /////////// IMPRIMO CAMPEONATO ////////////
                        if (FrmLogin.negritacampeonato == 1)
                        {
                            e.Graphics.DrawString(Convert.ToString(txttorneo.Text), new Font(FrmLogin.nomfuentecampeonato, FrmLogin.sizecampeonato, FontStyle.Bold), Brushes.Black, rect1, stringFormat);
                        }
                        else
                        {
                            e.Graphics.DrawString(Convert.ToString(txttorneo.Text), new Font(FrmLogin.nomfuentecampeonato, FrmLogin.sizecampeonato), Brushes.Black, rect1, stringFormat);
                        }

                        /////////// IMPRIMO FECHA ////////////

                        Rectangle rect111 = new Rectangle(190, 107, 410, 45);
                        if (FrmLogin.negritafecha == 1)
                        {
                            e.Graphics.DrawString(txtfechanumero.Text, new Font(FrmLogin.nomfuentefecha, FrmLogin.sizefecha, FontStyle.Bold), Brushes.Black, rect111, stringFormat);
                        }
                        else
                        {
                            e.Graphics.DrawString(txtfechanumero.Text, new Font(FrmLogin.nomfuentefecha, FrmLogin.sizefecha), Brushes.Black, rect111, stringFormat);
                        }


                        Rectangle rect0 = new Rectangle(190, 130, 410, 45);


                        /////////// IMPRIMO RIVAL ////////////

                        if (FrmLogin.negritarival == 1)
                        {
                            e.Graphics.DrawString(Convert.ToString(row.Cells[2].Value), new Font(FrmLogin.nomfuenterival, FrmLogin.sizerival, FontStyle.Bold), Brushes.Black, rect0, stringFormat);
                        }
                        else
                        {
                            e.Graphics.DrawString(Convert.ToString(row.Cells[2].Value), new Font(FrmLogin.nomfuenterival, FrmLogin.sizerival), Brushes.Black, rect0, stringFormat);

                        }

                        Pen mipen = new Pen(Color.Black, 7);
                        e.Graphics.DrawLine(mipen, 170, 170, 630, 170);


                        // fila 2

                        Char delimiter = '-';
                        int num = 190;
                        String[] substrings = Convert.ToString(row.Cells[3].Value).Split(delimiter);
                        foreach (var substring in substrings)
                        {
                            Rectangle rect2 = new Rectangle(170, num, 430, 30);
                            e.Graphics.DrawRectangle(Pens.White, rect2);


                            /////////// IMPRIMO MEDIO ////////////

                            if (FrmLogin.negritamedio == 1)
                            {
                                e.Graphics.DrawString(substring, new Font(FrmLogin.nomfuentemedio, FrmLogin.sizemedio, FontStyle.Bold), Brushes.Black, rect2, stringFormat);
                            }
                            else
                            {
                                e.Graphics.DrawString(substring, new Font(FrmLogin.nomfuentemedio, FrmLogin.sizemedio), Brushes.Black, rect2, stringFormat);

                            }


                            num = num + 30;
                        }
                        Pen mipen1 = new Pen(Color.Black, 7);
                        e.Graphics.DrawLine(mipen1, 170, 260, 630, 260);



                        // fila 3

                        Rectangle rect22 = new Rectangle(200, 250, 390, 60);
                        e.Graphics.DrawRectangle(Pens.White, rect22);

                        /////////// IMPRIMO UBICACION ////////////



                        if (Convert.ToString(row.Cells[6].Value) != "")
                        {
                            Rectangle rect23 = new Rectangle(170, 340, 420, 60);
                            e.Graphics.DrawRectangle(Pens.White, rect23);
                            if (FrmLogin.negritanombre == 1)
                            {
                                e.Graphics.DrawString(Convert.ToString(row.Cells[6].Value), new Font(FrmLogin.nomfuentenombre, FrmLogin.sizenombre, FontStyle.Bold), Brushes.Black, rect23, stringFormat);
                                if (Convert.ToString(row.Cells[7].Value) != "")
                                {
                                    Rectangle rect6 = new Rectangle(170, 390, 420, 60);
                                    e.Graphics.DrawRectangle(Pens.White, rect6);
                                    e.Graphics.DrawString(Convert.ToString(row.Cells[7].Value), new Font(FrmLogin.nomfuentenombre, FrmLogin.sizenombre, FontStyle.Bold), Brushes.Black, rect6, stringFormat);
                                }
                                else
                                {
                                    e.Graphics.DrawString(Convert.ToString(row.Cells[6].Value), new Font(FrmLogin.nomfuentenombre, FrmLogin.sizenombre), Brushes.Black, rect23, stringFormat);
                                    if (Convert.ToString(row.Cells[7].Value) != "")
                                    {
                                        Rectangle rect6 = new Rectangle(170, 390, 420, 60);
                                        e.Graphics.DrawRectangle(Pens.White, rect6);
                                        e.Graphics.DrawString(Convert.ToString(row.Cells[7].Value), new Font(FrmLogin.nomfuentenombre, FrmLogin.sizenombre), Brushes.Black, rect6, stringFormat);


                                    }

                                }
                            }

                        }


                        //credencial


                        Rectangle rect12 = new Rectangle(370, 420, 390, 40);
                        e.Graphics.DrawRectangle(Pens.White, rect12);
                        e.Graphics.DrawString("Nº " + Convert.ToString(credencial).PadLeft(3, '0'), new Font("Arial Black", 14), Brushes.Black, rect12, stringFormat);

                        conectar = Conexion.ObtenerConexion();
                        Evento d = new Evento();
                        numero_evento = d.traigo_numero_evento();

                        cmd = new MySqlCommand("Insert into impresiones(Torneo, Evento, Medio, Cantidad, Nombre, DNI, Credencial, Asiento, Fila, Cabina, Fecha, Tipo, Id_Evento, Estado, Usuario, Letras) values('" + row.Cells[1].Value + "', '" + row.Cells[2].Value + "', '" + row.Cells[3].Value + "', '" + cantidad_fija + "', '" + row.Cells[5].Value + "', '" + row.Cells[6].Value + "', '" + credencial + "', " + 0 + ", " + 0 + ", " + row.Cells[4].Value + ", '" + txtFecha.Text + "', " + tipo + ", " + numero_evento + ", 1, '" + FrmLogin.usu + "', '" + row.Cells[9].Value + "')", conectar);
                        cmd.ExecuteNonQuery();


                        if (cantidad == 0)
                        {
                            row.Cells[0].Value = false;
                            cargo = 1;
                        }

                        // Actualizo el numero de credencial

                        credencial++;
                        conectar = Conexion.ObtenerConexion();

                        if (credencial > FrmLogin.credencial_hasta)
                        {
                            cmd = new MySqlCommand("UPDATE setup SET Credencial_TV =" + FrmLogin.credencial_desde, conectar);
                            cmd.ExecuteNonQuery();
                            credencial = FrmLogin.credencial_desde;
                        }
                        else
                        {
                            cmd = new MySqlCommand("UPDATE setup SET Credencial_TV =" + credencial, conectar);
                            cmd.ExecuteNonQuery();
                        }



                        // QR

                        if (imprimiqr.Checked == true)

                        {
                            cadena = Convert.ToString(numero_id) + "#" + Convert.ToString(row.Cells[3].Value) + "*" + Convert.ToString(row.Cells[4].Value).PadLeft(2, '0') + "0000" + "^" + txturl.Text;
                            QrCode qrCode = new QrCode();
                            qrEncoder.TryEncode(cadena, out qrCode);
                            GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.Black, Brushes.White);
                            MemoryStream ms = new MemoryStream();
                            renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
                            var imageTemporal = new Bitmap(ms);
                            var imagen = new Bitmap(imageTemporal, new Size(new Point(100, 100)));
                            panelResultado.BackgroundImage = imagen;

                            //     e.Graphics.DrawImage(panelResultado.BackgroundImage, 220, 470, 100, 100);
                            e.Graphics.DrawImage(panelResultado.BackgroundImage, 190, 490, 100, 100);

                        }

                        // Letras

                        // Rectangle rect27 = new Rectangle(240, 410, 390, 150);
                        // e.Graphics.DrawRectangle(Pens.White, rect27);
                        // e.Graphics.DrawString("SECTOR", new Font("Arial", 21), Brushes.Black, rect27, stringFormat);
                        Rectangle rect29 = new Rectangle(210, 470, 380, 100);
                        e.Graphics.DrawRectangle(Pens.White, rect29);
                        e.Graphics.DrawString(Convert.ToString(row.Cells[9].Value), new Font("Arial", 32), Brushes.Black, rect29, stringFormat);



                        if (cantidad == 0)
                        {
                            row.Cells[0].Value = false;
                            cargo = 1;
                        }

                        FrmLogin.CantRegImp--;
                        if (FrmLogin.CantRegImp != 0)
                        {
                            e.HasMorePages = true;
                            return;
                        }

                    }
                }


                foreach (DataGridViewRow row in dgvCabinas.Rows)
                {
                    row.Cells[5].Value = 1;
                }

            }


                    new Evento().Traigo_Numeros_Credenciales(lbCabinas, lbPupitre12, lbMovil, lbTV);

                    MessageBox.Show("Finalizo la Impresion");

               
            }
       
        

        private void button6_Click_1(object sender, EventArgs e)
        {
            string criterio = "";

            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
            criterio = "Select a.Id_Evento, a.Nombre_Evento, a.Campeonato, a.Fecha, a.url, a.Numero_Fecha, a.Rival, a.Id_Rival, a.Estado, b.Descripcion From eventos AS a INNER JOIN Estados AS b ON a.Estado = b.Estado ORDER BY a.Fecha DESC";
            new Importar().muestro_eventos(dgvEventos, criterio);
            groupBox1.Visible = true;
            System.Windows.Forms.Cursor.Current = Cursors.Default;
        }

        private void dgvEventos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtidevento.Text = Convert.ToString(this.dgvEventos.CurrentRow.Cells[3].Value);
            Id_eventos.Text = txtidevento.Text;

            estado_evento.Text = Convert.ToString(this.dgvEventos.CurrentRow.Cells[5].Value);
            new Evento().Traigo_Datos_Evento(txttorneo, txtevento, txturl, txtfechanumero, Id_eventos, lafecha, textIdRival, estado_evento);
            txtFecha.Text = Convert.ToDateTime(lafecha.Text).ToString("yyyy-MM-dd");
            groupBox1.Visible = false;
            button1.Enabled = true;
            txtidrival.Text = idrival.Text;
            Id_Evento.Text = txtidevento.Text;
            txtideventos= txtidevento.Text;
            if (Convert.ToInt32(Id_Evento.Text) > 0)
            {
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button10.Enabled = true;
                button4.Enabled = true;
                button11.Enabled = true;
            } 

        }

        private void button14_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;

        }

        private void dgvEventos_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void FrmCapturaDatos_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Default;
            button1.BackColor = Color.DeepSkyBlue;
            button2.BackColor = Color.DeepSkyBlue;
            button3.BackColor = Color.DeepSkyBlue;
            button10.BackColor = Color.DeepSkyBlue;
            button4.BackColor = Color.DeepSkyBlue;
            button11.BackColor = Color.DeepSkyBlue;
        }

        private void dgvDatos_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.Default; 
        }

        private void dgvMovil_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Id_Evento_Click(object sender, EventArgs e)
        {

        }

        private void txtidevento_TextChanged(object sender, EventArgs e)
        {

        }

        private void txturl_TextChanged(object sender, EventArgs e)
        {

        }

        private void printDocument3_PrintPage(object sender, PrintPageEventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(" Esta seguro que quiere imprimir los registros seleccionado ?", "Imprimir registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                PrinterSettings settings = new PrinterSettings();
                PaperSize paperSize = new PaperSize("A4", 210, 297);
                printDocument2.PrinterSettings.DefaultPageSettings.PaperSize = paperSize;

                if (FrmPrincipal.cabina == 1)
                {
                    Evento d = new Evento();
                    FrmLogin.CantRegImp = d.CantRegImp(dgvCabinas);
                }

                if (FrmPrincipal.movil == 1)
                {
                    Evento d = new Evento();
                    FrmLogin.CantRegImp = d.CantRegImp(dgvMovil);
                }

                if (FrmPrincipal.pupitre == 1)
                {
                    Evento d = new Evento();
                    FrmLogin.CantRegImp = d.CantRegImp(dgvPupitre);
                }

                if (FrmPrincipal.pupitre34 == 1)
                {
                    Evento d = new Evento();
                    FrmLogin.CantRegImp = d.CantRegImp(dgvPupitre);
                }
                if (FrmPrincipal.pupitre567 == 1)
                {
                    Evento d = new Evento();
                    FrmLogin.CantRegImp = d.CantRegImp(dgvPupitre);
                }

                if (FrmPrincipal.TV == 1)
                {
                    Evento d = new Evento();
                    FrmLogin.CantRegImp = d.CantRegImp(dgvMovil);
                }


                printDocument2.Print();
                //printPreviewDialog1.Document = printDocument1;
                //printPreviewDialog1.ShowDialog();



            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(" Esta seguro que quiere imprimir los registros seleccionado ?", "Imprimir registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                PrinterSettings settings = new PrinterSettings();
                PaperSize paperSize = new PaperSize("A4", 210, 297);
                printDocument3.PrinterSettings.DefaultPageSettings.PaperSize = paperSize;

                if (FrmPrincipal.cabina == 1)
                {
                    Evento d = new Evento();
                    FrmLogin.CantRegImp = d.CantRegImp(dgvCabinas);
                }

                if (FrmPrincipal.movil == 1)
                {
                    Evento d = new Evento();
                    FrmLogin.CantRegImp = d.CantRegImp(dgvMovil);
                }

                if (FrmPrincipal.pupitre == 1)
                {
                    Evento d = new Evento();
                    FrmLogin.CantRegImp = d.CantRegImp(dgvPupitre);
                }

                if (FrmPrincipal.pupitre34 == 1)
                {
                    Evento d = new Evento();
                    FrmLogin.CantRegImp = d.CantRegImp(dgvPupitre);
                }
                if (FrmPrincipal.pupitre567 == 1)
                {
                    Evento d = new Evento();
                    FrmLogin.CantRegImp = d.CantRegImp(dgvPupitre);
                }

                if (FrmPrincipal.TV == 1)
                {
                    Evento d = new Evento();
                    FrmLogin.CantRegImp = d.CantRegImp(dgvMovil);
                }


                printDocument3.Print();
                //printPreviewDialog1.Document = printDocument1;
                //printPreviewDialog1.ShowDialog();



            }
        }

        private void printDocument3_PrintPage_1(object sender, PrintPageEventArgs e)
        {
            Pen blackPen = new Pen(Color.Black, 3);

            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;



            QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);

            //QrCode qrCode1 = new QrCode();
            //qrEncoder.TryEncode(txtCredencial.Text, out qrCode1);

            string cadena = "";
            int cantidad = 0, cantidad_fija = 0, tipo = 0, numero_evento = 0, numero_id = 0;
            DateTime mihora = DateTime.Now;
            string lahora = mihora.ToString("yyyy-MM-dd");
            int credencial = 0, buscocredencial = 2;


            new Importar().Traigo_Configuracion_Evento(txtideventos);

           


                ////// CABINA ////////

                if (FrmPrincipal.cabina == 1)
                {

                    conectar = Conexion.ObtenerConexion();


                    cmd = new MySqlCommand("SELECT Credencial_Cabinas  FROM setup", conectar);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        credencial = dr.GetInt32(0);
                    }
                    dr.Close();


                    while (buscocredencial == 2)
                    {
                        Evento d = new Evento();
                        buscocredencial = d.buscarcredenciallibre(credencial, 1);
                        if (buscocredencial == 2)
                        {
                            credencial++;
                            if (credencial > FrmLogin.credencial_hasta)
                            {
                                credencial = FrmLogin.credencial_desde;
                            }
                        }

                    }





                    foreach (DataGridViewRow row in dgvCabinas.Rows)
                    {

                        if (Convert.ToBoolean(row.Cells[0].Value) == true)

                        {


                            tipo = 1;
                            row.Cells[5].Value = Convert.ToString(Convert.ToInt32(row.Cells[5].Value) - 1);
                            cantidad = Convert.ToInt32(row.Cells[5].Value);
                            cantidad_fija = cantidad + 1;
                            Rectangle rect3 = new Rectangle(320, 230, 290, 70);
                            e.Graphics.DrawRectangle(Pens.White, rect3);

                            //credencial


                            // Rectangle rect12 = new Rectangle(440, 390, 170, 40);
                            //  e.Graphics.DrawRectangle(Pens.White, rect12);
                            //   e.Graphics.DrawString(Convert.ToString(credencial).PadLeft(3, '0'), new Font("Arial Black", 14), Brushes.Black, rect12, stringFormat);


                            if (imprimiqr.Checked == true)

                            {

                                // Nombre y DNI


                                if (Convert.ToBoolean(row.Cells[9].Value) == true)
                                {
                                    e.Graphics.DrawString(Convert.ToString(row.Cells[6].Value), new Font("Arial Black", 14), Brushes.Black, rect3, stringFormat);
                                    if (Convert.ToString(row.Cells[7].Value) != "")
                                    {
                                        Rectangle rect6 = new Rectangle(320, 260, 290, 60);
                                        e.Graphics.DrawRectangle(Pens.White, rect6);
                                        e.Graphics.DrawString(Convert.ToString(row.Cells[7].Value), new Font("Arial Black", 14), Brushes.Black, rect6, stringFormat);
                                    }
                                    Rectangle rect4 = new Rectangle(320, 290, 290, 40);
                                    e.Graphics.DrawRectangle(Pens.White, rect4);
                                    e.Graphics.DrawString("CABINA Nº " + Convert.ToString(row.Cells[4].Value), new Font("Arial Black", 14), Brushes.Black, rect4, stringFormat);
                                }

                                else
                                {
                                    Rectangle rect4 = new Rectangle(320, 250, 290, 70);
                                    e.Graphics.DrawRectangle(Pens.White, rect4);
                                    e.Graphics.DrawString("CABINA Nº " + Convert.ToString(row.Cells[4].Value), new Font("Arial Black", 14), Brushes.Black, rect4, stringFormat);

                                }
                            }
                            else
                            {
                                // Nombre y DNI

                                Rectangle rect999 = new Rectangle(220, 230, 390, 70);
                                e.Graphics.DrawRectangle(Pens.White, rect999);
                                if (Convert.ToBoolean(row.Cells[9].Value) == true)
                                {
                                    e.Graphics.DrawString(Convert.ToString(row.Cells[6].Value), new Font("Arial Black", 14), Brushes.Black, rect999, stringFormat);
                                    if (Convert.ToString(row.Cells[7].Value) != "")
                                    {
                                        Rectangle rect6 = new Rectangle(220, 260, 390, 60);
                                        e.Graphics.DrawRectangle(Pens.White, rect6);
                                        e.Graphics.DrawString(Convert.ToString(row.Cells[7].Value), new Font("Arial Black", 14), Brushes.Black, rect6, stringFormat);
                                    }
                                    Rectangle rect4 = new Rectangle(220, 290, 390, 40);
                                    e.Graphics.DrawRectangle(Pens.White, rect4);
                                    e.Graphics.DrawString("CABINA Nº " + Convert.ToString(row.Cells[4].Value), new Font("Arial Black", 14), Brushes.Black, rect4, stringFormat);
                                }

                                else
                                {
                                    Rectangle rect4 = new Rectangle(220, 250, 390, 70);
                                    e.Graphics.DrawRectangle(Pens.White, rect4);
                                    e.Graphics.DrawString("CABINA Nº " + Convert.ToString(row.Cells[4].Value), new Font("Arial Black", 14), Brushes.Black, rect4, stringFormat);

                                }


                            }




                            Rectangle rect1 = new Rectangle(220, 90, 390, 45);
                            //       e.Graphics.DrawRectangle(Pens.Black, rect1);

                            e.Graphics.DrawString("FESTEJO DE", new Font("Arial Black", 15), Brushes.Black, rect1, stringFormat);

                            Rectangle rect0 = new Rectangle(220, 140, 390, 45);
                            //       e.Graphics.DrawRectangle(Pens.Black, rect0);
                            e.Graphics.DrawString("EL MAS GR4NDE DE LA HISTORIA", new Font(FrmLogin.nomfuente, FrmLogin.sizefuente), Brushes.Black, rect0, stringFormat);


                            if (imprimiqr.Checked == true)

                            {

                                Char delimiter = '-';
                                int num = 190;
                                String[] substrings = Convert.ToString(row.Cells[3].Value).Split(delimiter);
                                foreach (var substring in substrings)
                                {
                                    Rectangle rect2 = new Rectangle(320, num, 290, 30);
                                    e.Graphics.DrawRectangle(Pens.White, rect2);
                                    e.Graphics.DrawString(substring, new Font("Arial Black", 16), Brushes.Black, rect2, stringFormat);
                                    num = num + 30;
                                }

                            }
                            else
                            {
                                Char delimiter = '-';
                                int num = 190;
                                String[] substrings = Convert.ToString(row.Cells[3].Value).Split(delimiter);
                                foreach (var substring in substrings)
                                {
                                    Rectangle rect2 = new Rectangle(220, num, 390, 30);
                                    e.Graphics.DrawRectangle(Pens.White, rect2);
                                    e.Graphics.DrawString(substring, new Font("Arial Black", 18), Brushes.Black, rect2, stringFormat);
                                    num = num + 30;
                                }

                            }




                            //Rectangle rect5 = new Rectangle(200, 390, 390, 30);
                            // e.Graphics.DrawRectangle(Pens.White, rect5);

                            //    e.Graphics.DrawString(Convert.ToString(row.Cells[2].Value), new Font("Arial Black", 14), Brushes.Black, rect5, stringFormat);
                            //           float x11111 = 200.0F;
                            //          float y11111 = 352.0F;
                            //            float x22222 = 590.0F;
                            //            float y22222 = 352.0F;
                            //    e.Graphics.DrawLine(blackPen, x11111, y11111, x22222, y22222);

                            // Rectangle rect11 = new Rectangle(200, 200, 390, 230);
                            // e.Graphics.DrawRectangle(Pens.Black, rect11);




                            conectar = Conexion.ObtenerConexion();
                            Evento d = new Evento();
                            numero_evento = d.traigo_numero_evento();

                            cmd = new MySqlCommand("Insert into impresiones(Torneo, Evento, Medio, Cantidad, Nombre, DNI, Credencial, Asiento, Fila, Cabina, Fecha, Tipo, Id_Evento, Estado, Usuario) values('" + row.Cells[1].Value + "', '" + row.Cells[2].Value + "', '" + row.Cells[3].Value + "', '" + cantidad_fija + "', '" + row.Cells[6].Value + "', '" + row.Cells[7].Value + "', '" + credencial + "', " + 0 + ", " + 0 + ", " + row.Cells[4].Value + ", '" + txtFecha.Text + "', " + tipo + ", " + numero_evento + ", 1, '" + FrmLogin.usu + "')", conectar);
                            cmd.ExecuteNonQuery();


                            if (cantidad == 0)
                            {
                                row.Cells[0].Value = false;
                                cargo = 1;
                            }

                            // Actualizo el numero de credencial

                            credencial++;
                            conectar = Conexion.ObtenerConexion();

                            if (credencial > FrmLogin.credencial_hasta)
                            {
                                cmd = new MySqlCommand("UPDATE setup SET Credencial_Cabinas = " + FrmLogin.credencial_desde, conectar);
                                cmd.ExecuteNonQuery();
                                credencial = FrmLogin.credencial_desde;
                            }
                            else
                            {
                                cmd = new MySqlCommand("UPDATE setup SET Credencial_Cabinas =" + credencial, conectar);
                                cmd.ExecuteNonQuery();
                            }



                            if (imprimiqr.Checked == true)

                            {
                                // CODIGO QR

                                numero_id = d.traigo_ultimo_Id();

                                cadena = Convert.ToString(numero_id) + "#" + Convert.ToString(row.Cells[3].Value) + "*" + Convert.ToString(row.Cells[4].Value).PadLeft(2, '0') + "0000" + "^" + txturl.Text;
                                //cadena = txturl.Text + " " + Convert.ToString(numero_id);

                                QrCode qrCode = new QrCode();
                                qrEncoder.TryEncode(cadena, out qrCode);
                                GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.Black, Brushes.White);
                                MemoryStream ms = new MemoryStream();
                                renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
                                var imageTemporal = new Bitmap(ms);
                                var imagen = new Bitmap(imageTemporal, new Size(new Point(100, 100)));
                                panelResultado.BackgroundImage = imagen;

                                e.Graphics.DrawImage(panelResultado.BackgroundImage, 230, 190, 100, 100);

                            }

                            FrmLogin.CantRegImp--;
                            if (FrmLogin.CantRegImp != 0)
                            {
                                e.HasMorePages = true;
                                return;
                            }

                        }
                    }


                    foreach (DataGridViewRow row in dgvCabinas.Rows)
                    {
                        row.Cells[5].Value = 1;
                    }



                }


                //// PUPITRE ///////

                if (FrmPrincipal.pupitre == 1 | FrmPrincipal.pupitre34 == 1 | FrmPrincipal.pupitre567 == 1)

                {

                    conectar = Conexion.ObtenerConexion();


                    cmd = new MySqlCommand("SELECT Credencial_Pupitres FROM setup", conectar);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        credencial = dr.GetInt32(0);
                    }
                    dr.Close();


                    while (buscocredencial == 2)
                    {
                        Evento d = new Evento();
                        buscocredencial = d.buscarcredenciallibre(credencial, 2);
                        if (buscocredencial == 2)
                        {
                            credencial++;
                            if (credencial > FrmLogin.credencial_hasta)
                            {
                                credencial = FrmLogin.credencial_desde;
                            }
                        }

                    }



                    foreach (DataGridViewRow row in dgvPupitre.Rows)
                    {

                        if (Convert.ToBoolean(row.Cells[0].Value) == true)

                        {

                            tipo = 2;
                            row.Cells[6].Value = Convert.ToString(Convert.ToInt32(row.Cells[6].Value) - 1);
                            cantidad = Convert.ToInt32(row.Cells[6].Value);
                            cantidad_fija = cantidad + 1;
                            Rectangle rect3 = new Rectangle(320, 230, 290, 70);
                            e.Graphics.DrawRectangle(Pens.White, rect3);

                            //credencial


                            //    Rectangle rect12 = new Rectangle(440, 410, 170, 40);
                            //    e.Graphics.DrawRectangle(Pens.White, rect12);
                            //    e.Graphics.DrawString(Convert.ToString(credencial).PadLeft(3, '0'), new Font("Arial Black", 14), Brushes.Black, rect12, stringFormat);



                            if (imprimiqr.Checked == true)

                            {


                                // Nombre y DNI


                                if (Convert.ToBoolean(row.Cells[10].Value) == true)
                                {
                                    e.Graphics.DrawString(Convert.ToString(row.Cells[7].Value), new Font("Arial Black", 14), Brushes.Black, rect3, stringFormat);
                                    if (Convert.ToString(row.Cells[8].Value) != "")
                                    {
                                        Rectangle rect6 = new Rectangle(320, 250, 290, 70);
                                        e.Graphics.DrawRectangle(Pens.White, rect6);
                                        e.Graphics.DrawString(Convert.ToString(row.Cells[8].Value), new Font("Arial Black", 14), Brushes.Black, rect6, stringFormat);
                                    }
                                    Rectangle rect4 = new Rectangle(320, 290, 290, 40);
                                    e.Graphics.DrawRectangle(Pens.White, rect4);
                                    e.Graphics.DrawString("FILA Nº " + Convert.ToString(row.Cells[4].Value) + " ASIENTO Nº " + Convert.ToString(row.Cells[5].Value), new Font("Arial Black", 14), Brushes.Black, rect4, stringFormat);
                                }



                                else
                                {
                                    Rectangle rect4 = new Rectangle(320, 250, 290, 70);
                                    e.Graphics.DrawRectangle(Pens.White, rect4);
                                    e.Graphics.DrawString("FILA Nº " + Convert.ToString(row.Cells[4].Value) + " ASIENTO Nº " + Convert.ToString(row.Cells[5].Value), new Font("Arial Black", 14), Brushes.Black, rect4, stringFormat);

                                }


                            }
                            else
                            {

                                // Nombre y DNI

                                Rectangle rect999 = new Rectangle(220, 230, 390, 70);
                                e.Graphics.DrawRectangle(Pens.White, rect999);
                                if (Convert.ToBoolean(row.Cells[10].Value) == true)
                                {
                                    e.Graphics.DrawString(Convert.ToString(row.Cells[7].Value), new Font("Arial Black", 14), Brushes.Black, rect999, stringFormat);
                                    if (Convert.ToString(row.Cells[8].Value) != "")
                                    {
                                        Rectangle rect6 = new Rectangle(220, 250, 390, 70);
                                        e.Graphics.DrawRectangle(Pens.White, rect6);
                                        e.Graphics.DrawString(Convert.ToString(row.Cells[8].Value), new Font("Arial Black", 14), Brushes.Black, rect6, stringFormat);
                                    }
                                    Rectangle rect4 = new Rectangle(220, 290, 390, 40);
                                    e.Graphics.DrawRectangle(Pens.White, rect4);
                                    e.Graphics.DrawString("FILA Nº " + Convert.ToString(row.Cells[4].Value) + " ASIENTO Nº " + Convert.ToString(row.Cells[5].Value), new Font("Arial Black", 14), Brushes.Black, rect4, stringFormat);
                                }



                                else
                                {
                                    Rectangle rect4 = new Rectangle(220, 250, 390, 70);
                                    e.Graphics.DrawRectangle(Pens.White, rect4);
                                    e.Graphics.DrawString("FILA Nº " + Convert.ToString(row.Cells[4].Value) + " ASIENTO Nº " + Convert.ToString(row.Cells[5].Value), new Font("Arial Black", 14), Brushes.Black, rect4, stringFormat);

                                }







                            }




                            Rectangle rect1 = new Rectangle(220, 90, 390, 45);
                            //       e.Graphics.DrawRectangle(Pens.Black, rect1);

                            e.Graphics.DrawString("FESTEJO DE", new Font("Arial Black", 15), Brushes.Black, rect1, stringFormat);

                            Rectangle rect0 = new Rectangle(220, 140, 390, 45);
                            //       e.Graphics.DrawRectangle(Pens.Black, rect0);
                            e.Graphics.DrawString("EL MAS GR4NDE DE LA HISTORIA", new Font(FrmLogin.nomfuente, FrmLogin.sizefuente), Brushes.Black, rect0, stringFormat);

                            //MEDIO


                            if (imprimiqr.Checked == true)

                            {
                                Char delimiter = '-';
                                int num = 190;
                                String[] substrings = Convert.ToString(row.Cells[3].Value).Split(delimiter);
                                foreach (var substring in substrings)
                                {
                                    Rectangle rect2 = new Rectangle(320, num, 290, 30);
                                    e.Graphics.DrawRectangle(Pens.White, rect2);
                                    e.Graphics.DrawString(substring, new Font("Arial Black", 16), Brushes.Black, rect2, stringFormat);
                                    num = num + 30;
                                }

                            }
                            else
                            {

                                Char delimiter = '-';
                                int num = 190;
                                String[] substrings = Convert.ToString(row.Cells[3].Value).Split(delimiter);
                                foreach (var substring in substrings)
                                {
                                    Rectangle rect2 = new Rectangle(220, num, 390, 30);
                                    e.Graphics.DrawRectangle(Pens.White, rect2);
                                    e.Graphics.DrawString(substring, new Font("Arial Black", 18), Brushes.Black, rect2, stringFormat);
                                    num = num + 30;
                                }






                            }


                            //Rectangle rect5 = new Rectangle(300, 410, 390, 30);
                            //e.Graphics.DrawRectangle(Pens.White, rect5);

                            //    e.Graphics.DrawString(Convert.ToString(row.Cells[2].Value), new Font("Arial Black", 14), Brushes.Black, rect5, stringFormat);
                            //    float x11111 = 200.0F;
                            //    float y11111 = 352.0F;
                            //    float x22222 = 590.0F;
                            //   e.Graphics.DrawLine(blackPen, x11111, y11
                            //    float y22222 = 352.0F;111, x22222, y22222);



                            //CUADRO CENTRAL
                            //  Rectangle rect11 = new Rectangle(200, 180, 390, 230);
                            //   e.Graphics.DrawRectangle(Pens.Black, rect11);


                            conectar = Conexion.ObtenerConexion();

                            Evento d = new Evento();
                            numero_evento = d.traigo_numero_evento();

                            cmd = new MySqlCommand("Insert into impresiones(Torneo, Evento, Medio, Cantidad, Nombre, DNI, Credencial, Asiento, Fila, Cabina, Fecha, Tipo, Id_Evento, Estado, Usuario ) values('" + row.Cells[1].Value + "', '" + row.Cells[2].Value + "', '" + row.Cells[3].Value + "', '" + cantidad_fija + "', '" + row.Cells[7].Value + "', '" + row.Cells[8].Value + "', '" + credencial + "', " + row.Cells[5].Value + ", " + row.Cells[4].Value + ", " + 0 + ", '" + txtFecha.Text + "', " + tipo + ", " + numero_evento + ", 1, '" + FrmLogin.usu + "')", conectar);
                            cmd.ExecuteNonQuery();


                            if (cantidad == 0)
                            {

                                row.Cells[0].Value = false;
                                cargo = 1;
                            }

                            // Actualizo el numero de credencial
                            credencial++;
                            conectar = Conexion.ObtenerConexion();

                            if (credencial > FrmLogin.credencial_hasta)
                            {
                                cmd = new MySqlCommand("UPDATE setup SET Credencial_Pupitres = " + FrmLogin.credencial_desde, conectar);
                                cmd.ExecuteNonQuery();
                                credencial = 1;
                            }
                            else
                            {
                                cmd = new MySqlCommand("UPDATE setup SET Credencial_Pupitres =" + credencial, conectar);
                                cmd.ExecuteNonQuery();
                            }

                            if (imprimiqr.Checked == true)

                            {
                                // CODIGO QR

                                numero_id = d.traigo_ultimo_Id();

                                cadena = Convert.ToString(numero_id) + "#" + Convert.ToString(row.Cells[3].Value) + "*" + "00" + string.Format("{00}", Convert.ToString(row.Cells[4].Value)) + Convert.ToString(row.Cells[5].Value).PadLeft(2, '0') + "^" + txturl.Text; ;
                                //cadena = txturl.Text + " " + Convert.ToString(numero_id);


                                QrCode qrCode = new QrCode();
                                qrEncoder.TryEncode(cadena, out qrCode);
                                GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.Black, Brushes.White);
                                MemoryStream ms = new MemoryStream();
                                renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
                                var imageTemporal = new Bitmap(ms);
                                var imagen = new Bitmap(imageTemporal, new Size(new Point(100, 100)));
                                panelResultado.BackgroundImage = imagen;

                                e.Graphics.DrawImage(panelResultado.BackgroundImage, 230, 190, 100, 100);

                            }


                            FrmLogin.CantRegImp--;
                            if (FrmLogin.CantRegImp != 0)
                            {
                                e.HasMorePages = true;
                                return;
                            }



                        }
                    }

                    foreach (DataGridViewRow row in dgvPupitre.Rows)
                    {
                        row.Cells[6].Value = 1;
                    }

                }

                //// MOVIL ///////

                if (FrmPrincipal.movil == 1)

                {
                    conectar = Conexion.ObtenerConexion();


                    cmd = new MySqlCommand("SELECT Credencial_Moviles FROM setup", conectar);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        credencial = dr.GetInt32(0);
                    }
                    dr.Close();


                    while (buscocredencial == 2)
                    {
                        Evento d = new Evento();
                        buscocredencial = d.buscarcredenciallibre(credencial, 3);
                        if (buscocredencial == 2)
                        {
                            credencial++;
                            if (credencial > FrmLogin.credencial_hasta)
                            {
                                credencial = FrmLogin.credencial_desde;
                            }
                        }

                    }



                    foreach (DataGridViewRow row in dgvMovil.Rows)
                    {

                        if (Convert.ToBoolean(row.Cells[0].Value) == true)

                            if (Convert.ToBoolean(row.Cells[0].Value) == true)

                            {

                                tipo = 3;
                                row.Cells[4].Value = Convert.ToString(Convert.ToInt32(row.Cells[4].Value) - 1);
                                cantidad = Convert.ToInt32(row.Cells[4].Value);
                                cantidad_fija = cantidad + 1;
                                Rectangle rect3 = new Rectangle(320, 210, 290, 70);
                                e.Graphics.DrawRectangle(Pens.White, rect3);

                                //credencial


                                //        Rectangle rect12 = new Rectangle(440, 410, 170, 40);
                                //        e.Graphics.DrawRectangle(Pens.White, rect12);
                                //        e.Graphics.DrawString(Convert.ToString(credencial).PadLeft(3, '0'), new Font("Arial Black", 14), Brushes.Black, rect12, stringFormat);



                                if (imprimiqr.Checked == true)

                                {
                                    // Nombre y DNI
                                    if (Convert.ToBoolean(row.Cells[8].Value) == true)

                                    {

                                        e.Graphics.DrawString(Convert.ToString(row.Cells[5].Value), new Font("Arial Black", 14), Brushes.Black, rect3, stringFormat);
                                        if (Convert.ToString(row.Cells[6].Value) != "")
                                        {
                                            Rectangle rect6 = new Rectangle(320, 230, 290, 70);
                                            e.Graphics.DrawRectangle(Pens.White, rect6);
                                            e.Graphics.DrawString(Convert.ToString(row.Cells[6].Value), new Font("Arial Black", 14), Brushes.Black, rect6, stringFormat);

                                        }

                                        Rectangle rect4 = new Rectangle(300, 270, 290, 40);
                                        e.Graphics.DrawRectangle(Pens.White, rect4);
                                        e.Graphics.DrawString("MOVIL", new Font("Arial Black", 17), Brushes.Black, rect4, stringFormat);
                                        Rectangle rect99 = new Rectangle(300, 290, 290, 40);
                                        e.Graphics.DrawRectangle(Pens.White, rect99);
                                        e.Graphics.DrawString("ACCESO A DESIGNAR", new Font("Arial Black", 15), Brushes.Black, rect99, stringFormat);


                                    }
                                    else
                                    {
                                        Rectangle rect4 = new Rectangle(300, 270, 290, 40);
                                        e.Graphics.DrawRectangle(Pens.White, rect4);
                                        e.Graphics.DrawString("MOVIL", new Font("Arial Black", 17), Brushes.Black, rect4, stringFormat);
                                        Rectangle rect99 = new Rectangle(300, 290, 290, 40);
                                        e.Graphics.DrawRectangle(Pens.White, rect99);
                                        e.Graphics.DrawString("ACCESO A DESIGNAR", new Font("Arial Black", 15), Brushes.Black, rect99, stringFormat);


                                    }

                                }
                                else
                                {

                                    // Nombre y DNI

                                    Rectangle rect999 = new Rectangle(220, 210, 390, 70);
                                    e.Graphics.DrawRectangle(Pens.White, rect999);
                                    if (Convert.ToBoolean(row.Cells[8].Value) == true)

                                    {

                                        e.Graphics.DrawString(Convert.ToString(row.Cells[5].Value), new Font("Arial Black", 14), Brushes.Black, rect999, stringFormat);
                                        if (Convert.ToString(row.Cells[6].Value) != "")
                                        {
                                            Rectangle rect6 = new Rectangle(220, 230, 390, 70);
                                            e.Graphics.DrawRectangle(Pens.White, rect6);
                                            e.Graphics.DrawString(Convert.ToString(row.Cells[6].Value), new Font("Arial Black", 14), Brushes.Black, rect6, stringFormat);

                                        }

                                        Rectangle rect4 = new Rectangle(220, 270, 390, 40);
                                        e.Graphics.DrawRectangle(Pens.White, rect4);
                                        e.Graphics.DrawString("MOVIL", new Font("Arial Black", 17), Brushes.Black, rect4, stringFormat);
                                        Rectangle rect99 = new Rectangle(220, 290, 390, 40);
                                        e.Graphics.DrawRectangle(Pens.White, rect99);
                                        e.Graphics.DrawString("ACCESO A DESIGNAR", new Font("Arial Black", 15), Brushes.Black, rect99, stringFormat);


                                    }
                                    else
                                    {
                                        Rectangle rect4 = new Rectangle(220, 270, 390, 40);
                                        e.Graphics.DrawRectangle(Pens.White, rect4);
                                        e.Graphics.DrawString("MOVIL", new Font("Arial Black", 17), Brushes.Black, rect4, stringFormat);
                                        Rectangle rect99 = new Rectangle(220, 290, 390, 40);
                                        e.Graphics.DrawRectangle(Pens.White, rect99);
                                        e.Graphics.DrawString("ACCESO A DESIGNAR", new Font("Arial Black", 15), Brushes.Black, rect99, stringFormat);


                                    }






                                }



                                Rectangle rect1 = new Rectangle(220, 90, 390, 45);
                                //       e.Graphics.DrawRectangle(Pens.Black, rect1);

                                e.Graphics.DrawString("FESTEJO DE", new Font("Arial Black", 15), Brushes.Black, rect1, stringFormat);

                                Rectangle rect0 = new Rectangle(220, 140, 390, 45);
                                //       e.Graphics.DrawRectangle(Pens.Black, rect0);
                                e.Graphics.DrawString("EL MAS GR4NDE DE LA HISTORIA", new Font(FrmLogin.nomfuente, FrmLogin.sizefuente), Brushes.Black, rect0, stringFormat);


                                //MEDIO

                                if (imprimiqr.Checked == true)

                                {
                                    Char delimiter = '-';
                                    int num = 180;
                                    String[] substrings = Convert.ToString(row.Cells[3].Value).Split(delimiter);
                                    foreach (var substring in substrings)
                                    {
                                        Rectangle rect2 = new Rectangle(320, num, 290, 30);
                                        e.Graphics.DrawRectangle(Pens.White, rect2);
                                        e.Graphics.DrawString(substring, new Font("Arial Black", 16), Brushes.Black, rect2, stringFormat);
                                        num = num + 30;
                                    }
                                }
                                else
                                {
                                    Char delimiter = '-';
                                    int num = 180;
                                    String[] substrings = Convert.ToString(row.Cells[3].Value).Split(delimiter);
                                    foreach (var substring in substrings)
                                    {
                                        Rectangle rect2 = new Rectangle(220, num, 390, 30);
                                        e.Graphics.DrawRectangle(Pens.White, rect2);
                                        e.Graphics.DrawString(substring, new Font("Arial Black", 18), Brushes.Black, rect2, stringFormat);
                                        num = num + 30;
                                    }




                                }


                                //Rectangle rect5 = new Rectangle(200, 410, 390, 30);
                                // e.Graphics.DrawRectangle(Pens.White, rect5);

                                //    e.Graphics.DrawString(Convert.ToString(row.Cells[2].Value), new Font("Arial Black", 14), Brushes.Black, rect5, stringFormat);
                                // float x11111 = 200.0F;
                                //   float y11111 = 352.0F;
                                //    float x22222 = 590.0F;
                                //     float y22222 = 352.0F;
                                //     e.Graphics.DrawLine(blackPen, x11111, y11111, x22222, y22222);

                                //     Rectangle rect11 = new Rectangle(200, 180, 390, 230);
                                //     e.Graphics.DrawRectangle(Pens.Black, rect11);


                                conectar = Conexion.ObtenerConexion();

                                Evento d = new Evento();
                                numero_evento = d.traigo_numero_evento();


                                cmd = new MySqlCommand("Insert into impresiones(Torneo, Evento, Medio, Cantidad, Nombre, DNI, Credencial, Asiento, Fila, Cabina, Fecha, Tipo, Id_Evento, Estado, Usuario) values('" + row.Cells[1].Value + "', '" + row.Cells[2].Value + "', '" + row.Cells[3].Value + "', '" + cantidad_fija + "', '" + row.Cells[5].Value + "', '" + row.Cells[6].Value + "', " + credencial + ", " + 0 + ", " + 0 + ", " + 0 + ", '" + txtFecha.Text + "', " + tipo + ", " + numero_evento + ", 1, '" + FrmLogin.usu + "')", conectar);
                                cmd.ExecuteNonQuery();



                                if (cantidad == 0)
                                {
                                    row.Cells[0].Value = false;
                                    cargo = 1;
                                }

                                // Actualizo el numero de credencial
                                credencial++;
                                conectar = Conexion.ObtenerConexion();

                                if (credencial > FrmLogin.credencial_hasta)
                                {
                                    cmd = new MySqlCommand("UPDATE setup SET Credencial_Moviles = " + FrmLogin.credencial_desde, conectar);
                                    cmd.ExecuteNonQuery();
                                    credencial = FrmLogin.credencial_desde;
                                }
                                else
                                {
                                    cmd = new MySqlCommand("UPDATE setup SET Credencial_Moviles =" + credencial, conectar);
                                    cmd.ExecuteNonQuery();
                                }


                                if (imprimiqr.Checked == true)

                                {
                                    // CODIGO QR

                                    numero_id = d.traigo_ultimo_Id();

                                    cadena = Convert.ToString(numero_id) + "#" + Convert.ToString(row.Cells[3].Value) + "*" + "000000" + "^" + txturl.Text;
                                    //cadena = txturl.Text + " " + Convert.ToString(numero_id);

                                    QrCode qrCode = new QrCode();
                                    qrEncoder.TryEncode(cadena, out qrCode);
                                    GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.Black, Brushes.White);
                                    MemoryStream ms = new MemoryStream();
                                    renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
                                    var imageTemporal = new Bitmap(ms);
                                    var imagen = new Bitmap(imageTemporal, new Size(new Point(100, 100)));
                                    panelResultado.BackgroundImage = imagen;

                                    e.Graphics.DrawImage(panelResultado.BackgroundImage, 230, 190, 100, 100);

                                }

                                FrmLogin.CantRegImp--;
                                if (FrmLogin.CantRegImp != 0)
                                {
                                    e.HasMorePages = true;
                                    return;
                                }



                            }
                    }

                    foreach (DataGridViewRow row in dgvMovil.Rows)
                    {
                        row.Cells[4].Value = 1;
                    }

                }


                //// TV Movil 2 ///////

                if (FrmPrincipal.TV == 1)

                {
                    conectar = Conexion.ObtenerConexion();


                    cmd = new MySqlCommand("SELECT Credencial_Moviles FROM setup", conectar);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        credencial = dr.GetInt32(0);
                    }
                    dr.Close();


                    while (buscocredencial == 2)
                    {
                        Evento d = new Evento();
                        buscocredencial = d.buscarcredenciallibre(credencial, 3);
                        if (buscocredencial == 2)
                        {
                            credencial++;
                            if (credencial > FrmLogin.credencial_hasta)
                            {
                                credencial = FrmLogin.credencial_desde;
                            }
                        }

                    }



                    foreach (DataGridViewRow row in dgvMovil.Rows)
                    {

                        if (Convert.ToBoolean(row.Cells[0].Value) == true)

                            if (Convert.ToBoolean(row.Cells[0].Value) == true)

                            {

                                tipo = 4;
                                row.Cells[4].Value = Convert.ToString(Convert.ToInt32(row.Cells[4].Value) - 1);
                                cantidad = Convert.ToInt32(row.Cells[4].Value);
                                cantidad_fija = cantidad + 1;
                                Rectangle rect3 = new Rectangle(320, 230, 290, 70);
                                e.Graphics.DrawRectangle(Pens.White, rect3);

                                //credencial


                                //        Rectangle rect12 = new Rectangle(440, 410, 170, 40);
                                //        e.Graphics.DrawRectangle(Pens.White, rect12);
                                //        e.Graphics.DrawString(Convert.ToString(credencial).PadLeft(3, '0'), new Font("Arial Black", 14), Brushes.Black, rect12, stringFormat);



                                if (imprimiqr.Checked == true)

                                {
                                    // Nombre y DNI
                                    if (Convert.ToBoolean(row.Cells[8].Value) == true)

                                    {

                                        e.Graphics.DrawString(Convert.ToString(row.Cells[5].Value), new Font("Arial Black", 14), Brushes.Black, rect3, stringFormat);
                                        if (Convert.ToString(row.Cells[6].Value) != "")
                                        {
                                            Rectangle rect6 = new Rectangle(320, 250, 290, 70);
                                            e.Graphics.DrawRectangle(Pens.White, rect6);
                                            e.Graphics.DrawString(Convert.ToString(row.Cells[6].Value), new Font("Arial Black", 14), Brushes.Black, rect6, stringFormat);
                                        }

                                        Rectangle rect4 = new Rectangle(320, 290, 290, 40);
                                        e.Graphics.DrawRectangle(Pens.White, rect4);
                                        e.Graphics.DrawString("MOVIL", new Font("Arial Black", 17), Brushes.Black, rect4, stringFormat);



                                    }
                                    else

                                    {
                                        Rectangle rect4 = new Rectangle(320, 290, 290, 40);
                                        e.Graphics.DrawRectangle(Pens.White, rect4);
                                        e.Graphics.DrawString("MOVIL", new Font("Arial Black", 17), Brushes.Black, rect4, stringFormat);


                                    }
                                }
                                else
                                {

                                    // Nombre y DNI

                                    Rectangle rect999 = new Rectangle(220, 230, 390, 70);
                                    e.Graphics.DrawRectangle(Pens.White, rect999);
                                    if (Convert.ToBoolean(row.Cells[8].Value) == true)

                                    {

                                        e.Graphics.DrawString(Convert.ToString(row.Cells[5].Value), new Font("Arial Black", 14), Brushes.Black, rect999, stringFormat);
                                        if (Convert.ToString(row.Cells[6].Value) != "")
                                        {
                                            Rectangle rect6 = new Rectangle(220, 250, 390, 70);
                                            e.Graphics.DrawRectangle(Pens.White, rect6);
                                            e.Graphics.DrawString(Convert.ToString(row.Cells[6].Value), new Font("Arial Black", 14), Brushes.Black, rect6, stringFormat);
                                        }

                                        Rectangle rect4 = new Rectangle(220, 290, 390, 40);
                                        e.Graphics.DrawRectangle(Pens.White, rect4);
                                        e.Graphics.DrawString("MOVIL", new Font("Arial Black", 17), Brushes.Black, rect4, stringFormat);



                                    }
                                    else

                                    {
                                        Rectangle rect4 = new Rectangle(220, 290, 390, 40);
                                        e.Graphics.DrawRectangle(Pens.White, rect4);
                                        e.Graphics.DrawString("MOVIL", new Font("Arial Black", 17), Brushes.Black, rect4, stringFormat);


                                    }





                                }



                                Rectangle rect1 = new Rectangle(220, 90, 390, 45);
                                //       e.Graphics.DrawRectangle(Pens.Black, rect1);

                                e.Graphics.DrawString("FESTEJO DE", new Font("Arial Black", 15), Brushes.Black, rect1, stringFormat);

                                Rectangle rect0 = new Rectangle(220, 140, 390, 45);
                                //       e.Graphics.DrawRectangle(Pens.Black, rect0);
                                e.Graphics.DrawString("EL MAS GR4NDE DE LA HISTORIA", new Font(FrmLogin.nomfuente, FrmLogin.sizefuente), Brushes.Black, rect0, stringFormat);


                                //MEDIO

                                if (imprimiqr.Checked == true)

                                {
                                    Char delimiter = '-';
                                    int num = 190;
                                    String[] substrings = Convert.ToString(row.Cells[3].Value).Split(delimiter);
                                    foreach (var substring in substrings)
                                    {
                                        Rectangle rect2 = new Rectangle(320, num, 290, 30);
                                        e.Graphics.DrawRectangle(Pens.White, rect2);
                                        e.Graphics.DrawString(substring, new Font("Arial Black", 16), Brushes.Black, rect2, stringFormat);
                                        num = num + 30;
                                    }


                                }
                                else
                                {
                                    Char delimiter = '-';
                                    int num = 190;
                                    String[] substrings = Convert.ToString(row.Cells[3].Value).Split(delimiter);
                                    foreach (var substring in substrings)
                                    {
                                        Rectangle rect2 = new Rectangle(220, num, 390, 30);
                                        e.Graphics.DrawRectangle(Pens.White, rect2);
                                        e.Graphics.DrawString(substring, new Font("Arial Black", 18), Brushes.Black, rect2, stringFormat);
                                        num = num + 30;
                                    }



                                }


                                //Rectangle rect5 = new Rectangle(200, 410, 390, 30);
                                // e.Graphics.DrawRectangle(Pens.White, rect5);


                                //    e.Graphics.DrawString(Convert.ToString(row.Cells[2].Value), new Font("Arial Black", 14), Brushes.Black, rect5, stringFormat);
                                // float x11111 = 200.0F;
                                //   float y11111 = 352.0F;
                                //    float x22222 = 590.0F;
                                //     float y22222 = 352.0F;
                                //     e.Graphics.DrawLine(blackPen, x11111, y11111, x22222, y22222);

                                //     Rectangle rect11 = new Rectangle(200, 180, 390, 230);
                                //     e.Graphics.DrawRectangle(Pens.Black, rect11);


                                conectar = Conexion.ObtenerConexion();

                                Evento d = new Evento();
                                numero_evento = d.traigo_numero_evento();


                                cmd = new MySqlCommand("Insert into impresiones(Torneo, Evento, Medio, Cantidad, Nombre, DNI, Credencial, Asiento, Fila, Cabina, Fecha, Tipo, Id_Evento, Estado, Usuario) values('" + row.Cells[1].Value + "', '" + row.Cells[2].Value + "', '" + row.Cells[3].Value + "', '" + cantidad_fija + "', '" + row.Cells[5].Value + "', '" + row.Cells[6].Value + "', " + credencial + ", " + 0 + ", " + 0 + ", " + 0 + ", '" + txtFecha.Text + "', " + tipo + ", " + numero_evento + ", 1, '" + FrmLogin.usu + "')", conectar);
                                cmd.ExecuteNonQuery();



                                if (cantidad == 0)
                                {
                                    row.Cells[0].Value = false;
                                    cargo = 1;
                                }

                                // Actualizo el numero de credencial
                                credencial++;
                                conectar = Conexion.ObtenerConexion();

                                if (credencial > FrmLogin.credencial_hasta)
                                {
                                    cmd = new MySqlCommand("UPDATE setup SET Credencial_Moviles = " + FrmLogin.credencial_desde, conectar);
                                    cmd.ExecuteNonQuery();
                                    credencial = FrmLogin.credencial_desde;
                                }
                                else
                                {
                                    cmd = new MySqlCommand("UPDATE setup SET Credencial_Moviles =" + credencial, conectar);
                                    cmd.ExecuteNonQuery();
                                }


                                if (imprimiqr.Checked == true)

                                {
                                    // CODIGO QR

                                    numero_id = d.traigo_ultimo_Id();

                                    cadena = Convert.ToString(numero_id) + "#" + Convert.ToString(row.Cells[3].Value) + "*" + "000000" + "^" + txturl.Text;
                                    //cadena = txturl.Text + " " + Convert.ToString(numero_id);


                                    QrCode qrCode = new QrCode();
                                    qrEncoder.TryEncode(cadena, out qrCode);
                                    GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.Black, Brushes.White);
                                    MemoryStream ms = new MemoryStream();
                                    renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
                                    var imageTemporal = new Bitmap(ms);
                                    var imagen = new Bitmap(imageTemporal, new Size(new Point(100, 100)));
                                    panelResultado.BackgroundImage = imagen;

                                    e.Graphics.DrawImage(panelResultado.BackgroundImage, 230, 190, 100, 100);

                                }

                                FrmLogin.CantRegImp--;
                                if (FrmLogin.CantRegImp != 0)
                                {
                                    e.HasMorePages = true;
                                    return;
                                }



                            }
                    }

                    foreach (DataGridViewRow row in dgvMovil.Rows)
                    {
                        row.Cells[4].Value = 1;
                    }

                }


                new Evento().Traigo_Numeros_Credenciales(lbCabinas, lbPupitre12, lbMovil, lbTV);

                MessageBox.Show("Finalizo la Impresion");

            
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            button1.BackColor = Color.DodgerBlue;

        }

        private void button4_BackgroundImageChanged(object sender, EventArgs e)
        {

        }

        private void button2_MouseMove(object sender, MouseEventArgs e)
        {
            button2.BackColor = Color.DodgerBlue;
        }

        private void button3_MouseMove(object sender, MouseEventArgs e)
        {
            button3.BackColor = Color.DodgerBlue;
        }

        private void button10_MouseMove(object sender, MouseEventArgs e)
        {
            button10.BackColor = Color.DodgerBlue;
        }

        private void button4_MouseMove(object sender, MouseEventArgs e)
        {
            button4.BackColor = Color.DodgerBlue;
        }

        private void button11_MouseMove(object sender, MouseEventArgs e)
        {
            button11.BackColor = Color.DodgerBlue;
        }

        private void button16_Click(object sender, EventArgs e)
        {

            if (FrmPrincipal.cabina == 1)
            {
                DataGridViewSelectedRowCollection Seleccionados = dgvCabinas.SelectedRows;

                foreach (DataGridViewRow item in Seleccionados)
                {
                    string id = item.Cells[1].Value.ToString();
                    item.Cells[0].Value = true;
                }
            }

            if (FrmPrincipal.pupitre == 1)
            {
                DataGridViewSelectedRowCollection Seleccionados = dgvPupitre.SelectedRows;

                foreach (DataGridViewRow item in Seleccionados)
                {
                    string id = item.Cells[1].Value.ToString();
                    item.Cells[0].Value = true;
                }

            }

            if (FrmPrincipal.pupitre34 == 1)
            {
                DataGridViewSelectedRowCollection Seleccionados = dgvPupitre.SelectedRows;

                foreach (DataGridViewRow item in Seleccionados)
                {
                    string id = item.Cells[1].Value.ToString();
                    item.Cells[0].Value = true;
                }

            }


            if (FrmPrincipal.pupitre567 == 1)
            {
                DataGridViewSelectedRowCollection Seleccionados = dgvPupitre.SelectedRows;

                foreach (DataGridViewRow item in Seleccionados)
                {
                    string id = item.Cells[1].Value.ToString();
                    item.Cells[0].Value = true;
                }

            }

            if (FrmPrincipal.movil == 1)
            {
                DataGridViewSelectedRowCollection Seleccionados = dgvMovil.SelectedRows;

                foreach (DataGridViewRow item in Seleccionados)
                {
                    string id = item.Cells[1].Value.ToString();
                    item.Cells[0].Value = true;
                }

            }

            if (FrmPrincipal.TV == 1)
            {
                DataGridViewSelectedRowCollection Seleccionados = dgvMovil.SelectedRows;

                foreach (DataGridViewRow item in Seleccionados)
                {
                    string id = item.Cells[1].Value.ToString();
                    item.Cells[0].Value = true;
                }


            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
