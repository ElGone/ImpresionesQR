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
    public partial class FrmModificoRecorridos : Form
    {

        MySqlCommand cmd;
        MySqlConnection conectar;
        MySqlDataReader dr;


        string elrecorrido, nombrerecorrido;
        public FrmModificoRecorridos(string recorrido, string nombre_recorrido, string lafecha)
        {
            InitializeComponent();
            elrecorrido = recorrido;
            nombrerecorrido = nombre_recorrido;
            mirecorrido.Text = nombrerecorrido;   
            Recorridos d = new Recorridos();
            d.modifico_recorrido(dgvrecorridos, elrecorrido, responsable );
            fecha1.Text  = lafecha;


        }

        private void FrmModificoRecorridos_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmAltaParadaCorreccion frm = new FrmAltaParadaCorreccion(elrecorrido, fecha1.Text );
            frm.ShowDialog();
            this.Show();
            Recorridos d = new Recorridos();
            d.modifico_recorrido(dgvrecorridos, elrecorrido, responsable );
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void dgvrecorridos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(" Esta seguro que quiere imprimir los registros seleccionado ?", "Imprimir registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                PrinterSettings settings = new PrinterSettings();
                PaperSize paperSize = new PaperSize("A4", 210, 297);
                printDocument1.PrinterSettings.DefaultPageSettings.PaperSize = paperSize;
                           

                printDocument1.Print();
                //printPreviewDialog1.Document = printDocument1;
                //printPreviewDialog1.ShowDialog();



            }
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Pen blackPen = new Pen(Color.Black, 3);
            Font drawFontBold = new Font("Candara", 11, FontStyle.Bold);
                          
          
            DateTime mihora = DateTime.Now;
            string lahora = mihora.ToString("yyyy-MM-dd");
            int  fila= 110;

            e.Graphics.DrawString(lahora, new Font("Candara", 20), Brushes.Black, 570, 40);
            e.Graphics.DrawImage(pictureBox2.Image, 20, 20, 113, 103);
            e.Graphics.DrawString("Listado de Recorridos", new Font("Candara", 25), Brushes.Black, 250, fila);

            fila = fila + 60;
           
            
            e.Graphics.DrawString("Tarjeta / Tag", new Font("Candara", 12), Brushes.Black, 50, fila);
            e.Graphics.DrawString("Nº de Serie", new Font("Candara", 12), Brushes.Black, 290, fila);
            e.Graphics.DrawString("Orden", new Font("Candara", 12), Brushes.Black, 410, fila);
            e.Graphics.DrawString("Fecha y Hora", new Font("Candara", 12), Brushes.Black, 500, fila);

            fila = fila + 20;
            Pen myPen = new Pen(Color.Black);
            myPen.Width = 2;
            e.Graphics.DrawLine(myPen, 30, 191, 800, 191);
            fila = fila + 15;

             foreach (DataGridViewRow row in dgvrecorridos.Rows)
                {
                e.Graphics.DrawString(Convert.ToString(row.Cells[1].Value), new Font("Candara", 10), Brushes.Black, 50, fila);
                e.Graphics.DrawString(Convert.ToString(row.Cells[2].Value), new Font("Candara", 10), Brushes.Black, 300, fila);
                e.Graphics.DrawString(Convert.ToString(row.Cells[3].Value), new Font("Candara", 10), Brushes.Black, 430, fila);
                e.Graphics.DrawString(Convert.ToString(row.Cells[4].Value), new Font("Candara", 10), Brushes.Black, 500, fila);

                fila =fila + 20;


                 }


        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(" Esta seguro que quiere eliminar la Parada del Recorrido seleccionado ?", "eliminar Recorrido", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dgvrecorridos.Rows)
                {

                    if (Convert.ToBoolean(row.Cells[0].Value) == true)

                    {
                        Recorridos d = new Recorridos();
                        d.elimino_parada_recorrido(Convert.ToString(row.Cells[5].Value), Convert.ToString(row.Cells[3].Value));
                        dgvrecorridos.Rows.Clear();
                        d.modifico_recorrido(dgvrecorridos, elrecorrido, responsable);

                    }
                }
            }
        }
    }
}
