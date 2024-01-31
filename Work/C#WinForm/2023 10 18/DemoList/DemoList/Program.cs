using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace DemoList
{
    internal class Program
    {
        static void Print(List<int> lst)
        {
            for (int i = 0; i < lst.Count; i++)
            {
                Console.Write(lst[i] + ",");
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            List<int> lst = new List<int>();

            lst.Add(1);
            lst.Add(2);
            lst.Add(3);
            lst.Add(4);            

            lst.Insert(1, 10); Print(lst);
            lst.Sort(); Print(lst);
            lst.Remove(1); Print(lst);
            lst.RemoveAt(3); Print(lst);
            lst.Clear(); Print(lst);
        }
    }
}
