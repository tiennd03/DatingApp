using System;
using System.Runtime.CompilerServices;

namespace DemoEvent
{
    public delegate void MyEventHandle(string str);

    public class MyButton
    {
        public event MyEventHandle Click;

        public static void Process(string str)
        {
            Console.WriteLine(str);
        }

        public void FireEvent(string str)
        {
            Click(str);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            MyButton btn = new MyButton();
            btn.Click += new MyEventHandle(MyButton.Process);

            btn.FireEvent("Da phat sinh su kien");
        }
    }
}
