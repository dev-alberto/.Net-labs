using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab4;
using Microsoft.EntityFrameworkCore;
using Remotion.Linq.Utilities;

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
            }
            
            using (var dbCtx2 = new DbEntities())
            {
                var userRepo = new UserRepository<User>(dbCtx2);
                var organisationRepo = new OrganizationRepository<Organization>(dbCtx2);

                for (int i = 0; i < 10; ++i)
                {
                    userRepo.Add(new User() { Id = Guid.NewGuid(), FirstName = "asda", LastName = "SdSDS" });
                }

                for (int i = 0; i < 5; ++i)
                {
                    organisationRepo.Add(new Organization() { Id = Guid.NewGuid(), Name = "dasxx", Description = "trololololoool"});
                }
            }
            
           
            using (var dbCtx3 = new DbEntities())
            {
                //var userRepo = new UserRepository<User>(dbCtx3);
                //var organisationRepo = new OrganizationRepository<Organization>(dbCtx3);

                foreach (var user in dbCtx3.Users)
                {
                    Console.WriteLine(user.FirstName + " " + user.LastName);
                }

                foreach (var org in dbCtx3.Organizations)
                {
                    Console.WriteLine(org.Name + " " +  org.Description);
                }

                var lazyQuary = dbCtx3.Organizations;
                
                foreach (var item in lazyQuary)
                {
                    Console.WriteLine($"{item.Name} has {item.AssignedUsers.Count} Assigned"); 
                }
                
                var eagerQuary = dbCtx3.Organizations.Include("AssignedUsers");

                foreach (var item in eagerQuary)
                {
                    Console.WriteLine($"{item.Name} has {item.AssignedUsers.Count} Assigned");
                }

                var explicitQuary = dbCtx3.Organizations.Include("AssignedUsers");

                foreach (var item in explicitQuary)
                {
                    var users = dbCtx3.Entry(item).Collection(c => c.AssignedUsers);
                    if (!users.IsLoaded)
                    {
                        users.Load();
                    }
                    Console.WriteLine($"{item.Name} has {item.AssignedUsers.Count} Assigned");
                }
                Console.ReadLine();
            }
            
        }
    }
}
