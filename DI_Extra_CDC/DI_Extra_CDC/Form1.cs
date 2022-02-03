﻿using Newtonsoft.Json;
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
            cargarFilas();
            cargarColumnas();
            cargarJson("US", 5);
        }

        private void cargarJson(String campo, int columna)
        {
            string filejson = File.ReadAllText(@"datos.json");
            //Coge todo lo que hay en el string como texto plano, ignorando caracteres escape y otros simbolos
            DataTable dt = (DataTable)JsonConvert.DeserializeObject(filejson, typeof(DataTable));
            List<int> posiciones = new List<int>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (!dt.Rows[i].ItemArray[1].ToString().Equals(campo))
                {
                    posiciones.Add(i);
                }
            }
            for (int i = posiciones.Count - 1; i >= 0; i--)
            {
                dt.Rows[(int)posiciones[i]].Delete();
            }
            for(int i = dt.Columns.Count - 1; i >= 0; i--)
            {
                if(i != 0 && i != 1 && i != columna)
                {
                    dt.Columns.RemoveAt(i);
                }
            }
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Width = 120;
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Width = 200;
        }

        private void cargarFilas()
        {
            string filejson = File.ReadAllText(@"datos.json");
            //Coge todo lo que hay en el string como texto plano, ignorando caracteres escape y otros simbolos
            DataTable dt = (DataTable)JsonConvert.DeserializeObject(filejson, typeof(DataTable));
            String fecha1 = dt.Rows[0].ItemArray[0].ToString();
            comboBox1.Items.Add(dt.Rows[0].ItemArray[1].ToString());
            for(int i = 1; i < dt.Rows.Count && dt.Rows[i].ItemArray[0].ToString().Equals(fecha1); i++)
            {
                comboBox1.Items.Add(dt.Rows[i].ItemArray[1].ToString());
            }
        }

        private void cargarColumnas()
        {
            string filejson = File.ReadAllText(@"datos.json");
            //Coge todo lo que hay en el string como texto plano, ignorando caracteres escape y otros simbolos
            DataTable dt = (DataTable)JsonConvert.DeserializeObject(filejson, typeof(DataTable));
            for (int i = 2; i < dt.Columns.Count; i++)
            {
                comboBox2.Items.Add(dt.Columns[i].ToString());
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox2.SelectedIndex == -1)
            {
                cargarJson(comboBox1.Text.ToString(), 5);
            }
            else
            {
                cargarJson(comboBox1.Text.ToString(), comboBox2.SelectedIndex + 2);
            }
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                cargarJson("US", comboBox2.SelectedIndex + 2);
            }
            else
            {
                cargarJson(comboBox1.Text.ToString(), comboBox2.SelectedIndex + 2);
            }
        }

        private void btnXml_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable) dataGridView1.DataSource;
            dt.TableName = "datos";
            dt.WriteXml("datos.xml");
        }
    }
}
