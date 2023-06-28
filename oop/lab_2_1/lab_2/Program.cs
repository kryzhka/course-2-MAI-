using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2_1
{
    class A
    {
        private B b = new B();
        private C c = new C();
        private J j = new J();
        
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
    }
    class B
    {
        private D d = new D();
        private E e = new E();

        public void mB()
        {
            Console.WriteLine("Metod of B");
        }
        public D dB
        {
            
            get { Console.Write("get d ->"); return d; }
        }
        public E eB
        {
           
            get { Console.Write("get e ->"); return e; }
        }
    }
    class C
    {
        private F f = new F();
        private E e = new E();
        
        public C()
        {
            this.c_value = 0;
        }
        public void mC()
        {
            Console.WriteLine("Metod of C");
        }
        public F fC
        {
           
            get { Console.Write("get f ->"); return f; }
        }
        public E eC
        {
            
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
        private D d = new D();

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