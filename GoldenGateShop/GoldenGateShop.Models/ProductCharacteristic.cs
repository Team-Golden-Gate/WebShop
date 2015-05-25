namespace GoldenGateShop.Models
{
    public class ProductCharacteristic
    {
        public int Id { get; set; }

        public int CharacteristicId { get; set; }

        public virtual Characteristic Characteristic { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
