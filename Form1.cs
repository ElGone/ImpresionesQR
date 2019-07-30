using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using MySql.Data.MySqlClient;



namespace ImpresionQR
{
    public partial class Form1 : Form
    {
        DateTime fecha = DateTime.Now;
        MySqlCommand cmd;
        MySqlConnection conectar;
        MySqlDataReader dr;
        int cargo = 1;
        string txtideventos;

        public Form1()

        {


            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);

            //QrCode qrCode1 = new QrCode();
            //qrEncoder.TryEncode(txtCredencial.Text, out qrCode1);

            string cadena = txtCredencial.Text + " " + txtValor.Text;
            QrCode qrCode = new QrCode();
            qrEncoder.TryEncode(cadena, out qrCode);


            GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.Black, Brushes.White);
            MemoryStream ms = new MemoryStream();

            renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
            var imageTemporal = new Bitmap(ms);
            var imagen = new Bitmap(imageTemporal, new Size(new Point(100, 100)));
            panelResultado.BackgroundImage = imagen;




        }

        private void Form1_Load(object sender, EventArgs e)
        {
            imprimiqr.Checked = true;
            cabina.Checked = true;
  
            CantidadT.Value = 1;

            // new Evento().Traigo_Datos_Evento(txtCampeonato, txtRival, txtValor, txtFecha,Id_Evento, txtFechaPartido, txtidrival, estado_evento );
            //  new Evento().Traigo_Numeros_Credenciales(lbCabinas, lbPupitre12, lbMovil, lbTV);

        }

        private void button3_Click(object sender, EventArgs e)
        {

            int sigo = 1;

            if (MessageBox.Show(" Esta seguro que quiere imprimir los registros seleccionado ?", "Imprimir registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (CantidadT.Value == 0)
                {
                    sigo = 2;
                    MessageBox.Show("La cantidad de copias debe ser mayor a cero");
                }

                if (cabina.Checked == true)
                {
                    if (string.IsNullOrEmpty(Convert.ToString(txtCabina.Text)))
                    {

                        sigo = 2;
                        MessageBox.Show("Numero de cabina en blanco");
                    }
                }

                if (pupitre.Checked == true)
                {
                    if ((string.IsNullOrEmpty(Convert.ToString(txtAsiento.Text))) | (string.IsNullOrEmpty(Convert.ToString(txtFila.Text))))
                    {
                        sigo = 2;
                        MessageBox.Show("Numero de asiento o fila cabina en blanco");
                    }
                }


                if (sigo == 1)
                {


                    PrinterSettings settings = new PrinterSettings();
                    PaperSize paperSize = new PaperSize("A4", 210, 297);
                    printDocument1.PrinterSettings.DefaultPageSettings.PaperSize = paperSize;
                    printDocument1.Print();

                }


            }

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
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

                if (cabina.Checked == true)
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
                        Evento f = new Evento();
                        buscocredencial = f.buscarcredenciallibre(credencial, 1);
                        if (buscocredencial == 2)
                        {
                            credencial++;
                            if (credencial > 999)
                            {
                                credencial = 1;
                            }
                        }

                    }






                    tipo = 1;
                    if (Convert.ToInt32(CantidadT.Text) > 0)
                    {
                        CantidadT.Text = Convert.ToString(Convert.ToInt32(CantidadT.Text) - 1);
                        cantidad = Convert.ToInt32(CantidadT.Text);
                        cantidad_fija = cantidad + 1;
                    }

                    Rectangle rect3 = new Rectangle(320, 230, 290, 70);
                    e.Graphics.DrawRectangle(Pens.White, rect3);

                    //credencial


                    //     Rectangle rect12 = new Rectangle(440, 410, 170, 40);
                    //      e.Graphics.DrawRectangle(Pens.White, rect12);
                    //      e.Graphics.DrawString(Convert.ToString(credencial).PadLeft(3, '0'), new Font("Arial Black", 14), Brushes.Black, rect12, stringFormat);


                    if (imprimiqr.Checked == true)

                    {

                        // Nombre y DNI
                        if (txtNombre.Text != "")
                        {
                            e.Graphics.DrawString(txtNombre.Text, new Font("Arial Black", 14), Brushes.Black, rect3, stringFormat);
                            if (txtDni.Text != "")
                            {
                                Rectangle rect6 = new Rectangle(320, 260, 290, 60);
                                e.Graphics.DrawRectangle(Pens.White, rect6);
                                e.Graphics.DrawString(txtDni.Text, new Font("Arial Black", 14), Brushes.Black, rect6, stringFormat);
                            }
                            Rectangle rect4 = new Rectangle(320, 290, 290, 40);
                            e.Graphics.DrawRectangle(Pens.White, rect4);
                            e.Graphics.DrawString("CABINA Nº " + txtCabina.Text, new Font("Arial Black", 14), Brushes.Black, rect4, stringFormat);

                        }

                        else
                        {
                            Rectangle rect4 = new Rectangle(320, 230, 290, 70);
                            e.Graphics.DrawRectangle(Pens.White, rect4);
                            e.Graphics.DrawString("CABINA Nº " + txtCabina.Text, new Font("Arial Black", 14), Brushes.Black, rect4, stringFormat);

                        }

                    }
                    else
                    {

                        // Nombre y DNI
                        Rectangle rect999 = new Rectangle(220, 230, 390, 70);
                        e.Graphics.DrawRectangle(Pens.White, rect999);
                        if (txtNombre.Text != "")
                        {
                            e.Graphics.DrawString(txtNombre.Text, new Font("Arial Black", 14), Brushes.Black, rect999, stringFormat);
                            if (txtDni.Text != "")
                            {
                                Rectangle rect6 = new Rectangle(220, 260, 390, 60);
                                e.Graphics.DrawRectangle(Pens.White, rect6);
                                e.Graphics.DrawString(txtDni.Text, new Font("Arial Black", 14), Brushes.Black, rect6, stringFormat);
                            }
                            Rectangle rect4 = new Rectangle(220, 290, 390, 40);
                            e.Graphics.DrawRectangle(Pens.White, rect4);
                            e.Graphics.DrawString("CABINA Nº " + txtCabina.Text, new Font("Arial Black", 14), Brushes.Black, rect4, stringFormat);

                        }

                        else
                        {
                            Rectangle rect4 = new Rectangle(220, 230, 390, 70);
                            e.Graphics.DrawRectangle(Pens.White, rect4);
                            e.Graphics.DrawString("CABINA Nº " + txtCabina.Text, new Font("Arial Black", 14), Brushes.Black, rect4, stringFormat);

                        }








                    }


                    Rectangle rect1 = new Rectangle(220, 90, 390, 45);
                    //     e.Graphics.DrawRectangle(Pens.Black, rect1);

                    e.Graphics.DrawString(Convert.ToString(txtCampeonato.Text + " - " + Convert.ToString(txtFecha.Text)), new Font("Arial Black", 15), Brushes.Black, rect1, stringFormat);

                    Rectangle rect0 = new Rectangle(220, 140, 390, 45);
                    //   e.Graphics.DrawRectangle(Pens.Black, rect0);
                    e.Graphics.DrawString(txtRival.Text, new Font(FrmLogin.nomfuente, FrmLogin.sizefuente), Brushes.Black, rect0, stringFormat);



                    if (imprimiqr.Checked == true)

                    {
                        Char delimiter = '-';
                        int num = 190;
                        String[] substrings = Convert.ToString(txtCanal.Text).Split(delimiter);
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
                        String[] substrings = Convert.ToString(txtCanal.Text).Split(delimiter);
                        foreach (var substring in substrings)
                        {
                            Rectangle rect2 = new Rectangle(220, num, 390, 30);
                            e.Graphics.DrawRectangle(Pens.White, rect2);
                            e.Graphics.DrawString(substring, new Font("Arial Black", 18), Brushes.Black, rect2, stringFormat);
                            num = num + 30;
                        }






                    }


                    //    Rectangle rect5 = new Rectangle(200, 410, 390, 30);
                    //    e.Graphics.DrawRectangle(Pens.White, rect5);



                    //e.Graphics.DrawString(Convert.ToString(row.Cells[2].Value), new Font("Arial Black", 14), Brushes.Black, rect5, stringFormat);
                    //    float x11111 = 200.0F;
                    //   float y11111 = 352.0F;
                    //     float x22222 = 590.0F;
                    //     float y22222 = 352.0F;
                    //     e.Graphics.DrawLine(blackPen, x11111, y11111, x22222, y22222);

                    //      Rectangle rect11 = new Rectangle(200, 220, 390, 230);
                    //      e.Graphics.DrawRectangle(Pens.Black, rect11);




                    Evento d = new Evento();
                    numero_evento = d.traigo_numero_evento();

                    cmd = new MySqlCommand("Insert into impresiones(Torneo, Evento, Medio, Cantidad, Nombre, DNI, Credencial, Asiento, Fila, Cabina, Fecha, Tipo, Id_Evento, Estado, Usuario, Letras ) values('" + txtCampeonato.Text + "', '" + txtRival.Text + "', '" + txtCanal.Text + "', '" + cantidad_fija + "', '" + txtNombre.Text + "', '" + txtDni.Text + "', '" + credencial + "', " + 0 + ", " + 0 + ", " + txtCabina.Text + ", '" + lahora + "', " + tipo + ", " + numero_evento + ", 1, '" + FrmLogin.usu + "', '')", conectar);
                    cmd.ExecuteNonQuery();




                    // Actualizo el numero de credencial

                    credencial++;


                    if (credencial >= 999)
                    {
                        cmd = new MySqlCommand("UPDATE setup SET Credencial_Cabinas = 1", conectar);
                        cmd.ExecuteNonQuery();
                        credencial = 1;
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
                        cadena = Convert.ToString(numero_id) + "#" + Convert.ToString(txtCanal.Text) + "*" + Convert.ToString(txtCabina.Text).PadLeft(2, '0') + "0000" + "^" + txtValor.Text;
                        //cadena = txtValor.Text + " " + Convert.ToString(numero_id);

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


                    if (cantidad == 0)
                    {
                        new Evento().Traigo_Numeros_Credenciales(lbCabinas, lbPupitre12, lbMovil, lbTV);
                        MessageBox.Show("Finalizo la Impresion");

                        e.HasMorePages = false;
                        return;

                    }
                    else
                    {
                        e.HasMorePages = true;
                        return;

                    }


                }


                // PUPITRE

                if (pupitre.Checked == true)

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
                        Evento f = new Evento();
                        buscocredencial = f.buscarcredenciallibre(credencial, 1);
                        if (buscocredencial == 2)
                        {
                            credencial++;
                            if (credencial > 999)
                            {
                                credencial = 1;
                            }
                        }

                    }



                    tipo = 2;
                    CantidadT.Text = Convert.ToString(Convert.ToInt32(CantidadT.Text) - 1);
                    cantidad = Convert.ToInt32(CantidadT.Text);
                    cantidad_fija = cantidad + 1;
                    Rectangle rect3 = new Rectangle(320, 230, 290, 70);
                    e.Graphics.DrawRectangle(Pens.White, rect3);

                    //credencial

                    // Rectangle rect12 = new Rectangle(440, 410, 170, 40);
                    //  e.Graphics.DrawRectangle(Pens.White, rect12);
                    //  e.Graphics.DrawString(Convert.ToString(credencial).PadLeft(3, '0'), new Font("Arial Black", 14), Brushes.Black, rect12, stringFormat);


                    if (imprimiqr.Checked == true)

                    {

                        // Nombre y DNI
                        if (txtNombre.Text != "")
                        {

                            e.Graphics.DrawString(txtNombre.Text, new Font("Arial Black", 14), Brushes.Black, rect3, stringFormat);
                            if (txtDni.Text != "")
                            {
                                Rectangle rect6 = new Rectangle(320, 250, 290, 70);
                                e.Graphics.DrawRectangle(Pens.White, rect6);
                                e.Graphics.DrawString(txtDni.Text, new Font("Arial Black", 14), Brushes.Black, rect6, stringFormat);
                            }
                            Rectangle rect4 = new Rectangle(320, 290, 290, 40);
                            e.Graphics.DrawRectangle(Pens.White, rect4);
                            e.Graphics.DrawString("FILA Nº " + txtFila.Text + " ASIENTO Nº " + txtAsiento.Text, new Font("Arial Black", 14), Brushes.Black, rect4, stringFormat);

                        }

                        else
                        {
                            Rectangle rect4 = new Rectangle(320, 290, 290, 40);
                            e.Graphics.DrawRectangle(Pens.White, rect4);
                            e.Graphics.DrawString("FILA Nº " + txtFila.Text + " ASIENTO Nº " + txtAsiento.Text, new Font("Arial Black", 14), Brushes.Black, rect4, stringFormat);

                        }
                    }
                    else
                    {

                        // Nombre y DNI
                        Rectangle rect999 = new Rectangle(220, 230, 390, 70);
                        e.Graphics.DrawRectangle(Pens.White, rect999);
                        if (txtNombre.Text != "")
                        {

                            e.Graphics.DrawString(txtNombre.Text, new Font("Arial Black", 14), Brushes.Black, rect999, stringFormat);
                            if (txtDni.Text != "")
                            {
                                Rectangle rect6 = new Rectangle(220, 250, 390, 70);
                                e.Graphics.DrawRectangle(Pens.White, rect6);
                                e.Graphics.DrawString(txtDni.Text, new Font("Arial Black", 14), Brushes.Black, rect6, stringFormat);
                            }
                            Rectangle rect4 = new Rectangle(220, 290, 390, 40);
                            e.Graphics.DrawRectangle(Pens.White, rect4);
                            e.Graphics.DrawString("FILA Nº " + txtFila.Text + " ASIENTO Nº " + txtAsiento.Text, new Font("Arial Black", 14), Brushes.Black, rect4, stringFormat);

                        }

                        else
                        {
                            Rectangle rect4 = new Rectangle(220, 290, 390, 40);
                            e.Graphics.DrawRectangle(Pens.White, rect4);
                            e.Graphics.DrawString("FILA Nº " + txtFila.Text + " ASIENTO Nº " + txtAsiento.Text, new Font("Arial Black", 14), Brushes.Black, rect4, stringFormat);

                        }




                    }





                    Rectangle rect1 = new Rectangle(220, 90, 390, 45);
                    //      e.Graphics.DrawRectangle(Pens.Black, rect1);

                    e.Graphics.DrawString(Convert.ToString(txtCampeonato.Text + " - " + Convert.ToString(txtFecha.Text)), new Font("Arial Black", 15), Brushes.Black, rect1, stringFormat);

                    Rectangle rect0 = new Rectangle(220, 130, 390, 45);
                    //    e.Graphics.DrawRectangle(Pens.Black, rect0);
                    e.Graphics.DrawString(txtRival.Text, new Font(FrmLogin.nomfuente, FrmLogin.sizefuente), Brushes.Black, rect0, stringFormat);




                    if (imprimiqr.Checked == true)

                    {
                        Char delimiter = '-';
                        int num = 190;
                        String[] substrings = Convert.ToString(txtCanal.Text).Split(delimiter);
                        foreach (var substring in substrings)
                        {
                            Rectangle rect2 = new Rectangle(220, num, 290, 30);
                            e.Graphics.DrawRectangle(Pens.White, rect2);
                            e.Graphics.DrawString(substring, new Font("Arial Black", 16), Brushes.Black, rect2, stringFormat);
                            num = num + 30;
                        }

                    }
                    else
                    {
                        Char delimiter = '-';
                        int num = 190;
                        String[] substrings = Convert.ToString(txtCanal.Text).Split(delimiter);
                        foreach (var substring in substrings)
                        {
                            Rectangle rect2 = new Rectangle(220, num, 390, 30);
                            e.Graphics.DrawRectangle(Pens.White, rect2);
                            e.Graphics.DrawString(substring, new Font("Arial Black", 18), Brushes.Black, rect2, stringFormat);
                            num = num + 30;
                        }






                    }

                    // Rectangle rect5 = new Rectangle(200, 410, 390, 30);
                    //  e.Graphics.DrawRectangle(Pens.White, rect5);

                    //e.Graphics.DrawString(Convert.ToString(row.Cells[2].Value), new Font("Arial Black", 14), Brushes.Black, rect5, stringFormat);
                    //float x11111 = 200.0F;
                    // float y11111 = 352.0F;
                    // float x22222 = 590.0F;
                    // float y22222 = 352.0F;
                    // e.Graphics.DrawLine(blackPen, x11111, y11111, x22222, y22222);

                    //Rectangle rect11 = new Rectangle(200, 220, 390, 230);
                    // e.Graphics.DrawRectangle(Pens.Black, rect11);


                    conectar = Conexion.ObtenerConexion();
                    Evento d = new Evento();
                    numero_evento = d.traigo_numero_evento();


                    cmd = new MySqlCommand("Insert into impresiones(Torneo, Evento, Medio, Cantidad, Nombre, DNI, Credencial, Asiento, Fila, Cabina, Fecha, Tipo, Id_Evento, Estado, Usuario) values('" + txtCampeonato.Text + "', '" + txtRival.Text + "', '" + txtCanal.Text + "', '" + cantidad_fija + "', '" + txtNombre.Text + "', '" + txtDni.Text + "', '" + credencial + "', " + txtAsiento.Text + ", " + txtFila.Text + ", " + 0 + ", '" + lahora + "', " + tipo + ", " + numero_evento + ", 1, '" + FrmLogin.usu + "')", conectar);
                    cmd.ExecuteNonQuery();




                    // Actualizo el numero de credencial

                    credencial++;
                    conectar = Conexion.ObtenerConexion();

                    if (credencial > 999)
                    {
                        cmd = new MySqlCommand("UPDATE setup SET Credencial_Pupitres = 1", conectar);
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
                        cadena = Convert.ToString(numero_id) + "#" + Convert.ToString(txtCanal.Text) + "*" + "00" + string.Format("{00}", Convert.ToString(txtFila.Text)) + Convert.ToString(txtAsiento.Text).PadLeft(2, '0') + "^" + txtValor.Text;
                        // cadena = txtValor.Text + " " + Convert.ToString(numero_id);

                        QrCode qrCode = new QrCode();
                        qrEncoder.TryEncode(cadena, out qrCode);
                        GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.Black, Brushes.White);
                        MemoryStream ms = new MemoryStream();
                        renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
                        var imageTemporal = new Bitmap(ms);
                        var imagen = new Bitmap(imageTemporal, new Size(new Point(100, 100)));
                        panelResultado.BackgroundImage = imagen;

                        e.Graphics.DrawImage(panelResultado.BackgroundImage, 220, 190, 100, 100);

                    }


                    if (cantidad == 0)
                    {
                        new Evento().Traigo_Numeros_Credenciales(lbCabinas, lbPupitre12, lbMovil, lbTV);
                        MessageBox.Show("Finalizo la Impresion");

                        e.HasMorePages = false;
                        return;

                    }
                    else
                    {
                        e.HasMorePages = true;
                        return;

                    }



                }





                //////  MOVIL ////////

                if (campo.Checked == true)
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
                        Evento f = new Evento();
                        buscocredencial = f.buscarcredenciallibre(credencial, 1);
                        if (buscocredencial == 2)
                        {
                            credencial++;
                            if (credencial > 999)
                            {
                                credencial = 1;
                            }
                        }

                    }


                    tipo = 3;
                    CantidadT.Text = Convert.ToString(Convert.ToInt32(CantidadT.Text) - 1);
                    cantidad = Convert.ToInt32(CantidadT.Text);
                    cantidad_fija = cantidad + 1;
                    Rectangle rect3 = new Rectangle(320, 210, 290, 70);
                    e.Graphics.DrawRectangle(Pens.White, rect3);

                    //credencial

                    //Rectangle rect12 = new Rectangle(440, 410, 170, 40);
                    // e.Graphics.DrawRectangle(Pens.White, rect12);
                    // e.Graphics.DrawString(Convert.ToString(credencial).PadLeft(3, '0'), new Font("Arial Black", 14), Brushes.Black, rect12, stringFormat);



                    if (imprimiqr.Checked == true)

                    {
                        // Nombre y DNI
                        if (txtNombre.Text != "")
                        {

                            e.Graphics.DrawString(txtNombre.Text, new Font("Arial Black", 14), Brushes.Black, rect3, stringFormat);
                            if (txtDni.Text != "")
                            {
                                Rectangle rect6 = new Rectangle(320, 230, 290, 70);
                                e.Graphics.DrawRectangle(Pens.White, rect6);
                                e.Graphics.DrawString(txtDni.Text, new Font("Arial Black", 14), Brushes.Black, rect6, stringFormat);
                            }
                            if (servicios_especiales.Checked == true)
                            {
                                Rectangle rect4 = new Rectangle(300, 270, 290, 40);
                                e.Graphics.DrawRectangle(Pens.White, rect4);
                                e.Graphics.DrawString("SERVICIOS ESPECIALES", new Font("Arial Black", 17), Brushes.Black, rect4, stringFormat);
                            }
                            Rectangle rect99 = new Rectangle(300, 290, 290, 40);
                            e.Graphics.DrawRectangle(Pens.White, rect99);
                            // e.Graphics.DrawString("ACCESO A DESIGNAR", new Font("Arial Black", 15), Brushes.Black, rect99, stringFormat);



                        }

                        else
                        {
                            if (servicios_especiales.Checked == true)
                            {
                                Rectangle rect4 = new Rectangle(300, 270, 290, 40);
                                e.Graphics.DrawRectangle(Pens.White, rect4);
                                e.Graphics.DrawString("SERVICIOS ESPECIALES", new Font("Arial Black", 17), Brushes.Black, rect4, stringFormat);
                            }
                            Rectangle rect99 = new Rectangle(300, 290, 290, 40);
                            e.Graphics.DrawRectangle(Pens.White, rect99);
                            //         e.Graphics.DrawString("ACCESO A DESIGNAR", new Font("Arial Black", 15), Brushes.Black, rect99, stringFormat);

                        }

                    }
                    else
                    {

                        // Nombre y DNI

                        Rectangle rect999 = new Rectangle(220, 210, 390, 70);
                        e.Graphics.DrawRectangle(Pens.White, rect999);
                        if (txtNombre.Text != "")
                        {

                            e.Graphics.DrawString(txtNombre.Text, new Font("Arial Black", 14), Brushes.Black, rect999, stringFormat);
                            if (txtDni.Text != "")
                            {
                                Rectangle rect6 = new Rectangle(220, 230, 390, 70);
                                e.Graphics.DrawRectangle(Pens.White, rect6);
                                e.Graphics.DrawString(txtDni.Text, new Font("Arial Black", 14), Brushes.Black, rect6, stringFormat);
                            }
                            if (servicios_especiales.Checked == true)
                            {
                                Rectangle rect4 = new Rectangle(220, 270, 390, 40);
                                e.Graphics.DrawRectangle(Pens.White, rect4);
                                e.Graphics.DrawString("SERVICIOS ESPECIALES", new Font("Arial Black", 17), Brushes.Black, rect4, stringFormat);
                            }
                            Rectangle rect99 = new Rectangle(220, 290, 390, 40);
                            e.Graphics.DrawRectangle(Pens.White, rect99);
                            // e.Graphics.DrawString("ACCESO A DESIGNAR", new Font("Arial Black", 15), Brushes.Black, rect99, stringFormat);



                        }

                        else
                        {
                            if (servicios_especiales.Checked == true)
                            {
                                Rectangle rect4 = new Rectangle(220, 270, 390, 40);
                                e.Graphics.DrawRectangle(Pens.White, rect4);
                                e.Graphics.DrawString("SERVICIOS ESPECIALES", new Font("Arial Black", 17), Brushes.Black, rect4, stringFormat);
                            }
                            Rectangle rect99 = new Rectangle(220, 290, 390, 40);
                            e.Graphics.DrawRectangle(Pens.White, rect99);
                            //        e.Graphics.DrawString("ACCESO A DESIGNAR", new Font("Arial Black", 15), Brushes.Black, rect99, stringFormat);

                        }





                    }



                    Rectangle rect1 = new Rectangle(220, 90, 390, 45);
                    //      e.Graphics.DrawRectangle(Pens.Black, rect1);

                    e.Graphics.DrawString(Convert.ToString(txtCampeonato.Text + " - " + Convert.ToString(txtFecha.Text)), new Font("Arial Black", 15), Brushes.Black, rect1, stringFormat);

                    Rectangle rect0 = new Rectangle(220, 130, 390, 45);
                    //    e.Graphics.DrawRectangle(Pens.Black, rect0);
                    e.Graphics.DrawString(txtRival.Text, new Font(FrmLogin.nomfuente, FrmLogin.sizefuente), Brushes.Black, rect0, stringFormat);



                    if (imprimiqr.Checked == true)

                    {
                        Char delimiter = '-';
                        int num = 180;
                        String[] substrings = Convert.ToString(txtCanal.Text).Split(delimiter);
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
                        String[] substrings = Convert.ToString(txtCanal.Text).Split(delimiter);
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

                    //e.Graphics.DrawString(Convert.ToString(row.Cells[2].Value), new Font("Arial Black", 14), Brushes.Black, rect5, stringFormat);
                    //float x11111 = 200.0F;
                    // float y11111 = 352.0F;
                    //  float x22222 = 590.0F;
                    //  float y22222 = 352.0F;
                    //  e.Graphics.DrawLine(blackPen, x11111, y11111, x22222, y22222);

                    //Rectangle rect11 = new Rectangle(200, 220, 390, 230);
                    // e.Graphics.DrawRectangle(Pens.Black, rect11);



                    conectar = Conexion.ObtenerConexion();

                    Evento d = new Evento();
                    numero_evento = d.traigo_numero_evento();

                    cmd = new MySqlCommand("Insert into impresiones(Torneo, Evento, Medio, Cantidad, Nombre, DNI, Credencial, Asiento, Fila, Cabina, Fecha, Tipo, Id_Evento, Estado, Usuario) values('" + txtCampeonato.Text + "', '" + txtRival.Text + "', '" + txtCanal.Text + "', '" + cantidad_fija + "', '" + txtNombre.Text + "', '" + txtDni.Text + "', '" + credencial + "', " + 0 + ", " + 0 + ", " + 0 + ", '" + lahora + "', " + tipo + ", " + numero_evento + ", 1, '" + FrmLogin.usu + "')", conectar);
                    cmd.ExecuteNonQuery();


                    // Actualizo el numero de credencial

                    credencial++;
                    conectar = Conexion.ObtenerConexion();

                    if (credencial > 999)
                    {
                        cmd = new MySqlCommand("UPDATE setup SET Credencial_Moviles = 1", conectar);
                        cmd.ExecuteNonQuery();
                        credencial = 1;
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
                        cadena = Convert.ToString(numero_id) + "#" + Convert.ToString(txtCanal.Text) + "*" + "000000" + "^" + txtValor.Text;
                        //cadena = txtValor.Text + " " + Convert.ToString(numero_id);

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


                    if (cantidad == 0)
                    {
                        new Evento().Traigo_Numeros_Credenciales(lbCabinas, lbPupitre12, lbMovil, lbTV);
                        MessageBox.Show("Finalizo la Impresion");

                        e.HasMorePages = false;
                        return;

                    }
                    else
                    {
                        e.HasMorePages = true;
                        return;

                    }



                }


                //////  TV ////////

                if (tv.Checked == true)
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
                        Evento f = new Evento();
                        buscocredencial = f.buscarcredenciallibre(credencial, 1);
                        if (buscocredencial == 2)
                        {
                            credencial++;
                            if (credencial > 999)
                            {
                                credencial = 1;
                            }
                        }

                    }




                    tipo = 4;
                    CantidadT.Text = Convert.ToString(Convert.ToInt32(CantidadT.Text) - 1);
                    cantidad = Convert.ToInt32(CantidadT.Text);
                    cantidad_fija = cantidad + 1;
                    Rectangle rect3 = new Rectangle(320, 230, 290, 70);
                    e.Graphics.DrawRectangle(Pens.White, rect3);

                    //credencial

                    //Rectangle rect12 = new Rectangle(440, 410, 170, 40);
                    // e.Graphics.DrawRectangle(Pens.White, rect12);
                    //e.Graphics.DrawString(Convert.ToString(credencial).PadLeft(3, '0'), new Font("Arial Black", 14), Brushes.Black, rect12, stringFormat);


                    if (imprimiqr.Checked == true)

                    {

                        // Nombre y DNI
                        if (txtNombre.Text != "")
                        {

                            e.Graphics.DrawString(txtNombre.Text, new Font("Arial Black", 14), Brushes.Black, rect3, stringFormat);
                            if (txtDni.Text != "")
                            {
                                Rectangle rect6 = new Rectangle(320, 250, 290, 70);
                                e.Graphics.DrawRectangle(Pens.White, rect6);
                                e.Graphics.DrawString(txtDni.Text, new Font("Arial Black", 14), Brushes.Black, rect6, stringFormat);
                            }
                            Rectangle rect4 = new Rectangle(320, 290, 270, 40);
                            e.Graphics.DrawRectangle(Pens.White, rect4);
                            e.Graphics.DrawString("CAMPO DE JUEGO", new Font("Arial Black", 17), Brushes.Black, rect4, stringFormat);



                        }

                        else
                        {
                            Rectangle rect4 = new Rectangle(320, 290, 290, 40);
                            e.Graphics.DrawRectangle(Pens.White, rect4);
                            e.Graphics.DrawString("CAMPO DE JUEGO", new Font("Arial Black", 17), Brushes.Black, rect4, stringFormat);

                        }


                    }
                    else
                    {

                        // Nombre y DNI
                        Rectangle rect999 = new Rectangle(220, 230, 390, 70);
                        e.Graphics.DrawRectangle(Pens.White, rect999);
                        if (txtNombre.Text != "")
                        {

                            e.Graphics.DrawString(txtNombre.Text, new Font("Arial Black", 14), Brushes.Black, rect999, stringFormat);
                            if (txtDni.Text != "")
                            {
                                Rectangle rect6 = new Rectangle(220, 250, 390, 70);
                                e.Graphics.DrawRectangle(Pens.White, rect6);
                                e.Graphics.DrawString(txtDni.Text, new Font("Arial Black", 14), Brushes.Black, rect6, stringFormat);
                            }
                            Rectangle rect4 = new Rectangle(220, 290, 370, 40);
                            e.Graphics.DrawRectangle(Pens.White, rect4);
                            e.Graphics.DrawString("CAMPO DE JUEGO", new Font("Arial Black", 17), Brushes.Black, rect4, stringFormat);



                        }

                        else
                        {
                            Rectangle rect4 = new Rectangle(220, 290, 390, 40);
                            e.Graphics.DrawRectangle(Pens.White, rect4);
                            e.Graphics.DrawString("CAMPO DE JUEGO", new Font("Arial Black", 17), Brushes.Black, rect4, stringFormat);

                        }








                    }

                    Rectangle rect1 = new Rectangle(220, 90, 390, 45);
                    //       e.Graphics.DrawRectangle(Pens.Black, rect1);

                    e.Graphics.DrawString(Convert.ToString(txtCampeonato.Text + " - " + Convert.ToString(txtFecha.Text)), new Font("Arial Black", 15), Brushes.Black, rect1, stringFormat);

                    Rectangle rect0 = new Rectangle(220, 130, 390, 45);
                    //     e.Graphics.DrawRectangle(Pens.Black, rect0);
                    e.Graphics.DrawString(txtRival.Text, new Font(FrmLogin.nomfuente, FrmLogin.sizefuente), Brushes.Black, rect0, stringFormat);

                    if (imprimiqr.Checked == true)

                    {
                        Char delimiter = '-';
                        int num = 180;
                        String[] substrings = Convert.ToString(txtCanal.Text).Split(delimiter);
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
                        String[] substrings = Convert.ToString(txtCanal.Text).Split(delimiter);
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

                    //e.Graphics.DrawString(Convert.ToString(row.Cells[2].Value), new Font("Arial Black", 14), Brushes.Black, rect5, stringFormat);
                    //float x11111 = 200.0F;
                    // float y11111 = 352.0F;
                    // float x22222 = 590.0F;
                    // float y22222 = 352.0F;
                    // e.Graphics.DrawLine(blackPen, x11111, y11111, x22222, y22222);

                    // Rectangle rect11 = new Rectangle(200, 220, 390, 230);
                    // e.Graphics.DrawRectangle(Pens.Black, rect11);

                    Evento d = new Evento();
                    if (imprimiqr.Checked == true)

                    {
                        // CODIGO QR

                        numero_id = d.traigo_ultimo_Id();
                        cadena = Convert.ToString(numero_id) + "#" + Convert.ToString(txtCanal.Text) + "*" + "000000" + "^" + txtValor.Text;
                        //cadena = txtValor.Text + " " + Convert.ToString(numero_id);

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

                    conectar = Conexion.ObtenerConexion();


                    numero_evento = d.traigo_numero_evento();

                    cmd = new MySqlCommand("Insert into impresiones(Torneo, Evento, Medio, Cantidad, Nombre, DNI, Credencial, Asiento, Fila, Cabina, Fecha, Tipo, Id_Evento, Estado, Usuario) values('" + txtCampeonato.Text + "', '" + txtRival.Text + "', '" + txtCanal.Text + "', '" + cantidad_fija + "', '" + txtNombre.Text + "', '" + txtDni.Text + "', '" + credencial + "', " + 0 + ", " + 0 + ", " + 0 + ", '" + lahora + "', " + tipo + ", " + numero_evento + ", 1, '" + FrmLogin.usu + "')", conectar);
                    cmd.ExecuteNonQuery();



                    // Actualizo el numero de credencial

                    credencial++;
                    conectar = Conexion.ObtenerConexion();

                    if (credencial > 999)
                    {
                        cmd = new MySqlCommand("UPDATE setup SET Credencial_TV = 1", conectar);
                        cmd.ExecuteNonQuery();
                        credencial = 1;
                    }
                    else
                    {
                        cmd = new MySqlCommand("UPDATE setup SET Credencial_TV =" + credencial, conectar);
                        cmd.ExecuteNonQuery();
                    }



                    if (cantidad == 0)
                    {
                        new Evento().Traigo_Numeros_Credenciales(lbCabinas, lbPupitre12, lbMovil, lbTV);
                        MessageBox.Show("Finalizo la Impresion");
                        e.HasMorePages = false;
                        return;

                    }
                    else
                    {

                        e.HasMorePages = true;
                        return;

                    }



                }

                                                                                                            }
        private void txtValor_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void txtFila_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();

        }

        private void cabina_CheckedChanged(object sender, EventArgs e)
        {
            if (cabina.Checked == true)
            {
                panel1.Enabled = true;
                panel2.Enabled = false;
            }
        }

        private void pupitre_CheckedChanged(object sender, EventArgs e)
        {
            if (pupitre.Checked == true)
            {
                panel1.Enabled = false;
                panel2.Enabled = true;
            }
        }

        private void campo_CheckedChanged(object sender, EventArgs e)
        {
            if (campo.Checked == true)
            {
                panel1.Enabled = false;
                panel2.Enabled = false;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tv_CheckedChanged(object sender, EventArgs e)
        {
            if (tv.Checked == true)
            {
                panel1.Enabled = false;
                panel2.Enabled = false;
            }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void Hewlett_Packard_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Samsumg_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string criterio = "";

            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
            criterio = "Select a.Id_Evento, a.Nombre_Evento, a.Campeonato, a.Fecha, a.url, a.Numero_Fecha, a.Rival, a.Id_Rival, a.Estado, b.Descripcion From eventos AS a INNER JOIN Estados AS b ON a.Estado = b.Estado ORDER BY a.Fecha DESC";
            new Importar().muestro_eventos(dgvEventos, criterio);
            groupBox2.Visible = true;
            System.Windows.Forms.Cursor.Current = Cursors.Default;
        }

        private void dgvEventos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtidevento.Text = Convert.ToString(this.dgvEventos.CurrentRow.Cells[3].Value);
            Id_eventos.Text = txtidevento.Text;
            Id_Evento.Text = Id_eventos.Text;
            estado_evento.Text = Convert.ToString(this.dgvEventos.CurrentRow.Cells[5].Value);
            new Evento().Traigo_Datos_Evento(txtCampeonato, txtRival, txtValor, txtFecha, Id_eventos, lafecha, textIdRival, estado_evento);
            txtFechaPartido.Text = Convert.ToDateTime(lafecha.Text).ToString("yyyy-MM-dd");
            groupBox2.Visible = false;
            button1.Enabled = true;
            txtidrival.Text = idrival.Text;
            Id_Evento.Text = txtidevento.Text;
            txtideventos = txtidevento.Text;


        }

        private void button14_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

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
            new Importar().Traigo_Fuentes_Evento(txtideventos);



            ////// CABINA ////////

            if (cabina.Checked == true)
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
                    Evento f = new Evento();
                    buscocredencial = f.buscarcredenciallibre(credencial, 1);
                    if (buscocredencial == 2)
                    {
                        credencial++;
                        if (credencial > FrmLogin.credencial_hasta)
                        {
                            credencial = FrmLogin.credencial_desde;
                        }
                    }

                }

                tipo = 1;
                if (Convert.ToInt32(CantidadT.Text) > 0)
                {
                    CantidadT.Text = Convert.ToString(Convert.ToInt32(CantidadT.Text) - 1);
                    cantidad = Convert.ToInt32(CantidadT.Text);
                    cantidad_fija = cantidad + 1;
                }

                Rectangle rect3 = new Rectangle(300, 230, 290, 70);
                e.Graphics.DrawRectangle(Pens.White, rect3);
                              

                // fila 1
                Rectangle rect1 = new Rectangle(190, 87, 410, 45);
                //e.Graphics.DrawRectangle(Pens.Black, rect1);

                /////////// IMPRIMO CAMPEONATO ////////////
                if (FrmLogin.negritacampeonato == 1)
                {
                    e.Graphics.DrawString(Convert.ToString(txtCampeonato.Text), new Font(FrmLogin.nomfuentecampeonato, FrmLogin.sizecampeonato, FontStyle.Bold), Brushes.Black, rect1, stringFormat);
                }
                else
                {
                    e.Graphics.DrawString(Convert.ToString(txtCampeonato.Text), new Font(FrmLogin.nomfuentecampeonato, FrmLogin.sizecampeonato), Brushes.Black, rect1, stringFormat);
                }

                /////////// IMPRIMO FECHA ////////////

                Rectangle rect111 = new Rectangle(190, 107, 410, 45);
                if (FrmLogin.negritafecha == 1)
                {
                    e.Graphics.DrawString(Convert.ToString(txtFecha.Text), new Font(FrmLogin.nomfuentefecha, FrmLogin.sizefecha, FontStyle.Bold), Brushes.Black, rect111, stringFormat);
                }
                else
                {
                    e.Graphics.DrawString(Convert.ToString(txtFecha.Text), new Font(FrmLogin.nomfuentefecha, FrmLogin.sizefecha), Brushes.Black, rect111, stringFormat);
                }
                
                
                Rectangle rect0 = new Rectangle(190, 130, 410, 45);


                /////////// IMPRIMO RIVAL ////////////

                if (FrmLogin.negritarival == 1)
                {
                    e.Graphics.DrawString(txtRival.Text, new Font(FrmLogin.nomfuenterival, FrmLogin.sizerival, FontStyle.Bold), Brushes.Black, rect0, stringFormat);
                }
                else
                {
                    e.Graphics.DrawString(txtRival.Text, new Font(FrmLogin.nomfuenterival, FrmLogin.sizerival), Brushes.Black, rect0, stringFormat);

                }


              
                Pen mipen = new Pen(Color.Black, 7);
                e.Graphics.DrawLine(mipen, 170, 170, 630, 170);


                // fila 2

                Char delimiter = '-';
                int num = 190;
                String[] substrings = Convert.ToString(txtCanal.Text).Split(delimiter);
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

                Rectangle rect22 = new Rectangle(190, 250, 390, 60);
                e.Graphics.DrawRectangle(Pens.White, rect22);

                /////////// IMPRIMO UBICACION ////////////


                if (FrmLogin.negritaubicacion == 1)
                {
                    e.Graphics.DrawString("CABINA DE PRENSA", new Font(FrmLogin.nomfuenteubicacion, FrmLogin.sizeubicacion, FontStyle.Bold), Brushes.Black, rect22, stringFormat);
                }
                else
                {
                    e.Graphics.DrawString("CABINA DE PRENSA", new Font(FrmLogin.nomfuenteubicacion, FrmLogin.sizeubicacion), Brushes.Black, rect22, stringFormat);
                }


                Rectangle rect4 = new Rectangle(190, 290, 390, 60);
                e.Graphics.DrawRectangle(Pens.White, rect4);

                if (FrmLogin.negritaubicacion == 1)
                {
                    e.Graphics.DrawString("CABINA Nº " + txtCabina.Text, new Font(FrmLogin.nomfuenteubicacion, FrmLogin.sizeubicacion, FontStyle.Bold), Brushes.Black, rect4, stringFormat);
                }
                else
                {

                    e.Graphics.DrawString("CABINA Nº " + txtCabina.Text, new Font(FrmLogin.nomfuenteubicacion, FrmLogin.sizeubicacion), Brushes.Black, rect4, stringFormat);

                }


                /// NOMBRE APELLIDO Y DNI
                if (txtNombre.Text != "")
                {
                    Rectangle rect23 = new Rectangle(170, 340, 420, 60);
                    e.Graphics.DrawRectangle(Pens.White, rect23);
                    if (FrmLogin.negritanombre == 1)
                    {
                        e.Graphics.DrawString(txtNombre.Text, new Font(FrmLogin.nomfuentenombre, FrmLogin.sizenombre, FontStyle.Bold), Brushes.Black, rect23, stringFormat);

                    }
                    else
                    {
                        e.Graphics.DrawString(txtNombre.Text, new Font(FrmLogin.nomfuentenombre, FrmLogin.sizenombre, FontStyle.Bold), Brushes.Black, rect23, stringFormat);


                    }
                }
                
                if (txtDni.Text != "")
                {
                    Rectangle rect6 = new Rectangle(170, 390, 420, 60);
                    e.Graphics.DrawRectangle(Pens.White, rect6);
                    if (FrmLogin.negritanombre == 1)
                    {                        
                        e.Graphics.DrawString(txtDni.Text, new Font(FrmLogin.nomfuentenombre, FrmLogin.sizenombre, FontStyle.Bold), Brushes.Black, rect6, stringFormat);
                    }
                    else
                    {
                        e.Graphics.DrawString(txtDni.Text, new Font(FrmLogin.nomfuentenombre, FrmLogin.sizenombre), Brushes.Black, rect6, stringFormat);
                    }

                }

                //credencial


                Rectangle rect12 = new Rectangle(370, 420, 390, 40);
                e.Graphics.DrawRectangle(Pens.White, rect12);
                e.Graphics.DrawString("Nº " + Convert.ToString(credencial).PadLeft(3, '0'), new Font("Arial Black", 14), Brushes.Black, rect12, stringFormat);

                Evento d = new Evento();
                numero_evento = d.traigo_numero_evento();

                cmd = new MySqlCommand("Insert into impresiones(Torneo, Evento, Medio, Cantidad, Nombre, DNI, Credencial, Asiento, Fila, Cabina, Fecha, Tipo, Id_Evento, Estado, Usuario, Letras) values('" + txtCampeonato.Text + "', '" + txtRival.Text + "', '" + txtCanal.Text + "', '" + cantidad_fija + "', '" + txtNombre.Text + "', '" + txtDni.Text + "', '" + credencial + "', " + 0 + ", " + 0 + ", " + txtCabina.Text + ", '" + lahora + "', " + tipo + ", " + numero_evento + ", 1, '" + FrmLogin.usu + "','" + txtLetras.Text + "')", conectar);
                cmd.ExecuteNonQuery();




                // Actualizo el numero de credencial

                credencial++;


                if (credencial >= FrmLogin.credencial_hasta)
                {
                    cmd = new MySqlCommand("UPDATE setup SET Credencial_Cabinas =" + FrmLogin.credencial_desde, conectar);
                    cmd.ExecuteNonQuery();
                    credencial = FrmLogin.credencial_desde;
                }
                else
                {
                    cmd = new MySqlCommand("UPDATE setup SET Credencial_Cabinas =" + credencial, conectar);
                    cmd.ExecuteNonQuery();
                }

                // QR


                if (imprimiqr.Checked == true)
                {
                    numero_id = d.traigo_ultimo_Id();
                    cadena = Convert.ToString(numero_id) + "#" + Convert.ToString(txtCanal.Text) + "*" + Convert.ToString(txtCabina.Text).PadLeft(2, '0') + "0000" + "^" + txtValor.Text;
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

                Rectangle rect29 = new Rectangle(210, 470, 380, 100);
                e.Graphics.DrawRectangle(Pens.White, rect29);
                e.Graphics.DrawString(txtLetras.Text, new Font("Arial", 32), Brushes.Black, rect29, stringFormat);


                if (cantidad == 0)
                {
                    new Evento().Traigo_Numeros_Credenciales(lbCabinas, lbPupitre12, lbMovil, lbTV);
                    MessageBox.Show("Finalizo la Impresion");

                    e.HasMorePages = false;
                    return;

                }
                else
                {
                    e.HasMorePages = true;
                    return;

                }

            }



            ////// PUPITRE ////////

            if (pupitre.Checked == true)
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
                    Evento f = new Evento();
                    buscocredencial = f.buscarcredenciallibre(credencial, 2);
                    if (buscocredencial == 2)
                    {
                        credencial++;
                        if (credencial > FrmLogin.credencial_hasta)
                        {
                            credencial = FrmLogin.credencial_desde;
                        }
                    }

                }

                tipo = 1;
                if (Convert.ToInt32(CantidadT.Text) > 0)
                {
                    CantidadT.Text = Convert.ToString(Convert.ToInt32(CantidadT.Text) - 1);
                    cantidad = Convert.ToInt32(CantidadT.Text);
                    cantidad_fija = cantidad + 1;
                }

                Rectangle rect3 = new Rectangle(300, 230, 290, 70);
                e.Graphics.DrawRectangle(Pens.White, rect3);


                // fila 1
                Rectangle rect1 = new Rectangle(190, 87, 410, 45);
                //e.Graphics.DrawRectangle(Pens.Black, rect1);

                /////////// IMPRIMO CAMPEONATO ////////////
                if (FrmLogin.negritacampeonato == 1)
                {
                    e.Graphics.DrawString(Convert.ToString(txtCampeonato.Text), new Font(FrmLogin.nomfuentecampeonato, FrmLogin.sizecampeonato, FontStyle.Bold), Brushes.Black, rect1, stringFormat);
                }
                else
                {
                    e.Graphics.DrawString(Convert.ToString(txtCampeonato.Text), new Font(FrmLogin.nomfuentecampeonato, FrmLogin.sizecampeonato), Brushes.Black, rect1, stringFormat);
                }

                /////////// IMPRIMO FECHA ////////////

                Rectangle rect111 = new Rectangle(190, 107, 410, 45);
                if (FrmLogin.negritafecha == 1)
                {
                    e.Graphics.DrawString(Convert.ToString(txtFecha.Text), new Font(FrmLogin.nomfuentefecha, FrmLogin.sizefecha, FontStyle.Bold), Brushes.Black, rect111, stringFormat);
                }
                else
                {
                    e.Graphics.DrawString(Convert.ToString(txtFecha.Text), new Font(FrmLogin.nomfuentefecha, FrmLogin.sizefecha), Brushes.Black, rect111, stringFormat);
                }


                Rectangle rect0 = new Rectangle(190, 130, 410, 45);


                /////////// IMPRIMO RIVAL ////////////

                if (FrmLogin.negritarival == 1)
                {
                    e.Graphics.DrawString(txtRival.Text, new Font(FrmLogin.nomfuenterival, FrmLogin.sizerival, FontStyle.Bold), Brushes.Black, rect0, stringFormat);
                }
                else
                {
                    e.Graphics.DrawString(txtRival.Text, new Font(FrmLogin.nomfuenterival, FrmLogin.sizerival), Brushes.Black, rect0, stringFormat);

                }



                Pen mipen = new Pen(Color.Black, 7);
                e.Graphics.DrawLine(mipen, 170, 170, 630, 170);


                // fila 2

                Char delimiter = '-';
                int num = 190;
                String[] substrings = Convert.ToString(txtCanal.Text).Split(delimiter);
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

                Rectangle rect22 = new Rectangle(190, 250, 390, 60);
                e.Graphics.DrawRectangle(Pens.White, rect22);

                /////////// IMPRIMO UBICACION ////////////



                Rectangle rect44 = new Rectangle(200, 250, 390, 60);
                e.Graphics.DrawRectangle(Pens.White, rect44);


                if (FrmLogin.negritaubicacion == 1)
                {
                    e.Graphics.DrawString("PUPITRE DE PRENSA", new Font(FrmLogin.nomfuenteubicacion, FrmLogin.sizeubicacion, FontStyle.Bold), Brushes.Black, rect44, stringFormat);
                    Rectangle rect78 = new Rectangle(200, 290, 390, 60);
                    e.Graphics.DrawRectangle(Pens.White, rect78);
                    e.Graphics.DrawString("FILA Nº " + Convert.ToString(txtAsiento.Text) + " ASIENTO Nº " + Convert.ToString(txtFila.Text), new Font(FrmLogin.nomfuenteubicacion, 21, FontStyle.Bold), Brushes.Black, rect78, stringFormat);
                }
                else
                {

                    e.Graphics.DrawString("PUPITRE DE PRENSA", new Font(FrmLogin.nomfuenteubicacion, FrmLogin.sizeubicacion), Brushes.Black, rect44, stringFormat);
                    Rectangle rect78 = new Rectangle(200, 290, 390, 60);
                    e.Graphics.DrawRectangle(Pens.White, rect78);
                    e.Graphics.DrawString("FILA Nº " + Convert.ToString(txtAsiento.Text) + " ASIENTO Nº " + Convert.ToString(txtFila.Text), new Font(FrmLogin.nomfuenteubicacion, 21), Brushes.Black, rect78, stringFormat);
                }

                /// NOMBRE APELLIDO Y DNI
                if (txtNombre.Text != "")
                {
                    Rectangle rect23 = new Rectangle(170, 340, 420, 60);
                    e.Graphics.DrawRectangle(Pens.White, rect23);
                    if (FrmLogin.negritanombre == 1)
                    {
                        e.Graphics.DrawString(txtNombre.Text, new Font(FrmLogin.nomfuentenombre, FrmLogin.sizenombre, FontStyle.Bold), Brushes.Black, rect23, stringFormat);

                    }
                    else
                    {
                        e.Graphics.DrawString(txtNombre.Text, new Font(FrmLogin.nomfuentenombre, FrmLogin.sizenombre, FontStyle.Bold), Brushes.Black, rect23, stringFormat);


                    }
                }

                if (txtDni.Text != "")
                {
                    Rectangle rect6 = new Rectangle(170, 390, 420, 60);
                    e.Graphics.DrawRectangle(Pens.White, rect6);
                    if (FrmLogin.negritanombre == 1)
                    {
                        e.Graphics.DrawString(txtDni.Text, new Font(FrmLogin.nomfuentenombre, FrmLogin.sizenombre, FontStyle.Bold), Brushes.Black, rect6, stringFormat);
                    }
                    else
                    {
                        e.Graphics.DrawString(txtDni.Text, new Font(FrmLogin.nomfuentenombre, FrmLogin.sizenombre), Brushes.Black, rect6, stringFormat);
                    }

                }








                //credencial


                Rectangle rect12 = new Rectangle(370, 420, 390, 40);
                e.Graphics.DrawRectangle(Pens.White, rect12);
                e.Graphics.DrawString("Nº " + Convert.ToString(credencial).PadLeft(3, '0'), new Font("Arial Black", 14), Brushes.Black, rect12, stringFormat);

                Evento d = new Evento();
                numero_evento = d.traigo_numero_evento();
                                
                cmd = new MySqlCommand("Insert into impresiones(Torneo, Evento, Medio, Cantidad, Nombre, DNI, Credencial, Asiento, Fila, Cabina, Fecha, Tipo, Id_Evento, Estado, Usuario, Letras) values('" + txtCampeonato.Text + "', '" + txtRival.Text + "', '" + txtCanal.Text + "', '" + cantidad_fija + "', '" + txtNombre.Text + "', '" + txtDni.Text + "', '" + credencial + "', " + txtAsiento.Text + ", " + txtFila.Text + ", " + 0 + ", '" + lahora + "', " + tipo + ", " + numero_evento + ", 1, '" + FrmLogin.usu + "', '" + txtLetras.Text + "')", conectar);
                cmd.ExecuteNonQuery();




                // Actualizo el numero de credencial

                credencial++;


                if (credencial >= FrmLogin.credencial_hasta)
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
                    numero_id = d.traigo_ultimo_Id();
                    cadena = Convert.ToString(numero_id) + "#" + Convert.ToString(txtCanal.Text) + "*" + Convert.ToString(txtCabina.Text).PadLeft(2, '0') + "0000" + "^" + txtValor.Text;
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

                Rectangle rect29 = new Rectangle(210, 470, 380, 100);
                e.Graphics.DrawRectangle(Pens.White, rect29);
                e.Graphics.DrawString(txtLetras.Text, new Font("Arial", 32), Brushes.Black, rect29, stringFormat);


                if (cantidad == 0)
                {
                    new Evento().Traigo_Numeros_Credenciales(lbCabinas, lbPupitre12, lbMovil, lbTV);
                    MessageBox.Show("Finalizo la Impresion");

                    e.HasMorePages = false;
                    return;

                }
                else
                {
                    e.HasMorePages = true;
                    return;

                }


            }


            ////// MOVIL ////////

            if (campo.Checked == true)
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
                    Evento f = new Evento();
                    buscocredencial = f.buscarcredenciallibre(credencial, 3);
                    if (buscocredencial == 2)
                    {
                        credencial++;
                        if (credencial > FrmLogin.credencial_hasta)
                        {
                            credencial = FrmLogin.credencial_desde;
                        }
                    }

                }

                tipo = 1;
                if (Convert.ToInt32(CantidadT.Text) > 0)
                {
                    CantidadT.Text = Convert.ToString(Convert.ToInt32(CantidadT.Text) - 1);
                    cantidad = Convert.ToInt32(CantidadT.Text);
                    cantidad_fija = cantidad + 1;
                }

                Rectangle rect3 = new Rectangle(300, 230, 290, 70);
                e.Graphics.DrawRectangle(Pens.White, rect3);


                // fila 1
                Rectangle rect1 = new Rectangle(190, 87, 410, 45);
                //e.Graphics.DrawRectangle(Pens.Black, rect1);

                /////////// IMPRIMO CAMPEONATO ////////////
                if (FrmLogin.negritacampeonato == 1)
                {
                    e.Graphics.DrawString(Convert.ToString(txtCampeonato.Text), new Font(FrmLogin.nomfuentecampeonato, FrmLogin.sizecampeonato, FontStyle.Bold), Brushes.Black, rect1, stringFormat);
                }
                else
                {
                    e.Graphics.DrawString(Convert.ToString(txtCampeonato.Text), new Font(FrmLogin.nomfuentecampeonato, FrmLogin.sizecampeonato), Brushes.Black, rect1, stringFormat);
                }

                /////////// IMPRIMO FECHA ////////////

                Rectangle rect111 = new Rectangle(190, 107, 410, 45);
                if (FrmLogin.negritafecha == 1)
                {
                    e.Graphics.DrawString(Convert.ToString(txtFecha.Text), new Font(FrmLogin.nomfuentefecha, FrmLogin.sizefecha, FontStyle.Bold), Brushes.Black, rect111, stringFormat);
                }
                else
                {
                    e.Graphics.DrawString(Convert.ToString(txtFecha.Text), new Font(FrmLogin.nomfuentefecha, FrmLogin.sizefecha), Brushes.Black, rect111, stringFormat);
                }


                Rectangle rect0 = new Rectangle(190, 130, 410, 45);


                /////////// IMPRIMO RIVAL ////////////

                if (FrmLogin.negritarival == 1)
                {
                    e.Graphics.DrawString(txtRival.Text, new Font(FrmLogin.nomfuenterival, FrmLogin.sizerival, FontStyle.Bold), Brushes.Black, rect0, stringFormat);
                }
                else
                {
                    e.Graphics.DrawString(txtRival.Text, new Font(FrmLogin.nomfuenterival, FrmLogin.sizerival), Brushes.Black, rect0, stringFormat);

                }



                Pen mipen = new Pen(Color.Black, 7);
                e.Graphics.DrawLine(mipen, 170, 170, 630, 170);


                // fila 2

                Char delimiter = '-';
                int num = 190;
                String[] substrings = Convert.ToString(txtCanal.Text).Split(delimiter);
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

                Rectangle rect22 = new Rectangle(190, 250, 390, 60);
                e.Graphics.DrawRectangle(Pens.White, rect22);

                /////////// IMPRIMO UBICACION ////////////

                if (servicios_especiales.Checked == true)
                {
                    Rectangle rect44 = new Rectangle(200, 250, 390, 60);
                    e.Graphics.DrawRectangle(Pens.White, rect44);


                    if (FrmLogin.negritaubicacion == 1)
                    {
                        e.Graphics.DrawString("SERVICIOS ESPECIALES", new Font(FrmLogin.nomfuenteubicacion, FrmLogin.sizeubicacion, FontStyle.Bold), Brushes.Black, rect44, stringFormat);
                        
                    }
                    else
                    {
                        e.Graphics.DrawString("SERVICIOS ESPECIALES", new Font(FrmLogin.nomfuenteubicacion, FrmLogin.sizeubicacion), Brushes.Black, rect44, stringFormat);

                    }



                }


                /// NOMBRE APELLIDO Y DNI
                if (txtNombre.Text != "")
                {
                    Rectangle rect23 = new Rectangle(170, 340, 420, 60);
                    e.Graphics.DrawRectangle(Pens.White, rect23);
                    if (FrmLogin.negritanombre == 1)
                    {
                        e.Graphics.DrawString(txtNombre.Text, new Font(FrmLogin.nomfuentenombre, FrmLogin.sizenombre, FontStyle.Bold), Brushes.Black, rect23, stringFormat);

                    }
                    else
                    {
                        e.Graphics.DrawString(txtNombre.Text, new Font(FrmLogin.nomfuentenombre, FrmLogin.sizenombre, FontStyle.Bold), Brushes.Black, rect23, stringFormat);


                    }
                }

                if (txtDni.Text != "")
                {
                    Rectangle rect6 = new Rectangle(170, 390, 420, 60);
                    e.Graphics.DrawRectangle(Pens.White, rect6);
                    if (FrmLogin.negritanombre == 1)
                    {
                        e.Graphics.DrawString(txtDni.Text, new Font(FrmLogin.nomfuentenombre, FrmLogin.sizenombre, FontStyle.Bold), Brushes.Black, rect6, stringFormat);
                    }
                    else
                    {
                        e.Graphics.DrawString(txtDni.Text, new Font(FrmLogin.nomfuentenombre, FrmLogin.sizenombre), Brushes.Black, rect6, stringFormat);
                    }

                }


                //credencial


                Rectangle rect12 = new Rectangle(370, 420, 390, 40);
                e.Graphics.DrawRectangle(Pens.White, rect12);
                e.Graphics.DrawString("Nº " + Convert.ToString(credencial).PadLeft(3, '0'), new Font("Arial Black", 14), Brushes.Black, rect12, stringFormat);

                Evento d = new Evento();
                numero_evento = d.traigo_numero_evento();
                cmd = new MySqlCommand("Insert into impresiones(Torneo, Evento, Medio, Cantidad, Nombre, DNI, Credencial, Asiento, Fila, Cabina, Fecha, Tipo, Id_Evento, Estado, Usuario, Letras) values('" + txtCampeonato.Text + "', '" + txtRival.Text + "', '" + txtCanal.Text + "', '" + cantidad_fija + "', '" + txtNombre.Text + "', '" + txtDni.Text + "', '" + credencial + "', " + 0 + ", " + 0 + ", " + 0 + ", '" + lahora + "', " + tipo + ", " + numero_evento + ", 1, '" + FrmLogin.usu + "', '" + txtLetras.Text + "')", conectar);
                
                cmd.ExecuteNonQuery();




                // Actualizo el numero de credencial

                credencial++;


                if (credencial >= FrmLogin.credencial_hasta)
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
                    numero_id = d.traigo_ultimo_Id();
                    cadena = Convert.ToString(numero_id) + "#" + Convert.ToString(txtCanal.Text) + "*" + Convert.ToString(txtCabina.Text).PadLeft(2, '0') + "0000" + "^" + txtValor.Text;
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

                Rectangle rect29 = new Rectangle(210, 470, 380, 100);
                e.Graphics.DrawRectangle(Pens.White, rect29);
                e.Graphics.DrawString(txtLetras.Text, new Font("Arial", 32), Brushes.Black, rect29, stringFormat);


                if (cantidad == 0)
                {
                    new Evento().Traigo_Numeros_Credenciales(lbCabinas, lbPupitre12, lbMovil, lbTV);
                    MessageBox.Show("Finalizo la Impresion");

                    e.HasMorePages = false;
                    return;

                }
                else
                {
                    e.HasMorePages = true;
                    return;

                }

            }





            ////// TV ////////

            if (tv.Checked == true)
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
                    Evento f = new Evento();
                    buscocredencial = f.buscarcredenciallibre(credencial, 4);
                    if (buscocredencial == 2)
                    {
                        credencial++;
                        if (credencial > FrmLogin.credencial_hasta)
                        {
                            credencial = FrmLogin.credencial_desde;
                        }
                    }

                }

                tipo = 1;
                if (Convert.ToInt32(CantidadT.Text) > 0)
                {
                    CantidadT.Text = Convert.ToString(Convert.ToInt32(CantidadT.Text) - 1);
                    cantidad = Convert.ToInt32(CantidadT.Text);
                    cantidad_fija = cantidad + 1;
                }

                Rectangle rect3 = new Rectangle(300, 230, 290, 70);
                e.Graphics.DrawRectangle(Pens.White, rect3);


                // fila 1
                Rectangle rect1 = new Rectangle(190, 87, 410, 45);
                //e.Graphics.DrawRectangle(Pens.Black, rect1);

                /////////// IMPRIMO CAMPEONATO ////////////
                if (FrmLogin.negritacampeonato == 1)
                {
                    e.Graphics.DrawString(Convert.ToString(txtCampeonato.Text), new Font(FrmLogin.nomfuentecampeonato, FrmLogin.sizecampeonato, FontStyle.Bold), Brushes.Black, rect1, stringFormat);
                }
                else
                {
                    e.Graphics.DrawString(Convert.ToString(txtCampeonato.Text), new Font(FrmLogin.nomfuentecampeonato, FrmLogin.sizecampeonato), Brushes.Black, rect1, stringFormat);
                }

                /////////// IMPRIMO FECHA ////////////

                Rectangle rect111 = new Rectangle(190, 107, 410, 45);
                if (FrmLogin.negritafecha == 1)
                {
                    e.Graphics.DrawString(Convert.ToString(txtFecha.Text), new Font(FrmLogin.nomfuentefecha, FrmLogin.sizefecha, FontStyle.Bold), Brushes.Black, rect111, stringFormat);
                }
                else
                {
                    e.Graphics.DrawString(Convert.ToString(txtFecha.Text), new Font(FrmLogin.nomfuentefecha, FrmLogin.sizefecha), Brushes.Black, rect111, stringFormat);
                }


                Rectangle rect0 = new Rectangle(190, 130, 410, 45);


                /////////// IMPRIMO RIVAL ////////////

                if (FrmLogin.negritarival == 1)
                {
                    e.Graphics.DrawString(txtRival.Text, new Font(FrmLogin.nomfuenterival, FrmLogin.sizerival, FontStyle.Bold), Brushes.Black, rect0, stringFormat);
                }
                else
                {
                    e.Graphics.DrawString(txtRival.Text, new Font(FrmLogin.nomfuenterival, FrmLogin.sizerival), Brushes.Black, rect0, stringFormat);

                }



                Pen mipen = new Pen(Color.Black, 7);
                e.Graphics.DrawLine(mipen, 170, 170, 630, 170);


                // fila 2

                Char delimiter = '-';
                int num = 190;
                String[] substrings = Convert.ToString(txtCanal.Text).Split(delimiter);
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

                Rectangle rect22 = new Rectangle(190, 250, 390, 60);
                e.Graphics.DrawRectangle(Pens.White, rect22);

                /////////// IMPRIMO UBICACION ////////////

                if (FrmLogin.negritaubicacion == 1)
                {
                    e.Graphics.DrawString("CAMPO DE", new Font(FrmLogin.nomfuenteubicacion, FrmLogin.sizeubicacion, FontStyle.Bold), Brushes.Black, rect22, stringFormat);
                }
                else
                {
                    e.Graphics.DrawString("CAMPO DE", new Font(FrmLogin.nomfuenteubicacion, FrmLogin.sizeubicacion), Brushes.Black, rect22, stringFormat);
                }


                Rectangle rect4 = new Rectangle(190, 290, 390, 60);
                e.Graphics.DrawRectangle(Pens.White, rect4);

                if (FrmLogin.negritaubicacion == 1)
                {
                    e.Graphics.DrawString("JUEGO",  new Font(FrmLogin.nomfuenteubicacion, FrmLogin.sizeubicacion, FontStyle.Bold), Brushes.Black, rect4, stringFormat);
                }
                else
                {

                    e.Graphics.DrawString("JUEGO" , new Font(FrmLogin.nomfuenteubicacion, FrmLogin.sizeubicacion), Brushes.Black, rect4, stringFormat);

                }



                /// NOMBRE APELLIDO Y DNI
                if (txtNombre.Text != "")
                {
                    Rectangle rect23 = new Rectangle(170, 340, 420, 60);
                    e.Graphics.DrawRectangle(Pens.White, rect23);
                    if (FrmLogin.negritanombre == 1)
                    {
                        e.Graphics.DrawString(txtNombre.Text, new Font(FrmLogin.nomfuentenombre, FrmLogin.sizenombre, FontStyle.Bold), Brushes.Black, rect23, stringFormat);

                    }
                    else
                    {
                        e.Graphics.DrawString(txtNombre.Text, new Font(FrmLogin.nomfuentenombre, FrmLogin.sizenombre, FontStyle.Bold), Brushes.Black, rect23, stringFormat);


                    }
                }

                if (txtDni.Text != "")
                {
                    Rectangle rect6 = new Rectangle(170, 390, 420, 60);
                    e.Graphics.DrawRectangle(Pens.White, rect6);
                    if (FrmLogin.negritanombre == 1)
                    {
                        e.Graphics.DrawString(txtDni.Text, new Font(FrmLogin.nomfuentenombre, FrmLogin.sizenombre, FontStyle.Bold), Brushes.Black, rect6, stringFormat);
                    }
                    else
                    {
                        e.Graphics.DrawString(txtDni.Text, new Font(FrmLogin.nomfuentenombre, FrmLogin.sizenombre), Brushes.Black, rect6, stringFormat);
                    }

                }



                //credencial


                Rectangle rect12 = new Rectangle(370, 420, 390, 40);
                e.Graphics.DrawRectangle(Pens.White, rect12);
                e.Graphics.DrawString("Nº " + Convert.ToString(credencial).PadLeft(3, '0'), new Font("Arial Black", 14), Brushes.Black, rect12, stringFormat);

                Evento d = new Evento();
                numero_evento = d.traigo_numero_evento();

                cmd = new MySqlCommand("Insert into impresiones(Torneo, Evento, Medio, Cantidad, Nombre, DNI, Credencial, Asiento, Fila, Cabina, Fecha, Tipo, Id_Evento, Estado, Usuario, Letras) values('" + txtCampeonato.Text + "', '" + txtRival.Text + "', '" + txtCanal.Text + "', '" + cantidad_fija + "', '" + txtNombre.Text + "', '" + txtDni.Text + "', '" + credencial + "', " + 0 + ", " + 0 + ", " + 0 + ", '" + lahora + "', " + tipo + ", " + numero_evento + ", 1, '" + FrmLogin.usu + "', '" + txtLetras.Text + "')", conectar);
                cmd.ExecuteNonQuery();




                // Actualizo el numero de credencial

                credencial++;


                if (credencial >= FrmLogin.credencial_hasta)
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
                    numero_id = d.traigo_ultimo_Id();
                    cadena = Convert.ToString(numero_id) + "#" + Convert.ToString(txtCanal.Text) + "*" + Convert.ToString(txtCabina.Text).PadLeft(2, '0') + "0000" + "^" + txtValor.Text;
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

                Rectangle rect29 = new Rectangle(210, 470, 380, 100);
                e.Graphics.DrawRectangle(Pens.White, rect29);
                e.Graphics.DrawString(txtLetras.Text, new Font("Arial", 32), Brushes.Black, rect29, stringFormat);


                if (cantidad == 0)
                {
                    new Evento().Traigo_Numeros_Credenciales(lbCabinas, lbPupitre12, lbMovil, lbTV);
                    MessageBox.Show("Finalizo la Impresion");

                    e.HasMorePages = false;
                    return;

                }
                else
                {
                    e.HasMorePages = true;
                    return;

                }

            }



        }

        private void button4_Click(object sender, EventArgs e)
        {
            int sigo = 1;

            if (MessageBox.Show(" Esta seguro que quiere imprimir los registros seleccionado ?", "Imprimir registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (CantidadT.Value == 0)
                {
                    sigo = 2;
                    MessageBox.Show("La cantidad de copias debe ser mayor a cero");
                }

                if (cabina.Checked == true)
                {
                    if (string.IsNullOrEmpty(Convert.ToString(txtCabina.Text)))
                    {
                        sigo = 2;
                        MessageBox.Show("Numero de cabina en blanco");
                    }
                }

                if (pupitre.Checked == true)
                {
                    if ((string.IsNullOrEmpty(Convert.ToString(txtAsiento.Text))) | (string.IsNullOrEmpty(Convert.ToString(txtFila.Text))))
                    {
                        sigo = 2;
                        MessageBox.Show("Numero de asiento o fila cabina en blanco");
                    }
                }


                if (sigo == 1)
                {


                    PrinterSettings settings = new PrinterSettings();
                    PaperSize paperSize = new PaperSize("A4", 210, 297);
                    printDocument2.PrinterSettings.DefaultPageSettings.PaperSize = paperSize;
                    printDocument2.Print();

                }


            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int sigo = 1;

            if (MessageBox.Show(" Esta seguro que quiere imprimir los registros seleccionado ?", "Imprimir registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (CantidadT.Value == 0)
                {
                    sigo = 2;
                    MessageBox.Show("La cantidad de copias debe ser mayor a cero");
                }

                if (cabina.Checked == true)
                {
                    if (string.IsNullOrEmpty(Convert.ToString(txtCabina.Text)))
                    {
                        sigo = 2;
                        MessageBox.Show("Numero de cabina en blanco");
                    }
                }

                if (pupitre.Checked == true)
                {
                    if ((string.IsNullOrEmpty(Convert.ToString(txtAsiento.Text))) | (string.IsNullOrEmpty(Convert.ToString(txtFila.Text))))
                    {
                        sigo = 2;
                        MessageBox.Show("Numero de asiento o fila cabina en blanco");
                    }
                }


                if (sigo == 1)
                {


                    PrinterSettings settings = new PrinterSettings();
                    PaperSize paperSize = new PaperSize("A4", 210, 297);
                    printDocument3.PrinterSettings.DefaultPageSettings.PaperSize = paperSize;
                    printDocument3.Print();

                }


            }
        }

        private void printDocument3_PrintPage(object sender, PrintPageEventArgs e)
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

            if (cabina.Checked == true)
            {
                conectar = Conexion.ObtenerConexion();
                cmd = new MySqlCommand("SELECT Credencial_Anual_Cabinas FROM setup", conectar);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    credencial = dr.GetInt32(0);
                }
                dr.Close();


                while (buscocredencial == 2)
                {
                    Evento f = new Evento();
                    buscocredencial = f.buscarcredenciallibre(credencial, 1);
                    if (buscocredencial == 2)
                    {
                        credencial++;
                        if (credencial > FrmLogin.credencial_anual_hasta)
                        {
                            credencial = FrmLogin.credencial_anual_desde;
                        }
                    }

                }

                tipo = 1;
                if (Convert.ToInt32(CantidadT.Text) > 0)
                {
                    CantidadT.Text = Convert.ToString(Convert.ToInt32(CantidadT.Text) - 1);
                    cantidad = Convert.ToInt32(CantidadT.Text);
                    cantidad_fija = cantidad + 1;
                }

                Rectangle rect3 = new Rectangle(300, 230, 290, 70);
                e.Graphics.DrawRectangle(Pens.White, rect3);



                // fila 1
                Pen mipen = new Pen(Color.Black, 35);
                e.Graphics.DrawLine(mipen, 170, 115, 630, 114);
                Rectangle rect1 = new Rectangle(190, 90, 420, 45);
                //e.Graphics.DrawRectangle(Pens.Black, rect1);
                e.Graphics.DrawString("CREDENCIAL ANUAL 2019", new Font("Arial Black", 17), Brushes.White, rect1, stringFormat);
                Rectangle rect0 = new Rectangle(190, 130, 420, 45);
                //  e.Graphics.DrawRectangle(Pens.Black, rect0);
                e.Graphics.DrawString("SUPERLIGA 2019-COPAS CONMEBOL 2019", new Font("Arial Black", 11), Brushes.Black, rect0, stringFormat);
                Pen mipens = new Pen(Color.Black, 7);
                e.Graphics.DrawLine(mipens, 170, 170, 630, 170);



                // fila 2

                Char delimiter = '-';
                int num = 190;
                String[] substrings = Convert.ToString(txtCanal.Text).Split(delimiter);
                foreach (var substring in substrings)
                {
                    Rectangle rect2 = new Rectangle(170, num, 430, 30);
                    e.Graphics.DrawRectangle(Pens.White, rect2);
                    e.Graphics.DrawString(substring, new Font("Arial Black", 21), Brushes.Black, rect2, stringFormat);
                    num = num + 30;
                }
                Pen mipen1 = new Pen(Color.Black, 7);
                e.Graphics.DrawLine(mipen1, 170, 260, 630, 260);



                // fila 3

                Rectangle rect22 = new Rectangle(200, 250, 390, 60);
                e.Graphics.DrawRectangle(Pens.White, rect22);
                e.Graphics.DrawString("CABINA DE PRENSA", new Font("Arial Black", 21), Brushes.Black, rect22, stringFormat);
                Rectangle rect4 = new Rectangle(190, 290, 390, 60);
                e.Graphics.DrawRectangle(Pens.White, rect4);
                e.Graphics.DrawString("CABINA Nº " + txtCabina.Text, new Font("Arial Black", 21), Brushes.Black, rect4, stringFormat);


                if (txtNombre.Text != "")
                {
                    Rectangle rect23 = new Rectangle(170, 340, 390, 60);
                    e.Graphics.DrawRectangle(Pens.White, rect23);
                    e.Graphics.DrawString(txtNombre.Text, new Font("Arial Black", 21), Brushes.Black, rect23, stringFormat);
                    if (txtDni.Text != "")
                    {
                        Rectangle rect6 = new Rectangle(170, 390, 390, 60);
                        e.Graphics.DrawRectangle(Pens.White, rect6);
                        e.Graphics.DrawString(txtDni.Text, new Font("Arial Black", 21), Brushes.Black, rect6, stringFormat);
                    }


                }


                //credencial


                Rectangle rect12 = new Rectangle(370, 420, 390, 40);
                e.Graphics.DrawRectangle(Pens.White, rect12);
                e.Graphics.DrawString("Nº " + Convert.ToString(credencial).PadLeft(3, '0'), new Font("Arial Black", 14), Brushes.Black, rect12, stringFormat);

                Evento d = new Evento();
                numero_evento = d.traigo_numero_evento();

                cmd = new MySqlCommand("Insert into impresiones(Torneo, Evento, Medio, Cantidad, Nombre, DNI, Credencial, Asiento, Fila, Cabina, Fecha, Tipo, Id_Evento, Estado, Usuario) values('" + txtCampeonato.Text + "', '" + txtRival.Text + "', '" + txtCanal.Text + "', '" + cantidad_fija + "', '" + txtNombre.Text + "', '" + txtDni.Text + "', '" + credencial + "', " + 0 + ", " + 0 + ", " + txtCabina.Text + ", '" + lahora + "', " + tipo + ", " + numero_evento + ", 1, '" + FrmLogin.usu + "')", conectar);
                cmd.ExecuteNonQuery();




                // Actualizo el numero de credencial

                credencial++;


                if (credencial >= FrmLogin.credencial_anual_hasta)
                {
                    cmd = new MySqlCommand("UPDATE setup SET Credencial_Anual_Cabinas =" + FrmLogin.credencial_anual_desde, conectar);
                    cmd.ExecuteNonQuery();
                    credencial = FrmLogin.credencial_anual_desde;
                }
                else
                {
                    cmd = new MySqlCommand("UPDATE setup SET Credencial_Anual_Cabinas =" + credencial, conectar);
                    cmd.ExecuteNonQuery();
                }

                // QR


                if (imprimiqr.Checked == true)
                {
                    numero_id = d.traigo_ultimo_Id();
                    cadena = Convert.ToString(numero_id) + "#" + Convert.ToString(txtCanal.Text) + "*" + Convert.ToString(txtCabina.Text).PadLeft(2, '0') + "0000" + "^" + txtValor.Text;
                    QrCode qrCode = new QrCode();
                    qrEncoder.TryEncode(cadena, out qrCode);
                    GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.Black, Brushes.White);
                    MemoryStream ms = new MemoryStream();
                    renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
                    var imageTemporal = new Bitmap(ms);
                    var imagen = new Bitmap(imageTemporal, new Size(new Point(100, 100)));
                    panelResultado.BackgroundImage = imagen;

                    //     e.Graphics.DrawImage(panelResultado.BackgroundImage, 220, 470, 100, 100);
                    e.Graphics.DrawImage(panelResultado.BackgroundImage, 180, 490, 100, 100);

                }

                Rectangle rect29 = new Rectangle(210, 470, 380, 100);
                e.Graphics.DrawRectangle(Pens.White, rect29);
                e.Graphics.DrawString(txtLetras.Text, new Font("Arial", 32), Brushes.Black, rect29, stringFormat);


                if (cantidad == 0)
                {
                    new Evento().Traigo_Numeros_Credenciales_Anuales(lbCabinaAnual, lbPupitreAnual, lbMovilAnual, lbTVAnual);
                    MessageBox.Show("Finalizo la Impresion");

                    e.HasMorePages = false;
                    return;

                }
                else
                {
                    e.HasMorePages = true;
                    return;

                }

            }



            ////// PUPITRE ////////

            if (pupitre.Checked == true)
            {
                conectar = Conexion.ObtenerConexion();
                cmd = new MySqlCommand("SELECT Credencial_Anual_Pupitres FROM setup", conectar);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    credencial = dr.GetInt32(0);
                }
                dr.Close();


                while (buscocredencial == 2)
                {
                    Evento f = new Evento();
                    buscocredencial = f.buscarcredenciallibre(credencial, 1);
                    if (buscocredencial == 2)
                    {
                        credencial++;
                        if (credencial > FrmLogin.credencial_anual_hasta)
                        {
                            credencial = FrmLogin.credencial_anual_desde;
                        }
                    }

                }


                tipo = 2;
                if (Convert.ToInt32(CantidadT.Text) > 0)
                {
                    CantidadT.Text = Convert.ToString(Convert.ToInt32(CantidadT.Text) - 1);
                    cantidad = Convert.ToInt32(CantidadT.Text);
                    cantidad_fija = cantidad + 1;
                }

                Rectangle rect3 = new Rectangle(300, 230, 290, 70);
                e.Graphics.DrawRectangle(Pens.White, rect3);



                // fila 1
                Pen mipen = new Pen(Color.Black, 35);
                e.Graphics.DrawLine(mipen, 170, 115, 630, 114);
                Rectangle rect1 = new Rectangle(190, 90, 420, 45);
                //e.Graphics.DrawRectangle(Pens.Black, rect1);
                e.Graphics.DrawString("CREDENCIAL ANUAL 2019", new Font("Arial Black", 17), Brushes.White, rect1, stringFormat);
                Rectangle rect0 = new Rectangle(190, 130, 420, 45);
                //  e.Graphics.DrawRectangle(Pens.Black, rect0);
                e.Graphics.DrawString("SUPERLIGA 2019-COPAS CONMEBOL 2019", new Font("Arial Black", 11), Brushes.Black, rect0, stringFormat);
                Pen mipens = new Pen(Color.Black, 7);
                e.Graphics.DrawLine(mipens, 170, 170, 630, 170);


                // fila 2

                Char delimiter = '-';
                int num = 190;
                String[] substrings = Convert.ToString(txtCanal.Text).Split(delimiter);
                foreach (var substring in substrings)
                {
                    Rectangle rect2 = new Rectangle(170, num, 430, 30);
                    e.Graphics.DrawRectangle(Pens.White, rect2);
                    e.Graphics.DrawString(substring, new Font("Arial Black", 21), Brushes.Black, rect2, stringFormat);
                    num = num + 30;
                }
                Pen mipen1 = new Pen(Color.Black, 7);
                e.Graphics.DrawLine(mipen1, 170, 260, 630, 260);



                // fila 3

                Rectangle rect22 = new Rectangle(200, 250, 390, 60);
                e.Graphics.DrawRectangle(Pens.White, rect22);
                e.Graphics.DrawString("PUPITRE DE PRENSA", new Font("Arial Black", 21), Brushes.Black, rect22, stringFormat);
                Rectangle rect4 = new Rectangle(190, 290, 390, 60);
                e.Graphics.DrawRectangle(Pens.White, rect4);
                e.Graphics.DrawString("FILA Nº " + Convert.ToString(txtFila.Text) + " ASIENTO Nº " + Convert.ToString(txtAsiento.Text), new Font("Arial Black", 18), Brushes.Black, rect4, stringFormat);

                if (txtNombre.Text != "")
                {
                    Rectangle rect23 = new Rectangle(170, 340, 390, 60);
                    e.Graphics.DrawRectangle(Pens.White, rect23);
                    e.Graphics.DrawString(Convert.ToString(txtNombre.Text), new Font("Arial Black", 21), Brushes.Black, rect23, stringFormat);
                    if (txtDni.Text != "")
                    {
                        Rectangle rect6 = new Rectangle(170, 390, 390, 60);
                        e.Graphics.DrawRectangle(Pens.White, rect6);
                        e.Graphics.DrawString(Convert.ToString(txtDni.Text), new Font("Arial Black", 21), Brushes.Black, rect6, stringFormat);
                    }


                }

                //credencial


                Rectangle rect12 = new Rectangle(370, 420, 390, 40);
                e.Graphics.DrawRectangle(Pens.White, rect12);
                e.Graphics.DrawString("Nº " + Convert.ToString(credencial).PadLeft(3, '0'), new Font("Arial Black", 14), Brushes.Black, rect12, stringFormat);

                conectar = Conexion.ObtenerConexion();
                Evento d = new Evento();
                numero_evento = d.traigo_numero_evento();


                cmd = new MySqlCommand("Insert into impresiones(Torneo, Evento, Medio, Cantidad, Nombre, DNI, Credencial, Asiento, Fila, Cabina, Fecha, Tipo, Id_Evento, Estado, Usuario) values('" + txtCampeonato.Text + "', '" + txtRival.Text + "', '" + txtCanal.Text + "', '" + cantidad_fija + "', '" + txtNombre.Text + "', '" + txtDni.Text + "', '" + credencial + "', " + txtAsiento.Text + ", " + txtFila.Text + ", " + 0 + ", '" + lahora + "', " + tipo + ", " + numero_evento + ", 1, '" + FrmLogin.usu + "')", conectar);
                cmd.ExecuteNonQuery();




                // Actualizo el numero de credencial

                credencial++;
                conectar = Conexion.ObtenerConexion();

                if (credencial > FrmLogin.credencial_anual_hasta)
                {
                    cmd = new MySqlCommand("UPDATE setup SET Credencial_Anual_Pupitres =" + FrmLogin.credencial_anual_desde, conectar);
                    cmd.ExecuteNonQuery();
                    credencial = FrmLogin.credencial_anual_desde;
                }
                else
                {
                    cmd = new MySqlCommand("UPDATE setup SET Credencial_Anual_Pupitres =" + credencial, conectar);
                    cmd.ExecuteNonQuery();
                }

                // QR


                if (imprimiqr.Checked == true)
                {
                    numero_id = d.traigo_ultimo_Id();
                    cadena = Convert.ToString(numero_id) + "#" + Convert.ToString(txtCanal.Text) + "*" + Convert.ToString(txtCabina.Text).PadLeft(2, '0') + "0000" + "^" + txtValor.Text;
                    QrCode qrCode = new QrCode();
                    qrEncoder.TryEncode(cadena, out qrCode);
                    GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.Black, Brushes.White);
                    MemoryStream ms = new MemoryStream();
                    renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
                    var imageTemporal = new Bitmap(ms);
                    var imagen = new Bitmap(imageTemporal, new Size(new Point(100, 100)));
                    panelResultado.BackgroundImage = imagen;

                    //     e.Graphics.DrawImage(panelResultado.BackgroundImage, 220, 470, 100, 100);
                    e.Graphics.DrawImage(panelResultado.BackgroundImage, 180, 490, 100, 100);

                }



                Rectangle rect29 = new Rectangle(210, 470, 380, 100);
                e.Graphics.DrawRectangle(Pens.White, rect29);
                e.Graphics.DrawString(txtLetras.Text, new Font("Arial", 32), Brushes.Black, rect29, stringFormat);


                if (cantidad == 0)
                {
                    new Evento().Traigo_Numeros_Credenciales_Anuales(lbCabinaAnual, lbPupitreAnual, lbMovilAnual, lbTVAnual);
                    MessageBox.Show("Finalizo la Impresion");

                    e.HasMorePages = false;
                    return;

                }
                else
                {
                    e.HasMorePages = true;
                    return;

                }

            }


            ////// MOVIL ////////

            if (campo.Checked == true)
            {
                conectar = Conexion.ObtenerConexion();
                cmd = new MySqlCommand("SELECT Credencial_Anual_Moviles FROM setup", conectar);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    credencial = dr.GetInt32(0);
                }
                dr.Close();


                while (buscocredencial == 2)
                {
                    Evento f = new Evento();
                    buscocredencial = f.buscarcredenciallibre(credencial, 1);
                    if (buscocredencial == 2)
                    {
                        credencial++;
                        if (credencial > FrmLogin.credencial_anual_hasta)
                        {
                            credencial = FrmLogin.credencial_anual_desde;
                        }
                    }

                }

                tipo = 3;
                if (Convert.ToInt32(CantidadT.Text) > 0)
                {
                    CantidadT.Text = Convert.ToString(Convert.ToInt32(CantidadT.Text) - 1);
                    cantidad = Convert.ToInt32(CantidadT.Text);
                    cantidad_fija = cantidad + 1;
                }

                Rectangle rect3 = new Rectangle(300, 230, 290, 70);
                e.Graphics.DrawRectangle(Pens.White, rect3);



                // fila 1
                Pen mipen = new Pen(Color.Black, 35);
                e.Graphics.DrawLine(mipen, 170, 115, 630, 114);
                Rectangle rect1 = new Rectangle(190, 90, 420, 45);
                //e.Graphics.DrawRectangle(Pens.Black, rect1);
                e.Graphics.DrawString("CREDENCIAL ANUAL 2019", new Font("Arial Black", 17), Brushes.White, rect1, stringFormat);
                Rectangle rect0 = new Rectangle(190, 130, 420, 45);
                //  e.Graphics.DrawRectangle(Pens.Black, rect0);
                e.Graphics.DrawString("SUPERLIGA 2019-COPAS CONMEBOL 2019", new Font("Arial Black", 11), Brushes.Black, rect0, stringFormat);
                Pen mipens = new Pen(Color.Black, 7);
                e.Graphics.DrawLine(mipens, 170, 170, 630, 170);


                // fila 2

                Char delimiter = '-';
                int num = 190;
                String[] substrings = Convert.ToString(txtCanal.Text).Split(delimiter);
                foreach (var substring in substrings)
                {
                    Rectangle rect2 = new Rectangle(170, num, 430, 30);
                    e.Graphics.DrawRectangle(Pens.White, rect2);
                    e.Graphics.DrawString(substring, new Font("Arial Black", 21), Brushes.Black, rect2, stringFormat);
                    num = num + 30;
                }
                Pen mipen1 = new Pen(Color.Black, 7);
                e.Graphics.DrawLine(mipen1, 170, 260, 630, 260);




                // fila 3

                //  Rectangle rect22 = new Rectangle(200, 265, 390, 60);
                //  e.Graphics.DrawRectangle(Pens.White, rect22);
                //  e.Graphics.DrawString("MOVIL", new Font("Arial Black", 21), Brushes.Black, rect22, stringFormat);
                //  Rectangle rect4 = new Rectangle(200, 290, 390, 60);
                //  e.Graphics.DrawRectangle(Pens.White, rect4);
                //  e.Graphics.DrawString("ACCESO A DESIGNAR", new Font("Arial Black", 21), Brushes.Black, rect4, stringFormat);


                if (txtNombre.Text != "")
                {
                    Rectangle rect23 = new Rectangle(180, 340, 390, 60);
                    e.Graphics.DrawRectangle(Pens.White, rect23);
                    e.Graphics.DrawString(txtNombre.Text, new Font("Arial Black", 21), Brushes.Black, rect23, stringFormat);
                    if (txtDni.Text != "")
                    {
                        Rectangle rect6 = new Rectangle(170, 390, 390, 60);
                        e.Graphics.DrawRectangle(Pens.White, rect6);
                        e.Graphics.DrawString(txtDni.Text, new Font("Arial Black", 21), Brushes.Black, rect6, stringFormat);
                    }


                }

                //credencial


                Rectangle rect12 = new Rectangle(370, 420, 390, 40);
                e.Graphics.DrawRectangle(Pens.White, rect12);
                e.Graphics.DrawString("Nº " + Convert.ToString(credencial).PadLeft(3, '0'), new Font("Arial Black", 14), Brushes.Black, rect12, stringFormat);

                conectar = Conexion.ObtenerConexion();

                Evento d = new Evento();
                numero_evento = d.traigo_numero_evento();

                cmd = new MySqlCommand("Insert into impresiones(Torneo, Evento, Medio, Cantidad, Nombre, DNI, Credencial, Asiento, Fila, Cabina, Fecha, Tipo, Id_Evento, Estado, Usuario) values('" + txtCampeonato.Text + "', '" + txtRival.Text + "', '" + txtCanal.Text + "', '" + cantidad_fija + "', '" + txtNombre.Text + "', '" + txtDni.Text + "', '" + credencial + "', " + 0 + ", " + 0 + ", " + 0 + ", '" + lahora + "', " + tipo + ", " + numero_evento + ", 1, '" + FrmLogin.usu + "')", conectar);
                cmd.ExecuteNonQuery();



                // QR
                if (imprimiqr.Checked == true)
                {
                    numero_id = d.traigo_ultimo_Id();
                    cadena = Convert.ToString(numero_id) + "#" + Convert.ToString(txtCanal.Text) + "*" + Convert.ToString(txtCabina.Text).PadLeft(2, '0') + "0000" + "^" + txtValor.Text;
                    QrCode qrCode = new QrCode();
                    qrEncoder.TryEncode(cadena, out qrCode);
                    GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.Black, Brushes.White);
                    MemoryStream ms = new MemoryStream();
                    renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
                    var imageTemporal = new Bitmap(ms);
                    var imagen = new Bitmap(imageTemporal, new Size(new Point(100, 100)));
                    panelResultado.BackgroundImage = imagen;

                    //     e.Graphics.DrawImage(panelResultado.BackgroundImage, 220, 470, 100, 100);
                    e.Graphics.DrawImage(panelResultado.BackgroundImage, 180, 490, 100, 100);

                }


                Rectangle rect29 = new Rectangle(210, 470, 380, 100);
                e.Graphics.DrawRectangle(Pens.White, rect29);
                e.Graphics.DrawString(txtLetras.Text, new Font("Arial", 32), Brushes.Black, rect29, stringFormat);

                // Actualizo el numero de credencial

                credencial++;
                conectar = Conexion.ObtenerConexion();

                if (credencial > FrmLogin.credencial_anual_hasta)
                {
                    cmd = new MySqlCommand("UPDATE setup SET Credencial_Anual_Moviles =" + FrmLogin.credencial_anual_desde, conectar);
                    cmd.ExecuteNonQuery();
                    credencial = FrmLogin.credencial_anual_desde;
                }
                else
                {
                    cmd = new MySqlCommand("UPDATE setup SET Credencial_Anual_Moviles =" + credencial, conectar);
                    cmd.ExecuteNonQuery();
                }







                if (cantidad == 0)
                {
                    new Evento().Traigo_Numeros_Credenciales_Anuales(lbCabinaAnual, lbPupitreAnual, lbMovilAnual, lbTVAnual);
                    MessageBox.Show("Finalizo la Impresion");

                    e.HasMorePages = false;
                    return;

                }
                else
                {
                    e.HasMorePages = true;
                    return;

                }

            }





            ////// TV ////////

            if (tv.Checked == true)
            {
                conectar = Conexion.ObtenerConexion();
                cmd = new MySqlCommand("SELECT Credencial_Anual_TV FROM setup", conectar);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    credencial = dr.GetInt32(0);
                }
                dr.Close();


                while (buscocredencial == 2)
                {
                    Evento f = new Evento();
                    buscocredencial = f.buscarcredenciallibre(credencial, 1);
                    if (buscocredencial == 2)
                    {
                        credencial++;
                        if (credencial > FrmLogin.credencial_anual_hasta)
                        {
                            credencial = FrmLogin.credencial_anual_desde;
                        }
                    }

                }

                tipo = 4;
                if (Convert.ToInt32(CantidadT.Text) > 0)
                {
                    CantidadT.Text = Convert.ToString(Convert.ToInt32(CantidadT.Text) - 1);
                    cantidad = Convert.ToInt32(CantidadT.Text);
                    cantidad_fija = cantidad + 1;
                }

                Rectangle rect3 = new Rectangle(300, 230, 290, 70);
                e.Graphics.DrawRectangle(Pens.White, rect3);



                // fila 1
                Pen mipen = new Pen(Color.Black, 35);
                e.Graphics.DrawLine(mipen, 170, 115, 630, 114);
                Rectangle rect1 = new Rectangle(170, 90, 420, 45);
                //e.Graphics.DrawRectangle(Pens.Black, rect1);
                e.Graphics.DrawString("CREDENCIAL ANUAL 2019", new Font("Arial Black", 17), Brushes.White, rect1, stringFormat);
                Rectangle rect0 = new Rectangle(190, 130, 420, 45);
                //  e.Graphics.DrawRectangle(Pens.Black, rect0);
                e.Graphics.DrawString("SUPERLIGA 2019-COPAS CONMEBOL 2019", new Font("Arial Black", 11), Brushes.Black, rect0, stringFormat);
                Pen mipens = new Pen(Color.Black, 7);
                e.Graphics.DrawLine(mipens, 170, 170, 630, 170);


                // fila 2

                Char delimiter = '-';
                int num = 190;
                String[] substrings = Convert.ToString(txtCanal.Text).Split(delimiter);
                foreach (var substring in substrings)
                {
                    Rectangle rect2 = new Rectangle(170, num, 430, 30);
                    e.Graphics.DrawRectangle(Pens.White, rect2);
                    e.Graphics.DrawString(substring, new Font("Arial Black", 21), Brushes.Black, rect2, stringFormat);
                    num = num + 30;
                }
                Pen mipen1 = new Pen(Color.Black, 7);
                e.Graphics.DrawLine(mipen1, 170, 260, 630, 260);



                // fila 3

                Rectangle rect22 = new Rectangle(200, 250, 390, 60);
                e.Graphics.DrawRectangle(Pens.White, rect22);
                e.Graphics.DrawString("CAMPO DE JUEGO", new Font("Arial Black", 21), Brushes.Black, rect22, stringFormat);
                //Rectangle rect4 = new Rectangle(200, 290, 390, 60);
                // e.Graphics.DrawRectangle(Pens.White, rect4);
                //  e.Graphics.DrawString("ACCESO A DESIGNAR", new Font("Arial Black", 21), Brushes.Black, rect4, stringFormat);


                if (txtNombre.Text != "")
                {
                    Rectangle rect23 = new Rectangle(170, 340, 390, 60);
                    e.Graphics.DrawRectangle(Pens.White, rect23);
                    e.Graphics.DrawString(txtNombre.Text, new Font("Arial Black", 21), Brushes.Black, rect23, stringFormat);
                    if (txtDni.Text != "")
                    {
                        Rectangle rect6 = new Rectangle(170, 390, 390, 60);
                        e.Graphics.DrawRectangle(Pens.White, rect6);
                        e.Graphics.DrawString(txtDni.Text, new Font("Arial Black", 21), Brushes.Black, rect6, stringFormat);
                    }


                }



                //credencial


                Rectangle rect12 = new Rectangle(370, 420, 390, 40);
                e.Graphics.DrawRectangle(Pens.White, rect12);
                e.Graphics.DrawString("Nº " + Convert.ToString(credencial).PadLeft(3, '0'), new Font("Arial Black", 14), Brushes.Black, rect12, stringFormat);

                conectar = Conexion.ObtenerConexion();

                Evento d = new Evento();
                numero_evento = d.traigo_numero_evento();

                cmd = new MySqlCommand("Insert into impresiones(Torneo, Evento, Medio, Cantidad, Nombre, DNI, Credencial, Asiento, Fila, Cabina, Fecha, Tipo, Id_Evento, Estado, Usuario) values('" + txtCampeonato.Text + "', '" + txtRival.Text + "', '" + txtCanal.Text + "', '" + cantidad_fija + "', '" + txtNombre.Text + "', '" + txtDni.Text + "', '" + credencial + "', " + 0 + ", " + 0 + ", " + 0 + ", '" + lahora + "', " + tipo + ", " + numero_evento + ", 1, '" + FrmLogin.usu + "')", conectar);
                cmd.ExecuteNonQuery();


                // QR
                if (imprimiqr.Checked == true)
                {
                    numero_id = d.traigo_ultimo_Id();
                    cadena = Convert.ToString(numero_id) + "#" + Convert.ToString(txtCanal.Text) + "*" + Convert.ToString(txtCabina.Text).PadLeft(2, '0') + "0000" + "^" + txtValor.Text;
                    QrCode qrCode = new QrCode();
                    qrEncoder.TryEncode(cadena, out qrCode);
                    GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.Black, Brushes.White);
                    MemoryStream ms = new MemoryStream();
                    renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
                    var imageTemporal = new Bitmap(ms);
                    var imagen = new Bitmap(imageTemporal, new Size(new Point(100, 100)));
                    panelResultado.BackgroundImage = imagen;

                    //     e.Graphics.DrawImage(panelResultado.BackgroundImage, 220, 470, 100, 100);
                    e.Graphics.DrawImage(panelResultado.BackgroundImage, 180, 490, 100, 100);

                }

                Rectangle rect29 = new Rectangle(210, 470, 380, 100);
                e.Graphics.DrawRectangle(Pens.White, rect29);
                e.Graphics.DrawString(txtLetras.Text, new Font("Arial", 32), Brushes.Black, rect29, stringFormat);



                // Actualizo el numero de credencial

                credencial++;
                conectar = Conexion.ObtenerConexion();

                if (credencial > FrmLogin.credencial_anual_hasta)
                {
                    cmd = new MySqlCommand("UPDATE setup SET Credencial_Anual_TV =" + FrmLogin.credencial_anual_desde, conectar);
                    cmd.ExecuteNonQuery();
                    credencial = FrmLogin.credencial_anual_desde;
                }
                else
                {
                    cmd = new MySqlCommand("UPDATE setup SET Credencial_Anual_TV =" + credencial, conectar);
                    cmd.ExecuteNonQuery();
                }



                if (cantidad == 0)
                {
                    new Evento().Traigo_Numeros_Credenciales_Anuales(lbCabinaAnual, lbPupitreAnual, lbMovilAnual, lbTVAnual);
                    MessageBox.Show("Finalizo la Impresion");
                    e.HasMorePages = false;
                    return;

                }
                else
                {

                    e.HasMorePages = true;
                    return;

                }







                if (cantidad == 0)
                {
                    new Evento().Traigo_Numeros_Credenciales(lbCabinas, lbPupitre12, lbMovil, lbTV);
                    MessageBox.Show("Finalizo la Impresion");

                    e.HasMorePages = false;
                    return;

                }
                else
                {
                    e.HasMorePages = true;
                    return;

                }

            }






        }

        private void lbPupitreAnual_Click(object sender, EventArgs e)
        {

        }

        private void lbMovilAnual_Click(object sender, EventArgs e)
        {

        }

        private void lbCabinaAnual_Click(object sender, EventArgs e)
        {

        }

        private void lbTVAnual_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            int sigo = 1;

            if (MessageBox.Show(" Esta seguro que quiere imprimir los registros seleccionado ?", "Imprimir registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (CantidadT.Value == 0)
                {
                    sigo = 2;
                    MessageBox.Show("La cantidad de copias debe ser mayor a cero");
                }

                if (cabina.Checked == true)
                {
                    if (string.IsNullOrEmpty(Convert.ToString(txtCabina.Text)))
                    {
                        sigo = 2;
                        MessageBox.Show("Numero de cabina en blanco");
                    }
                }

                if (pupitre.Checked == true)
                {
                    if ((string.IsNullOrEmpty(Convert.ToString(txtAsiento.Text))) | (string.IsNullOrEmpty(Convert.ToString(txtFila.Text))))
                    {
                        sigo = 2;
                        MessageBox.Show("Numero de asiento o fila cabina en blanco");
                    }
                }


                if (sigo == 1)
                {


                    PrinterSettings settings = new PrinterSettings();
                    PaperSize paperSize = new PaperSize("A4", 210, 297);
                    printDocument4.PrinterSettings.DefaultPageSettings.PaperSize = paperSize;
                    printDocument4.Print();

                }


            }
        }

        private void printDocument4_PrintPage(object sender, PrintPageEventArgs e)
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

                if (cabina.Checked == true)
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
                        Evento f = new Evento();
                        buscocredencial = f.buscarcredenciallibre(credencial, 1);
                        if (buscocredencial == 2)
                        {
                            credencial++;
                            if (credencial > 999)
                            {
                                credencial = 1;
                            }
                        }

                    }






                    tipo = 1;
                    if (Convert.ToInt32(CantidadT.Text) > 0)
                    {
                        CantidadT.Text = Convert.ToString(Convert.ToInt32(CantidadT.Text) - 1);
                        cantidad = Convert.ToInt32(CantidadT.Text);
                        cantidad_fija = cantidad + 1;
                    }

                    Rectangle rect3 = new Rectangle(320, 230, 290, 70);
                    e.Graphics.DrawRectangle(Pens.White, rect3);

                    //credencial


                    //      Rectangle rect12 = new Rectangle(440, 410, 170, 40);
                    //     e.Graphics.DrawRectangle(Pens.White, rect12);
                    //    e.Graphics.DrawString(Convert.ToString(credencial).PadLeft(3, '0'), new Font("Arial Black", 14), Brushes.Black, rect12, stringFormat);


                    if (imprimiqr.Checked == true)

                    {

                        // Nombre y DNI
                        if (txtNombre.Text != "")
                        {
                            e.Graphics.DrawString(txtNombre.Text, new Font("Arial Black", 14), Brushes.Black, rect3, stringFormat);
                            if (txtDni.Text != "")
                            {
                                Rectangle rect6 = new Rectangle(320, 260, 290, 60);
                                e.Graphics.DrawRectangle(Pens.White, rect6);
                                e.Graphics.DrawString(txtDni.Text, new Font("Arial Black", 14), Brushes.Black, rect6, stringFormat);
                            }
                            Rectangle rect4 = new Rectangle(320, 290, 290, 40);
                            e.Graphics.DrawRectangle(Pens.White, rect4);
                            e.Graphics.DrawString("CABINA Nº " + txtCabina.Text, new Font("Arial Black", 14), Brushes.Black, rect4, stringFormat);

                        }

                        else
                        {
                            Rectangle rect4 = new Rectangle(320, 230, 290, 70);
                            e.Graphics.DrawRectangle(Pens.White, rect4);
                            e.Graphics.DrawString("CABINA Nº " + txtCabina.Text, new Font("Arial Black", 14), Brushes.Black, rect4, stringFormat);

                        }

                    }
                    else
                    {

                        // Nombre y DNI
                        Rectangle rect999 = new Rectangle(220, 230, 390, 70);
                        e.Graphics.DrawRectangle(Pens.White, rect999);
                        if (txtNombre.Text != "")
                        {
                            e.Graphics.DrawString(txtNombre.Text, new Font("Arial Black", 14), Brushes.Black, rect999, stringFormat);
                            if (txtDni.Text != "")
                            {
                                Rectangle rect6 = new Rectangle(220, 260, 390, 60);
                                e.Graphics.DrawRectangle(Pens.White, rect6);
                                e.Graphics.DrawString(txtDni.Text, new Font("Arial Black", 14), Brushes.Black, rect6, stringFormat);
                            }
                            Rectangle rect4 = new Rectangle(220, 290, 390, 40);
                            e.Graphics.DrawRectangle(Pens.White, rect4);
                            e.Graphics.DrawString("CABINA Nº " + txtCabina.Text, new Font("Arial Black", 14), Brushes.Black, rect4, stringFormat);

                        }

                        else
                        {
                            Rectangle rect4 = new Rectangle(220, 230, 390, 70);
                            e.Graphics.DrawRectangle(Pens.White, rect4);
                            e.Graphics.DrawString("CABINA Nº " + txtCabina.Text, new Font("Arial Black", 14), Brushes.Black, rect4, stringFormat);

                        }








                    }


                    Rectangle rect1 = new Rectangle(220, 90, 390, 45);
                    //     e.Graphics.DrawRectangle(Pens.Black, rect1);

                    e.Graphics.DrawString("FESTEJO DE", new Font("Arial Black", 15), Brushes.Black, rect1, stringFormat);

                    Rectangle rect0 = new Rectangle(220, 140, 390, 45);
                    //   e.Graphics.DrawRectangle(Pens.Black, rect0);
                    e.Graphics.DrawString("EL MAS GR4NDE DE LA HISTORIA", new Font(FrmLogin.nomfuente, FrmLogin.sizefuente), Brushes.Black, rect0, stringFormat);



                    if (imprimiqr.Checked == true)

                    {
                        Char delimiter = '-';
                        int num = 190;
                        String[] substrings = Convert.ToString(txtCanal.Text).Split(delimiter);
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
                        String[] substrings = Convert.ToString(txtCanal.Text).Split(delimiter);
                        foreach (var substring in substrings)
                        {
                            Rectangle rect2 = new Rectangle(220, num, 390, 30);
                            e.Graphics.DrawRectangle(Pens.White, rect2);
                            e.Graphics.DrawString(substring, new Font("Arial Black", 18), Brushes.Black, rect2, stringFormat);
                            num = num + 30;
                        }






                    }


                    //    Rectangle rect5 = new Rectangle(200, 410, 390, 30);
                    //    e.Graphics.DrawRectangle(Pens.White, rect5);



                    //e.Graphics.DrawString(Convert.ToString(row.Cells[2].Value), new Font("Arial Black", 14), Brushes.Black, rect5, stringFormat);
                    //    float x11111 = 200.0F;
                    //   float y11111 = 352.0F;
                    //     float x22222 = 590.0F;
                    //     float y22222 = 352.0F;
                    //     e.Graphics.DrawLine(blackPen, x11111, y11111, x22222, y22222);

                    //      Rectangle rect11 = new Rectangle(200, 220, 390, 230);
                    //      e.Graphics.DrawRectangle(Pens.Black, rect11);




                    Evento d = new Evento();
                    numero_evento = d.traigo_numero_evento();

                    cmd = new MySqlCommand("Insert into impresiones(Torneo, Evento, Medio, Cantidad, Nombre, DNI, Credencial, Asiento, Fila, Cabina, Fecha, Tipo, Id_Evento, Estado, Usuario) values('" + txtCampeonato.Text + "', '" + txtRival.Text + "', '" + txtCanal.Text + "', '" + cantidad_fija + "', '" + txtNombre.Text + "', '" + txtDni.Text + "', '" + credencial + "', " + 0 + ", " + 0 + ", " + txtCabina.Text + ", '" + lahora + "', " + tipo + ", " + numero_evento + ", 1, '" + FrmLogin.usu + "')", conectar);
                    cmd.ExecuteNonQuery();




                    // Actualizo el numero de credencial

                    credencial++;


                    if (credencial >= 999)
                    {
                        cmd = new MySqlCommand("UPDATE setup SET Credencial_Cabinas = 1", conectar);
                        cmd.ExecuteNonQuery();
                        credencial = 1;
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
                        cadena = Convert.ToString(numero_id) + "#" + Convert.ToString(txtCanal.Text) + "*" + Convert.ToString(txtCabina.Text).PadLeft(2, '0') + "0000" + "^" + txtValor.Text;
                        //cadena = txtValor.Text + " " + Convert.ToString(numero_id);

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


                    if (cantidad == 0)
                    {
                        new Evento().Traigo_Numeros_Credenciales(lbCabinas, lbPupitre12, lbMovil, lbTV);
                        MessageBox.Show("Finalizo la Impresion");

                        e.HasMorePages = false;
                        return;

                    }
                    else
                    {
                        e.HasMorePages = true;
                        return;

                    }


                }


                // PUPITRE

                if (pupitre.Checked == true)

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
                        Evento f = new Evento();
                        buscocredencial = f.buscarcredenciallibre(credencial, 2);
                        if (buscocredencial == 2)
                        {
                            credencial++;
                            if (credencial > 999)
                            {
                                credencial = 1;
                            }
                        }

                    }



                    tipo = 2;
                    CantidadT.Text = Convert.ToString(Convert.ToInt32(CantidadT.Text) - 1);
                    cantidad = Convert.ToInt32(CantidadT.Text);
                    cantidad_fija = cantidad + 1;
                    Rectangle rect3 = new Rectangle(320, 230, 290, 70);
                    e.Graphics.DrawRectangle(Pens.White, rect3);

                    //credencial



                    //Rectangle rect12 = new Rectangle(440, 410, 170, 40);
                    // e.Graphics.DrawRectangle(Pens.White, rect12);
                    // e.Graphics.DrawString(Convert.ToString(credencial).PadLeft(3, '0'), new Font("Arial Black", 14), Brushes.Black, rect12, stringFormat);


                    if (imprimiqr.Checked == true)

                    {

                        // Nombre y DNI
                        if (txtNombre.Text != "")
                        {

                            e.Graphics.DrawString(txtNombre.Text, new Font("Arial Black", 14), Brushes.Black, rect3, stringFormat);
                            if (txtDni.Text != "")
                            {
                                Rectangle rect6 = new Rectangle(320, 250, 290, 70);
                                e.Graphics.DrawRectangle(Pens.White, rect6);
                                e.Graphics.DrawString(txtDni.Text, new Font("Arial Black", 14), Brushes.Black, rect6, stringFormat);
                            }
                            Rectangle rect4 = new Rectangle(320, 290, 290, 40);
                            e.Graphics.DrawRectangle(Pens.White, rect4);
                            e.Graphics.DrawString("FILA Nº " + txtFila.Text + " ASIENTO Nº " + txtAsiento.Text, new Font("Arial Black", 14), Brushes.Black, rect4, stringFormat);

                        }

                        else
                        {
                            Rectangle rect4 = new Rectangle(320, 290, 290, 40);
                            e.Graphics.DrawRectangle(Pens.White, rect4);
                            e.Graphics.DrawString("FILA Nº " + txtFila.Text + " ASIENTO Nº " + txtAsiento.Text, new Font("Arial Black", 14), Brushes.Black, rect4, stringFormat);

                        }
                    }
                    else
                    {

                        // Nombre y DNI
                        Rectangle rect999 = new Rectangle(220, 230, 390, 70);
                        e.Graphics.DrawRectangle(Pens.White, rect999);
                        if (txtNombre.Text != "")
                        {

                            e.Graphics.DrawString(txtNombre.Text, new Font("Arial Black", 14), Brushes.Black, rect999, stringFormat);
                            if (txtDni.Text != "")
                            {
                                Rectangle rect6 = new Rectangle(220, 250, 390, 70);
                                e.Graphics.DrawRectangle(Pens.White, rect6);
                                e.Graphics.DrawString(txtDni.Text, new Font("Arial Black", 14), Brushes.Black, rect6, stringFormat);
                            }
                            Rectangle rect4 = new Rectangle(220, 290, 390, 40);
                            e.Graphics.DrawRectangle(Pens.White, rect4);
                            e.Graphics.DrawString("FILA Nº " + txtFila.Text + " ASIENTO Nº " + txtAsiento.Text, new Font("Arial Black", 14), Brushes.Black, rect4, stringFormat);

                        }

                        else
                        {
                            Rectangle rect4 = new Rectangle(220, 290, 390, 40);
                            e.Graphics.DrawRectangle(Pens.White, rect4);
                            e.Graphics.DrawString("FILA Nº " + txtFila.Text + " ASIENTO Nº " + txtAsiento.Text, new Font("Arial Black", 14), Brushes.Black, rect4, stringFormat);

                        }




                    }





                    Rectangle rect1 = new Rectangle(220, 90, 390, 45);
                    //     e.Graphics.DrawRectangle(Pens.Black, rect1);

                    e.Graphics.DrawString("FESTEJO DE", new Font("Arial Black", 15), Brushes.Black, rect1, stringFormat);

                    Rectangle rect0 = new Rectangle(220, 140, 390, 45);
                    //   e.Graphics.DrawRectangle(Pens.Black, rect0);
                    e.Graphics.DrawString("EL MAS GR4NDE DE LA HISTORIA", new Font(FrmLogin.nomfuente, FrmLogin.sizefuente), Brushes.Black, rect0, stringFormat);




                    if (imprimiqr.Checked == true)

                    {
                        Char delimiter = '-';
                        int num = 190;
                        String[] substrings = Convert.ToString(txtCanal.Text).Split(delimiter);
                        foreach (var substring in substrings)
                        {
                            Rectangle rect2 = new Rectangle(220, num, 290, 30);
                            e.Graphics.DrawRectangle(Pens.White, rect2);
                            e.Graphics.DrawString(substring, new Font("Arial Black", 16), Brushes.Black, rect2, stringFormat);
                            num = num + 30;
                        }

                    }
                    else
                    {
                        Char delimiter = '-';
                        int num = 190;
                        String[] substrings = Convert.ToString(txtCanal.Text).Split(delimiter);
                        foreach (var substring in substrings)
                        {
                            Rectangle rect2 = new Rectangle(220, num, 390, 30);
                            e.Graphics.DrawRectangle(Pens.White, rect2);
                            e.Graphics.DrawString(substring, new Font("Arial Black", 18), Brushes.Black, rect2, stringFormat);
                            num = num + 30;
                        }






                    }

                    // Rectangle rect5 = new Rectangle(200, 410, 390, 30);
                    //  e.Graphics.DrawRectangle(Pens.White, rect5);

                    //e.Graphics.DrawString(Convert.ToString(row.Cells[2].Value), new Font("Arial Black", 14), Brushes.Black, rect5, stringFormat);
                    //float x11111 = 200.0F;
                    // float y11111 = 352.0F;
                    // float x22222 = 590.0F;
                    // float y22222 = 352.0F;
                    // e.Graphics.DrawLine(blackPen, x11111, y11111, x22222, y22222);

                    //Rectangle rect11 = new Rectangle(200, 220, 390, 230);
                    // e.Graphics.DrawRectangle(Pens.Black, rect11);


                    conectar = Conexion.ObtenerConexion();
                    Evento d = new Evento();
                    numero_evento = d.traigo_numero_evento();


                    cmd = new MySqlCommand("Insert into impresiones(Torneo, Evento, Medio, Cantidad, Nombre, DNI, Credencial, Asiento, Fila, Cabina, Fecha, Tipo, Id_Evento, Estado, Usuario) values('" + txtCampeonato.Text + "', '" + txtRival.Text + "', '" + txtCanal.Text + "', '" + cantidad_fija + "', '" + txtNombre.Text + "', '" + txtDni.Text + "', '" + credencial + "', " + txtAsiento.Text + ", " + txtFila.Text + ", " + 0 + ", '" + lahora + "', " + tipo + ", " + numero_evento + ", 1, '" + FrmLogin.usu + "')", conectar);
                    cmd.ExecuteNonQuery();




                    // Actualizo el numero de credencial

                    credencial++;
                    conectar = Conexion.ObtenerConexion();

                    if (credencial > 999)
                    {
                        cmd = new MySqlCommand("UPDATE setup SET Credencial_Pupitres = 1", conectar);
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
                        cadena = Convert.ToString(numero_id) + "#" + Convert.ToString(txtCanal.Text) + "*" + "00" + string.Format("{00}", Convert.ToString(txtFila.Text)) + Convert.ToString(txtAsiento.Text).PadLeft(2, '0') + "^" + txtValor.Text;
                        // cadena = txtValor.Text + " " + Convert.ToString(numero_id);

                        QrCode qrCode = new QrCode();
                        qrEncoder.TryEncode(cadena, out qrCode);
                        GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.Black, Brushes.White);
                        MemoryStream ms = new MemoryStream();
                        renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
                        var imageTemporal = new Bitmap(ms);
                        var imagen = new Bitmap(imageTemporal, new Size(new Point(100, 100)));
                        panelResultado.BackgroundImage = imagen;

                        e.Graphics.DrawImage(panelResultado.BackgroundImage, 220, 190, 100, 100);

                    }


                    if (cantidad == 0)
                    {
                        new Evento().Traigo_Numeros_Credenciales(lbCabinas, lbPupitre12, lbMovil, lbTV);
                        MessageBox.Show("Finalizo la Impresion");

                        e.HasMorePages = false;
                        return;

                    }
                    else
                    {
                        e.HasMorePages = true;
                        return;

                    }



                }





                //////  MOVIL ////////

                if (campo.Checked == true)
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
                        Evento f = new Evento();
                        buscocredencial = f.buscarcredenciallibre(credencial, 3);
                        if (buscocredencial == 2)
                        {
                            credencial++;
                            if (credencial > 999)
                            {
                                credencial = 1;
                            }
                        }

                    }


                    tipo = 3;
                    CantidadT.Text = Convert.ToString(Convert.ToInt32(CantidadT.Text) - 1);
                    cantidad = Convert.ToInt32(CantidadT.Text);
                    cantidad_fija = cantidad + 1;
                    Rectangle rect3 = new Rectangle(320, 210, 290, 70);
                    e.Graphics.DrawRectangle(Pens.White, rect3);

                    //credencial

                    //Rectangle rect12 = new Rectangle(440, 410, 170, 40);
                    // e.Graphics.DrawRectangle(Pens.White, rect12);
                    //  e.Graphics.DrawString(Convert.ToString(credencial).PadLeft(3, '0'), new Font("Arial Black", 14), Brushes.Black, rect12, stringFormat);



                    if (imprimiqr.Checked == true)

                    {
                        // Nombre y DNI
                        if (txtNombre.Text != "")
                        {

                            e.Graphics.DrawString(txtNombre.Text, new Font("Arial Black", 14), Brushes.Black, rect3, stringFormat);
                            if (txtDni.Text != "")
                            {
                                Rectangle rect6 = new Rectangle(320, 230, 290, 70);
                                e.Graphics.DrawRectangle(Pens.White, rect6);
                                e.Graphics.DrawString(txtDni.Text, new Font("Arial Black", 14), Brushes.Black, rect6, stringFormat);
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
                        if (txtNombre.Text != "")
                        {

                            e.Graphics.DrawString(txtNombre.Text, new Font("Arial Black", 14), Brushes.Black, rect999, stringFormat);
                            if (txtDni.Text != "")
                            {
                                Rectangle rect6 = new Rectangle(220, 230, 390, 70);
                                e.Graphics.DrawRectangle(Pens.White, rect6);
                                e.Graphics.DrawString(txtDni.Text, new Font("Arial Black", 14), Brushes.Black, rect6, stringFormat);
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
                    //     e.Graphics.DrawRectangle(Pens.Black, rect1);

                    e.Graphics.DrawString("FESTEJO DE", new Font("Arial Black", 15), Brushes.Black, rect1, stringFormat);

                    Rectangle rect0 = new Rectangle(220, 140, 390, 45);
                    //   e.Graphics.DrawRectangle(Pens.Black, rect0);
                    e.Graphics.DrawString("EL MAS GR4NDE DE LA HISTORIA", new Font(FrmLogin.nomfuente, FrmLogin.sizefuente), Brushes.Black, rect0, stringFormat);



                    if (imprimiqr.Checked == true)

                    {
                        Char delimiter = '-';
                        int num = 180;
                        String[] substrings = Convert.ToString(txtCanal.Text).Split(delimiter);
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
                        String[] substrings = Convert.ToString(txtCanal.Text).Split(delimiter);
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

                    //e.Graphics.DrawString(Convert.ToString(row.Cells[2].Value), new Font("Arial Black", 14), Brushes.Black, rect5, stringFormat);
                    //float x11111 = 200.0F;
                    // float y11111 = 352.0F;
                    //  float x22222 = 590.0F;
                    //  float y22222 = 352.0F;
                    //  e.Graphics.DrawLine(blackPen, x11111, y11111, x22222, y22222);

                    //Rectangle rect11 = new Rectangle(200, 220, 390, 230);
                    // e.Graphics.DrawRectangle(Pens.Black, rect11);



                    conectar = Conexion.ObtenerConexion();

                    Evento d = new Evento();
                    numero_evento = d.traigo_numero_evento();

                    cmd = new MySqlCommand("Insert into impresiones(Torneo, Evento, Medio, Cantidad, Nombre, DNI, Credencial, Asiento, Fila, Cabina, Fecha, Tipo, Id_Evento, Estado, Usuario) values('" + txtCampeonato.Text + "', '" + txtRival.Text + "', '" + txtCanal.Text + "', '" + cantidad_fija + "', '" + txtNombre.Text + "', '" + txtDni.Text + "', '" + credencial + "', " + 0 + ", " + 0 + ", " + 0 + ", '" + lahora + "', " + tipo + ", " + numero_evento + ", 1, '" + FrmLogin.usu + "')", conectar);
                    cmd.ExecuteNonQuery();


                    // Actualizo el numero de credencial

                    credencial++;
                    conectar = Conexion.ObtenerConexion();

                    if (credencial > 999)
                    {
                        cmd = new MySqlCommand("UPDATE setup SET Credencial_Moviles = 1", conectar);
                        cmd.ExecuteNonQuery();
                        credencial = 1;
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
                        cadena = Convert.ToString(numero_id) + "#" + Convert.ToString(txtCanal.Text) + "*" + "000000" + "^" + txtValor.Text;
                        //cadena = txtValor.Text + " " + Convert.ToString(numero_id);

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


                    if (cantidad == 0)
                    {
                        new Evento().Traigo_Numeros_Credenciales(lbCabinas, lbPupitre12, lbMovil, lbTV);
                        MessageBox.Show("Finalizo la Impresion");

                        e.HasMorePages = false;
                        return;

                    }
                    else
                    {
                        e.HasMorePages = true;
                        return;

                    }



                }


                //////  TV ////////

                if (tv.Checked == true)
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
                        Evento f = new Evento();
                        buscocredencial = f.buscarcredenciallibre(credencial, 4);
                        if (buscocredencial == 2)
                        {
                            credencial++;
                            if (credencial > 999)
                            {
                                credencial = 1;
                            }
                        }

                    }




                    tipo = 4;
                    CantidadT.Text = Convert.ToString(Convert.ToInt32(CantidadT.Text) - 1);
                    cantidad = Convert.ToInt32(CantidadT.Text);
                    cantidad_fija = cantidad + 1;
                    Rectangle rect3 = new Rectangle(320, 230, 290, 70);
                    e.Graphics.DrawRectangle(Pens.White, rect3);

                    //credencial

                    //Rectangle rect12 = new Rectangle(440, 410, 170, 40);
                    // e.Graphics.DrawRectangle(Pens.White, rect12);
                    //  e.Graphics.DrawString(Convert.ToString(credencial).PadLeft(3, '0'), new Font("Arial Black", 14), Brushes.Black, rect12, stringFormat);


                    if (imprimiqr.Checked == true)

                    {

                        // Nombre y DNI
                        if (txtNombre.Text != "")
                        {

                            e.Graphics.DrawString(txtNombre.Text, new Font("Arial Black", 14), Brushes.Black, rect3, stringFormat);
                            if (txtDni.Text != "")
                            {
                                Rectangle rect6 = new Rectangle(320, 250, 290, 70);
                                e.Graphics.DrawRectangle(Pens.White, rect6);
                                e.Graphics.DrawString(txtDni.Text, new Font("Arial Black", 14), Brushes.Black, rect6, stringFormat);
                            }
                            Rectangle rect4 = new Rectangle(320, 290, 270, 40);
                            e.Graphics.DrawRectangle(Pens.White, rect4);
                            e.Graphics.DrawString("CAMPO DE JUEGO", new Font("Arial Black", 17), Brushes.Black, rect4, stringFormat);



                        }

                        else
                        {
                            Rectangle rect4 = new Rectangle(320, 290, 290, 40);
                            e.Graphics.DrawRectangle(Pens.White, rect4);
                            e.Graphics.DrawString("CAMPO DE JUEGO", new Font("Arial Black", 17), Brushes.Black, rect4, stringFormat);

                        }


                    }
                    else
                    {

                        // Nombre y DNI
                        Rectangle rect999 = new Rectangle(220, 230, 390, 70);
                        e.Graphics.DrawRectangle(Pens.White, rect999);
                        if (txtNombre.Text != "")
                        {

                            e.Graphics.DrawString(txtNombre.Text, new Font("Arial Black", 14), Brushes.Black, rect999, stringFormat);
                            if (txtDni.Text != "")
                            {
                                Rectangle rect6 = new Rectangle(220, 250, 390, 70);
                                e.Graphics.DrawRectangle(Pens.White, rect6);
                                e.Graphics.DrawString(txtDni.Text, new Font("Arial Black", 14), Brushes.Black, rect6, stringFormat);
                            }
                            Rectangle rect4 = new Rectangle(220, 290, 370, 40);
                            e.Graphics.DrawRectangle(Pens.White, rect4);
                            e.Graphics.DrawString("CAMPO DE JUEGO", new Font("Arial Black", 17), Brushes.Black, rect4, stringFormat);



                        }

                        else
                        {
                            Rectangle rect4 = new Rectangle(220, 290, 390, 40);
                            e.Graphics.DrawRectangle(Pens.White, rect4);
                            e.Graphics.DrawString("CAMPO DE JUEGO", new Font("Arial Black", 17), Brushes.Black, rect4, stringFormat);

                        }








                    }
                    Rectangle rect1 = new Rectangle(220, 90, 390, 45);
                    //     e.Graphics.DrawRectangle(Pens.Black, rect1);

                    e.Graphics.DrawString("FESTEJO DE", new Font("Arial Black", 15), Brushes.Black, rect1, stringFormat);

                    Rectangle rect0 = new Rectangle(220, 140, 390, 45);
                    //   e.Graphics.DrawRectangle(Pens.Black, rect0);
                    e.Graphics.DrawString("EL MAS GR4NDE DE LA HISTORIA", new Font(FrmLogin.nomfuente, FrmLogin.sizefuente), Brushes.Black, rect0, stringFormat);

                    if (imprimiqr.Checked == true)

                    {
                        Char delimiter = '-';
                        int num = 180;
                        String[] substrings = Convert.ToString(txtCanal.Text).Split(delimiter);
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
                        String[] substrings = Convert.ToString(txtCanal.Text).Split(delimiter);
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

                    //e.Graphics.DrawString(Convert.ToString(row.Cells[2].Value), new Font("Arial Black", 14), Brushes.Black, rect5, stringFormat);
                    //float x11111 = 200.0F;
                    // float y11111 = 352.0F;
                    // float x22222 = 590.0F;
                    // float y22222 = 352.0F;
                    // e.Graphics.DrawLine(blackPen, x11111, y11111, x22222, y22222);

                    // Rectangle rect11 = new Rectangle(200, 220, 390, 230);
                    // e.Graphics.DrawRectangle(Pens.Black, rect11);

                    Evento d = new Evento();
                    if (imprimiqr.Checked == true)

                    {
                        // CODIGO QR

                        numero_id = d.traigo_ultimo_Id();
                        cadena = Convert.ToString(numero_id) + "#" + Convert.ToString(txtCanal.Text) + "*" + "000000" + "^" + txtValor.Text;
                        //cadena = txtValor.Text + " " + Convert.ToString(numero_id);

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

                    conectar = Conexion.ObtenerConexion();


                    numero_evento = d.traigo_numero_evento();

                    cmd = new MySqlCommand("Insert into impresiones(Torneo, Evento, Medio, Cantidad, Nombre, DNI, Credencial, Asiento, Fila, Cabina, Fecha, Tipo, Id_Evento, Estado, Usuario) values('" + txtCampeonato.Text + "', '" + txtRival.Text + "', '" + txtCanal.Text + "', '" + cantidad_fija + "', '" + txtNombre.Text + "', '" + txtDni.Text + "', '" + credencial + "', " + 0 + ", " + 0 + ", " + 0 + ", '" + lahora + "', " + tipo + ", " + numero_evento + ", 1, '" + FrmLogin.usu + "')", conectar);
                    cmd.ExecuteNonQuery();



                    // Actualizo el numero de credencial

                    credencial++;
                    conectar = Conexion.ObtenerConexion();

                    if (credencial > 999)
                    {
                        cmd = new MySqlCommand("UPDATE setup SET Credencial_TV = 1", conectar);
                        cmd.ExecuteNonQuery();
                        credencial = 1;
                    }
                    else
                    {
                        cmd = new MySqlCommand("UPDATE setup SET Credencial_TV =" + credencial, conectar);
                        cmd.ExecuteNonQuery();
                    }



                    if (cantidad == 0)
                    {
                        new Evento().Traigo_Numeros_Credenciales(lbCabinas, lbPupitre12, lbMovil, lbTV);
                        MessageBox.Show("Finalizo la Impresion");
                        e.HasMorePages = false;
                        return;

                    }
                    else
                    {

                        e.HasMorePages = true;
                        return;

                    }



                }
                               
                                                                      
            
        }

        private void button8_Click(object sender, EventArgs e)
        {

            string criterio;
            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
            criterio = "Select Id_Medios, Nombre_Medio, Letras From medios";
            Evento d = new Evento();
            d.traigo_datos_medios(dgvMedios, criterio);
            medios.Visible = true;
            System.Windows.Forms.Cursor.Current = Cursors.Default;

        }

        private void button9_Click(object sender, EventArgs e)
        {
            medios.Visible = false;

        }

        private void dgvMedios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCanal.Text = Convert.ToString(this.dgvMedios.CurrentRow.Cells[1].Value);
            txtLetras.Text = Convert.ToString(this.dgvMedios.CurrentRow.Cells[2].Value);
            medios.Visible = false;

        }

        private void button10_Click(object sender, EventArgs e)
        {
            int sigo = 1;

            if (MessageBox.Show(" Esta seguro que quiere Re-imprimir el ultimo registro ?", "Imprimir registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (CantidadT.Value == 0)
                {
                    sigo = 2;
                    MessageBox.Show("La cantidad de copias debe ser mayor a cero");
                }

                if (cabina.Checked == true)
                {
                    if (string.IsNullOrEmpty(Convert.ToString(txtCabina.Text)))
                    {
                        sigo = 2;
                        MessageBox.Show("Numero de cabina en blanco");
                    }
                }

                if (pupitre.Checked == true)
                {
                    if ((string.IsNullOrEmpty(Convert.ToString(txtAsiento.Text))) | (string.IsNullOrEmpty(Convert.ToString(txtFila.Text))))
                    {
                        sigo = 2;
                        MessageBox.Show("Numero de asiento o fila cabina en blanco");
                    }
                }


                if (sigo == 1)
                {


                    PrinterSettings settings = new PrinterSettings();
                    PaperSize paperSize = new PaperSize("A4", 210, 297);
                    printDocument5.PrinterSettings.DefaultPageSettings.PaperSize = paperSize;
                    printDocument5.Print();

                }


            }
        }

        private void printDocument5_PrintPage(object sender, PrintPageEventArgs e)
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

            if (cabina.Checked == true)
            {
               
                tipo = 1;
                if (Convert.ToInt32(CantidadT.Text) > 0)
                {
                    CantidadT.Text = Convert.ToString(Convert.ToInt32(CantidadT.Text) - 1);
                    cantidad = Convert.ToInt32(CantidadT.Text);
                    cantidad_fija = cantidad + 1;
                }

                Rectangle rect3 = new Rectangle(300, 230, 290, 70);
                e.Graphics.DrawRectangle(Pens.White, rect3);



                // fila 1
                Pen mipen = new Pen(Color.Black, 35);
                e.Graphics.DrawLine(mipen, 170, 115, 630, 114);
                Rectangle rect1 = new Rectangle(190, 90, 420, 45);
                //e.Graphics.DrawRectangle(Pens.Black, rect1);
                e.Graphics.DrawString("CREDENCIAL ANUAL 2019", new Font("Arial Black", 17), Brushes.White, rect1, stringFormat);
                Rectangle rect0 = new Rectangle(190, 130, 420, 45);
                //  e.Graphics.DrawRectangle(Pens.Black, rect0);
                e.Graphics.DrawString("SUPERLIGA 2019-COPAS CONMEBOL 2019", new Font("Arial Black", 11), Brushes.Black, rect0, stringFormat);
                Pen mipens = new Pen(Color.Black, 7);
                e.Graphics.DrawLine(mipens, 170, 170, 630, 170);



                // fila 2

                Char delimiter = '-';
                int num = 190;
                String[] substrings = Convert.ToString(txtCanal.Text).Split(delimiter);
                foreach (var substring in substrings)
                {
                    Rectangle rect2 = new Rectangle(170, num, 430, 30);
                    e.Graphics.DrawRectangle(Pens.White, rect2);
                    e.Graphics.DrawString(substring, new Font("Arial Black", 21), Brushes.Black, rect2, stringFormat);
                    num = num + 30;
                }
                Pen mipen1 = new Pen(Color.Black, 7);
                e.Graphics.DrawLine(mipen1, 170, 260, 630, 260);



                // fila 3

                Rectangle rect22 = new Rectangle(200, 250, 390, 60);
                e.Graphics.DrawRectangle(Pens.White, rect22);
                e.Graphics.DrawString("CABINA DE PRENSA", new Font("Arial Black", 21), Brushes.Black, rect22, stringFormat);
                Rectangle rect4 = new Rectangle(190, 290, 390, 60);
                e.Graphics.DrawRectangle(Pens.White, rect4);
                e.Graphics.DrawString("CABINA Nº " + txtCabina.Text, new Font("Arial Black", 21), Brushes.Black, rect4, stringFormat);


                if (txtNombre.Text != "")
                {
                    Rectangle rect23 = new Rectangle(170, 340, 390, 60);
                    e.Graphics.DrawRectangle(Pens.White, rect23);
                    e.Graphics.DrawString(txtNombre.Text, new Font("Arial Black", 21), Brushes.Black, rect23, stringFormat);
                    if (txtDni.Text != "")
                    {
                        Rectangle rect6 = new Rectangle(170, 390, 390, 60);
                        e.Graphics.DrawRectangle(Pens.White, rect6);
                        e.Graphics.DrawString(txtDni.Text, new Font("Arial Black", 21), Brushes.Black, rect6, stringFormat);
                    }


                }


                //credencial


                Rectangle rect12 = new Rectangle(370, 420, 390, 40);
                e.Graphics.DrawRectangle(Pens.White, rect12);
                credencial = Convert.ToInt32(lbCabinaAnual.Text) - 1;
                e.Graphics.DrawString("Nº " + Convert.ToString(credencial).PadLeft(3, '0'), new Font("Arial Black", 14), Brushes.Black, rect12, stringFormat);

                Evento d = new Evento();
                numero_evento = d.traigo_numero_evento();

                cmd = new MySqlCommand("Insert into impresiones(Torneo, Evento, Medio, Cantidad, Nombre, DNI, Credencial, Asiento, Fila, Cabina, Fecha, Tipo, Id_Evento, Estado, Usuario) values('" + txtCampeonato.Text + "', '" + txtRival.Text + "', '" + txtCanal.Text + "', '" + cantidad_fija + "', '" + txtNombre.Text + "', '" + txtDni.Text + "', '" + credencial + "', " + 0 + ", " + 0 + ", " + txtCabina.Text + ", '" + lahora + "', " + tipo + ", " + numero_evento + ", 1, '" + FrmLogin.usu + "')", conectar);
                cmd.ExecuteNonQuery();


                              

                // QR


                if (imprimiqr.Checked == true)
                {
                    numero_id = d.traigo_ultimo_Id();
                    cadena = Convert.ToString(numero_id) + "#" + Convert.ToString(txtCanal.Text) + "*" + Convert.ToString(txtCabina.Text).PadLeft(2, '0') + "0000" + "^" + txtValor.Text;
                    QrCode qrCode = new QrCode();
                    qrEncoder.TryEncode(cadena, out qrCode);
                    GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.Black, Brushes.White);
                    MemoryStream ms = new MemoryStream();
                    renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
                    var imageTemporal = new Bitmap(ms);
                    var imagen = new Bitmap(imageTemporal, new Size(new Point(100, 100)));
                    panelResultado.BackgroundImage = imagen;

                    //     e.Graphics.DrawImage(panelResultado.BackgroundImage, 220, 470, 100, 100);
                    e.Graphics.DrawImage(panelResultado.BackgroundImage, 180, 490, 100, 100);

                }

                Rectangle rect29 = new Rectangle(210, 470, 380, 100);
                e.Graphics.DrawRectangle(Pens.White, rect29);
                e.Graphics.DrawString(txtLetras.Text, new Font("Arial", 32), Brushes.Black, rect29, stringFormat);


                if (cantidad == 0)
                {
                    new Evento().Traigo_Numeros_Credenciales_Anuales(lbCabinaAnual, lbPupitreAnual, lbMovilAnual, lbTVAnual);
                    MessageBox.Show("Finalizo la Impresion");

                    e.HasMorePages = false;
                    return;

                }
                else
                {
                    e.HasMorePages = true;
                    return;

                }

            }



            ////// PUPITRE ////////

            if (pupitre.Checked == true)
            {
              


                tipo = 2;
                if (Convert.ToInt32(CantidadT.Text) > 0)
                {
                    CantidadT.Text = Convert.ToString(Convert.ToInt32(CantidadT.Text) - 1);
                    cantidad = Convert.ToInt32(CantidadT.Text);
                    cantidad_fija = cantidad + 1;
                }

                Rectangle rect3 = new Rectangle(300, 230, 290, 70);
                e.Graphics.DrawRectangle(Pens.White, rect3);



                // fila 1
                Pen mipen = new Pen(Color.Black, 35);
                e.Graphics.DrawLine(mipen, 170, 115, 630, 114);
                Rectangle rect1 = new Rectangle(190, 90, 420, 45);
                //e.Graphics.DrawRectangle(Pens.Black, rect1);
                e.Graphics.DrawString("CREDENCIAL ANUAL 2019", new Font("Arial Black", 17), Brushes.White, rect1, stringFormat);
                Rectangle rect0 = new Rectangle(190, 130, 420, 45);
                //  e.Graphics.DrawRectangle(Pens.Black, rect0);
                e.Graphics.DrawString("SUPERLIGA 2019-COPAS CONMEBOL 2019", new Font("Arial Black", 11), Brushes.Black, rect0, stringFormat);
                Pen mipens = new Pen(Color.Black, 7);
                e.Graphics.DrawLine(mipens, 170, 170, 630, 170);


                // fila 2

                Char delimiter = '-';
                int num = 190;
                String[] substrings = Convert.ToString(txtCanal.Text).Split(delimiter);
                foreach (var substring in substrings)
                {
                    Rectangle rect2 = new Rectangle(170, num, 430, 30);
                    e.Graphics.DrawRectangle(Pens.White, rect2);
                    e.Graphics.DrawString(substring, new Font("Arial Black", 21), Brushes.Black, rect2, stringFormat);
                    num = num + 30;
                }
                Pen mipen1 = new Pen(Color.Black, 7);
                e.Graphics.DrawLine(mipen1, 170, 260, 630, 260);



                // fila 3

                Rectangle rect22 = new Rectangle(200, 250, 390, 60);
                e.Graphics.DrawRectangle(Pens.White, rect22);
                e.Graphics.DrawString("PUPITRE DE PRENSA", new Font("Arial Black", 21), Brushes.Black, rect22, stringFormat);
                Rectangle rect4 = new Rectangle(190, 290, 390, 60);
                e.Graphics.DrawRectangle(Pens.White, rect4);
                e.Graphics.DrawString("FILA Nº " + Convert.ToString(txtFila.Text) + " ASIENTO Nº " + Convert.ToString(txtAsiento.Text), new Font("Arial Black", 18), Brushes.Black, rect4, stringFormat);

                if (txtNombre.Text != "")
                {
                    Rectangle rect23 = new Rectangle(170, 340, 390, 60);
                    e.Graphics.DrawRectangle(Pens.White, rect23);
                    e.Graphics.DrawString(Convert.ToString(txtNombre.Text), new Font("Arial Black", 21), Brushes.Black, rect23, stringFormat);
                    if (txtDni.Text != "")
                    {
                        Rectangle rect6 = new Rectangle(170, 390, 390, 60);
                        e.Graphics.DrawRectangle(Pens.White, rect6);
                        e.Graphics.DrawString(Convert.ToString(txtDni.Text), new Font("Arial Black", 21), Brushes.Black, rect6, stringFormat);
                    }


                }

                //credencial


                Rectangle rect12 = new Rectangle(370, 420, 390, 40);
                e.Graphics.DrawRectangle(Pens.White, rect12);
                credencial = Convert.ToInt32(lbCabinaAnual.Text) - 1;
                e.Graphics.DrawString("Nº " + Convert.ToString(credencial).PadLeft(3, '0'), new Font("Arial Black", 14), Brushes.Black, rect12, stringFormat);

                conectar = Conexion.ObtenerConexion();
                Evento d = new Evento();
                numero_evento = d.traigo_numero_evento();


                cmd = new MySqlCommand("Insert into impresiones(Torneo, Evento, Medio, Cantidad, Nombre, DNI, Credencial, Asiento, Fila, Cabina, Fecha, Tipo, Id_Evento, Estado, Usuario) values('" + txtCampeonato.Text + "', '" + txtRival.Text + "', '" + txtCanal.Text + "', '" + cantidad_fija + "', '" + txtNombre.Text + "', '" + txtDni.Text + "', '" + credencial + "', " + txtAsiento.Text + ", " + txtFila.Text + ", " + 0 + ", '" + lahora + "', " + tipo + ", " + numero_evento + ", 1, '" + FrmLogin.usu + "')", conectar);
                cmd.ExecuteNonQuery();
                

                
                // QR


                if (imprimiqr.Checked == true)
                {
                    numero_id = d.traigo_ultimo_Id();
                    cadena = Convert.ToString(numero_id) + "#" + Convert.ToString(txtCanal.Text) + "*" + Convert.ToString(txtCabina.Text).PadLeft(2, '0') + "0000" + "^" + txtValor.Text;
                    QrCode qrCode = new QrCode();
                    qrEncoder.TryEncode(cadena, out qrCode);
                    GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.Black, Brushes.White);
                    MemoryStream ms = new MemoryStream();
                    renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
                    var imageTemporal = new Bitmap(ms);
                    var imagen = new Bitmap(imageTemporal, new Size(new Point(100, 100)));
                    panelResultado.BackgroundImage = imagen;

                    //     e.Graphics.DrawImage(panelResultado.BackgroundImage, 220, 470, 100, 100);
                    e.Graphics.DrawImage(panelResultado.BackgroundImage, 180, 490, 100, 100);

                }



                Rectangle rect29 = new Rectangle(210, 470, 380, 100);
                e.Graphics.DrawRectangle(Pens.White, rect29);
                e.Graphics.DrawString(txtLetras.Text, new Font("Arial", 32), Brushes.Black, rect29, stringFormat);


                if (cantidad == 0)
                {
                    new Evento().Traigo_Numeros_Credenciales_Anuales(lbCabinaAnual, lbPupitreAnual, lbMovilAnual, lbTVAnual);
                    MessageBox.Show("Finalizo la Impresion");

                    e.HasMorePages = false;
                    return;

                }
                else
                {
                    e.HasMorePages = true;
                    return;

                }

            }


            ////// MOVIL ////////

            if (campo.Checked == true)
            {
                                tipo = 3;
                if (Convert.ToInt32(CantidadT.Text) > 0)
                {
                    CantidadT.Text = Convert.ToString(Convert.ToInt32(CantidadT.Text) - 1);
                    cantidad = Convert.ToInt32(CantidadT.Text);
                    cantidad_fija = cantidad + 1;
                }

                Rectangle rect3 = new Rectangle(300, 230, 290, 70);
                e.Graphics.DrawRectangle(Pens.White, rect3);



                // fila 1
                Pen mipen = new Pen(Color.Black, 35);
                e.Graphics.DrawLine(mipen, 170, 115, 630, 114);
                Rectangle rect1 = new Rectangle(190, 90, 420, 45);
                //e.Graphics.DrawRectangle(Pens.Black, rect1);
                e.Graphics.DrawString("CREDENCIAL ANUAL 2019", new Font("Arial Black", 17), Brushes.White, rect1, stringFormat);
                Rectangle rect0 = new Rectangle(190, 130, 420, 45);
                //  e.Graphics.DrawRectangle(Pens.Black, rect0);
                e.Graphics.DrawString("SUPERLIGA 2019-COPAS CONMEBOL 2019", new Font("Arial Black", 11), Brushes.Black, rect0, stringFormat);
                Pen mipens = new Pen(Color.Black, 7);
                e.Graphics.DrawLine(mipens, 170, 170, 630, 170);


                // fila 2

                Char delimiter = '-';
                int num = 190;
                String[] substrings = Convert.ToString(txtCanal.Text).Split(delimiter);
                foreach (var substring in substrings)
                {
                    Rectangle rect2 = new Rectangle(170, num, 430, 30);
                    e.Graphics.DrawRectangle(Pens.White, rect2);
                    e.Graphics.DrawString(substring, new Font("Arial Black", 21), Brushes.Black, rect2, stringFormat);
                    num = num + 30;
                }
                Pen mipen1 = new Pen(Color.Black, 7);
                e.Graphics.DrawLine(mipen1, 170, 260, 630, 260);




                // fila 3

                //  Rectangle rect22 = new Rectangle(200, 265, 390, 60);
                //  e.Graphics.DrawRectangle(Pens.White, rect22);
                //  e.Graphics.DrawString("MOVIL", new Font("Arial Black", 21), Brushes.Black, rect22, stringFormat);
                //  Rectangle rect4 = new Rectangle(200, 290, 390, 60);
                //  e.Graphics.DrawRectangle(Pens.White, rect4);
                //  e.Graphics.DrawString("ACCESO A DESIGNAR", new Font("Arial Black", 21), Brushes.Black, rect4, stringFormat);


                if (txtNombre.Text != "")
                {
                    Rectangle rect23 = new Rectangle(180, 340, 390, 60);
                    e.Graphics.DrawRectangle(Pens.White, rect23);
                    e.Graphics.DrawString(txtNombre.Text, new Font("Arial Black", 21), Brushes.Black, rect23, stringFormat);
                    if (txtDni.Text != "")
                    {
                        Rectangle rect6 = new Rectangle(170, 390, 390, 60);
                        e.Graphics.DrawRectangle(Pens.White, rect6);
                        e.Graphics.DrawString(txtDni.Text, new Font("Arial Black", 21), Brushes.Black, rect6, stringFormat);
                    }


                }

                //credencial


                Rectangle rect12 = new Rectangle(370, 420, 390, 40);
                e.Graphics.DrawRectangle(Pens.White, rect12);
                credencial = Convert.ToInt32(lbCabinaAnual.Text) - 1;
                e.Graphics.DrawString("Nº " + Convert.ToString(credencial).PadLeft(3, '0'), new Font("Arial Black", 14), Brushes.Black, rect12, stringFormat);

                conectar = Conexion.ObtenerConexion();

                Evento d = new Evento();
                numero_evento = d.traigo_numero_evento();

                cmd = new MySqlCommand("Insert into impresiones(Torneo, Evento, Medio, Cantidad, Nombre, DNI, Credencial, Asiento, Fila, Cabina, Fecha, Tipo, Id_Evento, Estado, Usuario) values('" + txtCampeonato.Text + "', '" + txtRival.Text + "', '" + txtCanal.Text + "', '" + cantidad_fija + "', '" + txtNombre.Text + "', '" + txtDni.Text + "', '" + credencial + "', " + 0 + ", " + 0 + ", " + 0 + ", '" + lahora + "', " + tipo + ", " + numero_evento + ", 1, '" + FrmLogin.usu + "')", conectar);
                cmd.ExecuteNonQuery();



                // QR
                if (imprimiqr.Checked == true)
                {
                    numero_id = d.traigo_ultimo_Id();
                    cadena = Convert.ToString(numero_id) + "#" + Convert.ToString(txtCanal.Text) + "*" + Convert.ToString(txtCabina.Text).PadLeft(2, '0') + "0000" + "^" + txtValor.Text;
                    QrCode qrCode = new QrCode();
                    qrEncoder.TryEncode(cadena, out qrCode);
                    GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.Black, Brushes.White);
                    MemoryStream ms = new MemoryStream();
                    renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
                    var imageTemporal = new Bitmap(ms);
                    var imagen = new Bitmap(imageTemporal, new Size(new Point(100, 100)));
                    panelResultado.BackgroundImage = imagen;

                    //     e.Graphics.DrawImage(panelResultado.BackgroundImage, 220, 470, 100, 100);
                    e.Graphics.DrawImage(panelResultado.BackgroundImage, 180, 490, 100, 100);

                }


                Rectangle rect29 = new Rectangle(210, 470, 380, 100);
                e.Graphics.DrawRectangle(Pens.White, rect29);
                e.Graphics.DrawString(txtLetras.Text, new Font("Arial", 32), Brushes.Black, rect29, stringFormat);

                


                if (cantidad == 0)
                {
                    new Evento().Traigo_Numeros_Credenciales_Anuales(lbCabinaAnual, lbPupitreAnual, lbMovilAnual, lbTVAnual);
                    MessageBox.Show("Finalizo la Impresion");

                    e.HasMorePages = false;
                    return;

                }
                else
                {
                    e.HasMorePages = true;
                    return;

                }

            }





            ////// TV ////////

            if (tv.Checked == true)
            {
            

                tipo = 4;
                if (Convert.ToInt32(CantidadT.Text) > 0)
                {
                    CantidadT.Text = Convert.ToString(Convert.ToInt32(CantidadT.Text) - 1);
                    cantidad = Convert.ToInt32(CantidadT.Text);
                    cantidad_fija = cantidad + 1;
                }

                Rectangle rect3 = new Rectangle(300, 230, 290, 70);
                e.Graphics.DrawRectangle(Pens.White, rect3);



                // fila 1
                Pen mipen = new Pen(Color.Black, 35);
                e.Graphics.DrawLine(mipen, 170, 115, 630, 114);
                Rectangle rect1 = new Rectangle(170, 90, 420, 45);
                //e.Graphics.DrawRectangle(Pens.Black, rect1);
                e.Graphics.DrawString("CREDENCIAL ANUAL 2019", new Font("Arial Black", 17), Brushes.White, rect1, stringFormat);
                Rectangle rect0 = new Rectangle(190, 130, 420, 45);
                //  e.Graphics.DrawRectangle(Pens.Black, rect0);
                e.Graphics.DrawString("SUPERLIGA 2019-COPAS CONMEBOL 2019", new Font("Arial Black", 11), Brushes.Black, rect0, stringFormat);
                Pen mipens = new Pen(Color.Black, 7);
                e.Graphics.DrawLine(mipens, 170, 170, 630, 170);


                // fila 2

                Char delimiter = '-';
                int num = 190;
                String[] substrings = Convert.ToString(txtCanal.Text).Split(delimiter);
                foreach (var substring in substrings)
                {
                    Rectangle rect2 = new Rectangle(170, num, 430, 30);
                    e.Graphics.DrawRectangle(Pens.White, rect2);
                    e.Graphics.DrawString(substring, new Font("Arial Black", 21), Brushes.Black, rect2, stringFormat);
                    num = num + 30;
                }
                Pen mipen1 = new Pen(Color.Black, 7);
                e.Graphics.DrawLine(mipen1, 170, 260, 630, 260);



                // fila 3

                Rectangle rect22 = new Rectangle(200, 250, 390, 60);
                e.Graphics.DrawRectangle(Pens.White, rect22);
                e.Graphics.DrawString("CAMPO DE JUEGO", new Font("Arial Black", 21), Brushes.Black, rect22, stringFormat);
                //Rectangle rect4 = new Rectangle(200, 290, 390, 60);
                // e.Graphics.DrawRectangle(Pens.White, rect4);
                //  e.Graphics.DrawString("ACCESO A DESIGNAR", new Font("Arial Black", 21), Brushes.Black, rect4, stringFormat);


                if (txtNombre.Text != "")
                {
                    Rectangle rect23 = new Rectangle(170, 340, 390, 60);
                    e.Graphics.DrawRectangle(Pens.White, rect23);
                    e.Graphics.DrawString(txtNombre.Text, new Font("Arial Black", 21), Brushes.Black, rect23, stringFormat);
                    if (txtDni.Text != "")
                    {
                        Rectangle rect6 = new Rectangle(170, 390, 390, 60);
                        e.Graphics.DrawRectangle(Pens.White, rect6);
                        e.Graphics.DrawString(txtDni.Text, new Font("Arial Black", 21), Brushes.Black, rect6, stringFormat);
                    }


                }



                //credencial


                Rectangle rect12 = new Rectangle(370, 420, 390, 40);
                e.Graphics.DrawRectangle(Pens.White, rect12);
                credencial = Convert.ToInt32(lbCabinaAnual.Text) - 1;
                e.Graphics.DrawString("Nº " + Convert.ToString(credencial).PadLeft(3, '0'), new Font("Arial Black", 14), Brushes.Black, rect12, stringFormat);

                conectar = Conexion.ObtenerConexion();

                Evento d = new Evento();
                numero_evento = d.traigo_numero_evento();

                cmd = new MySqlCommand("Insert into impresiones(Torneo, Evento, Medio, Cantidad, Nombre, DNI, Credencial, Asiento, Fila, Cabina, Fecha, Tipo, Id_Evento, Estado, Usuario) values('" + txtCampeonato.Text + "', '" + txtRival.Text + "', '" + txtCanal.Text + "', '" + cantidad_fija + "', '" + txtNombre.Text + "', '" + txtDni.Text + "', '" + credencial + "', " + 0 + ", " + 0 + ", " + 0 + ", '" + lahora + "', " + tipo + ", " + numero_evento + ", 1, '" + FrmLogin.usu + "')", conectar);
                cmd.ExecuteNonQuery();


                // QR
                if (imprimiqr.Checked == true)
                {
                    numero_id = d.traigo_ultimo_Id();
                    cadena = Convert.ToString(numero_id) + "#" + Convert.ToString(txtCanal.Text) + "*" + Convert.ToString(txtCabina.Text).PadLeft(2, '0') + "0000" + "^" + txtValor.Text;
                    QrCode qrCode = new QrCode();
                    qrEncoder.TryEncode(cadena, out qrCode);
                    GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.Black, Brushes.White);
                    MemoryStream ms = new MemoryStream();
                    renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
                    var imageTemporal = new Bitmap(ms);
                    var imagen = new Bitmap(imageTemporal, new Size(new Point(100, 100)));
                    panelResultado.BackgroundImage = imagen;

                    //     e.Graphics.DrawImage(panelResultado.BackgroundImage, 220, 470, 100, 100);
                    e.Graphics.DrawImage(panelResultado.BackgroundImage, 180, 490, 100, 100);

                }

                Rectangle rect29 = new Rectangle(210, 470, 380, 100);
                e.Graphics.DrawRectangle(Pens.White, rect29);
                e.Graphics.DrawString(txtLetras.Text, new Font("Arial", 32), Brushes.Black, rect29, stringFormat);

                
                
                if (cantidad == 0)
                {
                    new Evento().Traigo_Numeros_Credenciales_Anuales(lbCabinaAnual, lbPupitreAnual, lbMovilAnual, lbTVAnual);
                    MessageBox.Show("Finalizo la Impresion");
                    e.HasMorePages = false;
                    return;

                }
                else
                {

                    e.HasMorePages = true;
                    return;

                }







                if (cantidad == 0)
                {
                    new Evento().Traigo_Numeros_Credenciales(lbCabinas, lbPupitre12, lbMovil, lbTV);
                    MessageBox.Show("Finalizo la Impresion");

                    e.HasMorePages = false;
                    return;

                }
                else
                {
                    e.HasMorePages = true;
                    return;

                }

            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            int sigo = 1;

            if (MessageBox.Show(" Esta seguro que quiere imprimir los registros seleccionado ?", "Imprimir registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (CantidadT.Value == 0)
                {
                    sigo = 2;
                    MessageBox.Show("La cantidad de copias debe ser mayor a cero");
                }

                if (cabina.Checked == true)
                {
                    if (string.IsNullOrEmpty(Convert.ToString(txtCabina.Text)))
                    {
                        sigo = 2;
                        MessageBox.Show("Numero de cabina en blanco");
                    }
                }

                if (pupitre.Checked == true)
                {
                    if ((string.IsNullOrEmpty(Convert.ToString(txtAsiento.Text))) | (string.IsNullOrEmpty(Convert.ToString(txtFila.Text))))
                    {
                        sigo = 2;
                        MessageBox.Show("Numero de asiento o fila cabina en blanco");
                    }
                }


                if (sigo == 1)
                {


                    PrinterSettings settings = new PrinterSettings();
                    PaperSize paperSize = new PaperSize("A4", 210, 297);
                    printDocument6.PrinterSettings.DefaultPageSettings.PaperSize = paperSize;
                    printDocument6.Print();

                }


            }
        }

        private void printDocument6_PrintPage(object sender, PrintPageEventArgs e)
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

            conectar = Conexion.ObtenerConexion();

            new Importar().Traigo_Configuracion_Evento(txtideventos);



            ////// CABINA ////////

            if (cabina.Checked == true)
            {

                tipo = 1;
                if (Convert.ToInt32(CantidadT.Text) > 0)
                {
                    CantidadT.Text = Convert.ToString(Convert.ToInt32(CantidadT.Text) - 1);
                    cantidad = Convert.ToInt32(CantidadT.Text);
                    cantidad_fija = cantidad + 1;
                }

                Rectangle rect3 = new Rectangle(300, 230, 290, 70);
                e.Graphics.DrawRectangle(Pens.White, rect3);



                // fila 1
                Pen mipen = new Pen(Color.Black, 35);
                e.Graphics.DrawLine(mipen, 170, 115, 630, 114);
                Rectangle rect1 = new Rectangle(190, 90, 420, 45);
                //e.Graphics.DrawRectangle(Pens.Black, rect1);
                e.Graphics.DrawString("CREDENCIAL ANUAL 2019", new Font("Arial Black", 17), Brushes.White, rect1, stringFormat);
                Rectangle rect0 = new Rectangle(190, 130, 420, 45);
                //  e.Graphics.DrawRectangle(Pens.Black, rect0);
                e.Graphics.DrawString("SUPERLIGA 2019-COPAS CONMEBOL 2019", new Font("Arial Black", 11), Brushes.Black, rect0, stringFormat);
                Pen mipens = new Pen(Color.Black, 7);
                e.Graphics.DrawLine(mipens, 170, 170, 630, 170);



                // fila 2

                Char delimiter = '-';
                int num = 190;
                String[] substrings = Convert.ToString(txtCanal.Text).Split(delimiter);
                foreach (var substring in substrings)
                {
                    Rectangle rect2 = new Rectangle(170, num, 430, 30);
                    e.Graphics.DrawRectangle(Pens.White, rect2);
                    e.Graphics.DrawString(substring, new Font("Arial Black", 21), Brushes.Black, rect2, stringFormat);
                    num = num + 30;
                }
                Pen mipen1 = new Pen(Color.Black, 7);
                e.Graphics.DrawLine(mipen1, 170, 260, 630, 260);



                // fila 3

                Rectangle rect22 = new Rectangle(200, 250, 390, 60);
                e.Graphics.DrawRectangle(Pens.White, rect22);
                e.Graphics.DrawString("CABINA DE PRENSA", new Font("Arial Black", 21), Brushes.Black, rect22, stringFormat);
                Rectangle rect4 = new Rectangle(190, 290, 390, 60);
                e.Graphics.DrawRectangle(Pens.White, rect4);
                e.Graphics.DrawString("CABINA Nº " + txtCabina.Text, new Font("Arial Black", 21), Brushes.Black, rect4, stringFormat);


                if (txtNombre.Text != "")
                {
                    Rectangle rect23 = new Rectangle(170, 340, 390, 60);
                    e.Graphics.DrawRectangle(Pens.White, rect23);
                    e.Graphics.DrawString(txtNombre.Text, new Font("Arial Black", 21), Brushes.Black, rect23, stringFormat);
                    if (txtDni.Text != "")
                    {
                        Rectangle rect6 = new Rectangle(170, 390, 390, 60);
                        e.Graphics.DrawRectangle(Pens.White, rect6);
                        e.Graphics.DrawString(txtDni.Text, new Font("Arial Black", 21), Brushes.Black, rect6, stringFormat);
                    }


                }


                //credencial


                Rectangle rect12 = new Rectangle(370, 420, 390, 40);
                e.Graphics.DrawRectangle(Pens.White, rect12);
                e.Graphics.DrawString("Nº " + Convert.ToString(nrocred.Text).PadLeft(3, '0'), new Font("Arial Black", 14), Brushes.Black, rect12, stringFormat);

                Evento d = new Evento();
                numero_evento = d.traigo_numero_evento();

                cmd = new MySqlCommand("Insert into impresiones(Torneo, Evento, Medio, Cantidad, Nombre, DNI, Credencial, Asiento, Fila, Cabina, Fecha, Tipo, Id_Evento, Estado, Usuario) values('" + txtCampeonato.Text + "', '" + txtRival.Text + "', '" + txtCanal.Text + "', '" + cantidad_fija + "', '" + txtNombre.Text + "', '" + txtDni.Text + "', '" + nrocred.Text + "', " + 0 + ", " + 0 + ", " + txtCabina.Text + ", '" + lahora + "', " + tipo + ", " + numero_evento + ", 1, '" + FrmLogin.usu + "')", conectar);
                cmd.ExecuteNonQuery();




                // QR


                if (imprimiqr.Checked == true)
                {
                    numero_id = d.traigo_ultimo_Id();
                    cadena = Convert.ToString(numero_id) + "#" + Convert.ToString(txtCanal.Text) + "*" + Convert.ToString(txtCabina.Text).PadLeft(2, '0') + "0000" + "^" + txtValor.Text;
                    QrCode qrCode = new QrCode();
                    qrEncoder.TryEncode(cadena, out qrCode);
                    GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.Black, Brushes.White);
                    MemoryStream ms = new MemoryStream();
                    renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
                    var imageTemporal = new Bitmap(ms);
                    var imagen = new Bitmap(imageTemporal, new Size(new Point(100, 100)));
                    panelResultado.BackgroundImage = imagen;

                    //     e.Graphics.DrawImage(panelResultado.BackgroundImage, 220, 470, 100, 100);
                    e.Graphics.DrawImage(panelResultado.BackgroundImage, 180, 490, 100, 100);

                }

                Rectangle rect29 = new Rectangle(210, 470, 380, 100);
                e.Graphics.DrawRectangle(Pens.White, rect29);
                e.Graphics.DrawString(txtLetras.Text, new Font("Arial", 32), Brushes.Black, rect29, stringFormat);


                if (cantidad == 0)
                {
                 
                    MessageBox.Show("Finalizo la Impresion");

                    e.HasMorePages = false;
                    return;

                }
                else
                {
                    e.HasMorePages = true;
                    return;

                }

            }



            ////// PUPITRE ////////

            if (pupitre.Checked == true)
            {



                tipo = 2;
                if (Convert.ToInt32(CantidadT.Text) > 0)
                {
                    CantidadT.Text = Convert.ToString(Convert.ToInt32(CantidadT.Text) - 1);
                    cantidad = Convert.ToInt32(CantidadT.Text);
                    cantidad_fija = cantidad + 1;
                }

                Rectangle rect3 = new Rectangle(300, 230, 290, 70);
                e.Graphics.DrawRectangle(Pens.White, rect3);



                // fila 1
                Pen mipen = new Pen(Color.Black, 35);
                e.Graphics.DrawLine(mipen, 170, 115, 630, 114);
                Rectangle rect1 = new Rectangle(190, 90, 420, 45);
                //e.Graphics.DrawRectangle(Pens.Black, rect1);
                e.Graphics.DrawString("CREDENCIAL ANUAL 2019", new Font("Arial Black", 17), Brushes.White, rect1, stringFormat);
                Rectangle rect0 = new Rectangle(190, 130, 420, 45);
                //  e.Graphics.DrawRectangle(Pens.Black, rect0);
                e.Graphics.DrawString("SUPERLIGA 2019-COPAS CONMEBOL 2019", new Font("Arial Black", 11), Brushes.Black, rect0, stringFormat);
                Pen mipens = new Pen(Color.Black, 7);
                e.Graphics.DrawLine(mipens, 170, 170, 630, 170);


                // fila 2

                Char delimiter = '-';
                int num = 190;
                String[] substrings = Convert.ToString(txtCanal.Text).Split(delimiter);
                foreach (var substring in substrings)
                {
                    Rectangle rect2 = new Rectangle(170, num, 430, 30);
                    e.Graphics.DrawRectangle(Pens.White, rect2);
                    e.Graphics.DrawString(substring, new Font("Arial Black", 21), Brushes.Black, rect2, stringFormat);
                    num = num + 30;
                }
                Pen mipen1 = new Pen(Color.Black, 7);
                e.Graphics.DrawLine(mipen1, 170, 260, 630, 260);



                // fila 3

                Rectangle rect22 = new Rectangle(200, 250, 390, 60);
                e.Graphics.DrawRectangle(Pens.White, rect22);
                e.Graphics.DrawString("PUPITRE DE PRENSA", new Font("Arial Black", 21), Brushes.Black, rect22, stringFormat);
                Rectangle rect4 = new Rectangle(190, 290, 390, 60);
                e.Graphics.DrawRectangle(Pens.White, rect4);
                e.Graphics.DrawString("FILA Nº " + Convert.ToString(txtFila.Text) + " ASIENTO Nº " + Convert.ToString(txtAsiento.Text), new Font("Arial Black", 18), Brushes.Black, rect4, stringFormat);

                if (txtNombre.Text != "")
                {
                    Rectangle rect23 = new Rectangle(170, 340, 390, 60);
                    e.Graphics.DrawRectangle(Pens.White, rect23);
                    e.Graphics.DrawString(Convert.ToString(txtNombre.Text), new Font("Arial Black", 21), Brushes.Black, rect23, stringFormat);
                    if (txtDni.Text != "")
                    {
                        Rectangle rect6 = new Rectangle(170, 390, 390, 60);
                        e.Graphics.DrawRectangle(Pens.White, rect6);
                        e.Graphics.DrawString(Convert.ToString(txtDni.Text), new Font("Arial Black", 21), Brushes.Black, rect6, stringFormat);
                    }


                }

                //credencial


                Rectangle rect12 = new Rectangle(370, 420, 390, 40);
                e.Graphics.DrawRectangle(Pens.White, rect12);
                e.Graphics.DrawString("Nº " + Convert.ToString(nrocred.Text).PadLeft(3, '0'), new Font("Arial Black", 14), Brushes.Black, rect12, stringFormat);

                conectar = Conexion.ObtenerConexion();
                Evento d = new Evento();
                numero_evento = d.traigo_numero_evento();


                cmd = new MySqlCommand("Insert into impresiones(Torneo, Evento, Medio, Cantidad, Nombre, DNI, Credencial, Asiento, Fila, Cabina, Fecha, Tipo, Id_Evento, Estado, Usuario) values('" + txtCampeonato.Text + "', '" + txtRival.Text + "', '" + txtCanal.Text + "', '" + cantidad_fija + "', '" + txtNombre.Text + "', '" + txtDni.Text + "', '" + nrocred.Text + "', " + txtAsiento.Text + ", " + txtFila.Text + ", " + 0 + ", '" + lahora + "', " + tipo + ", " + numero_evento + ", 1, '" + FrmLogin.usu + "')", conectar);
                cmd.ExecuteNonQuery();



                // QR


                if (imprimiqr.Checked == true)
                {
                    numero_id = d.traigo_ultimo_Id();
                    cadena = Convert.ToString(numero_id) + "#" + Convert.ToString(txtCanal.Text) + "*" + Convert.ToString(txtCabina.Text).PadLeft(2, '0') + "0000" + "^" + txtValor.Text;
                    QrCode qrCode = new QrCode();
                    qrEncoder.TryEncode(cadena, out qrCode);
                    GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.Black, Brushes.White);
                    MemoryStream ms = new MemoryStream();
                    renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
                    var imageTemporal = new Bitmap(ms);
                    var imagen = new Bitmap(imageTemporal, new Size(new Point(100, 100)));
                    panelResultado.BackgroundImage = imagen;

                    //     e.Graphics.DrawImage(panelResultado.BackgroundImage, 220, 470, 100, 100);
                    e.Graphics.DrawImage(panelResultado.BackgroundImage, 180, 490, 100, 100);

                }



                Rectangle rect29 = new Rectangle(210, 470, 380, 100);
                e.Graphics.DrawRectangle(Pens.White, rect29);
                e.Graphics.DrawString(txtLetras.Text, new Font("Arial", 32), Brushes.Black, rect29, stringFormat);


                if (cantidad == 0)
                {
                    new Evento().Traigo_Numeros_Credenciales_Anuales(lbCabinaAnual, lbPupitreAnual, lbMovilAnual, lbTVAnual);
                    MessageBox.Show("Finalizo la Impresion");

                    e.HasMorePages = false;
                    return;

                }
                else
                {
                    e.HasMorePages = true;
                    return;

                }

            }


            ////// MOVIL ////////

            if (campo.Checked == true)
            {
                tipo = 3;
                if (Convert.ToInt32(CantidadT.Text) > 0)
                {
                    CantidadT.Text = Convert.ToString(Convert.ToInt32(CantidadT.Text) - 1);
                    cantidad = Convert.ToInt32(CantidadT.Text);
                    cantidad_fija = cantidad + 1;
                }

                Rectangle rect3 = new Rectangle(300, 230, 290, 70);
                e.Graphics.DrawRectangle(Pens.White, rect3);



                // fila 1
                Pen mipen = new Pen(Color.Black, 35);
                e.Graphics.DrawLine(mipen, 170, 115, 630, 114);
                Rectangle rect1 = new Rectangle(190, 90, 420, 45);
                //e.Graphics.DrawRectangle(Pens.Black, rect1);
                e.Graphics.DrawString("CREDENCIAL ANUAL 2019", new Font("Arial Black", 17), Brushes.White, rect1, stringFormat);
                Rectangle rect0 = new Rectangle(190, 130, 420, 45);
                //  e.Graphics.DrawRectangle(Pens.Black, rect0);
                e.Graphics.DrawString("SUPERLIGA 2019-COPAS CONMEBOL 2019", new Font("Arial Black", 11), Brushes.Black, rect0, stringFormat);
                Pen mipens = new Pen(Color.Black, 7);
                e.Graphics.DrawLine(mipens, 170, 170, 630, 170);


                // fila 2

                Char delimiter = '-';
                int num = 190;
                String[] substrings = Convert.ToString(txtCanal.Text).Split(delimiter);
                foreach (var substring in substrings)
                {
                    Rectangle rect2 = new Rectangle(170, num, 430, 30);
                    e.Graphics.DrawRectangle(Pens.White, rect2);
                    e.Graphics.DrawString(substring, new Font("Arial Black", 21), Brushes.Black, rect2, stringFormat);
                    num = num + 30;
                }
                Pen mipen1 = new Pen(Color.Black, 7);
                e.Graphics.DrawLine(mipen1, 170, 260, 630, 260);




                // fila 3

                //  Rectangle rect22 = new Rectangle(200, 265, 390, 60);
                //  e.Graphics.DrawRectangle(Pens.White, rect22);
                //  e.Graphics.DrawString("MOVIL", new Font("Arial Black", 21), Brushes.Black, rect22, stringFormat);
                //  Rectangle rect4 = new Rectangle(200, 290, 390, 60);
                //  e.Graphics.DrawRectangle(Pens.White, rect4);
                //  e.Graphics.DrawString("ACCESO A DESIGNAR", new Font("Arial Black", 21), Brushes.Black, rect4, stringFormat);


                if (txtNombre.Text != "")
                {
                    Rectangle rect23 = new Rectangle(180, 340, 390, 60);
                    e.Graphics.DrawRectangle(Pens.White, rect23);
                    e.Graphics.DrawString(txtNombre.Text, new Font("Arial Black", 21), Brushes.Black, rect23, stringFormat);
                    if (txtDni.Text != "")
                    {
                        Rectangle rect6 = new Rectangle(170, 390, 390, 60);
                        e.Graphics.DrawRectangle(Pens.White, rect6);
                        e.Graphics.DrawString(txtDni.Text, new Font("Arial Black", 21), Brushes.Black, rect6, stringFormat);
                    }


                }

                //credencial


                Rectangle rect12 = new Rectangle(370, 420, 390, 40);
                e.Graphics.DrawRectangle(Pens.White, rect12);
                e.Graphics.DrawString("Nº " + Convert.ToString(nrocred.Text).PadLeft(3, '0'), new Font("Arial Black", 14), Brushes.Black, rect12, stringFormat);

                conectar = Conexion.ObtenerConexion();

                Evento d = new Evento();
                numero_evento = d.traigo_numero_evento();

                cmd = new MySqlCommand("Insert into impresiones(Torneo, Evento, Medio, Cantidad, Nombre, DNI, Credencial, Asiento, Fila, Cabina, Fecha, Tipo, Id_Evento, Estado, Usuario) values('" + txtCampeonato.Text + "', '" + txtRival.Text + "', '" + txtCanal.Text + "', '" + cantidad_fija + "', '" + txtNombre.Text + "', '" + txtDni.Text + "', '" + nrocred.Text + "', " + 0 + ", " + 0 + ", " + 0 + ", '" + lahora + "', " + tipo + ", " + numero_evento + ", 1, '" + FrmLogin.usu + "')", conectar);
                cmd.ExecuteNonQuery();



                // QR
                if (imprimiqr.Checked == true)
                {
                    numero_id = d.traigo_ultimo_Id();
                    cadena = Convert.ToString(numero_id) + "#" + Convert.ToString(txtCanal.Text) + "*" + Convert.ToString(txtCabina.Text).PadLeft(2, '0') + "0000" + "^" + txtValor.Text;
                    QrCode qrCode = new QrCode();
                    qrEncoder.TryEncode(cadena, out qrCode);
                    GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.Black, Brushes.White);
                    MemoryStream ms = new MemoryStream();
                    renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
                    var imageTemporal = new Bitmap(ms);
                    var imagen = new Bitmap(imageTemporal, new Size(new Point(100, 100)));
                    panelResultado.BackgroundImage = imagen;

                    //     e.Graphics.DrawImage(panelResultado.BackgroundImage, 220, 470, 100, 100);
                    e.Graphics.DrawImage(panelResultado.BackgroundImage, 180, 490, 100, 100);

                }


                Rectangle rect29 = new Rectangle(210, 470, 380, 100);
                e.Graphics.DrawRectangle(Pens.White, rect29);
                e.Graphics.DrawString(txtLetras.Text, new Font("Arial", 32), Brushes.Black, rect29, stringFormat);




                if (cantidad == 0)
                {
                    new Evento().Traigo_Numeros_Credenciales_Anuales(lbCabinaAnual, lbPupitreAnual, lbMovilAnual, lbTVAnual);
                    MessageBox.Show("Finalizo la Impresion");

                    e.HasMorePages = false;
                    return;

                }
                else
                {
                    e.HasMorePages = true;
                    return;

                }

            }





            ////// TV ////////

            if (tv.Checked == true)
            {


                tipo = 4;
                if (Convert.ToInt32(CantidadT.Text) > 0)
                {
                    CantidadT.Text = Convert.ToString(Convert.ToInt32(CantidadT.Text) - 1);
                    cantidad = Convert.ToInt32(CantidadT.Text);
                    cantidad_fija = cantidad + 1;
                }

                Rectangle rect3 = new Rectangle(300, 230, 290, 70);
                e.Graphics.DrawRectangle(Pens.White, rect3);



                // fila 1
                Pen mipen = new Pen(Color.Black, 35);
                e.Graphics.DrawLine(mipen, 170, 115, 630, 114);
                Rectangle rect1 = new Rectangle(170, 90, 420, 45);
                //e.Graphics.DrawRectangle(Pens.Black, rect1);
                e.Graphics.DrawString("CREDENCIAL ANUAL 2019", new Font("Arial Black", 17), Brushes.White, rect1, stringFormat);
                Rectangle rect0 = new Rectangle(190, 130, 420, 45);
                //  e.Graphics.DrawRectangle(Pens.Black, rect0);
                e.Graphics.DrawString("SUPERLIGA 2019-COPAS CONMEBOL 2019", new Font("Arial Black", 11), Brushes.Black, rect0, stringFormat);
                Pen mipens = new Pen(Color.Black, 7);
                e.Graphics.DrawLine(mipens, 170, 170, 630, 170);


                // fila 2

                Char delimiter = '-';
                int num = 190;
                String[] substrings = Convert.ToString(txtCanal.Text).Split(delimiter);
                foreach (var substring in substrings)
                {
                    Rectangle rect2 = new Rectangle(170, num, 430, 30);
                    e.Graphics.DrawRectangle(Pens.White, rect2);
                    e.Graphics.DrawString(substring, new Font("Arial Black", 21), Brushes.Black, rect2, stringFormat);
                    num = num + 30;
                }
                Pen mipen1 = new Pen(Color.Black, 7);
                e.Graphics.DrawLine(mipen1, 170, 260, 630, 260);



                // fila 3

                Rectangle rect22 = new Rectangle(200, 250, 390, 60);
                e.Graphics.DrawRectangle(Pens.White, rect22);
                e.Graphics.DrawString("CAMPO DE JUEGO", new Font("Arial Black", 21), Brushes.Black, rect22, stringFormat);
                //Rectangle rect4 = new Rectangle(200, 290, 390, 60);
                // e.Graphics.DrawRectangle(Pens.White, rect4);
                //  e.Graphics.DrawString("ACCESO A DESIGNAR", new Font("Arial Black", 21), Brushes.Black, rect4, stringFormat);


                if (txtNombre.Text != "")
                {
                    Rectangle rect23 = new Rectangle(170, 340, 390, 60);
                    e.Graphics.DrawRectangle(Pens.White, rect23);
                    e.Graphics.DrawString(txtNombre.Text, new Font("Arial Black", 21), Brushes.Black, rect23, stringFormat);
                    if (txtDni.Text != "")
                    {
                        Rectangle rect6 = new Rectangle(170, 390, 390, 60);
                        e.Graphics.DrawRectangle(Pens.White, rect6);
                        e.Graphics.DrawString(txtDni.Text, new Font("Arial Black", 21), Brushes.Black, rect6, stringFormat);
                    }


                }



                //credencial


                Rectangle rect12 = new Rectangle(370, 420, 390, 40);
                e.Graphics.DrawRectangle(Pens.White, rect12);
                e.Graphics.DrawString("Nº " + Convert.ToString(nrocred.Text).PadLeft(3, '0'), new Font("Arial Black", 14), Brushes.Black, rect12, stringFormat);

                conectar = Conexion.ObtenerConexion();

                Evento d = new Evento();
                numero_evento = d.traigo_numero_evento();

                cmd = new MySqlCommand("Insert into impresiones(Torneo, Evento, Medio, Cantidad, Nombre, DNI, Credencial, Asiento, Fila, Cabina, Fecha, Tipo, Id_Evento, Estado, Usuario) values('" + txtCampeonato.Text + "', '" + txtRival.Text + "', '" + txtCanal.Text + "', '" + cantidad_fija + "', '" + txtNombre.Text + "', '" + txtDni.Text + "', '" + nrocred.Text + "', " + 0 + ", " + 0 + ", " + 0 + ", '" + lahora + "', " + tipo + ", " + numero_evento + ", 1, '" + FrmLogin.usu + "')", conectar);
                cmd.ExecuteNonQuery();


                // QR
                if (imprimiqr.Checked == true)
                {
                    numero_id = d.traigo_ultimo_Id();
                    cadena = Convert.ToString(numero_id) + "#" + Convert.ToString(txtCanal.Text) + "*" + Convert.ToString(txtCabina.Text).PadLeft(2, '0') + "0000" + "^" + txtValor.Text;
                    QrCode qrCode = new QrCode();
                    qrEncoder.TryEncode(cadena, out qrCode);
                    GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.Black, Brushes.White);
                    MemoryStream ms = new MemoryStream();
                    renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
                    var imageTemporal = new Bitmap(ms);
                    var imagen = new Bitmap(imageTemporal, new Size(new Point(100, 100)));
                    panelResultado.BackgroundImage = imagen;

                    //     e.Graphics.DrawImage(panelResultado.BackgroundImage, 220, 470, 100, 100);
                    e.Graphics.DrawImage(panelResultado.BackgroundImage, 180, 490, 100, 100);

                }

                Rectangle rect29 = new Rectangle(210, 470, 380, 100);
                e.Graphics.DrawRectangle(Pens.White, rect29);
                e.Graphics.DrawString(txtLetras.Text, new Font("Arial", 32), Brushes.Black, rect29, stringFormat);



                if (cantidad == 0)
                {
                    new Evento().Traigo_Numeros_Credenciales_Anuales(lbCabinaAnual, lbPupitreAnual, lbMovilAnual, lbTVAnual);
                    MessageBox.Show("Finalizo la Impresion");
                    e.HasMorePages = false;
                    return;

                }
                else
                {

                    e.HasMorePages = true;
                    return;

                }







                if (cantidad == 0)
                {
                    new Evento().Traigo_Numeros_Credenciales(lbCabinas, lbPupitre12, lbMovil, lbTV);
                    MessageBox.Show("Finalizo la Impresion");

                    e.HasMorePages = false;
                    return;

                }
                else
                {
                    e.HasMorePages = true;
                    return;

                }

            }
        }
    }
}
    



