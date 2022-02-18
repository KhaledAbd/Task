/*
    Repostitory Class For Bill Impelement CRUD Pattern
*/

using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RepoTest.API.Dtos;
using RepoTest.API.Models;

namespace RepoTest.API.Data
{
    public interface IBillRepository
    {
        public Task AddAsync(Bill billDtos);

        public Task<Bill> GetByIdAsync(int id);

        public Task<Bill> UpdateAsync(int id, Bill BillFormDtos);

        public Task RemoveAsync(int id);
    }

    public class BillRepository : IBillRepository
    {
        private readonly DataContext _context;

        public BillRepository(DataContext context){
            this._context = context;
        }
        public async Task AddAsync(Bill bill)
        {   
            bill.CreatedAt = new System.DateTime();
            await _context.Bills.AddAsync(bill);
            await _context.SaveChangesAsync(); 
        }


        public async Task<Bill> GetByIdAsync(int id)
        {
            return  await _context.Bills.Include(p => p.BillItems).ThenInclude(p => p.ItemNavigation).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Bill> UpdateAsync(int id, Bill newBill)
        {
            var bill = await _context.Bills.FindAsync(id);
            bill = newBill;
            await _context.SaveChangesAsync();
            return bill;
        }
        public async Task RemoveAsync(int id)
        {
            var bill = await _context.Bills.FindAsync(id);
            _context.Remove(bill);
            await _context.SaveChangesAsync();
        }
    }
}