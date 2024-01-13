using AutoMapper;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories;
using CleanArchitecture.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class VendorRepository : RepositoryBase<Vendor, Vendor, ApplicationDbContext>, IVendorRepository
    {
        public VendorRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }
        public async Task<Domain.Entities.Vendor> FindByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await FindAsync(x => x.Id == id, cancellationToken);
        }

    }
}
