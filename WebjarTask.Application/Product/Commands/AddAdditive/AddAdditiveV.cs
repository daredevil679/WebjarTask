using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebjarTask.Application.Product.Commands.AddAdditive
{
    public class AddAdditiveV : AbstractValidator<AddAdditiveVM>
    {
        public AddAdditiveV()
        {
            RuleFor(x => x.Name)
               .Must(Name => !string.IsNullOrEmpty(Name)).WithMessage("لطفا نام افزودنی را وارد کنید")
               .MaximumLength(100).WithMessage("طول نام افزودنی حد اکثر 100 کاراکتر است");
        }
    }
}
