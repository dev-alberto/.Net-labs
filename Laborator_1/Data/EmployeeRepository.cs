using System;
using System.Collections.Generic;

namespace Data
{
    public interface EmployeeRepository
    {
         IEnumerable<Employee> RetrieveArchitects();
         IEnumerable<Employee> RetrieveManagers();
         IEnumerable<Employee> RetrieveActiveEmployees();
         IEnumerable<Employee> RetriveAllOrderBySalaryDescending();
         IEnumerable<Employee> RetriveAllOrderBySalaryAscending();
         IEnumerable<Employee> RetrieveAll(string name);
         IEnumerable<Employee> RetrieveAll(DateTime startDate, DateTime endDate);
    }
}