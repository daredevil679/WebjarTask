using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebjarTask.Domain.Entities.Product
{
    public class FeaturesM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        #region Relations
        public virtual ICollection<ProductFeaturesM> ProductFeatures { get; set; }
        #endregion
    }
}
