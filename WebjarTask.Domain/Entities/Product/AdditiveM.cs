using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebjarTask.Domain.Entities.Product
{
    public class AdditiveM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        #region Relations
        public virtual ICollection<ProductAdditiveM> ProductAdditives { get; set; }
        #endregion
    }
}
