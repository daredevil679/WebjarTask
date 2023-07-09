using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebjarTask.Application.Product.Common;

namespace WebjarTask.Application.Product.Commands.AddPriceForProduct
{
    public class AddPriceForProductVM : IRequest<ErrorOr<bool>>
    {
        public int ProductId { get; set; }
        public decimal? Price { get; set; }
        public int Stock { get; set; }
        public bool IsFormulaPrice { get; set; }
        public decimal? FormulaMultiplier { get; set; }
        public decimal? DiscountAmount { get; set; }
        public DateTime? DiscountExpireAt { get; set; }
        public List<ProductFeature_vm>? Features { get; set; } = new List<ProductFeature_vm>();
    }
}
