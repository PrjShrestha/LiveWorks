using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LiveWorks.Core.Models
{
    public class OrderItem
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public virtual Order Order { get; set; }
        [Required]
        public virtual Item Item { get; set; }
        [Required]
        public double PricePerItem { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
