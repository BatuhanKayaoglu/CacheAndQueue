using CacheNQueue.Application.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheNQueue.Application.Med.AppUserMed.LoginUser
{
    public class LoginUserCommandResponse
    {
        public TokenResponse Token { get; set; }

        public string message { get; set; }
    }
}
