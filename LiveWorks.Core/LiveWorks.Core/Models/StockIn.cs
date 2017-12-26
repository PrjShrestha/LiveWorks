using System.ComponentModel.DataAnnotations;

namespace LiveWorks.Core.Models
{
    public class StockIn
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int StoreDate { get; set; }
        [Required]
        public virtual Item Item { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public string PersonWhoStored { get; set; }
        [Required]
        public virtual Client ClientBoughtFrom { get; set; }
        [Required]
        public bool NewItem { get; set; }
        [Required]
        public string Remarks { get; set; }
    }
}
