using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebjarTask.Domain.Entities.Product
{
    public class ProductFeaturesM
    {
        public int ProductPriceId { get; set; }
        public int FeatureId { get; set; }
        public string Value { get; set; }
        #region Relations
        public virtual ProductPriceM ProductPrice { get; set; }
        public virtual FeaturesM Feature { get; set; }
        #endregion
    }
}
