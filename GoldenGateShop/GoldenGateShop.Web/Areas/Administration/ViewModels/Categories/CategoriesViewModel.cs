namespace GoldenGateShop.Web.Areas.Administration.ViewModels.Categories
{
    using GoldenGateShop.Models;
    using GoldenGateShop.Web.Infrastructure.Mapping;

    public class CategoriesViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Position { get; set; }
    }
}