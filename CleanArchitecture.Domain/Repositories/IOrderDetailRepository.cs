using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Repositories
{
    public interface IOrderDetailRepository : IEFRepository<OrderDetail, OrderDetail>
    {
        Task<OrderDetail?> FindByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<List<OrderDetail>?> FindAll(CancellationToken cancellationToken = default);
        Task<List<OrderDetail>> FindByIdsAsync(Guid[] ids, CancellationToken cancellationToken = default);

    }
}