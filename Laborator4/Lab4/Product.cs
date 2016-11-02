using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Lab4
{
    public class Product
    {
        
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public string Description { get;  set; }

        [Required]
        public DateTime StartDate { get;  set; }

        public DateTime ? EndDate { get;  set; }

        [Required]
        public double Price { get;  set; }

        [Required]
        public int Vat { get;  set; }

        public bool IsValid()
        {
         //   return EndDate.Substract(StartDate).Seconds <= 0;
            return true;
        }

        public double ComputeVat()
        {
            return Price * Vat / 100;
        }

        public void SetValability(DateTime endDate)
        {
            if (endDate < StartDate)
            {
                throw new ArgumentException("EndDate should be greater then StartDate");
            }

            EndDate = endDate;
        }
    }
}
