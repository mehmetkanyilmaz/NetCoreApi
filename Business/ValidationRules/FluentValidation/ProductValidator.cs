using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.ProductName).NotEmpty();
            RuleFor(x => x.ProductName).Must(ProductNameCheck).WithMessage("Product name must be at least 2 words");


            RuleFor(x => x.CategoryId).NotEmpty();
            //Kategori id'si sıfırdan büyük olmalı
            RuleFor(x => x.CategoryId).GreaterThan(0);


            RuleFor(x => x.QuantityPerUnit).NotEmpty();


            RuleFor(x => x.UnitPrice).NotEmpty();
            //Birim fiyat sıfırdan büyük olmalı
            RuleFor(x => x.UnitPrice).GreaterThan(0);
            //Kategori id'si 1 olan ürünlerin fiyatları 10'dan büyük olmalı
            RuleFor(x => x.UnitPrice).GreaterThanOrEqualTo(10).When(x => x.ProductId == 1); 


            RuleFor(x => x.UnitsInStock).NotEmpty();
        }

        //Burada kendi kuralımızı oluşturduk.
        //ProductName en az 2 kelime olması gerektiği kuralını uyguladık.
        private bool ProductNameCheck(string arg)
        {
            return arg.Trim().Contains(" ");
        }
    }
}
