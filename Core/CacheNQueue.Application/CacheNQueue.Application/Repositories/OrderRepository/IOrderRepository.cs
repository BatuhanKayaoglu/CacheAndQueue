using CacheNQueue.Domain.Entities;
using CacheNQueue.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheNQueue.Application.Repositories.OrderRepository
{
    public interface IOrderRepository : IRepositoryAsync<Order>
    {
        Task<List<Order>> GetOrdersByUserIdAsync(Guid userId);
        Task<AppUser> GetUserAsync(Guid userId);
    }
}
