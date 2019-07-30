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
    public partial class FrmAltaManualSeguridad : Form
    {
        public FrmAltaManualSeguridad(string Id_ElEvento)
        {
            InitializeComponent();
            Id_Evento.Text = Id_ElEvento;
        }

        private void FrmAltaManualSeguridad_Load(object sender, EventArgs e)
        {
            Importar d = new Importar();

            string criterio = "Select  Id_Nivel_Acceso, Descripcion from nivel_acceso";
            d.llenarcombonivelacceso(cbnivelacceso, criterio);

            criterio = "Select  Id_TipoPersona, Descripcion from tipo_persona";
            d.llenarcombotipopersona(cbtipopersona, criterio);


            new Evento().Traigo_Datos_Evento(txttorneo, txtRival, txturl, txtFecha, Id_Evento, txtFechaPartido, txtidrival, estado_evento);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            if (MessageBox.Show(" Esta seguro que quiere imprimir los registros seleccionado ?", "Imprimir registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {


                new Evento().Cargo_Altas_Manuales_Seguridad(txttorneo.Text, txtRival.Text, txtFecha.Text, txtFechaPartido.Text, txtNombre.Text , txtApellido.Text ,txtcargo.Text , cbnivelacceso.Text , cbtipopersona.Text , Id_Evento.Text, txtdni.Text  , txtempresa.Text   );
                
            }


        }

        private void txtQr1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
