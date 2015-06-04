namespace GoldenGateShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using GoldenGateShop.Contracts;


    public class CharacteristicType : IAuditInfo, IDeletableEntity
    {
        private ICollection<Category> category;
        private ICollection<ProductCharacteristic> productCharacteristics;
        private ICollection<CharacteristicValue> characteristicValue;

        public CharacteristicType()
        {
            this.category = new HashSet<Category>();
            this.characteristicValue = new HashSet<CharacteristicValue>();
            this.productCharacteristics = new HashSet<ProductCharacteristic>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public int Position { get; set; }

        [Required]
        public FilterType FilterType { get; set; }

        public virtual ICollection<Category> Category
        {
            get { return this.category; }
            set { this.category = value; }
        }

        public virtual ICollection<CharacteristicValue> CharacteristicValue
        {
            get { return this.characteristicValue; }
            set { this.characteristicValue = value; }
        }

        public virtual ICollection<ProductCharacteristic> ProductCharacteristics
        {
            get { return this.productCharacteristics; }
            set { this.productCharacteristics = value; }
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
