using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LiveWorks.Core.Models
{
    public class ItemSet
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string ItemSetType { get; set; }

        public string Description { get; set; }
    }
}
