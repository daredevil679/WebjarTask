using FluentValidation;

namespace WebjarTask.Application.Product.Commands.AddPriceForProduct
{
    public class AddPriceForProductV : AbstractValidator<AddPriceForProductVM>
    {
        public AddPriceForProductV()
        {
            When(x => x.Features != null, () =>
            {
                RuleForEach(vm => vm.Features)
                    .Must(x => !string.IsNullOrEmpty(x.Value)).WithMessage("لطفا ویژگی را مقداردهی کنید");
            });
            When(x => x.DiscountExpireAt != null, () =>
            {
                RuleFor(p => p.DiscountExpireAt)
                .Must(expire => DateTime.Compare(expire.Value, DateTime.Now) > 0)
                .WithMessage("تاریخ انقضا باید بعد از تاریخ الآن باشد");
                RuleFor(p => p.DiscountAmount)
                .Must(DiscountAmount => DiscountAmount != null)
                .WithMessage("لطفا مقدار تخفیف را مشخص کنید");
            });
            When(x => x.IsFormulaPrice == true, () =>
            {
                RuleFor(m => m.FormulaMultiplier)
                .Must(mult => mult != null).WithMessage("لطفا ضریب فرمول را مقدار دهی کنید");
            });
            When(x => x.IsFormulaPrice == false, () =>
            {
                RuleFor(m => m.Price)
                .Must(price => price != null).WithMessage("لطفا قیمت را مقدار دهی کنید");
            });
        }
    }
}
