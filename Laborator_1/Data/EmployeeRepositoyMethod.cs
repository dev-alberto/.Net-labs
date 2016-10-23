using System;
using System.Collections.Generic;
using System.Linq;

namespace Data
{
    public class EmployeeRepositoyMethod : EmployeeRepository

    {
        private List<Employee> Employees { get; set; }

        public EmployeeRepositoyMethod(List<Employee> employees)
        {

            if (employees.Count < 10)
            {
                throw new ArgumentException("Not enoght employees in the initial list.");
            }
            Employees = new List<Employee>(employees);
        }

        public IEnumerable<Employee> RetrieveArchitects()
        {
            IEnumerable< Employee > architects = Employees.FindAll(item => item.GetType() == typeof(Architect));
            return architects;
        }

        public IEnumerable<Employee> RetrieveManagers()
        {
            IEnumerable<Employee> managers = Employees.Where(item => item.GetType() == typeof(Manager));
            return managers;
        }

        public IEnumerable<Employee> RetrieveActiveEmployees()
        {
            IEnumerable<Employee> activEmployees = Employees.Where(item => item.IsActive());
            return activEmployees;
        }

        public IEnumerable<Employee> RetriveAllOrderBySalaryDescending()
        {
            IEnumerable<Employee> orderedEmployees = Employees.OrderByDescending(item => item.Salary);
            return orderedEmployees;
        }

        public IEnumerable<Employee> RetriveAllOrderBySalaryAscending()
        {
            IEnumerable<Employee> orderedEmployees = Employees.OrderBy(item => item.Salary);
            return orderedEmployees;
        }

        public IEnumerable<Employee> RetrieveAll(string name)
        {
            IEnumerable<Employee> nameEmployees = Employees.Where(item => item.GetFullName() == name);
            return nameEmployees;
        }

        public IEnumerable<Employee> RetrieveAll(DateTime startDate, DateTime endDate)
        {
            IEnumerable<Employee> emp = Employees.Where(item => DateTime.Compare(item.StartDate, startDate) <= 0 && DateTime.Compare(item.EndDate, endDate) <= 0);
            return emp;
        }
    }

}