namespace WebjarTask.Domain.Entities.Product
{
    public class ProductPriceM
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public bool IsFormulaPrice { get; set; }
        public decimal? DiscountAmount { get; set; }
        public DateTime? DiscountExpireAt { get; set; }
        #region Relations
        public virtual ICollection<ProductFeaturesM> ProductFeatures { get; set; }
        public virtual ProductM Product { get; set; }
        #endregion
    }
}
