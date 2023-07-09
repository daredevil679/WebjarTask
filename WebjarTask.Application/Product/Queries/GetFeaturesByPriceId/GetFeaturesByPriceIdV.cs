using FluentValidation;

namespace WebjarTask.Application.Product.Queries.GetFeaturesByPriceId
{
    public class GetFeaturesByPriceIdV : AbstractValidator<GetFeaturesByPriceIdVM>
    {
        public GetFeaturesByPriceIdV()
        {
            RuleFor(x => x.Id)
                .Must(id => id > 0).WithMessage("لطفا شناسه ی قیمت را وارد کنید");
        }
    }
}
