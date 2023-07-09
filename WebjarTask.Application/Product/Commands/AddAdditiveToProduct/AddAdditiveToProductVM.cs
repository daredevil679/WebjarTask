using ErrorOr;
using MediatR;

namespace WebjarTask.Application.Product.Commands.AddAdditiveToProduct
{
    public class AddAdditiveToProductVM : IRequest<ErrorOr<bool>>
    {
        public int ProductId { get; set; }
        public int AdditiveId { get; set; }
        public decimal Price { get; set; }
    }
}
