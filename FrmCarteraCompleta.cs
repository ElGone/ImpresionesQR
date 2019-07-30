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
using SpreadsheetLight;

namespace ImpresionQR
{
    public partial class FrmCarteraCompleta : Form
    {
        public FrmCarteraCompleta(string ruta)
        {
            
            string vari = "", DNI = "", NOMBRE = "", FECHA = "";
            int CapturoDNI = 2, CapturoNOMBRE = 2, CapturoSECTOR = 2, CapturoFECHA = 2, contirow = 0;

            InitializeComponent();
            string outputJSON = File.ReadAllText(ruta);
            JsonTextReader reader = new JsonTextReader(new StringReader(outputJSON));


            while (reader.Read())
                {
                    vari = Convert.ToString(reader.Value);
                    if (CapturoFECHA == 1)
                    {
                        FECHA = vari;
                        CapturoFECHA = 2;
                    }
                    

                    if (CapturoDNI == 1)
                    {
                        DNI = vari;
                        CapturoDNI = 2;
                    }
                    
                    if (vari == "identificador")
                    {
                        CapturoDNI = 1;
                    }

                    if (CapturoNOMBRE == 1)
                    {
                      NOMBRE = vari;
                      CapturoNOMBRE = 2;
                    }
                              
                

                    if (CapturoSECTOR == 1)
                    {
                            dgventradas.Rows.Add();
                            dgventradas.Rows[contirow].Cells[0].Value = ImpresionQR.Properties.Resources.check_30;
                            dgventradas.Rows[contirow].Cells[1].Value = NOMBRE;
                            dgventradas.Rows[contirow].Cells[2].Value = DNI;
                            dgventradas.Rows[contirow].Cells[3].Value = FECHA;
                            dgventradas.Rows[contirow].Cells[4].Value = vari;
                            CapturoSECTOR = 2;
                            contirow++;
                     }



                    if (vari == "fecha")
                    {
                        CapturoFECHA = 1;
                    }

                    if (vari == "sector")
                    {
                        CapturoSECTOR = 1;
                    }


                    if (vari == "titular")
                    {
                        CapturoNOMBRE = 1;
                    }
                    
                }

            txtcantreg.Text = Convert.ToString(contirow);





            }

        private void FrmCarteraCompleta_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string NombreDT = "", DNIDT = "", FechaDT = "", SectorDT = "";


            try
            {


                SLDocument oSLDocument = new SLDocument();
            System.Data.DataTable dt = new System.Data.DataTable();

            dt.Columns.Add("NOMBRE");
            dt.Columns.Add("DNI");
            dt.Columns.Add("FECHA");
            dt.Columns.Add("SECTOR");


            foreach (DataGridViewRow row in dgventradas.Rows)
            {
                   NombreDT = Convert.ToString(row.Cells[1].Value);
                   DNIDT= Convert.ToString(row.Cells[2].Value);
                   FechaDT = Convert.ToString(row.Cells[3].Value);
                   SectorDT = Convert.ToString(row.Cells[4].Value);

                   dt.Rows.Add(NombreDT, DNIDT, FechaDT, SectorDT);
             }


                FechaDT = FechaDT.Substring(6, 4) + FechaDT.Substring(3, 2) + FechaDT.Substring(0, 2);
                string archivo = "c:\\Sistemas\\" + FechaDT + ".xlsx";
                oSLDocument.ImportDataTable(1, 1, dt, true);
                oSLDocument.SaveAs(archivo);
                MessageBox.Show("Se han exportados los datos con exito al archivo " + FechaDT + ".xlsx en la carpeta Sistemas de su disco");

            }


            catch (Exception ex)
            {
                MessageBox.Show("No se exportaron los datos " + ex.ToString());


            }



            

        }
    }
}
