using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace lab_6_7
{
    internal class Controller
    {
        private Model model;

        public Controller(Model model)
        {
            this.model = model;
        }
        public void Check()
        {
            model.CheckClick();
        }
        public int giveResult()
        {
            return model.Score;
        }
        public int giveError()
        {
            return model.ErrorCount;
        }
    }
}
