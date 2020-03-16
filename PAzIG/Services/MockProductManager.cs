using System;
using System.Collections.Generic;
using System.Text;
using PAzIG.Model;

namespace PAzIG.Services
{
    public class MockProductManager : IProductManager
    {
        private List<Product> _products;

        public MockProductManager()
        {
            _products = new List<Product>()
                        {
                            new Product("makaron", 10.5),
                            new Product("kasza", 3.2)
                        };
        }

        public void AddProduct(Product product)
        {
            // dodanie nowego produktu do bazy danych
            _products.Add(product);
        }

        public IEnumerable<Product> GetProducts()
        {
            // pobranie produktów z bazy danych
            return _products;
        }
    }
}
