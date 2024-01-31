using System;
using System.Collections;

namespace DemoHashTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hashtable ht = new Hashtable();
            ht.Add("huce", "Truong ĐHXD HN");
            ht.Add("hust", "Truong ĐHBK HN");
            ht.Add("1", 6);

            foreach (string key in ht.Keys) {
                string str_val = ht[key].ToString();
                Console.Write(key + "; " + str_val + ",");
            }
            Console.WriteLine();

            //ht.Remove("huce");
            //foreach (string key in ht.Keys)
            //{
            //    Console.Write(key + "; " + ht[key] + ",");
            //}
            //Console.WriteLine();

            if(ht.ContainsKey("huce"))
            {
                Console.WriteLine("Ton tai huce trong HT");
            }
            else
            {
                Console.WriteLine("Khong ton tai huce trong HT");
            }
        }
    }
}
