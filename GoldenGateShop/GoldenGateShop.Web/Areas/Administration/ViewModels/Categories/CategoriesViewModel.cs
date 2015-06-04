namespace GoldenGateShop.Web.Areas.Administration.ViewModels.Categories
{
    using GoldenGateShop.Models;
    using GoldenGateShop.Web.Infrastructure.Mapping;
    using System.ComponentModel.DataAnnotations;

    public class CategoriesViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public int Position { get; set; }
    }
}