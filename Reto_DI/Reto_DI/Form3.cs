using Microsoft.Reporting.WinForms;
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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private string sql;
        private MiConexion Conexion = new MiConexion();
        //SqlCommand cmd = new SqlCommand(sql, Conexion.pConexion);
        //Conexion.AbrirConexion();

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'EmpresaDataSet1.Peliculas' Puede moverla o quitarla según sea necesario.
            rellenarCombo();
            sql = "SELECT CodFac, NombCli, Importe, Fecha FROM Facturas f JOIN Clientes c ON f.CodCli = c.CodCli";
            SqlCommand cmd = new SqlCommand(sql, Conexion.pConexion);
            SqlDataAdapter das = new SqlDataAdapter(cmd);
            Conexion.AbrirConexion();
            DataSet ds = new DataSet();
            das.Fill(ds, "tabla");
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "Facturas";
            rds.Value = ds.Tables[0];
            reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.RefreshReport();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem != null)
            {
                sql = "SELECT SUM(Importe) FROM Facturas WHERE CodCli = " + Convert.ToInt32(comboBox1.SelectedItem.ToString());
                SqlCommand cmd = new SqlCommand(sql, Conexion.pConexion);
                Conexion.AbrirConexion();
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                MessageBox.Show(Convert.ToString(dr.GetDouble(0)));
                Conexion.CerrarConexion();
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                sql = "DELETE FROM Facturas WHERE CodCli = " + Convert.ToInt32(comboBox1.SelectedItem.ToString());
                SqlCommand cmd = new SqlCommand(sql, Conexion.pConexion);
                Conexion.AbrirConexion();
                cmd.ExecuteNonQuery();
                Conexion.CerrarConexion();
                sql = "DELETE FROM Clientes WHERE CodCli = " + Convert.ToInt32(comboBox1.SelectedItem.ToString());
                cmd = new SqlCommand(sql, Conexion.pConexion);
                Conexion.AbrirConexion();
                cmd.ExecuteNonQuery();
                Conexion.CerrarConexion();
                rellenarCombo();
            }
        }

        private void rellenarCombo()
        {
            comboBox1.Items.Clear();
            sql = "SELECT CodCli FROM Clientes ORDER BY CodCli ASC";
            SqlCommand cmd = new SqlCommand(sql, Conexion.pConexion);
            Conexion.AbrirConexion();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(Convert.ToString(dr.GetInt32(0)));
            }
            Conexion.CerrarConexion();
            comboBox1.SelectedItem = 1;
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            
        }

        private void btnPais_Click(object sender, EventArgs e)
        {

            this.PeliculasTableAdapter.Fill(EmpresaDataSet1.Peliculas, txtPais.Text);

            this.reportViewer1.RefreshReport();

        }

        private void btnTransac_Click(object sender, EventArgs e)
        {
            // 'Se tienen que realizar las dos o ninguna
            //' Apertura de la conexión
            double result = 0;
            Conexion.AbrirConexion();
            SqlCommand comando = new SqlCommand();
            SqlTransaction transaccion;

            //' Inicio de la transaccion
            transaccion = Conexion.pConexion.BeginTransaction();
            comando.Connection = Conexion.pConexion;
            comando.Transaction = transaccion;

            try
            {
                comando.CommandText = "SELECT Precio FROM Peliculas WHERE CodPelicula = 101";
                result = Convert.ToDouble(comando.ExecuteScalar());
                MessageBox.Show(result.ToString(), "Valor inicial");

                comando.CommandText = "UPDATE Peliculas SET Precio = Precio + 5  WHERE CodPelicula = 101";
                comando.ExecuteNonQuery();

                //'PROVOCO UN ERROR. La tabla Productos no existe
                comando.CommandText = "UPDATE Productos SET UnitPrice = UnitPrice + 3.99  WHERE ProductID = 4";
                comando.ExecuteNonQuery();

                //' Finalización exitosa de la transacción
                transaccion.Commit();
            }
            catch (Exception ex)
            {
                //' Cancela toda la transacción
                transaccion.Rollback();
                MessageBox.Show("Se ha producido un error");

                comando.CommandText = "SELECT Precio FROM Peliculas WHERE CodPelicula = 101";
                result = Convert.ToDouble(comando.ExecuteScalar());
                MessageBox.Show(result.ToString(), "Compruebo si es igual al valor inicial");
            }
        }
    }
}
