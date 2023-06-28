using lb4_5.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AFClass;
namespace lb4_5
{
    public partial class Form1 : Form
    {
        
        
        public Form1()
        {
            InitializeComponent();
        }

       


        
        public class Picture
        {
            public PictureBox pic;
            public Picture(AbstractFactory factory,Point p)
            {
                pic = factory.CreatePicture(p);
            }
        }

        private void котикиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            Point p=new Point(10,10);
            Picture picCreate = new Picture(ConcreteFactory1.Instance, p);
            this.panel1.Controls.Add(picCreate.pic);
        }

        private void собачкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            Point p = new Point(10, 10);
            Picture picCreate = new Picture(ConcreteFactory2.Instance, p);
            this.panel1.Controls.Add(picCreate.pic);
        }

        private void cleanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
        }
    }


}
