using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace lab_8
{
    class sClass
    {
        public sClass() { }
    }
    class A<T>
    {
        public A() { }
        public void m(T t) 
        {
            Console.WriteLine(t.ToString());
        }
        public void m()
        {
            Console.WriteLine(value.ToString());

        }
        public T value { set; get; }

    }
    class B <T1,T2,T3>
    {
        public B() { }
        public void m(T2 t2)
        {
            Console.WriteLine(t2.ToString());
        }
        public void m(T3 t3)
        {
            Console.WriteLine(t3.ToString());
        }
        public void swap(ref T1 t1,ref T1 t2)
        {
            T1 temp = t1;
            t1 = t2;
            t2 = temp;
        }
        public T1 t1 { set; get; }
        public T2 t2 { set; get; }
        public T3 t3 { set; get; }

    }
    class Programm
    {
        static void Main(string[] args)
        {
            
            A<string> a_str = new A<string>();
            a_str.m("HI");
            A<int> a_int = new A<int>();
            a_int.m(6+9);
            A<sClass> a_sclass = new A<sClass>();
            a_sclass.m(new sClass());
            B <A<string>,A<sClass>,sClass> b = new B<A<string>,A<sClass>,sClass>();
            b.t3 = new sClass();
            a_str.value = "value str";
            var v=new A<string>();
            v.value = "str SWAP";
            Console.WriteLine("BEFORE SWAP");
            a_str.m();
            v.m();
            b.swap(ref a_str,ref v);
            Console.WriteLine("AFTER SWAP");
            a_str.m();
            v.m();
            
        }
    }
    
}
