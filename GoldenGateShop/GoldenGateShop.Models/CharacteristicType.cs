namespace GoldenGateShop.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class CharacteristicType
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
        [Index(IsUnique = true)]
        [StringLength(50)]
        public string Name { get; set; }

        public int Position { get; set; }

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
    }
}
