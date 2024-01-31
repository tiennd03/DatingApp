using System;

namespace DemoMang2ChieuZicZac
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] B = new int[3][];
            B[0] = new int[] { 1, 4, 5, 7, 8, 5, 9 };
            B[1] = new int[] { 1, 4, 5, 7, 8 };
            B[2] = new int[] { 1, 4, 5, 7, 8, 7, 2, 3, 4, 6, 7, 6, 5, 6, 3 };

            Console.WriteLine("B = {");
            for (int i = 0; i < B.GetLength(0); i++)
            {
                Console.Write("\t{");
                for (int j = 0; j < B[i].GetLength(0); j++)
                {
                    Console.Write(B[i][j]);
                    if (j < B[i].GetLength(0) - 1)
                    {
                        Console.Write(",");
                    }
                }
                Console.Write("}");
                if (i < B.GetLength(0) - 1)
                {
                    Console.Write(",");
                }
                Console.WriteLine();
            }
            Console.WriteLine("}");
        }
    }
}
