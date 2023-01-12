using System;
using System.Collections.Generic;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Store maqsudDayininMarketi = new Store();
            maqsudDayininMarketi.Products.Add(new Product
            {
                Name = "Milla 1L",
                Price = 2,
                CreatedDate = new DateTime(2020, 10, 20),
                ExpireDate = new DateTime(2023, 10, 20)
            });
            maqsudDayininMarketi.Products.Add(new Product
            {
                Name = "Milla 2L",
                Price = 4,
                CreatedDate = new DateTime(2021, 10, 20),
                ExpireDate = new DateTime(2021, 10, 25)
            });
            maqsudDayininMarketi.Products.Add(new Product
            {
                Name = "Milla 3L",
                Price = 6,
                CreatedDate = new DateTime(2022, 10, 20),
                ExpireDate = new DateTime(2022, 10, 20)
            });
            maqsudDayininMarketi.Products.Add(new Product
            {
                Name = "Milla 4L",
                Price = 2,
                CreatedDate = new DateTime(2022, 10, 20),
                ExpireDate = new DateTime(2024, 10, 20)
            });
            maqsudDayininMarketi.Products.Add(new Product
            {
                Name = "Milla 5L",
                Price = 20,
                CreatedDate = new DateTime(2020, 10, 20),
                ExpireDate = new DateTime(2023, 01, 12)
            });

            //for (int i = 0; i < 3; i++)
            //{
            //    var product = CreateProduct();
            //    maqsudDayininMarketi.Products.Add(product);
            //}

            Console.WriteLine("Istifade muddeti bitmis mehsullar:");
            foreach (var item in maqsudDayininMarketi.GetAll(x => x.ExpireDate.Date < DateTime.Now.Date))
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Istifade muddeti 1 il bitmis mehsullar:");
            foreach (var item in maqsudDayininMarketi.GetAll(x => x.ExpireDate.Date >= DateTime.Now.AddYears(1).Date))
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("100 gun qalmis:");
            foreach (var item in maqsudDayininMarketi.GetAll(x => (x.ExpireDate.Date - DateTime.Now.Date).TotalDays >= 100))
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Qiymeti 10-dan kicik olanlar:");
            foreach (var item in maqsudDayininMarketi.GetAll(x => x.Price < 10))
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Qiymeti 10-dan kicik olanlar:");
            foreach (var item in maqsudDayininMarketi.Products.FindAll(x => x.Price < 10))
            {
                Console.WriteLine(item);
            }

            List<int> numbers= new List<int>() { 34, 2, 24, 4, 6, 7, 8, 9 };

            Console.WriteLine(numbers.Exists(x => x>200));

            foreach (var item in numbers.FindAll(x => x > 20))
            {
                Console.WriteLine(item);
            }
        }

        static Product CreateProduct()
        {
            Console.WriteLine("Ad:");
            string name = Console.ReadLine();
            Console.WriteLine("Qiymet:");
            string priceStr = Console.ReadLine();
            decimal price = decimal.Parse(priceStr);

            Console.WriteLine("Istehsal tarixi");
            string createdDateStr = Console.ReadLine();
            DateTime createdDate = DateTime.Parse(createdDateStr);

            Console.WriteLine("Bitme tarixi");
            string expireDateStr = Console.ReadLine();
            DateTime expireDate = DateTime.Parse(expireDateStr);

            Product product = new Product
            {
                Name = name,
                Price = price,
                ExpireDate = expireDate,
                CreatedDate = createdDate,
            };

            return product;
        }
    }
}
