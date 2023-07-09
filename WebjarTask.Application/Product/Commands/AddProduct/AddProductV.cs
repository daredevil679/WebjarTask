using FluentValidation;
using WebjarTask.Application.Common.Enums;
using WebjarTask.Application.Common.Tools;

namespace WebjarTask.Application.Product.Commands.AddProduct
{
    public class AddProductV : AbstractValidator<AddProductVM>
    {
        public AddProductV()
        {
            RuleFor(x => x.Name)
              .Must(Name => !string.IsNullOrEmpty(Name)).WithMessage("لطفا نام کالا را وارد کنید")
              .MaximumLength(150).WithMessage("طول نام کالا حد اکثر 150 کاراکتر است");
            RuleFor(x => x.Image)
                .NotNull().WithMessage("لطفا تصویر کالا را بارگذاری کنید")
              .Must(image => FileExtentionT.GetFileType(image.ContentType) == FileTypeEnum.Image).WithMessage("فایل بارگذاری شده تصویر نیست");
        }
    }
}
