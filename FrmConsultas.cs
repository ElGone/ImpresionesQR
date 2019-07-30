using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Printing;
using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using System.Drawing.Imaging;
using System.IO;
using MySql.Data.MySqlClient;


namespace ImpresionQR
{
    public partial class FrmConsultas : Form
    {
        DateTime fecha = DateTime.Now;
        //       MySqlCommand cmd;
        //       MySqlConnection conectar;
        
        int cargo = 1;
        string txtideventos;

        public FrmConsultas()
        {
            
            InitializeComponent();
            

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmConsultas_Load(object sender, EventArgs e)
        {
         // pdesde.CustomFormat = "yyyy-MM-dd";
            pdesde.Value = DateTime.Now;
            

            string criterio = "";
            Evento d = new Evento();
            criterio = "Select Id_Tipo, Descripcion_Tipo from tipos Order By Id_Tipo";
            d.llenarcombotipo(cbtipos, criterio);
           
             
          
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Close();


        }

        private void cbtemporadas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


            string criterio = "", fdesde="";
            fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);
            Evento d = new Evento();
            imprimiqr.Checked = true;


            if (txtevento.Text  != "")
            {
                string evento = Id_evento.Text ;
                string tipo = cbtipos.SelectedValue.ToString();

                if (cbtipos.Text == "Cabinas")

                {
                    FrmPrincipal.cabina = 1;
                    FrmPrincipal.pupitre34 = 2;
                    FrmPrincipal.pupitre567 = 2;
                    FrmPrincipal.pupitre = 2;
                    FrmPrincipal.movil = 2;
                    FrmPrincipal.TV = 2;
                    dgvCabinas.Rows.Clear();
                    dgvCabinas.Visible = true;
                    txtidrival.Visible = false;
                    dgvMovil.Visible = false;
                    criterio = "Select a.Id_Impresiones, a.Torneo, a.Evento, a.Medio, a.Cantidad, a.Nombre, a.DNI, a.Credencial, a.Cabina, a.Id_Evento, a.Fecha, a.Tipo, b.Descripcion, a.Letras FROM impresiones AS a INNER JOIN estados As b ON a.estado=b.estado WHERE Tipo=1 AND Id_Evento=" + evento + " Order By Id_Impresiones";
                    new Evento().Traigo_Consulta_Eventos(dgvCabinas, criterio, 1);
                }
                if (cbtipos.Text == "Pupitres")
                {

                    FrmPrincipal.cabina = 2;
                    FrmPrincipal.pupitre34 = 1;
                    FrmPrincipal.pupitre567 = 1;
                    FrmPrincipal.pupitre = 1;
                    FrmPrincipal.movil = 2;
                    FrmPrincipal.TV = 2;
                    txtidrival.Rows.Clear();
                    dgvCabinas.Visible = false;
                    txtidrival.Visible = true;
                    dgvMovil.Visible = false;
                    criterio = "Select a.Id_Impresiones, a.Torneo, a.Evento, a.Medio, a.Cantidad, a.Nombre, a.DNI,a.Credencial, a.Fila, a.Asiento, a.Id_Evento, a.Fecha, a.Tipo , b.Descripcion, a.Letras FROM impresiones AS a INNER JOIN estados As b ON a.estado=b.estado WHERE Tipo=2 AND Id_Evento=" + evento + " Order By Id_Impresiones";
                    new Evento().Traigo_Consulta_Eventos(txtidrival, criterio, 2);
                }
                if (cbtipos.Text == "Moviles")
                {
                    FrmPrincipal.cabina = 2;
                    FrmPrincipal.pupitre34 = 2;
                    FrmPrincipal.pupitre567 = 2;
                    FrmPrincipal.pupitre = 2;
                    FrmPrincipal.movil = 1;
                    FrmPrincipal.TV = 2;
                    dgvMovil.Rows.Clear();
                    dgvCabinas.Visible = false;
                    txtidrival.Visible = false;
                    dgvMovil.Visible = true;
                    criterio = "Select a.Id_Impresiones, a.Torneo, a.Evento, a.Medio, a.Cantidad, a.Nombre, a.DNI,a.Credencial, a.Id_Evento, a.Fecha, a.Tipo , b.Descripcion, a.Letras FROM impresiones AS a INNER JOIN estados As b ON a.estado=b.estado WHERE Tipo=3 AND Id_Evento=" + evento + " Order By Id_Impresiones";
                    new Evento().Traigo_Consulta_Eventos(dgvMovil, criterio, 3);
                }
                if (cbtipos.Text == "TV")
                {
                    FrmPrincipal.cabina = 2;
                    FrmPrincipal.pupitre34 = 2;
                    FrmPrincipal.pupitre567 = 2;
                    FrmPrincipal.pupitre = 2;
                    FrmPrincipal.movil = 2;
                    FrmPrincipal.TV = 1;
                    dgvMovil.Rows.Clear();
                    dgvCabinas.Visible = false;
                    txtidrival.Visible = false;
                    dgvMovil.Visible = true;
                    criterio = "Select a.Id_Impresiones, a.Torneo, a.Evento, a.Medio, a.Cantidad, a.Nombre, a.DNI,a.Credencial, a.Id_Evento, a.Fecha, a.Tipo , b.Descripcion, a.Letras FROM impresiones AS a INNER JOIN estados As b ON a.estado=b.estado WHERE Tipo=4 AND Id_Evento=" + evento + " Order By Id_Impresiones";
                    new Evento().Traigo_Consulta_Eventos(dgvMovil, criterio, 4);
                }
                button7.Enabled = true;
                button6.Enabled = true;
                button5.Enabled = true;
                button2.Enabled = true;

            }
            else
            {
                txtidrival.Rows.Clear();
                dgvCabinas.Rows.Clear();
                dgvMovil.Rows.Clear();
                MessageBox.Show("No se encontraron datos para esta fecha");

            }
           
        }

        private void pdesde_ValueChanged(object sender, EventArgs e)
        {
           // string criterio = "", fdesde="";
            

        //    fdesde = Convert.ToString(pdesde.Text).Substring(0,10);
       //     Evento d = new Evento();
      //      criterio = "Select Id_Evento, Nombre_Evento, Campeonato, Numero_Fecha, url , Id_Rival from eventos where Fecha='" + fdesde + "' Order By Id_Evento";
       //     d.llenarcomboeventos(cbeventos, criterio);
       //     d.Busco_Dato_Evento(txttorneo, fecnumero, URL, criterio, txtidevento, idrival );



        }

        private void button7_Click(object sender, EventArgs e)
        {

          
            if (MessageBox.Show(" Esta seguro que quiere imprimir los registros seleccionado ?", "Imprimir registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
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
                    FrmLogin.CantRegImp = d.CantRegImp(txtidrival);
                }

                if (FrmPrincipal.pupitre34 == 1)
                {
                    Evento d = new Evento();
                    FrmLogin.CantRegImp = d.CantRegImp(txtidrival);
                }

                if (FrmPrincipal.pupitre567 == 1)
                {
                    Evento d = new Evento();
                    FrmLogin.CantRegImp = d.CantRegImp(txtidrival);
                }

                if (FrmPrincipal.TV == 1)
                {
                    Evento d = new Evento();
                    FrmLogin.CantRegImp = d.CantRegImp(dgvMovil);
                }




                printDocument1.Print();
                
            }
        }

        private void cbeventos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string evento = cbeventos.SelectedValue.ToString();


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
            int cantidad = 0, cantidad_fija = 0, tipo=0;
            DateTime mihora = DateTime.Now;
            string lahora = mihora.ToString("yyyy-MM-dd");
            //int credencial = 0;

            new Importar().Traigo_Configuracion_Evento(txtideventos);
            

           


                ////// CABINA ////////



