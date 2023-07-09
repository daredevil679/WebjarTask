using ErrorOr;
using MediatR;
using WebjarTask.Application.Common.Interfaces.Services;
using WebjarTask.Application.Product.Common;

namespace WebjarTask.Application.Product.Queries.GetProducts
{
    public class GetProductsH : IRequestHandler<GetProductsVM, ErrorOr<List<Product_vm>>>
    {
        private readonly IProductS _product;

        public GetProductsH(IProductS product)
        {
            _product = product;
        }

        public async Task<ErrorOr<List<Product_vm>>> Handle(GetProductsVM request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            var result = await _product.GetProducts(request.SortField??"");
            return result;
        }
    }
}
