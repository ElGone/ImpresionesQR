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
    public partial class FrmPrincipal : Form
    {

        public static int cabina = 2, pupitre = 2, movil=2, contirow=0, pupitre34=2, pupitre567 = 2, TV=2, Id_Evento=0;

        private void consultasDeImpresionesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (FrmLogin.tipo_usuario == 1)
            {
                FrmConsultas frm = new FrmConsultas();
                frm.ShowDialog();
                this.Show();
            }
        }

        private void nuevoEventoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mapaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (FrmLogin.tipo_usuario == 1)
            {
                Frmjson frm = new Frmjson();
                frm.ShowDialog();
                this.Show();
            }
          
        }

        private void añadirComentariosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saliToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pruebaToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FrmUsuarios frm = new FrmUsuarios();
            frm.ShowDialog();
            this.Show();
        }

        private void calibrarImpresionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FrmLogin.tipo_usuario == 1)
            {
                FrmCalibrarImpresion frm = new FrmCalibrarImpresion();
                frm.ShowDialog();
                this.Show();
            }
        }

        private void lecturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLecturas frm = new FrmLecturas();
            frm.ShowDialog();
            this.Show();
        }

        private void gerenciaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tarjetasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tarjetasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (FrmLogin.tipo_usuario == 2)
            {
                FrmTarjetas frm = new FrmTarjetas();
                frm.ShowDialog();
                this.Show();
            }
        }

        private void recorridosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FrmLogin.tipo_usuario == 2)
            {
                FrmRecorridos frm = new FrmRecorridos();
                frm.ShowDialog();
                this.Show();
            }
        }

        private void altaDeMediosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FrmLogin.tipo_usuario == 1)
            {
                FrmAltaMedios frm = new FrmAltaMedios();
                frm.ShowDialog();
                this.Show();
            }
        }

        private void actualizacionDeMediosToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            if (FrmLogin.tipo_usuario == 1)
            {
                FrmActualizoMedios frm = new FrmActualizoMedios();
                frm.ShowDialog();
                this.Show();
            }
        }

        private void consulaQRDNIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FrmLogin.tipo_usuario == 2)
            {
                FrmMapaSeguridad frm = new FrmMapaSeguridad();
                frm.ShowDialog();
                this.Show();
            }
        }

        private void importarDNIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FrmLogin.tipo_usuario == 2)
            {
                FrmActualizoDNI frm = new FrmActualizoDNI();
                frm.ShowDialog();
                this.Show();
            }
        }

        private void importarTagsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FrmLogin.tipo_usuario == 2)
            {
                FrmActualizoTags frm = new FrmActualizoTags();
                frm.ShowDialog();
                this.Show();
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {

        }

        private void altasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void altasDeCredencialesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FrmLogin.tipo_usuario == 1)
            {
                Form1 frm = new Form1();
                frm.ShowDialog();
                this.Show();
            }
        }

        private void abrirEventoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cuadro frm = new cuadro();
            frm.ShowDialog();
            this.Show();
        }

        private void impresionesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        public FrmPrincipal(string s_nombreusuario, string s_usuario)
        {
            InitializeComponent();
        }

        private void capturaDeArchivoxlsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (FrmLogin.tipo_usuario == 1)
            {
                FrmCapturaDatos frm = new FrmCapturaDatos();
                frm.ShowDialog();
                this.Show();
            }

            else if ((FrmLogin.tipo_usuario == 2))
            {
                FrmCapturaDatosSeguridad frm = new FrmCapturaDatosSeguridad();
                frm.ShowDialog();
                this.Show();
            }

          
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {

        }
    }
}
