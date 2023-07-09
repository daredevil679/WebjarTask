using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace WebjarTask.Application.Product.Commands.AddProduct
{
    public class AddProductVM : IRequest<ErrorOr<bool>>
    {
        public string Name { get; set; }
        public IFormFile Image { get; set; }
    }
}
