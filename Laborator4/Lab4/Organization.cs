using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lab4
{
    public class Organization
    {
        public Organization()
        {
            this.AssignedUsers = new List<User>();
        }

        [Required]
        public Guid Id { get; set; }

        [Required]
        [StringLength(300)]
        public string Name { get; set; }

        public string Description { get; set; }

        public string ActivityType { get; set; }

        public virtual ICollection<User> AssignedUsers { get; set; }

    }
}