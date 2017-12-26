using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LiveWorks.Core.Models
{
    public class Order
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public double TotalSum { get; set; }
        public double Discount { get; set; }
        public string ClientName { get; set; }
        public virtual Client Client { get; set; }

    }
}
