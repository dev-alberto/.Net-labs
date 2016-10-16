using System;
using System.Globalization;
using Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace BusinessTest
{
    [TestClass]
    public class ManagerTest
    {
        [TestMethod]
        public void When_ManagerIsInstanciated_Then_VerifyAll()
        {
            Manager manager = CreateManager();
            manager.Id.Should().NotBe(Guid.Empty);
            manager.FirstName.Should().NotBeNullOrEmpty();
            manager.LastName.Should().NotBeNullOrEmpty();
            manager.StartDate.Should().BeAfter(DateTime.MinValue);
            manager.EndDate.Should().Be(DateTime.MinValue);
            manager.Salary.Should().BeGreaterThan(0);
        }

        [TestMethod]
        public void When_ManagerIsInstanciatedWithEndDateMin_then_IsActiveShouldReturnTrue()
        {
            Manager manager = CreateManager();

            var result = manager.IsActive();

            result.Should().Be(true);
        }

        [TestMethod]
        public void When_ManagerIsInstanciated_then_GetFullNameShouldReturnFullNAme()
        {
            Manager manager = CreateManager();

            string result = manager.FirstName + manager.LastName;

            result.Should().Match(result);
        }

        [TestMethod]
        public void When_ManagerIsInstanciated_then_SalutationShouldReturnHelloAndTypeOfManager()
        {
            Manager manager = CreateManager();

            string salutation = "Hello " + typeof(Manager);

            salutation.Should().Match(salutation);
        }

    private Manager CreateManager()
        {
            Guid id = Guid.NewGuid();
            return new Manager(id, "Alberto", "Cieri", DateTime.Now, 9000);
        }
    }

 
}