using System;
using System.Collections.Generic;

internal class Singletone
{
    private Singletone() { }

    private static List<double> list;
    public static List<double> listDoub
    {
        get
        {
            if (list == null)
                list = new List<double>();
            return list;
        }
        set { list = value; }
    }
}
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, world!");
    }
}