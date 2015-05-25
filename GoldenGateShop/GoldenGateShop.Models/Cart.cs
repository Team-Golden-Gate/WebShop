using System.ComponentModel.DataAnnotations;
namespace GoldenGateShop.Models
{
    public class Cart
    {
        public int Id { get; set; }

        [Required]
        public virtual User User { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
      
        public decimal Price { get; set; }

        public int StateId { get; set; }

        public virtual State State { get; set; }

        public int OrderId { get; set; }

        public virtual Order Order { get; set; }
    }
}
