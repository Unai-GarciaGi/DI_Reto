
namespace Reto_DI
{
    partial class Form3
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.btnMostrar = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.txtPais = new System.Windows.Forms.TextBox();
            this.btnPais = new System.Windows.Forms.Button();
            this.PeliculasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.EmpresaDataSet1 = new Reto_DI.EmpresaDataSet1();
            this.PeliculasTableAdapter = new Reto_DI.EmpresaDataSet1TableAdapters.PeliculasTableAdapter();
            this.btnTransac = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PeliculasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpresaDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnMostrar
            // 
            this.btnMostrar.Location = new System.Drawing.Point(12, 12);
            this.btnMostrar.Name = "btnMostrar";
            this.btnMostrar.Size = new System.Drawing.Size(100, 23);
            this.btnMostrar.TabIndex = 0;
            this.btnMostrar.Text = "Mostrar";
            this.btnMostrar.UseVisualStyleBackColor = true;
            this.btnMostrar.Click += new System.EventHandler(this.btnMostrar_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(119, 13);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // btnBorrar
            // 
            this.btnBorrar.Location = new System.Drawing.Point(12, 41);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(100, 23);
            this.btnBorrar.TabIndex = 2;
            this.btnBorrar.Text = "Borrar";
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.PeliculasBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Reto_DI.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 140);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(776, 304);
            this.reportViewer1.TabIndex = 3;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // txtPais
            // 
            this.txtPais.Location = new System.Drawing.Point(119, 73);
            this.txtPais.Name = "txtPais";
            this.txtPais.Size = new System.Drawing.Size(121, 20);
            this.txtPais.TabIndex = 4;
            // 
            // btnPais
            // 
            this.btnPais.Location = new System.Drawing.Point(12, 70);
            this.btnPais.Name = "btnPais";
            this.btnPais.Size = new System.Drawing.Size(100, 23);
            this.btnPais.TabIndex = 5;
            this.btnPais.Text = "Pais";
            this.btnPais.UseVisualStyleBackColor = true;
            this.btnPais.Click += new System.EventHandler(this.btnPais_Click);
            // 
            // PeliculasBindingSource
            // 
            this.PeliculasBindingSource.DataMember = "Peliculas";
            this.PeliculasBindingSource.DataSource = this.EmpresaDataSet1;
            // 
            // EmpresaDataSet1
            // 
            this.EmpresaDataSet1.DataSetName = "EmpresaDataSet1";
            this.EmpresaDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // PeliculasTableAdapter
            // 
            this.PeliculasTableAdapter.ClearBeforeFill = true;
            // 
            // btnTransac
            // 
            this.btnTransac.Location = new System.Drawing.Point(407, 40);
            this.btnTransac.Name = "btnTransac";
            this.btnTransac.Size = new System.Drawing.Size(75, 23);
            this.btnTransac.TabIndex = 6;
            this.btnTransac.Text = "Transaccion";
            this.btnTransac.UseVisualStyleBackColor = true;
            this.btnTransac.Click += new System.EventHandler(this.btnTransac_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 510);
            this.Controls.Add(this.btnTransac);
            this.Controls.Add(this.btnPais);
            this.Controls.Add(this.txtPais);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnMostrar);
            this.Name = "Form3";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PeliculasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpresaDataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMostrar;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnBorrar;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource PeliculasBindingSource;
        private EmpresaDataSet1 EmpresaDataSet1;
        private EmpresaDataSet1TableAdapters.PeliculasTableAdapter PeliculasTableAdapter;
        private System.Windows.Forms.TextBox txtPais;
        private System.Windows.Forms.Button btnPais;
        private System.Windows.Forms.Button btnTransac;
    }
}