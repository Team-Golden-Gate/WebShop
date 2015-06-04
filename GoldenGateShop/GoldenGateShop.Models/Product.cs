namespace GoldenGateShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using GoldenGateShop.Contracts;


    public class Product : IAuditInfo, IDeletableEntity
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
        [StringLength(50)]
        public string Name { get; set; }

        public string Picture { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
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

        public int TradeId { get; set; }

        public virtual Trade Trade { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreatedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ModifiedOn { get; set; }

        [Index]
        public bool IsDeleted { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DeletedOn { get; set; }
    }
}
