namespace GoldenGateShop.Models
{
    using System.ComponentModel.DataAnnotations;

    public class State
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
