
namespace Reto_DI
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCargar = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.empresaDataSet = new Reto_DI.EmpresaDataSet();
            this.vendedoresBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vendedoresTableAdapter = new Reto_DI.EmpresaDataSetTableAdapters.VendedoresTableAdapter();
            this.btnAddX = new System.Windows.Forms.Button();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.btnBorrarVend = new System.Windows.Forms.Button();
            this.txtBorrar = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtSalario = new System.Windows.Forms.TextBox();
            this.btnFila = new System.Windows.Forms.Button();
            this.txtFila = new System.Windows.Forms.TextBox();
            this.txtNombreBuscar = new System.Windows.Forms.TextBox();
            this.btnBuscarNombre = new System.Windows.Forms.Button();
            this.empresaDataSet1 = new Reto_DI.EmpresaDataSet();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.empresaDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vendedoresBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.empresaDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 185);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(776, 213);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(13, 13);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(94, 23);
            this.btnGuardar.TabIndex = 1;
            this.btnGuardar.Text = "Guardar XML";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_click);
            // 
            // btnCargar
            // 
            this.btnCargar.Location = new System.Drawing.Point(13, 42);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(94, 23);
            this.btnCargar.TabIndex = 2;
            this.btnCargar.Text = "Cargar XML";
            this.btnCargar.UseVisualStyleBackColor = true;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(13, 71);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(94, 23);
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // empresaDataSet
            // 
            this.empresaDataSet.DataSetName = "EmpresaDataSet";
            this.empresaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // vendedoresBindingSource
            // 
            this.vendedoresBindingSource.DataMember = "Vendedores";
            this.vendedoresBindingSource.DataSource = this.empresaDataSet;
            // 
            // vendedoresTableAdapter
            // 
            this.vendedoresTableAdapter.ClearBeforeFill = true;
            // 
            // btnAddX
            // 
            this.btnAddX.Location = new System.Drawing.Point(13, 101);
            this.btnAddX.Name = "btnAddX";
            this.btnAddX.Size = new System.Drawing.Size(94, 23);
            this.btnAddX.TabIndex = 4;
            this.btnAddX.Text = "Add X";
            this.btnAddX.UseVisualStyleBackColor = true;
            this.btnAddX.Click += new System.EventHandler(this.btnAddX_Click);
            // 
            // btnBorrar
            // 
            this.btnBorrar.Location = new System.Drawing.Point(13, 131);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(94, 23);
            this.btnBorrar.TabIndex = 5;
            this.btnBorrar.Text = "Borrar char";
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // btnBorrarVend
            // 
            this.btnBorrarVend.Location = new System.Drawing.Point(411, 13);
            this.btnBorrarVend.Name = "btnBorrarVend";
            this.btnBorrarVend.Size = new System.Drawing.Size(95, 23);
            this.btnBorrarVend.TabIndex = 6;
            this.btnBorrarVend.Text = "Borrar Vendedor";
            this.btnBorrarVend.UseVisualStyleBackColor = true;
            this.btnBorrarVend.Click += new System.EventHandler(this.btnBorrarVend_Click);
            // 
            // txtBorrar
            // 
            this.txtBorrar.Location = new System.Drawing.Point(513, 15);
            this.txtBorrar.Name = "txtBorrar";
            this.txtBorrar.Size = new System.Drawing.Size(26, 20);
            this.txtBorrar.TabIndex = 7;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(411, 44);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(154, 20);
            this.txtNombre.TabIndex = 8;
            // 
            // txtSalario
            // 
            this.txtSalario.Location = new System.Drawing.Point(571, 45);
            this.txtSalario.Name = "txtSalario";
            this.txtSalario.Size = new System.Drawing.Size(154, 20);
            this.txtSalario.TabIndex = 9;
            // 
            // btnFila
            // 
            this.btnFila.Location = new System.Drawing.Point(411, 71);
            this.btnFila.Name = "btnFila";
            this.btnFila.Size = new System.Drawing.Size(95, 23);
            this.btnFila.TabIndex = 10;
            this.btnFila.Text = "Ir a fila";
            this.btnFila.UseVisualStyleBackColor = true;
            this.btnFila.Click += new System.EventHandler(this.btnFila_Click);
            // 
            // txtFila
            // 
            this.txtFila.Location = new System.Drawing.Point(513, 73);
            this.txtFila.Name = "txtFila";
            this.txtFila.Size = new System.Drawing.Size(26, 20);
            this.txtFila.TabIndex = 11;
            // 
            // txtNombreBuscar
            // 
            this.txtNombreBuscar.Location = new System.Drawing.Point(513, 101);
            this.txtNombreBuscar.Name = "txtNombreBuscar";
            this.txtNombreBuscar.Size = new System.Drawing.Size(212, 20);
            this.txtNombreBuscar.TabIndex = 12;
            this.txtNombreBuscar.TextChanged += new System.EventHandler(this.txtNombreBuscar_TextChanged);
            // 
            // btnBuscarNombre
            // 
            this.btnBuscarNombre.Location = new System.Drawing.Point(411, 101);
            this.btnBuscarNombre.Name = "btnBuscarNombre";
            this.btnBuscarNombre.Size = new System.Drawing.Size(95, 23);
            this.btnBuscarNombre.TabIndex = 13;
            this.btnBuscarNombre.Text = "Buscar Nombre";
            this.btnBuscarNombre.UseVisualStyleBackColor = true;
            this.btnBuscarNombre.Click += new System.EventHandler(this.btnBuscarNombre_Click);
            // 
            // empresaDataSet1
            // 
            this.empresaDataSet1.DataSetName = "EmpresaDataSet";
            this.empresaDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnBuscarNombre);
            this.Controls.Add(this.txtNombreBuscar);
            this.Controls.Add(this.txtFila);
            this.Controls.Add(this.btnFila);
            this.Controls.Add(this.txtSalario);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtBorrar);
            this.Controls.Add(this.btnBorrarVend);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.btnAddX);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnCargar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.empresaDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vendedoresBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.empresaDataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.Button btnUpdate;
        private EmpresaDataSet empresaDataSet;
        private System.Windows.Forms.BindingSource vendedoresBindingSource;
        private EmpresaDataSetTableAdapters.VendedoresTableAdapter vendedoresTableAdapter;
        private System.Windows.Forms.Button btnAddX;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Button btnBorrarVend;
        private System.Windows.Forms.TextBox txtBorrar;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtSalario;
        private System.Windows.Forms.Button btnFila;
        private System.Windows.Forms.TextBox txtFila;
        private System.Windows.Forms.TextBox txtNombreBuscar;
        private System.Windows.Forms.Button btnBuscarNombre;
        private EmpresaDataSet empresaDataSet1;
    }
}