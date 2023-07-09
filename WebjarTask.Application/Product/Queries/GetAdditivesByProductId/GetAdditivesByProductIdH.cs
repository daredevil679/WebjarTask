using ErrorOr;
using MediatR;
using WebjarTask.Application.Common.Interfaces.Services;
using WebjarTask.Application.Product.Common;

namespace WebjarTask.Application.Product.Queries.GetAdditivesByProductId
{
    public class GetAdditivesByProductIdH : IRequestHandler<GetAdditivesByProductIdVM, ErrorOr<List<ProductAdditive_vm>>>
    {
        private readonly IProductS _product;

        public GetAdditivesByProductIdH(IProductS product)
        {
            _product = product;
        }

        public async Task<ErrorOr<List<ProductAdditive_vm>>> Handle(GetAdditivesByProductIdVM request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            var result = await _product.GetProductAdditivesByProductId(request.Id);
            return result;
        }
    }
}
