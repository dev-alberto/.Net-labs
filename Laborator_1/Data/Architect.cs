using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data
{
    public class Architect : Employee
    {
        public Architect(Guid id, string firstName, string lastName, DateTime startDate, double salary) : base(id, firstName, lastName, startDate, salary)
        {
        }

        public override void Salutation()
        {
            Console.WriteLine("Hello " + typeof(Architect));
        }
    }
}
