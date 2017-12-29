using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LiveWorks.EntityDto
{
    public class ItemDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string TypeDto { get; set; }
        [Required]
        public double RentalPrice { get; set; }

        public string Description { get; set; }
        public string Dimensions { get; set; }
        public string Supplier { get; set; }
        [Required]
        public int AvailableQuantity { get; set; }
        [Required]
        public DateTime RestockDate { get; set; }
        [Required]
        public int RestockQuantity { get; set; }
    }
}
