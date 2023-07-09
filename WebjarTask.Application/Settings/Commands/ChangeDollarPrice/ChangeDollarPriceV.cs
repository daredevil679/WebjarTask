using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebjarTask.Application.Product.Commands.AddPriceForProduct;

namespace WebjarTask.Application.Settings.Commands.ChangeDollarPrice
{
    public class ChangeDollarPriceV : AbstractValidator<ChangeDollarPriceVM>
    {
        public ChangeDollarPriceV()
        {
            RuleFor(x => x.DollarPrice)
                .Must(p => p > 0).WithMessage("لطفا قیمت دلار را وارد کنید");
        }
    }
}
