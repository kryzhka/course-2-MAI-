using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace kyrs138
{
    public partial class Form1 : Form,Observer
    {

        public int n;
        private Model model;
        private Controller controller;
        public Form1(Model model_l)
        {
            n = 0;
            InitializeComponent();
            this.model = model_l;
            model.register(this);
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
        //delegate void MatrixCallback(double[,] Matrix);
        //public void OnUpdate(double[,] B)
        //{
        //    if (this.dataGridView2.InvokeRequired)
        //    {
        //        MatrixCallback d = new MatrixCallback(OnUpdate);
        //        this.Invoke(d, new object[] { B });
        //    }
        //    else
        //    {
        //        label5.Text = B.ToString();
        //        MatrixInTable2(B);
        //    }

        //}
        public void OnUpdate(double[,] b)
        {
            
            MatrixInTable2(b);
            this.dataGridView2.Refresh();
        }
        public void UpdateMath(List<string[]> A)
        {
            ArrayOfVectorToTable3(A);
            this.dataGridView3.Refresh();
        }
        public void ArrayOfVectorToTable3(List<string[]> A)
        {
            dataGridView3.RowCount = n;
            dataGridView3.ColumnCount = A.Count;
            
            for (int i = 0; i < A.Count; i++)
            {
                for( int j = 0; j < n; j++)
                {
                    
                    dataGridView3.Rows[j].Cells[i].Value = A[i][j];
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


            
            controller.getOrthonormalMatrix();
            
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
