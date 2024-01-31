using System;
using System.Collections.Generic;

namespace DemoDictionary
{
    internal class Program
    {
        static void Print(Dictionary<int, string> dic)
        {
            foreach (var k in dic.Keys)
            {
                Console.Write("[" + k + ";" + dic[k] + "], " );
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            Dictionary<int, string> dic = new Dictionary<int, string>();
            dic.Add(1, "value 1");
            dic.Add(2, "value 2");
            dic.Add(3, "value 3");

            Print(dic);

            dic.Remove(2); Print(dic);
            dic.Remove(1); Print(dic);

            if (dic.ContainsKey(1))
            {
                Console.WriteLine("Ton tai key trong Dictionary");
            }
            else
            {
                Console.WriteLine("Khong ton tai key trong Dictionary");
            }
        }
    }
}
