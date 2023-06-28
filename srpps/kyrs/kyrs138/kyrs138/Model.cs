using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace kyrs138
{
    public class Model
    {
        double[,] M;
        Random rand;
        public int n;
        
        public Model()
        {
            rand = new Random();
            n = 0;
        }
        public void putSizeOfMatrix(int size)
        {
            n = size;
            M = new double[n, n];
            
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
        public double[] sumOfscalar(int i, double[,] B)//сумма проекций векторов
        {
            double[] C = new double[n];
            for (int j = 0; j < i; j++)//summ=scalarproisv(mixmj)xmj
            {
                C = vectorSum(C, Multiplication(scalarPr(getRow(M, i), getRow(B, j)) / scalarPr(getRow(B, j), getRow(B, j)), getRow(B, j)));// an-сумма проекция an на bj j=1 -> n-1
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
        public double [,] OrthonormalMatrix()//вычисление с помошбю грамма-шмидта
        {
            double[] C = new double[n];
            double[,] B = new double[n, n];
            double[,] X = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                C = vectorSub(getRow(M, i), sumOfscalar(i, B));//mi-sum
                C=normalization(C);
                //dataGridView1.Rows[i] = vectorSubtraction(dataGridView1.Rows[i], sumOfscalar(scalarPr(scalarPr()) , i));
                for (int j = 0; j < n; j++)
                {
                    //dataGridView2.Rows[j].Cells[i].Value = C[j];
                    X[j, i] = C[j];
                    B[i, j] = C[j];
                }

            }
            M = B;
            return M;
        }
    }
}
