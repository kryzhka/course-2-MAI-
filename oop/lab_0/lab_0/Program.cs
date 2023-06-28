using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_0
{
    class Complex_number
    {
        private int real_number;
        private int imagine_number;
        public Complex_number()
        {
            real_number = 0;
            imagine_number = 0;
        }
        public Complex_number(int real, int imagine)
        {
            this.real_number = real;
            this.imagine_number = imagine;
        }
        public static Complex_number operator +(Complex_number a, Complex_number b)
        {
            Complex_number c=new Complex_number(a.real_number + b.real_number, a.imagine_number + b.imagine_number);
            return (c);
        }
        public static Complex_number operator *(Complex_number a, Complex_number b)
        {
            Complex_number c = new Complex_number(a.real_number*b.real_number-a.imagine_number*b.imagine_number,a.real_number*b.imagine_number-b.real_number*a.imagine_number);
            return c;
        }
        public static Complex_number operator /(Complex_number a, Complex_number b)
        {
            Complex_number c = new Complex_number((a.real_number * b.real_number + a.imagine_number * b.imagine_number) / (b.real_number * b.real_number + b.imagine_number * b.imagine_number),
                (b.real_number*a.imagine_number-a.real_number*b.imagine_number)/ (b.real_number * b.real_number + b.imagine_number * b.imagine_number));
            return c;
        }
        public static Complex_number operator +(Complex_number a, int b)
        {
            Complex_number c = new Complex_number(a.real_number + b, a.imagine_number);
            return c;
        }
        public static Complex_number operator +(int a, Complex_number b)
        {
            Complex_number c = new Complex_number(b.real_number + a, b.imagine_number);
            return c;
        }
        public static Complex_number operator -(Complex_number a, Complex_number b)
        {
            Complex_number c = new Complex_number(a.real_number - b.real_number, a.imagine_number - b.imagine_number);
            return (c);
        }
        public void set(int a, int b )
        {
            this.real_number = a;
            this.imagine_number = b;
        }
        public string view()
        {
            if(this.imagine_number>=0)
                return $"({this.real_number}+{this.imagine_number}i)";
            else
                return $"({this.real_number}{this.imagine_number}i)";
        }
    };
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Complex_number c1 = new Complex_number();
            Complex_number c2 = new Complex_number(1,2);
            Complex_number c3 = new Complex_number(2,-3);
            Console.WriteLine($"first number is  {c1.view()}");
            Console.WriteLine($"sevond number is {c2.view()}");
            Console.WriteLine($"third number is { c3.view()}");
            c1.set(1,-7);
            Console.WriteLine($"first number is  {c1.view()}");
            Console.WriteLine($"Summ first and second is {(c1+c2).view()}");
            Console.WriteLine($"Summ third and second is {(c3 + c2).view()}");
            Console.WriteLine($"Multiplication third and second is {(c2*c3).view()}");
            Console.WriteLine($"Division third and second is {(c3/c2).view()}");


        }
    }
}

    

