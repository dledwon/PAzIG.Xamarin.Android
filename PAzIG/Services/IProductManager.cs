using PAzIG.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PAzIG.Services
{
    public interface IProductManager
    {
        IEnumerable<Product> GetProducts();
        void AddProduct(Product product);
    }
}
