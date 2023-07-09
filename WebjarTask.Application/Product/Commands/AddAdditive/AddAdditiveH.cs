using ErrorOr;
using MapsterMapper;
using MediatR;
using WebjarTask.Application.Common.Interfaces.Services;
using WebjarTask.Domain.Entities.Product;

namespace WebjarTask.Application.Product.Commands.AddAdditive
{
    public class AddAdditiveH : IRequestHandler<AddAdditiveVM, ErrorOr<bool>>
    {
        private readonly IMapper _mapper;
        private readonly IProductS _product;
        public AddAdditiveH(IMapper mapper, IProductS product)
        {
            _mapper = mapper;
            _product = product;
        }

        public async Task<ErrorOr<bool>> Handle(AddAdditiveVM request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            var additive = _mapper.Map<AdditiveM>(request);
            var result = await _product.AddAdditive(additive);
            return result;
        }
    }
}
