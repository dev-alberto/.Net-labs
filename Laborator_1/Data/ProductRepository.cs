using System;
using System.Collections.Generic;
using System.Linq;

namespace Data
{
    public class ProductRepository
    {
        public List<Product> Products { get; private set; }

        public ProductRepository(Product product1, Product product2, Product product3)
        {
            Products = new List<Product>();
            Products.Add(product1);
            Products.Add(product2);
            Products.Add(product3);
        }
        public Product GetPoductByName(string productName)
        {
            var product = Products.Find(x => x.Name == productName);
            if (product == null)
            {
                throw new ArgumentException("Give a valid Product name");
            }
            return product;
        }

        public List<Product> FindAllProducts()
        {
            return Products;
        }

        public void AddProduct(Product product)
        {
            if (Products.Contains(product))
            {
                throw new ArgumentException("Duplicate product");
            }
            else
            {
                Products.Add(product);
            }
        }

        public Product GetProductByPosition(int index)
        {
            if (index < 0 || index > Products.Count)
            {
                throw new IndexOutOfRangeException("index out of range");
            }
            return Products.ElementAt(index);
        }

        public void RemoveProductByName(string productName)
        {
            var product = GetPoductByName(productName);
            if (product != null)
            {
                Products.Remove(product);
            }
            else
            {
                throw new ArgumentException("Product does not exist");
            }
        }
    }
}