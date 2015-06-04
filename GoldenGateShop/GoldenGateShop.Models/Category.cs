namespace GoldenGateShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using GoldenGateShop.Contracts;


    public class Category : IAuditInfo, IDeletableEntity
    {
        private ICollection<Product> products;
        private ICollection<CharacteristicType> characteristicType;

        public Category()
        {
            this.products = new HashSet<Product>();
            this.characteristicType = new HashSet<CharacteristicType>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public int Position { get; set; }

        public virtual ICollection<CharacteristicType> CharacteristicTypes
        {
            get { return this.characteristicType; }
            set { this.characteristicType = value; }
        }

        public virtual ICollection<Product> Products
        {
            get { return this.products; }
            set { this.products = value; }
        }

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
