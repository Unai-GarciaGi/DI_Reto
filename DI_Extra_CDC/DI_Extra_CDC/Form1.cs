using Newtonsoft.Json;
using System;
using System.Collections;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                WebClient wc = new WebClient();
                wc.DownloadFile("https://data.cdc.gov/resource/km4m-vcsb.json", "datos.json");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("No se ha podido descargar, se utilizará el dato en local");
            }
            string filejson = File.ReadAllText(@"datos.json");
            //Coge todo lo que hay en el string como texto plano, ignorando caracteres escape y otros simbolos
            DataTable dt = (DataTable)JsonConvert.DeserializeObject(filejson, typeof(DataTable));
            List<int> posiciones = new List<int>();
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                if (!dt.Rows[i].ItemArray[1].ToString().Equals("US"))
                {
                    posiciones.Add(i);
                }
            }
            for(int i = posiciones.Count - 1; i >= 0; i--)
            {
                dt.Rows[(int)posiciones[i]].Delete();
            }
            dataGridView1.DataSource = dt;
        }
    }
}
