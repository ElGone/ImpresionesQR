using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
  

namespace ImpresionQR
{
  
    public partial class FrmSQL : Form
    {
       
        public FrmSQL()
        {
            InitializeComponent();
        }
        SqlConnection cn = new SqlConnection("Data Source=192.168.2.16 ; Initial Catalog=Desarrollo;  User Id=Desarrollo;  Password=r1v3rpl4t3");
        
        private void FrmSQL_Load(object sender, EventArgs e)
        {
             

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
               //cn.Open();
              //  MessageBox.Show("Conexion");
                new Seguridad().cargo_alta_seguridad();




            }

            catch (Exception ex)
            {
                MessageBox.Show("No Conexion" + ex.Message);

            }
        }
    }
}
