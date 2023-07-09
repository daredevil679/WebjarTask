using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebjarTask.Application.Product.Commands.AddAdditiveToProduct;

namespace WebjarTask.Application.Product.Commands.AddFeature
{
    public class AddFeatureV : AbstractValidator<AddFeatureVM>
    {
        public AddFeatureV()
        {
            RuleFor(x => x.Name)
               .Must(Name => !string.IsNullOrEmpty(Name)).WithMessage("لطفا نام ویژگی را وارد کنید")
               .MaximumLength(50).WithMessage("طول نام ویژگی حد اکثر 50 کاراکتر است");
        }
    }
}
