using System;
using System.Collections.Generic;
using System.Linq;


namespace Data
{
    public class EmployeeRepositoryQuery : EmployeeRepository
    {
        private List<Employee> Employees { get; set; }

        public EmployeeRepositoryQuery(List<Employee> employees)
        {
            
            if (employees.Count < 10)
            {
                throw new ArgumentException("Not enoght employees in the initial list.");
            }
            Employees = new List<Employee>(employees);
        }


        public IEnumerable<Employee> RetrieveArchitects()
        {
            /*
            List<Architect> architects = Employees.Where(item => item.Equals(typeof(Architect))).Cast<Architect>().ToList();
            return architects;
            */
            IEnumerable<Employee> architects = from item in Employees where item.GetType() == typeof(Architect) select item;
            return  architects;
        }

        public IEnumerable<Employee> RetrieveManagers()
        {
            /*
            List<Manager> managers = Employees.Where(item => item.Equals(typeof(Manager))).Cast<Manager>().ToList();
            return managers;
            */
            IEnumerable<Employee> managers = from item in Employees where item.GetType() == typeof(Manager) select item;
            return managers;
        }

        public IEnumerable<Employee> RetrieveActiveEmployees()
        {
            IEnumerable<Employee> actEmployees = from item in Employees where item.IsActive() select item;
            return actEmployees;
        }

        public IEnumerable<Employee> RetriveAllOrderBySalaryDescending()
        {
            IEnumerable<Employee> orderedDesBySalary = from item in Employees
                where true
                orderby item.Salary descending 
                select item
            ;
            return orderedDesBySalary;
        }

        public IEnumerable<Employee> RetriveAllOrderBySalaryAscending()
        {
            IEnumerable<Employee> orderedAscBySalary = from item in Employees
                                                       where true
                                                       orderby item.Salary ascending 
                                                       select item
            ;
            return orderedAscBySalary;
        }

        public IEnumerable<Employee> RetrieveAll(string name)
        {
            IEnumerable<Employee> sortByName = from item in Employees
                where item.GetFullName() == name
                select item;
            return sortByName;
        }

        public IEnumerable<Employee> RetrieveAll(DateTime startDate, DateTime endDate)
        {
            IEnumerable<Employee> employeesBetweenDates = from item in Employees
                                                          where DateTime.Compare(item.StartDate, startDate) <= 0 &&
                                                                DateTime.Compare(item.EndDate, endDate) <= 0
                                                          select item;
            return employeesBetweenDates;
        }

    }

}
