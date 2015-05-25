namespace GoldenGateShop.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class SubCategory
    {
        private ICollection<Characteristic> characteristics;

        public SubCategory()
        {
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
    }
}
