using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using WebjarTask.Application.Common.Interfaces.Services;
using WebjarTask.Domain.Entities.Product;
using WebjarTask.Domain.Errors;

namespace WebjarTask.Application.Product.Commands.AddPriceForProduct
{
    public class AddPriceForProductH : IRequestHandler<AddPriceForProductVM, ErrorOr<bool>>
    {
        private readonly IProductS _product;
        private readonly IMapper _mapper;
        private IConfiguration _config;
        public AddPriceForProductH(IProductS product, IMapper mapper, IConfiguration config)
        {
            _product = product;
            _mapper = mapper;
            _config = config;
        }

        public async Task<ErrorOr<bool>> Handle(AddPriceForProductVM request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            var price = _mapper.Map<ProductPriceM>(request);
            if (request.IsFormulaPrice == true)
            {
                var dollarPrice = _config.GetValue<decimal>("PriceValuation:DOLLAR");
                price.Price = request.FormulaMultiplier.Value * dollarPrice;
            }
            if (request.DiscountAmount != null && decimal.Compare(request.DiscountAmount.Value, price.Price) > 0)
                return VErrors.Product.InvalidDiscount;
            var result = await _product.AddPriceToProduct(price);
            return result;
        }
    }
}
