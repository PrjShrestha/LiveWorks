using System.ComponentModel.DataAnnotations;

namespace LiveWorks.EntityDto
{
    public class CategoryDto
    {
        [Required]
        public int Id;
        [Required]
        public string categoryName;
    }
}
