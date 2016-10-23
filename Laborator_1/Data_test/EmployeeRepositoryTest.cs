using System;
using System.Collections.Generic;
using Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace BusinessTest
{
    public class EmployeeRepositoryTest
    {
        protected EmployeeRepository Sut;

        [TestMethod]
        public void When_EmployeeRepositoryImplementationIsInstanciated_Then_RetrieveArchitectsShouldReturnfArchitects()
        {
            var employeeRepository = Sut;
            employeeRepository.RetrieveArchitects()
                .Should()
                .BeEquivalentTo(MockData.ArchitectList()); //BeEquivalentTo compares using equals method, order is not important
        }

        [TestMethod]
        public void When_EmployeeRepositoryImplementationIsInstanciated_Then_RetrieveArchitectsShouldReturnAListOfManagers()
        {
            var employeeRepository = Sut;
            employeeRepository.RetrieveManagers()
                .Should()
                .BeEquivalentTo(MockData.ManagersList());
        }

        [TestMethod]
        public void When_EmployeeRepositoryImplementationIsInstanciated_Then_RetrieveActiveEmployeesShouldReturnAllActiveEmployees()
        {
            var employeeRepository = Sut;
            employeeRepository.RetrieveActiveEmployees()
                .Should()
                .BeEquivalentTo(MockData.ConstructEmployeeList()); //No employee has a set end date, so we should get all employees in this test
        }

        [TestMethod]
        public void
        When_EmployeeRepositoryImplementationIsInstanciated_Then_RetriveAllOrderBySalaryDescendingShouldReturnAListOfEmployeesWithSalariesInDescendingOrder()
        {
            var employeeRepository = Sut;
            employeeRepository.RetriveAllOrderBySalaryDescending()
                .Should()
                .BeInDescendingOrder(x => x.Salary);
        }

        [TestMethod]
        public void
        When_EmployeeRepositoryImplementationIsInstanciated_Then_RetriveAllOrderBySalaryAscendingShouldReturnAListOfEmployeesWithSalariesInAscendingOrder()
        {
            var employeeRepository = Sut;
            employeeRepository.RetriveAllOrderBySalaryAscending()
                .Should()
                .BeInAscendingOrder(x => x.Salary);
        }

        [TestMethod]
        public void When_EmployeeRepositoryImplematationIsInstanciated_Then_RetriveAllShouldReturnAListOfEmployeesWithThatSpecifiedName()
        {
            var employeeRepositoryQueryTest = Sut;
            const string name = "OctavVerde";
            employeeRepositoryQueryTest.RetrieveAll(name)
                .Should()
                .BeEquivalentTo(MockData.EmployeesWhoAreNamedOctavVerde());
        }

        [TestMethod]
        public void When_EmployeeRepositoryImplementationIsInstanciated_Then_RetriveAllShouldReturnAListOfEmployeesWithDatesBetweenThoseGiven()
        {
            var employeeRepositoryQueryTest = Sut;
            var start = new DateTime(1992, 8, 21);
            var end = DateTime.MinValue;
            employeeRepositoryQueryTest.RetrieveAll(start, end)
                .Should()
                .BeEquivalentTo(MockData.EmployeesWhoAreAreBetweenDates_1992_8_21_and_DateTimeMin());
        }
    }
}
