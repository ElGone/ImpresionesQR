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
    public partial class txtreponsable : Form
    {
        public txtreponsable()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void FrmAltaRecorridos_Load(object sender, EventArgs e)
        {
            string criterio = "";
            Recorridos d = new Recorridos();
            criterio = "Select Numero_Serie, Nombre_Tarjeta from tarjetas WHERE Estado=1 Order By Nombre_Tarjeta";
            d.llenarcombotarjetas(cbtarjetas, criterio);
        }

        private void label6_Click(object sender, EventArgs e)
        {
         
        }

        private void dgvrecorridos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Recorridos d = new Recorridos();
            d.cargoengrid(dgvrecorridos, txtnombre.Text, pdesde.Text , numec  , cbtarjetas.SelectedValue.ToString() , cbtarjetas.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Recorridos d = new Recorridos();
            d.altaderecorrido(dgvrecorridos, txtnombre.Text, pdesde.Text, txtResponsable.Text );


        }
    }
}
