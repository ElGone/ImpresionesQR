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
    public partial class cuadro : Form
    {
        string id_rival;
        public cuadro()
        {
            InitializeComponent();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show(" Esta seguro que quiere Abrir un Nuevo Evento con estos Datos ?", "Abrir Evento", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                new Evento().Genero_Evento(pdesde.Text, txtevento , txttorneo, txturl, txtfechanumero, txtrival ,  id_rival );
            }
        }

        private void FrmAbroEvento_Load(object sender, EventArgs e)
        {
            pdesde.Value = DateTime.Now;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string criterio = "";
            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
            criterio = "Select Id_Equipo, Nombre_Equipo, Escudo From equipos Order By Nombre_Equipo";
            new Importar().muestro_rivales(dgvrivales, criterio);
            rivales.Visible = true;
            System.Windows.Forms.Cursor.Current = Cursors.Default;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            rivales.Visible = false;

        }

        private void dgvrivales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            id_rival = Convert.ToString(this.dgvrivales.CurrentRow.Cells[2].Value);
            txtrival.Text = Convert.ToString(this.dgvrivales.CurrentRow.Cells[1].Value);
            txtevento.Text = "RIVER PLATE VS " + txtrival.Text;
            rivales.Visible = false;
            new Importar().traigo_escudo_rival(id_rival, pictureBox3, pictureBox2, nombreequipo, cuadro1);
            button1.Enabled = true;
            label8.Visible = true;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string criterio = "";
            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
            criterio = "Select Id_Equipo, Nombre_Equipo, Escudo, Nacional From equipos Where Nacional=1 Order By Nombre_Equipo";
            new Importar().muestro_rivales(dgvrivales, criterio);
            rivales.Visible = true;
            System.Windows.Forms.Cursor.Current = Cursors.Default;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string criterio = "";
            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
            criterio = "Select Id_Equipo, Nombre_Equipo, Escudo, Nacional From equipos Where Nacional=2 Order By Nombre_Equipo";
            new Importar().muestro_rivales(dgvrivales, criterio);
            rivales.Visible = true;
            System.Windows.Forms.Cursor.Current = Cursors.Default;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string criterio = "";

            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
            criterio = "Select a.Id_Evento, a.Nombre_Evento, a.Campeonato, a.Fecha, a.url, a.Numero_Fecha, a.Rival, a.Id_Rival, a.Estado, b.Descripcion From eventos AS a INNER JOIN Estados AS b ON a.Estado = b.Estado ORDER BY a.Fecha DESC";
            new Importar().muestro_eventos(dgvEventos, criterio);
            groupBox1.Visible = true;
            System.Windows.Forms.Cursor.Current = Cursors.Default;
            label8.Visible = true;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
        }

        private void dgvEventos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Id_evento.Text = Convert.ToString(this.dgvEventos.CurrentRow.Cells[3].Value);
            estado_evento.Text = Convert.ToString(this.dgvEventos.CurrentRow.Cells[5].Value);
            txtIdRival.Text  = Convert.ToString(this.dgvEventos.CurrentRow.Cells[7].Value);
            lafecha.Text= Convert.ToString(this.dgvEventos.CurrentRow.Cells[2].Value);
            new Evento().Traigo_Datos_Evento(txttorneo, txtevento, txturl, txtfechanumero, Id_evento, lafecha, txtIdRival, estado_evento);
            new Importar().traigo_escudo_rival(txtIdRival.Text, pictureBox3, pictureBox2, nombreequipo, cuadro1);
            pdesde.Text  = Convert.ToDateTime(lafecha.Text).ToString("yyyy-MM-dd") ;
            txtrival.Text = nombreequipo.Text;  
            groupBox1.Visible = false;
            button1.Enabled = false;
            label8.Visible = true;
            if (estado_evento.Text=="5")
            {
                button9.Enabled = true;

            } 
            else
            {
                button9.Enabled = false;

            }
        }

        private void button8_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show(" Esta seguro que quiere Cerrar este Evento ?", "Cerrar Evento", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                new Evento().Cerrar_Evento(Id_evento.Text);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(" Esta seguro que quiere volver a Abrir el Evento Seleccionado ?", "Abrir Evento", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                
                new Evento().ReAbro_Evento(Id_evento.Text);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
           
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            FrmModificoEliminoeventos frm = new FrmModificoEliminoeventos(Id_evento.Text, pdesde.Text, nombreequipo.Text, txtIdRival.Text);
            frm.ShowDialog();
            this.Show();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
