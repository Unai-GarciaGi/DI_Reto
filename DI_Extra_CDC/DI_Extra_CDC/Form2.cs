using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    }
}
