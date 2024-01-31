using System;

namespace DemoMang2ChieuHcn
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] a =
            {
                {1,2,3,4 },
                {5,6,7,8 },
                {9,10,11,12}
            };

            Console.WriteLine(" A = {");
            for (int i = 0; i < a.GetLength(0); i++)
            {
                Console.Write("\t {");
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write(a[i,j]);
                    if (j < a.GetLength(1) - 1)
                    {
                        Console.Write(",");
                    }    
                }
                Console.Write("}");
                if (i < a.GetLength(0) - 1)
                {
                    Console.Write(",");
                }
                Console.WriteLine();
            }
            Console.WriteLine("}");
        }
    }
}
