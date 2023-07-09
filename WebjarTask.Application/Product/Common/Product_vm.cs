namespace WebjarTask.Application.Product.Common
{
    public class Product_vm
    {
        public int ProductId { get; set; }
        public int PriceId { get; set; }
        public string ProductName { get; set; }
        public string ImageLink { get; set; }
        public string Price { get; set; }
        public string? DiscountAmount { get; set; }
        public string? DiscountExpireAt { get; set; }
    }
}
