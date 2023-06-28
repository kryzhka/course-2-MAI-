using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kyrs138
{
    public partial class Form1 : Form
    {

        public int n;
        private Model model;
        private Controller controller;
        public Form1(Model model_l)
        {
            n = 0;
            InitializeComponent();
            this.model = model_l;
            controller = new Controller(model);
        }

        public void MatrixInTable1(double[,]M)//v
        {
            //A = new double [n,n];
            for (int i = 0; i < n; i++)
            {
                for (int j=0; j < n; j++)
                {
                    dataGridView1.Rows[j].Cells[i].Value = M[i, j];
                }
            }
        }
        public void MatrixInTable2(double[,] M)//v
        {
            //A = new double [n,n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    dataGridView2.Rows[j].Cells[i].Value = M[i, j];
                }
            }
        }
        public double[,] Table1ToMatrix()
        {
            double[,] A = new double[n, n];
            for(int i=0;i<n;i++)
            {
                for(int j=0;j<n;j++)
                {
                    A[i, j] =Convert.ToDouble( dataGridView1.Rows[j].Cells[i].Value);
                }
            }
            return A;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
            n = Convert.ToInt32(this.numericUpDown1.Value);
            if(n<=0)
            {
                MessageBox.Show("Введите размер матрицы больший нуля");
                return;
            }
            dataGridView1.RowCount = n;
            dataGridView1.ColumnCount = n;
            dataGridView2.RowCount = n;
            dataGridView2.ColumnCount = n;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = 0;
                }
            }
            MatrixInTable1(controller.getRandomMatrix());
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            
            MatrixInTable2(controller.getOrthonormalMatrix());
            textBox1.Text = controller.Check().ToString("F4");
           
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            n = Convert.ToInt32(this.numericUpDown1.Value);
            dataGridView1.RowCount = n;
            dataGridView1.ColumnCount = n;
            dataGridView2.RowCount = n;
            dataGridView2.ColumnCount = n;
            controller.SetSizeOfMatrix(n);
            
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    
                    dataGridView1.Rows[i].Cells[j].Value = 0;
                    dataGridView2.Rows[i].Cells[j].Value = 0;

                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                controller.SetMatrix(Table1ToMatrix());
                MessageBox.Show("Данные введены");
            }
            catch
            {
                MessageBox.Show("Некоректные данные");
            }
        }
    }
}
