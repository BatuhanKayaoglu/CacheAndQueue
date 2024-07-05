using CacheNQueue.Application.Repositories;
using CacheNQueue.Domain.Entities.Comman;
using CacheNQueue.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CacheNQueue.Persistence.Repositorty
{
    public class EfCoreRepositoryAsync<T> : IRepositoryAsync<T> where T : BaseEntity
    {
        protected readonly CacheNQueueDbContext _context;

        public EfCoreRepositoryAsync(CacheNQueueDbContext context)
        {
            _context = context;
        }

        public async Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Set<T>().FindAsync(id, cancellationToken);
        }

        public async Task<List<T>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task AddAsync(T entity, CancellationToken cancellationToken)
        {
            await _context.Set<T>().AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync();
        }

        public async Task AddRangeAsync(List<T> entities, CancellationToken cancellationToken)
        {
            await _context.Set<T>().AddRangeAsync(entities, cancellationToken);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity, CancellationToken cancellationToken)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }

        public async Task RemoveAsync(T entity, CancellationToken cancellationToken)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }
    }
}
