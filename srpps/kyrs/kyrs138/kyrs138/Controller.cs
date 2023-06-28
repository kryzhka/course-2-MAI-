using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kyrs138
{
    internal class Controller
    {
        private Model model;

        public Controller(Model model_in)
        {
            this.model = model_in;
        }
        public double[,] getRandomMatrix()
        {
            return model.enterRandomNumbers();
        }
        public void SetSizeOfMatrix(int n)
        {
            model.putSizeOfMatrix(n);
        }
        public double[,] getOrthonormalMatrix()
        {
            return model.OrthonormalMatrix();
        }
        public double Check()
        {
            return model.checkMatrix();
        }
        public void SetMatrix(double[,] M)
        {
            model.getMatrix(M);
        }
    }
}
