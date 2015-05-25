namespace GoldenGateShop.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Category
    {
        private ICollection<Product> products;
        private ICollection<Characteristic> characteristics;

        public Category()
        {
            this.products = new HashSet<Product>();
            this.characteristics = new HashSet<Characteristic>();
        }

        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [StringLength(50)]
        public string Name { get; set; }

        public int Position { get; set; }

        public virtual ICollection<Characteristic> Characteristics
        {
            get { return this.characteristics; }
            set { this.characteristics = value; }
        }

        public virtual ICollection<Product> Products
        {
            get { return this.products; }
            set { this.products = value; }
        }
    }
}
