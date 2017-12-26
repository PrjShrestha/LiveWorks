using System.ComponentModel.DataAnnotations;

namespace LiveWorks.Core.Models
{
    public class StockOut
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int OutDate { get; set; }
        [Required]
        public virtual Item Item { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public string PersonWhoGave { get; set; }
        [Required]
        public virtual Client ClientRentedTo { get; set; }
        [Required]
        public string Remarks { get; set; }
    }
}
