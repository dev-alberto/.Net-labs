using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab4;

namespace Database
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var newProduct1 = new Product {Name = "firstProduct"};
            var newProduct2 = new Product() {Name= "secondProduct"};
            var newCustomer1 = new Customer() {Name = "firstCustomer", Email = "adsw@gmail.com", Adress = "sadsaswwww", Id = Guid.NewGuid(), PhoneNumber = "0742757942"};
            var newCustomer2 = new Customer() { Name = "secondCustomer", Email = "adw@gmail.com", Adress = "sdsaswwww", Id = Guid.NewGuid(), PhoneNumber = "0742757942" };
            var newCustomer3 = new Customer() { Name = "thirdCustomer", Email = "dsw@gmail.com", Adress = "sadsasww", Id = Guid.NewGuid(), PhoneNumber = "0742757942" };

            using (var dbCtx1 = new DbEntities())
            {
                var productRepo = new ProductRepository<Product>(dbCtx1);
                var customerRepo = new CustomerRepository<Customer>(dbCtx1);

                productRepo.Add(newProduct1);
                productRepo.Add(newProduct2);

                customerRepo.Add(newCustomer1);
                customerRepo.Add(newCustomer2);
                customerRepo.Add(newCustomer3);

                var numberOfProducts = dbCtx1.Products.Count();
                var numberOfCustomers = dbCtx1.Customers.Count();
                Console.WriteLine("Number of Customers: " + numberOfCustomers);
                Console.WriteLine("Number of Products: " + numberOfProducts);
                Console.Read();               
            }
    
        }
    }
}
