using System;

namespace Data
{
    public abstract class Employee
    {
        public Employee(Guid id, string firstName, string lastName, DateTime startDate, double salary)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            StartDate = startDate;
            Salary = salary;
            EndDate = DateTime.MinValue;
        }

        public Guid Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public double Salary { get; private set; }

        public string GetFullName()
        {
            return this.FirstName + this.LastName;
        }

        public bool IsActive()
        {
            return EndDate == DateTime.MinValue;
        }

        public void SetEndDate(DateTime endDate)
        {
            if (endDate < StartDate)
            {
                throw new ArgumentException("EndDate should be greater then StartDate");
            }

            this.EndDate = endDate;
        }
        public abstract void Salutation();

        //Guid.newGuid() introduces some errors when compering wtth our mock data, because of the probabilistic effect
        public override bool Equals(object obj)
        {
            var item = obj as Employee;
            return (FirstName == item.FirstName && LastName == item.LastName && item.Salary == Salary);
        }
    }
}
