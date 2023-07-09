using Mapster;
using WebjarTask.Application.Product.Commands.AddPriceForProduct;
using WebjarTask.Application.Product.Common;
using WebjarTask.Domain.Entities.Product;

namespace WebjarTask.Common.Mappings
{
    public class MappingC : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<AddPriceForProductVM, ProductPriceM>()
                .Map(dest => dest.ProductFeatures, src => src.Features)
                ;
            config.NewConfig<ProductPriceM, Product_vm>()
                .Map(dest => dest.ProductId, src => src.Product.Id)
                .Map(dest => dest.ProductName, src => src.Product.Name)
                ;
            config.NewConfig<ProductFeaturesM, ProductFeatureVal_vm>()
                .Map(dest => dest.FeatureName, src => src.Feature.Name)
                ;
        }
    }
}
