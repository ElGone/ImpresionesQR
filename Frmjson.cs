using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using MySql.Data.MySqlClient;

namespace ImpresionQR
{
    public partial class Frmjson : Form
    {


        MySqlCommand cmd;
        MySqlConnection conectar;
        MySqlDataReader dr;

        public Frmjson()
        {
            InitializeComponent();
        }

        private void Frmjson_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;

            FrmLogin.total_cabinas_impresas = 0;
            FrmLogin.total_pupitres_impresos = 0;
            FrmLogin.totimpresiones = 0;
            FrmLogin.total_cabinas_faltantes = 0;
            FrmLogin.total_cabinas_entrantes = 0;
            FrmLogin.total_pupitres_faltantes = 0;
            FrmLogin.total_pupitres_entrantes = 0;

    }

        private void button1_Click(object sender, EventArgs e)
        {
                      
        }
        
        private void button2_Click(object sender, EventArgs e)
        {

            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F7A28.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F7A28", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
                  

            
        }

        private void pdesde_ValueChanged(object sender, EventArgs e)
        {
            

        }

        private void F7A27_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F7A27.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F7A27", fdesde, 1, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void button41_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);
            if (F4A46.BackColor != Color.White)
            {

                FrmDatosLugar frm = new FrmDatosLugar("F4A46", fdesde, 2, URL.Text); frm.ShowDialog();
                this.Show();
            }
        }

        private void F7A26_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F7A26.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F7A26", fdesde, 1, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void button267_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);
            if (F1A30.BackColor != Color.White)
            {

                FrmDatosLugar frm = new FrmDatosLugar("F1A30", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void fecnumero_TextChanged(object sender, EventArgs e)
        {

        }

        private void button37_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F5A18.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F5A18", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F6A21_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);
            if (F7A22.BackColor != Color.White)
            {

                FrmDatosLugar frm = new FrmDatosLugar("F6A22", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int cont = 0;
            string Id_impresion = "";
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);


            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
            FrmLogin.total_cabinas_faltantes = 0;
            FrmLogin.total_cabinas_entrantes = 0;
            FrmLogin.total_pupitres_faltantes = 0;
            FrmLogin.total_pupitres_entrantes = 0;


            Evento d = new Evento();
            d.Limpio_Rojo(F7A28, fdesde,2);
            d.Limpio_Rojo(F7A27, fdesde,2);
            d.Limpio_Rojo(F7A26, fdesde,2);
            d.Limpio_Rojo(F7A25, fdesde,2);
            d.Limpio_Rojo(F7A24, fdesde,2);
            d.Limpio_Rojo(F7A23, fdesde,2);
            d.Limpio_Rojo(F7A22, fdesde,2);
            d.Limpio_Rojo(F7A21, fdesde,2);
            d.Limpio_Rojo(F7A20, fdesde,2);
            d.Limpio_Rojo(F7A19, fdesde,2);
            d.Limpio_Rojo(F7A18, fdesde,2);
            d.Limpio_Rojo(F7A17, fdesde,2);
            d.Limpio_Rojo(F7A16, fdesde,2);
            d.Limpio_Rojo(F7A15, fdesde,2);
            d.Limpio_Rojo(F7A14, fdesde,2);
            d.Limpio_Rojo(F7A13, fdesde,2);
            d.Limpio_Rojo(F7A12, fdesde,2);
            d.Limpio_Rojo(F7A11, fdesde,2);
            d.Limpio_Rojo(F7A10, fdesde,2);
            d.Limpio_Rojo(F7A09, fdesde,2);
            d.Limpio_Rojo(F7A08, fdesde,2);
            d.Limpio_Rojo(F7A07, fdesde,2);
            d.Limpio_Rojo(F7A06, fdesde,2);
            d.Limpio_Rojo(F7A05, fdesde,2);
            d.Limpio_Rojo(F7A04, fdesde,2);
            d.Limpio_Rojo(F7A03, fdesde,2);
            d.Limpio_Rojo(F7A02, fdesde,2);
            d.Limpio_Rojo(F7A01, fdesde,2);
            d.Limpio_Rojo(F7A28, fdesde,2);
            d.Limpio_Rojo(F7A27, fdesde,2);
            d.Limpio_Rojo(F7A26, fdesde,2);
            d.Limpio_Rojo(F7A25, fdesde,2);
            d.Limpio_Rojo(F7A24, fdesde,2);
            d.Limpio_Rojo(F7A23, fdesde,2);
            d.Limpio_Rojo(F7A22, fdesde,2);
            d.Limpio_Rojo(F7A21, fdesde,2);
            d.Limpio_Rojo(F7A20, fdesde,2);
            d.Limpio_Rojo(F7A19, fdesde,2);
            d.Limpio_Rojo(F7A18, fdesde,2);
            d.Limpio_Rojo(F7A17, fdesde,2);
            d.Limpio_Rojo(F7A16, fdesde,2);
            d.Limpio_Rojo(F7A15, fdesde,2);
            d.Limpio_Rojo(F7A14, fdesde,2);
            d.Limpio_Rojo(F7A13, fdesde,2);
            d.Limpio_Rojo(F7A12, fdesde,2);
            d.Limpio_Rojo(F7A11, fdesde,2);
            d.Limpio_Rojo(F7A10, fdesde,2);
            d.Limpio_Rojo(F7A09, fdesde,2);
            d.Limpio_Rojo(F7A08, fdesde,2);
            d.Limpio_Rojo(F7A07, fdesde,2);
            d.Limpio_Rojo(F7A06, fdesde,2);
            d.Limpio_Rojo(F7A05, fdesde,2);
            d.Limpio_Rojo(F7A04, fdesde,2);
            d.Limpio_Rojo(F7A03, fdesde,2);
            d.Limpio_Rojo(F7A02, fdesde,2);
            d.Limpio_Rojo(F7A01, fdesde,2);
            d.Limpio_Rojo(F6A24, fdesde,2);
            d.Limpio_Rojo(F6A23, fdesde,2);
            d.Limpio_Rojo(F6A22, fdesde,2);
            d.Limpio_Rojo(F6A22, fdesde,2);
            d.Limpio_Rojo(F6A20, fdesde,2);
            d.Limpio_Rojo(F6A19, fdesde,2);
            d.Limpio_Rojo(F6A18, fdesde,2);
            d.Limpio_Rojo(F6A17, fdesde,2);
            d.Limpio_Rojo(F6A16, fdesde,2);
            d.Limpio_Rojo(F6A15, fdesde,2);
            d.Limpio_Rojo(F6A14, fdesde,2);
            d.Limpio_Rojo(F6A13, fdesde,2);
            d.Limpio_Rojo(F6A12, fdesde,2);
            d.Limpio_Rojo(F6A11, fdesde,2);
            d.Limpio_Rojo(F6A10, fdesde,2);
            d.Limpio_Rojo(F6A09, fdesde,2);
            d.Limpio_Rojo(F6A08, fdesde,2);
            d.Limpio_Rojo(F6A07, fdesde,2);
            d.Limpio_Rojo(F6A06, fdesde,2);
            d.Limpio_Rojo(F6A05, fdesde,2);
            d.Limpio_Rojo(F6A04, fdesde,2);
            d.Limpio_Rojo(F6A03, fdesde,2);
            d.Limpio_Rojo(F6A02, fdesde,2);
            d.Limpio_Rojo(F6A01, fdesde,2);
            d.Limpio_Rojo(F5A18, fdesde,2);
            d.Limpio_Rojo(F5A17, fdesde,2);
            d.Limpio_Rojo(F5A16, fdesde,2);
            d.Limpio_Rojo(F5A15, fdesde,2);
            d.Limpio_Rojo(F5A14, fdesde,2);
            d.Limpio_Rojo(F5A13, fdesde,2);
            d.Limpio_Rojo(F5A12, fdesde,2);
            d.Limpio_Rojo(F5A11, fdesde,2);
            d.Limpio_Rojo(F5A10, fdesde,2);
            d.Limpio_Rojo(F5A09, fdesde,2);
            d.Limpio_Rojo(F5A08, fdesde,2);
            d.Limpio_Rojo(F5A07, fdesde,2);
            d.Limpio_Rojo(F5A06, fdesde,2);
            d.Limpio_Rojo(F5A05, fdesde,2);
            d.Limpio_Rojo(F5A04, fdesde,2);
            d.Limpio_Rojo(F5A03, fdesde,2);
            d.Limpio_Rojo(F5A02, fdesde,2);
            d.Limpio_Rojo(F5A01, fdesde,2);
            d.Limpio_Rojo(F4A53, fdesde,2);
            d.Limpio_Rojo(F4A52, fdesde,2);
            d.Limpio_Rojo(F4A51, fdesde,2);
            d.Limpio_Rojo(F4A50, fdesde,2);
            d.Limpio_Rojo(F4A49, fdesde,2);
            d.Limpio_Rojo(F4A48, fdesde,2);
            d.Limpio_Rojo(F4A47, fdesde,2);
            d.Limpio_Rojo(F4A46, fdesde,2);
            d.Limpio_Rojo(F4A45, fdesde,2);
            d.Limpio_Rojo(F4A44, fdesde,2);
            d.Limpio_Rojo(F4A43, fdesde,2);
            d.Limpio_Rojo(F4A42, fdesde,2);
            d.Limpio_Rojo(F4A41, fdesde,2);
            d.Limpio_Rojo(F4A40, fdesde,2);
            d.Limpio_Rojo(F4A39, fdesde,2);
            d.Limpio_Rojo(F4A38, fdesde,2);
            d.Limpio_Rojo(F4A37, fdesde,2);
            d.Limpio_Rojo(F4A36, fdesde,2);
            d.Limpio_Rojo(F4A35, fdesde,2);
            d.Limpio_Rojo(F4A34, fdesde,2);
            d.Limpio_Rojo(F4A33, fdesde,2);
            d.Limpio_Rojo(F4A32, fdesde,2);
            d.Limpio_Rojo(F4A31, fdesde,2);
            d.Limpio_Rojo(F4A30, fdesde,2);
            d.Limpio_Rojo(F4A29, fdesde,2);
            d.Limpio_Rojo(F4A28, fdesde,2);
            d.Limpio_Rojo(F4A27, fdesde,2);
            d.Limpio_Rojo(F4A26, fdesde,2);
            d.Limpio_Rojo(F4A25, fdesde,2);
            d.Limpio_Rojo(F4A24, fdesde,2);
            d.Limpio_Rojo(F4A23, fdesde,2);
            d.Limpio_Rojo(F4A22, fdesde,2);
            d.Limpio_Rojo(F4A21, fdesde,2);
            d.Limpio_Rojo(F4A20, fdesde,2);
            d.Limpio_Rojo(F4A19, fdesde,2);
            d.Limpio_Rojo(F4A18, fdesde,2);
            d.Limpio_Rojo(F4A17, fdesde,2);
            d.Limpio_Rojo(F4A16, fdesde,2);
            d.Limpio_Rojo(F4A15, fdesde,2);
            d.Limpio_Rojo(F4A14, fdesde,2);
            d.Limpio_Rojo(F4A13, fdesde,2);
            d.Limpio_Rojo(F4A12, fdesde,2);
            d.Limpio_Rojo(F4A11, fdesde,2);
            d.Limpio_Rojo(F4A10, fdesde,2);
            d.Limpio_Rojo(F4A09, fdesde,2);
            d.Limpio_Rojo(F4A08, fdesde,2);
            d.Limpio_Rojo(F4A07, fdesde,2);
            d.Limpio_Rojo(F4A06, fdesde,2);
            d.Limpio_Rojo(F4A05, fdesde,2);
            d.Limpio_Rojo(F4A04, fdesde,2);
            d.Limpio_Rojo(F4A03, fdesde,2);
            d.Limpio_Rojo(F4A02, fdesde,2);
            d.Limpio_Rojo(F4A01, fdesde,2);
            d.Limpio_Rojo(F3A52, fdesde,2);
            d.Limpio_Rojo(F3A51, fdesde,2);
            d.Limpio_Rojo(F3A50, fdesde,2);
            d.Limpio_Rojo(F3A49, fdesde,2);
            d.Limpio_Rojo(F3A48, fdesde,2);
            d.Limpio_Rojo(F3A47, fdesde,2);
            d.Limpio_Rojo(F3A46, fdesde,2);
            d.Limpio_Rojo(F3A45, fdesde,2);
            d.Limpio_Rojo(F3A44, fdesde,2);
            d.Limpio_Rojo(F3A43, fdesde,2);
            d.Limpio_Rojo(F3A42, fdesde,2);
            d.Limpio_Rojo(F3A41, fdesde,2);
            d.Limpio_Rojo(F3A40, fdesde,2);
            d.Limpio_Rojo(F3A39, fdesde,2);
            d.Limpio_Rojo(F3A38, fdesde,2);
            d.Limpio_Rojo(F3A37, fdesde,2);
            d.Limpio_Rojo(F3A36, fdesde,2);
            d.Limpio_Rojo(F3A35, fdesde,2);
            d.Limpio_Rojo(F3A34, fdesde,2);
            d.Limpio_Rojo(F3A33, fdesde,2);
            d.Limpio_Rojo(F3A32, fdesde,2);
            d.Limpio_Rojo(F3A31, fdesde,2);
            d.Limpio_Rojo(F3A30, fdesde,2);
            d.Limpio_Rojo(F3A29, fdesde,2);
            d.Limpio_Rojo(F3A28, fdesde,2);
            d.Limpio_Rojo(F3A27, fdesde,2);
            d.Limpio_Rojo(F3A26, fdesde,2);
            d.Limpio_Rojo(F3A25, fdesde,2);
            d.Limpio_Rojo(F3A24, fdesde,2);
            d.Limpio_Rojo(F3A23, fdesde,2);
            d.Limpio_Rojo(F3A22, fdesde,2);
            d.Limpio_Rojo(F3A21, fdesde,2);
            d.Limpio_Rojo(F3A20, fdesde,2);
            d.Limpio_Rojo(F3A19, fdesde,2);
            d.Limpio_Rojo(F3A18, fdesde,2);
            d.Limpio_Rojo(F3A17, fdesde,2);
            d.Limpio_Rojo(F3A16, fdesde,2);
            d.Limpio_Rojo(F3A15, fdesde,2);
            d.Limpio_Rojo(F3A14, fdesde,2);
            d.Limpio_Rojo(F3A13, fdesde,2);
            d.Limpio_Rojo(F3A12, fdesde,2);
            d.Limpio_Rojo(F3A11, fdesde,2);
            d.Limpio_Rojo(F3A10, fdesde,2);
            d.Limpio_Rojo(F3A09, fdesde,2);
            d.Limpio_Rojo(F3A08, fdesde,2);
            d.Limpio_Rojo(F3A07, fdesde,2);
            d.Limpio_Rojo(F3A06, fdesde,2);
            d.Limpio_Rojo(F3A05, fdesde,2);
            d.Limpio_Rojo(F3A04, fdesde,2);
            d.Limpio_Rojo(F3A03, fdesde,2);
            d.Limpio_Rojo(F3A02, fdesde,2);
            d.Limpio_Rojo(F3A01, fdesde,2);
            d.Limpio_Rojo(F2A52, fdesde,2);
            d.Limpio_Rojo(F2A51, fdesde,2);
            d.Limpio_Rojo(F2A50, fdesde,2);
            d.Limpio_Rojo(F2A49, fdesde,2);
            d.Limpio_Rojo(F2A48, fdesde,2);
            d.Limpio_Rojo(F2A47, fdesde,2);
            d.Limpio_Rojo(F2A46, fdesde,2);
            d.Limpio_Rojo(F2A45, fdesde,2);
            d.Limpio_Rojo(F2A44, fdesde,2);
            d.Limpio_Rojo(F2A43, fdesde,2);
            d.Limpio_Rojo(F2A42, fdesde,2);
            d.Limpio_Rojo(F2A41, fdesde,2);
            d.Limpio_Rojo(F2A40, fdesde,2);
            d.Limpio_Rojo(F2A39, fdesde,2);
            d.Limpio_Rojo(F2A38, fdesde,2);
            d.Limpio_Rojo(F2A37, fdesde,2);
            d.Limpio_Rojo(F2A36, fdesde,2);
            d.Limpio_Rojo(F2A35, fdesde,2);
            d.Limpio_Rojo(F2A34, fdesde,2);
            d.Limpio_Rojo(F2A33, fdesde,2);
            d.Limpio_Rojo(F2A32, fdesde,2);
            d.Limpio_Rojo(F2A31, fdesde,2);
            d.Limpio_Rojo(F2A30, fdesde,2);
            d.Limpio_Rojo(F2A29, fdesde,2);
            d.Limpio_Rojo(F2A28, fdesde,2);
            d.Limpio_Rojo(F2A27, fdesde,2);
            d.Limpio_Rojo(F2A26, fdesde,2);
            d.Limpio_Rojo(F2A25, fdesde,2);
            d.Limpio_Rojo(F2A24, fdesde,2);
            d.Limpio_Rojo(F2A23, fdesde,2);
            d.Limpio_Rojo(F2A22, fdesde,2);
            d.Limpio_Rojo(F2A21, fdesde,2);
            d.Limpio_Rojo(F2A20, fdesde,2);
            d.Limpio_Rojo(F2A19, fdesde,2);
            d.Limpio_Rojo(F2A18, fdesde,2);
            d.Limpio_Rojo(F2A17, fdesde,2);
            d.Limpio_Rojo(F2A16, fdesde,2);
            d.Limpio_Rojo(F2A15, fdesde,2);
            d.Limpio_Rojo(F2A14, fdesde,2);
            d.Limpio_Rojo(F2A13, fdesde,2);
            d.Limpio_Rojo(F2A12, fdesde,2);
            d.Limpio_Rojo(F2A11, fdesde,2);
            d.Limpio_Rojo(F2A10, fdesde,2);
            d.Limpio_Rojo(F2A09, fdesde,2);
            d.Limpio_Rojo(F2A08, fdesde,2);
            d.Limpio_Rojo(F2A07, fdesde,2);
            d.Limpio_Rojo(F2A06, fdesde,2);
            d.Limpio_Rojo(F2A05, fdesde,2);
            d.Limpio_Rojo(F2A04, fdesde,2);
            d.Limpio_Rojo(F2A03, fdesde,2);
            d.Limpio_Rojo(F2A02, fdesde,2);
            d.Limpio_Rojo(F2A01, fdesde,2);
            d.Limpio_Rojo(F1A52, fdesde,2);
            d.Limpio_Rojo(F1A51, fdesde,2);
            d.Limpio_Rojo(F1A50, fdesde,2);
            d.Limpio_Rojo(F1A49, fdesde,2);
            d.Limpio_Rojo(F1A48, fdesde,2);
            d.Limpio_Rojo(F1A47, fdesde,2);
            d.Limpio_Rojo(F1A46, fdesde,2);
            d.Limpio_Rojo(F1A45, fdesde,2);
            d.Limpio_Rojo(F1A44, fdesde,2);
            d.Limpio_Rojo(F1A43, fdesde,2);
            d.Limpio_Rojo(F1A42, fdesde,2);
            d.Limpio_Rojo(F1A41, fdesde,2);
            d.Limpio_Rojo(F1A40, fdesde,2);
            d.Limpio_Rojo(F1A39, fdesde,2);
            d.Limpio_Rojo(F1A38, fdesde,2);
            d.Limpio_Rojo(F1A37, fdesde,2);
            d.Limpio_Rojo(F1A36, fdesde,2);
            d.Limpio_Rojo(F1A35, fdesde,2);
            d.Limpio_Rojo(F1A34, fdesde,2);
            d.Limpio_Rojo(F1A33, fdesde,2);
            d.Limpio_Rojo(F1A32, fdesde,2);
            d.Limpio_Rojo(F1A31, fdesde,2);
            d.Limpio_Rojo(F1A30, fdesde,2);
            d.Limpio_Rojo(F1A29, fdesde,2);
            d.Limpio_Rojo(F1A28, fdesde,2);
            d.Limpio_Rojo(F1A27, fdesde,2);
            d.Limpio_Rojo(F1A26, fdesde,2);
            d.Limpio_Rojo(F1A25, fdesde,2);
            d.Limpio_Rojo(F1A24, fdesde,2);
            d.Limpio_Rojo(F1A23, fdesde,2);
            d.Limpio_Rojo(F1A22, fdesde,2);
            d.Limpio_Rojo(F1A21, fdesde,2);
            d.Limpio_Rojo(F1A20, fdesde,2);
            d.Limpio_Rojo(F1A19, fdesde,2);
            d.Limpio_Rojo(F1A18, fdesde,2);
            d.Limpio_Rojo(F1A17, fdesde,2);
            d.Limpio_Rojo(F1A16, fdesde,2);
            d.Limpio_Rojo(F1A15, fdesde,2);
            d.Limpio_Rojo(F1A14, fdesde,2);
            d.Limpio_Rojo(F1A13, fdesde,2);
            d.Limpio_Rojo(F1A12, fdesde,2);
            d.Limpio_Rojo(F1A11, fdesde,2);
            d.Limpio_Rojo(F1A10, fdesde,2);
            d.Limpio_Rojo(F1A09, fdesde,2);
            d.Limpio_Rojo(F1A08, fdesde,2);
            d.Limpio_Rojo(F1A07, fdesde,2);
            d.Limpio_Rojo(F1A06, fdesde,2);
            d.Limpio_Rojo(F1A05, fdesde,2);
            d.Limpio_Rojo(F1A04, fdesde,2);
            d.Limpio_Rojo(F1A03, fdesde,2);
            d.Limpio_Rojo(F1A02, fdesde,2);
            d.Limpio_Rojo(F1A01, fdesde,2);
            d.Limpio_Rojo(C17, fdesde,1);
            d.Limpio_Rojo(C16, fdesde,1);
            d.Limpio_Rojo(C15, fdesde,1);
            d.Limpio_Rojo(C14, fdesde,1);
            d.Limpio_Rojo(C13, fdesde,1);
            d.Limpio_Rojo(C12, fdesde,1);
            d.Limpio_Rojo(C11, fdesde,1);
            d.Limpio_Rojo(C10, fdesde,1);
            d.Limpio_Rojo(C09, fdesde,1);
            d.Limpio_Rojo(C08, fdesde,1);
            d.Limpio_Rojo(C07, fdesde,1);
            d.Limpio_Rojo(C06, fdesde,1);
            d.Limpio_Rojo(C05, fdesde,1);
            d.Limpio_Rojo(C04, fdesde,1);
            d.Limpio_Rojo(C03, fdesde,1);
            d.Limpio_Rojo(C02, fdesde,1);
            d.Limpio_Rojo(C01, fdesde,1);

            string respuesta ="", ruta="";



            OpenFileDialog openfile1 = new OpenFileDialog();
            openfile1.InitialDirectory = "\\\\192.168.192.53\\Sistemas\\";
            openfile1.Filter = "JSON files (*.JSON)|*.JSON|All files (*.*)|*.*";
            
            openfile1.Title = "Seleccione el archivo a Importar";
            if (openfile1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                if (openfile1.FileName.Equals("") == false)
                {
                    ruta = openfile1.FileName;
                }

            }


            if (ruta != "")
            {

                // Verifico si son iguales los nomnbres de los archivos por la fecha
                string fechaCalendario = Convert.ToString(pdesde.Text).Substring(0, 10);
                fechaCalendario = fechaCalendario.Substring(0, 4) + fechaCalendario.Substring(5, 2) + fechaCalendario.Substring(8, 2);
                string fechaRuta = ruta.Substring(26, 8);
                if (fechaRuta == fechaCalendario)
                {
                    string outputJSON = File.ReadAllText(ruta);
                    JsonTextReader reader = new JsonTextReader(new StringReader(outputJSON));
                    while (reader.Read())
                    {
                        if (reader.Value != null)
                        {
                            cont++;
                            if (cont == 4)
                            {
                                Id_impresion = Convert.ToString(reader.Value);
                                respuesta = d.Busco_Presentes(Id_impresion);
                                if (respuesta == "F7A28")
                                    F7A28.BackColor = Color.Green;
                                if (respuesta == "F7A27")
                                    F7A27.BackColor = Color.Green;
                                if (respuesta == "F7A26")
                                    F7A26.BackColor = Color.Green;
                                if (respuesta == "F7A25")
                                    F7A25.BackColor = Color.Green;
                                if (respuesta == "F7A24")
                                    F7A24.BackColor = Color.Green;
                                if (respuesta == "F7A23")
                                    F7A23.BackColor = Color.Green;
                                if (respuesta == "F7A22")
                                    F7A22.BackColor = Color.Green;
                                if (respuesta == "F7A21")
                                    F7A21.BackColor = Color.Green;
                                if (respuesta == "F7A20")
                                    F7A20.BackColor = Color.Green;
                                if (respuesta == "F7A19")
                                    F7A19.BackColor = Color.Green;
                                if (respuesta == "F7A18")
                                    F7A18.BackColor = Color.Green;
                                if (respuesta == "F7A17")
                                    F7A17.BackColor = Color.Green;
                                if (respuesta == "F7A16")
                                    F7A16.BackColor = Color.Green;
                                if (respuesta == "F7A15")
                                    F7A15.BackColor = Color.Green;
                                if (respuesta == "F7A14")
                                    F7A14.BackColor = Color.Green;
                                if (respuesta == "F7A13")
                                    F7A13.BackColor = Color.Green;
                                if (respuesta == "F7A12")
                                    F7A12.BackColor = Color.Green;
                                if (respuesta == "F7A11")
                                    F7A11.BackColor = Color.Green;
                                if (respuesta == "F7A10")
                                    F7A10.BackColor = Color.Green;
                                if (respuesta == "F7A09")
                                    F7A09.BackColor = Color.Green;
                                if (respuesta == "F7A08")
                                    F7A08.BackColor = Color.Green;
                                if (respuesta == "F7A07")
                                    F7A07.BackColor = Color.Green;
                                if (respuesta == "F7A06")
                                    F7A06.BackColor = Color.Green;
                                if (respuesta == "F7A05")
                                    F7A05.BackColor = Color.Green;
                                if (respuesta == "F7A04")
                                    F7A04.BackColor = Color.Green;
                                if (respuesta == "F7A03")
                                    F7A03.BackColor = Color.Green;
                                if (respuesta == "F7A02")
                                    F7A02.BackColor = Color.Green;
                                if (respuesta == "F7A01")
                                    F7A01.BackColor = Color.Green;
                                if (respuesta == "F6A24")
                                    F6A24.BackColor = Color.Green;
                                if (respuesta == "F6A23")
                                    F6A23.BackColor = Color.Green;
                                if (respuesta == "F6A22")
                                    F6A22.BackColor = Color.Green;
                                if (respuesta == "F6A21")
                                    F6A21.BackColor = Color.Green;
                                if (respuesta == "F6A20")
                                    F6A20.BackColor = Color.Green;
                                if (respuesta == "F6A19")
                                    F6A19.BackColor = Color.Green;
                                if (respuesta == "F6A18")
                                    F6A18.BackColor = Color.Green;
                                if (respuesta == "F6A17")
                                    F6A17.BackColor = Color.Green;
                                if (respuesta == "F6A16")
                                    F6A16.BackColor = Color.Green;
                                if (respuesta == "F6A15")
                                    F6A15.BackColor = Color.Green;
                                if (respuesta == "F6A14")
                                    F6A14.BackColor = Color.Green;
                                if (respuesta == "F6A13")
                                    F6A13.BackColor = Color.Green;
                                if (respuesta == "F6A12")
                                    F6A12.BackColor = Color.Green;
                                if (respuesta == "F6A11")
                                    F6A11.BackColor = Color.Green;
                                if (respuesta == "F6A10")
                                    F6A10.BackColor = Color.Green;
                                if (respuesta == "F6A09")
                                    F6A09.BackColor = Color.Green;
                                if (respuesta == "F6A08")
                                    F6A08.BackColor = Color.Green;
                                if (respuesta == "F6A07")
                                    F6A07.BackColor = Color.Green;
                                if (respuesta == "F6A06")
                                    F6A06.BackColor = Color.Green;
                                if (respuesta == "F6A05")
                                    F6A05.BackColor = Color.Green;
                                if (respuesta == "F6A04")
                                    F6A04.BackColor = Color.Green;
                                if (respuesta == "F6A03")
                                    F6A03.BackColor = Color.Green;
                                if (respuesta == "F6A02")
                                    F6A02.BackColor = Color.Green;
                                if (respuesta == "F6A01")
                                    F6A01.BackColor = Color.Green;
                                if (respuesta == "F5A18")
                                    F5A18.BackColor = Color.Green;
                                if (respuesta == "F5A17")
                                    F5A17.BackColor = Color.Green;
                                if (respuesta == "F5A16")
                                    F5A16.BackColor = Color.Green;
                                if (respuesta == "F5A15")
                                    F5A15.BackColor = Color.Green;
                                if (respuesta == "F5A14")
                                    F5A14.BackColor = Color.Green;
                                if (respuesta == "F5A13")
                                    F5A13.BackColor = Color.Green;
                                if (respuesta == "F5A12")
                                    F5A12.BackColor = Color.Green;
                                if (respuesta == "F5A11")
                                    F5A11.BackColor = Color.Green;
                                if (respuesta == "F5A10")
                                    F5A10.BackColor = Color.Green;
                                if (respuesta == "F5A09")
                                    F5A09.BackColor = Color.Green;
                                if (respuesta == "F5A08")
                                    F5A08.BackColor = Color.Green;
                                if (respuesta == "F5A07")
                                    F5A07.BackColor = Color.Green;
                                if (respuesta == "F5A06")
                                    F5A06.BackColor = Color.Green;
                                if (respuesta == "F5A05")
                                    F5A05.BackColor = Color.Green;
                                if (respuesta == "F5A04")
                                    F5A04.BackColor = Color.Green;
                                if (respuesta == "F5A03")
                                    F5A03.BackColor = Color.Green;
                                if (respuesta == "F5A02")
                                    F5A02.BackColor = Color.Green;
                                if (respuesta == "F5A01")
                                    F5A01.BackColor = Color.Green;
                                if (respuesta == "F4A53")
                                    F4A53.BackColor = Color.Green;
                                if (respuesta == "F4A52")
                                    F4A52.BackColor = Color.Green;
                                if (respuesta == "F4A51")
                                    F4A51.BackColor = Color.Green;
                                if (respuesta == "F4A50")
                                    F4A50.BackColor = Color.Green;
                                if (respuesta == "F4A49")
                                    F4A49.BackColor = Color.Green;
                                if (respuesta == "F4A48")
                                    F4A48.BackColor = Color.Green;
                                if (respuesta == "F4A47")
                                    F4A47.BackColor = Color.Green;
                                if (respuesta == "F4A46")
                                    F4A46.BackColor = Color.Green;
                                if (respuesta == "F4A45")
                                    F4A45.BackColor = Color.Green;
                                if (respuesta == "F4A44")
                                    F4A44.BackColor = Color.Green;
                                if (respuesta == "F4A43")
                                    F4A43.BackColor = Color.Green;
                                if (respuesta == "F4A42")
                                    F4A42.BackColor = Color.Green;
                                if (respuesta == "F4A41")
                                    F4A41.BackColor = Color.Green;
                                if (respuesta == "F4A40")
                                    F4A40.BackColor = Color.Green;
                                if (respuesta == "F4A39")
                                    F4A39.BackColor = Color.Green;
                                if (respuesta == "F4A38")
                                    F4A38.BackColor = Color.Green;
                                if (respuesta == "F4A37")
                                    F4A37.BackColor = Color.Green;
                                if (respuesta == "F4A36")
                                    F4A36.BackColor = Color.Green;
                                if (respuesta == "F4A35")
                                    F4A35.BackColor = Color.Green;
                                if (respuesta == "F4A34")
                                    F4A34.BackColor = Color.Green;
                                if (respuesta == "F4A33")
                                    F4A33.BackColor = Color.Green;
                                if (respuesta == "F4A32")
                                    F4A32.BackColor = Color.Green;
                                if (respuesta == "F4A31")
                                    F4A31.BackColor = Color.Green;
                                if (respuesta == "F4A30")
                                    F4A30.BackColor = Color.Green;
                                if (respuesta == "F4A29")
                                    F4A29.BackColor = Color.Green;
                                if (respuesta == "F4A28")
                                    F4A28.BackColor = Color.Green;
                                if (respuesta == "F4A27")
                                    F4A27.BackColor = Color.Green;
                                if (respuesta == "F4A26")
                                    F4A26.BackColor = Color.Green;
                                if (respuesta == "F4A25")
                                    F4A25.BackColor = Color.Green;
                                if (respuesta == "F4A24")
                                    F4A24.BackColor = Color.Green;
                                if (respuesta == "F4A23")
                                    F4A23.BackColor = Color.Green;
                                if (respuesta == "F4A22")
                                    F4A22.BackColor = Color.Green;
                                if (respuesta == "F4A21")
                                    F4A21.BackColor = Color.Green;
                                if (respuesta == "F4A20")
                                    F4A20.BackColor = Color.Green;
                                if (respuesta == "F4A19")
                                    F4A19.BackColor = Color.Green;
                                if (respuesta == "F4A18")
                                    F4A18.BackColor = Color.Green;
                                if (respuesta == "F4A17")
                                    F4A17.BackColor = Color.Green;
                                if (respuesta == "F4A16")
                                    F4A16.BackColor = Color.Green;
                                if (respuesta == "F4A15")
                                    F4A15.BackColor = Color.Green;
                                if (respuesta == "F4A14")
                                    F4A14.BackColor = Color.Green;
                                if (respuesta == "F4A13")
                                    F4A13.BackColor = Color.Green;
                                if (respuesta == "F4A12")
                                    F4A12.BackColor = Color.Green;
                                if (respuesta == "F4A11")
                                    F4A11.BackColor = Color.Green;
                                if (respuesta == "F4A10")
                                    F4A10.BackColor = Color.Green;
                                if (respuesta == "F4A09")
                                    F4A09.BackColor = Color.Green;
                                if (respuesta == "F4A08")
                                    F4A08.BackColor = Color.Green;
                                if (respuesta == "F4A07")
                                    F4A07.BackColor = Color.Green;
                                if (respuesta == "F4A06")
                                    F4A06.BackColor = Color.Green;
                                if (respuesta == "F4A05")
                                    F4A05.BackColor = Color.Green;
                                if (respuesta == "F4A04")
                                    F4A04.BackColor = Color.Green;
                                if (respuesta == "F4A03")
                                    F4A03.BackColor = Color.Green;
                                if (respuesta == "F4A02")
                                    F4A02.BackColor = Color.Green;
                                if (respuesta == "F4A01")
                                    F4A01.BackColor = Color.Green;
                                if (respuesta == "F3A52")
                                    F3A52.BackColor = Color.Green;
                                if (respuesta == "F3A51")
                                    F3A51.BackColor = Color.Green;
                                if (respuesta == "F3A50")
                                    F3A50.BackColor = Color.Green;
                                if (respuesta == "F3A49")
                                    F3A49.BackColor = Color.Green;
                                if (respuesta == "F3A48")
                                    F3A48.BackColor = Color.Green;
                                if (respuesta == "F3A47")
                                    F3A47.BackColor = Color.Green;
                                if (respuesta == "F3A46")
                                    F3A46.BackColor = Color.Green;
                                if (respuesta == "F3A45")
                                    F3A45.BackColor = Color.Green;
                                if (respuesta == "F3A44")
                                    F3A44.BackColor = Color.Green;
                                if (respuesta == "F3A43")
                                    F3A43.BackColor = Color.Green;
                                if (respuesta == "F3A42")
                                    F3A42.BackColor = Color.Green;
                                if (respuesta == "F3A41")
                                    F3A41.BackColor = Color.Green;
                                if (respuesta == "F3A40")
                                    F3A40.BackColor = Color.Green;
                                if (respuesta == "F3A39")
                                    F3A39.BackColor = Color.Green;
                                if (respuesta == "F3A38")
                                    F3A38.BackColor = Color.Green;
                                if (respuesta == "F3A37")
                                    F3A37.BackColor = Color.Green;
                                if (respuesta == "F3A36")
                                    F3A36.BackColor = Color.Green;
                                if (respuesta == "F3A35")
                                    F3A35.BackColor = Color.Green;
                                if (respuesta == "F3A34")
                                    F3A34.BackColor = Color.Green;
                                if (respuesta == "F3A33")
                                    F3A33.BackColor = Color.Green;
                                if (respuesta == "F3A32")
                                    F3A32.BackColor = Color.Green;
                                if (respuesta == "F3A31")
                                    F3A31.BackColor = Color.Green;
                                if (respuesta == "F3A30")
                                    F3A30.BackColor = Color.Green;
                                if (respuesta == "F3A29")
                                    F3A29.BackColor = Color.Green;
                                if (respuesta == "F3A28")
                                    F3A28.BackColor = Color.Green;
                                if (respuesta == "F3A27")
                                    F3A27.BackColor = Color.Green;
                                if (respuesta == "F3A26")
                                    F3A26.BackColor = Color.Green;
                                if (respuesta == "F3A25")
                                    F3A25.BackColor = Color.Green;
                                if (respuesta == "F3A24")
                                    F3A24.BackColor = Color.Green;
                                if (respuesta == "F3A23")
                                    F3A23.BackColor = Color.Green;
                                if (respuesta == "F3A22")
                                    F3A22.BackColor = Color.Green;
                                if (respuesta == "F3A21")
                                    F3A21.BackColor = Color.Green;
                                if (respuesta == "F3A20")
                                    F3A20.BackColor = Color.Green;
                                if (respuesta == "F3A19")
                                    F3A19.BackColor = Color.Green;
                                if (respuesta == "F3A18")
                                    F3A18.BackColor = Color.Green;
                                if (respuesta == "F3A17")
                                    F3A17.BackColor = Color.Green;
                                if (respuesta == "F3A16")
                                    F3A16.BackColor = Color.Green;
                                if (respuesta == "F3A15")
                                    F3A15.BackColor = Color.Green;
                                if (respuesta == "F3A14")
                                    F3A14.BackColor = Color.Green;
                                if (respuesta == "F3A13")
                                    F3A13.BackColor = Color.Green;
                                if (respuesta == "F3A12")
                                    F3A12.BackColor = Color.Green;
                                if (respuesta == "F3A11")
                                    F3A11.BackColor = Color.Green;
                                if (respuesta == "F3A10")
                                    F3A10.BackColor = Color.Green;
                                if (respuesta == "F3A09")
                                    F3A09.BackColor = Color.Green;
                                if (respuesta == "F3A08")
                                    F3A08.BackColor = Color.Green;
                                if (respuesta == "F3A07")
                                    F3A07.BackColor = Color.Green;
                                if (respuesta == "F3A06")
                                    F3A06.BackColor = Color.Green;
                                if (respuesta == "F3A05")
                                    F3A05.BackColor = Color.Green;
                                if (respuesta == "F3A04")
                                    F3A04.BackColor = Color.Green;
                                if (respuesta == "F3A03")
                                    F3A03.BackColor = Color.Green;
                                if (respuesta == "F3A02")
                                    F3A02.BackColor = Color.Green;
                                if (respuesta == "F3A01")
                                    F3A01.BackColor = Color.Green;
                                if (respuesta == "F2A52")
                                    F2A52.BackColor = Color.Green;
                                if (respuesta == "F2A51")
                                    F2A51.BackColor = Color.Green;
                                if (respuesta == "F2A50")
                                    F2A50.BackColor = Color.Green;
                                if (respuesta == "F2A49")
                                    F2A49.BackColor = Color.Green;
                                if (respuesta == "F2A48")
                                    F2A48.BackColor = Color.Green;
                                if (respuesta == "F2A47")
                                    F2A47.BackColor = Color.Green;
                                if (respuesta == "F2A46")
                                    F2A46.BackColor = Color.Green;
                                if (respuesta == "F2A45")
                                    F2A45.BackColor = Color.Green;
                                if (respuesta == "F2A44")
                                    F2A44.BackColor = Color.Green;
                                if (respuesta == "F2A43")
                                    F2A43.BackColor = Color.Green;
                                if (respuesta == "F2A42")
                                    F2A42.BackColor = Color.Green;
                                if (respuesta == "F2A41")
                                    F2A41.BackColor = Color.Green;
                                if (respuesta == "F2A40")
                                    F2A40.BackColor = Color.Green;
                                if (respuesta == "F2A39")
                                    F2A39.BackColor = Color.Green;
                                if (respuesta == "F2A38")
                                    F2A38.BackColor = Color.Green;
                                if (respuesta == "F2A37")
                                    F2A37.BackColor = Color.Green;
                                if (respuesta == "F2A36")
                                    F2A36.BackColor = Color.Green;
                                if (respuesta == "F2A35")
                                    F2A35.BackColor = Color.Green;
                                if (respuesta == "F2A34")
                                    F2A34.BackColor = Color.Green;
                                if (respuesta == "F2A33")
                                    F2A33.BackColor = Color.Green;
                                if (respuesta == "F2A32")
                                    F2A32.BackColor = Color.Green;
                                if (respuesta == "F2A31")
                                    F2A31.BackColor = Color.Green;
                                if (respuesta == "F2A30")
                                    F2A30.BackColor = Color.Green;
                                if (respuesta == "F2A29")
                                    F2A29.BackColor = Color.Green;
                                if (respuesta == "F2A28")
                                    F2A28.BackColor = Color.Green;
                                if (respuesta == "F2A27")
                                    F2A27.BackColor = Color.Green;
                                if (respuesta == "F2A26")
                                    F2A26.BackColor = Color.Green;
                                if (respuesta == "F2A25")
                                    F2A25.BackColor = Color.Green;
                                if (respuesta == "F2A24")
                                    F2A24.BackColor = Color.Green;
                                if (respuesta == "F2A23")
                                    F2A23.BackColor = Color.Green;
                                if (respuesta == "F2A22")
                                    F2A22.BackColor = Color.Green;
                                if (respuesta == "F2A21")
                                    F2A21.BackColor = Color.Green;
                                if (respuesta == "F2A20")
                                    F2A20.BackColor = Color.Green;
                                if (respuesta == "F2A19")
                                    F2A19.BackColor = Color.Green;
                                if (respuesta == "F2A18")
                                    F2A18.BackColor = Color.Green;
                                if (respuesta == "F2A17")
                                    F2A17.BackColor = Color.Green;
                                if (respuesta == "F2A16")
                                    F2A16.BackColor = Color.Green;
                                if (respuesta == "F2A15")
                                    F2A15.BackColor = Color.Green;
                                if (respuesta == "F2A14")
                                    F2A14.BackColor = Color.Green;
                                if (respuesta == "F2A13")
                                    F2A13.BackColor = Color.Green;
                                if (respuesta == "F2A12")
                                    F2A12.BackColor = Color.Green;
                                if (respuesta == "F2A11")
                                    F2A11.BackColor = Color.Green;
                                if (respuesta == "F2A10")
                                    F2A10.BackColor = Color.Green;
                                if (respuesta == "F2A09")
                                    F2A09.BackColor = Color.Green;
                                if (respuesta == "F2A08")
                                    F2A08.BackColor = Color.Green;
                                if (respuesta == "F2A07")
                                    F2A07.BackColor = Color.Green;
                                if (respuesta == "F2A06")
                                    F2A06.BackColor = Color.Green;
                                if (respuesta == "F2A05")
                                    F2A05.BackColor = Color.Green;
                                if (respuesta == "F2A04")
                                    F2A04.BackColor = Color.Green;
                                if (respuesta == "F2A03")
                                    F2A03.BackColor = Color.Green;
                                if (respuesta == "F2A02")
                                    F2A02.BackColor = Color.Green;
                                if (respuesta == "F2A01")
                                    F2A01.BackColor = Color.Green;
                                if (respuesta == "F1A52")
                                    F1A52.BackColor = Color.Green;
                                if (respuesta == "F1A51")
                                    F1A51.BackColor = Color.Green;
                                if (respuesta == "F1A50")
                                    F1A50.BackColor = Color.Green;
                                if (respuesta == "F1A49")
                                    F1A49.BackColor = Color.Green;
                                if (respuesta == "F1A48")
                                    F1A48.BackColor = Color.Green;
                                if (respuesta == "F1A47")
                                    F1A47.BackColor = Color.Green;
                                if (respuesta == "F1A46")
                                    F1A46.BackColor = Color.Green;
                                if (respuesta == "F1A45")
                                    F1A45.BackColor = Color.Green;
                                if (respuesta == "F1A44")
                                    F1A44.BackColor = Color.Green;
                                if (respuesta == "F1A43")
                                    F1A43.BackColor = Color.Green;
                                if (respuesta == "F1A42")
                                    F1A42.BackColor = Color.Green;
                                if (respuesta == "F1A41")
                                    F1A41.BackColor = Color.Green;
                                if (respuesta == "F1A40")
                                    F1A40.BackColor = Color.Green;
                                if (respuesta == "F1A39")
                                    F1A39.BackColor = Color.Green;
                                if (respuesta == "F1A38")
                                    F1A38.BackColor = Color.Green;
                                if (respuesta == "F1A37")
                                    F1A37.BackColor = Color.Green;
                                if (respuesta == "F1A36")
                                    F1A36.BackColor = Color.Green;
                                if (respuesta == "F1A35")
                                    F1A35.BackColor = Color.Green;
                                if (respuesta == "F1A34")
                                    F1A34.BackColor = Color.Green;
                                if (respuesta == "F1A33")
                                    F1A33.BackColor = Color.Green;
                                if (respuesta == "F1A32")
                                    F1A32.BackColor = Color.Green;
                                if (respuesta == "F1A31")
                                    F1A31.BackColor = Color.Green;
                                if (respuesta == "F1A30")
                                    F1A30.BackColor = Color.Green;
                                if (respuesta == "F1A29")
                                    F1A29.BackColor = Color.Green;
                                if (respuesta == "F1A28")
                                    F1A28.BackColor = Color.Green;
                                if (respuesta == "F1A27")
                                    F1A27.BackColor = Color.Green;
                                if (respuesta == "F1A26")
                                    F1A26.BackColor = Color.Green;
                                if (respuesta == "F1A25")
                                    F1A25.BackColor = Color.Green;
                                if (respuesta == "F1A24")
                                    F1A24.BackColor = Color.Green;
                                if (respuesta == "F1A23")
                                    F1A23.BackColor = Color.Green;
                                if (respuesta == "F1A22")
                                    F1A22.BackColor = Color.Green;
                                if (respuesta == "F1A21")
                                    F1A21.BackColor = Color.Green;
                                if (respuesta == "F1A20")
                                    F1A20.BackColor = Color.Green;
                                if (respuesta == "F1A19")
                                    F1A19.BackColor = Color.Green;
                                if (respuesta == "F1A18")
                                    F1A18.BackColor = Color.Green;
                                if (respuesta == "F1A17")
                
                                    F1A17.BackColor = Color.Green;
                                if (respuesta == "F1A16")
                                    F1A16.BackColor = Color.Green;
                                if (respuesta == "F1A15")
                                    F1A15.BackColor = Color.Green;
                                if (respuesta == "F1A14")
                                    F1A14.BackColor = Color.Green;
                                if (respuesta == "F1A13")
                                    F1A13.BackColor = Color.Green;
                                if (respuesta == "F1A12")
                                    F1A12.BackColor = Color.Green;
                                if (respuesta == "F1A11")
                                    F1A11.BackColor = Color.Green;
                                if (respuesta == "F1A10")
                                    F1A10.BackColor = Color.Green;
                                if (respuesta == "F1A09")
                                    F1A09.BackColor = Color.Green;
                                if (respuesta == "F1A08")
                                    F1A08.BackColor = Color.Green;
                                if (respuesta == "F1A07")
                                    F1A07.BackColor = Color.Green;
                                if (respuesta == "F1A06")
                                    F1A06.BackColor = Color.Green;
                                if (respuesta == "F1A05")
                                    F1A05.BackColor = Color.Green;
                                if (respuesta == "F1A04")
                                    F1A04.BackColor = Color.Green;
                                if (respuesta == "F1A03")
                                    F1A03.BackColor = Color.Green;
                                if (respuesta == "F1A02")
                                    F1A02.BackColor = Color.Green;
                                if (respuesta == "F1A01")
                                    F1A01.BackColor = Color.Green;
                                if (respuesta == "C17")
                                    C17.BackColor = Color.Green;
                                if (respuesta == "C16")
                                    C16.BackColor = Color.Green;
                                if (respuesta == "C15")
                                    C15.BackColor = Color.Green;
                                if (respuesta == "C14")
                                    C14.BackColor = Color.Green;
                                if (respuesta == "C13")
                                    C13.BackColor = Color.Green;
                                if (respuesta == "C12")
                                    C12.BackColor = Color.Green;
                                if (respuesta == "C11")
                                    C11.BackColor = Color.Green;
                                if (respuesta == "C10")
                                    C10.BackColor = Color.Green;
                                if (respuesta == "C09")
                                    C09.BackColor = Color.Green;
                                if (respuesta == "C08")
                                    C08.BackColor = Color.Green;
                                if (respuesta == "C07")
                                    C07.BackColor = Color.Green;
                                if (respuesta == "C06")
                                    C06.BackColor = Color.Green;
                                if (respuesta == "C05")
                                    C05.BackColor = Color.Green;
                                if (respuesta == "C04")
                                    C04.BackColor = Color.Green;
                                if (respuesta == "C03")
                                    C03.BackColor = Color.Green;
                                if (respuesta == "C02")
                                    C02.BackColor = Color.Green;
                                if (respuesta == "C01")
                                    C01.BackColor = Color.Green;

                                panel2.Visible = false;
                                panel5.Visible = false;
                                panel6.Visible = false;
                                panel3.Visible = true;
                                panel4.Visible = true;
                                panel7.Visible = true;
                                panel8.Visible = true;
                                totentrantescabinas.Text = Convert.ToString(FrmLogin.total_cabinas_entrantes) + " Cabinas Entrantes";
                                totfaltantescabinas.Text = Convert.ToString(Convert.ToDouble(FrmLogin.total_cabinas_impresas - FrmLogin.total_cabinas_entrantes)) + " Cabinas Faltantes";
                                totentrantespupitres.Text = Convert.ToString(FrmLogin.total_pupitres_entrantes) + " Pupitres Entrantes";
                                totfaltantespupitres.Text = Convert.ToString(Convert.ToDouble(FrmLogin.total_pupitres_impresos - FrmLogin.total_pupitres_entrantes)) + " Pupitres Faltantes";




                            }




                        }
                        else
                        {
                            cont = 0;
                        }
                    }


                }
                else
                {
                    MessageBox.Show("No son iguales en fecha el archivo seleccionado con la fecha para buscar");
                }



            }
                System.Windows.Forms.Cursor.Current = Cursors.Default;
                this.Refresh();
            
             
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string criterio = "", fdesde = "";
            double total_impresiones = 0;
            FrmLogin.total_cabinas_impresas = 0;
            FrmLogin.total_pupitres_impresos = 0;
            FrmLogin.totimpresiones = 0;



                txtidevento.Text  = "";
                fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);
                Evento d = new Evento();
                criterio = "Select Id_Evento, Nombre_Evento, Campeonato, Numero_Fecha, url, Id_Rival from eventos where Fecha='" + fdesde + "' Order By Id_Evento";
                d.llenarcomboeventos(cbeventos, criterio);
                d.Busco_Dato_Evento(txttorneo, fecnumero, URL, criterio, txtidevento, txtidrival);
                this.Refresh();
            
            if ( txtidevento.Text  != "")
            {
                System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;

                d.Limpio(F7A28);
                d.Limpio(F7A27);
                d.Limpio(F7A26);
                d.Limpio(F7A25);
                d.Limpio(F7A24);
                d.Limpio(F7A23);
                d.Limpio(F7A22);
                d.Limpio(F7A21);
                d.Limpio(F7A20);
                d.Limpio(F7A19);
                d.Limpio(F7A18);
                d.Limpio(F7A17);
                d.Limpio(F7A16);
                d.Limpio(F7A15);
                d.Limpio(F7A14);
                d.Limpio(F7A13);
                d.Limpio(F7A12);
                d.Limpio(F7A11);
                d.Limpio(F7A10);
                d.Limpio(F7A09);
                d.Limpio(F7A08);
                d.Limpio(F7A07);
                d.Limpio(F7A06);
                d.Limpio(F7A05);
                d.Limpio(F7A04);
                d.Limpio(F7A03);
                d.Limpio(F7A02);
                d.Limpio(F7A01);
                d.Limpio(F7A28);
                d.Limpio(F7A27);
                d.Limpio(F7A26);
                d.Limpio(F7A25);
                d.Limpio(F7A24);
                d.Limpio(F7A23);
                d.Limpio(F7A22);
                d.Limpio(F7A21);
                d.Limpio(F7A20);
                d.Limpio(F7A19);
                d.Limpio(F7A18);
                d.Limpio(F7A17);
                d.Limpio(F7A16);
                d.Limpio(F7A15);
                d.Limpio(F7A14);
                d.Limpio(F7A13);
                d.Limpio(F7A12);
                d.Limpio(F7A11);
                d.Limpio(F7A10);
                d.Limpio(F7A09);
                d.Limpio(F7A08);
                d.Limpio(F7A07);
                d.Limpio(F7A06);
                d.Limpio(F7A05);
                d.Limpio(F7A04);
                d.Limpio(F7A03);
                d.Limpio(F7A02);
                d.Limpio(F7A01);
                d.Limpio(F6A24);
                d.Limpio(F6A23);
                d.Limpio(F6A22);
                d.Limpio(F6A21);
                d.Limpio(F6A20);
                d.Limpio(F6A19);
                d.Limpio(F6A18);
                d.Limpio(F6A17);
                d.Limpio(F6A16);
                d.Limpio(F6A15);
                d.Limpio(F6A14);
                d.Limpio(F6A13);
                d.Limpio(F6A12);
                d.Limpio(F6A11);
                d.Limpio(F6A10);
                d.Limpio(F6A09);
                d.Limpio(F6A08);
                d.Limpio(F6A07);
                d.Limpio(F6A06);
                d.Limpio(F6A05);
                d.Limpio(F6A04);
                d.Limpio(F6A03);
                d.Limpio(F6A02);
                d.Limpio(F6A01);
                d.Limpio(F5A18);
                d.Limpio(F5A17);
                d.Limpio(F5A16);
                d.Limpio(F5A15);
                d.Limpio(F5A14);
                d.Limpio(F5A13);
                d.Limpio(F5A12);
                d.Limpio(F5A11);
                d.Limpio(F5A10);
                d.Limpio(F5A09);
                d.Limpio(F5A08);
                d.Limpio(F5A07);
                d.Limpio(F5A06);
                d.Limpio(F5A05);
                d.Limpio(F5A04);
                d.Limpio(F5A03);
                d.Limpio(F5A02);
                d.Limpio(F5A01);
                d.Limpio(F4A53);
                d.Limpio(F4A52);
                d.Limpio(F4A51);
                d.Limpio(F4A50);
                d.Limpio(F4A49);
                d.Limpio(F4A48);
                d.Limpio(F4A47);
                d.Limpio(F4A46);
                d.Limpio(F4A45);
                d.Limpio(F4A44);
                d.Limpio(F4A43);
                d.Limpio(F4A42);
                d.Limpio(F4A41);
                d.Limpio(F4A40);
                d.Limpio(F4A39);
                d.Limpio(F4A38);
                d.Limpio(F4A37);
                d.Limpio(F4A36);
                d.Limpio(F4A35);
                d.Limpio(F4A34);
                d.Limpio(F4A33);
                d.Limpio(F4A32);
                d.Limpio(F4A31);
                d.Limpio(F4A30);
                d.Limpio(F4A29);
                d.Limpio(F4A28);
                d.Limpio(F4A27);
                d.Limpio(F4A26);
                d.Limpio(F4A25);
                d.Limpio(F4A24);
                d.Limpio(F4A23);
                d.Limpio(F4A22);
                d.Limpio(F4A21);
                d.Limpio(F4A20);
                d.Limpio(F4A19);
                d.Limpio(F4A18);
                d.Limpio(F4A17);
                d.Limpio(F4A16);
                d.Limpio(F4A15);
                d.Limpio(F4A14);
                d.Limpio(F4A13);
                d.Limpio(F4A12);
                d.Limpio(F4A11);
                d.Limpio(F4A10);
                d.Limpio(F4A09);
                d.Limpio(F4A08);
                d.Limpio(F4A07);
                d.Limpio(F4A06);
                d.Limpio(F4A05);
                d.Limpio(F4A04);
                d.Limpio(F4A03);
                d.Limpio(F4A02);
                d.Limpio(F4A01);
                d.Limpio(F3A52);
                d.Limpio(F3A51);
                d.Limpio(F3A50);
                d.Limpio(F3A49);
                d.Limpio(F3A48);
                d.Limpio(F3A47);
                d.Limpio(F3A46);
                d.Limpio(F3A45);
                d.Limpio(F3A44);
                d.Limpio(F3A43);
                d.Limpio(F3A42);
                d.Limpio(F3A41);
                d.Limpio(F3A40);
                d.Limpio(F3A39);
                d.Limpio(F3A38);
                d.Limpio(F3A37);
                d.Limpio(F3A36);
                d.Limpio(F3A35);
                d.Limpio(F3A34);
                d.Limpio(F3A33);
                d.Limpio(F3A32);
                d.Limpio(F3A31);
                d.Limpio(F3A30);
                d.Limpio(F3A29);
                d.Limpio(F3A28);
                d.Limpio(F3A27);
                d.Limpio(F3A26);
                d.Limpio(F3A25);
                d.Limpio(F3A24);
                d.Limpio(F3A23);
                d.Limpio(F3A22);
                d.Limpio(F3A21);
                d.Limpio(F3A20);
                d.Limpio(F3A19);
                d.Limpio(F3A18);
                d.Limpio(F3A17);
                d.Limpio(F3A16);
                d.Limpio(F3A15);
                d.Limpio(F3A14);
                d.Limpio(F3A13);
                d.Limpio(F3A12);
                d.Limpio(F3A11);
                d.Limpio(F3A10);
                d.Limpio(F3A09);
                d.Limpio(F3A08);
                d.Limpio(F3A07);
                d.Limpio(F3A06);
                d.Limpio(F3A05);
                d.Limpio(F3A04);
                d.Limpio(F3A03);
                d.Limpio(F3A02);
                d.Limpio(F3A01);
                d.Limpio(F2A52);
                d.Limpio(F2A51);
                d.Limpio(F2A50);
                d.Limpio(F2A49);
                d.Limpio(F2A48);
                d.Limpio(F2A47);
                d.Limpio(F2A46);
                d.Limpio(F2A45);
                d.Limpio(F2A44);
                d.Limpio(F2A43);
                d.Limpio(F2A42);
                d.Limpio(F2A41);
                d.Limpio(F2A40);
                d.Limpio(F2A39);
                d.Limpio(F2A38);
                d.Limpio(F2A37);
                d.Limpio(F2A36);
                d.Limpio(F2A35);
                d.Limpio(F2A34);
                d.Limpio(F2A33);
                d.Limpio(F2A32);
                d.Limpio(F2A31);
                d.Limpio(F2A30);
                d.Limpio(F2A29);
                d.Limpio(F2A28);
                d.Limpio(F2A27);
                d.Limpio(F2A26);
                d.Limpio(F2A25);
                d.Limpio(F2A24);
                d.Limpio(F2A23);
                d.Limpio(F2A22);
                d.Limpio(F2A21);
                d.Limpio(F2A20);
                d.Limpio(F2A19);
                d.Limpio(F2A18);
                d.Limpio(F2A17);
                d.Limpio(F2A16);
                d.Limpio(F2A15);
                d.Limpio(F2A14);
                d.Limpio(F2A13);
                d.Limpio(F2A12);
                d.Limpio(F2A11);
                d.Limpio(F2A10);
                d.Limpio(F2A09);
                d.Limpio(F2A08);
                d.Limpio(F2A07);
                d.Limpio(F2A06);
                d.Limpio(F2A05);
                d.Limpio(F2A04);
                d.Limpio(F2A03);
                d.Limpio(F2A02);
                d.Limpio(F2A01);
                d.Limpio(F1A52);
                d.Limpio(F1A51);
                d.Limpio(F1A50);
                d.Limpio(F1A49);
                d.Limpio(F1A48);
                d.Limpio(F1A47);
                d.Limpio(F1A46);
                d.Limpio(F1A45);
                d.Limpio(F1A44);
                d.Limpio(F1A43);
                d.Limpio(F1A42);
                d.Limpio(F1A41);
                d.Limpio(F1A40);
                d.Limpio(F1A39);
                d.Limpio(F1A38);
                d.Limpio(F1A37);
                d.Limpio(F1A36);
                d.Limpio(F1A35);
                d.Limpio(F1A34);
                d.Limpio(F1A33);
                d.Limpio(F1A32);
                d.Limpio(F1A31);
                d.Limpio(F1A30);
                d.Limpio(F1A29);
                d.Limpio(F1A28);
                d.Limpio(F1A27);
                d.Limpio(F1A26);
                d.Limpio(F1A25);
                d.Limpio(F1A24);
                d.Limpio(F1A23);
                d.Limpio(F1A22);
                d.Limpio(F1A21);
                d.Limpio(F1A20);
                d.Limpio(F1A19);
                d.Limpio(F1A18);
                d.Limpio(F1A17);
                d.Limpio(F1A16);
                d.Limpio(F1A15);
                d.Limpio(F1A14);
                d.Limpio(F1A13);
                d.Limpio(F1A12);
                d.Limpio(F1A11);
                d.Limpio(F1A10);
                d.Limpio(F1A09);
                d.Limpio(F1A08);
                d.Limpio(F1A07);
                d.Limpio(F1A06);
                d.Limpio(F1A05);
                d.Limpio(F1A04);
                d.Limpio(F1A03);
                d.Limpio(F1A02);
                d.Limpio(F1A01);
                d.Limpio(C17);
                d.Limpio(C16);
                d.Limpio(C15);
                d.Limpio(C14);
                d.Limpio(C13);
                d.Limpio(C12);
                d.Limpio(C11);
                d.Limpio(C10);
                d.Limpio(C09);
                d.Limpio(C08);
                d.Limpio(C07);
                d.Limpio(C06);
                d.Limpio(C05);
                d.Limpio(C04);
                d.Limpio(C03);
                d.Limpio(C02);
                d.Limpio(C01);












                // FILA 7
                d.Busco_Impresos_Pupitres(fdesde, F7A28);
                d.Busco_Impresos_Pupitres(fdesde, F7A27);
                d.Busco_Impresos_Pupitres(fdesde, F7A26);
                d.Busco_Impresos_Pupitres(fdesde, F7A25);
                d.Busco_Impresos_Pupitres(fdesde, F7A24);
                d.Busco_Impresos_Pupitres(fdesde, F7A23);
                d.Busco_Impresos_Pupitres(fdesde, F7A22);
                d.Busco_Impresos_Pupitres(fdesde, F7A21);
                d.Busco_Impresos_Pupitres(fdesde, F7A20);
                d.Busco_Impresos_Pupitres(fdesde, F7A19);
                d.Busco_Impresos_Pupitres(fdesde, F7A18);
                d.Busco_Impresos_Pupitres(fdesde, F7A17);
                d.Busco_Impresos_Pupitres(fdesde, F7A16);
                d.Busco_Impresos_Pupitres(fdesde, F7A15);
                d.Busco_Impresos_Pupitres(fdesde, F7A14);
                d.Busco_Impresos_Pupitres(fdesde, F7A13);
                d.Busco_Impresos_Pupitres(fdesde, F7A12);
                d.Busco_Impresos_Pupitres(fdesde, F7A11);
                d.Busco_Impresos_Pupitres(fdesde, F7A10);
                d.Busco_Impresos_Pupitres(fdesde, F7A09);
                d.Busco_Impresos_Pupitres(fdesde, F7A08);
                d.Busco_Impresos_Pupitres(fdesde, F7A07);
                d.Busco_Impresos_Pupitres(fdesde, F7A06);
                d.Busco_Impresos_Pupitres(fdesde, F7A05);
                d.Busco_Impresos_Pupitres(fdesde, F7A04);
                d.Busco_Impresos_Pupitres(fdesde, F7A03);
                d.Busco_Impresos_Pupitres(fdesde, F7A02);
                d.Busco_Impresos_Pupitres(fdesde, F7A01);
                // FILA 6
                d.Busco_Impresos_Pupitres(fdesde, F6A24);
                d.Busco_Impresos_Pupitres(fdesde, F6A23);
                d.Busco_Impresos_Pupitres(fdesde, F6A22);
                d.Busco_Impresos_Pupitres(fdesde, F6A22);
                d.Busco_Impresos_Pupitres(fdesde, F6A20);
                d.Busco_Impresos_Pupitres(fdesde, F6A19);
                d.Busco_Impresos_Pupitres(fdesde, F6A18);
                d.Busco_Impresos_Pupitres(fdesde, F6A17);
                d.Busco_Impresos_Pupitres(fdesde, F6A16);
                d.Busco_Impresos_Pupitres(fdesde, F6A15);
                d.Busco_Impresos_Pupitres(fdesde, F6A14);
                d.Busco_Impresos_Pupitres(fdesde, F6A13);
                d.Busco_Impresos_Pupitres(fdesde, F6A12);
                d.Busco_Impresos_Pupitres(fdesde, F6A11);
                d.Busco_Impresos_Pupitres(fdesde, F6A10);
                d.Busco_Impresos_Pupitres(fdesde, F6A09);
                d.Busco_Impresos_Pupitres(fdesde, F6A08);
                d.Busco_Impresos_Pupitres(fdesde, F6A07);
                d.Busco_Impresos_Pupitres(fdesde, F6A06);
                d.Busco_Impresos_Pupitres(fdesde, F6A05);
                d.Busco_Impresos_Pupitres(fdesde, F6A04);
                d.Busco_Impresos_Pupitres(fdesde, F6A03);
                d.Busco_Impresos_Pupitres(fdesde, F6A02);
                d.Busco_Impresos_Pupitres(fdesde, F6A01);
                //FILA 5
                d.Busco_Impresos_Pupitres(fdesde, F5A18);
                d.Busco_Impresos_Pupitres(fdesde, F5A17);
                d.Busco_Impresos_Pupitres(fdesde, F5A16);
                d.Busco_Impresos_Pupitres(fdesde, F5A15);
                d.Busco_Impresos_Pupitres(fdesde, F5A14);
                d.Busco_Impresos_Pupitres(fdesde, F5A13);
                d.Busco_Impresos_Pupitres(fdesde, F5A12);
                d.Busco_Impresos_Pupitres(fdesde, F5A11);
                d.Busco_Impresos_Pupitres(fdesde, F5A10);
                d.Busco_Impresos_Pupitres(fdesde, F5A09);
                d.Busco_Impresos_Pupitres(fdesde, F5A08);
                d.Busco_Impresos_Pupitres(fdesde, F5A07);
                d.Busco_Impresos_Pupitres(fdesde, F5A06);
                d.Busco_Impresos_Pupitres(fdesde, F5A05);
                d.Busco_Impresos_Pupitres(fdesde, F5A04);
                d.Busco_Impresos_Pupitres(fdesde, F5A03);
                d.Busco_Impresos_Pupitres(fdesde, F5A02);
                d.Busco_Impresos_Pupitres(fdesde, F5A01);

                //FILA 4
                d.Busco_Impresos_Pupitres(fdesde, F4A53);
                d.Busco_Impresos_Pupitres(fdesde, F4A52);
                d.Busco_Impresos_Pupitres(fdesde, F4A51);
                d.Busco_Impresos_Pupitres(fdesde, F4A50);
                d.Busco_Impresos_Pupitres(fdesde, F4A49);
                d.Busco_Impresos_Pupitres(fdesde, F4A48);
                d.Busco_Impresos_Pupitres(fdesde, F4A47);
                d.Busco_Impresos_Pupitres(fdesde, F4A46);
                d.Busco_Impresos_Pupitres(fdesde, F4A45);
                d.Busco_Impresos_Pupitres(fdesde, F4A44);
                d.Busco_Impresos_Pupitres(fdesde, F4A43);
                d.Busco_Impresos_Pupitres(fdesde, F4A42);
                d.Busco_Impresos_Pupitres(fdesde, F4A41);
                d.Busco_Impresos_Pupitres(fdesde, F4A40);
                d.Busco_Impresos_Pupitres(fdesde, F4A39);
                d.Busco_Impresos_Pupitres(fdesde, F4A38);
                d.Busco_Impresos_Pupitres(fdesde, F4A37);
                d.Busco_Impresos_Pupitres(fdesde, F4A36);
                d.Busco_Impresos_Pupitres(fdesde, F4A35);
                d.Busco_Impresos_Pupitres(fdesde, F4A34);
                d.Busco_Impresos_Pupitres(fdesde, F4A33);
                d.Busco_Impresos_Pupitres(fdesde, F4A32);
                d.Busco_Impresos_Pupitres(fdesde, F4A31);
                d.Busco_Impresos_Pupitres(fdesde, F4A30);
                d.Busco_Impresos_Pupitres(fdesde, F4A29);
                d.Busco_Impresos_Pupitres(fdesde, F4A28);
                d.Busco_Impresos_Pupitres(fdesde, F4A27);
                d.Busco_Impresos_Pupitres(fdesde, F4A26);
                d.Busco_Impresos_Pupitres(fdesde, F4A25);
                d.Busco_Impresos_Pupitres(fdesde, F4A24);
                d.Busco_Impresos_Pupitres(fdesde, F4A23);
                d.Busco_Impresos_Pupitres(fdesde, F4A22);
                d.Busco_Impresos_Pupitres(fdesde, F4A21);
                d.Busco_Impresos_Pupitres(fdesde, F4A20);
                d.Busco_Impresos_Pupitres(fdesde, F4A19);
                d.Busco_Impresos_Pupitres(fdesde, F4A18);
                d.Busco_Impresos_Pupitres(fdesde, F4A17);
                d.Busco_Impresos_Pupitres(fdesde, F4A16);
                d.Busco_Impresos_Pupitres(fdesde, F4A15);
                d.Busco_Impresos_Pupitres(fdesde, F4A14);
                d.Busco_Impresos_Pupitres(fdesde, F4A13);
                d.Busco_Impresos_Pupitres(fdesde, F4A12);
                d.Busco_Impresos_Pupitres(fdesde, F4A11);
                d.Busco_Impresos_Pupitres(fdesde, F4A10);
                d.Busco_Impresos_Pupitres(fdesde, F4A09);
                d.Busco_Impresos_Pupitres(fdesde, F4A08);
                d.Busco_Impresos_Pupitres(fdesde, F4A07);
                d.Busco_Impresos_Pupitres(fdesde, F4A06);
                d.Busco_Impresos_Pupitres(fdesde, F4A05);
                d.Busco_Impresos_Pupitres(fdesde, F4A04);
                d.Busco_Impresos_Pupitres(fdesde, F4A03);
                d.Busco_Impresos_Pupitres(fdesde, F4A02);
                d.Busco_Impresos_Pupitres(fdesde, F4A01);

                //FILA 3
                d.Busco_Impresos_Pupitres(fdesde, F3A52);
                d.Busco_Impresos_Pupitres(fdesde, F3A51);
                d.Busco_Impresos_Pupitres(fdesde, F3A50);
                d.Busco_Impresos_Pupitres(fdesde, F3A49);
                d.Busco_Impresos_Pupitres(fdesde, F3A48);
                d.Busco_Impresos_Pupitres(fdesde, F3A47);
                d.Busco_Impresos_Pupitres(fdesde, F3A46);
                d.Busco_Impresos_Pupitres(fdesde, F3A45);
                d.Busco_Impresos_Pupitres(fdesde, F3A44);
                d.Busco_Impresos_Pupitres(fdesde, F3A43);
                d.Busco_Impresos_Pupitres(fdesde, F3A42);
                d.Busco_Impresos_Pupitres(fdesde, F3A41);
                d.Busco_Impresos_Pupitres(fdesde, F3A40);
                d.Busco_Impresos_Pupitres(fdesde, F3A39);
                d.Busco_Impresos_Pupitres(fdesde, F3A38);
                d.Busco_Impresos_Pupitres(fdesde, F3A37);
                d.Busco_Impresos_Pupitres(fdesde, F3A36);
                d.Busco_Impresos_Pupitres(fdesde, F3A35);
                d.Busco_Impresos_Pupitres(fdesde, F3A34);
                d.Busco_Impresos_Pupitres(fdesde, F3A33);
                d.Busco_Impresos_Pupitres(fdesde, F3A32);
                d.Busco_Impresos_Pupitres(fdesde, F3A31);
                d.Busco_Impresos_Pupitres(fdesde, F3A30);
                d.Busco_Impresos_Pupitres(fdesde, F3A29);
                d.Busco_Impresos_Pupitres(fdesde, F3A28);
                d.Busco_Impresos_Pupitres(fdesde, F3A27);
                d.Busco_Impresos_Pupitres(fdesde, F3A26);
                d.Busco_Impresos_Pupitres(fdesde, F3A25);
                d.Busco_Impresos_Pupitres(fdesde, F3A24);
                d.Busco_Impresos_Pupitres(fdesde, F3A23);
                d.Busco_Impresos_Pupitres(fdesde, F3A22);
                d.Busco_Impresos_Pupitres(fdesde, F3A21);
                d.Busco_Impresos_Pupitres(fdesde, F3A20);
                d.Busco_Impresos_Pupitres(fdesde, F3A19);
                d.Busco_Impresos_Pupitres(fdesde, F3A18);
                d.Busco_Impresos_Pupitres(fdesde, F3A17);
                d.Busco_Impresos_Pupitres(fdesde, F3A16);
                d.Busco_Impresos_Pupitres(fdesde, F3A15);
                d.Busco_Impresos_Pupitres(fdesde, F3A14);
                d.Busco_Impresos_Pupitres(fdesde, F3A13);
                d.Busco_Impresos_Pupitres(fdesde, F3A12);
                d.Busco_Impresos_Pupitres(fdesde, F3A11);
                d.Busco_Impresos_Pupitres(fdesde, F3A10);
                d.Busco_Impresos_Pupitres(fdesde, F3A09);
                d.Busco_Impresos_Pupitres(fdesde, F3A08);
                d.Busco_Impresos_Pupitres(fdesde, F3A07);
                d.Busco_Impresos_Pupitres(fdesde, F3A06);
                d.Busco_Impresos_Pupitres(fdesde, F3A05);
                d.Busco_Impresos_Pupitres(fdesde, F3A04);
                d.Busco_Impresos_Pupitres(fdesde, F3A03);
                d.Busco_Impresos_Pupitres(fdesde, F3A02);
                d.Busco_Impresos_Pupitres(fdesde, F3A01);


                //FILA 2
                d.Busco_Impresos_Pupitres(fdesde, F2A52);
                d.Busco_Impresos_Pupitres(fdesde, F2A51);
                d.Busco_Impresos_Pupitres(fdesde, F2A50);
                d.Busco_Impresos_Pupitres(fdesde, F2A49);
                d.Busco_Impresos_Pupitres(fdesde, F2A48);
                d.Busco_Impresos_Pupitres(fdesde, F2A47);
                d.Busco_Impresos_Pupitres(fdesde, F2A46);
                d.Busco_Impresos_Pupitres(fdesde, F2A45);
                d.Busco_Impresos_Pupitres(fdesde, F2A44);
                d.Busco_Impresos_Pupitres(fdesde, F2A43);
                d.Busco_Impresos_Pupitres(fdesde, F2A42);
                d.Busco_Impresos_Pupitres(fdesde, F2A41);
                d.Busco_Impresos_Pupitres(fdesde, F2A40);
                d.Busco_Impresos_Pupitres(fdesde, F2A39);
                d.Busco_Impresos_Pupitres(fdesde, F2A38);
                d.Busco_Impresos_Pupitres(fdesde, F2A37);
                d.Busco_Impresos_Pupitres(fdesde, F2A36);
                d.Busco_Impresos_Pupitres(fdesde, F2A35);
                d.Busco_Impresos_Pupitres(fdesde, F2A34);
                d.Busco_Impresos_Pupitres(fdesde, F2A33);
                d.Busco_Impresos_Pupitres(fdesde, F2A32);
                d.Busco_Impresos_Pupitres(fdesde, F2A31);
                d.Busco_Impresos_Pupitres(fdesde, F2A30);
                d.Busco_Impresos_Pupitres(fdesde, F2A29);
                d.Busco_Impresos_Pupitres(fdesde, F2A28);
                d.Busco_Impresos_Pupitres(fdesde, F2A27);
                d.Busco_Impresos_Pupitres(fdesde, F2A26);
                d.Busco_Impresos_Pupitres(fdesde, F2A25);
                d.Busco_Impresos_Pupitres(fdesde, F2A24);
                d.Busco_Impresos_Pupitres(fdesde, F2A23);
                d.Busco_Impresos_Pupitres(fdesde, F2A22);
                d.Busco_Impresos_Pupitres(fdesde, F2A21);
                d.Busco_Impresos_Pupitres(fdesde, F2A20);
                d.Busco_Impresos_Pupitres(fdesde, F2A19);
                d.Busco_Impresos_Pupitres(fdesde, F2A18);
                d.Busco_Impresos_Pupitres(fdesde, F2A17);
                d.Busco_Impresos_Pupitres(fdesde, F2A16);
                d.Busco_Impresos_Pupitres(fdesde, F2A15);
                d.Busco_Impresos_Pupitres(fdesde, F2A14);
                d.Busco_Impresos_Pupitres(fdesde, F2A13);
                d.Busco_Impresos_Pupitres(fdesde, F2A12);
                d.Busco_Impresos_Pupitres(fdesde, F2A11);
                d.Busco_Impresos_Pupitres(fdesde, F2A10);
                d.Busco_Impresos_Pupitres(fdesde, F2A09);
                d.Busco_Impresos_Pupitres(fdesde, F2A08);
                d.Busco_Impresos_Pupitres(fdesde, F2A07);
                d.Busco_Impresos_Pupitres(fdesde, F2A06);
                d.Busco_Impresos_Pupitres(fdesde, F2A05);
                d.Busco_Impresos_Pupitres(fdesde, F2A04);
                d.Busco_Impresos_Pupitres(fdesde, F2A03);
                d.Busco_Impresos_Pupitres(fdesde, F2A02);
                d.Busco_Impresos_Pupitres(fdesde, F2A01);

                //FILA 1
                d.Busco_Impresos_Pupitres(fdesde, F1A52);
                d.Busco_Impresos_Pupitres(fdesde, F1A51);
                d.Busco_Impresos_Pupitres(fdesde, F1A50);
                d.Busco_Impresos_Pupitres(fdesde, F1A49);
                d.Busco_Impresos_Pupitres(fdesde, F1A48);
                d.Busco_Impresos_Pupitres(fdesde, F1A47);
                d.Busco_Impresos_Pupitres(fdesde, F1A46);
                d.Busco_Impresos_Pupitres(fdesde, F1A45);
                d.Busco_Impresos_Pupitres(fdesde, F1A44);
                d.Busco_Impresos_Pupitres(fdesde, F1A43);
                d.Busco_Impresos_Pupitres(fdesde, F1A42);
                d.Busco_Impresos_Pupitres(fdesde, F1A41);
                d.Busco_Impresos_Pupitres(fdesde, F1A40);
                d.Busco_Impresos_Pupitres(fdesde, F1A39);
                d.Busco_Impresos_Pupitres(fdesde, F1A38);
                d.Busco_Impresos_Pupitres(fdesde, F1A37);
                d.Busco_Impresos_Pupitres(fdesde, F1A36);
                d.Busco_Impresos_Pupitres(fdesde, F1A35);
                d.Busco_Impresos_Pupitres(fdesde, F1A34);
                d.Busco_Impresos_Pupitres(fdesde, F1A33);
                d.Busco_Impresos_Pupitres(fdesde, F1A32);
                d.Busco_Impresos_Pupitres(fdesde, F1A31);
                d.Busco_Impresos_Pupitres(fdesde, F1A30);
                d.Busco_Impresos_Pupitres(fdesde, F1A29);
                d.Busco_Impresos_Pupitres(fdesde, F1A28);
                d.Busco_Impresos_Pupitres(fdesde, F1A27);
                d.Busco_Impresos_Pupitres(fdesde, F1A26);
                d.Busco_Impresos_Pupitres(fdesde, F1A25);
                d.Busco_Impresos_Pupitres(fdesde, F1A24);
                d.Busco_Impresos_Pupitres(fdesde, F1A23);
                d.Busco_Impresos_Pupitres(fdesde, F1A22);
                d.Busco_Impresos_Pupitres(fdesde, F1A21);
                d.Busco_Impresos_Pupitres(fdesde, F1A20);
                d.Busco_Impresos_Pupitres(fdesde, F1A19);
                d.Busco_Impresos_Pupitres(fdesde, F1A18);
                d.Busco_Impresos_Pupitres(fdesde, F1A17);
                d.Busco_Impresos_Pupitres(fdesde, F1A16);
                d.Busco_Impresos_Pupitres(fdesde, F1A15);
                d.Busco_Impresos_Pupitres(fdesde, F1A14);
                d.Busco_Impresos_Pupitres(fdesde, F1A13);
                d.Busco_Impresos_Pupitres(fdesde, F1A12);
                d.Busco_Impresos_Pupitres(fdesde, F1A11);
                d.Busco_Impresos_Pupitres(fdesde, F1A10);
                d.Busco_Impresos_Pupitres(fdesde, F1A09);
                d.Busco_Impresos_Pupitres(fdesde, F1A08);
                d.Busco_Impresos_Pupitres(fdesde, F1A07);
                d.Busco_Impresos_Pupitres(fdesde, F1A06);
                d.Busco_Impresos_Pupitres(fdesde, F1A05);
                d.Busco_Impresos_Pupitres(fdesde, F1A04);
                d.Busco_Impresos_Pupitres(fdesde, F1A03);
                d.Busco_Impresos_Pupitres(fdesde, F1A02);
                d.Busco_Impresos_Pupitres(fdesde, F1A01);


                // CABINAS
                d.Busco_Impresos_Cabinas(fdesde, C17);
                d.Busco_Impresos_Cabinas(fdesde, C16);
                d.Busco_Impresos_Cabinas(fdesde, C15);
                d.Busco_Impresos_Cabinas(fdesde, C14);
                d.Busco_Impresos_Cabinas(fdesde, C13);
                d.Busco_Impresos_Cabinas(fdesde, C12);
                d.Busco_Impresos_Cabinas(fdesde, C11);
                d.Busco_Impresos_Cabinas(fdesde, C10);
                d.Busco_Impresos_Cabinas(fdesde, C09);
                d.Busco_Impresos_Cabinas(fdesde, C08);
                d.Busco_Impresos_Cabinas(fdesde, C07);
                d.Busco_Impresos_Cabinas(fdesde, C06);
                d.Busco_Impresos_Cabinas(fdesde, C05);
                d.Busco_Impresos_Cabinas(fdesde, C04);
                d.Busco_Impresos_Cabinas(fdesde, C03);
                d.Busco_Impresos_Cabinas(fdesde, C02);
                d.Busco_Impresos_Cabinas(fdesde, C01);
                totimpresionescabinas.Text = FrmLogin.total_cabinas_impresas + " Cabinas Impresas";
                totimpresionespupitres.Text = FrmLogin.total_pupitres_impresos + " Pupitres Impresos";
                total_impresiones = Convert.ToDouble(FrmLogin.total_cabinas_impresas) + Convert.ToDouble(FrmLogin.total_pupitres_impresos);
                totimpresiones.Text = "Total Impresiones " + total_impresiones;
                panel2.Visible = true;
                panel5.Visible = true;
                panel6.Visible = true;
                panel3.Visible = false;
                panel4.Visible = false;
                panel7.Visible = false;
                panel8.Visible = false;


                cuadro.Visible = true;
                new Importar().traigo_escudo_rival(txtidrival.Text, pictureBox3, pictureBox2, nombreequipo, cuadro );
                button3.Enabled = true;
                System.Windows.Forms.Cursor.Current = Cursors.Default;


            }

         else
            {
                txttorneo.Text  = "";
                txtidrival.Text  = "";
                fecnumero.Text = "";
                URL.Text = ""; 
                txtidevento.Text = "";
                pictureBox3.Image = null;
                pictureBox2.Visible=false ;
                vs.Visible = false;
                d.Limpio(F7A28);
                d.Limpio(F7A27);
                d.Limpio(F7A26);
                d.Limpio(F7A25);
                d.Limpio(F7A24);
                d.Limpio(F7A23);
                d.Limpio(F7A22);
                d.Limpio(F7A21);
                d.Limpio(F7A20);
                d.Limpio(F7A19);
                d.Limpio(F7A18);
                d.Limpio(F7A17);
                d.Limpio(F7A16);
                d.Limpio(F7A15);
                d.Limpio(F7A14);
                d.Limpio(F7A13);
                d.Limpio(F7A12);
                d.Limpio(F7A11);
                d.Limpio(F7A10);
                d.Limpio(F7A09);
                d.Limpio(F7A08);
                d.Limpio(F7A07);
                d.Limpio(F7A06);
                d.Limpio(F7A05);
                d.Limpio(F7A04);
                d.Limpio(F7A03);
                d.Limpio(F7A02);
                d.Limpio(F7A01);
                d.Limpio(F7A28);
                d.Limpio(F7A27);
                d.Limpio(F7A26);
                d.Limpio(F7A25);
                d.Limpio(F7A24);
                d.Limpio(F7A23);
                d.Limpio(F7A22);
                d.Limpio(F7A21);
                d.Limpio(F7A20);
                d.Limpio(F7A19);
                d.Limpio(F7A18);
                d.Limpio(F7A17);
                d.Limpio(F7A16);
                d.Limpio(F7A15);
                d.Limpio(F7A14);
                d.Limpio(F7A13);
                d.Limpio(F7A12);
                d.Limpio(F7A11);
                d.Limpio(F7A10);
                d.Limpio(F7A09);
                d.Limpio(F7A08);
                d.Limpio(F7A07);
                d.Limpio(F7A06);
                d.Limpio(F7A05);
                d.Limpio(F7A04);
                d.Limpio(F7A03);
                d.Limpio(F7A02);
                d.Limpio(F7A01);
                d.Limpio(F6A24);
                d.Limpio(F6A23);
                d.Limpio(F6A22);
                d.Limpio(F6A21);
                d.Limpio(F6A20);
                d.Limpio(F6A19);
                d.Limpio(F6A18);
                d.Limpio(F6A17);
                d.Limpio(F6A16);
                d.Limpio(F6A15);
                d.Limpio(F6A14);
                d.Limpio(F6A13);
                d.Limpio(F6A12);
                d.Limpio(F6A11);
                d.Limpio(F6A10);
                d.Limpio(F6A09);
                d.Limpio(F6A08);
                d.Limpio(F6A07);
                d.Limpio(F6A06);
                d.Limpio(F6A05);
                d.Limpio(F6A04);
                d.Limpio(F6A03);
                d.Limpio(F6A02);
                d.Limpio(F6A01);
                d.Limpio(F5A18);
                d.Limpio(F5A17);
                d.Limpio(F5A16);
                d.Limpio(F5A15);
                d.Limpio(F5A14);
                d.Limpio(F5A13);
                d.Limpio(F5A12);
                d.Limpio(F5A11);
                d.Limpio(F5A10);
                d.Limpio(F5A09);
                d.Limpio(F5A08);
                d.Limpio(F5A07);
                d.Limpio(F5A06);
                d.Limpio(F5A05);
                d.Limpio(F5A04);
                d.Limpio(F5A03);
                d.Limpio(F5A02);
                d.Limpio(F5A01);
                d.Limpio(F4A53);
                d.Limpio(F4A52);
                d.Limpio(F4A51);
                d.Limpio(F4A50);
                d.Limpio(F4A49);
                d.Limpio(F4A48);
                d.Limpio(F4A47);
                d.Limpio(F4A46);
                d.Limpio(F4A45);
                d.Limpio(F4A44);
                d.Limpio(F4A43);
                d.Limpio(F4A42);
                d.Limpio(F4A41);
                d.Limpio(F4A40);
                d.Limpio(F4A39);
                d.Limpio(F4A38);
                d.Limpio(F4A37);
                d.Limpio(F4A36);
                d.Limpio(F4A35);
                d.Limpio(F4A34);
                d.Limpio(F4A33);
                d.Limpio(F4A32);
                d.Limpio(F4A31);
                d.Limpio(F4A30);
                d.Limpio(F4A29);
                d.Limpio(F4A28);
                d.Limpio(F4A27);
                d.Limpio(F4A26);
                d.Limpio(F4A25);
                d.Limpio(F4A24);
                d.Limpio(F4A23);
                d.Limpio(F4A22);
                d.Limpio(F4A21);
                d.Limpio(F4A20);
                d.Limpio(F4A19);
                d.Limpio(F4A18);
                d.Limpio(F4A17);
                d.Limpio(F4A16);
                d.Limpio(F4A15);
                d.Limpio(F4A14);
                d.Limpio(F4A13);
                d.Limpio(F4A12);
                d.Limpio(F4A11);
                d.Limpio(F4A10);
                d.Limpio(F4A09);
                d.Limpio(F4A08);
                d.Limpio(F4A07);
                d.Limpio(F4A06);
                d.Limpio(F4A05);
                d.Limpio(F4A04);
                d.Limpio(F4A03);
                d.Limpio(F4A02);
                d.Limpio(F4A01);
                d.Limpio(F3A52);
                d.Limpio(F3A51);
                d.Limpio(F3A50);
                d.Limpio(F3A49);
                d.Limpio(F3A48);
                d.Limpio(F3A47);
                d.Limpio(F3A46);
                d.Limpio(F3A45);
                d.Limpio(F3A44);
                d.Limpio(F3A43);
                d.Limpio(F3A42);
                d.Limpio(F3A41);
                d.Limpio(F3A40);
                d.Limpio(F3A39);
                d.Limpio(F3A38);
                d.Limpio(F3A37);
                d.Limpio(F3A36);
                d.Limpio(F3A35);
                d.Limpio(F3A34);
                d.Limpio(F3A33);
                d.Limpio(F3A32);
                d.Limpio(F3A31);
                d.Limpio(F3A30);
                d.Limpio(F3A29);
                d.Limpio(F3A28);
                d.Limpio(F3A27);
                d.Limpio(F3A26);
                d.Limpio(F3A25);
                d.Limpio(F3A24);
                d.Limpio(F3A23);
                d.Limpio(F3A22);
                d.Limpio(F3A21);
                d.Limpio(F3A20);
                d.Limpio(F3A19);
                d.Limpio(F3A18);
                d.Limpio(F3A17);
                d.Limpio(F3A16);
                d.Limpio(F3A15);
                d.Limpio(F3A14);
                d.Limpio(F3A13);
                d.Limpio(F3A12);
                d.Limpio(F3A11);
                d.Limpio(F3A10);
                d.Limpio(F3A09);
                d.Limpio(F3A08);
                d.Limpio(F3A07);
                d.Limpio(F3A06);
                d.Limpio(F3A05);
                d.Limpio(F3A04);
                d.Limpio(F3A03);
                d.Limpio(F3A02);
                d.Limpio(F3A01);
                d.Limpio(F2A52);
                d.Limpio(F2A51);
                d.Limpio(F2A50);
                d.Limpio(F2A49);
                d.Limpio(F2A48);
                d.Limpio(F2A47);
                d.Limpio(F2A46);
                d.Limpio(F2A45);
                d.Limpio(F2A44);
                d.Limpio(F2A43);
                d.Limpio(F2A42);
                d.Limpio(F2A41);
                d.Limpio(F2A40);
                d.Limpio(F2A39);
                d.Limpio(F2A38);
                d.Limpio(F2A37);
                d.Limpio(F2A36);
                d.Limpio(F2A35);
                d.Limpio(F2A34);
                d.Limpio(F2A33);
                d.Limpio(F2A32);
                d.Limpio(F2A31);
                d.Limpio(F2A30);
                d.Limpio(F2A29);
                d.Limpio(F2A28);
                d.Limpio(F2A27);
                d.Limpio(F2A26);
                d.Limpio(F2A25);
                d.Limpio(F2A24);
                d.Limpio(F2A23);
                d.Limpio(F2A22);
                d.Limpio(F2A21);
                d.Limpio(F2A20);
                d.Limpio(F2A19);
                d.Limpio(F2A18);
                d.Limpio(F2A17);
                d.Limpio(F2A16);
                d.Limpio(F2A15);
                d.Limpio(F2A14);
                d.Limpio(F2A13);
                d.Limpio(F2A12);
                d.Limpio(F2A11);
                d.Limpio(F2A10);
                d.Limpio(F2A09);
                d.Limpio(F2A08);
                d.Limpio(F2A07);
                d.Limpio(F2A06);
                d.Limpio(F2A05);
                d.Limpio(F2A04);
                d.Limpio(F2A03);
                d.Limpio(F2A02);
                d.Limpio(F2A01);
                d.Limpio(F1A52);
                d.Limpio(F1A51);
                d.Limpio(F1A50);
                d.Limpio(F1A49);
                d.Limpio(F1A48);
                d.Limpio(F1A47);
                d.Limpio(F1A46);
                d.Limpio(F1A45);
                d.Limpio(F1A44);
                d.Limpio(F1A43);
                d.Limpio(F1A42);
                d.Limpio(F1A41);
                d.Limpio(F1A40);
                d.Limpio(F1A39);
                d.Limpio(F1A38);
                d.Limpio(F1A37);
                d.Limpio(F1A36);
                d.Limpio(F1A35);
                d.Limpio(F1A34);
                d.Limpio(F1A33);
                d.Limpio(F1A32);
                d.Limpio(F1A31);
                d.Limpio(F1A30);
                d.Limpio(F1A29);
                d.Limpio(F1A28);
                d.Limpio(F1A27);
                d.Limpio(F1A26);
                d.Limpio(F1A25);
                d.Limpio(F1A24);
                d.Limpio(F1A23);
                d.Limpio(F1A22);
                d.Limpio(F1A21);
                d.Limpio(F1A20);
                d.Limpio(F1A19);
                d.Limpio(F1A18);
                d.Limpio(F1A17);
                d.Limpio(F1A16);
                d.Limpio(F1A15);
                d.Limpio(F1A14);
                d.Limpio(F1A13);
                d.Limpio(F1A12);
                d.Limpio(F1A11);
                d.Limpio(F1A10);
                d.Limpio(F1A09);
                d.Limpio(F1A08);
                d.Limpio(F1A07);
                d.Limpio(F1A06);
                d.Limpio(F1A05);
                d.Limpio(F1A04);
                d.Limpio(F1A03);
                d.Limpio(F1A02);
                d.Limpio(F1A01);
                d.Limpio(C17);
                d.Limpio(C16);
                d.Limpio(C15);
                d.Limpio(C14);
                d.Limpio(C13);
                d.Limpio(C12);
                d.Limpio(C11);
                d.Limpio(C10);
                d.Limpio(C09);
                d.Limpio(C08);
                d.Limpio(C07);
                d.Limpio(C06);
                d.Limpio(C05);
                d.Limpio(C04);
                d.Limpio(C03);
                d.Limpio(C02);
                d.Limpio(C01);
                panel2.Visible = false;
                panel3.Visible = false;
                panel4.Visible = false;
                panel5.Visible = false;
                panel6.Visible = false;
                panel7.Visible = false;
                panel8.Visible = false;
            //    button3.Enabled = false;
                if (cbeventos.Items.Count > 0)
                    cbeventos.Items.Clear();
                   


                MessageBox.Show("No se encontraron datos para esta fecha" );


            }




        }

        private void C05_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (C05.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("C05", fdesde, 1, URL.Text);
                frm.ShowDialog();
                this.Show();
            }

        }

        private void F7A25_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F7A25.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F7A25", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F7A24_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F7A24.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F7A24", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F7A23_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F7A23.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F7A23", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F7A22_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F7A22.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F7A22", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F7A21_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);
            if (F7A21.BackColor != Color.White)
            {

                FrmDatosLugar frm = new FrmDatosLugar("F7A21", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F7A20_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F7A20.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F7A20", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F7A19_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F7A19.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F7A19", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F7A18_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F7A18.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F7A18", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F7A17_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F7A17.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F7A17", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F7A16_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F7A16.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F7A16", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }

        }

        private void F7A15_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F7A15.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F7A15", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F7A14_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F7A14.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F7A14", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F7A13_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F7A13.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F7A13", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F7A12_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F7A12.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F7A12", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F7A11_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F7A11.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F7A11", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F7A10_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);
            if (F7A10.BackColor != Color.White)
            {

                FrmDatosLugar frm = new FrmDatosLugar("F7A10", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F7A09_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);
            if (F7A09.BackColor != Color.White)
            {

                FrmDatosLugar frm = new FrmDatosLugar("F7A09", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F7A08_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F7A08.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F7A08", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F7A07_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F7A07.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F7A07", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F7A06_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F7A06.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F7A06", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F7A05_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F7A05.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F7A05", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F7A04_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F7A04.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F7A04", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F7A03_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F7A03.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F7A03", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F7A02_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F7A02.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F7A02", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F7A01_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F7A01.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F7A01", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F6A24_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);
            if (F6A24.BackColor != Color.White)
            {

                FrmDatosLugar frm = new FrmDatosLugar("F6A24", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F6A23_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F6A23.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F6A23", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F6A21_Click_1(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F6A21.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F6A21", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F6A20_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F6A20.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F6A20", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F6A19_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F6A19.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F6A19", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F6A18_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);
            if (F6A18.BackColor != Color.White)
            {

                FrmDatosLugar frm = new FrmDatosLugar("F6A18", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F6A17_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F6A17.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F6A17", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F6A16_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F6A16.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F6A16", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F6A15_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F6A15.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F6A15", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F6A14_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F6A14.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F6A14", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F6A13_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F6A13.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F6A13", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F6A12_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F6A12.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F6A12", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F6A11_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F6A11.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F6A11", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F6A10_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F6A10.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F6A10", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F6A09_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F6A09.BackColor != Color.White)
            { 
                FrmDatosLugar frm = new FrmDatosLugar("F6A09", fdesde, 2, URL.Text);
            frm.ShowDialog();
            this.Show();
        }
        }

        private void F6A08_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F6A08.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F6A08", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F6A07_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F6A07.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F6A07", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F6A06_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);
            if (F6A06.BackColor != Color.White)
            {

                FrmDatosLugar frm = new FrmDatosLugar("F6A06", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F6A05_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F6A05.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F6A05", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F6A04_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F6A04.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F6A04", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F6A03_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F6A03.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F6A03", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F6A02_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F6A02.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F6A02", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F6A01_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F6A01.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F6A01", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F5A17_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F5A17.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F5A17", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F5A16_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F5A16.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F5A16", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void button34_Click(object sender, EventArgs e)
        {

        }

        private void F5A15_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F5A15.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F5A15", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F5A14_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F5A14.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F5A14", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F5A13_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F5A13.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F5A13", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F5A12_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F5A12.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F5A12", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F5A11_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F5A11.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F5A11", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F5A10_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F5A10.BackColor != Color.White)
            {

                FrmDatosLugar frm = new FrmDatosLugar("F5A10", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F5A09_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);
            if (F5A09.BackColor != Color.White)
            {

                FrmDatosLugar frm = new FrmDatosLugar("F5A09", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F5A08_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);
            if (F5A08.BackColor != Color.White)
            {

                FrmDatosLugar frm = new FrmDatosLugar("F5A08", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F5A07_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F5A07.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F5A07", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F5A06_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F5A06.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F5A06", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F5A05_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F5A05.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F5A05", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F5A04_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F5A04.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F5A04", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F5A03_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F5A03.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F5A03", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F5A02_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F5A02.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F5A02", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F5A01_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F5A01.BackColor != Color.White)
            {

                FrmDatosLugar frm = new FrmDatosLugar("F5A01", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F4A53_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F4A53.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F4A53", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F4A52_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F4A52.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F4A52", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F4A51_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F4A51.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F4A51", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F4A50_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F4A50.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F4A50", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F4A49_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F4A49.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F4A49", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F4A48_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);
            if (F4A48.BackColor != Color.White)
            {

                FrmDatosLugar frm = new FrmDatosLugar("F4A48", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F4A47_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F4A47.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F4A47", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F4A45_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F4A45.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F4A45", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }


        private void F4A46_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F4A46.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F4A46", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F4A44_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F4A44.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F4A44", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F4A43_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F4A43.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F4A43", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F4A42_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F4A42.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F4A42", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F4A41_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F4A41.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F4A41", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }

        }
        private void F4A40_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);
            if (F4A40.BackColor != Color.White)
            {

                FrmDatosLugar frm = new FrmDatosLugar("F4A40", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F4A39_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F4A39.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F4A39", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F4A38_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F4A38.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F4A38", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F4A37_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F4A37.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F4A37", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F4A36_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F4A36.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F4A36", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F4A35_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F4A35.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F4A35", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F4A34_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F4A34.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F4A34", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F4A33_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F4A33.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F4A33", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F4A32_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);
            if (F4A32.BackColor != Color.White)
            {

                FrmDatosLugar frm = new FrmDatosLugar("F4A32", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F4A31_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F4A31.BackColor != Color.White)
            {

                FrmDatosLugar frm = new FrmDatosLugar("F4A31", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F4A30_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);
            if (F4A30.BackColor != Color.White)
            {

                FrmDatosLugar frm = new FrmDatosLugar("F4A30", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F4A29_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);
            if (F4A29.BackColor != Color.White)
            {

                FrmDatosLugar frm = new FrmDatosLugar("F4A29", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F4A28_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);
            if (F4A28.BackColor != Color.White)
            {

                FrmDatosLugar frm = new FrmDatosLugar("F4A28", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F4A27_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F4A27.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F4A27", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F4A26_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);
            if (F4A26.BackColor != Color.White)
            {

                FrmDatosLugar frm = new FrmDatosLugar("F4A26", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F4A25_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F4A25.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F4A25", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F4A24_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F4A24.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F4A24", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F4A23_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F4A23.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F4A23", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F4A22_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F4A22.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F4A22", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F4A21_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F4A21.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F4A21", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F4A20_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F4A20.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F4A20", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F4A19_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F4A19.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F4A19", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F4A18_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F4A18.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F4A18", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F4A17_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F4A17.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F4A17", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F4A16_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F4A16.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F4A16", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F4A15_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F4A15.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F4A15", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F4A14_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);
            if (F4A14.BackColor != Color.White)
            {

                FrmDatosLugar frm = new FrmDatosLugar("F4A14", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F4A13_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F4A13.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F4A13", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F4A12_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F4A12.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F4A12", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F4A11_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F4A11.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F4A11", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F4A10_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F4A10.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F4A10", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F4A09_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F4A09.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F4A09", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F4A08_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);
            if (F4A08.BackColor != Color.White)
            {

                FrmDatosLugar frm = new FrmDatosLugar("F4A08", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F4A07_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);
            if (F4A07.BackColor != Color.White)
            {

                FrmDatosLugar frm = new FrmDatosLugar("F4A07", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F4A06_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F4A06.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F4A06", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F4A05_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);
            if (F4A05.BackColor != Color.White)
            {

                FrmDatosLugar frm = new FrmDatosLugar("F4A05", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F4A04_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F4A04.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F4A04", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F4A03_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);
            if (F4A03.BackColor != Color.White)
            {

                FrmDatosLugar frm = new FrmDatosLugar("F4A03", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F4A02_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);
            if (F4A02.BackColor != Color.White)
            {

                FrmDatosLugar frm = new FrmDatosLugar("F4A02", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F4A01_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);
            if (F4A01.BackColor != Color.White)
            {

                FrmDatosLugar frm = new FrmDatosLugar("F4A01", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F3A52_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F3A52.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F3A52", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F3A51_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F3A51.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F3A51", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F3A50_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);
            if (F3A50.BackColor != Color.White)
            {

                FrmDatosLugar frm = new FrmDatosLugar("F3A50", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F3A49_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F3A49.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F3A49", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F3A48_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F3A49.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F3A48", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F3A47_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);
            if (F3A47.BackColor != Color.White)
            {

                FrmDatosLugar frm = new FrmDatosLugar("F3A47", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F3A46_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F3A46.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F3A46", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F3A45_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F3A45.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F3A45", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F3A44_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F3A44.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F3A44", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F3A43_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);
            if (F3A43.BackColor != Color.White)
            {

                FrmDatosLugar frm = new FrmDatosLugar("F3A43", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F3A42_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F3A42.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F3A42", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F3A41_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F3A41.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F3A41", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F3A40_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F3A40.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F3A40", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F3A39_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F3A39.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F3A39", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F3A38_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F3A38.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F3A38", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F3A37_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F3A37.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F3A37", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F3A36_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F3A36.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F3A36", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F3A35_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F3A35.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F3A35", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F3A34_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F3A34.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F3A34", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F3A33_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F3A33.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F3A33", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F3A32_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F3A32.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F3A32", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F3A31_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F3A31.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F3A31", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F3A30_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F3A30.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F3A30", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F3A29_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F3A29.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F3A29", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F3A28_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F3A28.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F3A28", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F3A27_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F3A27.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F3A27", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F3A26_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F3A26.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F3A26", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F3A25_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F3A25.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F3A25", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F3A24_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F3A24.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F3A24", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }

        }

        private void F3A23_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);
            if (F3A23.BackColor != Color.White)
            {

                FrmDatosLugar frm = new FrmDatosLugar("F3A23", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F3A22_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F3A22.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F3A22", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F3A21_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F3A21.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F3A21", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F3A20_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F3A20.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F3A20", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F3A19_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);
            if (F3A19.BackColor != Color.White)
            {

                FrmDatosLugar frm = new FrmDatosLugar("F3A19", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F3A18_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F3A18.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F3A18", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F3A17_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F3A17.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F3A17", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F3A16_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F3A16.BackColor != Color.White)
            {

                FrmDatosLugar frm = new FrmDatosLugar("F3A216", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F3A15_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F3A15.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F3A15", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F3A14_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F3A14.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F3A14", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F3A13_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);
            if (F3A13.BackColor != Color.White)
            {

                FrmDatosLugar frm = new FrmDatosLugar("F3A13", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F3A12_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F3A12.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F3A12", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F3A11_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);
            if (F3A11.BackColor != Color.White)
            {

                FrmDatosLugar frm = new FrmDatosLugar("F3A11", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F3A10_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F3A10.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F3A10", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F3A09_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F3A09.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F3A09", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F3A08_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);
            if (F3A08.BackColor != Color.White)
            {

                FrmDatosLugar frm = new FrmDatosLugar("F3A08", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F3A07_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F3A07.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F3A07", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F3A06_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F3A06.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F3A06", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F3A05_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F3A05.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F3A05", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F3A04_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F3A04.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F3A04", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F3A03_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);
            if (F3A03.BackColor != Color.White)
            {

                FrmDatosLugar frm = new FrmDatosLugar("F3A03", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F3A02_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F3A02.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F3A02", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F3A01_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F3A01.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F3A01", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F2A52_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F2A52.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F2A52", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F2A51_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F2A51.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F2A51", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F2A50_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F2A50.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F2A50", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F2A49_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F2A49.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F2A49", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();

            }
        }

        private void F2A48_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F2A48.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F2A48", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F2A47_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F2A47.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F2A47", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F2A46_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);
            if (F2A46.BackColor != Color.White)
            {

                FrmDatosLugar frm = new FrmDatosLugar("F2A46", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F2A45_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F2A45.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F2A45", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F2A44_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F2A44.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F2A44", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F2A43_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F2A43.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F2A43", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F2A42_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F2A42.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F2A42", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F2A41_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);
            if (F2A41.BackColor != Color.White)
            {

                FrmDatosLugar frm = new FrmDatosLugar("F2A41", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F2A40_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F2A40.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F2A40", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F2A39_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F2A39.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F2A39", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F2A38_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);
            if (F2A38.BackColor != Color.White)
            {

                FrmDatosLugar frm = new FrmDatosLugar("F2A38", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F2A37_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F2A37.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F2A37", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F2A36_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F2A36.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F2A36", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F2A35_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F2A35.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F2A35", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F2A34_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F2A34.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F2A34", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F2A33_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F2A33.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F2A33", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F2A32_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);
            if (F2A32.BackColor != Color.White)
            {

                FrmDatosLugar frm = new FrmDatosLugar("F2A32", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F2A31_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F2A31.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F2A31", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F2A30_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);
            if (F2A30.BackColor != Color.White)
            {

                FrmDatosLugar frm = new FrmDatosLugar("F2A30", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F2A29_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F2A29.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F2A29", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            } 
        }

        private void F2A28_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F2A28.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F2A28", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F2A27_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);
            if (F2A27.BackColor != Color.White)
            {

                FrmDatosLugar frm = new FrmDatosLugar("F2A27", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F2A26_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F2A26.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F2A26", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F2A25_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F2A25.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F2A25", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F2A24_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F2A24.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F2A24", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F2A23_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F2A23.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F2A23", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F2A22_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F2A22.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F2A22", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F2A21_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F2A21.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F2A21", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F2A20_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F2A20.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F2A20", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F2A19_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F2A19.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F2A19", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F2A18_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F2A18.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F2A18", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F2A17_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F2A17.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F2A17", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F2A16_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F2A16.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F2A16", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F2A15_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F2A15.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F2A15", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F2A14_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F2A14.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F2A14", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F2A13_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F2A13.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F2A13", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F2A12_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F2A12.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F2A12", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F2A11_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F2A11.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F2A11", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F2A10_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F2A10.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F2A10", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F2A09_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F2A09.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F2A09", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F2A08_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F2A08.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F2A08", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F2A07_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F2A07.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F2A07", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F2A06_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F2A06.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F2A06", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F2A05_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F2A05.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F2A05", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F2A04_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F2A04.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F2A04", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F2A03_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F2A03.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F2A03", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F2A02_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F2A02.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F2A02", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F2A01_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);
            if (F2A01.BackColor != Color.White)
            {

                FrmDatosLugar frm = new FrmDatosLugar("F2A01", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F1A52_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F1A52.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F1A52", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F1A51_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);
            if (F1A51.BackColor != Color.White)
            {

                FrmDatosLugar frm = new FrmDatosLugar("F1A51", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F1A50_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);
            if (F1A50.BackColor != Color.White)
            {

                FrmDatosLugar frm = new FrmDatosLugar("F1A50", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F1A49_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F1A49.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F1A49", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F1A48_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F1A48.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F1A48", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F1A47_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F1A47.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F1A47", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F1A46_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F1A46.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F1A46", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F1A45_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);
            if (F1A45.BackColor != Color.White)
            {

                FrmDatosLugar frm = new FrmDatosLugar("F1A45", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F1A44_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F1A44.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F1A44", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F1A43_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F1A43.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F1A43", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F1A42_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F1A42.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F1A42", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F1A41_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);
            if (F1A41.BackColor != Color.White)
            {

                FrmDatosLugar frm = new FrmDatosLugar("F1A41", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F1A40_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);
            if (F1A40.BackColor != Color.White)
            {

                FrmDatosLugar frm = new FrmDatosLugar("F1A40", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F1A39_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F1A39.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F1A39", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F1A38_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F1A38.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F1A38", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F1A37_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F1A37.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F1A37", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F1A36_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F1A36.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F1A36", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F1A35_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);
            if (F1A35.BackColor != Color.White)
            {

                FrmDatosLugar frm = new FrmDatosLugar("F1A35", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F1A34_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F1A34.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F1A34", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F1A33_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F1A33.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F1A33", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F1A32_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F1A32.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F1A32", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F1A31_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F1A31.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F1A31", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F1A29_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F1A29.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F1A29", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F1A28_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F1A28.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F1A28", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F1A27_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F1A27.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F1A27", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F1A26_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);
            if (F1A26.BackColor != Color.White)
            {

                FrmDatosLugar frm = new FrmDatosLugar("F1A26", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F1A25_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F1A25.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F1A25", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F1A24_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F1A24.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F1A24", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F1A23_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);
            if (F1A23.BackColor != Color.White)
            {

                FrmDatosLugar frm = new FrmDatosLugar("F1A23", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F1A22_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F1A22.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F1A22", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F1A21_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F1A21.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F1A21", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F1A20_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F1A20.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F1A20", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F1A19_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F1A19.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F1A19", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F1A18_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);
            if (F1A18.BackColor != Color.White)
            {

                FrmDatosLugar frm = new FrmDatosLugar("F1A18", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F1A17_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);
            if (F1A17.BackColor != Color.White)
            {

                FrmDatosLugar frm = new FrmDatosLugar("F1A17", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F1A16_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F1A16.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F1A16", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F1A15_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);
            if (F1A15.BackColor != Color.White)
            {

                FrmDatosLugar frm = new FrmDatosLugar("F1A15", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F1A14_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);
            if (F1A14.BackColor != Color.White)
            {

                FrmDatosLugar frm = new FrmDatosLugar("F1A14", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F1A13_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F1A13.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F1A13", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F1A12_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);
            if (F1A12.BackColor != Color.White)
            {

                FrmDatosLugar frm = new FrmDatosLugar("F1A12", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F1A11_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F1A11.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F1A11", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F1A10_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F1A10.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F1A10", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F1A09_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F1A09.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F1A09", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F1A08_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F1A08.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F1A08", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F1A07_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F1A07.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F1A07", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F1A06_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);
            if (F1A06.BackColor != Color.White)
            {

                FrmDatosLugar frm = new FrmDatosLugar("F1A06", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F1A05_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);
            if (F1A05.BackColor != Color.White)
            {

                FrmDatosLugar frm = new FrmDatosLugar("F1A05", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F1A04_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);
            if (F1A04.BackColor != Color.White)
            {

                FrmDatosLugar frm = new FrmDatosLugar("F1A04", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F1A03_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F1A03.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F1A03", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F1A02_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (F1A02.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("F1A02", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void F1A01_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);
            if (F1A01.BackColor != Color.White)
            {

                FrmDatosLugar frm = new FrmDatosLugar("F1A01", fdesde, 2, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }
        private void C04_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (C04.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("C04", fdesde, 1, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void C17_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (C17.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("C17", fdesde, 1, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void C16_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (C16.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("C16", fdesde, 1, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void C15_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (C15.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("C15", fdesde, 1, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void C14_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);
            if (C14.BackColor != Color.White)
            {

                FrmDatosLugar frm = new FrmDatosLugar("C14", fdesde, 1, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void C13_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (C13.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("C13", fdesde, 1, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void C12_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (C12.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("C12", fdesde, 1, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void C11_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (C11.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("C11", fdesde, 1, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void C10_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (C10.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("C10", fdesde, 1, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void C09_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);
            if (C09.BackColor != Color.White)
            {

                FrmDatosLugar frm = new FrmDatosLugar("C09", fdesde, 1, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void C08_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (C08.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("C08", fdesde, 1, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void C07_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (C07.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("C07", fdesde, 1, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void C06_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);
            if (C06.BackColor != Color.White)
            {

                FrmDatosLugar frm = new FrmDatosLugar("C06", fdesde, 1, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void C03_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (C03.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("C03", fdesde, 1, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void C02_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (C02.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("C02", fdesde, 1, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void C01_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);

            if (C01.BackColor != Color.White)
            {
                FrmDatosLugar frm = new FrmDatosLugar("C01", fdesde, 1, URL.Text);
                frm.ShowDialog();
                this.Show();
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtidrival_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            string criterio = "";

            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
            criterio = "Select a.Id_Evento, a.Nombre_Evento, a.Campeonato, a.Fecha, a.url, a.Numero_Fecha, a.Rival, a.Id_Rival, a.Estado, b.Descripcion From eventos AS a INNER JOIN Estados AS b ON a.Estado = b.Estado ORDER BY a.Fecha";
            new Importar().muestro_eventos(dgvEventos, criterio);
            groupBox1.Visible = true;
            System.Windows.Forms.Cursor.Current = Cursors.Default;
        }

        private void dgvEventos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtidevento.Text = Convert.ToString(this.dgvEventos.CurrentRow.Cells[3].Value);
            Id_evento.Text = txtidevento.Text;
            estado_evento.Text = Convert.ToString(this.dgvEventos.CurrentRow.Cells[5].Value);
            new Evento().Traigo_Datos_Evento(txttorneo, txtevento, URL , fecnumero, Id_evento, lafecha, textIdRival, estado_evento);
            pdesde.Text = Convert.ToDateTime(lafecha.Text).ToString("yyyy-MM-dd");
            groupBox1.Visible = false;
            button1.Enabled = true;
        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void button20_Click(object sender, EventArgs e)
        {
            int cont = 0;
            string Id_impresion = "";
            string fdesde = Convert.ToString(pdesde.Text).Substring(0, 10);


            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
            FrmLogin.total_cabinas_faltantes = 0;
            FrmLogin.total_cabinas_entrantes = 0;
            FrmLogin.total_pupitres_faltantes = 0;
            FrmLogin.total_pupitres_entrantes = 0;


            Evento d = new Evento();
            d.Limpio_Rojo(F7A28, fdesde, 2);
            d.Limpio_Rojo(F7A27, fdesde, 2);
            d.Limpio_Rojo(F7A26, fdesde, 2);
            d.Limpio_Rojo(F7A25, fdesde, 2);
            d.Limpio_Rojo(F7A24, fdesde, 2);
            d.Limpio_Rojo(F7A23, fdesde, 2);
            d.Limpio_Rojo(F7A22, fdesde, 2);
            d.Limpio_Rojo(F7A21, fdesde, 2);
            d.Limpio_Rojo(F7A20, fdesde, 2);
            d.Limpio_Rojo(F7A19, fdesde, 2);
            d.Limpio_Rojo(F7A18, fdesde, 2);
            d.Limpio_Rojo(F7A17, fdesde, 2);
            d.Limpio_Rojo(F7A16, fdesde, 2);
            d.Limpio_Rojo(F7A15, fdesde, 2);
            d.Limpio_Rojo(F7A14, fdesde, 2);
            d.Limpio_Rojo(F7A13, fdesde, 2);
            d.Limpio_Rojo(F7A12, fdesde, 2);
            d.Limpio_Rojo(F7A11, fdesde, 2);
            d.Limpio_Rojo(F7A10, fdesde, 2);
            d.Limpio_Rojo(F7A09, fdesde, 2);
            d.Limpio_Rojo(F7A08, fdesde, 2);
            d.Limpio_Rojo(F7A07, fdesde, 2);
            d.Limpio_Rojo(F7A06, fdesde, 2);
            d.Limpio_Rojo(F7A05, fdesde, 2);
            d.Limpio_Rojo(F7A04, fdesde, 2);
            d.Limpio_Rojo(F7A03, fdesde, 2);
            d.Limpio_Rojo(F7A02, fdesde, 2);
            d.Limpio_Rojo(F7A01, fdesde, 2);
            d.Limpio_Rojo(F7A28, fdesde, 2);
            d.Limpio_Rojo(F7A27, fdesde, 2);
            d.Limpio_Rojo(F7A26, fdesde, 2);
            d.Limpio_Rojo(F7A25, fdesde, 2);
            d.Limpio_Rojo(F7A24, fdesde, 2);
            d.Limpio_Rojo(F7A23, fdesde, 2);
            d.Limpio_Rojo(F7A22, fdesde, 2);
            d.Limpio_Rojo(F7A21, fdesde, 2);
            d.Limpio_Rojo(F7A20, fdesde, 2);
            d.Limpio_Rojo(F7A19, fdesde, 2);
            d.Limpio_Rojo(F7A18, fdesde, 2);
            d.Limpio_Rojo(F7A17, fdesde, 2);
            d.Limpio_Rojo(F7A16, fdesde, 2);
            d.Limpio_Rojo(F7A15, fdesde, 2);
            d.Limpio_Rojo(F7A14, fdesde, 2);
            d.Limpio_Rojo(F7A13, fdesde, 2);
            d.Limpio_Rojo(F7A12, fdesde, 2);
            d.Limpio_Rojo(F7A11, fdesde, 2);
            d.Limpio_Rojo(F7A10, fdesde, 2);
            d.Limpio_Rojo(F7A09, fdesde, 2);
            d.Limpio_Rojo(F7A08, fdesde, 2);
            d.Limpio_Rojo(F7A07, fdesde, 2);
            d.Limpio_Rojo(F7A06, fdesde, 2);
            d.Limpio_Rojo(F7A05, fdesde, 2);
            d.Limpio_Rojo(F7A04, fdesde, 2);
            d.Limpio_Rojo(F7A03, fdesde, 2);
            d.Limpio_Rojo(F7A02, fdesde, 2);
            d.Limpio_Rojo(F7A01, fdesde, 2);
            d.Limpio_Rojo(F6A24, fdesde, 2);
            d.Limpio_Rojo(F6A23, fdesde, 2);
            d.Limpio_Rojo(F6A22, fdesde, 2);
            d.Limpio_Rojo(F6A22, fdesde, 2);
            d.Limpio_Rojo(F6A20, fdesde, 2);
            d.Limpio_Rojo(F6A19, fdesde, 2);
            d.Limpio_Rojo(F6A18, fdesde, 2);
            d.Limpio_Rojo(F6A17, fdesde, 2);
            d.Limpio_Rojo(F6A16, fdesde, 2);
            d.Limpio_Rojo(F6A15, fdesde, 2);
            d.Limpio_Rojo(F6A14, fdesde, 2);
            d.Limpio_Rojo(F6A13, fdesde, 2);
            d.Limpio_Rojo(F6A12, fdesde, 2);
            d.Limpio_Rojo(F6A11, fdesde, 2);
            d.Limpio_Rojo(F6A10, fdesde, 2);
            d.Limpio_Rojo(F6A09, fdesde, 2);
            d.Limpio_Rojo(F6A08, fdesde, 2);
            d.Limpio_Rojo(F6A07, fdesde, 2);
            d.Limpio_Rojo(F6A06, fdesde, 2);
            d.Limpio_Rojo(F6A05, fdesde, 2);
            d.Limpio_Rojo(F6A04, fdesde, 2);
            d.Limpio_Rojo(F6A03, fdesde, 2);
            d.Limpio_Rojo(F6A02, fdesde, 2);
            d.Limpio_Rojo(F6A01, fdesde, 2);
            d.Limpio_Rojo(F5A18, fdesde, 2);
            d.Limpio_Rojo(F5A17, fdesde, 2);
            d.Limpio_Rojo(F5A16, fdesde, 2);
            d.Limpio_Rojo(F5A15, fdesde, 2);
            d.Limpio_Rojo(F5A14, fdesde, 2);
            d.Limpio_Rojo(F5A13, fdesde, 2);
            d.Limpio_Rojo(F5A12, fdesde, 2);
            d.Limpio_Rojo(F5A11, fdesde, 2);
            d.Limpio_Rojo(F5A10, fdesde, 2);
            d.Limpio_Rojo(F5A09, fdesde, 2);
            d.Limpio_Rojo(F5A08, fdesde, 2);
            d.Limpio_Rojo(F5A07, fdesde, 2);
            d.Limpio_Rojo(F5A06, fdesde, 2);
            d.Limpio_Rojo(F5A05, fdesde, 2);
            d.Limpio_Rojo(F5A04, fdesde, 2);
            d.Limpio_Rojo(F5A03, fdesde, 2);
            d.Limpio_Rojo(F5A02, fdesde, 2);
            d.Limpio_Rojo(F5A01, fdesde, 2);
            d.Limpio_Rojo(F4A53, fdesde, 2);
            d.Limpio_Rojo(F4A52, fdesde, 2);
            d.Limpio_Rojo(F4A51, fdesde, 2);
            d.Limpio_Rojo(F4A50, fdesde, 2);
            d.Limpio_Rojo(F4A49, fdesde, 2);
            d.Limpio_Rojo(F4A48, fdesde, 2);
            d.Limpio_Rojo(F4A47, fdesde, 2);
            d.Limpio_Rojo(F4A46, fdesde, 2);
            d.Limpio_Rojo(F4A45, fdesde, 2);
            d.Limpio_Rojo(F4A44, fdesde, 2);
            d.Limpio_Rojo(F4A43, fdesde, 2);
            d.Limpio_Rojo(F4A42, fdesde, 2);
            d.Limpio_Rojo(F4A41, fdesde, 2);
            d.Limpio_Rojo(F4A40, fdesde, 2);
            d.Limpio_Rojo(F4A39, fdesde, 2);
            d.Limpio_Rojo(F4A38, fdesde, 2);
            d.Limpio_Rojo(F4A37, fdesde, 2);
            d.Limpio_Rojo(F4A36, fdesde, 2);
            d.Limpio_Rojo(F4A35, fdesde, 2);
            d.Limpio_Rojo(F4A34, fdesde, 2);
            d.Limpio_Rojo(F4A33, fdesde, 2);
            d.Limpio_Rojo(F4A32, fdesde, 2);
            d.Limpio_Rojo(F4A31, fdesde, 2);
            d.Limpio_Rojo(F4A30, fdesde, 2);
            d.Limpio_Rojo(F4A29, fdesde, 2);
            d.Limpio_Rojo(F4A28, fdesde, 2);
            d.Limpio_Rojo(F4A27, fdesde, 2);
            d.Limpio_Rojo(F4A26, fdesde, 2);
            d.Limpio_Rojo(F4A25, fdesde, 2);
            d.Limpio_Rojo(F4A24, fdesde, 2);
            d.Limpio_Rojo(F4A23, fdesde, 2);
            d.Limpio_Rojo(F4A22, fdesde, 2);
            d.Limpio_Rojo(F4A21, fdesde, 2);
            d.Limpio_Rojo(F4A20, fdesde, 2);
            d.Limpio_Rojo(F4A19, fdesde, 2);
            d.Limpio_Rojo(F4A18, fdesde, 2);
            d.Limpio_Rojo(F4A17, fdesde, 2);
            d.Limpio_Rojo(F4A16, fdesde, 2);
            d.Limpio_Rojo(F4A15, fdesde, 2);
            d.Limpio_Rojo(F4A14, fdesde, 2);
            d.Limpio_Rojo(F4A13, fdesde, 2);
            d.Limpio_Rojo(F4A12, fdesde, 2);
            d.Limpio_Rojo(F4A11, fdesde, 2);
            d.Limpio_Rojo(F4A10, fdesde, 2);
            d.Limpio_Rojo(F4A09, fdesde, 2);
            d.Limpio_Rojo(F4A08, fdesde, 2);
            d.Limpio_Rojo(F4A07, fdesde, 2);
            d.Limpio_Rojo(F4A06, fdesde, 2);
            d.Limpio_Rojo(F4A05, fdesde, 2);
            d.Limpio_Rojo(F4A04, fdesde, 2);
            d.Limpio_Rojo(F4A03, fdesde, 2);
            d.Limpio_Rojo(F4A02, fdesde, 2);
            d.Limpio_Rojo(F4A01, fdesde, 2);
            d.Limpio_Rojo(F3A52, fdesde, 2);
            d.Limpio_Rojo(F3A51, fdesde, 2);
            d.Limpio_Rojo(F3A50, fdesde, 2);
            d.Limpio_Rojo(F3A49, fdesde, 2);
            d.Limpio_Rojo(F3A48, fdesde, 2);
            d.Limpio_Rojo(F3A47, fdesde, 2);
            d.Limpio_Rojo(F3A46, fdesde, 2);
            d.Limpio_Rojo(F3A45, fdesde, 2);
            d.Limpio_Rojo(F3A44, fdesde, 2);
            d.Limpio_Rojo(F3A43, fdesde, 2);
            d.Limpio_Rojo(F3A42, fdesde, 2);
            d.Limpio_Rojo(F3A41, fdesde, 2);
            d.Limpio_Rojo(F3A40, fdesde, 2);
            d.Limpio_Rojo(F3A39, fdesde, 2);
            d.Limpio_Rojo(F3A38, fdesde, 2);
            d.Limpio_Rojo(F3A37, fdesde, 2);
            d.Limpio_Rojo(F3A36, fdesde, 2);
            d.Limpio_Rojo(F3A35, fdesde, 2);
            d.Limpio_Rojo(F3A34, fdesde, 2);
            d.Limpio_Rojo(F3A33, fdesde, 2);
            d.Limpio_Rojo(F3A32, fdesde, 2);
            d.Limpio_Rojo(F3A31, fdesde, 2);
            d.Limpio_Rojo(F3A30, fdesde, 2);
            d.Limpio_Rojo(F3A29, fdesde, 2);
            d.Limpio_Rojo(F3A28, fdesde, 2);
            d.Limpio_Rojo(F3A27, fdesde, 2);
            d.Limpio_Rojo(F3A26, fdesde, 2);
            d.Limpio_Rojo(F3A25, fdesde, 2);
            d.Limpio_Rojo(F3A24, fdesde, 2);
            d.Limpio_Rojo(F3A23, fdesde, 2);
            d.Limpio_Rojo(F3A22, fdesde, 2);
            d.Limpio_Rojo(F3A21, fdesde, 2);
            d.Limpio_Rojo(F3A20, fdesde, 2);
            d.Limpio_Rojo(F3A19, fdesde, 2);
            d.Limpio_Rojo(F3A18, fdesde, 2);
            d.Limpio_Rojo(F3A17, fdesde, 2);
            d.Limpio_Rojo(F3A16, fdesde, 2);
            d.Limpio_Rojo(F3A15, fdesde, 2);
            d.Limpio_Rojo(F3A14, fdesde, 2);
            d.Limpio_Rojo(F3A13, fdesde, 2);
            d.Limpio_Rojo(F3A12, fdesde, 2);
            d.Limpio_Rojo(F3A11, fdesde, 2);
            d.Limpio_Rojo(F3A10, fdesde, 2);
            d.Limpio_Rojo(F3A09, fdesde, 2);
            d.Limpio_Rojo(F3A08, fdesde, 2);
            d.Limpio_Rojo(F3A07, fdesde, 2);
            d.Limpio_Rojo(F3A06, fdesde, 2);
            d.Limpio_Rojo(F3A05, fdesde, 2);
            d.Limpio_Rojo(F3A04, fdesde, 2);
            d.Limpio_Rojo(F3A03, fdesde, 2);
            d.Limpio_Rojo(F3A02, fdesde, 2);
            d.Limpio_Rojo(F3A01, fdesde, 2);
            d.Limpio_Rojo(F2A52, fdesde, 2);
            d.Limpio_Rojo(F2A51, fdesde, 2);
            d.Limpio_Rojo(F2A50, fdesde, 2);
            d.Limpio_Rojo(F2A49, fdesde, 2);
            d.Limpio_Rojo(F2A48, fdesde, 2);
            d.Limpio_Rojo(F2A47, fdesde, 2);
            d.Limpio_Rojo(F2A46, fdesde, 2);
            d.Limpio_Rojo(F2A45, fdesde, 2);
            d.Limpio_Rojo(F2A44, fdesde, 2);
            d.Limpio_Rojo(F2A43, fdesde, 2);
            d.Limpio_Rojo(F2A42, fdesde, 2);
            d.Limpio_Rojo(F2A41, fdesde, 2);
            d.Limpio_Rojo(F2A40, fdesde, 2);
            d.Limpio_Rojo(F2A39, fdesde, 2);
            d.Limpio_Rojo(F2A38, fdesde, 2);
            d.Limpio_Rojo(F2A37, fdesde, 2);
            d.Limpio_Rojo(F2A36, fdesde, 2);
            d.Limpio_Rojo(F2A35, fdesde, 2);
            d.Limpio_Rojo(F2A34, fdesde, 2);
            d.Limpio_Rojo(F2A33, fdesde, 2);
            d.Limpio_Rojo(F2A32, fdesde, 2);
            d.Limpio_Rojo(F2A31, fdesde, 2);
            d.Limpio_Rojo(F2A30, fdesde, 2);
            d.Limpio_Rojo(F2A29, fdesde, 2);
            d.Limpio_Rojo(F2A28, fdesde, 2);
            d.Limpio_Rojo(F2A27, fdesde, 2);
            d.Limpio_Rojo(F2A26, fdesde, 2);
            d.Limpio_Rojo(F2A25, fdesde, 2);
            d.Limpio_Rojo(F2A24, fdesde, 2);
            d.Limpio_Rojo(F2A23, fdesde, 2);
            d.Limpio_Rojo(F2A22, fdesde, 2);
            d.Limpio_Rojo(F2A21, fdesde, 2);
            d.Limpio_Rojo(F2A20, fdesde, 2);
            d.Limpio_Rojo(F2A19, fdesde, 2);
            d.Limpio_Rojo(F2A18, fdesde, 2);
            d.Limpio_Rojo(F2A17, fdesde, 2);
            d.Limpio_Rojo(F2A16, fdesde, 2);
            d.Limpio_Rojo(F2A15, fdesde, 2);
            d.Limpio_Rojo(F2A14, fdesde, 2);
            d.Limpio_Rojo(F2A13, fdesde, 2);
            d.Limpio_Rojo(F2A12, fdesde, 2);
            d.Limpio_Rojo(F2A11, fdesde, 2);
            d.Limpio_Rojo(F2A10, fdesde, 2);
            d.Limpio_Rojo(F2A09, fdesde, 2);
            d.Limpio_Rojo(F2A08, fdesde, 2);
            d.Limpio_Rojo(F2A07, fdesde, 2);
            d.Limpio_Rojo(F2A06, fdesde, 2);
            d.Limpio_Rojo(F2A05, fdesde, 2);
            d.Limpio_Rojo(F2A04, fdesde, 2);
            d.Limpio_Rojo(F2A03, fdesde, 2);
            d.Limpio_Rojo(F2A02, fdesde, 2);
            d.Limpio_Rojo(F2A01, fdesde, 2);
            d.Limpio_Rojo(F1A52, fdesde, 2);
            d.Limpio_Rojo(F1A51, fdesde, 2);
            d.Limpio_Rojo(F1A50, fdesde, 2);
            d.Limpio_Rojo(F1A49, fdesde, 2);
            d.Limpio_Rojo(F1A48, fdesde, 2);
            d.Limpio_Rojo(F1A47, fdesde, 2);
            d.Limpio_Rojo(F1A46, fdesde, 2);
            d.Limpio_Rojo(F1A45, fdesde, 2);
            d.Limpio_Rojo(F1A44, fdesde, 2);
            d.Limpio_Rojo(F1A43, fdesde, 2);
            d.Limpio_Rojo(F1A42, fdesde, 2);
            d.Limpio_Rojo(F1A41, fdesde, 2);
            d.Limpio_Rojo(F1A40, fdesde, 2);
            d.Limpio_Rojo(F1A39, fdesde, 2);
            d.Limpio_Rojo(F1A38, fdesde, 2);
            d.Limpio_Rojo(F1A37, fdesde, 2);
            d.Limpio_Rojo(F1A36, fdesde, 2);
            d.Limpio_Rojo(F1A35, fdesde, 2);
            d.Limpio_Rojo(F1A34, fdesde, 2);
            d.Limpio_Rojo(F1A33, fdesde, 2);
            d.Limpio_Rojo(F1A32, fdesde, 2);
            d.Limpio_Rojo(F1A31, fdesde, 2);
            d.Limpio_Rojo(F1A30, fdesde, 2);
            d.Limpio_Rojo(F1A29, fdesde, 2);
            d.Limpio_Rojo(F1A28, fdesde, 2);
            d.Limpio_Rojo(F1A27, fdesde, 2);
            d.Limpio_Rojo(F1A26, fdesde, 2);
            d.Limpio_Rojo(F1A25, fdesde, 2);
            d.Limpio_Rojo(F1A24, fdesde, 2);
            d.Limpio_Rojo(F1A23, fdesde, 2);
            d.Limpio_Rojo(F1A22, fdesde, 2);
            d.Limpio_Rojo(F1A21, fdesde, 2);
            d.Limpio_Rojo(F1A20, fdesde, 2);
            d.Limpio_Rojo(F1A19, fdesde, 2);
            d.Limpio_Rojo(F1A18, fdesde, 2);
            d.Limpio_Rojo(F1A17, fdesde, 2);
            d.Limpio_Rojo(F1A16, fdesde, 2);
            d.Limpio_Rojo(F1A15, fdesde, 2);
            d.Limpio_Rojo(F1A14, fdesde, 2);
            d.Limpio_Rojo(F1A13, fdesde, 2);
            d.Limpio_Rojo(F1A12, fdesde, 2);
            d.Limpio_Rojo(F1A11, fdesde, 2);
            d.Limpio_Rojo(F1A10, fdesde, 2);
            d.Limpio_Rojo(F1A09, fdesde, 2);
            d.Limpio_Rojo(F1A08, fdesde, 2);
            d.Limpio_Rojo(F1A07, fdesde, 2);
            d.Limpio_Rojo(F1A06, fdesde, 2);
            d.Limpio_Rojo(F1A05, fdesde, 2);
            d.Limpio_Rojo(F1A04, fdesde, 2);
            d.Limpio_Rojo(F1A03, fdesde, 2);
            d.Limpio_Rojo(F1A02, fdesde, 2);
            d.Limpio_Rojo(F1A01, fdesde, 2);
            d.Limpio_Rojo(C17, fdesde, 1);
            d.Limpio_Rojo(C16, fdesde, 1);
            d.Limpio_Rojo(C15, fdesde, 1);
            d.Limpio_Rojo(C14, fdesde, 1);
            d.Limpio_Rojo(C13, fdesde, 1);
            d.Limpio_Rojo(C12, fdesde, 1);
            d.Limpio_Rojo(C11, fdesde, 1);
            d.Limpio_Rojo(C10, fdesde, 1);
            d.Limpio_Rojo(C09, fdesde, 1);
            d.Limpio_Rojo(C08, fdesde, 1);
            d.Limpio_Rojo(C07, fdesde, 1);
            d.Limpio_Rojo(C06, fdesde, 1);
            d.Limpio_Rojo(C05, fdesde, 1);
            d.Limpio_Rojo(C04, fdesde, 1);
            d.Limpio_Rojo(C03, fdesde, 1);
            d.Limpio_Rojo(C02, fdesde, 1);
            d.Limpio_Rojo(C01, fdesde, 1);

            string respuesta = "", ruta = "";


            conectar = Conexion.ObtenerConexion();
            cmd = new MySqlCommand("Select * from lecturas where evento='" + "RIVER PLATE VS ALDOSIVI" + "'", conectar);
            dr = cmd.ExecuteReader();

            
                    while (dr.Read())
                    {

                         Id_impresion = dr.GetString(4);
                         respuesta = d.Busco_Presentes(Id_impresion);

                                if (respuesta == "F7A28")
                                    F7A28.BackColor = Color.Green;
                                if (respuesta == "F7A27")
                                    F7A27.BackColor = Color.Green;
                                if (respuesta == "F7A26")
                                    F7A26.BackColor = Color.Green;
                                if (respuesta == "F7A25")
                                    F7A25.BackColor = Color.Green;
                                if (respuesta == "F7A24")
                                    F7A24.BackColor = Color.Green;
                                if (respuesta == "F7A23")
                                    F7A23.BackColor = Color.Green;
                                if (respuesta == "F7A22")
                                    F7A22.BackColor = Color.Green;
                                if (respuesta == "F7A21")
                                    F7A21.BackColor = Color.Green;
                                if (respuesta == "F7A20")
                                    F7A20.BackColor = Color.Green;
                                if (respuesta == "F7A19")
                                    F7A19.BackColor = Color.Green;
                                if (respuesta == "F7A18")
                                    F7A18.BackColor = Color.Green;
                                if (respuesta == "F7A17")
                                    F7A17.BackColor = Color.Green;
                                if (respuesta == "F7A16")
                                    F7A16.BackColor = Color.Green;
                                if (respuesta == "F7A15")
                                    F7A15.BackColor = Color.Green;
                                if (respuesta == "F7A14")
                                    F7A14.BackColor = Color.Green;
                                if (respuesta == "F7A13")
                                    F7A13.BackColor = Color.Green;
                                if (respuesta == "F7A12")
                                    F7A12.BackColor = Color.Green;
                                if (respuesta == "F7A11")
                                    F7A11.BackColor = Color.Green;
                                if (respuesta == "F7A10")
                                    F7A10.BackColor = Color.Green;
                                if (respuesta == "F7A09")
                                    F7A09.BackColor = Color.Green;
                                if (respuesta == "F7A08")
                                    F7A08.BackColor = Color.Green;
                                if (respuesta == "F7A07")
                                    F7A07.BackColor = Color.Green;
                                if (respuesta == "F7A06")
                                    F7A06.BackColor = Color.Green;
                                if (respuesta == "F7A05")
                                    F7A05.BackColor = Color.Green;
                                if (respuesta == "F7A04")
                                    F7A04.BackColor = Color.Green;
                                if (respuesta == "F7A03")
                                    F7A03.BackColor = Color.Green;
                                if (respuesta == "F7A02")
                                    F7A02.BackColor = Color.Green;
                                if (respuesta == "F7A01")
                                    F7A01.BackColor = Color.Green;
                                if (respuesta == "F6A24")
                                    F6A24.BackColor = Color.Green;
                                if (respuesta == "F6A23")
                                    F6A23.BackColor = Color.Green;
                                if (respuesta == "F6A22")
                                    F6A22.BackColor = Color.Green;
                                if (respuesta == "F6A21")
                                    F6A21.BackColor = Color.Green;
                                if (respuesta == "F6A20")
                                    F6A20.BackColor = Color.Green;
                                if (respuesta == "F6A19")
                                    F6A19.BackColor = Color.Green;
                                if (respuesta == "F6A18")
                                    F6A18.BackColor = Color.Green;
                                if (respuesta == "F6A17")
                                    F6A17.BackColor = Color.Green;
                                if (respuesta == "F6A16")
                                    F6A16.BackColor = Color.Green;
                                if (respuesta == "F6A15")
                                    F6A15.BackColor = Color.Green;
                                if (respuesta == "F6A14")
                                    F6A14.BackColor = Color.Green;
                                if (respuesta == "F6A13")
                                    F6A13.BackColor = Color.Green;
                                if (respuesta == "F6A12")
                                    F6A12.BackColor = Color.Green;
                                if (respuesta == "F6A11")
                                    F6A11.BackColor = Color.Green;
                                if (respuesta == "F6A10")
                                    F6A10.BackColor = Color.Green;
                                if (respuesta == "F6A09")
                                    F6A09.BackColor = Color.Green;
                                if (respuesta == "F6A08")
                                    F6A08.BackColor = Color.Green;
                                if (respuesta == "F6A07")
                                    F6A07.BackColor = Color.Green;
                                if (respuesta == "F6A06")
                                    F6A06.BackColor = Color.Green;
                                if (respuesta == "F6A05")
                                    F6A05.BackColor = Color.Green;
                                if (respuesta == "F6A04")
                                    F6A04.BackColor = Color.Green;
                                if (respuesta == "F6A03")
                                    F6A03.BackColor = Color.Green;
                                if (respuesta == "F6A02")
                                    F6A02.BackColor = Color.Green;
                                if (respuesta == "F6A01")
                                    F6A01.BackColor = Color.Green;
                                if (respuesta == "F5A18")
                                    F5A18.BackColor = Color.Green;
                                if (respuesta == "F5A17")
                                    F5A17.BackColor = Color.Green;
                                if (respuesta == "F5A16")
                                    F5A16.BackColor = Color.Green;
                                if (respuesta == "F5A15")
                                    F5A15.BackColor = Color.Green;
                                if (respuesta == "F5A14")
                                    F5A14.BackColor = Color.Green;
                                if (respuesta == "F5A13")
                                    F5A13.BackColor = Color.Green;
                                if (respuesta == "F5A12")
                                    F5A12.BackColor = Color.Green;
                                if (respuesta == "F5A11")
                                    F5A11.BackColor = Color.Green;
                                if (respuesta == "F5A10")
                                    F5A10.BackColor = Color.Green;
                                if (respuesta == "F5A09")
                                    F5A09.BackColor = Color.Green;
                                if (respuesta == "F5A08")
                                    F5A08.BackColor = Color.Green;
                                if (respuesta == "F5A07")
                                    F5A07.BackColor = Color.Green;
                                if (respuesta == "F5A06")
                                    F5A06.BackColor = Color.Green;
                                if (respuesta == "F5A05")
                                    F5A05.BackColor = Color.Green;
                                if (respuesta == "F5A04")
                                    F5A04.BackColor = Color.Green;
                                if (respuesta == "F5A03")
                                    F5A03.BackColor = Color.Green;
                                if (respuesta == "F5A02")
                                    F5A02.BackColor = Color.Green;
                                if (respuesta == "F5A01")
                                    F5A01.BackColor = Color.Green;
                                if (respuesta == "F4A53")
                                    F4A53.BackColor = Color.Green;
                                if (respuesta == "F4A52")
                                    F4A52.BackColor = Color.Green;
                                if (respuesta == "F4A51")
                                    F4A51.BackColor = Color.Green;
                                if (respuesta == "F4A50")
                                    F4A50.BackColor = Color.Green;
                                if (respuesta == "F4A49")
                                    F4A49.BackColor = Color.Green;
                                if (respuesta == "F4A48")
                                    F4A48.BackColor = Color.Green;
                                if (respuesta == "F4A47")
                                    F4A47.BackColor = Color.Green;
                                if (respuesta == "F4A46")
                                    F4A46.BackColor = Color.Green;
                                if (respuesta == "F4A45")
                                    F4A45.BackColor = Color.Green;
                                if (respuesta == "F4A44")
                                    F4A44.BackColor = Color.Green;
                                if (respuesta == "F4A43")
                                    F4A43.BackColor = Color.Green;
                                if (respuesta == "F4A42")
                                    F4A42.BackColor = Color.Green;
                                if (respuesta == "F4A41")
                                    F4A41.BackColor = Color.Green;
                                if (respuesta == "F4A40")
                                    F4A40.BackColor = Color.Green;
                                if (respuesta == "F4A39")
                                    F4A39.BackColor = Color.Green;
                                if (respuesta == "F4A38")
                                    F4A38.BackColor = Color.Green;
                                if (respuesta == "F4A37")
                                    F4A37.BackColor = Color.Green;
                                if (respuesta == "F4A36")
                                    F4A36.BackColor = Color.Green;
                                if (respuesta == "F4A35")
                                    F4A35.BackColor = Color.Green;
                                if (respuesta == "F4A34")
                                    F4A34.BackColor = Color.Green;
                                if (respuesta == "F4A33")
                                    F4A33.BackColor = Color.Green;
                                if (respuesta == "F4A32")
                                    F4A32.BackColor = Color.Green;
                                if (respuesta == "F4A31")
                                    F4A31.BackColor = Color.Green;
                                if (respuesta == "F4A30")
                                    F4A30.BackColor = Color.Green;
                                if (respuesta == "F4A29")
                                    F4A29.BackColor = Color.Green;
                                if (respuesta == "F4A28")
                                    F4A28.BackColor = Color.Green;
                                if (respuesta == "F4A27")
                                    F4A27.BackColor = Color.Green;
                                if (respuesta == "F4A26")
                                    F4A26.BackColor = Color.Green;
                                if (respuesta == "F4A25")
                                    F4A25.BackColor = Color.Green;
                                if (respuesta == "F4A24")
                                    F4A24.BackColor = Color.Green;
                                if (respuesta == "F4A23")
                                    F4A23.BackColor = Color.Green;
                                if (respuesta == "F4A22")
                                    F4A22.BackColor = Color.Green;
                                if (respuesta == "F4A21")
                                    F4A21.BackColor = Color.Green;
                                if (respuesta == "F4A20")
                                    F4A20.BackColor = Color.Green;
                                if (respuesta == "F4A19")
                                    F4A19.BackColor = Color.Green;
                                if (respuesta == "F4A18")
                                    F4A18.BackColor = Color.Green;
                                if (respuesta == "F4A17")
                                    F4A17.BackColor = Color.Green;
                                if (respuesta == "F4A16")
                                    F4A16.BackColor = Color.Green;
                                if (respuesta == "F4A15")
                                    F4A15.BackColor = Color.Green;
                                if (respuesta == "F4A14")
                                    F4A14.BackColor = Color.Green;
                                if (respuesta == "F4A13")
                                    F4A13.BackColor = Color.Green;
                                if (respuesta == "F4A12")
                                    F4A12.BackColor = Color.Green;
                                if (respuesta == "F4A11")
                                    F4A11.BackColor = Color.Green;
                                if (respuesta == "F4A10")
                                    F4A10.BackColor = Color.Green;
                                if (respuesta == "F4A09")
                                    F4A09.BackColor = Color.Green;
                                if (respuesta == "F4A08")
                                    F4A08.BackColor = Color.Green;
                                if (respuesta == "F4A07")
                                    F4A07.BackColor = Color.Green;
                                if (respuesta == "F4A06")
                                    F4A06.BackColor = Color.Green;
                                if (respuesta == "F4A05")
                                    F4A05.BackColor = Color.Green;
                                if (respuesta == "F4A04")
                                    F4A04.BackColor = Color.Green;
                                if (respuesta == "F4A03")
                                    F4A03.BackColor = Color.Green;
                                if (respuesta == "F4A02")
                                    F4A02.BackColor = Color.Green;
                                if (respuesta == "F4A01")
                                    F4A01.BackColor = Color.Green;
                                if (respuesta == "F3A52")
                                    F3A52.BackColor = Color.Green;
                                if (respuesta == "F3A51")
                                    F3A51.BackColor = Color.Green;
                                if (respuesta == "F3A50")
                                    F3A50.BackColor = Color.Green;
                                if (respuesta == "F3A49")
                                    F3A49.BackColor = Color.Green;
                                if (respuesta == "F3A48")
                                    F3A48.BackColor = Color.Green;
                                if (respuesta == "F3A47")
                                    F3A47.BackColor = Color.Green;
                                if (respuesta == "F3A46")
                                    F3A46.BackColor = Color.Green;
                                if (respuesta == "F3A45")
                                    F3A45.BackColor = Color.Green;
                                if (respuesta == "F3A44")
                                    F3A44.BackColor = Color.Green;
                                if (respuesta == "F3A43")
                                    F3A43.BackColor = Color.Green;
                                if (respuesta == "F3A42")
                                    F3A42.BackColor = Color.Green;
                                if (respuesta == "F3A41")
                                    F3A41.BackColor = Color.Green;
                                if (respuesta == "F3A40")
                                    F3A40.BackColor = Color.Green;
                                if (respuesta == "F3A39")
                                    F3A39.BackColor = Color.Green;
                                if (respuesta == "F3A38")
                                    F3A38.BackColor = Color.Green;
                                if (respuesta == "F3A37")
                                    F3A37.BackColor = Color.Green;
                                if (respuesta == "F3A36")
                                    F3A36.BackColor = Color.Green;
                                if (respuesta == "F3A35")
                                    F3A35.BackColor = Color.Green;
                                if (respuesta == "F3A34")
                                    F3A34.BackColor = Color.Green;
                                if (respuesta == "F3A33")
                                    F3A33.BackColor = Color.Green;
                                if (respuesta == "F3A32")
                                    F3A32.BackColor = Color.Green;
                                if (respuesta == "F3A31")
                                    F3A31.BackColor = Color.Green;
                                if (respuesta == "F3A30")
                                    F3A30.BackColor = Color.Green;
                                if (respuesta == "F3A29")
                                    F3A29.BackColor = Color.Green;
                                if (respuesta == "F3A28")
                                    F3A28.BackColor = Color.Green;
                                if (respuesta == "F3A27")
                                    F3A27.BackColor = Color.Green;
                                if (respuesta == "F3A26")
                                    F3A26.BackColor = Color.Green;
                                if (respuesta == "F3A25")
                                    F3A25.BackColor = Color.Green;
                                if (respuesta == "F3A24")
                                    F3A24.BackColor = Color.Green;
                                if (respuesta == "F3A23")
                                    F3A23.BackColor = Color.Green;
                                if (respuesta == "F3A22")
                                    F3A22.BackColor = Color.Green;
                                if (respuesta == "F3A21")
                                    F3A21.BackColor = Color.Green;
                                if (respuesta == "F3A20")
                                    F3A20.BackColor = Color.Green;
                                if (respuesta == "F3A19")
                                    F3A19.BackColor = Color.Green;
                                if (respuesta == "F3A18")
                                    F3A18.BackColor = Color.Green;
                                if (respuesta == "F3A17")
                                    F3A17.BackColor = Color.Green;
                                if (respuesta == "F3A16")
                                    F3A16.BackColor = Color.Green;
                                if (respuesta == "F3A15")
                                    F3A15.BackColor = Color.Green;
                                if (respuesta == "F3A14")
                                    F3A14.BackColor = Color.Green;
                                if (respuesta == "F3A13")
                                    F3A13.BackColor = Color.Green;
                                if (respuesta == "F3A12")
                                    F3A12.BackColor = Color.Green;
                                if (respuesta == "F3A11")
                                    F3A11.BackColor = Color.Green;
                                if (respuesta == "F3A10")
                                    F3A10.BackColor = Color.Green;
                                if (respuesta == "F3A09")
                                    F3A09.BackColor = Color.Green;
                                if (respuesta == "F3A08")
                                    F3A08.BackColor = Color.Green;
                                if (respuesta == "F3A07")
                                    F3A07.BackColor = Color.Green;
                                if (respuesta == "F3A06")
                                    F3A06.BackColor = Color.Green;
                                if (respuesta == "F3A05")
                                    F3A05.BackColor = Color.Green;
                                if (respuesta == "F3A04")
                                    F3A04.BackColor = Color.Green;
                                if (respuesta == "F3A03")
                                    F3A03.BackColor = Color.Green;
                                if (respuesta == "F3A02")
                                    F3A02.BackColor = Color.Green;
                                if (respuesta == "F3A01")
                                    F3A01.BackColor = Color.Green;
                                if (respuesta == "F2A52")
                                    F2A52.BackColor = Color.Green;
                                if (respuesta == "F2A51")
                                    F2A51.BackColor = Color.Green;
                                if (respuesta == "F2A50")
                                    F2A50.BackColor = Color.Green;
                                if (respuesta == "F2A49")
                                    F2A49.BackColor = Color.Green;
                                if (respuesta == "F2A48")
                                    F2A48.BackColor = Color.Green;
                                if (respuesta == "F2A47")
                                    F2A47.BackColor = Color.Green;
                                if (respuesta == "F2A46")
                                    F2A46.BackColor = Color.Green;
                                if (respuesta == "F2A45")
                                    F2A45.BackColor = Color.Green;
                                if (respuesta == "F2A44")
                                    F2A44.BackColor = Color.Green;
                                if (respuesta == "F2A43")
                                    F2A43.BackColor = Color.Green;
                                if (respuesta == "F2A42")
                                    F2A42.BackColor = Color.Green;
                                if (respuesta == "F2A41")
                                    F2A41.BackColor = Color.Green;
                                if (respuesta == "F2A40")
                                    F2A40.BackColor = Color.Green;
                                if (respuesta == "F2A39")
                                    F2A39.BackColor = Color.Green;
                                if (respuesta == "F2A38")
                                    F2A38.BackColor = Color.Green;
                                if (respuesta == "F2A37")
                                    F2A37.BackColor = Color.Green;
                                if (respuesta == "F2A36")
                                    F2A36.BackColor = Color.Green;
                                if (respuesta == "F2A35")
                                    F2A35.BackColor = Color.Green;
                                if (respuesta == "F2A34")
                                    F2A34.BackColor = Color.Green;
                                if (respuesta == "F2A33")
                                    F2A33.BackColor = Color.Green;
                                if (respuesta == "F2A32")
                                    F2A32.BackColor = Color.Green;
                                if (respuesta == "F2A31")
                                    F2A31.BackColor = Color.Green;
                                if (respuesta == "F2A30")
                                    F2A30.BackColor = Color.Green;
                                if (respuesta == "F2A29")
                                    F2A29.BackColor = Color.Green;
                                if (respuesta == "F2A28")
                                    F2A28.BackColor = Color.Green;
                                if (respuesta == "F2A27")
                                    F2A27.BackColor = Color.Green;
                                if (respuesta == "F2A26")
                                    F2A26.BackColor = Color.Green;
                                if (respuesta == "F2A25")
                                    F2A25.BackColor = Color.Green;
                                if (respuesta == "F2A24")
                                    F2A24.BackColor = Color.Green;
                                if (respuesta == "F2A23")
                                    F2A23.BackColor = Color.Green;
                                if (respuesta == "F2A22")
                                    F2A22.BackColor = Color.Green;
                                if (respuesta == "F2A21")
                                    F2A21.BackColor = Color.Green;
                                if (respuesta == "F2A20")
                                    F2A20.BackColor = Color.Green;
                                if (respuesta == "F2A19")
                                    F2A19.BackColor = Color.Green;
                                if (respuesta == "F2A18")
                                    F2A18.BackColor = Color.Green;
                                if (respuesta == "F2A17")
                                    F2A17.BackColor = Color.Green;
                                if (respuesta == "F2A16")
                                    F2A16.BackColor = Color.Green;
                                if (respuesta == "F2A15")
                                    F2A15.BackColor = Color.Green;
                                if (respuesta == "F2A14")
                                    F2A14.BackColor = Color.Green;
                                if (respuesta == "F2A13")
                                    F2A13.BackColor = Color.Green;
                                if (respuesta == "F2A12")
                                    F2A12.BackColor = Color.Green;
                                if (respuesta == "F2A11")
                                    F2A11.BackColor = Color.Green;
                                if (respuesta == "F2A10")
                                    F2A10.BackColor = Color.Green;
                                if (respuesta == "F2A09")
                                    F2A09.BackColor = Color.Green;
                                if (respuesta == "F2A08")
                                    F2A08.BackColor = Color.Green;
                                if (respuesta == "F2A07")
                                    F2A07.BackColor = Color.Green;
                                if (respuesta == "F2A06")
                                    F2A06.BackColor = Color.Green;
                                if (respuesta == "F2A05")
                                    F2A05.BackColor = Color.Green;
                                if (respuesta == "F2A04")
                                    F2A04.BackColor = Color.Green;
                                if (respuesta == "F2A03")
                                    F2A03.BackColor = Color.Green;
                                if (respuesta == "F2A02")
                                    F2A02.BackColor = Color.Green;
                                if (respuesta == "F2A01")
                                    F2A01.BackColor = Color.Green;
                                if (respuesta == "F1A52")
                                    F1A52.BackColor = Color.Green;
                                if (respuesta == "F1A51")
                                    F1A51.BackColor = Color.Green;
                                if (respuesta == "F1A50")
                                    F1A50.BackColor = Color.Green;
                                if (respuesta == "F1A49")
                                    F1A49.BackColor = Color.Green;
                                if (respuesta == "F1A48")
                                    F1A48.BackColor = Color.Green;
                                if (respuesta == "F1A47")
                                    F1A47.BackColor = Color.Green;
                                if (respuesta == "F1A46")
                                    F1A46.BackColor = Color.Green;
                                if (respuesta == "F1A45")
                                    F1A45.BackColor = Color.Green;
                                if (respuesta == "F1A44")
                                    F1A44.BackColor = Color.Green;
                                if (respuesta == "F1A43")
                                    F1A43.BackColor = Color.Green;
                                if (respuesta == "F1A42")
                                    F1A42.BackColor = Color.Green;
                                if (respuesta == "F1A41")
                                    F1A41.BackColor = Color.Green;
                                if (respuesta == "F1A40")
                                    F1A40.BackColor = Color.Green;
                                if (respuesta == "F1A39")
                                    F1A39.BackColor = Color.Green;
                                if (respuesta == "F1A38")
                                    F1A38.BackColor = Color.Green;
                                if (respuesta == "F1A37")
                                    F1A37.BackColor = Color.Green;
                                if (respuesta == "F1A36")
                                    F1A36.BackColor = Color.Green;
                                if (respuesta == "F1A35")
                                    F1A35.BackColor = Color.Green;
                                if (respuesta == "F1A34")
                                    F1A34.BackColor = Color.Green;
                                if (respuesta == "F1A33")
                                    F1A33.BackColor = Color.Green;
                                if (respuesta == "F1A32")
                                    F1A32.BackColor = Color.Green;
                                if (respuesta == "F1A31")
                                    F1A31.BackColor = Color.Green;
                                if (respuesta == "F1A30")
                                    F1A30.BackColor = Color.Green;
                                if (respuesta == "F1A29")
                                    F1A29.BackColor = Color.Green;
                                if (respuesta == "F1A28")
                                    F1A28.BackColor = Color.Green;
                                if (respuesta == "F1A27")
                                    F1A27.BackColor = Color.Green;
                                if (respuesta == "F1A26")
                                    F1A26.BackColor = Color.Green;
                                if (respuesta == "F1A25")
                                    F1A25.BackColor = Color.Green;
                                if (respuesta == "F1A24")
                                    F1A24.BackColor = Color.Green;
                                if (respuesta == "F1A23")
                                    F1A23.BackColor = Color.Green;
                                if (respuesta == "F1A22")
                                    F1A22.BackColor = Color.Green;
                                if (respuesta == "F1A21")
                                    F1A21.BackColor = Color.Green;
                                if (respuesta == "F1A20")
                                    F1A20.BackColor = Color.Green;
                                if (respuesta == "F1A19")
                                    F1A19.BackColor = Color.Green;
                                if (respuesta == "F1A18")
                                    F1A18.BackColor = Color.Green;
                                if (respuesta == "F1A17")
                                    F1A17.BackColor = Color.Green;
                                if (respuesta == "F1A16")
                                    F1A16.BackColor = Color.Green;
                                if (respuesta == "F1A15")
                                    F1A15.BackColor = Color.Green;
                                if (respuesta == "F1A14")
                                    F1A14.BackColor = Color.Green;
                                if (respuesta == "F1A13")
                                    F1A13.BackColor = Color.Green;
                                if (respuesta == "F1A12")
                                    F1A12.BackColor = Color.Green;
                                if (respuesta == "F1A11")
                                    F1A11.BackColor = Color.Green;
                                if (respuesta == "F1A10")
                                    F1A10.BackColor = Color.Green;
                                if (respuesta == "F1A09")
                                    F1A09.BackColor = Color.Green;
                                if (respuesta == "F1A08")
                                    F1A08.BackColor = Color.Green;
                                if (respuesta == "F1A07")
                                    F1A07.BackColor = Color.Green;
                                if (respuesta == "F1A06")
                                    F1A06.BackColor = Color.Green;
                                if (respuesta == "F1A05")
                                    F1A05.BackColor = Color.Green;
                                if (respuesta == "F1A04")
                                    F1A04.BackColor = Color.Green;
                                if (respuesta == "F1A03")
                                    F1A03.BackColor = Color.Green;
                                if (respuesta == "F1A02")
                                    F1A02.BackColor = Color.Green;
                                if (respuesta == "F1A01")
                                    F1A01.BackColor = Color.Green;
                                if (respuesta == "C17")
                                    C17.BackColor = Color.Green;
                                if (respuesta == "C16")
                                    C16.BackColor = Color.Green;
                                if (respuesta == "C15")
                                    C15.BackColor = Color.Green;
                                if (respuesta == "C14")
                                    C14.BackColor = Color.Green;
                                if (respuesta == "C13")
                                    C13.BackColor = Color.Green;
                                if (respuesta == "C12")
                                    C12.BackColor = Color.Green;
                                if (respuesta == "C11")
                                    C11.BackColor = Color.Green;
                                if (respuesta == "C10")
                                    C10.BackColor = Color.Green;
                                if (respuesta == "C09")
                                    C09.BackColor = Color.Green;
                                if (respuesta == "C08")
                                    C08.BackColor = Color.Green;
                                if (respuesta == "C07")
                                    C07.BackColor = Color.Green;
                                if (respuesta == "C06")
                                    C06.BackColor = Color.Green;
                                if (respuesta == "C05")
                                    C05.BackColor = Color.Green;
                                if (respuesta == "C04")
                                    C04.BackColor = Color.Green;
                                if (respuesta == "C03")
                                    C03.BackColor = Color.Green;
                                if (respuesta == "C02")
                                    C02.BackColor = Color.Green;
                                if (respuesta == "C01")
                                    C01.BackColor = Color.Green;

                                panel2.Visible = false;
                                panel5.Visible = false;
                                panel6.Visible = false;
                                panel3.Visible = true;
                                panel4.Visible = true;
                                panel7.Visible = true;
                                panel8.Visible = true;
                                totentrantescabinas.Text = Convert.ToString(FrmLogin.total_cabinas_entrantes) + " Cabinas Entrantes";
                                totfaltantescabinas.Text = Convert.ToString(Convert.ToDouble(FrmLogin.total_cabinas_impresas - FrmLogin.total_cabinas_entrantes)) + " Cabinas Faltantes";
                                totentrantespupitres.Text = Convert.ToString(FrmLogin.total_pupitres_entrantes) + " Pupitres Entrantes";
                                totfaltantespupitres.Text = Convert.ToString(Convert.ToDouble(FrmLogin.total_pupitres_impresos - FrmLogin.total_pupitres_entrantes)) + " Pupitres Faltantes";




                            }
                                         

            
            System.Windows.Forms.Cursor.Current = Cursors.Default;
            this.Refresh();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            FrmLecturaPorSectores frm = new FrmLecturaPorSectores();
            frm.ShowDialog();
            this.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {

        }
    }
}
