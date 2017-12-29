using System;
using System.ComponentModel.DataAnnotations;

namespace LiveWorks.Core.Models
{
    public class StockOut
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public DateTime DealDate { get; set; }
        [Required]
        public virtual Item Item { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public string Dealer { get; set; }
        [Required]
        public string Client { get; set; }

        public string Remarks { get; set; }
    }
}
