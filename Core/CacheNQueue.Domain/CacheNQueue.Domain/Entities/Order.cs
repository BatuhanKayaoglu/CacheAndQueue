using CacheNQueue.Domain.Entities.Comman;
using CacheNQueue.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheNQueue.Domain.Entities
{
    public class Order : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        public string Address { get; set; }
        public string OrderStatus { get; set; }
        public int UnitPrice { get; set; }

    }

}
