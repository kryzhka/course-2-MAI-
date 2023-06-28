using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace lab_4_1
{
    public interface B
    {
        void mB();
        int fB();
    }
    public class C
    {
        public C()
        {
            this.v_1 = 12;
        }
        public int v_1 { get; set; }
        public int f()
        {
            Console.WriteLine("class C f()");
            return 2;
        }
    }

    public class E:C,B
    {
        public E() { this.v_2 = 5; this.v_3 = 10; }
        protected int v_2 { set; get; }
        public int v_3 { set; get; }


        public int fB() { return this.v_3 * (10 - this.v_1); }
        public void mB() { this.v_2 = this.v_1 * this.v_3 + 100; }
    }
   
   



    class Program
    {
        static void Main(string[] args)
        {
            E a = new E();
            Console.WriteLine("combination");
            Console.WriteLine($"a.fa() = {a.fB()}");
            Console.WriteLine($"((A)b).f() =  {((E)a).f()}");

            C c = new C();
            c.f();
            c = new E();

            Console.ReadKey();
        }
    }
}