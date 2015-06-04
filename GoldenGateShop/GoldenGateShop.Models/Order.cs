namespace GoldenGateShop.Models
{
    using System;

    public class Order
    {
        public int Id { get; set; }

        public virtual Product Product { get; set; }

        public virtual User User { get; set; }

        public DateTime OrderedOn { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
