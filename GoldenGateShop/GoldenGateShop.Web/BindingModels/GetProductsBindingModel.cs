namespace GoldenGateShop.Web.BindingModels
{
    public class GetProductsBindingModel
    {
        public int PageSize { get; set; }

        public string[] TradeNames { get; set; }

        public decimal? MinPrice { get; set; }

        public decimal? MaxPrice { get; set; }

        public string OrderBy { get; set; }
    }
}