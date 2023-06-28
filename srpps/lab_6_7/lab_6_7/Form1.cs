using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Timer = System.Timers.Timer;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace lab_6_7
{
    
    public partial class Form1 : Form, Observer
    {
        private Controller controller_l;
        private Model model_l;
        
        public Form1(Model model)
        {
            InitializeComponent();
            this.model_l=model;
            this.model_l.register(this);
            controller_l = new Controller(this.model_l);
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            int timeOfTick = 0;
            
            try
            {
                timeOfTick = Convert.ToInt32(textBox1.Text);
                ModelConfig config = new ModelConfig(timeOfTick);
                if(model_l.SwitchEnable)
                {
                    model_l.SwitchOff();
                    button1.Text = "Запустить";
                }
                else
                {
                    model_l.SwitchOn(config);
                    textBox2.Text = "0";
                    textBox3.Text="0";
                    button1.Text = "Остановить";
                }
            }
            catch
            {
                MessageBox.Show("Не введено количетво времени между появлением кнопок");
            }
            
        }

        
        delegate void SetTextCallback(string text);

        public void SetText(string text)
        {
            
            if (this.button2.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.button2.Text = text;
            }
        }

       

        
        private void button2_Click(object sender, EventArgs e)
        {
            controller_l.Check();
            
            
            this.textBox2.Text = controller_l.giveError().ToString();
            
            
            this.textBox3.Text = controller_l.giveResult().ToString();
            
        }
    }
}
