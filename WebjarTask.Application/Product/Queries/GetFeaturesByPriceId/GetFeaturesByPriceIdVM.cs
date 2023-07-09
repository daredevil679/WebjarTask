using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebjarTask.Application.Product.Common;

namespace WebjarTask.Application.Product.Queries.GetFeaturesByPriceId
{
    public class GetFeaturesByPriceIdVM : IRequest<ErrorOr<List<ProductFeatureVal_vm>>>
    {
        public int Id { get; set; }
    }
}
