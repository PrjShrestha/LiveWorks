using System.ComponentModel.DataAnnotations;

namespace LiveWorks.Core.Models
{
    public class Category
    {
        [Required]
        int id;
        [Required]
        string categoryName;
    }
}
