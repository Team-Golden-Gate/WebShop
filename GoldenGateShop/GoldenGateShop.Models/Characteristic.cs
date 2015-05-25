namespace GoldenGateShop.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Characteristic
    {
        public ICollection<SubCategory> subCategory;

        public Characteristic()
        {
            this.subCategory = new HashSet<SubCategory>();
        }

        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [StringLength(50)]
        public string Name { get; set; }

        public int Position { get; set; }

        public virtual ICollection<SubCategory> SubCategory
        {
            get { return this.subCategory; }
            set { this.subCategory = value; }
        }
    }
}
