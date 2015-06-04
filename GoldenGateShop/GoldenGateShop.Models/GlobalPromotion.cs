namespace GoldenGateShop.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class GlobalPromotion
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime StartedOn { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime EndedOn { get; set; }

        [Required]
        public virtual Promotion Promotion { get; set; }
    }
}
