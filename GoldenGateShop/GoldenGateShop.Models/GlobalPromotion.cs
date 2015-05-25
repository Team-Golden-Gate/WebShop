namespace GoldenGateShop.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class GlobalPromotion
    {
        public int Id { get; set; }

        public DateTime StartedOn { get; set; }

        public DateTime EndedOn { get; set; }

        [Required]
        public virtual Promotion Promotion { get; set; }
    }
}
