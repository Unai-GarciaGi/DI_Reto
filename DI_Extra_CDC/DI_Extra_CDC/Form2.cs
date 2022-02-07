using Newtonsoft.Json;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DI_Extra_CDC
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string filejson = File.ReadAllText(@"estaciones.json");
            //Coge todo lo que hay en el string como texto plano, ignorando caracteres escape y otros simbolos
            DataTable dt = (DataTable)JsonConvert.DeserializeObject(filejson, typeof(DataTable));
            dt.Columns.RemoveAt(4);
            dt.Columns.RemoveAt(4);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = dataGridView1.CurrentCell.RowIndex;
            textBox1.Text = dataGridView1.Rows[fila].Cells[4].Value.ToString();
            textBox2.Text = dataGridView1.Rows[fila].Cells[5].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "" && textBox2.Text != "")
            {
                string latitud = textBox1.Text;
                string longitud = textBox2.Text;
                //Reemplazo la coma por el punto
                latitud = latitud.Replace(",", ".");
                longitud = longitud.Replace(",", ".");
                //Lanzo el proceso con el enlace
                System.Diagnostics.Process.Start("https://www.google.com/maps/search/?api=1&query=" + latitud+","+longitud);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dataGridView1.DataSource;
            /*
            StreamWriter sw = new StreamWriter("datos.csv", false);
            //headers    
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                sw.Write(dt.Columns[i]);
                if (i < dt.Columns.Count - 1)
                {
                    //Separador
                    sw.Write(",");
                }
            }
            sw.Write(sw.NewLine);
            foreach (DataRow dr in dt.Rows)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    if (!Convert.IsDBNull(dr[i]))
                    {
                        string value = dr[i].ToString();
                        //Se asegura que el separador no reaparezca
                        if (value.Contains(','))
                        {
                            value = String.Format("\"{0}\"", value);
                            sw.Write(value);
                        }
                        else
                        {
                            sw.Write(dr[i].ToString());
                        }
                    }
                    if (i < dt.Columns.Count - 1)
                    {
                        //Separador
                        sw.Write(",");
                    }
                }
                sw.Write(sw.NewLine);
            }
            sw.Close();
            System.Diagnostics.Process.Start("datos.csv");
            */
            //PARA ESTO NECESITAMOS EL PAQUETE NUGGET EPPLUS VERSIÓN 4.X
            //USAMOS LA 4.X PORQUE NO HE SIDO CAPAZ DE HACER FUNCIONAR LA 5.X CON EL CAMBIO DE LICENCIA
            //Creo un excel
            ExcelPackage ep = new ExcelPackage();
            //Añado la primera hoja
            ExcelWorksheet ew = ep.Workbook.Worksheets.Add("Sheet 1");
            //Le cargo la tabla en la celda A1
            ew.Cells["A1"].LoadFromDataTable(dt, true);
            //Hago que las columnas se autorredimensionen
            ew.Cells[ew.Dimension.Address].AutoFitColumns();
            //Guardar como, se crea un fileinfo y luego se guarda
            FileInfo fi = new FileInfo("datos.xlsx");
            ep.SaveAs(fi);
            //Inicio excel
            System.Diagnostics.Process.Start("datos.xlsx");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
                //Oculto primero la ventana
                this.Hide();
                //Creo el segundo formulario
                var form3 = new Form3();
                //Añado el cerrar de este formulario al cerrar del segundo y lo muestro
                form3.Closed += (s, args) => this.Close();
                form3.Show();
            
        }
    }
}
