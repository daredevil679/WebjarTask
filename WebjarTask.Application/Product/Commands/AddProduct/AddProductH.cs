using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using WebjarTask.Application.Common.Interfaces.Services;
using WebjarTask.Application.Common.Tools;
using WebjarTask.Domain.Entities.Product;
using WebjarTask.Domain.Errors;

namespace WebjarTask.Application.Product.Commands.AddProduct
{
    public class AddProductH : IRequestHandler<AddProductVM, ErrorOr<bool>>
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IProductS _product;
        public AddProductH(IWebHostEnvironment hostingEnvironment, IProductS product)
        {
            _hostingEnvironment = hostingEnvironment;
            _product = product;
        }

        public async Task<ErrorOr<bool>> Handle(AddProductVM request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            var path = "storage/system/products/images";
            var rootPath = Path.Combine(_hostingEnvironment.WebRootPath, path);
            var uploadPic = await request.Image.UploadFileAsync(rootPath);
            if (uploadPic.IsError)
                return uploadPic.FirstError;
            var product = new ProductM()
            {
                Name = request.Name,
                ImageLink = "../" + path + "/" + uploadPic.Value
            };
            var result = await _product.AddProduct(product);
            return result;
        }
    }
}
