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
using System.Drawing.Text;
using System.Collections;

namespace lab_6_7
{
    public class ModelConfig
    {
        public int TimerTickInterval;
        public ModelConfig(int TickInterval)
        {
            TimerTickInterval = TickInterval; 
        }
        


    }
    public class Model
    {
        public int timeTick = 0;
        public bool SwitchEnable;
        private Timer timerOfTick;
        public int Score;
        public int ErrorCount;
        public int flag;
        private ArrayList Listeners;

        public delegate void SetTextCallback(string text);
        public delegate void UpdateDelegate();

        public event SetTextCallback SetText;
        public event UpdateDelegate OnUpdate;

        public Model()
        {
            SwitchEnable = false;
            timerOfTick = new Timer();
            timerOfTick.AutoReset = true;
            
            timerOfTick.Enabled = false;
            timerOfTick.Elapsed += new ElapsedEventHandler(TimerTickButton);
            //timerOfTick.Start();
            Score = 0;
            ErrorCount = 0;
            flag = 1;
            Listeners = new ArrayList();
            

        }
        public void register(Observer listener)
        {
            Listeners.Add(listener);
            SetText += listener.SetText;
            
        }
        private void TimerTickButton(object sender, ElapsedEventArgs e)
        {
            if (flag == 1)
            {
                SetText?.Invoke("Жми на кнопку");//как это реализовать
                flag = 0;
            }
            else
            {
                SetText?.Invoke("");
                flag = 1;
            }
        }
        public void SwitchOff()
        {
            SwitchEnable=false;
            timerOfTick.Stop();
        }
        public void SwitchOn(ModelConfig config)
        {
            timerOfTick.Interval = config.TimerTickInterval;
            SwitchEnable = true;
            flag = 1;
            ErrorCount = 0;
            Score = 0;
            timerOfTick.Start();
        }
        public void CheckClick()
        {
            if (flag == 1)
            {
                ErrorCount++;
            }
            else
                Score++;
        }
        
    }
}
