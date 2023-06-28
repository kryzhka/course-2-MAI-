using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Threading;
using System.Collections;

namespace kyrs138
{
    public class Model
    {
        //public delegate void MatrixCallback(double[,] Matrix);
        //public event MatrixCallback OnUpdate;
        private ArrayList Listeners;
        private List<string[]> VectorMath;
        double[,] M;
        Random rand;
        public int n;
        double[,] B;

        public Model()
        {
            rand = new Random();
            n = 0;
            Listeners = new ArrayList();
            VectorMath = new List<string[]>();
            
        }
        public void putSizeOfMatrix(int size)
        {
            n = size;
            M = new double[n, n];
            
        }
        public void register(Observer listener)
        {
            Listeners.Add(listener);
            //OnUpdate += listener.OnUpdate;

        }
        
        public string[] numberToVector(double number, int i)
        {
            string [] vector = new string[n];
            vector[i] = number.ToString();
            return vector;
        }

        public void UpdateObservers()
        {
            foreach(Observer observer in Listeners)
            {
                observer.OnUpdate(B);
                observer.UpdateMath(VectorMath);
            }
        }
        public double checkMatrix()//проверка матрицы на ортогональность
        {
            double[] A = new double[n];
            double[] B = new double[n];
            double max = 0;
            double c=0;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    A = getRow(M, i);
                    B = getRow(M, j);
                    c = scalarPr(A, B);

                    if (c > max)
                        max = c;
                }

            }
            return c;
        }
        public double[,] enterRandomNumbers()//заполнение матрицы рандомными числами
        {
            
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (rand.Next(1, 2) == 1)
                    {
                        M[i, j] = 1.00 / rand.Next(-20, -1);
                        
                    }
                    else
                    {
                        M[i, j] = 1.00 / rand.Next(1, 20);
                        
                    }

                }
            }
            return M;
        }
        public void getMatrix(double[,] a)
        {
            M = a;
        }
        public double scalarPr(double[] A, double[] B)//Скалярное произведение векторов
        {
            double c = 0;
            for (int i = 0; i < n; i++)
            {
                c += A[i] * B[i];
            }
            return c;
        }
        public string[] charToVector(string c,int i)
        {
            string[] A = new string[n];
            A[i] = c;
            return A;
        }
        public double[] vectorSub(double[] A, double[] B)//разность векторов
        {
            double[] C = new double[n];
            for (int i = 0; i < n; i++)
            {
                
                
                C[i] = A[i] - B[i];
            }
            return C;
        }
        public double[] getRow(double[,] A, int index)//получение строки
        {
            double[] C = new double[n];
            for (int j = 0; j < n; j++)
            {
                C[j] = A[index, j];
            }
            return C;
        }
        public double[] getColl(double[,] A, int index)//получение столбца
        {
            double[] C = new double[n];
            for (int j = 0; j < n; j++)
            {
                C[j] = A[j, index];
            }
            return C;
        }
        public double[] vectorSum(double[] A, double[] B)//сумма векторов
        {
            double[] C = new double[n];
            for (int i = 0; i < n; i++)
            {
                C[i] = A[i] + B[i];
            }
            return C;
        }
        public double[] Multiplication(double A, double[] B)//произведение вектрора на число
        {
            double[] C = new double[n];

            for (int i = 0; i < n; i++)
            {
                C[i] = B[i] * A;
            }
            return C;
        }
        public double[] vectorMultiplication(double[] A, double[] B)//произведение векторов
        {
            double[] C = new double[n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    C[i] += A[i] * B[j];
                }
            }
            return C;
        }
        public string[] DoubToStr(double[]A)
        {
            string[] B = new string[n];
            for(int i=0;i<n;i++)
            {
                B[i] = A[i].ToString();
            }
            return B;
        }
        public double[] sumOfscalar(int i, double[,] B)//сумма проекций векторов
        {
            double[] C = new double[n];
            string[] A = new string[n];
            for (int j = 0; j < i; j++)//summ=scalarproisv(mixmj)xmj
            {
                C = vectorSum(C, Multiplication(scalarPr(getRow(M, i), getRow(B, j)) / scalarPr(getRow(B, j), getRow(B, j)), getRow(B, j)));
                
                
                A =DoubToStr( getRow(B, j));
                VectorMath.Add(A);
                A = numberToVector(scalarPr(getRow(M, i), getRow(B, j)), n-2);
                A[n-1] = scalarPr(getRow(B, j), getRow(B, j)).ToString();
                VectorMath.Add(A);
                VectorMath.Add(charToVector("-", n-1));
                // an-сумма проекция an на bj j=1 -> n-1
            }
            return C;
        }
        public double[] normalization(double[] A)
        {
            double c = 0;
            c = Math.Sqrt(scalarPr(A, A));
            if (c != 0)
            {

                for (int i = 0; i < n; i++)
                {
                    A[i] = A[i] / c;
                }
            }
            return A;
        }
        
        public void OrthonormalMatrix()//вычисление с помошбю грамма-шмидта
        {
            double[] C = new double[n];
            B = new double[n, n];
            //double[,] X = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                Thread.Sleep(2000);
                C = vectorSub(getRow(M, i), sumOfscalar(i, B));//mi-sum

                VectorMath.Add(DoubToStr(getRow(M,i)));
                VectorMath.Add(charToVector("=", n-1));
                VectorMath.Add(DoubToStr(C));
                C =normalization(C);
                
                //dataGridView1.Rows[i] = vectorSubtraction(dataGridView1.Rows[i], sumOfscalar(scalarPr(scalarPr()) , i));
                for (int j = 0; j < n; j++)
                {
                    //dataGridView2.Rows[j].Cells[i].Value = C[j];
                   // X[j, i] = C[j];
                    B[i, j] = C[j];
                    //OnUpdate?.Invoke(B);
                    
                }
                VectorMath.Reverse();
                UpdateObservers();
                
                VectorMath.Clear();
            }
            M = B;
            
            return;
        }
    }
}
