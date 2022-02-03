using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reto_DI
{
    public partial class Padre : Form
    {
        public Padre()
        {
            InitializeComponent();
        }
        public static Form1 f1 = new Form1(); //De esta manera se ve en los demás formularios
        private Form2 f2 = new Form2();
        private Form3 f3 = new Form3();
        private Form4 f4 = new Form4();
        private void Padre_Load(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            this.menuStrip1.MdiWindowListItem = milista;
            f1.MdiParent = this;
            f2.MdiParent = this;
            f3.MdiParent = this;
            f4.MdiParent = this;
            f1.WindowState = FormWindowState.Maximized;
            f2.WindowState = FormWindowState.Maximized;
            f3.WindowState = FormWindowState.Maximized;
            //Cambio el tamaño al de la pantalla
            this.Bounds = f1.Bounds;
            f1.Show();
            f1.Activate();
        }

        private void formulario2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Bounds = f2.Bounds;
            f2.Show();
            f2.Activate();
        }

        private void formulario3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Bounds = f3.Bounds;
            f3.Show();
            f3.Activate();
        }

        private void formulario1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f1.Show();
            f1.Activate();
            this.Bounds = f1.Bounds;
        }

        private void Padre_MdiChildActivate(object sender, EventArgs e)
        {
            
        }

        private void formulario4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f4.Show();
            f4.Activate();
            this.Bounds = f4.Bounds;
        }
    }
}
