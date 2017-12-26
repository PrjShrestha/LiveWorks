using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LiveWorks.Core.Models
{
    public class Bill
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public double TotalSum { get; set; }
        public double Tax { get; set; }

        public double TotalDiscount { get; set; }
        [Required]
        public virtual Client Client {get; set;}
        [Required]
        public double GrandTotal { get; set; }
    }
}
