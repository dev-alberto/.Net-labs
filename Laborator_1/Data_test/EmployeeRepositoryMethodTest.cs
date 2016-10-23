using System.Collections.Generic;
using System.Linq;
using Data;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusinessTest
{
    [TestClass]
    public class EmployeeRepositoryMethodTest : EmployeeRepositoryTest
    {
        [TestInitialize]
        public void Instanciate()
        {
            Sut = new EmployeeRepositoyMethod(MockData.ConstructEmployeeList());
        }

    }
}