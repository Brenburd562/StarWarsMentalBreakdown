using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StarWarsBNBGrid
{
    public partial class Form1 : Form
    {
        Graphics onScreen;

        Bitmap bm;
        Graphics offScreen;
        public Form1()
        {
            InitializeComponent();

            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            onScreen = this.CreateGraphics();
            bm = new Bitmap(this.Width, this.Height);
            offScreen = Graphics.FromImage(bm); 
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            Pen drawpen = new Pen(Color.Black);
            int x = 0, y = 0, gridSize = 25;
            while (y <= this.Height)
            {
                g.DrawLine(drawpen, 0, y, this.Width, y);
                y = y + gridSize;
            }
            while (x <= this.Width)
            {
                g.DrawLine(drawpen, x, 0, x, this.Height);
                x = x + gridSize;
            }
            MainForm_Click(sender, e);
        }
        private void MainForm_Click(object sender, EventArgs e)
        {
            SolidBrush drawbrush = new SolidBrush(Color.Black);
            offScreen.FillRectangle (drawbrush, 25, 0, 25, 25);
            onScreen.DrawImage(bm, 0, 0);
        }
    }
}
