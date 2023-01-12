using System;
using System.Reflection;

namespace Reflection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var assemblies = Assembly.GetExecutingAssembly();

            Console.WriteLine("All types");
            foreach (var item in assemblies.GetTypes())
            {
                Console.WriteLine(item.Name+" - "+item.Namespace);
                foreach (var field in item.GetFields())
                {
                    Console.WriteLine("\t"+field.Name);
                }
            }
            Product product = new Product(4)
            {
                SalePrice = 10,
                Name = "Milla 1L",
                Category = "Sud mehsulu"
            };

            var type = product.GetType();
            
            Console.WriteLine("\nProperties: ");
            foreach (var item in type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic))
            {
                Console.WriteLine($"{item.Name} - {item.GetValue(product)}");
            }

            Console.WriteLine("\nFields: ");
            foreach (var item in type.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic))
            {
                if (item.Name == "_costPrice")
                {
                    item.SetValue(product, 100);
                }
                Console.WriteLine($"{item.Name} - {item.GetValue(product)}");
            
            }

            Console.WriteLine("\nMethods: ");
            foreach (var item in type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic))
            {
                Console.WriteLine(item.Name);
            }
        }
    }
}
