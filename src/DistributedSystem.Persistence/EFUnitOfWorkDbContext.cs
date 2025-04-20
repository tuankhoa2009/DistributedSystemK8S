using DistributedSystem.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistributedSystem.Persistence
{
    public class EFUnitOfWorkDbContext<TContext> : IUnitOfWorkDbContext<TContext>
    where TContext : DbContext
    {
        private readonly TContext _dbContext;

        public EFUnitOfWorkDbContext(TContext dbContext)
            => _dbContext = dbContext;

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
            => await _dbContext.SaveChangesAsync();

        async ValueTask IAsyncDisposable.DisposeAsync()
            => await _dbContext.DisposeAsync();
    }
}
