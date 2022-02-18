using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using RepoTest.API.Dtos;
using RepoTest.API.Models;
using RepoTest.API.Helpers;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace RepoTest.API.Data
{
    public interface IProductRepository
    {
        public Task Add(Product product);

        public Task Remove(Product product);

        public Task<ProductDtos> GetById(int id);

        public Task<List<ProductDtos>> GetAll();

        public Task SaveAsync();

        public Task<int> GetMaxId();
    }

    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;
        private readonly IMapper mapper;
        public ProductRepository(DataContext _context, IMapper mapper)
        {
            this.mapper = mapper;
            this._context = _context;
        }
        public async Task Add(Product product)
        {
            await _context.Products.AddAsync(product);
        }

        public async Task Remove(Product product)
        {
            _context.Products.Remove(product);
            await Task.CompletedTask;
        }
        public async Task<ProductDtos> GetById(int id) { return mapper.Map<ProductDtos>(await _context.Products.FindAsync(id));}

        public async Task<List<ProductDtos>> GetAll()
        {
            return mapper.Map<List<ProductDtos>>(await _context.Products.ToListAsync());
        }
        public async Task SaveAsync(){
            await _context.SaveChangesAsync();
        }
        public async Task<int> GetMaxId(){
            var  p = await _context.Products.OrderBy(p => p.Id).LastOrDefaultAsync();
            return p.Id;
        }


    }

    // public class FakeProductRepository : IProductRepository
    // {
    //     private readonly List<Product> Products = new(){
    //         new Product {Id = 1, Name =" Product1", Price = 9},
    //         new Product {Id = 2, Name =" Product2", Price = 10},
    //         new Product {Id = 3, Name =" Product3", Price = 11},
    //     };
    //     private readonly IMapper mapper;
    //     public FakeProductRepository(){
    //         var config = new MapperConfiguration(cfg => {
    //         cfg.AddProfile<AutoMapperProfile>();
    //         });

    //         this.mapper = config.CreateMapper();
    //     }
    //     public async Task Add(Product product)
    //     {
    //         Products.Add(product);   
    //         await Task.CompletedTask;
    //     }

    //     public async Task<ProductDtos> GetById(int id)
    //     {
    //         Products.Find(p => p.Id == id);
    //         return await Task.FromResult(mapper.Map<ProductDtos>(Products.Find(p => p.Id == id)));
    //     }

    //     public async Task Remove(Product product)
    //     {
    //         Products.Remove(product);
    //         await Task.CompletedTask;
    //     }
    // }
}