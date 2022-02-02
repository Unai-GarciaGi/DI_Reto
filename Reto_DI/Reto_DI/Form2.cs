using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
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
        private const string fichXML = "XML/fichero.xml";
        private string sql;
        private MiConexion Conexion = new MiConexion();
        //SqlCommand cmd = new SqlCommand(sql, Conexion.pConexion);
        //Conexion.AbrirConexion();
        private Boolean cambioBuscar;
        private int posicion;

        private void Form2_Load(object sender, EventArgs e)
        {
            cambioBuscar = true;
            // TODO: esta línea de código carga datos en la tabla 'empresaDataSet.Vendedores' Puede moverla o quitarla según sea necesario.
            //this.vendedoresTableAdapter.Fill(this.empresaDataSet.Vendedores);
            sql = "SELECT CodVend, NombVen, DirecVen, Telefono, Salario FROM Vendedores";
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

        private void btnGuardar_click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable) dataGridView1.DataSource;
            dt.WriteXml(fichXML);
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds.ReadXml(fichXML);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //NO SE COMO FUNCIONA ESTO TENGO QUE PREGUNTAR
            OleDbConnection conn = null;
            conn = new OleDbConnection("Server=LOCALHOST;DataBase=Empresa;Integrated Security=true");
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            //Creo el comando
            adapter.UpdateCommand = new OleDbCommand("UPDATE Vendedores SET NombVen = ?, DirecVen = ?, Telefono = ? WHERE CodVend = ?", conn);
            //Añado los parámetros
            adapter.UpdateCommand.Parameters.Clear();
            OleDbParameter pNombre = new OleDbParameter("NombVen", -1);
            pNombre.OleDbType = OleDbType.VarChar;
            pNombre.SourceColumn = "NombVen";
            pNombre.ParameterName = "NombVen";
            adapter.UpdateCommand.Parameters.Add(pNombre);
            OleDbParameter pDirec = new OleDbParameter("DirecVen", -1);
            pNombre.OleDbType = OleDbType.VarChar;
            pNombre.SourceColumn = "DirecVen";
            pNombre.ParameterName = "DirecVen";
            adapter.UpdateCommand.Parameters.Add(pDirec);
            OleDbParameter pTelefono = new OleDbParameter("Telefono", -1);
            pNombre.OleDbType = OleDbType.VarChar;
            pNombre.SourceColumn = "Telefono";
            pNombre.ParameterName = "Telefono";
            adapter.UpdateCommand.Parameters.Add(pTelefono);
            OleDbParameter pCod = new OleDbParameter("CodVend", -1);
            pNombre.OleDbType = OleDbType.Integer;
            pNombre.SourceColumn = "CodVend";
            pNombre.ParameterName = "CodVend";
            adapter.UpdateCommand.Parameters.Add(pCod);
            //Inserto el adaptador en el commandBuilder
            OleDbCommandBuilder cb = new OleDbCommandBuilder(adapter);
            conn.Open();
            adapter.Update((DataTable) dataGridView1.DataSource);
            conn.Close();
        }

        private void btnAddX_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows[0].Cells[2].Value = dataGridView1.Rows[0].Cells[2].Value.ToString() + "x";
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if(dataGridView1.Rows[0].Cells[2].Value.ToString().Length != 0)
            {
                dataGridView1.Rows[0].Cells[2].Value = dataGridView1.Rows[0].Cells[2].Value.ToString().Substring(0, dataGridView1.Rows[0].Cells[2].Value.ToString().Length - 1);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                txtNombre.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtSalario.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            }
        }

        private void btnFila_Click(object sender, EventArgs e)
        {
            try
            {
                int fila = Convert.ToInt32(txtFila.Text.ToString());
                for(int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dataGridView1.Rows[i].Selected = false;
                }
                dataGridView1.Rows[fila - 1].Selected = true;
                dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.SelectedRows[0].Index;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Debes introducir un número de fila válido");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
             CambioBuscar se actualiza cada vez que cambia el texto
            Si ha cambiado, entonces vuelvo a buscar por nombre
            Y escojo el primer nombre entre todas las filas que salen
            Si no ha cambiado, entonces paso a la siguiente
             */
            if(cambioBuscar)
            {
                try
                {
                    String nombre = txtNombreBuscar.Text.ToString();
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        if (dataGridView1.Rows[i].Cells[1].Value != null && dataGridView1.Rows[i].Cells[1].Value.ToString().Contains(nombre))
                        {
                            dataGridView1.Rows[i].Selected = true;
                        }
                        else
                        {
                            dataGridView1.Rows[i].Selected = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    MessageBox.Show(ex.Message);
                }
                posicion = 0;
                dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.SelectedRows[posicion].Index;
            }
            else
            {
                posicion++;
                if(dataGridView1.SelectedRows.Count > posicion)
                {
                    dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.SelectedRows[posicion].Index;
                }
                else
                {
                    posicion = 0;
                    dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.SelectedRows[posicion].Index;
                }
            }
            
        }

        private void txtNombreBuscar_TextChanged(object sender, EventArgs e)
        {
            cambioBuscar = true;
        }
    }
}
