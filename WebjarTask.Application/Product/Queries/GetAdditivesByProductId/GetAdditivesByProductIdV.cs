using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebjarTask.Application.Product.Queries.GetFeaturesByPriceId;

namespace WebjarTask.Application.Product.Queries.GetAdditivesByProductId
{
    public class GetAdditivesByProductIdV : AbstractValidator<GetAdditivesByProductIdVM>
    {
        public GetAdditivesByProductIdV()
        {
            RuleFor(x => x.Id)
                .Must(id => id > 0).WithMessage("لطفا شناسه ی کالا را وارد کنید");
        }
    }
}
