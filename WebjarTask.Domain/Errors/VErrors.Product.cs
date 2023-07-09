using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebjarTask.Domain.Errors
{
    public partial class VErrors
    {
        public static class Product
        {
            public static Error InvalidDiscount => Error.Validation(
                code: "Product.InvalidDiscount",
                description: "مقدار تخفیف از قیمت کالا نمیتواند بیشتر باشد");
        }
    }
}
