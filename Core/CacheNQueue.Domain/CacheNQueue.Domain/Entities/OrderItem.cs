using CacheNQueue.Domain.Entities.Comman;
using CacheNQueue.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheNQueue.Domain.Entities
{
    public class OrderItem : BaseEntity// Sipariş durumu
    {
        public AppUser appUser { get; set; }
        public Order Order { get; set; } // İlgili sipariş
        public Product Product { get; set; } // İlgili ürün
    }

}
