using System;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RepoTest.API.Controllers;
using RepoTest.API.Data;
using RepoTest.API.Dtos;
using Xunit;

namespace RepoTest.test
{
    public class BillControllerTest
    {
        private Mock<IBillRepository> repoBill = new();
        
        public BillControllerTest(){
            
        }
        [Fact]
        public async Task GetBillAsync_withNotExistProduct_ReturnNotFound()
        {
            //Arrange
            repoBill.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((BillReturnDtos)null);
            var controller = new BillController(repoBill.Object, );

            //act
            var rnd = new Random();
            var result = await controller.GetBillById(rnd.Next(2, 10));
            //Assert
            Assert.IsType<NotFoundResult>(result.Result);
            result.Result.Should().BeOfType<NotFoundResult>();
        }        




   }
   
}