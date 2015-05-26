namespace GoldenGateShop.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Category
    {
        private ICollection<Product> products;
        private ICollection<CharacteristicType> characteristicType;

        public Category()
        {
            this.products = new HashSet<Product>();
            this.characteristicType = new HashSet<CharacteristicType>();
        }

        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [StringLength(50)]
        public string Name { get; set; }

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
    }
}
