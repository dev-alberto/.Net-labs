using System;
using Microsoft.EntityFrameworkCore;

namespace Lab4
{
    public class Customer
    {

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Adress { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }
    }
}