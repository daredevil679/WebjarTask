using ErrorOr;
using MediatR;

namespace WebjarTask.Application.Product.Commands.AddAdditive
{
    public class AddAdditiveVM : IRequest<ErrorOr<bool>>
    {
        public string Name { get; set; }
    }
}
