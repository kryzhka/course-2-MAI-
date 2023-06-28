using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static lab_2_2.A;
using static lab_2_2.A.B;

namespace lab_2_2
{
    class A
    {
        public A() { }
        public class B
        {
            public B() { }
            public class D
            {
                public D() { }
                public void mD()
                {
                    Console.WriteLine("metod of D");
                }
            }
            
            public class E
            {
                public E() { }
                public void mE()
                {
                    Console.WriteLine("metod of E");
                }
            }
            public void mB()
            {
                Console.WriteLine("metod of B");
            }
            public D dB
            {
                get { Console.Write("get d ->"); return d; }
            }
            public E eB
            {
                get { Console.Write("get e ->");return e; }
            }
            D d =new D();
            E e =new E();

        }
        public class C
        {
            public C()
            {
                this.c_value = 0;
            }
            public class F
            {
                public F() { }
                public void mF()
                {
                    Console.WriteLine("metod of F");
                }

            }
            public class E
            {
                public E() { }
                public void mE()
                {
                    Console.WriteLine("metod of E");
                }
            }
            public F fC
            {
                get { Console.Write("get d ->"); return f; }
            }
            public E eC
            {
                get { Console.Write("get e ->"); return e; }
            }
            public void mC()
            {
                Console.WriteLine("Metod of C");
            }
            F f = new F();
            E e = new E();
            public int c_value{set; get;}
        }
        public class J
        {
            public J() { }
            public void mJ()
            {
                Console.WriteLine("metod of J");
            }

        }
        public void mA()
        {
            Console.WriteLine("Metod of A");
        }
        public B bA
        {

            get { Console.Write("get b ->"); return b; }
        }
        public C cA
        {

            get { Console.Write("get b ->"); return c; }
        }
        public J jA
        {

            get { Console.Write("get b ->"); return j; }
        }
        private B b = new B();
        private C c = new C();
        private J j = new J();
    }
    
    internal class Program
    {
        static void Main(string[] args)
        {

            A a = new A();

            a.mA();
            a.bA.mB();
            a.cA.mC();
            a.jA.mJ();

            a.bA.dB.mD();
            a.bA.eB.mE();

            a.cA.eC.mE();
            a.cA.fC.mF();

            Console.WriteLine($"C value is {a.cA.c_value}");
            a.cA.c_value = 1;
            Console.WriteLine($"C vaue is {a.cA.c_value}");

            Console.ReadKey();
        }
    }
}