using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheNQueue.Application.Abstractions
{
    public class TokenResponse
    {
        public string AccessToken { get; set; }
        public DateTime Expiration { get; set; }
    }
}