                if (FrmPrincipal.cabina == 1)
                {

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


                            //     Rectangle rect12 = new Rectangle(440, 410, 170, 40);
                            //     e.Graphics.DrawRectangle(Pens.White, rect12);
                            //     e.Graphics.DrawString(Convert.ToString(row.Cells[8].Value).PadLeft(3, '0'), new Font("Arial Black", 14), Brushes.Black, rect12, stringFormat);

                            // QR
                            cadena = Convert.ToString(row.Cells[10].Value) + "#" + Convert.ToString(row.Cells[3].Value) + "*" + Convert.ToString(row.Cells[4].Value).PadLeft(2, '0') + "0000" + "^" + URL.Text;
                            //cadena = URL.Text + " " + Convert.ToString(row.Cells[10].Value);


                            if (imprimiqr.Checked == true)

                            {

                                // Nombre y DNI
                                if (Convert.ToString(row.Cells[6].Value) != "")
                                {
                                    e.Graphics.DrawString(Convert.ToString(row.Cells[6].Value), new Font("Arial Black", 14), Brushes.Black, rect3, stringFormat);
                                    if (Convert.ToString(row.Cells[7].Value) != "")
                                    {
                                        Rectangle rect6 = new Rectangle(320, 260, 290, 60);
                                        e.Graphics.DrawRectangle(Pens.White, rect6);
                                        e.Graphics.DrawString(Convert.ToString(row.Cells[7].Value), new Font("Arial Black", 14), Brushes.Black, rect6, stringFormat);
                                    }
                                    Rectangle rect4 = new Rectangle(330, 290, 290, 40);
                                    e.Graphics.DrawRectangle(Pens.White, rect4);
                                    e.Graphics.DrawString("CABINA Nº " + Convert.ToString(row.Cells[4].Value), new Font("Arial Black", 14), Brushes.Black, rect4, stringFormat);

                                }

                                else
                                {
                                    Rectangle rect4 = new Rectangle(330, 250, 290, 70);
                                    e.Graphics.DrawRectangle(Pens.White, rect4);
                                    e.Graphics.DrawString("CABINA Nº " + Convert.ToString(row.Cells[4].Value), new Font("Arial Black", 14), Brushes.Black, rect4, stringFormat);

                                }

                            }
                            else
                            {

                                // Nombre y DNI
                                Rectangle rect999 = new Rectangle(220, 230, 390, 70);
                                e.Graphics.DrawRectangle(Pens.White, rect999);
                                if (Convert.ToString(row.Cells[6].Value) != "")
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
                           // e.Graphics.DrawRectangle(Pens.Black, rect1);

                            e.Graphics.DrawString(Convert.ToString(txttorneo.Text) + " - " + Convert.ToString(fecnumero.Text), new Font("Arial Black", 15), Brushes.Black, rect1, stringFormat);

                            Rectangle rect0 = new Rectangle(220, 140, 390, 45);
                         //   e.Graphics.DrawRectangle(Pens.Black, rect0);
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
                                                    







                            //    Rectangle rect5 = new Rectangle(200, 410, 390, 30);
                            //     e.Graphics.DrawRectangle(Pens.White, rect5);

                            //e.Graphics.DrawString(Convert.ToString(row.Cells[2].Value), new Font("Arial Black", 14), Brushes.Black, rect5, stringFormat);
                            //   float x11111 = 200.0F;
                            //    float y11111 = 352.0F;
                            //    float x22222 = 590.0F;
                            //    float y22222 = 352.0F;
                            //                        e.Graphics.DrawLine(blackPen, x11111, y11111, x22222, y22222);

                            //                      Rectangle rect11 = new Rectangle(200, 220, 390, 230);
                            //                     e.Graphics.DrawRectangle(Pens.Black, rect11);









                            if (imprimiqr.Checked == true)

                            {
                                // CODIGO QR

                                QrCode qrCode = new QrCode();
                                qrEncoder.TryEncode(cadena, out qrCode);
                                GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.Black, Brushes.White);
                                MemoryStream ms = new MemoryStream();
                                renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
                                var imageTemporal = new Bitmap(ms);
                                var imagen = new Bitmap(imageTemporal, new Size(new Point(100, 100)));
                                panelResultado.BackgroundImage = imagen;

                                //     e.Graphics.DrawImage(panelResultado.BackgroundImage, 220, 470, 100, 100);
                                e.Graphics.DrawImage(panelResultado.BackgroundImage, 230, 190, 100, 100);

                            }









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






                }


                //// PUPITRE ///////

                if (FrmPrincipal.pupitre == 1 | FrmPrincipal.pupitre34 == 1 | FrmPrincipal.pupitre567 == 1)

