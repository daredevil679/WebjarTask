namespace WebjarTask.Domain.Entities.Product
{
    public class ProductAdditiveM
    {
        public int ProductId { get; set; }
        public int AdditiveId { get; set; }
        public decimal Price { get; set; }

        #region Relations
        public virtual ProductM Product { get; set; }
        public virtual AdditiveM Additive { get; set; }
        #endregion
    }
}
