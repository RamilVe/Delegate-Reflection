using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    internal class Store
    {
        public List<Product> Products = new List<Product>();

        public List<Product> GetExpiredProducts() 
        { 
            List<Product> expiredProducts = new List<Product>();
            foreach (var item in Products)
            {
                if(item.ExpireDate.Date < DateTime.Now.Date)
                    expiredProducts.Add(item);
            }

            return expiredProducts;
        }
        public List<Product> GetExpiredProducts1Year()
        {
            List<Product> expiredProducts = new List<Product>();
            foreach (var item in Products)
            {
                if (item.ExpireDate.Date > DateTime.Now.AddYears(1).Date)
                    expiredProducts.Add(item);
            }

            return expiredProducts;
        }
        public List<Product> GetExpiredProductsIn1Month()
        {
            List<Product> expiredProducts = new List<Product>();
            foreach (var item in Products)
            {
                if (item.ExpireDate.Date > DateTime.Now.Date && item.ExpireDate.Date<DateTime.Now.AddMonths(1).Date)
                    expiredProducts.Add(item);
            }

            return expiredProducts;
        }

        public List<Product> GetExpiredProductsAfter100Days()
        {
            List<Product> expiredProducts = new List<Product>();
            foreach (var item in Products)
            {
                if ((item.ExpireDate.Date - DateTime.Now.Date).TotalDays>=100)
                    expiredProducts.Add(item);
            }

            return expiredProducts;
        }

        public List<Product> GetAll(Predicate<Product> predicate)
        {
            List<Product> wantedProduct = new List<Product>();
            foreach (var item in Products)
            {
                if (predicate(item))
                    wantedProduct.Add(item);
            }

            return wantedProduct;
        }
    }
}
