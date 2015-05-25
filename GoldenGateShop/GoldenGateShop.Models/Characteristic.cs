namespace GoldenGateShop.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Characteristic
    {
        public ICollection<Category> category;

        public Characteristic()
        {
            this.category = new HashSet<Category>();
        }

        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [StringLength(50)]
        public string Name { get; set; }

        public int Position { get; set; }

        public virtual ICollection<Category> Category
        {
            get { return this.category; }
            set { this.category = value; }
        }
    }
}
