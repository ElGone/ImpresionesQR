using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ImpresionQR
{
    public partial class FrmLecturas : Form
    {

        MySqlCommand cmd;
        MySqlConnection conectar;
        MySqlDataReader dr;


        public FrmLecturas()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
          
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new Importar().Importar_Lecturas(dgvDatos, progressBar_cabinas, dgvCabinas);
        }

        private void button2_Click(object sender, EventArgs e)
        {



        }

        private void FrmLecturas_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            DateTime mihora;
            string mifecha;

            conectar = Conexion.ObtenerConexion();
            foreach (DataGridViewRow row in dgvCabinas.Rows)
            {
                 mihora = Convert.ToDateTime(row.Cells[2].Value);
                 mifecha = mihora.ToString("yyyy-MM-dd");

                cmd = new MySqlCommand("Insert into lecturas(Evento, Lectura, Fecha, Id_Impresiones, Sector, Hora, Medio, Asiento, Fila, Cabina) values('" + row.Cells[0].Value + "', '" + row.Cells[1].Value + "', '" + mifecha  + "', " + row.Cells[3].Value + ", '" + row.Cells[4].Value + "', '" + row.Cells[5].Value + "', '"  + row.Cells[6].Value + "', " + row.Cells[9].Value + ", " + row.Cells[8].Value + ", " + row.Cells[7].Value + ")", conectar);
                cmd.ExecuteNonQuery();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
        //    new Importar().importarExcel_Lectura(dgvDatos, "Lecturas");
        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
