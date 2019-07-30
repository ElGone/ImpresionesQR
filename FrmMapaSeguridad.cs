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
using System.Net;

namespace ImpresionQR
{
    public partial class FrmMapaSeguridad : Form
    {

        DataTable dt;
        MySqlCommand cmd;
        MySqlDataReader dr;
        MySqlConnection conectar;
        string ruta = "";

        public FrmMapaSeguridad()
        {

            InitializeComponent();
        }

        private void FrmMapaSeguridad_Load(object sender, EventArgs e)
        {

        }

        private void dgvEventos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            string criterio = "";

            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
            criterio = "Select a.Id_Evento, a.Nombre_Evento, a.Campeonato, a.Fecha, a.url, a.Numero_Fecha, a.Rival, a.Id_Rival, a.Estado, b.Descripcion From eventos AS a INNER JOIN Estados AS b ON a.Estado = b.Estado ORDER BY a.Fecha";
            new Importar().muestro_eventos(dataGridView1, criterio);
            System.Windows.Forms.Cursor.Current = Cursors.Default;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            Id_evento.Text = Convert.ToString(this.dgvEventos.CurrentRow.Cells[3].Value);
            estado_evento.Text = Convert.ToString(this.dgvEventos.CurrentRow.Cells[5].Value);
            textIdRival.Text = Convert.ToString(this.dgvEventos.CurrentRow.Cells[7].Value);
            lafecha.Text = Convert.ToString(this.dgvEventos.CurrentRow.Cells[2].Value);
            new Evento().Traigo_Datos_Evento(txtnombre, txtevento, URL, fecnumero, Id_evento, lafecha, textIdRival, estado_evento);
            // new Importar().traigo_escudo_rival(txtIdRival.Text, pictureBox3, pictureBox2, nombreequipo, cuadro);

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            string laruta;

            Id_evento.Text = Convert.ToString(this.dataGridView1.CurrentRow.Cells[3].Value);
            estado_evento.Text = Convert.ToString(this.dataGridView1.CurrentRow.Cells[5].Value);
            textIdRival.Text = Convert.ToString(this.dataGridView1.CurrentRow.Cells[7].Value);
            lafecha.Text = Convert.ToString(this.dataGridView1.CurrentRow.Cells[2].Value);
            laruta = lafecha.Text.Substring(0, 4) + lafecha.Text.Substring(5, 2) + lafecha.Text.Substring(8, 2) + ".json";
            new Evento().Traigo_Datos_Evento(txttorneo, txtevento, URL, fecnumero, Id_evento, lafecha, textIdRival, estado_evento);
           //  new Importar().traigo_escudo_rival(txtIdRival.Text, pictureBox3, pictureBox2, nombreequipo, cuadro);

           // ruta = "http://192.168.2.4/sociosapi/api/registros/prensa?fecha=2018-08-29";
            ruta = "http://192.168.2.4/sociosapi/api/registros/prensa";
         //   var json = new WebClient().DownloadString(ruta);

            
            ruta = "\\\\192.168.192.53\\Sistemas\\" + laruta;
            panel1.Visible = true;
            lbArchivo.Text = ruta;

        }

        private void fecnumero_TextChanged(object sender, EventArgs e)
        {

        }

        private void txttorneo_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {






        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            string vari = "", DNI = "", NOMBRE = "", FECHA="";
            int CapturoDNI = 2, CapturoNOMBRE = 2, CapturoSECTOR = 2, CapturoFECHA = 2, contirow =0;

            if (ruta != "")
            {

                // Verifico si son iguales los nomnbres de los archivos por la fecha

                string outputJSON = File.ReadAllText(ruta);
                JsonTextReader reader = new JsonTextReader(new StringReader(outputJSON));

                

                if (txtnombre.Text != "")
                {
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
                            if (txtdni.Text == vari)
                            {
                                DNI = vari;
                                CapturoDNI = 2;


                            }
                            else
                            {
                                CapturoDNI = 2;
                            }
                        }


                        if (vari == "identificador")
                        { CapturoDNI = 1; }

                        if (CapturoNOMBRE == 1)
                        {
                          
                                NOMBRE = vari;
                                CapturoNOMBRE = 2;
                        }

                        

                        if (CapturoSECTOR == 1)
                        {
                            if (txtnombre.Text == NOMBRE)
                            {
                                txtnombreencontrado.Text  = NOMBRE;
                                txtdniencontrado.Text  = DNI;

                                dgventradas.Rows.Add();
                                dgventradas.Rows[contirow].Cells[0].Value = ImpresionQR.Properties.Resources.check_30;
                                dgventradas.Rows[contirow].Cells[1].Value = FECHA;
                                dgventradas.Rows[contirow].Cells[2].Value = vari;
                                CapturoSECTOR = 2;
                                contirow++;
                            }
                            else
                            {
                                CapturoSECTOR = 2;

                            }

                        }



                        if (vari == "fecha")
                        { CapturoFECHA = 1; }

                        if (vari == "sector")
                        { CapturoSECTOR = 1; }


                        if (vari == "titular")
                        { CapturoNOMBRE = 1; }


                    }
                }
                


                if (txtdni.Text != "")
                {
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
                            if (txtdni.Text == vari)
                            {
                                DNI = vari;
                                CapturoDNI = 2;
                                
                                
                            }
                         else
                            {
                                CapturoDNI = 2;
                            }   
                        }


                        if (vari == "identificador")
                        { CapturoDNI = 1; }

                        if (CapturoNOMBRE == 1)
                        {
                            if (txtdni.Text == DNI)
                            {
                                txtnombreencontrado.Text = vari;
                                txtdniencontrado.Text = DNI;
                                CapturoNOMBRE = 2;
                             }

                            else
                            {
                                CapturoNOMBRE = 2;

                            }  
                        }

                        if (CapturoSECTOR == 1)
                        {
                            if (txtdni.Text == DNI)
                            {
                                
                                dgventradas.Rows.Add();
                                dgventradas.Rows[contirow].Cells[0].Value = ImpresionQR.Properties.Resources.check_30; 
                                dgventradas.Rows[contirow].Cells[1].Value = FECHA;
                                dgventradas.Rows[contirow].Cells[2].Value =vari;
                                CapturoSECTOR = 2;
                                contirow++;
                            }
                          else
                            {
                                CapturoSECTOR = 2;

                            }

                        }



                        if (vari == "fecha")
                        { CapturoFECHA = 1; }

                        if (vari == "sector")
                        { CapturoSECTOR = 1; }
                                                

                        if (vari == "titular")
                        { CapturoNOMBRE = 1; }



                    }


                }
            }
        }

               
            
            
       

        private void txtnombreencontrado_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {


          // OpenFileDialog openfile1 = new OpenFileDialog();
          //  openfile1.InitialDirectory = "\\\\192.168.192.53\\Sistemas\\";
           // openfile1.Filter = "JSON files (*.JSON)|*.JSON|All files (*.*)|*.*";

          //  openfile1.Title = "Seleccione el archivo a Importar";
          //  if (openfile1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
          //  {

           //     if (openfile1.FileName.Equals("") == false)
            //    {
                  //  ruta = openfile1.FileName;
             //       panel1.Visible = true;
             //       lbArchivo.Text = ruta;


//                }

           // }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            FrmCarteraCompleta frm = new FrmCarteraCompleta(ruta);
            frm.ShowDialog();
            this.Show();
        }

        private void txtevento_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
        
        }

        private void txtnombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtdni_TextChanged(object sender, EventArgs e)
        {

        }
    }
    }


   

