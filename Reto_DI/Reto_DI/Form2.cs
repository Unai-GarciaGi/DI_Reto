using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reto_DI
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private string sql;
        private int cont;
        private MiConexion Conexion = new MiConexion();
        //SqlCommand cmd = new SqlCommand(sql, Conexion.pConexion);
        //Conexion.AbrirConexion();

        private void Form2_Load(object sender, EventArgs e)
        {
            sql = "SELECT * FROM Vendedores";
            SqlCommand cmd = new SqlCommand(sql, Conexion.pConexion);
            Conexion.AbrirConexion();
            SqlDataAdapter das = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            das.Fill(ds, "tabla");
            dataGridView1.DataSource = ds.Tables[0];
            /*
             Otra manera de hacerlo según StackOverflow
            DataTable dt = new DataTable();
            das.Fill(dt);
            dataGridView1.ItemsSource= dt.DefaultView;
             */
            Conexion.CerrarConexion();
        }
    }
}
