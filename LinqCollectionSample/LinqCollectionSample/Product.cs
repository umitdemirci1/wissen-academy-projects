using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqCollectionSample
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public decimal Price { get; set; }

        public IList<Product> GetAllProducts()
        {
            IList<Product> products = new List<Product>()
            {
                new Product { ProductID = 1, ProductName = "Süt", CategoryName = "Gıda" , Price = 30 },
                new Product { ProductID = 2, ProductName = "Elma", CategoryName = "Meyve" , Price = 80 },
                new Product { ProductID = 3, ProductName = "Karpuz", CategoryName = "Meyve" , Price = 45 },
                new Product { ProductID = 4, ProductName = "Kiraz", CategoryName = "Meyve" , Price = 75 },

            };
            return products;
        }
    }
}