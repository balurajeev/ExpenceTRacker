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

        Task AddAsync(Statements reminder, CancellationToken cancellationToken);
        Task<Statements?> GetByIdAsync(int ID, CancellationToken cancellationToken);        
        Task RemovebyIDAsync(int ID, CancellationToken cancellationToken);
        Task RemoveRangeAsync(List<int> IDs, CancellationToken cancellationToken);
        Task UpdateAsync(int ID, CancellationToken cancellationToken);
    }
}
