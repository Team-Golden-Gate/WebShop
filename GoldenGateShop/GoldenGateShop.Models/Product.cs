namespace GoldenGateShop.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Product
    {
        private ICollection<ProductCharacteristic> productCharacteristics;
        private ICollection<IndividualPromotion> promotions;

        public Product()
        {
            this.productCharacteristics = new HashSet<ProductCharacteristic>();
            this.promotions = new HashSet<IndividualPromotion>();
        }

        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [StringLength(50)]
        public string Name { get; set; }

        public string Picture { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public virtual ICollection<ProductCharacteristic> ProductCharacteristics
        {
            get { return this.productCharacteristics; }
            set { this.productCharacteristics = value; }
        }
        public virtual ICollection<IndividualPromotion> Promotions
        {
            get { return this.promotions; }
            set { this.promotions = value; }
        }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public int SubCategoryId { get; set; }

        public virtual SubCategory SubCategory { get; set; }

        public int TradeId { get; set; }

        public virtual Trade Trade { get; set; }
    }
}
