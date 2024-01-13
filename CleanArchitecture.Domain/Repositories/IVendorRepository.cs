using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Repositories
{
    public interface IVendorRepository : IEFRepository<Vendor, Vendor>
    {
        public Task<Vendor?> FindByIdAsync(Guid id, CancellationToken cancellationToken = default);

        public Task<List<Vendor>> FindAllAsync(CancellationToken cancellationToken = default);
    }
}
