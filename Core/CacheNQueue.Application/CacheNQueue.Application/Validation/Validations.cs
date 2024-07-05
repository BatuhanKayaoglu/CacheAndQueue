using CacheNQueue.Application.Features.OrderMed.Add;
using CacheNQueue.Application.Med.ProductMed.Add;
using CacheNQueue.Application.Med.ProductMed.CreateUser;
using CacheNQueue.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheNQueue.Application.Validation
{
    public class ProductValidations : AbstractValidator<CreateProductCommandReques>
    {
        public ProductValidations()
        {
            RuleFor(x => x.Name).NotEmpty()
                .WithMessage("Name Boş Geçilemez")
                .NotNull()
                .WithMessage("Boş geçilemez")
                .MaximumLength(15)
                .MinimumLength(3)
                .WithMessage("3-15 değer aralığında isimlendirme kullanınız");
            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Description Boş Geçilemez")
                .NotNull()
                .WithMessage("Boş geçilemez")
                .MaximumLength(15)
                .MinimumLength(3)
                .WithMessage("3-15 değer aralığında isimlendirme kullanınız");
            RuleFor(x => x.Price).NotEmpty()
                .WithMessage("3-15 değer aralığında isimlendirme kullanınız");

        }
    }
    public class OrderValidation : AbstractValidator<CreateOrderCommandRequest>
    {
        public OrderValidation()
        {
            RuleFor(x => x.Address).NotNull().NotEmpty().WithMessage("Boş brakılamaz");
            RuleFor(x => x.UserId).NotNull().NotEmpty().WithMessage("Boş brakılamaz");
            RuleFor(x => x.ProductId).NotNull().NotEmpty().WithMessage("Boş brakılamaz");
            RuleFor(x => x.UnitPrice).NotNull().NotEmpty().WithMessage("Boş brakılamaz");
            RuleFor(x => x.OrderStatus).NotNull().NotEmpty().WithMessage("Boş brakılamaz");

        }
    }
    public class UserValidation : AbstractValidator<CreateUserCommandRequest>
    {
        public UserValidation()
        {
            RuleFor(x => x.UserName)
                .NotEmpty()
                .NotNull()
                .WithMessage("Kullanıcı adı boş brakılamaz")
                .MaximumLength(10)
                .MinimumLength(3)
                .WithMessage("3-10 değer aralığında bir kullanıcı adı giriniz");
            RuleFor(x => x.Name_Surname)
                .NotEmpty()
                .NotNull()
                .WithMessage(" boş brakılamaz")
                .MaximumLength(20)
                .WithMessage("5-10 değer aralığında bir kullanıcı adı giriniz");
            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull()
                .WithMessage(" boş brakılamaz")
                .EmailAddress()
                .WithMessage("Email adresini doğru giriniz");
            RuleFor(x => x.Password).NotEmpty()
                .NotNull()
                .WithMessage(" boş brakılamaz")
                .MaximumLength(20)
                .MinimumLength(2)
                .WithMessage("5-10 değer aralığında bir kullanıcı adı giriniz");
            RuleFor(x => x.PasswordConfirm).NotEmpty()
               .NotNull()
               .WithMessage(" boş brakılamaz")
               .MaximumLength(20)
               .MinimumLength(2)
               .WithMessage("5-10 değer aralığında bir kullanıcı adı giriniz");
        }
    }
}
