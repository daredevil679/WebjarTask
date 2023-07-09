using ErrorOr;
using MediatR;
using WebjarTask.Application.Common.Interfaces.Services;
using WebjarTask.Application.Product.Common;

namespace WebjarTask.Application.Product.Queries.GetFeaturesByPriceId
{
    public class GetFeaturesByPriceIdH : IRequestHandler<GetFeaturesByPriceIdVM, ErrorOr<List<ProductFeatureVal_vm>>>
    {
        private readonly IProductS _product;

        public GetFeaturesByPriceIdH(IProductS product)
        {
            _product = product;
        }

        public async Task<ErrorOr<List<ProductFeatureVal_vm>>> Handle(GetFeaturesByPriceIdVM request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            var result = await _product.GetProductFeaturesByPriceId(request.Id);
            return result;
        }
    }
}
