namespace GoldenGateShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using GoldenGateShop.Contracts;

    public class CharacteristicValue : IAuditInfo, IDeletableEntity
    {
        private ICollection<ProductCharacteristic> productCharacteristics;

        public CharacteristicValue()
        {
            this.productCharacteristics = new HashSet<ProductCharacteristic>();
        }

        public int Id { get; set; }

        public double Value { get; set; }

        [Required]
        public string Description { get; set; }

        public int CharacteristicTypeId { get; set; }

        public virtual CharacteristicType CharacteristicType { get; set; }

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
