using System;

namespace DemoNhapXuat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int a = 5;
            int b = 7;
            Console.WriteLine(a + " + " + b + " = " + (a+b));

            Console.WriteLine("a + b = " + (a+b)) ;
            Console.WriteLine("{0} + {1} = {2}",a,b,a+b);

            Console.Write("Nhap vao a: ");
            string a_txt = Console.ReadLine();
            //try
            //{
            //    a = int.Parse(a_txt);
            //    Console.WriteLine("Gia tri vua nhap vao: " + a);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("Du lieu nhap vao khong phai la so");
            //}

            int.TryParse(a_txt, out a);
            Console.WriteLine("Gia tri vua nhap vao: " + a);

            double c = 3.5;
            int d = (int)c;
        }
    }
}
