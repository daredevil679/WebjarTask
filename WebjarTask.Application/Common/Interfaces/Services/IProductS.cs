using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebjarTask.Application.Product.Common;
using WebjarTask.Domain.Entities.Product;

namespace WebjarTask.Application.Common.Interfaces.Services
{
    public interface IProductS
    {
        Task<ErrorOr<bool>> AddAdditive(AdditiveM model);
        Task<ErrorOr<bool>> AddProductAdditive(ProductAdditiveM model);
        Task<ErrorOr<bool>> AddProduct(ProductM model);
        Task<ErrorOr<bool>> AddFeature(FeaturesM model);
        Task<ErrorOr<bool>> AddPriceToProduct(ProductPriceM model);
        Task<ErrorOr<List<Product_vm>>> GetProducts(string SortField);
        Task<ErrorOr<List<ProductFeatureVal_vm>>> GetProductFeaturesByPriceId(int PriceId);
        Task<ErrorOr<List<ProductAdditive_vm>>> GetProductAdditivesByProductId(int ProductId);
    }
}
