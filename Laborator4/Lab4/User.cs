using System;
using System.ComponentModel.DataAnnotations;

namespace Lab4
{
    public class User
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [StringLength(300)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(300)]
        public string LastName { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }
    }
}