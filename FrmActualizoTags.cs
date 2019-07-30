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
    public partial class FrmActualizoTags : Form
    {
        public FrmActualizoTags()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Importar().importarExcelTAGS(dgvDatos, "Hoja1", button2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Importar().Importar_TAGS(dgvDatos);
        }
    }
}
