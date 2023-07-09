using ErrorOr;
using MapsterMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebjarTask.Application.Common.Interfaces.Services;
using WebjarTask.Application.Product.Commands.AddAdditiveToProduct;
using WebjarTask.Domain.Entities.Product;

namespace WebjarTask.Application.Product.Commands.AddFeature
{
    public class AddFeatureH : IRequestHandler<AddFeatureVM, ErrorOr<bool>>
    {
        private readonly IProductS _product;
        private readonly IMapper _mapper;
        public AddFeatureH(IProductS product, IMapper mapper)
        {
            _product = product;
            _mapper = mapper;
        }

        public async Task<ErrorOr<bool>> Handle(AddFeatureVM request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            var feature = _mapper.Map<FeaturesM>(request);
            var result = await _product.AddFeature(feature);
            return result;
        }
    }
}
