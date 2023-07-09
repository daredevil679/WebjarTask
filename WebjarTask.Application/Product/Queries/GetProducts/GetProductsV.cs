using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebjarTask.Application.Product.Commands.AddPriceForProduct;

namespace WebjarTask.Application.Product.Queries.GetProducts
{
    public class GetProductsV : AbstractValidator<GetProductsVM>
    {
        public GetProductsV()
        {

        }
    }
}
