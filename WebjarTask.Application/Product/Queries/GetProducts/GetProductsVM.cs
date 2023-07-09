using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebjarTask.Application.Product.Common;

namespace WebjarTask.Application.Product.Queries.GetProducts
{
    public class GetProductsVM : IRequest<ErrorOr<List<Product_vm>>>
    {
        public string? SortField { get; set; }
    }
}
