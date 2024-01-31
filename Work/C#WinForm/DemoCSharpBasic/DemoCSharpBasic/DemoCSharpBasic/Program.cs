using System;

namespace DemoCSharpBasic
{
    internal class Program
    {
        /// <summary>
        /// (Mô tả về hàm) Hàm đổi chỗ dạng tham trị
        /// </summary>
        /// <param name="a">biến 1 truyền vào dạng tham trị</param>
        /// <param name="b">biến 2 truyền vào dạng tham trị</param>
        static void DoiCho(int a, int b)
        {
            int tg = a;
            a = b;
            b=tg;
        }

        /// <summary>
        /// Hàm đổi chỗ dạng tham chiếu
        /// </summary>
        /// <param name="a">biến 1 truyền vào dạng tham chiếu</param>
        /// <param name="b">biến 2 truyền vào dạng tham chiếu</param>
        static void DoiCho(ref int a, ref int b)
        {
            int tg = a;
            a = b;
            b = tg;
        }

        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            int a = 5;
            int b = 7;

            //Truyền biến dạng tham trị
            DoiCho(a, b);

            //Truyền biến dạng tham chiếu
            DoiCho(ref a, ref b);

            DoiCho()

            Console.WriteLine();
        }
    }
}
