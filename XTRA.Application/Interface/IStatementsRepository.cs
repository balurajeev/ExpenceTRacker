using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XTRA.Domain.Entity;

namespace XTRA.Application.Interface
{
    public interface IStatementsRepository
    {

        Task AddAsync(List<Statements> BankTRansactions, CancellationToken cancellationToken);
        Task<List<Statements>?> GetAsync(string startDate,string endDate, CancellationToken cancellationToken);
        Task<Statements?> GetByIdAsync(int ID, CancellationToken cancellationToken);        
        Task RemovebyIDAsync(int ID, CancellationToken cancellationToken);
        Task RemoveRangeAsync(List<int> IDs, CancellationToken cancellationToken);
        Task UpdateAsync(Statements bankstatement, CancellationToken cancellationToken);
        Task RemoveRangeAsync(string startDate, string endDate, CancellationToken cancellationToken);
    }
}
