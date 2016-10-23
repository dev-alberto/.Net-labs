using System;
using System.Collections.Generic;
using Data;

namespace BusinessTest
{
    internal static class MockData
    {
     
        public static List<Employee> ConstructEmployeeList()
        {
            var employees = new List<Employee> {

            new Manager(Guid.NewGuid(), "Octav", "la", new DateTime(1992, 8, 18), 23211.11),
            new Manager(Guid.NewGuid(), "a", "la", new DateTime(1992, 8, 12), 23215.11),
            new Architect(Guid.NewGuid(), "Octav", "Verde", new DateTime(2012, 03, 11), 2001),
            new Manager(Guid.NewGuid(), "ad", "la", new DateTime(1992, 8, 20), 23213.11),
            new Manager(Guid.NewGuid(), "ae", "la", new DateTime(1992, 8, 21), 23214.11),
            new Architect(Guid.NewGuid(), "Octav", "Verde", new DateTime(2012, 02, 11), 2000),
            new Architect(Guid.NewGuid(), "fc", "dass", new DateTime(2012, 05, 11), 2003),
            new Manager(Guid.NewGuid(), "ab", "la", new DateTime(1992, 8, 19), 23212.11),
            new Architect(Guid.NewGuid(), "fb", "das", new DateTime(2012, 04, 11), 2002),
            new Architect(Guid.NewGuid(), "f", "das", new DateTime(2012, 06, 11), 2004)
        };

            return employees;
        }

        public static IEnumerable<Employee> ArchitectList()
        {
            var architects = new List<Employee>
            {
                new Architect(Guid.NewGuid(), "Octav", "Verde", new DateTime(2012, 02, 11), 2000),
                new Architect(Guid.NewGuid(), "Octav", "Verde", new DateTime(2012, 03, 11), 2001),
                new Architect(Guid.NewGuid(), "fb", "das", new DateTime(2012, 04, 11), 2002),
                new Architect(Guid.NewGuid(), "fc", "dass", new DateTime(2012, 05, 11), 2003),
                new Architect(Guid.NewGuid(), "f", "das", new DateTime(2012, 06, 11), 2004)
            };

            return architects;
        }

        public static IEnumerable<Employee> ManagersList()
        {
            var managers = new List<Employee>
            {
                 new Manager(Guid.NewGuid(), "Octav", "la", new DateTime(1992, 8, 18), 23211.11),
                 new Manager(Guid.NewGuid(), "ab", "la", new DateTime(1992, 8, 19), 23212.11),
                 new Manager(Guid.NewGuid(), "ad", "la", new DateTime(1992, 8, 20), 23213.11),
                 new Manager(Guid.NewGuid(), "ae", "la", new DateTime(1992, 8, 21), 23214.11),
                 new Manager(Guid.NewGuid(), "a", "la", new DateTime(1992, 8, 12), 23215.11)
            };

            return managers;
        }

       

        public static IEnumerable<Employee> EmployeesWhoAreNamedOctavVerde()
        {
            var octavVerde = new List<Employee>
            {
                new Architect(Guid.NewGuid(), "Octav", "Verde", new DateTime(2012, 02, 11), 2000),
                new Architect(Guid.NewGuid(), "Octav", "Verde", new DateTime(2012, 03, 11), 2001),
            };

            return octavVerde;
        }

        public static IEnumerable<Employee> EmployeesWhoAreAreBetweenDates_1992_8_21_and_DateTimeMin()
        {
            var betweenDates = new List<Employee>
            {
                new Manager(Guid.NewGuid(), "Octav", "la", new DateTime(1992, 8, 18), 23211.11),
                new Manager(Guid.NewGuid(), "a", "la", new DateTime(1992, 8, 12), 23215.11),
                new Manager(Guid.NewGuid(), "ad", "la", new DateTime(1992, 8, 20), 23213.11),
                new Manager(Guid.NewGuid(), "ae", "la", new DateTime(1992, 8, 21), 23214.11),
                new Manager(Guid.NewGuid(), "ab", "la", new DateTime(1992, 8, 19), 23212.11),
        };

            return betweenDates;
        }
    }
}