                {

                    foreach (DataGridViewRow row in txtidrival.Rows)
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
                            //Rectangle rect12 = new Rectangle(440, 410, 170, 40);
                            // e.Graphics.DrawRectangle(Pens.White, rect12);
                            // e.Graphics.DrawString(Convert.ToString(row.Cells[9].Value).PadLeft(3, '0'), new Font("Arial Black", 14), Brushes.Black, rect12, stringFormat);

                            // QR
                           cadena = Convert.ToString(row.Cells[11].Value) + "#" + Convert.ToString(row.Cells[3].Value) + "*" + "00" + Convert.ToString(row.Cells[4].Value).PadLeft(2, '0') + Convert.ToString(row.Cells[5].Value).PadLeft(2, '0') + "^" + URL.Text;
                            //cadena = URL.Text + " " + Convert.ToString(row.Cells[10].Value);



                            if (imprimiqr.Checked == true)

                            {

                                // Nombre y DNI
                                if (Convert.ToString(row.Cells[7].Value) != "")
                                {
                                    e.Graphics.DrawString(Convert.ToString(row.Cells[7].Value), new Font("Arial Black", 14), Brushes.Black, rect3, stringFormat);
                                    if (Convert.ToString(row.Cells[8].Value) != "")
                                    {
                                        Rectangle rect6 = new Rectangle(320, 250, 290, 70);
                                        e.Graphics.DrawRectangle(Pens.White, rect6);
                                        e.Graphics.DrawString(Convert.ToString(row.Cells[8].Value), new Font("Arial Black", 14), Brushes.Black, rect6, stringFormat);
                                    }
                                    Rectangle rect4 = new Rectangle(320, 270, 290, 70);
                                    e.Graphics.DrawRectangle(Pens.White, rect4);
                                    e.Graphics.DrawString("FILA Nº " + Convert.ToString(row.Cells[4].Value) + " ASIENTO Nº " + Convert.ToString(row.Cells[5].Value), new Font("Arial Black", 14), Brushes.Black, rect4, stringFormat);

                                }

                                else
                                {
                                    Rectangle rect4 = new Rectangle(320, 250, 290, 70);
                                    e.Graphics.DrawRectangle(Pens.White, rect4);
                                    e.Graphics.DrawString("FILA Nº " + Convert.ToString(row.Cells[4].Value) + " ASIENTO Nº " + Convert.ToString(row.Cells[5].Value), new Font("Arial Black", 14), Brushes.Black, rect4, stringFormat);

                                }

                            }  else
                            {

                                // Nombre y DNI
                                Rectangle rect999 = new Rectangle(220, 230, 390, 70);
                                e.Graphics.DrawRectangle(Pens.White, rect999);
                                if (Convert.ToString(row.Cells[7].Value) != "")
                                {
                                    e.Graphics.DrawString(Convert.ToString(row.Cells[7].Value), new Font("Arial Black", 14), Brushes.Black, rect999, stringFormat);
                                    if (Convert.ToString(row.Cells[8].Value) != "")
                                    {
                                        Rectangle rect6 = new Rectangle(220, 250, 390, 70);
                                        e.Graphics.DrawRectangle(Pens.White, rect6);
                                        e.Graphics.DrawString(Convert.ToString(row.Cells[8].Value), new Font("Arial Black", 14), Brushes.Black, rect6, stringFormat);
                                    }
                                    Rectangle rect4 = new Rectangle(220, 270, 390, 70);
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
                          //  e.Graphics.DrawRectangle(Pens.Black, rect1);

                            e.Graphics.DrawString(Convert.ToString(txttorneo.Text) + " - " + Convert.ToString(fecnumero.Text), new Font("Arial Black", 15), Brushes.Black, rect1, stringFormat);

                            Rectangle rect0 = new Rectangle(220, 130, 390, 45);
                           // e.Graphics.DrawRectangle(Pens.Black, rect0);
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




                            // Rectangle rect5 = new Rectangle(200, 410, 390, 30);
                            // e.Graphics.DrawRectangle(Pens.White, rect5);

                            //e.Graphics.DrawString(Convert.ToString(row.Cells[2].Value), new Font("Arial Black", 14), Brushes.Black, rect5, stringFormat);
                            // float x11111 = 200.0F;
                            //  float y11111 = 352.0F;
                            //  float x22222 = 590.0F;
                            //  float y22222 = 352.0F;
                            //  e.Graphics.DrawLine(blackPen, x11111, y11111, x22222, y22222);


                            //   Rectangle rect11 = new Rectangle(200, 220, 390, 230);
                            //   e.Graphics.DrawRectangle(Pens.Black, rect11);

                            //  Rectangle rect12 = new Rectangle(200, 180, 390, 140);
                            //  e.Graphics.DrawRectangle(Pens.Black, rect12);




                            if (imprimiqr.Checked == true)

                            {
                                // CODIGO QR

                                QrCode qrCode = new QrCode();
                                qrEncoder.TryEncode(cadena, out qrCode);
                                GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.Black, Brushes.White);
                                MemoryStream ms = new MemoryStream();
                                renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
                                var imageTemporal = new Bitmap(ms);
                                var imagen = new Bitmap(imageTemporal, new Size(new Point(100, 100)));
                                panelResultado.BackgroundImage = imagen;

                                e.Graphics.DrawImage(panelResultado.BackgroundImage, 230, 190, 100, 100);
                                //e.Graphics.DrawImage(panelResultado.BackgroundImage, 220, 470, 100, 100);

                            }



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

                }

                //// MOVIL ///////

                if (FrmPrincipal.movil == 1)

                {



                    foreach (DataGridViewRow row in dgvMovil.Rows)
                    {

                        if (Convert.ToBoolean(row.Cells[0].Value) == true)


                        {

                            tipo = 3;
                            row.Cells[4].Value = Convert.ToString(Convert.ToInt32(row.Cells[4].Value) - 1);
                            cantidad = Convert.ToInt32(row.Cells[4].Value);
                            cantidad_fija = cantidad + 1;
                            Rectangle rect3 = new Rectangle(320, 210, 290, 70);
                            e.Graphics.DrawRectangle(Pens.White, rect3);

                            //credencial


                            //Rectangle rect12 = new Rectangle(440, 410, 170, 40);
                            // e.Graphics.DrawRectangle(Pens.White, rect12);
                            // e.Graphics.DrawString(Convert.ToString(row.Cells[7].Value).PadLeft(3, '0'), new Font("Arial Black", 14), Brushes.Black, rect12, stringFormat);



                            // QR
                           cadena = Convert.ToString(row.Cells[9].Value) + "#" + Convert.ToString(row.Cells[3].Value) + "*" + "000000" + "^" + URL.Text;
                            // cadena = URL.Text + " " + Convert.ToString(row.Cells[10].Value);

                            // Nombre y DNI


                            if (imprimiqr.Checked == true)

                            {


                                if (Convert.ToString(row.Cells[5].Value) != "")
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
            //                        e.Graphics.DrawString("MOVIL", new Font("Arial Black", 17), Brushes.Black, rect4, stringFormat);
                                    Rectangle rect99 = new Rectangle(300, 290, 290, 40);
                                    e.Graphics.DrawRectangle(Pens.White, rect99);
                                    e.Graphics.DrawString("ACCESO A DESIGNAR", new Font("Arial Black", 15), Brushes.Black, rect99, stringFormat);


                                }
                                else
                                {

                                    Rectangle rect4 = new Rectangle(320, 250, 290, 40);
                                    e.Graphics.DrawRectangle(Pens.White, rect4);
              //                      e.Graphics.DrawString("MOVIL", new Font("Arial Black", 17), Brushes.Black, rect4, stringFormat);
                                    Rectangle rect99 = new Rectangle(320, 290, 290, 40);
                                    e.Graphics.DrawRectangle(Pens.White, rect99);
            //                        e.Graphics.DrawString("ACCESO A DESIGNAR", new Font("Arial Black", 15), Brushes.Black, rect99, stringFormat);

                                }


                            }
                            else
                            {
                                Rectangle rect999 = new Rectangle(220, 230, 390, 70);
                                e.Graphics.DrawRectangle(Pens.White, rect999);
                                if (Convert.ToString(row.Cells[5].Value) != "")
                                {
                                    e.Graphics.DrawString(Convert.ToString(row.Cells[5].Value), new Font("Arial Black", 14), Brushes.Black, rect999, stringFormat);
                                    if (Convert.ToString(row.Cells[6].Value) != "")
                                    {
                                        Rectangle rect6 = new Rectangle(220, 250, 390, 70);
                                        e.Graphics.DrawRectangle(Pens.White, rect6);
                                        e.Graphics.DrawString(Convert.ToString(row.Cells[6].Value), new Font("Arial Black", 14), Brushes.Black, rect6, stringFormat);
                                    }
                                    Rectangle rect4 = new Rectangle(200, 270, 390, 40);
                                    e.Graphics.DrawRectangle(Pens.White, rect4);
              //                      e.Graphics.DrawString("MOVIL", new Font("Arial Black", 17), Brushes.Black, rect4, stringFormat);
                                    Rectangle rect99 = new Rectangle(200, 290, 390, 40);
                                    e.Graphics.DrawRectangle(Pens.White, rect99);
                //                    e.Graphics.DrawString("ACCESO A DESIGNAR", new Font("Arial Black", 15), Brushes.Black, rect99, stringFormat);


                                }
                                else
                                {

                                    Rectangle rect4 = new Rectangle(220, 250, 390, 40);
                                    e.Graphics.DrawRectangle(Pens.White, rect4);
                  //                  e.Graphics.DrawString("MOVIL", new Font("Arial Black", 17), Brushes.Black, rect4, stringFormat);
                                    Rectangle rect99 = new Rectangle(220, 290, 390, 40);
                                    e.Graphics.DrawRectangle(Pens.White, rect99);
                    //                e.Graphics.DrawString("ACCESO A DESIGNAR", new Font("Arial Black", 15), Brushes.Black, rect99, stringFormat);

                                }
                                
                            }



                                Rectangle rect1 = new Rectangle(220, 90, 390, 45);
                          //  e.Graphics.DrawRectangle(Pens.Black, rect1);

                            e.Graphics.DrawString(Convert.ToString(txttorneo.Text) + " - " + Convert.ToString(fecnumero.Text), new Font("Arial Black", 15), Brushes.Black, rect1, stringFormat);

                            Rectangle rect0 = new Rectangle(220, 130, 390, 45);
                           // e.Graphics.DrawRectangle(Pens.Black, rect0);
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



                            //Rectangle rect5 = new Rectangle(200, 420, 390, 30);
                            // e.Graphics.DrawRectangle(Pens.White, rect5);

                            //e.Graphics.DrawString(Convert.ToString(row.Cells[2].Value), new Font("Arial Black", 14), Brushes.Black, rect5, stringFormat);
                            // float x11111 = 200.0F;
                            //  float y11111 = 352.0F;
                            //  float x22222 = 590.0F;
                            //  float y22222 = 352.0F;
                            //  e.Graphics.DrawLine(blackPen, x11111, y11111, x22222, y22222);


                            // Rectangle rect11 = new Rectangle(200, 220, 390, 230);
                            // e.Graphics.DrawRectangle(Pens.Black, rect11);

                            //  Rectangle rect12 = new Rectangle(200, 180, 390, 140);
                            //  e.Graphics.DrawRectangle(Pens.Black, rect12);




                            if (imprimiqr.Checked == true)

                            {
                                // CODIGO QR

                                QrCode qrCode = new QrCode();
                                qrEncoder.TryEncode(cadena, out qrCode);
                                GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.Black, Brushes.White);
                                MemoryStream ms = new MemoryStream();
                                renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
                                var imageTemporal = new Bitmap(ms);
                                var imagen = new Bitmap(imageTemporal, new Size(new Point(100, 100)));
                                panelResultado.BackgroundImage = imagen;

                                e.Graphics.DrawImage(panelResultado.BackgroundImage, 220, 190, 100, 100);
                                //e.Graphics.DrawImage(panelResultado.BackgroundImage, 220, 470, 100, 100);

                            }




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

                }


                //// TV ///////

                if (FrmPrincipal.TV == 1)

                {


                    foreach (DataGridViewRow row in dgvMovil.Rows)
                    {

                        if (Convert.ToBoolean(row.Cells[0].Value) == true)

                        {




                            tipo = 4;
                            row.Cells[4].Value = Convert.ToString(Convert.ToInt32(row.Cells[4].Value) - 1);
                            cantidad = Convert.ToInt32(row.Cells[4].Value);
                            cantidad_fija = cantidad + 1;
                            Rectangle rect3 = new Rectangle(320, 230, 290, 70);
                            e.Graphics.DrawRectangle(Pens.White, rect3);

                            //credencial


                            //Rectangle rect12 = new Rectangle(440, 410, 170, 40);
                            // e.Graphics.DrawRectangle(Pens.White, rect12);
                            // e.Graphics.DrawString(Convert.ToString(row.Cells[7].Value).PadLeft(3, '0'), new Font("Arial Black", 14), Brushes.Black, rect12, stringFormat);



                            // QR
                            cadena = Convert.ToString(row.Cells[9].Value) + "#" + Convert.ToString(row.Cells[3].Value) + "*" + "000000" + "^" + URL.Text;
                            //cadena = URL.Text + " " + Convert.ToString(row.Cells[10].Value);


                            // Nombre y DNI
                            if (imprimiqr.Checked == true)

                            {


                                if (Convert.ToString(row.Cells[5].Value) != "")
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
                //                    e.Graphics.DrawString("MOVIL", new Font("Arial Black", 17), Brushes.Black, rect4, stringFormat);
                                    Rectangle rect99 = new Rectangle(300, 290, 290, 40);
                                    e.Graphics.DrawRectangle(Pens.White, rect99);
                      //              e.Graphics.DrawString("ACCESO A DESIGNAR", new Font("Arial Black", 15), Brushes.Black, rect99, stringFormat);


                                }
                                else
                                {

                                    Rectangle rect4 = new Rectangle(320, 250, 290, 40);
                                    e.Graphics.DrawRectangle(Pens.White, rect4);
                  //                  e.Graphics.DrawString("MOVIL", new Font("Arial Black", 17), Brushes.Black, rect4, stringFormat);
                                    Rectangle rect99 = new Rectangle(320, 290, 290, 40);
                                    e.Graphics.DrawRectangle(Pens.White, rect99);
                        //            e.Graphics.DrawString("ACCESO A DESIGNAR", new Font("Arial Black", 15), Brushes.Black, rect99, stringFormat);

                                }


                            }
                            else
                            {
                                Rectangle rect999 = new Rectangle(220, 230, 390, 70);
                                e.Graphics.DrawRectangle(Pens.White, rect999);
                                if (Convert.ToString(row.Cells[5].Value) != "")
                                {
                                    e.Graphics.DrawString(Convert.ToString(row.Cells[5].Value), new Font("Arial Black", 14), Brushes.Black, rect999, stringFormat);
                                    if (Convert.ToString(row.Cells[6].Value) != "")
                                    {
                                        Rectangle rect6 = new Rectangle(220, 250, 390, 70);
                                        e.Graphics.DrawRectangle(Pens.White, rect6);
                                        e.Graphics.DrawString(Convert.ToString(row.Cells[6].Value), new Font("Arial Black", 14), Brushes.Black, rect6, stringFormat);
                                    }
                                    Rectangle rect4 = new Rectangle(200, 270, 390, 40);
                                    e.Graphics.DrawRectangle(Pens.White, rect4);
                          //          e.Graphics.DrawString("MOVIL", new Font("Arial Black", 17), Brushes.Black, rect4, stringFormat);
                                    Rectangle rect99 = new Rectangle(200, 290, 390, 40);
                                    e.Graphics.DrawRectangle(Pens.White, rect99);
                            //        e.Graphics.DrawString("ACCESO A DESIGNAR", new Font("Arial Black", 15), Brushes.Black, rect99, stringFormat);


                                }
                                else
                                {

                                    Rectangle rect4 = new Rectangle(220, 250, 390, 40);
                                    e.Graphics.DrawRectangle(Pens.White, rect4);
                              //      e.Graphics.DrawString("MOVIL", new Font("Arial Black", 17), Brushes.Black, rect4, stringFormat);
                                    Rectangle rect99 = new Rectangle(220, 290, 390, 40);
                                    e.Graphics.DrawRectangle(Pens.White, rect99);
                                //    e.Graphics.DrawString("ACCESO A DESIGNAR", new Font("Arial Black", 15), Brushes.Black, rect99, stringFormat);

                                }

                            }


                            Rectangle rect1 = new Rectangle(220, 90, 390, 45);
                         //   e.Graphics.DrawRectangle(Pens.Black, rect1);

                            e.Graphics.DrawString(Convert.ToString(txttorneo.Text) + " - " + Convert.ToString(fecnumero.Text), new Font("Arial Black", 15), Brushes.Black, rect1, stringFormat);

                            Rectangle rect0 = new Rectangle(220, 130, 390, 45);
                         //   e.Graphics.DrawRectangle(Pens.Black, rect0);
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
                            //e.Graphics.DrawRectangle(Pens.White, rect5);

                            //e.Graphics.DrawString(Convert.ToString(row.Cells[2].Value), new Font("Arial Black", 14), Brushes.Black, rect5, stringFormat);
                            // float x11111 = 200.0F;
                            // float y11111 = 352.0F;
                            // float x22222 = 590.0F;
                            // float y22222 = 352.0F;
                            // e.Graphics.DrawLine(blackPen, x11111, y11111, x22222, y22222);


                            //  Rectangle rect11 = new Rectangle(200, 220, 390, 230);
                            //  e.Graphics.DrawRectangle(Pens.Black, rect11);

                            //  Rectangle rect12 = new Rectangle(200, 180, 390, 140);
                            //  e.Graphics.DrawRectangle(Pens.Black, rect12);




                            if (imprimiqr.Checked == true)

                            {
                                // CODIGO QR

                                QrCode qrCode = new QrCode();
                                qrEncoder.TryEncode(cadena, out qrCode);
                                GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.Black, Brushes.White);
                                MemoryStream ms = new MemoryStream();
                                renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
                                var imageTemporal = new Bitmap(ms);
                                var imagen = new Bitmap(imageTemporal, new Size(new Point(100, 100)));
                                panelResultado.BackgroundImage = imagen;

                                e.Graphics.DrawImage(panelResultado.BackgroundImage, 220, 190, 100, 100);
                                //e.Graphics.DrawImage(panelResultado.BackgroundImage, 220, 470, 100, 100);

                            }



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

                }



                MessageBox.Show("Finalizo la Impresion");
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string criterio = "SELECT comentarios FROM eventos WHERE Id_Evento=" + Id_evento.Text;

            Evento d = new Evento();
            d.Busco_Comentario(criterio,txtcomentarios);
            comentario.Visible = true;
            
             
        }

