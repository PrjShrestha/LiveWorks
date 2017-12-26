using System.ComponentModel.DataAnnotations;

namespace LiveWorks.Core.Models
{
    public class Inventory
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public virtual Item Item { get; set; }
        [Required]
        public int AvailableQuantity { get; set; }
        [Required]
        public System.DateTime RestockDate { get; set; }
        [Required]
        public int RestockQuantity { get; set; }
    }
}
