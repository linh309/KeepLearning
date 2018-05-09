using System;
using System.Text;

namespace ConsoleApp1
{
    public class People
    {
        public string FullName { get; set; }
        public double Age { get; set; }
    }
    public class Student : People
    {
        public string Name { get; set; }
        public int Id { get; set; }
    }

    class Program
    {
        static T GetDefaultValue<T>()
        {
            T value = default(T);
            return value;
        }

        static void Main(string[] args)
        {
            //Student st = new Student();

            var x = typeof(Student);
            var props = x.GetProperties();

            foreach (var property in props)
            {
                Console.WriteLine("{0}, {1}", property.Name, property.PropertyType);
            }

            

            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }
}
