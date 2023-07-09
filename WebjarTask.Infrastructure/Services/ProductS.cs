using ErrorOr;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebjarTask.Application.Common.Interfaces.Repository;
using WebjarTask.Application.Common.Interfaces.Services;
using WebjarTask.Application.Common.Tools;
using WebjarTask.Application.Product.Common;
using WebjarTask.Domain.Entities.Product;

namespace WebjarTask.Infrastructure.Services
{
    public class ProductS: IProductS
    {
        private readonly IGenericR<AdditiveM> _additive;
        private readonly IGenericR<ProductAdditiveM> _productAdditive;
        private readonly IGenericR<ProductM> _product;
        private readonly IGenericR<FeaturesM> _feature;
        private readonly IGenericR<ProductPriceM> _productPrice;
        private readonly IGenericR<ProductFeaturesM> _productFeatures;


        public ProductS(IGenericR<AdditiveM> additive, IGenericR<ProductAdditiveM> productAdditive, IGenericR<ProductM> product, IGenericR<FeaturesM> feature, IGenericR<ProductPriceM> productPrice, IGenericR<ProductFeaturesM> productFeatures)
        {
            _additive = additive;
            _productAdditive = productAdditive;
            _product = product;
            _feature = feature;
            _productPrice = productPrice;
            _productFeatures = productFeatures;
        }

        public async Task<ErrorOr<bool>> AddAdditive(AdditiveM model)
        {
            var result = await _additive.Insert(model);
            if (result.IsError)
                return result.Errors;
            return true;
        }
        public async Task<ErrorOr<bool>> AddProductAdditive(ProductAdditiveM model)
        {
            var result = await _productAdditive.Insert(model);
            if (result.IsError)
                return result.Errors;
            return true;
        }
        public async Task<ErrorOr<bool>> AddProduct(ProductM model)
        {
            var result = await _product.Insert(model);
            if (result.IsError)
                return result.Errors;
            return true;
        }
        public async Task<ErrorOr<bool>> AddFeature(FeaturesM model)
        {
            var result = await _feature.Insert(model);
            if (result.IsError)
                return result.Errors;
            return true;
        }
        public async Task<ErrorOr<bool>> AddPriceToProduct(ProductPriceM model)
        {
            var result = await _productPrice.Insert(model,x=>x.Include(y=>y.ProductFeatures));
            if (result.IsError)
                return result.Errors;
            return true;
        }
        public async Task<ErrorOr<List<Product_vm>>> GetProducts(string SortField)
        {
            Expression<Func<Product_vm, object>> order = u => true;
            if (!string.IsNullOrEmpty(SortField))
            {
                var tryGetOrder = QueryT<Product_vm>.GetExpressionWithString(SortField);
                if (!tryGetOrder.IsError)
                    order = tryGetOrder.Value;
            }
            var result = await _productPrice.GetAllWithCondition<Product_vm>(null, x => x.Include(y => y.Product), true, order, true);
            return result;
        }
        public async Task<ErrorOr<List<ProductFeatureVal_vm>>> GetProductFeaturesByPriceId(int PriceId)
        {
            var result = await _productFeatures.GetAllWithCondition<ProductFeatureVal_vm>(x => x.ProductPriceId == PriceId, i=>i.Include(x=>x.Feature), true);
            return result;
        }
        public async Task<ErrorOr<List<ProductAdditive_vm>>> GetProductAdditivesByProductId(int ProductId)
        {
            var result = await _productAdditive.GetAllWithCondition<ProductAdditive_vm>(x => x.ProductId == ProductId, null, true);
            return result;
        }
    }
}
