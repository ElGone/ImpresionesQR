using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using System.Drawing.Imaging;

using System.IO;


namespace ImpresionQR
{
    public partial class FrmDatosLugar : Form
    {
        public FrmDatosLugar(string boton, string fdesde, int tipo, string url)
        {
            

            InitializeComponent();

          
           
            Evento d = new Evento();
            d.Traigo_Datos_Lugar(boton, fdesde, tipo, txtevento, txttorneo, txtmedio, txtnombre, txtdni, txttipo, txtcabina, txtasiento, txtfila, url, dgvLecturas);

        }

        private void panelResultado_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmDatosLugar_Load(object sender, EventArgs e)
        {
                  

          

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
