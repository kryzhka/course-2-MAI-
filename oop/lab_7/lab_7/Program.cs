using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_7
{
    class B
    {
        public B() { }
        public int f()
        {
            return 11;
        } 
    }
    static class C
    {
        public static int f()
        {
            return 5;
        }
    }
    class A
    {
        public A() { }
        public void m(B b) { Console.WriteLine($" class A client m() {b.f()} "); }
        public void utility() { Console.WriteLine($" class C utility f  {C.f()}"); }
    }
    class Programm
    {
        static void Main(string[] args)
        {
            B b = new B();
            A a = new A();
            a.m(b);
            a.utility();
            C.f();
        }
    }
}