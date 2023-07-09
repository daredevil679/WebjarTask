using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebjarTask.Application.Product.Commands.AddFeature
{
    public class AddFeatureVM : IRequest<ErrorOr<bool>>
    {
        public string Name { get; set; }
    }
}
