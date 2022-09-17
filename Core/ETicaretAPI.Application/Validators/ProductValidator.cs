using ETicaretAPI.Application.CQRS.Product.Command.Add;
using ETicaretAPI.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Validators
{
    public class ProductValidator : AbstractValidator<AddProductCommandRequest>
    {
        public ProductValidator()
        {
            RuleFor(p => p.Name).NotNull().NotEmpty().WithMessage("Lutfen isim alanını doldurunuz").MaximumLength(150).WithMessage("Lutfen 150 karakterden fazla girmeyiniz");

            RuleFor(p => p.Stock).NotNull().NotEmpty().WithMessage("Lutfen stok alanını doldurunuz").Must(p => p >= 0)
                .WithMessage("Lutfen stok alanına negatif deger girmeyiniz");

            RuleFor(p => p.Price).NotNull().NotEmpty().WithMessage("Lutfen fiyat alanını doldurunuz").Must(p => p >= 0)
              .WithMessage("Lutfen fiyat alanına negatif deger girmeyiniz");
        }
    }
}
