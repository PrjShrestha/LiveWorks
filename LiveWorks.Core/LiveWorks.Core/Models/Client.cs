using System.ComponentModel.DataAnnotations;

namespace LiveWorks.Core.Models
{
    public class Client
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string Address { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string OfficeAddress { get; set; }
    }
}
