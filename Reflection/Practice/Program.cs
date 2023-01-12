using System;
using System.Reflection;

namespace Practice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var assemblies = Assembly.GetExecutingAssembly();

            foreach (var item in assemblies.GetTypes())
            {
                Console.WriteLine(item.Name + " - "+item.Namespace);
                foreach (var field in item.GetFields())
                {
                    Console.WriteLine(field.Name);
                }
                foreach (var method in item.GetMethods())
                {
                    Console.WriteLine(method.Name);
                }
            }
            Student student = new Student()
            {
                Name = "Abbas",
                Surname = "Abbasov"
            };
            
            
            var type = student.GetType();

            Console.WriteLine("\nProperties");
            foreach (var item in type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic))
            {
                Console.WriteLine($"{item.Name} - {item.GetValue(student)}");
            }

            Console.WriteLine("\nFields");
            foreach (var item in type.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic))
            {
                if (item.Name == "_no")
                {
                    item.SetValue(student, 3);
                }
                Console.WriteLine($"{item.Name} - {item.GetValue(student)}");
            }

            Console.WriteLine("\nMethods");
            foreach (var item in type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic))
            {
                Console.WriteLine($"{item.Name}");
            }
        }
    }
}
