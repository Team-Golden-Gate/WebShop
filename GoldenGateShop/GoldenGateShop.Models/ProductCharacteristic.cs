namespace GoldenGateShop.Models
{
    public class ProductCharacteristic
    {
        public int Id { get; set; }

        public int CharacteristicValueId { get; set; }

        public virtual CharacteristicValue CharacteristicValue { get; set; }

        public int CharacteristicTypeId { get; set; }

        public virtual CharacteristicType CharacteristicType { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