        private void button4_Click(object sender, EventArgs e)
        {
            comentario.Visible = false;
              
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Evento d = new Evento();
            d.Guardo_Comentario(txtcomentarios, Id_evento.Text);
            comentario.Visible = true;
        }

        private void txtcomentarios_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void cbtipos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

            if (cbtipos.Text == "Cabinas")
            {
                Evento d = new Evento();
                d.Bajo_Cabinas(dgvCabinas);

            }


            if (cbtipos.Text == "Pupitres")
            {
                Evento d = new Evento();
                d.Bajo_Pupitres(txtidrival);

            }

            if (cbtipos.Text == "Moviles")
            {
                Evento d = new Evento();
                d.Bajo_Moviles(dgvMovil);

            }


            if (cbtipos.Text == "TV")
            {
                Evento d = new Evento();
                d.Bajo_TV(dgvMovil);

            }





        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (cbtipos.Text == "Cabinas")
            {
                Evento d = new Evento();
                d.Modifico_Cabinas(dgvCabinas);

            }


            if (cbtipos.Text == "Pupitres")
            {
                Evento d = new Evento();
                d.Modifico_Pupitre(txtidrival);

            }

            if (cbtipos.Text == "Moviles")
            {
                Evento d = new Evento();
                d.Modifico_Moviles(dgvMovil);

            }


