using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace lab_4_1
{
    public interface A
    {
        void mA();
        int fA();
    }
    //расширение
    public class B : A
    {
        public B()
        {
            this.v_1 = 1;
            this.v_2 = 2;
        }
        protected int v_1 { set; get; }
        public int v_2 { set; get; }
        public virtual int f()
        {
            Console.WriteLine("class B f() ");
            return 0;
        }
        public void mA()
        {
            this.v_1 += 1;
        }
        public int fA()
        {
            return v_2 + 2;
        }
    }
    public class J : A
    {
        public J()
        {
            this.v_1 = 1;
        }
        protected int v_1 { set; get; }
        public virtual int f()
        {
            Console.WriteLine("class B f() ");
            return 0;
        }
        public void mA()
        {
            this.v_1 += 1;
        }
        public int fA()
        {
            return v_1 + 2;
        }
    }
    //специализация
    public class D : B
    {
        public D()
        {
            this.v_3 = 3;
        }
        public int v_3 {set; get;}
        public override int f()
        {
            Console.WriteLine("Class D f()");
            return base.f()+7;
        }
        public int fD()
        {
            return this.v_1 + this.v_3;
        }

    }

    
    //спецификация
    public abstract class C :A
    {
        public void mC(int a)
        {
            this.v_1 = a;
        }
        private int v_1 = 11;
        public abstract int fC();
        public void mA() { this.v_1 += this.v_1 * 2; }
        public int fA() { return this.v_1; }

    }
    
    public class F:C
    {
        public F() { }
        public override int fC()
        {
            Console.WriteLine("fC()");
            return 0;
        }
       
    }

    public class E :C
    {
        public E() { }
        public override int fC()
        {
            Console.WriteLine("fC(");
            return 5 + this.fA();
        }
    }
    
   

    class Program
    {
        static void Main(string[] args)
        {
            A a = new B();
            B b = new B();
            Console.WriteLine("Extension");
            Console.WriteLine($"class B b.f() {b.f()}");
            Console.WriteLine($"class B v_2 {b.v_2}");
            a.mA();
            Console.WriteLine($"interface A fA() {a.fA()}");

            a = new J();
            a=b;
            Console.WriteLine($"class J b.f() {b.f()}");
            Console.WriteLine($"class J v_2 {b.v_2}");
            a.mA();
            Console.WriteLine($"interface A fA() {a.fA()}");



            Console.WriteLine("Specialization");
            b =new D();
            a = b;
            Console.WriteLine($"class D b.f() {b.f()}");
            Console.WriteLine($"class D v_2 {b.v_2}");
            Console.WriteLine($"class D v_3 {((D)b).v_3}");
            Console.WriteLine($"class D fD() {((D)b).fD()}");


            Console.WriteLine("Specification");
            C c = null;
            c = new E();
            Console.WriteLine("class C c.fC() {0}", c.fC());

            c = new F();
            Console.WriteLine("class C c.fC() {0}", c.fC());
        }
    }
}