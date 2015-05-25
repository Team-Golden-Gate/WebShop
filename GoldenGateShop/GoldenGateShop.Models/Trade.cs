namespace GoldenGateShop.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Trade
    {
        private ICollection<Product> product;

        public Trade()
        {
            this.product = new HashSet<Product>();
        }

        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [StringLength(50)]
        public string Name { get; set; }

        public int Position { get; set; }

        public virtual ICollection<Product> Products
        {
            get { return this.product; }
            set { this.product = value; }
        }
    }
}
