using System;
using System.ComponentModel.DataAnnotations;

namespace LiveWorks.Core.Models
{
    public class StockIn
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public DateTime StoreDate { get; set; }
        [Required]
        public virtual Item Item { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public string Storer { get; set; }
        public string Supplier { get; set; }
        [Required]
        public bool NewItem { get; set; }

        public string Remarks { get; set; }
    }
}
