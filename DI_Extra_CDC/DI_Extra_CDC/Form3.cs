using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace DI_Extra_CDC
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private DataSet ds = new DataSet();

        private void Form3_Load(object sender, EventArgs e)
        {
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = "python";
            start.Arguments = string.Format("meteorologia.py");
            start.UseShellExecute = true;
            Process p = Process.Start(start);
            p.WaitForExit();
            ds.ReadXml("meteorologia.xml");
            dataGridView1.DataSource = ds.Tables[0];
            string[] text = File.ReadAllLines("estaciones.txt");
            foreach(string s in text)
            {
                comboBox1.Items.Add(s);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ds.ReadXml("meteorologia.xml");
            dataGridView1.DataSource = ds.Tables[0];
            for(int i = dataGridView1.Rows.Count - 2; i >= 0; i--)
            {
                if (!dataGridView1.Rows[i].Cells[0].Value.ToString().Equals(comboBox1.SelectedItem.ToString()))
                {
                    dataGridView1.Rows.RemoveAt(i);
                }
            }
        }
    }
}
