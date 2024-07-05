using CacheNQueue.Domain.Entities.Identity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheNQueue.Application.Med.ProductMed.CreateUser
{
    public class CreateUserCommandRequest : IRequest<CreateUserCommandResponse>
    {

        public string UserName { get; set; }
        public string Name_Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }


        public static AppUser Map(CreateUserCommandRequest request)
        {
            if (request.Password == request.PasswordConfirm)
            {
                return new AppUser()
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = request.UserName,
                    Surname = request.Name_Surname,
                    Email = request.Email,
                };

            }
            throw new Exception("Şifre eşlesmiyor");

        }
    }
}