            if (cbtipos.Text == "TV")
            {
                Evento d = new Evento();
                d.Modifico_TV(dgvMovil);

            }
        }

        private void txtidrival_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvEventos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtidevento.Text = Convert.ToString(this.dgvEventos.CurrentRow.Cells[3].Value);
            Id_evento.Text  = txtidevento.Text;
            estado_evento.Text = Convert.ToString(this.dgvEventos.CurrentRow.Cells[5].Value);
            new Evento().Traigo_Datos_Evento(txttorneo, txtevento, URL, fecnumero, Id_evento, lafecha, textIdRival, estado_evento);
            pdesde.Text = Convert.ToDateTime(lafecha.Text).ToString("yyyy-MM-dd");
            groupBox1.Visible = false;
            button1.Enabled = true;
            button2.Enabled = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string criterio = "";

            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
            criterio = "Select a.Id_Evento, a.Nombre_Evento, a.Campeonato, a.Fecha, a.url, a.Numero_Fecha, a.Rival, a.Id_Rival, a.Estado, b.Descripcion From eventos AS a INNER JOIN Estados AS b ON a.Estado = b.Estado ORDER BY a.Fecha DESC";
            new Importar().muestro_eventos(dgvEventos, criterio);
            groupBox1.Visible = true;
            System.Windows.Forms.Cursor.Current = Cursors.Default;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
             
        }

        private void dgvEventos_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
           
        }

        private void txtidrival_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.Hand; 
        }

        private void dgvEventos_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void FrmConsultas_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Default;
            button6.BackColor = Color.DeepSkyBlue;
            button5.BackColor = Color.DeepSkyBlue;
        }

        private void dgvCabinas_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void dgvMovil_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void dgvMovil_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void dgvEventos_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            Id_evento.Text = Convert.ToString(this.dgvEventos.CurrentRow.Cells[3].Value);
            estado_evento.Text = Convert.ToString(this.dgvEventos.CurrentRow.Cells[5].Value);
            textIdRival.Text = Convert.ToString(this.dgvEventos.CurrentRow.Cells[7].Value);
            lafecha.Text = Convert.ToString(this.dgvEventos.CurrentRow.Cells[2].Value);
            new Evento().Traigo_Datos_Evento(txttorneo, txtevento, URL, fecnumero, Id_evento, lafecha, textIdRival, estado_evento);
          // new Importar().traigo_escudo_rival(txtIdRival.Text, pictureBox3, pictureBox2, nombreequipo, cuadro);
            pdesde.Text = Convert.ToDateTime(lafecha.Text).ToString("yyyy-MM-dd");
       //   txtrival.Text = nombreequipo.Text;
            groupBox1.Visible = false;
            button1.Enabled = true;
            txtideventos = Id_evento.Text;
            txtidrival.Rows.Clear();
            dgvCabinas.Rows.Clear();
            dgvMovil.Rows.Clear();



        }

        private void groupBox1_Enter(object sender, EventArgs e)
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
            int cantidad = 0, cantidad_fija = 0, tipo = 0;
            DateTime mihora = DateTime.Now;
            string lahora = mihora.ToString("yyyy-MM-dd");
            //int credencial = 0;

            new Importar().Traigo_Configuracion_Evento(txtideventos);

                       
            


                ////// CABINA ////////



                if (FrmPrincipal.cabina == 1)
                {

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
                        //e.Graphics.DrawRectangle(Pens.Black, rect1);
                        e.Graphics.DrawString(Convert.ToString(txttorneo.Text), new Font("Garamond", 16, FontStyle.Bold), Brushes.Black, rect1, stringFormat);
                        Rectangle rect111 = new Rectangle(190, 107, 410, 45);
                        //e.Graphics.DrawRectangle(Pens.Black, rect1);

                        //Por unica vez
                        //e.Graphics.DrawString(Convert.ToDateTime(fecnumero.Text).ToString("dd-MM-yyyy"), new Font("Garamond", 16, FontStyle.Bold), Brushes.Black, rect111, stringFormat);
                        e.Graphics.DrawString("FINAL", new Font("Garamond", 16, FontStyle.Bold), Brushes.Black, rect111, stringFormat);

                        //e.Graphics.DrawString(Convert.ToDateTime(fecnumero.Text).ToString("dd-MM-yyyy"), new Font("Garamond", 16, FontStyle.Bold), Brushes.Black, rect111, stringFormat);
                        Rectangle rect0 = new Rectangle(190, 130, 410, 45);
                        //  e.Graphics.DrawRectangle(Pens.Black, rect0);
                        e.Graphics.DrawString(Convert.ToString(row.Cells[2].Value), new Font("Garamond", 16, FontStyle.Bold), Brushes.Black, rect0, stringFormat);
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
                                e.Graphics.DrawString(substring, new Font("Calibri Light", 21, FontStyle.Bold), Brushes.Black, rect2, stringFormat);
                                num = num + 30;
                            }
                            Pen mipen1 = new Pen(Color.Black, 7);
                            e.Graphics.DrawLine(mipen1, 170, 260, 630, 260);                         


                            // fila 3

                            Rectangle rect22 = new Rectangle(200, 250, 390, 60);
                            e.Graphics.DrawRectangle(Pens.White, rect22);
                            e.Graphics.DrawString("CABINA DE PRENSA" ,  new Font("Stencial", 21), Brushes.Black, rect22, stringFormat);
                            Rectangle rect4 = new Rectangle(200, 290, 390, 60);
                            e.Graphics.DrawRectangle(Pens.White, rect4);
                            e.Graphics.DrawString("CABINA Nº " + Convert.ToString(row.Cells[4].Value), new Font("Stencial", 21), Brushes.Black, rect4, stringFormat);

                            
                            if (Convert.ToString(row.Cells[6].Value) != "")
                            {
                                Rectangle rect23 = new Rectangle(170, 340, 390, 60);
                                e.Graphics.DrawRectangle(Pens.White, rect23);
                                e.Graphics.DrawString(Convert.ToString(row.Cells[6].Value), new Font("Stencial", 21), Brushes.Black, rect23, stringFormat);
                                if (Convert.ToString(row.Cells[7].Value) != "")
                                {
                                    Rectangle rect6 = new Rectangle(170, 390, 390, 60);
                                    e.Graphics.DrawRectangle(Pens.White, rect6);
                                    e.Graphics.DrawString(Convert.ToString(row.Cells[7].Value), new Font("Stencial", 21), Brushes.Black, rect6, stringFormat);
                                }
                            

                            }


                            //credencial


                                 Rectangle rect12 = new Rectangle(370, 420, 390, 40);
                                 e.Graphics.DrawRectangle(Pens.White, rect12);
                                 e.Graphics.DrawString("Nº " + Convert.ToString(row.Cells[8].Value).PadLeft(3, '0'), new Font("Arial Black", 14), Brushes.Black, rect12, stringFormat);

                            // QR

                            if (imprimiqr.Checked == true)

                            {
                                cadena = Convert.ToString(row.Cells[10].Value) + "#" + Convert.ToString(row.Cells[3].Value) + "*" + Convert.ToString(row.Cells[4].Value).PadLeft(2, '0') + "0000" + "^" + URL.Text;
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


                }




                // PUPITRES /////


                if (FrmPrincipal.pupitre == 1 | FrmPrincipal.pupitre34 == 1 | FrmPrincipal.pupitre567 == 1)

                {


                    foreach (DataGridViewRow row in txtidrival.Rows)
                    
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
                        //e.Graphics.DrawRectangle(Pens.Black, rect1);
                        e.Graphics.DrawString(Convert.ToString(txttorneo.Text), new Font("Garamond", 16, FontStyle.Bold), Brushes.Black, rect1, stringFormat);
                        Rectangle rect111 = new Rectangle(190, 107, 410, 45);
                        //e.Graphics.DrawRectangle(Pens.Black, rect1);

                        //Por unica vez
                        //e.Graphics.DrawString(Convert.ToDateTime(fecnumero.Text).ToString("dd-MM-yyyy"), new Font("Garamond", 16, FontStyle.Bold), Brushes.Black, rect111, stringFormat);
                        e.Graphics.DrawString("FINAL", new Font("Garamond", 16, FontStyle.Bold), Brushes.Black, rect111, stringFormat);

                        Rectangle rect0 = new Rectangle(190, 130, 410, 45);
                        //  e.Graphics.DrawRectangle(Pens.Black, rect0);
                        e.Graphics.DrawString(Convert.ToString(row.Cells[2].Value), new Font("Garamond", 16, FontStyle.Bold), Brushes.Black, rect0, stringFormat);
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
                                e.Graphics.DrawString(substring, new Font("Calibri Light", 21, FontStyle.Bold), Brushes.Black, rect2, stringFormat);
                                num = num + 30;
                            }
                            Pen mipen1 = new Pen(Color.Black, 7);
                            e.Graphics.DrawLine(mipen1, 170, 260, 630, 260);



                            // fila 3

                            Rectangle rect22 = new Rectangle(200, 250, 390, 60);
                            e.Graphics.DrawRectangle(Pens.White, rect22);
                            e.Graphics.DrawString("PUPITRE DE PRENSA", new Font("Stencial", 21), Brushes.Black, rect22, stringFormat);
                            Rectangle rect4 = new Rectangle(200, 290, 390, 60);
                            e.Graphics.DrawRectangle(Pens.White, rect4);
                            e.Graphics.DrawString("FILA Nº " + Convert.ToString(row.Cells[4].Value) + " ASIENTO Nº " + Convert.ToString(row.Cells[5].Value), new Font("Stencial", 21), Brushes.Black, rect4, stringFormat);

                            if (Convert.ToString(row.Cells[7].Value) != "")
                            {
                                Rectangle rect23 = new Rectangle(170, 340, 390, 60);
                                e.Graphics.DrawRectangle(Pens.White, rect23);
                                e.Graphics.DrawString(Convert.ToString(row.Cells[7].Value), new Font("Stencial", 21), Brushes.Black, rect23, stringFormat);
                                if (Convert.ToString(row.Cells[8].Value) != "")
                                {
                                    Rectangle rect6 = new Rectangle(170, 390, 390, 60);
                                    e.Graphics.DrawRectangle(Pens.White, rect6);
                                    e.Graphics.DrawString(Convert.ToString(row.Cells[8].Value), new Font("Stencial", 21), Brushes.Black, rect6, stringFormat);
                                }


                            }


                            //credencial


                            Rectangle rect12 = new Rectangle(370, 420, 390, 40);
                            e.Graphics.DrawRectangle(Pens.White, rect12);
                            e.Graphics.DrawString("Nº " + Convert.ToString(row.Cells[9].Value).PadLeft(3, '0'), new Font("Arial Black", 14), Brushes.Black, rect12, stringFormat);

                            // QR

                            if (imprimiqr.Checked == true)

                            {
                                cadena = Convert.ToString(row.Cells[11].Value) + "#" + Convert.ToString(row.Cells[3].Value) + "*" + "00" + Convert.ToString(row.Cells[4].Value).PadLeft(2, '0') + Convert.ToString(row.Cells[5].Value).PadLeft(2, '0') + "^" + URL.Text;
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
                            e.Graphics.DrawString(Convert.ToString(row.Cells[12].Value), new Font("Arial", 32), Brushes.Black, rect29, stringFormat);


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

                }

                //// MOVIL ///////

                if (FrmPrincipal.movil == 1)

                {


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
                        //e.Graphics.DrawRectangle(Pens.Black, rect1);
                        e.Graphics.DrawString(Convert.ToString(txttorneo.Text), new Font("Garamond", 16, FontStyle.Bold), Brushes.Black, rect1, stringFormat);
                        Rectangle rect111 = new Rectangle(190, 107, 410, 45);
                        //e.Graphics.DrawRectangle(Pens.Black, rect1);

                        //Por unica vez
                        //e.Graphics.DrawString(Convert.ToDateTime(fecnumero.Text).ToString("dd-MM-yyyy"), new Font("Garamond", 16, FontStyle.Bold), Brushes.Black, rect111, stringFormat);
                        e.Graphics.DrawString("FINAL", new Font("Garamond", 16, FontStyle.Bold), Brushes.Black, rect111, stringFormat);

                        
                        Rectangle rect0 = new Rectangle(190, 130, 410, 45);
                        //  e.Graphics.DrawRectangle(Pens.Black, rect0);
                        e.Graphics.DrawString(Convert.ToString(row.Cells[2].Value), new Font("Garamond", 16, FontStyle.Bold), Brushes.Black, rect0, stringFormat);
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
                                e.Graphics.DrawString(substring, new Font("Calibri Light", 21, FontStyle.Bold), Brushes.Black, rect2, stringFormat);
                                num = num + 30;
                            }
                            Pen mipen1 = new Pen(Color.Black, 7);
                            e.Graphics.DrawLine(mipen1, 170, 260, 630, 260);



                            // fila 3

                            Rectangle rect22 = new Rectangle(200, 250, 390, 60);
                            e.Graphics.DrawRectangle(Pens.White, rect22);
                            e.Graphics.DrawString("MOVIL", new Font("Stencial", 21), Brushes.Black, rect22, stringFormat);
                            Rectangle rect4 = new Rectangle(200, 290, 390, 60);
                            e.Graphics.DrawRectangle(Pens.White, rect4);
                            e.Graphics.DrawString("ACCESO A DESIGNAR", new Font("Stencial", 21), Brushes.Black, rect4, stringFormat);


                            if (Convert.ToString(row.Cells[5].Value) != "")
                            {
                                Rectangle rect23 = new Rectangle(170, 340, 390, 60);
                                e.Graphics.DrawRectangle(Pens.White, rect23);
                                e.Graphics.DrawString(Convert.ToString(row.Cells[5].Value), new Font("Stencial", 21), Brushes.Black, rect23, stringFormat);
                                if (Convert.ToString(row.Cells[6].Value) != "")
                                {
                                    Rectangle rect6 = new Rectangle(170, 390, 390, 60);
                                    e.Graphics.DrawRectangle(Pens.White, rect6);
                                    e.Graphics.DrawString(Convert.ToString(row.Cells[6].Value), new Font("Stencial", 21), Brushes.Black, rect6, stringFormat);
                                }


                            }


                            //credencial


                            Rectangle rect12 = new Rectangle(370, 420, 390, 40);
                            e.Graphics.DrawRectangle(Pens.White, rect12);
                            e.Graphics.DrawString("Nº " + Convert.ToString(row.Cells[7].Value).PadLeft(3, '0'), new Font("Arial Black", 14), Brushes.Black, rect12, stringFormat);

                            // QR

                            if (imprimiqr.Checked == true)

                            {
                                cadena = Convert.ToString(row.Cells[9].Value) + "#" + Convert.ToString(row.Cells[3].Value) + "*" + "000000" + "^" + URL.Text;
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

                }

                    
                    

                //// TV ///////

                if (FrmPrincipal.TV == 1)

                {


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
                        //e.Graphics.DrawRectangle(Pens.Black, rect1);
                        e.Graphics.DrawString(Convert.ToString(txttorneo.Text), new Font("Garamond", 16, FontStyle.Bold), Brushes.Black, rect1, stringFormat);
                        Rectangle rect111 = new Rectangle(190, 107, 410, 45);
                        //e.Graphics.DrawRectangle(Pens.Black, rect1);

                        //Por unica vez
                        //e.Graphics.DrawString(Convert.ToDateTime(fecnumero.Text).ToString("dd-MM-yyyy"), new Font("Garamond", 16, FontStyle.Bold), Brushes.Black, rect111, stringFormat);
                        e.Graphics.DrawString("FINAL", new Font("Garamond", 16, FontStyle.Bold), Brushes.Black, rect111, stringFormat);

                        Rectangle rect0 = new Rectangle(190, 130, 410, 45);
                        //  e.Graphics.DrawRectangle(Pens.Black, rect0);
                        e.Graphics.DrawString(Convert.ToString(row.Cells[2].Value), new Font("Garamond", 16, FontStyle.Bold), Brushes.Black, rect0, stringFormat);
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
                                e.Graphics.DrawString(substring, new Font("Calibri Light", 21, FontStyle.Bold), Brushes.Black, rect2, stringFormat);
                                num = num + 30;
                            }
                            Pen mipen1 = new Pen(Color.Black, 7);
                            e.Graphics.DrawLine(mipen1, 170, 260, 630, 260);



                            // fila 3

                            Rectangle rect22 = new Rectangle(200, 250, 390, 60);
                            e.Graphics.DrawRectangle(Pens.White, rect22);
                            e.Graphics.DrawString("MOVIL", new Font("Stencial", 21), Brushes.Black, rect22, stringFormat);
                            Rectangle rect4 = new Rectangle(200, 290, 390, 60);
                            e.Graphics.DrawRectangle(Pens.White, rect4);
                            e.Graphics.DrawString("ACCESO A DESIGNAR", new Font("Stencial", 21), Brushes.Black, rect4, stringFormat);


                            if (Convert.ToString(row.Cells[5].Value) != "")
                            {
                                Rectangle rect23 = new Rectangle(170, 340, 390, 60);
                                e.Graphics.DrawRectangle(Pens.White, rect23);
                                e.Graphics.DrawString(Convert.ToString(row.Cells[5].Value), new Font("Stencial", 21), Brushes.Black, rect23, stringFormat);
                                if (Convert.ToString(row.Cells[6].Value) != "")
                                {
                                    Rectangle rect6 = new Rectangle(170, 390, 390, 60);
                                    e.Graphics.DrawRectangle(Pens.White, rect6);
                                    e.Graphics.DrawString(Convert.ToString(row.Cells[6].Value), new Font("Stencial", 21), Brushes.Black, rect6, stringFormat);
                                }


                            }


                            //credencial


                            Rectangle rect12 = new Rectangle(370, 420, 390, 40);
                            e.Graphics.DrawRectangle(Pens.White, rect12);
                            e.Graphics.DrawString("Nº " + Convert.ToString(row.Cells[7].Value).PadLeft(3, '0'), new Font("Arial Black", 14), Brushes.Black, rect12, stringFormat);

                            // QR

                            if (imprimiqr.Checked == true)

                            {
                                cadena = Convert.ToString(row.Cells[9].Value) + "#" + Convert.ToString(row.Cells[3].Value) + "*" + "000000" + "^" + URL.Text;
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

                }

                

                MessageBox.Show("Finalizo la Impresion");

            
        }

        private void button9_Click(object sender, EventArgs e)
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
                    FrmLogin.CantRegImp = d.CantRegImp(txtidrival);
                }

                if (FrmPrincipal.pupitre34 == 1)
                {
                    Evento d = new Evento();
                    FrmLogin.CantRegImp = d.CantRegImp(txtidrival);
                }

                if (FrmPrincipal.pupitre567 == 1)
                {
                    Evento d = new Evento();
                    FrmLogin.CantRegImp = d.CantRegImp(txtidrival);
                }

                if (FrmPrincipal.TV == 1)
                {
                    Evento d = new Evento();
                    FrmLogin.CantRegImp = d.CantRegImp(dgvMovil);
                }




                printDocument2.Print();

            }
        }

        private void txtevento_TextChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
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
                    FrmLogin.CantRegImp = d.CantRegImp(txtidrival);
                }

                if (FrmPrincipal.pupitre34 == 1)
                {
                    Evento d = new Evento();
                    FrmLogin.CantRegImp = d.CantRegImp(txtidrival);
                }

                if (FrmPrincipal.pupitre567 == 1)
                {
                    Evento d = new Evento();
                    FrmLogin.CantRegImp = d.CantRegImp(txtidrival);
                }

                if (FrmPrincipal.TV == 1)
                {
                    Evento d = new Evento();
                    FrmLogin.CantRegImp = d.CantRegImp(dgvMovil);
                }




                printDocument3.Print();

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
            int cantidad = 0, cantidad_fija = 0, tipo = 0;
            DateTime mihora = DateTime.Now;
            string lahora = mihora.ToString("yyyy-MM-dd");
            //int credencial = 0;

            new Importar().Traigo_Configuracion_Evento(txtideventos);



       
       
                ////// CABINA ////////



                if (FrmPrincipal.cabina == 1)
                {

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


                            //     Rectangle rect12 = new Rectangle(440, 410, 170, 40);
                            //     e.Graphics.DrawRectangle(Pens.White, rect12);
                            //     e.Graphics.DrawString(Convert.ToString(row.Cells[8].Value).PadLeft(3, '0'), new Font("Arial Black", 14), Brushes.Black, rect12, stringFormat);

                            // QR
                            cadena = Convert.ToString(row.Cells[10].Value) + "#" + Convert.ToString(row.Cells[3].Value) + "*" + Convert.ToString(row.Cells[4].Value).PadLeft(2, '0') + "0000" + "^" + URL.Text;
                            //cadena = URL.Text + " " + Convert.ToString(row.Cells[10].Value);


                            if (imprimiqr.Checked == true)

                            {

                                // Nombre y DNI
                                if (Convert.ToString(row.Cells[6].Value) != "")
                                {
                                    e.Graphics.DrawString(Convert.ToString(row.Cells[6].Value), new Font("Arial Black", 14), Brushes.Black, rect3, stringFormat);
                                    if (Convert.ToString(row.Cells[7].Value) != "")
                                    {
                                        Rectangle rect6 = new Rectangle(320, 260, 290, 60);
                                        e.Graphics.DrawRectangle(Pens.White, rect6);
                                        e.Graphics.DrawString(Convert.ToString(row.Cells[7].Value), new Font("Arial Black", 14), Brushes.Black, rect6, stringFormat);
                                    }
                                    Rectangle rect4 = new Rectangle(330, 290, 290, 40);
                                    e.Graphics.DrawRectangle(Pens.White, rect4);
                                    e.Graphics.DrawString("CABINA Nº " + Convert.ToString(row.Cells[4].Value), new Font("Arial Black", 14), Brushes.Black, rect4, stringFormat);

                                }

                                else
                                {
                                    Rectangle rect4 = new Rectangle(330, 250, 290, 70);
                                    e.Graphics.DrawRectangle(Pens.White, rect4);
                                    e.Graphics.DrawString("CABINA Nº " + Convert.ToString(row.Cells[4].Value), new Font("Arial Black", 14), Brushes.Black, rect4, stringFormat);

                                }

                            }
                            else
                            {

                                // Nombre y DNI
                                Rectangle rect999 = new Rectangle(220, 230, 390, 70);
                                e.Graphics.DrawRectangle(Pens.White, rect999);
                                if (Convert.ToString(row.Cells[6].Value) != "")
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
                            // e.Graphics.DrawRectangle(Pens.Black, rect1);

                            e.Graphics.DrawString("FESTEJO DE" , new Font("Arial Black", 15), Brushes.Black, rect1, stringFormat);

                            Rectangle rect0 = new Rectangle(220, 140, 390, 45);
                            //   e.Graphics.DrawRectangle(Pens.Black, rect0);
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








                            //    Rectangle rect5 = new Rectangle(200, 410, 390, 30);
                            //     e.Graphics.DrawRectangle(Pens.White, rect5);

                            //e.Graphics.DrawString(Convert.ToString(row.Cells[2].Value), new Font("Arial Black", 14), Brushes.Black, rect5, stringFormat);
                            //   float x11111 = 200.0F;
                            //    float y11111 = 352.0F;
                            //    float x22222 = 590.0F;
                            //    float y22222 = 352.0F;
                            //                        e.Graphics.DrawLine(blackPen, x11111, y11111, x22222, y22222);

                            //                      Rectangle rect11 = new Rectangle(200, 220, 390, 230);
                            //                     e.Graphics.DrawRectangle(Pens.Black, rect11);









                            if (imprimiqr.Checked == true)

                            {
                                // CODIGO QR

                                QrCode qrCode = new QrCode();
                                qrEncoder.TryEncode(cadena, out qrCode);
                                GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.Black, Brushes.White);
                                MemoryStream ms = new MemoryStream();
                                renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
                                var imageTemporal = new Bitmap(ms);
                                var imagen = new Bitmap(imageTemporal, new Size(new Point(100, 100)));
                                panelResultado.BackgroundImage = imagen;

                                //     e.Graphics.DrawImage(panelResultado.BackgroundImage, 220, 470, 100, 100);
                                e.Graphics.DrawImage(panelResultado.BackgroundImage, 230, 190, 100, 100);

                            }









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






                }


                //// PUPITRE ///////

                if (FrmPrincipal.pupitre == 1 | FrmPrincipal.pupitre34 == 1 | FrmPrincipal.pupitre567 == 1)

                {

                    foreach (DataGridViewRow row in txtidrival.Rows)
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
                            //Rectangle rect12 = new Rectangle(440, 410, 170, 40);
                            // e.Graphics.DrawRectangle(Pens.White, rect12);
                            // e.Graphics.DrawString(Convert.ToString(row.Cells[9].Value).PadLeft(3, '0'), new Font("Arial Black", 14), Brushes.Black, rect12, stringFormat);

                            // QR
                            cadena = Convert.ToString(row.Cells[11].Value) + "#" + Convert.ToString(row.Cells[3].Value) + "*" + "00" + Convert.ToString(row.Cells[4].Value).PadLeft(2, '0') + Convert.ToString(row.Cells[5].Value).PadLeft(2, '0') + "^" + URL.Text;
                            //cadena = URL.Text + " " + Convert.ToString(row.Cells[10].Value);



                            if (imprimiqr.Checked == true)

                            {

                                // Nombre y DNI
                                if (Convert.ToString(row.Cells[7].Value) != "")
                                {
                                    e.Graphics.DrawString(Convert.ToString(row.Cells[7].Value), new Font("Arial Black", 14), Brushes.Black, rect3, stringFormat);
                                    if (Convert.ToString(row.Cells[8].Value) != "")
                                    {
                                        Rectangle rect6 = new Rectangle(320, 250, 290, 70);
                                        e.Graphics.DrawRectangle(Pens.White, rect6);
                                        e.Graphics.DrawString(Convert.ToString(row.Cells[8].Value), new Font("Arial Black", 14), Brushes.Black, rect6, stringFormat);
                                    }
                                    Rectangle rect4 = new Rectangle(320, 270, 290, 70);
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
                                if (Convert.ToString(row.Cells[7].Value) != "")
                                {
                                    e.Graphics.DrawString(Convert.ToString(row.Cells[7].Value), new Font("Arial Black", 14), Brushes.Black, rect999, stringFormat);
                                    if (Convert.ToString(row.Cells[8].Value) != "")
                                    {
                                        Rectangle rect6 = new Rectangle(220, 250, 390, 70);
                                        e.Graphics.DrawRectangle(Pens.White, rect6);
                                        e.Graphics.DrawString(Convert.ToString(row.Cells[8].Value), new Font("Arial Black", 14), Brushes.Black, rect6, stringFormat);
                                    }
                                    Rectangle rect4 = new Rectangle(220, 270, 390, 70);
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
                            // e.Graphics.DrawRectangle(Pens.Black, rect1);

                            e.Graphics.DrawString("FESTEJO DE", new Font("Arial Black", 15), Brushes.Black, rect1, stringFormat);

                            Rectangle rect0 = new Rectangle(220, 140, 390, 45);
                            //   e.Graphics.DrawRectangle(Pens.Black, rect0);
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




                            // Rectangle rect5 = new Rectangle(200, 410, 390, 30);
                            // e.Graphics.DrawRectangle(Pens.White, rect5);

                            //e.Graphics.DrawString(Convert.ToString(row.Cells[2].Value), new Font("Arial Black", 14), Brushes.Black, rect5, stringFormat);
                            // float x11111 = 200.0F;
                            //  float y11111 = 352.0F;
                            //  float x22222 = 590.0F;
                            //  float y22222 = 352.0F;
                            //  e.Graphics.DrawLine(blackPen, x11111, y11111, x22222, y22222);


                            //   Rectangle rect11 = new Rectangle(200, 220, 390, 230);
                            //   e.Graphics.DrawRectangle(Pens.Black, rect11);

                            //  Rectangle rect12 = new Rectangle(200, 180, 390, 140);
                            //  e.Graphics.DrawRectangle(Pens.Black, rect12);




                            if (imprimiqr.Checked == true)

                            {
                                // CODIGO QR

                                QrCode qrCode = new QrCode();
                                qrEncoder.TryEncode(cadena, out qrCode);
                                GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.Black, Brushes.White);
                                MemoryStream ms = new MemoryStream();
                                renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
                                var imageTemporal = new Bitmap(ms);
                                var imagen = new Bitmap(imageTemporal, new Size(new Point(100, 100)));
                                panelResultado.BackgroundImage = imagen;

                                e.Graphics.DrawImage(panelResultado.BackgroundImage, 230, 190, 100, 100);
                                //e.Graphics.DrawImage(panelResultado.BackgroundImage, 220, 470, 100, 100);

                            }



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

                }

                //// MOVIL ///////

                if (FrmPrincipal.movil == 1)

                {



                    foreach (DataGridViewRow row in dgvMovil.Rows)
                    {

                        if (Convert.ToBoolean(row.Cells[0].Value) == true)


                        {

                            tipo = 3;
                            row.Cells[4].Value = Convert.ToString(Convert.ToInt32(row.Cells[4].Value) - 1);
                            cantidad = Convert.ToInt32(row.Cells[4].Value);
                            cantidad_fija = cantidad + 1;
                            Rectangle rect3 = new Rectangle(320, 210, 290, 70);
                            e.Graphics.DrawRectangle(Pens.White, rect3);

                            //credencial


                            //Rectangle rect12 = new Rectangle(440, 410, 170, 40);
                            // e.Graphics.DrawRectangle(Pens.White, rect12);
                            // e.Graphics.DrawString(Convert.ToString(row.Cells[7].Value).PadLeft(3, '0'), new Font("Arial Black", 14), Brushes.Black, rect12, stringFormat);



                            // QR
                            cadena = Convert.ToString(row.Cells[9].Value) + "#" + Convert.ToString(row.Cells[3].Value) + "*" + "000000" + "^" + URL.Text;
                            // cadena = URL.Text + " " + Convert.ToString(row.Cells[10].Value);

                            // Nombre y DNI


                            if (imprimiqr.Checked == true)

                            {


                                if (Convert.ToString(row.Cells[5].Value) != "")
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

                                    Rectangle rect4 = new Rectangle(320, 250, 290, 40);
                                    e.Graphics.DrawRectangle(Pens.White, rect4);
                                    e.Graphics.DrawString("MOVIL", new Font("Arial Black", 17), Brushes.Black, rect4, stringFormat);
                                    Rectangle rect99 = new Rectangle(320, 290, 290, 40);
                                    e.Graphics.DrawRectangle(Pens.White, rect99);
                                    e.Graphics.DrawString("ACCESO A DESIGNAR", new Font("Arial Black", 15), Brushes.Black, rect99, stringFormat);

                                }


                            }
                            else
                            {
                                Rectangle rect999 = new Rectangle(220, 230, 390, 70);
                                e.Graphics.DrawRectangle(Pens.White, rect999);
                                if (Convert.ToString(row.Cells[5].Value) != "")
                                {
                                    e.Graphics.DrawString(Convert.ToString(row.Cells[5].Value), new Font("Arial Black", 14), Brushes.Black, rect999, stringFormat);
                                    if (Convert.ToString(row.Cells[6].Value) != "")
                                    {
                                        Rectangle rect6 = new Rectangle(220, 250, 390, 70);
                                        e.Graphics.DrawRectangle(Pens.White, rect6);
                                        e.Graphics.DrawString(Convert.ToString(row.Cells[6].Value), new Font("Arial Black", 14), Brushes.Black, rect6, stringFormat);
                                    }
                                    Rectangle rect4 = new Rectangle(200, 270, 390, 40);
                                    e.Graphics.DrawRectangle(Pens.White, rect4);
                                    e.Graphics.DrawString("MOVIL", new Font("Arial Black", 17), Brushes.Black, rect4, stringFormat);
                                    Rectangle rect99 = new Rectangle(200, 290, 390, 40);
                                    e.Graphics.DrawRectangle(Pens.White, rect99);
                                    e.Graphics.DrawString("ACCESO A DESIGNAR", new Font("Arial Black", 15), Brushes.Black, rect99, stringFormat);


                                }
                                else
                                {

                                    Rectangle rect4 = new Rectangle(220, 250, 390, 40);
                                    e.Graphics.DrawRectangle(Pens.White, rect4);
                                    e.Graphics.DrawString("MOVIL", new Font("Arial Black", 17), Brushes.Black, rect4, stringFormat);
                                    Rectangle rect99 = new Rectangle(220, 290, 390, 40);
                                    e.Graphics.DrawRectangle(Pens.White, rect99);
                                    e.Graphics.DrawString("ACCESO A DESIGNAR", new Font("Arial Black", 15), Brushes.Black, rect99, stringFormat);

                                }

                            }



                            Rectangle rect1 = new Rectangle(220, 90, 390, 45);
                            // e.Graphics.DrawRectangle(Pens.Black, rect1);

                            e.Graphics.DrawString("FESTEJO DE", new Font("Arial Black", 15), Brushes.Black, rect1, stringFormat);

                            Rectangle rect0 = new Rectangle(220, 140, 390, 45);
                            //   e.Graphics.DrawRectangle(Pens.Black, rect0);
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



                            //Rectangle rect5 = new Rectangle(200, 420, 390, 30);
                            // e.Graphics.DrawRectangle(Pens.White, rect5);

                            //e.Graphics.DrawString(Convert.ToString(row.Cells[2].Value), new Font("Arial Black", 14), Brushes.Black, rect5, stringFormat);
                            // float x11111 = 200.0F;
                            //  float y11111 = 352.0F;
                            //  float x22222 = 590.0F;
                            //  float y22222 = 352.0F;
                            //  e.Graphics.DrawLine(blackPen, x11111, y11111, x22222, y22222);


                            // Rectangle rect11 = new Rectangle(200, 220, 390, 230);
                            // e.Graphics.DrawRectangle(Pens.Black, rect11);

                            //  Rectangle rect12 = new Rectangle(200, 180, 390, 140);
                            //  e.Graphics.DrawRectangle(Pens.Black, rect12);




                            if (imprimiqr.Checked == true)

                            {
                                // CODIGO QR

                                QrCode qrCode = new QrCode();
                                qrEncoder.TryEncode(cadena, out qrCode);
                                GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.Black, Brushes.White);
                                MemoryStream ms = new MemoryStream();
                                renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
                                var imageTemporal = new Bitmap(ms);
                                var imagen = new Bitmap(imageTemporal, new Size(new Point(100, 100)));
                                panelResultado.BackgroundImage = imagen;

                                e.Graphics.DrawImage(panelResultado.BackgroundImage, 220, 190, 100, 100);
                                //e.Graphics.DrawImage(panelResultado.BackgroundImage, 220, 470, 100, 100);

                            }




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

                }


                //// TV ///////

                if (FrmPrincipal.TV == 1)

                {


                    foreach (DataGridViewRow row in dgvMovil.Rows)
                    {

                        if (Convert.ToBoolean(row.Cells[0].Value) == true)

                        {




                            tipo = 4;
                            row.Cells[4].Value = Convert.ToString(Convert.ToInt32(row.Cells[4].Value) - 1);
                            cantidad = Convert.ToInt32(row.Cells[4].Value);
                            cantidad_fija = cantidad + 1;
                            Rectangle rect3 = new Rectangle(320, 230, 290, 70);
                            e.Graphics.DrawRectangle(Pens.White, rect3);

                            //credencial


                            //Rectangle rect12 = new Rectangle(440, 410, 170, 40);
                            // e.Graphics.DrawRectangle(Pens.White, rect12);
                            // e.Graphics.DrawString(Convert.ToString(row.Cells[7].Value).PadLeft(3, '0'), new Font("Arial Black", 14), Brushes.Black, rect12, stringFormat);



                            // QR
                            cadena = Convert.ToString(row.Cells[9].Value) + "#" + Convert.ToString(row.Cells[3].Value) + "*" + "000000" + "^" + URL.Text;
                            //cadena = URL.Text + " " + Convert.ToString(row.Cells[10].Value);


                            // Nombre y DNI
                            if (imprimiqr.Checked == true)

                            {


                                if (Convert.ToString(row.Cells[5].Value) != "")
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

                                    Rectangle rect4 = new Rectangle(320, 250, 290, 40);
                                    e.Graphics.DrawRectangle(Pens.White, rect4);
                                    e.Graphics.DrawString("MOVIL", new Font("Arial Black", 17), Brushes.Black, rect4, stringFormat);
                                    Rectangle rect99 = new Rectangle(320, 290, 290, 40);
                                    e.Graphics.DrawRectangle(Pens.White, rect99);
                                    e.Graphics.DrawString("ACCESO A DESIGNAR", new Font("Arial Black", 15), Brushes.Black, rect99, stringFormat);

                                }


                            }
                            else
                            {
                                Rectangle rect999 = new Rectangle(220, 230, 390, 70);
                                e.Graphics.DrawRectangle(Pens.White, rect999);
                                if (Convert.ToString(row.Cells[5].Value) != "")
                                {
                                    e.Graphics.DrawString(Convert.ToString(row.Cells[5].Value), new Font("Arial Black", 14), Brushes.Black, rect999, stringFormat);
                                    if (Convert.ToString(row.Cells[6].Value) != "")
                                    {
                                        Rectangle rect6 = new Rectangle(220, 250, 390, 70);
                                        e.Graphics.DrawRectangle(Pens.White, rect6);
                                        e.Graphics.DrawString(Convert.ToString(row.Cells[6].Value), new Font("Arial Black", 14), Brushes.Black, rect6, stringFormat);
                                    }
                                    Rectangle rect4 = new Rectangle(200, 270, 390, 40);
                                    e.Graphics.DrawRectangle(Pens.White, rect4);
                                    e.Graphics.DrawString("MOVIL", new Font("Arial Black", 17), Brushes.Black, rect4, stringFormat);
                                    Rectangle rect99 = new Rectangle(200, 290, 390, 40);
                                    e.Graphics.DrawRectangle(Pens.White, rect99);
                                    e.Graphics.DrawString("ACCESO A DESIGNAR", new Font("Arial Black", 15), Brushes.Black, rect99, stringFormat);


                                }
                                else
                                {

                                    Rectangle rect4 = new Rectangle(220, 250, 390, 40);
                                    e.Graphics.DrawRectangle(Pens.White, rect4);
                                    e.Graphics.DrawString("MOVIL", new Font("Arial Black", 17), Brushes.Black, rect4, stringFormat);
                                    Rectangle rect99 = new Rectangle(220, 290, 390, 40);
                                    e.Graphics.DrawRectangle(Pens.White, rect99);
                                    e.Graphics.DrawString("ACCESO A DESIGNAR", new Font("Arial Black", 15), Brushes.Black, rect99, stringFormat);

                                }

                            }


                            Rectangle rect1 = new Rectangle(220, 90, 390, 45);
                            // e.Graphics.DrawRectangle(Pens.Black, rect1);

                            e.Graphics.DrawString("FESTEJO DE", new Font("Arial Black", 15), Brushes.Black, rect1, stringFormat);

                            Rectangle rect0 = new Rectangle(220, 140, 390, 45);
                            //   e.Graphics.DrawRectangle(Pens.Black, rect0);
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
                            //e.Graphics.DrawRectangle(Pens.White, rect5);

                            //e.Graphics.DrawString(Convert.ToString(row.Cells[2].Value), new Font("Arial Black", 14), Brushes.Black, rect5, stringFormat);
                            // float x11111 = 200.0F;
                            // float y11111 = 352.0F;
                            // float x22222 = 590.0F;
                            // float y22222 = 352.0F;
                            // e.Graphics.DrawLine(blackPen, x11111, y11111, x22222, y22222);


                            //  Rectangle rect11 = new Rectangle(200, 220, 390, 230);
                            //  e.Graphics.DrawRectangle(Pens.Black, rect11);

                            //  Rectangle rect12 = new Rectangle(200, 180, 390, 140);
                            //  e.Graphics.DrawRectangle(Pens.Black, rect12);




                            if (imprimiqr.Checked == true)

                            {
                                // CODIGO QR

                                QrCode qrCode = new QrCode();
                                qrEncoder.TryEncode(cadena, out qrCode);
                                GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.Black, Brushes.White);
                                MemoryStream ms = new MemoryStream();
                                renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
                                var imageTemporal = new Bitmap(ms);
                                var imagen = new Bitmap(imageTemporal, new Size(new Point(100, 100)));
                                panelResultado.BackgroundImage = imagen;

                                e.Graphics.DrawImage(panelResultado.BackgroundImage, 220, 190, 100, 100);
                                //e.Graphics.DrawImage(panelResultado.BackgroundImage, 220, 470, 100, 100);

                            }



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

                }
                

                MessageBox.Show("Finalizo la Impresion");

            
        }

        private void fecnumero_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_MouseMove(object sender, MouseEventArgs e)
        {
            button5.BackColor = Color.DodgerBlue;
        }

        private void button6_MouseMove(object sender, MouseEventArgs e)
        {
            button6.BackColor = Color.DodgerBlue;
        }

        private void imprimiqr_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dgvMovil_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txturl_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panelResultado_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtfechanumero_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txttorneo_TextChanged(object sender, EventArgs e)
        {

        }

        private void URL_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtidevento_TextChanged(object sender, EventArgs e)
        {

        }

        private void comentario_Enter(object sender, EventArgs e)
        {

        }

        private void idrival_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMedio_TextChanged(object sender, EventArgs e)
        {

        }

        private void estado_evento_Click(object sender, EventArgs e)
        {

        }

        private void lafecha_TextChanged(object sender, EventArgs e)
        {

        }

        private void textIdRival_TextChanged(object sender, EventArgs e)
        {

        }

        private void Id_evento_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void printDocument4_PrintPage(object sender, PrintPageEventArgs e)
        {

        }

        private void dgvCabinas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
