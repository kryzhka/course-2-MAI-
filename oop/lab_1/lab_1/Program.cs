using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_1
{
    class A
    {
        private B b = null;
        private C c = null;
        private J j = null;
        public A(B b, C c, J j)
        {
            this.b = b;
            this.c = c;
            this.j = j;
        }
        public void mA()
        {
            Console.WriteLine("Metod of A");
        }
        public B bA
        {
            set { Console.WriteLine("set b");b=value ;}
            get { Console.Write("get b ->");return b; }
        }
        public C cA
        {
            set { Console.WriteLine("set b"); c = value; }
            get { Console.Write("get b ->"); return c; }
        }
        public J jA
        {
            set { Console.WriteLine("set b"); j = value; }
            get { Console.Write("get b ->"); return j; }
        }
    }
    class B
    {
        private D d = null;
        private E e = null;
        public B(D d, E e)
        {
            this.d = d;
            this.e = e;
        }
        public void mB()
        {
            Console.WriteLine("Metod of B");
        }
        public D dB
        {
            set { Console.WriteLine("set d"); d = value; }
            get { Console.Write("get d ->"); return d; }
        }
        public E eB
        {
            set { Console.WriteLine("set e"); e = value; }
            get { Console.Write("get e ->"); return e; }
        }
    }
    class C
    {
        private F f = null;
        private E e = null;
        public C(F f, E e)
        {
            this.f = f;
            this.e = e;
            this.c_value = 0;
        }
        public void mC()
        {
            Console.WriteLine("Metod of C");
        }
        public F fC
        {
            set { Console.WriteLine("set f"); f = value; }
            get { Console.Write("get f ->"); return f; }
        }
        public E eC
        {
            set { Console.WriteLine("set e"); e = value; }
            get { Console.Write("get e ->"); return e; }
        }
        public int c_value { set; get; }
    }
    class J
    {
        public J() { }
        public void mJ()
        {
            Console.WriteLine(" method of J");
        }
    }
    class D
    {
        public D() { }
        public void mD()
        {
            Console.WriteLine(" method of D");
        }
    }
    class E
    {
        private D d = null;
        public E(D d)
        {
            this.d = d;
        }
        public void mE()
        {
            Console.WriteLine(" Method of E");
        }

        public D dE
        {
            set { Console.WriteLine("set d"); d = value; }
            get { Console.Write("get d ->"); return d; }
        }
    }
    class F
    {
        public F() { }
        public void mF()
        {
            Console.WriteLine(" method of F");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            J j = new J();
            F f = new F();
            D d = new D();

            E e = new E(d);

            B b = new B(d, e);
            C c = new C(f, e);

            A a = new A(b, c, j);
            Console.WriteLine($"C value is {a.cA.c_value}");
            a.cA.c_value = 1;
            Console.WriteLine($"C vaue is {a.cA.c_value}");
            Console.WriteLine();
            a.mA();
            a.bA.mB();
            a.cA.mC();
            a.jA.mJ();

            a.bA.dB.mD();
            a.bA.eB.mE();

            a.cA.eC.mE();
            a.cA.fC.mF();
            Console.ReadKey();


        }
    }
}