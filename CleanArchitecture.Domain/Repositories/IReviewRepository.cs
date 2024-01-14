using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Repositories
{
    public interface IReviewRepository : IEFRepository<Review, Review>
    {
        Task<Review?> FindByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<List<Review>> FindByIdsAsync(Guid[] ids, CancellationToken cancellationToken = default);
    }
}