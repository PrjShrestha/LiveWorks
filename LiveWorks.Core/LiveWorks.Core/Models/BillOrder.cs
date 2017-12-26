using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LiveWorks.Core.Models
{
    public class BillOrder
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public virtual Bill Bill { get; set; }
        [Required]
        public virtual Order Order { get; set; }

    }
}
