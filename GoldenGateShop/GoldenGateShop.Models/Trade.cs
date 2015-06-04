namespace GoldenGateShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using GoldenGateShop.Contracts;


    public class Trade : IAuditInfo, IDeletableEntity
    {
        private ICollection<Product> product;

        public Trade()
        {
            this.product = new HashSet<Product>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public int Position { get; set; }

        public virtual ICollection<Product> Products
        {
            get { return this.product; }
            set { this.product = value; }
        }

        [Column(TypeName = "datetime2")]
        public DateTime CreatedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ModifiedOn { get; set; }

        [Index]
        public bool IsDeleted { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DeletedOn { get; set; }
    }
}
