using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using System.Numerics;
namespace lab2v2
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            foreach (Label lb in groupBox1.Controls.OfType<Label>())
            {
                lb.Font = new Font("Microsoft Sans Serif", trackBar1.Value);
            }
            foreach (Label lb in groupBox3.Controls.OfType<Label>())
            {
                lb.Font = new Font("Microsoft Sans Serif", trackBar1.Value);
            }
            groupBox1.Font = new Font("Microsoft Sans Serif", trackBar1.Value);
        }
        public int n;
        public int m;
        public double[,] A,B,C,D;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                n = Convert.ToInt32(textBox1.Text);
                m = Convert.ToInt32(textBox2.Text);//error


                A = new double[n, m];
                Form2 entering = new Form2(n, m);

                entering.Show();
                A = entering.B;
            }
            catch
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Введите количество строк");
                }
                if(textBox2.Text=="")
                {
                    MessageBox.Show("Введите количество столбцов");
                }
            }
            //result res = new result(A, n, m);
            //res.Show();
        }

        private void button2_Click(object sender, EventArgs e)//вывод ответа
        {
            //будем смотреть на количество матриц
            //if (textBox1.Text == "")
            //{
            //    MessageBox.Show("Введите количество строк");
            //}
            //if (textBox2.Text == "")
            //{
            //    MessageBox.Show("Введите количество столбцов");
            //}
            try
            {
                if (radioButton1.Checked)
                {

                    if (numericUpDown1.Value == 2)
                    {
                        if (A == null)
                        {
                            MessageBox.Show("Введите матрицу A");
                            return;
                        }
                        if (B==null)
                        {
                            MessageBox.Show("Введите матрицу В");
                            return;
                        }
                        for (int i = 0; i < Convert.ToInt32(this.textBox1.Text); ++i)
                        {
                            for (int j = 0; j < Convert.ToInt32(this.textBox2.Text); ++j)
                            {
                                A[i, j] = A[i, j] + B[i, j];
                            }
                        }
                    }
                    else if (numericUpDown1.Value == 3)
                    {
                        if (A == null)
                        {
                            MessageBox.Show("Введите матрицу A");
                            return;
                        }
                        if (B == null)
                        {
                            MessageBox.Show("Введите матрицу В");
                            return;
                        }
                        if (C == null)
                        {
                            MessageBox.Show("Введите матрицу C");
                            return;
                        }
                        for (int i = 0; i < Convert.ToInt32(this.textBox1.Text); ++i)
                        {
                            for (int j = 0; j < Convert.ToInt32(this.textBox2.Text); ++j)
                            {
                                A[i, j] = A[i, j] + B[i, j] + C[i, j];
                            }
                        }
                    }
                    else if (numericUpDown1.Value == 4)
                    {
                        if (A == null)
                        {
                            MessageBox.Show("Введите матрицу A");
                            return;
                        }
                        if (B == null)
                        {
                            MessageBox.Show("Введите матрицу В");
                            return;
                        }
                        if (C == null)
                        {
                            MessageBox.Show("Введите матрицу C");
                            return;
                        }
                        if (D == null)
                        {
                            MessageBox.Show("Введите матрицу D");
                            return;
                        }
                        for (int i = 0; i < Convert.ToInt32(this.textBox1.Text); ++i)
                        {
                            for (int j = 0; j < Convert.ToInt32(this.textBox2.Text); ++j)
                            {
                                A[i, j] = A[i, j] + B[i, j] + C[i, j] + D[i, j];
                            }
                        }
                    }

                }
                else if (radioButton2.Checked)
                {

                    if (numericUpDown1.Value == 2)
                    {
                        if (A == null)
                        {
                            MessageBox.Show("Введите матрицу A");
                            return;
                        }
                        if (B == null)
                        {
                            MessageBox.Show("Введите матрицу В");
                            return;
                        }
                        for (int i = 0; i < Convert.ToInt32(this.textBox1.Text); ++i)
                        {
                            for (int j = 0; j < Convert.ToInt32(this.textBox2.Text); ++j)
                            {
                                A[i, j] = A[i, j] - B[i, j];
                            }
                        }
                    }
                    else if (numericUpDown1.Value == 3)
                    {
                        if (A == null)
                        {
                            MessageBox.Show("Введите матрицу A");
                            return;
                        }
                        if (B == null)
                        {
                            MessageBox.Show("Введите матрицу В");
                            return;
                        }
                        if (C == null)
                        {
                            MessageBox.Show("Введите матрицу C");
                            return;
                        }
                        for (int i = 0; i < Convert.ToInt32(this.textBox1.Text); ++i)
                        {
                            for (int j = 0; j < Convert.ToInt32(this.textBox2.Text); ++j)
                            {
                                A[i, j] = A[i, j] - B[i, j] - C[i, j];
                            }
                        }
                    }
                    else if (numericUpDown1.Value == 4)
                    {
                        if (A == null)
                        {
                            MessageBox.Show("Введите матрицу A");
                            return;
                        }
                        if (B == null)
                        {
                            MessageBox.Show("Введите матрицу В");
                            return;
                        }
                        if (C == null)
                        {
                            MessageBox.Show("Введите матрицу C");
                            return;
                        }
                        if (D == null)
                        {
                            MessageBox.Show("Введите матрицу D");
                            return;
                        }
                        for (int i = 0; i < Convert.ToInt32(this.textBox1.Text); ++i)
                        {
                            for (int j = 0; j < Convert.ToInt32(this.textBox2.Text); ++j)
                            {
                                A[i, j] = A[i, j] - B[i, j] - C[i, j] - D[i, j];
                            }
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Выберите операцию");
                }
                result res = new result(A, n, m);
                res.Show();
            }
            catch
            {
                
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Введите количество строк");
                }
                if (textBox2.Text == "")
                {
                    MessageBox.Show("Введите количество столбцов");
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if(numericUpDown1.Value==3)
            {
                this.button4.Visible = true;
                this.label8.Visible = true;
                this.button5.Visible = false;
                this.label9.Visible = false;
                this.checkedListBox3.Visible = true;
                this.checkedListBox4.Visible = false;
            }
            if(numericUpDown1.Value==4)
            {
                this.button4.Visible = true;
                this.label8.Visible = true;
                this.button5.Visible = true;
                this.label9.Visible = true;
                this.checkedListBox3.Visible = true;
                this.checkedListBox4.Visible = true;
            }
            if(numericUpDown1.Value==2)
            {
                this.button4.Visible = false;
                this.label8.Visible = false;
                this.button5.Visible = false;
                this.label9.Visible = false;
                this.checkedListBox3.Visible = false;
                this.checkedListBox4.Visible = false;
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                n = Convert.ToInt32(textBox1.Text);
                m = Convert.ToInt32(textBox2.Text);
                A = new double[n, m];
                
                if (checkedListBox1.CheckedItems.Contains("Единичная матрица"))
                {
                    for (int i = 0; i < n; i++)
                        A[i, i] = 1;
                    
                }
                else if (checkedListBox1.CheckedItems.Contains("Нулевая матрица"))
                {
                    for(int i= 0; i < n; i++)
                    {
                        for(int j=0;j<m;j++)
                        {
                            A[i, j] = 0;
                        }    
                    }
                    
                }
                
            }
            catch
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Введите количество строк");
                }
                if (textBox2.Text == "")
                {
                    MessageBox.Show("Введите количество столбцов");
                }
            }
        }

        private void checkedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                n = Convert.ToInt32(textBox1.Text);
                m = Convert.ToInt32(textBox2.Text);
                B = new double[n, m];

                if (checkedListBox2.CheckedItems.Contains("Единичная матрица"))
                {
                    for (int i = 0; i < n; i++)
                        B[i, i] = 1;

                }
                else if (checkedListBox2.CheckedItems.Contains("Нулевая матрица"))
                {
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < m; j++)
                        {
                            B[i, j] = 0;
                        }
                    }

                }

            }
            catch
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Введите количество строк");
                }
                if (textBox2.Text == "")
                {
                    MessageBox.Show("Введите количество столбцов");
                }
            }
        }

        private void checkedListBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                n = Convert.ToInt32(textBox1.Text);
                m = Convert.ToInt32(textBox2.Text);
                C = new double[n, m];

                if (checkedListBox3.CheckedItems.Contains("Единичная матрица"))
                {
                    for (int i = 0; i < n; i++)
                        C[i, i] = 1;

                }
                else if (checkedListBox3.CheckedItems.Contains("Нулевая матрица"))
                {
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < m; j++)
                        {
                            C[i, j] = 0;
                        }
                    }

                }

            }
            catch
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Введите количество строк");
                }
                if (textBox2.Text == "")
                {
                    MessageBox.Show("Введите количество столбцов");
                }
            }
        }

        private void checkedListBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                n = Convert.ToInt32(textBox1.Text);
                m = Convert.ToInt32(textBox2.Text);
                D = new double[n, m];

                if (checkedListBox4.CheckedItems.Contains("Единичная матрица"))
                {
                    for (int i = 0; i < n; i++)
                        D[i, i] = 1;

                }
                else if (checkedListBox4.CheckedItems.Contains("Нулевая матрица"))
                {
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < m; j++)
                        {
                            D[i, j] = 0;
                        }
                    }

                }

            }
            catch
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Введите количество строк");
                }
                if (textBox2.Text == "")
                {
                    MessageBox.Show("Введите количество столбцов");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            try
            {
                n = Convert.ToInt32(textBox1.Text);
                m = Convert.ToInt32(textBox2.Text);//error


                B = new double[n, m];
                Form2 entering = new Form2(n, m);

                entering.Show();
                B = entering.B;
            }
            catch
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Введите количество строк");
                }
                if (textBox2.Text == "")
                {
                    MessageBox.Show("Введите количество столбцов");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                n = Convert.ToInt32(textBox1.Text);
                m = Convert.ToInt32(textBox2.Text);//error


                C = new double[n, m];
                Form2 entering = new Form2(n, m);

                entering.Show();
                C = entering.B;
            }
            catch
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Введите количество строк");
                }
                if (textBox2.Text == "")
                {
                    MessageBox.Show("Введите количество столбцов");
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                n = Convert.ToInt32(textBox1.Text);
                m = Convert.ToInt32(textBox2.Text);//error


                D = new double[n, m];
                Form2 entering = new Form2(n, m);

                entering.Show();
                D = entering.B;
            }
            catch
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Введите количество строк");
                }
                if (textBox2.Text == "")
                {
                    MessageBox.Show("Введите количество столбцов");
                }
            }
        }
    }
}
