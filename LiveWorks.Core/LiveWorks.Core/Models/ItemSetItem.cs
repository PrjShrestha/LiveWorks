using System.ComponentModel.DataAnnotations;

namespace LiveWorks.Core.Models
{
    public class ItemSetItem
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public virtual ItemSet ItemSet { get; set; }
        [Required]
        public virtual Item Item { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
