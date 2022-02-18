using Microsoft.EntityFrameworkCore;
using RepoTest.API.Models;

namespace RepoTest.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext() {}
        public DataContext(DbContextOptions<DataContext>  options) : base (options) {}

        protected override void OnModelCreating(ModelBuilder builder){
         base.OnModelCreating(builder);               
        }
        
        public virtual DbSet<Product> Products{get; set;}

        public virtual DbSet<Item> Items {get; set;}

        public virtual DbSet<BillItem> BillItems {get; set;}

        public virtual DbSet<Bill> Bills {get; set;}
    }
}