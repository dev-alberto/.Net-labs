using System;
using Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace BusinessTest
{
    [TestClass]
    public class ArchitectTest
    {

        [TestMethod]
        public void When_ManagerIsInstanciated_then_SalutationShouldReturnHelloAndTypeOfManager()
        {
            Architect manager = CreateSUT();

            string salutation = "Hello " + typeof(Architect);

            salutation.Should().Match(salutation);
        }


        private Architect CreateSUT()
        {
            Guid id = Guid.NewGuid();
            return new Architect(id, "Andrei", "Toma", DateTime.Now, 9000);
        }
    }
}