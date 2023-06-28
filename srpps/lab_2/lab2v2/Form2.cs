using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace lab2v2
{
    public partial class Form2 : Form
    {
        public double[,] B;
        int row;
        int col;
        public Form2(int n,int m)
        {
            InitializeComponent();
            dataGridView1.RowCount = m;
            dataGridView1.ColumnCount = n;
            row = m;col = n;
            B = new double[n,m];
            

        }
        //private void radioButton1_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (radioButton1.Checked)
        //    {
             
        //        button1.Visible = true;
        //    }
        //    else
        //        button1.Visible = false;

        //}

        //private void radioButton2_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (radioButton2.Checked)
        //    {
        //        checkedListBox1.Visible = true;
        //    }
        //    else
        //        checkedListBox1.Visible = false;
        //}

        //private void trackBar1_Scroll(object sender, EventArgs e)
        //{
        //    foreach (Label lb in groupBox1.Controls.OfType<Label>())
        //    {
        //        lb.Font = new Font("Microsoft Sans Serif", trackBar1.Value);
        //    }
        //    foreach (RadioButton rb in groupBox1.Controls.OfType<RadioButton>())
        //    {
        //        rb.Font = new Font("Microsoft Sans Serif", trackBar1.Value);
        //    }
        //    groupBox1.Font = new Font("Microsoft Sans Serif", trackBar1.Value);
        //}

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    openFileDialog1.ShowDialog();
        //    button1.Text = openFileDialog1.FileName;
        //    double[,] tmp = new double[col, row];
        //    for(int i=0;i<col;++i)
        //    {
        //        for(int j=0;j<row;++j)
        //        {
        //            //tmp[j, i] = Convert.ToDouble(System.IO.File.ReadAllText(openFileDialog1.FileName.ToString()));
        //            tmp[j, i] = Convert.ToDouble(System.IO.File.ReadAllText(openFileDialog1.FileName));
        //        }//крч я считывал фулл файл и пытался преобразовать
        //        //разработай алгопитм поелементного считывания и преобразовывания в дабл
        //    }
        //    //tmp = Convert.ToDouble(System.IO.File.ReadAllText(openFileDialog1.FileName));
        //    for (int i=0;i<col;++i)
        //    {
        //        for(int j=0;j<row;++j)
        //        {
        //            dataGridView1.Rows[i].Cells[j].Value = tmp[i,j];
        //        }
        //    }
        //}

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < col; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    B[i, j] = Convert.ToDouble(dataGridView1.Rows[j].Cells[i].Value);//error
                }
            }
            this.Close();
        }
    }
}
