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
    public partial class FrmCalibrarImpresion : Form
    {


        public FrmCalibrarImpresion()
        {
            InitializeComponent();


        }

        private void FrmCalibrarImpresion_Load(object sender, EventArgs e)
        {
         
            imprimiqr.Checked = true;
            Id_eventos.Text = "";



        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowColor = true;

            fontDialog1.Font = txtfontcampeonato.Font;
            fontDialog1.Color = txtfontcampeonato.ForeColor;


            if (fontDialog1.ShowDialog() != DialogResult.Cancel)
            {
                txtCampeonato.Font = fontDialog1.Font;
                txtCampeonato.ForeColor = fontDialog1.Color;
                txtfontcampeonato.Text = fontDialog1.Font.Name;
                txtsizecampeonato.Text = Convert.ToString(Math.Truncate(fontDialog1.Font.Size));
                
                if (fontDialog1.Font.Bold==true)
                {
                    negritacampeonato.Checked = true;

                }

                else
                {
                    negritacampeonato.Checked = false;

                }

            }
        }

        private void fontDialog1_Apply(object sender, EventArgs e)
        {
            this.button1.Click += new System.EventHandler(this.button1_Click);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string criterio = "";

            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
            criterio = "Select a.Id_Evento, a.Nombre_Evento, a.Campeonato, a.Fecha, a.url, a.Numero_Fecha, a.Rival, a.Id_Rival, a.Estado, b.Descripcion From eventos AS a INNER JOIN Estados AS b ON a.Estado = b.Estado ORDER BY a.Fecha";
            new Importar().muestro_eventos(dgvEventos, criterio);
            groupBox2.Visible = true;
            System.Windows.Forms.Cursor.Current = Cursors.Default;
        }
        

        private void dgvEventos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtidevento.Text = Convert.ToString(this.dgvEventos.CurrentRow.Cells[3].Value);
            Id_eventos.Text = txtidevento.Text;
            new Evento().Traigo_Datos_Evento(txtCampeonato, txtRival, txtValor, txtFecha, Id_eventos, lafecha, textIdRival, estado_evento);
                                            
           
            button1.Enabled = true;
            new Importar().Traigo_Configuracion_Impresiones(txtfontcampeonato, txtsizecampeonato, txtfontrival, txtsizerival, txtfontmedio, txtsizemedio, txtfontfecha, txtsizefecha, Id_eventos.Text, txtfontubicacion, txtsizeubicacion, negritacampeonato, negritarival, negritafecha, negritamedio, negritaubicacion, txtCampeonato, txtRival, txtCanal, txtFecha, txtUbicacion, txtfontnombre, txtsizenombre, negritanombre, txtnombre);
            groupBox2.Visible = false;
            txtUbicacion.Text = "CABINA Nº 5";
            txtnombre.Text = "Nombre y DNI";

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowColor = true;

            fontDialog1.Font = txtfontrival.Font;
            fontDialog1.Color = txtfontrival.ForeColor;


            if (fontDialog1.ShowDialog() != DialogResult.Cancel)
            {
                txtRival.Font = fontDialog1.Font;
                txtRival.ForeColor = fontDialog1.Color;
                txtfontrival.Text = fontDialog1.Font.Name;
                txtsizerival.Text = Convert.ToString(Math.Truncate(fontDialog1.Font.Size));

            }


            if (fontDialog1.Font.Bold == true)
            {
                negritarival.Checked = true;

            }

            else
            {
                negritarival.Checked = false;

            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowColor = true;

            fontDialog1.Font = txtfontmedio.Font;
            fontDialog1.Color = txtfontmedio.ForeColor;


            if (fontDialog1.ShowDialog() != DialogResult.Cancel)
            {
                txtCanal.Font = fontDialog1.Font;
                txtCanal.ForeColor = fontDialog1.Color;
                txtfontmedio.Text = fontDialog1.Font.Name;
                txtsizemedio.Text = Convert.ToString(Math.Truncate(fontDialog1.Font.Size));
                if (fontDialog1.Font.Bold == true)
                {
                    negritamedio.Checked = true;

                }

                else
                {
                    negritamedio.Checked = false;

                }

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowColor = true;

            fontDialog1.Font = txtfontfecha.Font;
            fontDialog1.Color = txtfontfecha.ForeColor;


            if (fontDialog1.ShowDialog() != DialogResult.Cancel)
            {
                txtFecha.Font = fontDialog1.Font;
                txtFecha.ForeColor = fontDialog1.Color;
                txtfontfecha.Text = fontDialog1.Font.Name;
                txtsizefecha.Text = Convert.ToString(Math.Truncate(fontDialog1.Font.Size));

            }


            if (fontDialog1.Font.Bold == true)
            {
                negritafecha.Checked = true;

            }

            else
            {
                negritafecha.Checked = false;

            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowColor = true;

            fontDialog1.Font = txtfontfecha.Font;
            fontDialog1.Color = txtfontfecha.ForeColor;


            if (fontDialog1.ShowDialog() != DialogResult.Cancel)
            {
                txtUbicacion.Font = fontDialog1.Font;
                txtUbicacion.ForeColor = fontDialog1.Color;
                txtfontubicacion.Text = fontDialog1.Font.Name;
                txtsizeubicacion.Text = Convert.ToString(Math.Truncate(fontDialog1.Font.Size));

            }


            if (fontDialog1.Font.Bold == true)
            {
                negritaubicacion.Checked = true;

            }

            else
            {
                negritaubicacion.Checked = false;

            }

        }

        private void button8_Click(object sender, EventArgs e)
        {

            if (Id_eventos.Text == "")
            {
                MessageBox.Show("Falta Seleccionar un Evento");
                
            }

            else
            {
                if (MessageBox.Show(" Esta seguro que quiere cambiar la configuracion de las impresiones ?", "Imprimir registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    new Importar().Guardo_Configuracion_Impresion(txtfontcampeonato.Text, txtsizecampeonato.Text, txtfontrival.Text, txtsizerival.Text, txtfontmedio.Text, txtsizemedio.Text, txtfontfecha.Text, txtsizefecha.Text, txtRival.Text, Convert.ToInt32(Id_eventos.Text), txtfontubicacion.Text, txtsizeubicacion.Text, negritacampeonato, negritamedio, negritarival, negritafecha, negritaubicacion, txtfontnombre.Text, txtsizenombre.Text, negritanombre);

                }
            }
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
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

            // new Importar().Traigo_Configuracion_Evento(txtideventos);


            // fila 1
            Rectangle rect1 = new Rectangle(190, 87, 410, 45);
            

            /////////// IMPRIMO CAMPEONATO ////////////
            if (FrmLogin.negritacampeonato == 1)
            {
                e.Graphics.DrawString(Convert.ToString(txtCampeonato.Text), new Font(txtfontcampeonato.Text, Convert.ToInt32(txtsizecampeonato.Text), FontStyle.Bold), Brushes.Black, rect1, stringFormat);
            }
            else
            {
                e.Graphics.DrawString(Convert.ToString(txtCampeonato.Text), new Font(txtfontcampeonato.Text, Convert.ToInt32(txtsizecampeonato.Text)), Brushes.Black, rect1, stringFormat);
            }

            /////////// IMPRIMO FECHA ////////////

            Rectangle rect111 = new Rectangle(190, 107, 410, 45);
            if (FrmLogin.negritafecha == 1)
            {
                e.Graphics.DrawString(Convert.ToString(txtFecha.Text), new Font(txtfontfecha.Text, Convert.ToInt32(txtsizefecha.Text), FontStyle.Bold), Brushes.Black, rect111, stringFormat);
            }
            else
            {
                e.Graphics.DrawString(Convert.ToString(txtFecha.Text), new Font(txtfontfecha.Text, Convert.ToInt32(txtsizefecha.Text)), Brushes.Black, rect111, stringFormat);
            }


            Rectangle rect0 = new Rectangle(190, 130, 410, 45);


            /////////// IMPRIMO RIVAL ////////////

            if (FrmLogin.negritarival == 1)
            {
                e.Graphics.DrawString(txtRival.Text, new Font(txtfontrival.Text, Convert.ToInt32(txtsizerival.Text), FontStyle.Bold), Brushes.Black, rect0, stringFormat);
            }
            else
            {
                e.Graphics.DrawString(txtRival.Text, new Font(txtfontrival.Text, Convert.ToInt32(txtsizerival.Text)), Brushes.Black, rect0, stringFormat);

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
                    e.Graphics.DrawString(substring, new Font(txtfontmedio.Text, Convert.ToInt32(txtsizemedio.Text), FontStyle.Bold), Brushes.Black, rect2, stringFormat);
                }
                else
                {
                    e.Graphics.DrawString(substring, new Font(txtfontmedio.Text, Convert.ToInt32(txtsizemedio.Text)), Brushes.Black, rect2, stringFormat);

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
                e.Graphics.DrawString("CABINA DE PRENSA", new Font(txtfontubicacion.Text, Convert.ToInt32(txtsizeubicacion.Text) , FontStyle.Bold), Brushes.Black, rect22, stringFormat);
            }
            else
            {
                e.Graphics.DrawString("CABINA DE PRENSA", new Font(txtfontubicacion.Text, Convert.ToInt32(txtsizeubicacion.Text)), Brushes.Black, rect22, stringFormat);
            }


            Rectangle rect4 = new Rectangle(190, 290, 390, 60);
            e.Graphics.DrawRectangle(Pens.White, rect4);

            if (FrmLogin.negritaubicacion == 1)
            {
                e.Graphics.DrawString(txtUbicacion.Text, new Font(txtfontubicacion.Text, Convert.ToInt32(txtsizeubicacion.Text), FontStyle.Bold), Brushes.Black, rect4, stringFormat);
            }
            else
            {

                e.Graphics.DrawString(txtUbicacion.Text, new Font(txtfontubicacion.Text, Convert.ToInt32(txtsizeubicacion.Text)), Brushes.Black, rect4, stringFormat);

            }



            if (txtnombre.Text != "")
            {
                Rectangle rect23 = new Rectangle(170, 340, 420, 60);
                e.Graphics.DrawRectangle(Pens.White, rect23);
                if (FrmLogin.negritanombre == 1)
                {
                    e.Graphics.DrawString(txtnombre.Text, new Font(txtfontnombre.Text, Convert.ToInt32(txtsizenombre.Text), FontStyle.Bold), Brushes.Black, rect23, stringFormat);
                }
                else
                {
                    e.Graphics.DrawString(txtnombre.Text, new Font(txtfontnombre.Text, Convert.ToInt32(txtsizenombre.Text)), Brushes.Black, rect23, stringFormat);

                }
                

            }

            //credencial


            Rectangle rect12 = new Rectangle(370, 420, 390, 40);
            e.Graphics.DrawRectangle(Pens.White, rect12);
            e.Graphics.DrawString("Nº 555" , new Font("Arial Black", 14), Brushes.Black, rect12, stringFormat);

            
            // QR


            if (imprimiqr.Checked == true)
            {
              
                cadena = "#" + Convert.ToString(txtCanal.Text) + "*" + Convert.ToString(txtnombre.Text).PadLeft(2, '0') + "0000" + "^" + txtValor.Text;
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
            e.Graphics.DrawString("A-B-C-D", new Font("Arial", 32), Brushes.Black, rect29, stringFormat);

            


            MessageBox.Show("Finalizo la Impresion");


        }

        private void button10_Click(object sender, EventArgs e)
        {
            string criterio;
            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
            criterio = "Select Id_Equipo, Nombre_Equipo, Escudo From equipos Order By Nombre_Equipo";
            
            
            System.Windows.Forms.Cursor.Current = Cursors.Default;
        }

        private void dgvrivales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void txtsizerival_TextChanged(object sender, EventArgs e)
        {

        }

        private void imprimiqr_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
          

        }

        private void button14_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            fontDialog1.ShowColor = true;

            fontDialog1.Font = txtfontcampeonato.Font;
            fontDialog1.Color = txtfontcampeonato.ForeColor;


            if (fontDialog1.ShowDialog() != DialogResult.Cancel)
            {
                txtnombre.Font = fontDialog1.Font;
                txtnombre.ForeColor = fontDialog1.Color;
                txtfontnombre.Text = fontDialog1.Font.Name;
                txtsizenombre.Text = Convert.ToString(Math.Truncate(fontDialog1.Font.Size));

                if (fontDialog1.Font.Bold == true)
                {
                    negritanombre.Checked = true;

                }

                else
                {
                    negritanombre.Checked = false;

                }

            }
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void button10_Click_2(object sender, EventArgs e)
        {
            fontDialog1.ShowColor = true;

            fontDialog1.Font = txtfontnombre.Font;
            fontDialog1.Color = txtfontnombre.ForeColor;


            if (fontDialog1.ShowDialog() != DialogResult.Cancel)
            {
                txtnombre.Font = fontDialog1.Font;
                txtnombre.ForeColor = fontDialog1.Color;
                txtfontnombre.Text = fontDialog1.Font.Name;
                txtsizenombre.Text = Convert.ToString(Math.Truncate(fontDialog1.Font.Size));

            }


            if (fontDialog1.Font.Bold == true)
            {
                negritanombre.Checked = true;

            }

            else
            {
                negritanombre.Checked = false;

            }

        }

        private void button14_Click_1(object sender, EventArgs e)
        {
            groupBox2.Visible = false;

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}








        