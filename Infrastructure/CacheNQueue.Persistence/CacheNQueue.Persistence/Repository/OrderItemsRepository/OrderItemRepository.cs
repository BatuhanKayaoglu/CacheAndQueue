using CacheNQueue.Domain.Entities;
using CacheNQueue.Persistence.Context;
using CacheNQueue.Persistence.Repositorty;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheNQueue.Application.Repositories.OrderItemsRepository
{
    public class OrderItemRepository : EfCoreRepositoryAsync<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(CacheNQueueDbContext context) : base(context)
        {
        }
        public async Task<List<OrderItem>> GetOrderItemsByOrderIdAsync(Guid orderId, CancellationToken cancellationToken)
        {
            return await _context.OrderItems
                                 .Where(oi => oi.Id == orderId)
                                 .Include(oi => oi.Product)
                                 .Include(oi => oi.appUser)
                                 .Include(oi => oi.Order)
                                 .ToListAsync(cancellationToken);
        }
    }
}
