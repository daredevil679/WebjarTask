using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebjarTask.Application.Product.Common;

namespace WebjarTask.Application.Product.Queries.GetAdditivesByProductId
{
    public class GetAdditivesByProductIdVM : IRequest<ErrorOr<List<ProductAdditive_vm>>>
    {
        public int Id { get; set; }
    }
}
