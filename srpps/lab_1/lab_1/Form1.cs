using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_1
{
   
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double degree, speed, height;
            double g = 9.81,l;
            try
            {
                degree = Convert.ToDouble(textBox1.Text);
                speed = Convert.ToDouble(textBox3.Text);
                height = Convert.ToDouble(textBox2.Text);
                double v_x = speed * Math.Cos(degree * Math.PI / 180);
                double v_y = speed * Math.Sin(degree * Math.PI / 180);
                l = v_x * (v_y + Math.Sqrt(Math.Pow(v_y,2) + 2 * g * height)) / g;
                result res = new result(Convert.ToString(Math.Round(l,3)));
                res.Show();
            }
            catch
            {
                if (textBox1.Text == "")
                    MessageBox.Show("Не введено значение угла");
                if (textBox3.Text == "")
                    MessageBox.Show("Не введено значение начальной скорости");
                if (textBox2.Text == "")
                    MessageBox.Show("Не введено значение начальной высоты");
                else
                {
                    DialogResult result = MessageBox.Show("Ошибка ввода.\n" + "Неверный формат данных.\n" + "Повторить?",
                                "Ошибка", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    switch (result)
                    {
                        case DialogResult.Yes:
                            textBox1.Text = "";
                            break;
                        case DialogResult.No:
                            this.Close();
                            break;
                    }
                }

                
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            info info = new info();
            info.Show();
        }
    }
}
