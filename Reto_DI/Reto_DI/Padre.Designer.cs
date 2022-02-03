
namespace Reto_DI
{
    partial class Padre
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.formularios = new System.Windows.Forms.ToolStripMenuItem();
            this.formulario1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formulario2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formulario3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.milista = new System.Windows.Forms.ToolStripMenuItem();
            this.formulario4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.formularios,
            this.milista});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // formularios
            // 
            this.formularios.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.formulario1ToolStripMenuItem,
            this.formulario2ToolStripMenuItem,
            this.formulario3ToolStripMenuItem,
            this.formulario4ToolStripMenuItem});
            this.formularios.Name = "formularios";
            this.formularios.Size = new System.Drawing.Size(82, 20);
            this.formularios.Text = "Formularios";
            // 
            // formulario1ToolStripMenuItem
            // 
            this.formulario1ToolStripMenuItem.Name = "formulario1ToolStripMenuItem";
            this.formulario1ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.formulario1ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.formulario1ToolStripMenuItem.Text = "Formulario 1";
            this.formulario1ToolStripMenuItem.Click += new System.EventHandler(this.formulario1ToolStripMenuItem_Click);
            // 
            // formulario2ToolStripMenuItem
            // 
            this.formulario2ToolStripMenuItem.Name = "formulario2ToolStripMenuItem";
            this.formulario2ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.formulario2ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.formulario2ToolStripMenuItem.Text = "Formulario 2";
            this.formulario2ToolStripMenuItem.Click += new System.EventHandler(this.formulario2ToolStripMenuItem_Click);
            // 
            // formulario3ToolStripMenuItem
            // 
            this.formulario3ToolStripMenuItem.Name = "formulario3ToolStripMenuItem";
            this.formulario3ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.formulario3ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.formulario3ToolStripMenuItem.Text = "Formulario 3";
            this.formulario3ToolStripMenuItem.Click += new System.EventHandler(this.formulario3ToolStripMenuItem_Click);
            // 
            // milista
            // 
            this.milista.Name = "milista";
            this.milista.Size = new System.Drawing.Size(94, 20);
            this.milista.Text = "Form Abiertos";
            // 
            // formulario4ToolStripMenuItem
            // 
            this.formulario4ToolStripMenuItem.Name = "formulario4ToolStripMenuItem";
            this.formulario4ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.formulario4ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.formulario4ToolStripMenuItem.Text = "Formulario 4";
            this.formulario4ToolStripMenuItem.Click += new System.EventHandler(this.formulario4ToolStripMenuItem_Click);
            // 
            // Padre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Padre";
            this.Text = "Padre";
            this.Load += new System.EventHandler(this.Padre_Load);
            this.MdiChildActivate += new System.EventHandler(this.Padre_MdiChildActivate);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem formularios;
        private System.Windows.Forms.ToolStripMenuItem milista;
        private System.Windows.Forms.ToolStripMenuItem formulario2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formulario3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formulario1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formulario4ToolStripMenuItem;
    }
}