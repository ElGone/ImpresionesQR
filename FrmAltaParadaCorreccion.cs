using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImpresionQR
{
    public partial class FrmAltaParadaCorreccion : Form
    {
        string mirecorrido, lafecha;
        public FrmAltaParadaCorreccion(string recorrido, string fecha)
        {
            InitializeComponent();
            mirecorrido = recorrido;
            lafecha = fecha;
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void FrmAltaParadaCorreccion_Load(object sender, EventArgs e)
        {
            string criterio = "";
            Recorridos d = new Recorridos();
            criterio = "Select Numero_Serie, Nombre_Tarjeta from tarjetas Where Estado=1 Order By Nombre_Tarjeta";
            d.llenarcombotarjetas(cbtarjetas, criterio);
        }

        private void hora_ValueChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void numec_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void cbtarjetas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Recorridos d = new Recorridos();
            d.altadeparadacorreccion(cbtarjetas.Text , mirecorrido, numec, lafecha, hora.Text  );
        }
    }
}
