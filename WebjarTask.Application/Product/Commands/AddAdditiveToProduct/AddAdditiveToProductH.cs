using ErrorOr;
using MapsterMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebjarTask.Application.Common.Interfaces.Services;
using WebjarTask.Application.Product.Commands.AddAdditive;
using WebjarTask.Domain.Entities.Product;

namespace WebjarTask.Application.Product.Commands.AddAdditiveToProduct
{
    public class AddAdditiveToProductH : IRequestHandler<AddAdditiveToProductVM, ErrorOr<bool>>
    {
        private readonly IMapper _mapper;
        private readonly IProductS _product;
        public AddAdditiveToProductH(IMapper mapper, IProductS product)
        {
            _mapper = mapper;
            _product = product;
        }

        public async Task<ErrorOr<bool>> Handle(AddAdditiveToProductVM request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            var model = _mapper.Map<ProductAdditiveM>(request);
            var result = await _product.AddProductAdditive(model);
            return result;
        }
    }
}
