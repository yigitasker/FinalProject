using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.ProductName).MinimumLength(2);                 // Product ın ProductName i 2 karakter..
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(0);
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1);      // ıd 1 olanlar için unirprice 10 dan küçük olmayacak demiş olduk.
            RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Ürünler A harfi ile başlamalı.");                                         // Kendi oluşturduğumuz metoda uyum istedik
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");                                    // arg bool olduğu için true false döner
        }
    }
}
