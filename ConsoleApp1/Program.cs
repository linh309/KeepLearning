using System;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static T GetDefaultValue<T>()
        {
            T value = default(T);
            return value;
        }

        static void Main(string[] args)
        {
            bool b = GetDefaultValue<bool>();
            int i = GetDefaultValue<int>();
            double d = GetDefaultValue<double>();

            Console.WriteLine("{0}, {1}, {2}", b, i, d);


            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }
}
