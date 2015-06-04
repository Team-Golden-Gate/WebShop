namespace GoldenGateShop.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class IndividualPromotion
    {
        public int Id { get; set; }

        public int PromotionId { get; set; }

        public virtual Promotion Promotion { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime StartedOn { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime EndedOn { get; set; }
    }
}
