using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XTRA.Application.Interface;
using XTRA.Domain.Entity;
using XTRA.Infrastructure.DBcontext;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace XTRA.Infrastructure.Repository
{
    public class StatementsRepository(AppDbContext _dbContext) : IStatementsRepository
    {
        public async Task AddAsync(List<Statements> BankTRansactions, CancellationToken cancellationToken)
        {
            await _dbContext.AddRangeAsync(BankTRansactions);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Statements>?> GetAsync(string startDate, string endDate, CancellationToken cancellationToken)
        {
            var query = _dbContext.Set<Statements>()
        .Where(entity =>Convert.ToDateTime(entity.Date) >= Convert.ToDateTime(startDate) && Convert.ToDateTime(entity.Date) < Convert.ToDateTime(endDate));

            return await query.ToListAsync<Statements>();
        }

       

       public async Task<Statements?> GetByIdAsync(int ID, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Set<Statements>().FindAsync(ID);
            return entity;
        }

        public async Task RemovebyIDAsync(int ID, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Set<Statements>().FindAsync(ID);
            if (entity != null)
            {
                // Remove the entity from the DbContext
                _dbContext.Remove(entity);
                // Save changes to the database
                await _dbContext.SaveChangesAsync();
            }
        }
        public async Task RemoveRangeAsync( string startDate, string endDate, CancellationToken cancellationToken)
        {
            var query = _dbContext.Set<Statements>()
           .Where(entity => Convert.ToDateTime(entity.Date) >= Convert.ToDateTime(startDate) && Convert.ToDateTime(entity.Date) < Convert.ToDateTime(endDate));
            // Save changes to the database
            _dbContext.RemoveRange(query);
            // Save changes to the database
            await _dbContext.SaveChangesAsync();
        }
        public async Task RemoveRangeAsync(List<int> IDs, CancellationToken cancellationToken)
        {
            foreach (var id in IDs)
            {
                var entity = await _dbContext.Set<Statements>().FindAsync(id);
                if (entity != null)
                {
                    _dbContext.Remove(entity);
                }
            }
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Statements bankstatement, CancellationToken cancellationToken)
        {
            // Attach the entity to the DbContext (if not already tracked)
            _dbContext.Attach(bankstatement);

            // Set the entity state to Modified to indicate changes
            _dbContext.Entry(bankstatement).State = EntityState.Modified;

            // Save changes to the database
            await _dbContext.SaveChangesAsync();
        }

       
    }
}
