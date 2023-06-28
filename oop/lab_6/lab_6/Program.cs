using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_6
{
    class A
    {
        public A() { }
        public B b { get; set; }
        public int f() { return 3; }
    }
    class B
    {
        public B() { }
        public A a { get; set; }
        public int f() { return 2; }

    }
    class A1
    {
        public A1()
        {
            n = 3;
            this.b = new B1[n];
        }
        public A1(int n)
        {
            this.n = n;
            this.b = new B1[n];
        }
        public void setB(B1 b)
        {
            if(size<n)
            {
                this.b[size]=b;
                size++;
            }
        }
        public B1 get(int index)
        {
            if(index<size)
            {
                return this.b[index];
            }
            return null;
        }
        private int n=0;
        private B1[] b = null;
        private int size = 0;
    }

    class B1
    {
        public B1() { }
        public B1(A1 a)
        {
            a.setB(this);
        }
        public int f()
        {
            return v;
        }
        private int v = 11;
        public A1 a { set; get; }

    }
    class Programm
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Association 1:1");
            B b = new B();
            A a = new A();
            b.a = a;
            a.b = b;
            Console.WriteLine($" b1.a.f() = {b.a.f()}");
            Console.WriteLine($" a1.b.f() = { a.b.f()}");

            Console.WriteLine("Association 1:N");
            A1 a1 = new A1();
            A1 a1S = new A1(7);
            B1 b1 = new B1();
            a1.setB(b1);
            b1.a = a1;
            Console.WriteLine($" b1.a.getNext().f() = { b1.a.get(0).f()}");
            Console.WriteLine($" a1.getNext().f() = { a1.get(0).f()}");
            
        }
    }
}