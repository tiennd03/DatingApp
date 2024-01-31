using System;

namespace DemoForeach
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] A = {5,7,6,4,1,5,2,9,12,5,2,1,10};

            Console.Write( "A = {");
            for (int i = 0; i < A.Length; i++)
            {
                Console.Write(A[i] + ",");
            }
            Console.WriteLine("}");


            //foreach (var i in A)
            //{
            //    Console.WriteLine(i);
            //}

            Array.Reverse(A);
            Console.WriteLine("Mang sau khi dao nguoc");
            Console.Write("A = {");
            for (int i = 0; i < A.Length; i++)
            {
                Console.Write(A[i] + ",");
            }
            Console.WriteLine("}");

            Array.Sort(A);
            Console.WriteLine("Mang sau khi sap xep");

            Console.Write("A = {");
            for (int i = 0; i < A.Length; i++)
            {
                Console.Write(A[i] + ",");
            }
            Console.WriteLine("}");
        }
    }
}
