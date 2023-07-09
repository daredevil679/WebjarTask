using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebjarTask.Application.Product.Commands.AddAdditive;

namespace WebjarTask.Application.Product.Commands.AddAdditiveToProduct
{
    public class AddAdditiveToProductV : AbstractValidator<AddAdditiveToProductVM>
    {
        public AddAdditiveToProductV()
        {
            RuleFor(x => x.ProductId)
                .Must(pid => pid > 0).WithMessage("لطفا شناسه ی کالا را وارد کنید");
            RuleFor(x => x.AdditiveId)
                .Must(addid => addid > 0).WithMessage("لطفا شناسه ی افزونه را وارد کنید");
        }
    }
}
