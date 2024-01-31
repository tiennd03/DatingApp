using System;
using System.Collections;

namespace DemoArrayList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArrayList A = new ArrayList();
            A.Add(1);
            A.Add("2");
            A.Add(3.5);
            A.Add('c');
            A.Add(true);

            for (int i = 0; i < A.Count; i++)
            {
                Console.Write(A[i] + ",");
            }
            Console.WriteLine();

            A.Insert(2, "New");

            for (int i = 0; i < A.Count; i++)
            {
                Console.Write(A[i] + ",");
            }
            Console.WriteLine();

            A[3] = 10;
            for (int i = 0; i < A.Count; i++)
            {
                Console.Write(A[i] + ",");
            }
            Console.WriteLine();

            A.Remove('c');
            for (int i = 0; i < A.Count; i++)
            {
                Console.Write(A[i] + ",");
            }
            Console.WriteLine();

            A.RemoveAt(2);
            for (int i = 0; i < A.Count; i++)
            {
                Console.Write(A[i] + ",");
            }
            Console.WriteLine();

            ArrayList B = new ArrayList();
            B.Add(10);
            B.Add(12);
            B.Add(3);
            B.Add(7);
            B.Add(5);
            B.Add(1);

            B.Sort();

            for (int i = 0; i < B.Count; i++)
            {
                Console.Write(B[i] + ",");
            }
            Console.WriteLine();

            int rs1 = A.IndexOf(2);
            if (rs1 == -1)
            {
                Console.WriteLine("Khong tim thay phan tu trong A");
            }
            else
            {
                Console.WriteLine("Tim thay phan tu trong A tai vi tri " + rs1);
            }
        }
    }
}
