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
using MySql.Data.MySqlClient;

namespace ImpresionQR
{
    public partial class FrmCapturaDatosSeguridad : Form
    {
        MySqlCommand cmd;
        MySqlConnection conectar;
        MySqlDataReader dr;
        DateTime fecha = DateTime.Now;

        public FrmCapturaDatosSeguridad()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            new Importar().importarExcelSeguridad(dgvDatos, button3, "CAMPO");
        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            dgvCabinas.Rows.Clear();
            new Importar().Importar_Datos_Excel_Seguridad(dgvDatos, progressBar_cabinas, dgvCabinas, txttorneo.Text, txtevento.Text, button7);
        }

        private void dgvCabinas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            dgvCabinas.Rows.Clear();
            new Importar().Importar_Datos_Excel_Seguridad(dgvDatos, progressBar_cabinas, dgvCabinas, txttorneo.Text, txtevento.Text, button7);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string nombre = "", apellido = "", cargo = "", nivel = "", persona = "";
            int numero_evento = 0;
            string lahora = fecha.ToString("yyyy-MM-dd");

            Evento d = new Evento();
            numero_evento = d.traigo_numero_evento();

            foreach (DataGridViewRow row in dgvCabinas.Rows)
            {

                if (Convert.ToBoolean(row.Cells[0].Value) == true)

                {


                    nombre = Convert.ToString(row.Cells[3].Value);
                    apellido = Convert.ToString(row.Cells[4].Value);
                    cargo = Convert.ToString(row.Cells[5].Value);
                    nivel = Convert.ToString(row.Cells[6].Value);
                    persona = Convert.ToString(row.Cells[7].Value);








                    conectar = Conexion.ObtenerConexion();
                    cmd = new MySqlCommand("Insert into empleados(Torneo, Evento, Nombre, Apellido, Cargo, Nivel_Acceso, Tipo_Persona, Estado, Usuario, Fecha, Id_Evento) values('" + row.Cells[1].Value + "', '" + row.Cells[2].Value + "', '" + nombre.ToUpper() + "', '" + apellido.ToUpper() + "', '" + cargo.ToUpper() + "', '" + nivel.ToUpper() + "', '" + persona.ToUpper() + "', " + 1 + ", '" + FrmLogin.usu + "','" + lahora + "', " + numero_evento + ")", conectar);
                    cmd.ExecuteNonQuery();
                    conectar.Close();

                }


            }
        }

        private void FrmCapturaDatosSeguridad_Load(object sender, EventArgs e)
        {

            int haycarga = 2;


            new Evento().Traigo_Datos_Evento(txttorneo, txtevento, txturl, txtfechanumero, Id_Evento, txtFecha, txtidrival, estado_evento  );
            new Importar().traigo_escudo_rival(txtidrival.Text, pictureBox3, pictureBox2, nombreequipo, cuadro);
            Evento d = new Evento();
            haycarga = d.Traigo_Datos_Personas(dgvCabinas, Id_Evento.Text );

            if (haycarga == 1)
            {
                if (estado_evento.Text == "4")
                {
                    button4.Enabled = true;
                    button5.Enabled = true;
                    button2.Enabled = true;
                    button6.Enabled = true;
                    button10.Enabled = true;
                    button11.Enabled = true;
                }
                else
                {
                    button4.Enabled = false;
                    button5.Enabled = false;
                    button2.Enabled = true;
                    button6.Enabled = true;
                    button10.Enabled = false;
                    button11.Enabled = false;
                }
            }
            else
            {
                button4.Enabled = false;
                button5.Enabled = true;
                button6.Enabled = false;
                button2.Enabled = true;
                button6.Enabled = false;
                button11.Enabled = true;
            }


            rivales.Visible = false;
            panel2.Visible = true;
            button10.Enabled = true;


        }

        private void txtfechanumero_TextChanged(object sender, EventArgs e)
        {

        }

        private void txturl_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string criterio = "";

            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
            criterio = "Select a.Id_Evento, a.Nombre_Evento, a.Campeonato, a.Fecha, a.url, a.Numero_Fecha, a.Rival, a.Id_Rival, a.Estado, b.Descripcion From eventos AS a INNER JOIN Estados AS b ON a.Estado = b.Estado ORDER BY a.Fecha";
            new Importar().muestro_eventos(dgvrivales, criterio);
            rivales.Visible = true;
            System.Windows.Forms.Cursor.Current = Cursors.Default;

        }

        private void button5_Click_1(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro que quiere Exportar a Excel LA NUEVA CARTERA den este EVENTO ?", "Nueva Cartera", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                new Importar().ExportarDataGridViewExcel(dgvCabinas);


            }

       }

        private void button10_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Esta seguro que quiere Guardar los Datos en este EVENTO ?", "Nueva Cartera", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                if (estado_evento.Text == "4")
                {
                    new Evento().Guardo_personas_Evento(dgvCabinas, Id_Evento, txtFecha);

                }

                else
                {
                    MessageBox.Show("No se pueden guardar los Datos. El Evento esta Cerrado");
                }


            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvCabinas.Rows)
            {
                row.Cells[0].Value = true;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvCabinas.Rows)
            {
                row.Cells[0].Value = false;
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            rivales.Visible = false;

        }

        private void dgvrivales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int haycarga;
            Id_Evento.Text = Convert.ToString(this.dgvrivales.CurrentRow.Cells[3].Value);
            estado_evento.Text = Convert.ToString(this.dgvrivales.CurrentRow.Cells[5].Value);
            new Evento().Traigo_Datos_Evento(txttorneo, txtevento, txturl, txtfechanumero, Id_Evento, txtFecha, txtidrival, estado_evento);
            new Importar().traigo_escudo_rival(txtidrival.Text, pictureBox3, pictureBox2, nombreequipo, cuadro);


            Evento d = new Evento();
            haycarga= d.Traigo_Datos_Personas(dgvCabinas, Id_Evento.Text);

            if (haycarga == 1)
            {
                if (estado_evento.Text == "4")
                {
                    button4.Enabled = true;
                    button5.Enabled = true;
                    button2.Enabled = true;
                    button6.Enabled = true;
                    button10.Enabled = true;
                    button11.Enabled = true;
                }
                else
                {
                    button4.Enabled = false;
                    button5.Enabled = false;
                    button2.Enabled = true;
                    button6.Enabled = true;
                    button10.Enabled = false;
                    button11.Enabled = false;
                }
            }
            else
            {
                button4.Enabled = false;
                button5.Enabled = true;
                button6.Enabled = false;
                button2.Enabled = true;
                button6.Enabled = false;
                button11.Enabled = true;
            }


            rivales.Visible = false;
            panel2.Visible = true;
             


        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rivales_Enter(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            string criterio = "";

            if (MessageBox.Show("Esta seguro que quiere Abrir UNA NUEVA CARTERA en este EVENTO ?", "Nueva Cartera", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
                criterio = "Select Id_Impresiones, Torneo, Evento, Nombre, Apellido, Cargo, Nivel_acceso, Tipo_Persona, DNI, Empresa From empleados  ORDER BY Apellido, Nombre";
                new Evento().Traigo_Datos_Cartera(dgvCabinas, criterio);
                rivales.Visible = false;
                System.Windows.Forms.Cursor.Current = Cursors.Default;
                button4.Enabled = true;
                button5.Enabled = true;
                button2.Enabled = true;
                button6.Enabled = true;
                button10.Enabled = true;
            }
        }

        private void txtevento_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void button4_Click(object sender, EventArgs e)
        {
           int cont = 0;


            FrmAltaManualSeguridad frm = new FrmAltaManualSeguridad(Id_Evento.Text );
            frm.ShowDialog();
            this.Show();
            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;

            conectar = Conexion.ObtenerConexion();
            cmd = new MySqlCommand("SELECT Id_Impresiones, Torneo, Evento, Apellido, Nombre, Cargo, Nivel_Acceso, Tipo_Persona, Estado,Fecha, Id_evento FROM empleados ORDER BY Id_Impresiones DESC LIMIT 1", conectar);
            dr = cmd.ExecuteReader();

            cont = dgvCabinas.RowCount-2;
            while (dr.Read())
            {

                dgvCabinas.Rows.Add();
                dgvCabinas.Rows[cont].Cells[1].Value = dr.GetString(1);
                dgvCabinas.Rows[cont].Cells[2].Value = dr.GetString(2);
                dgvCabinas.Rows[cont].Cells[3].Value = dr.GetString(3);
                dgvCabinas.Rows[cont].Cells[4].Value = dr.GetString(4);
                dgvCabinas.Rows[cont].Cells[5].Value = dr.GetString(5);
                dgvCabinas.Rows[cont].Cells[6].Value = dr.GetString(6);
                dgvCabinas.Rows[cont].Cells[7].Value = dr.GetString(7);
                dgvCabinas.Rows[cont].Cells[8].Value = dr.GetString(0);

            }



            // criterio = "Select Id_Impresiones, Torneo, Evento, Nombre, Apellido, Cargo, Nivel_acceso, Tipo_Persona From empleados  ORDER BY Apellido, Nombre";
            //  new Evento().Traigo_Datos_Cartera(dgvCabinas, criterio);
            rivales.Visible = false;
        }
    }
}
