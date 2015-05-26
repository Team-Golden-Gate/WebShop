using System.Collections.Generic;
namespace GoldenGateShop.Models
{
    public class CharacteristicValue
    {
        private ICollection<ProductCharacteristic> productCharacteristics;

        public CharacteristicValue()
        {
            this.productCharacteristics = new HashSet<ProductCharacteristic>();
        }

        public int Id { get; set; }

        public double? Value { get; set; }

        public string Description { get; set; }

        public int CharacteristicTypeId { get; set; }

        public virtual CharacteristicType CharacteristicType { get; set; }

        public virtual ICollection<ProductCharacteristic> ProductCharacteristics
        {
            get { return this.productCharacteristics; }
            set { this.productCharacteristics = value; }
        }
    }
}
