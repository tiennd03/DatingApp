using System;

namespace DemoDelegate
{
    internal class Program
    {
        public delegate int Calculator(int a, int b);
        public static int Add(int a,int b){
            return a + b;
        }
        public static int Sub(int a, int b){
            return a - b;
        }
        static void Main(string[] args)
        {
            //Add(7, 5); //cách gọi hàm bthuong

            //Cách gọi hàm thông qua delegate
            Calculator cal = new Calculator(Add);
            Console.WriteLine( "KQ cal tro vao ham Add: " +  cal(7, 5));
            cal = Sub;
            Console.WriteLine("KQ cal tro vao ham Sub: " + cal(7, 5));
        }
    }
}
