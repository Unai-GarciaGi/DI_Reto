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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private string sql;
        private int cont;
        private MiConexion Conexion = new MiConexion();
        //SqlCommand cmd = new SqlCommand(sql, Conexion.pConexion);
        //Conexion.AbrirConexion();
        private void Form1_Load(object sender, EventArgs e)
        {
            sql = "SELECT NomGenero FROM generos";
            SqlCommand cmd = new SqlCommand(sql, Conexion.pConexion);
            Conexion.AbrirConexion();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr.GetString(0));
            }
            Conexion.CerrarConexion();

            sql = "SELECT DISTINCT Fecha FROM Facturas";
            cmd = new SqlCommand(sql, Conexion.pConexion);
            Conexion.AbrirConexion();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboInicial.Items.Add(dr.GetDateTime(0).ToShortDateString());
            }
            Conexion.CerrarConexion();
        }

        private void btnContar_Click(object sender, EventArgs e)
        {
            sql = "SELECT COUNT (*) FROM peliculas";
            SqlCommand cmd = new SqlCommand(sql, Conexion.pConexion);
            Conexion.AbrirConexion();
            cont = Convert.ToInt32(cmd.ExecuteScalar());
            label5.Text = Convert.ToString(cont);
            Conexion.CerrarConexion();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            String nombre = txtNombre.Text;
            Conexion.AbrirConexion();
            sql = "SELECT MAX(CodPelicula) FROM peliculas";
            SqlCommand cmd = new SqlCommand(sql, Conexion.pConexion);
            int x = Convert.ToInt32(cmd.ExecuteScalar()) + 1;
            sql = "INSERT INTO peliculas (CodPelicula, Titulo) values (" + x + ", '" + nombre +"')";
            cmd = new SqlCommand(sql, Conexion.pConexion);
            cmd.ExecuteNonQuery();
            Conexion.CerrarConexion();
            txtNombre.Text = "";
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            String nombre = txtNombre.Text;
            Conexion.AbrirConexion();
            sql = "DELETE FROM peliculas WHERE Titulo = '" + nombre + "'";
            SqlCommand cmd = new SqlCommand(sql, Conexion.pConexion);
            cmd.ExecuteNonQuery();
            Conexion.CerrarConexion();
            txtNombre.Text = "";
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            String nombre = txtNombre.Text;
            String productora = txtNombre.Text;
            String director = txtNombre.Text;
            if(nombre.Equals("") || productora.Equals("") || director.Equals(""))
            {
                label5.Text = "TIENES QUE RELLENAR LOS CAMPOS";
            }
            else
            {
                sql = "UPDATE peliculas SET Productora = '" + productora +"', Director = '" + director + "' WHERE Titulo = '" +  nombre + "';";
                SqlCommand cmd = new SqlCommand(sql, Conexion.pConexion);
                Conexion.AbrirConexion();
                cmd.ExecuteNonQuery();
                Conexion.CerrarConexion();
                txtNombre.Text = "";
                txtProductora.Text = "";
                txtDirector.Text = "";
            }
            
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            if (!comboBox1.Text.Equals(""))
            {
                sql = "SELECT * FROM Peliculas WHERE CodGenero = (SELECT CodGenero FROM Generos WHERE NomGenero = '" + comboBox1.Text +"')";
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

        private void comboInicial_SelectedIndexChanged(object sender, EventArgs e)
        {
            String fecha = comboInicial.SelectedItem.ToString();
            comboFinal.Items.Clear();
            comboFinal.SelectedItem = fecha;
            DateTime fechaDT = Convert.ToDateTime(fecha);
            try
            {
                sql = "SELECT DISTINCT Fecha FROM Facturas WHERE Fecha > " + fecha;
                SqlCommand cmd = new SqlCommand(sql, Conexion.pConexion);
                Conexion.AbrirConexion();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    DateTime drFecha = dr.GetDateTime(0);
                    if (drFecha > fechaDT)
                    {
                        comboFinal.Items.Add(drFecha);
                    }
                }
                Conexion.CerrarConexion();
            }
            catch(Exception ex)
            {
                Console.WriteLine(fecha + "    " + fechaDT);
                Console.WriteLine(ex.Message);
                Conexion.CerrarConexion();
            }
            
        }

        private void btnFacturas_Click(object sender, EventArgs e)
        {
            String f1 = comboInicial.SelectedItem.ToString();
            String f2 = null;
            if(comboFinal.SelectedItem != null)
            {
                f2 = comboFinal.SelectedItem.ToString();
            }
            //ESTABA DANDO ERROR PORQUE SQL SERVER ESTABA COGIENDO LAS FECHAS COMO FECHAS AMERICANAS AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
            if (!f1.Equals("") && f2 != null && !f2.Equals(""))
            {
                Console.WriteLine(f1 + "   " + f2);
                sql = "SELECT * FROM Facturas WHERE Fecha BETWEEN CONVERT(datetime, '" + f1 + "',103) AND CONVERT(datetime, '" + f2 + "',103)";
                SqlCommand cmd = new SqlCommand(sql, Conexion.pConexion);
                Conexion.AbrirConexion();
                SqlDataAdapter das = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                das.Fill(ds, "tabla");
                dataGridView1.DataSource = ds.Tables[0];
                Conexion.CerrarConexion();
            }
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            sql = "SELECT NombCli FROM Clientes";
            SqlCommand cmd = new SqlCommand(sql, Conexion.pConexion);
            Conexion.AbrirConexion();
            SqlDataReader dr = cmd.ExecuteReader();
            String acum = "";
            int x = 0;
            while (dr.Read())
            {
                x++;
                acum = acum + x + " - " + dr.GetString(0) + Environment.NewLine;
                if(x % 25 == 0){
                    MessageBox.Show(acum);
                    acum = "";
                }
            }
            MessageBox.Show(acum);
            Conexion.CerrarConexion();
        }
    }
}
