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
    public partial class FrmLecturaPorSectores : Form
    {
        public FrmLecturaPorSectores()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            this.Close();

        }

        private void FrmLecturaPorSectores_Load(object sender, EventArgs e)
        {
            new Importar().Traigo_Lecturas(dgvCabinas);
        }
    }
}
