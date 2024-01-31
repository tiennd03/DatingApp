using System;

namespace DemoLenhNhay
{
    internal class Program
    {
        static void print(int x)
        {
            for (int i = 0; i < x; i++)
            {
                if (i == 4) { return; }
                Console.WriteLine(i);
            }
        }

        static int Add(int a, int b)
        {
            int c = a + b;
            return c;
        }

        static void Main(string[] args)
        {
            //break
            for (int i = 0; i < 10; i++)
            {
                if (i == 4) { break; }
                Console.WriteLine(i);
            }

            //continue
            for (int i = 0; i < 10; i++)
            {
                if (i == 4) { continue; }
                Console.WriteLine(i);
            }

            //call function return
            print(10);

            int x = Add(5, 7);
            Console.WriteLine("Tong 2 so: " + x);
            Console.WriteLine("Tong 2 so: " + x);
            Console.WriteLine("Tong 2 so: " + x);
            Console.WriteLine("Tong 2 so: " + x);
            Console.WriteLine("Tong 2 so: " + x);
            Console.WriteLine("Tong 2 so: " + x);
            Console.WriteLine("Tong 2 so: " + x);
            Console.WriteLine("Tong 2 so: " + x);
            Console.WriteLine("Tong 2 so: " + x);

            Console.WriteLine("Tong 2 so: " + Add(5,7));
            Console.WriteLine("Tong 2 so: " + Add(5,7));
            Console.WriteLine("Tong 2 so: " + Add(5,7));
            Console.WriteLine("Tong 2 so: " + Add(5,7));
            Console.WriteLine("Tong 2 so: " + Add(5,7));

        }
    }
}
