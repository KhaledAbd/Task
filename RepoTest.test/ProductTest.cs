using System;
using Xunit;
using Moq;
using RepoTest.API.Data;
using RepoTest.API.Models;
using RepoTest.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using RepoTest.API.Dtos;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using RepoTest.API.Helpers;
using System.Collections.Generic;
using FluentAssertions;
namespace RepoTest.test
{
    public class ProductControllerTests
    {
        private Mock<IProductRepository> repoPRoduct = new();
        [Fact]
        public async Task GetItemAsync_withNotExistProduct_ReturnNotFound()
        {
            //Arrange
            repoPRoduct.Setup(repo => repo.GetById(It.IsAny<int>())).ReturnsAsync((ProductDtos)null);
            var controller = new ProductController(repoPRoduct.Object);

            //act
            var rnd = new Random();
            var result = await controller.GetProduct(rnd.Next(2, 10));
            //Assert
            Assert.IsType<NotFoundResult>(result.Result);
            result.Result.Should().BeOfType<NotFoundResult>();
        }        
        [Fact]
        public async Task GetItemAsync_withExistingProduct_ReturnExpectedProduct(){
            //Arrange
            var expectedValue = CreateRendomProduct();
            repoPRoduct.Setup(repo => repo.GetById(It.IsAny<int>())).ReturnsAsync(expectedValue);

            var controller = new ProductController(repoPRoduct.Object);
            var result = await controller.GetProduct(new Random().Next());

            // Assert.IsType<ProductDtos>(result.Value);
            // var dto = (result as ActionResult<ProductDtos>).Value;
            // Assert.Equal(expectedValue.Id, dto.Id);
            // Assert.Equal(expectedValue.Name, dto.Name);
            result.Value.Should().BeEquivalentTo(expectedValue, o => 
                o.ComparingByMembers<ProductDtos>()
            );
        }
        
        [Fact]
        public async Task GetItemsAsync_AllProducts_ReturnsAllProduct(){
            //Arrange
            var products = new List<ProductDtos>(){
                new ProductDtos(){Id = 1},
                new ProductDtos(){Id = 2},
                new ProductDtos(){Id = 3},
            };
            repoPRoduct.Setup(repo => repo.GetAll()).ReturnsAsync(products);
            var controller = new ProductController(repoPRoduct.Object);
            //Act
            List<ProductDtos> foundProducts = (await controller.GetProducts()).Value;
            //Assert
            // Assert.Equal(products[0].Id, foundProducts[0].Id);
            foundProducts.Should().BeEquivalentTo(products, o => o.ComparingByMembers<ProductDtos>());
        }
        [Fact]
        public async Task CreateProduct_WithProduct_ReturnsCreatedProduct(){
            //Arrange
            var productDto = new ProductDtos() {
                Id = 1,
                Name = "adsa",
                Price = 10
            };
            var controller = new ProductController(repoPRoduct.Object);
            
            //Act
            var result = await controller.CreateProduct(productDto);
            var createdItem = (result.Result as CreatedAtActionResult).Value as ProductDtos;
            //Assert
            createdItem.Should().BeEquivalentTo(productDto,
            o => o.ComparingByMembers<ProductDtos>().ExcludingMissingMembers());
            createdItem.Name.Should().NotBeEmpty();

        }
        private ProductDtos CreateRendomProduct()
        {
            return new ProductDtos()
            {
                Id = new Random().Next(),
                Name = "asdasd",
                Price = 1
            };
        }
    }
}
