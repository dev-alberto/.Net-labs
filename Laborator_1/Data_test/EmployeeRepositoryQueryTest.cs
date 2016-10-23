using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using Data;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusinessTest
{
    [TestClass]
    public class EmployeeRepositoryQueryTest : EmployeeRepositoryTest
    {
        [TestInitialize]
        public void Instanciate()
        {
            Sut = new EmployeeRepositoryQuery(MockData.ConstructEmployeeList());
        }

    }
}