using System;
using Data;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusinessTest
{
    [TestClass]
    public class ProductRepositoryTest
    {

        [TestMethod]
        public void When_ProductRepositoryIsInstanciated_Then_VerifyAll()
        {
            ProductRepository productRepository = CreateSUT();
            productRepository.Products.Count.Should().Be(3);
        }

        [TestMethod]
        public void When_ProductRepositoryIsInstanciatedWithValidName_Then_GetProductByNameShouldReturnProduct()
        {
            ProductRepository productRepository = CreateSUT();
            string productName = "prod1";
            productRepository.GetPoductByName(productName).Should().BeOfType(typeof(Product));
        }

        [TestMethod]
        public void When_ProductRepositoryIsInstanciatedWithInvalidName_Then_GetProductByNameShouldReturnProductShouldThrowException()
        {
            ProductRepository productRepository = CreateSUT();
            Action action = () => productRepository.GetPoductByName("Some wrong name");
            action.ShouldThrow<ArgumentException>();
        }

        [TestMethod]
        public void When_ProductRepositoryIsInstanciated_Then_FindAllProductsShouldReturnAllProducts()
        {
            ProductRepository productRepository = CreateSUT();
            productRepository.FindAllProducts().Should().BeSameAs(productRepository.Products);
        }

        [TestMethod]
        public void When_ProductRepositoryIsInstanciatedWithNewProduct_Then_AddProductShouldAddAProductToTheList()
        {
            ProductRepository productRepository = CreateSUT();
            Product product1 = new Product("Not a duplicate", "drterter", DateTime.Now, 33.1, 20);
            productRepository.AddProduct(product1);
            productRepository.Products.Should().Contain(product1);
        }

        [TestMethod]
        public void When_ProductRepositoryIsInstanciatedWithAlreadyExistingProduct_Then_AddProductShouldAddThrowException()
        {
            ProductRepository productRepository = CreateSUT();
            Product product1 = new Product("prod1", "fine", DateTime.Now, 33.1, 20);
            Action action = () => productRepository.AddProduct(product1);
            action.ShouldThrow<ArgumentException>();
        }

        [TestMethod]
        public void When_ProductRepositoryIsInstanciatedValidIndex_Then_GetProductByPositionShouldReturnProductAtIndexSpecified()
        {
            ProductRepository productRepository = CreateSUT();
            Product test = productRepository.GetProductByPosition(1);
            productRepository.Products.Should().Contain(test);
        }

        [TestMethod]
        public void When_ProductRepositoryIsInstanciatedWithInvalidIndex_Then_GetProductByPositionShouldShouldThrowException()
        {
            ProductRepository productRepository = CreateSUT();
            Action action = () => productRepository.GetProductByPosition(-1);
            action.ShouldThrow<IndexOutOfRangeException>();
        }

        [TestMethod]
        public void When_ProductRepositoryIsInstanciated_Then_RemoveProductByNameShouldRemoveProductWithSpecifiedName()
        {
            ProductRepository productRepository = CreateSUT();
            productRepository.RemoveProductByName("prod1");
            productRepository.FindAllProducts().Count.Should().Be(2);
        }

        [TestMethod]
        public void When_ProductRepositoryIsInstanciated_Then_RemoveProductByNameShouldThrowException()
        {
            ProductRepository productRepository = CreateSUT();
            Action action = () => productRepository.RemoveProductByName("BadName");
            action.ShouldThrow<ArgumentException>();
        }

        private ProductRepository CreateSUT()
        {
            Product product1 = new Product("prod1", "fine", DateTime.Now,  33.1, 20);
            Product product2 = new Product("prod2", "fisdadsane", DateTime.Now, 43.1, 20);
            Product product3 = new Product("prod3", "fisadasdsane", DateTime.Now, 53.1, 20);
            ProductRepository productRepository =new ProductRepository(product1, product2, product3);
            return productRepository;
        }


    }
}