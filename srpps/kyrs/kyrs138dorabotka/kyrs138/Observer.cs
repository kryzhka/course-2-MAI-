using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kyrs138
{
    public interface Observer
    {

        void OnUpdate(double[,] B);
        void UpdateMath(List<string[]> A);
    }
}
