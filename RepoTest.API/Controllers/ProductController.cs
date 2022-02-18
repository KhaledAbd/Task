using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RepoTest.API.Data;
using RepoTest.API.Dtos;
using RepoTest.API.Models;

namespace RepoTest.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository repo;
        public ProductController(IProductRepository repo) { 
            this.repo = repo;
        }

        [HttpGet("{id}", Name ="GetProduct")]
        public async Task<ActionResult<ProductDtos>> GetProduct(int id) { 
            var product =  await repo.GetById(id);
            if (product == null){
                return NotFound();
            }
            return product;
        }
        [HttpGet]
        public async Task<ActionResult<List<ProductDtos>>> GetProducts() {
            var products = (await repo.GetAll());
            if(products == null){
                return NotFound();
            }
            return products;
        }
        [HttpPost]
        public async Task<ActionResult<ProductDtos>> CreateProduct(Product product){
            await repo.Add(product);
            try{
                await repo.SaveAsync();
            }catch(Exception e){
                Console.Error.WriteLine(e.Message);
            }
            int id = await repo.GetMaxId();
            return CreatedAtRoute("GetProduct", new {id =  id}, product);
        }

    }
}