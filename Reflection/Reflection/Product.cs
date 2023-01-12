using System;
using System.Collections.Generic;
using System.Text;

namespace Reflection
{
    internal class Product
    {
        public Product(double costPrice)
        {
            _costPrice = costPrice;
        }
        private double _costPrice;
        public double SalePrice;
        public string Name;
        public string Category { get; set; }
    }
}
