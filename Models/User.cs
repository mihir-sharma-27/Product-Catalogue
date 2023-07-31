using System.ComponentModel.DataAnnotations;

namespace ProductCatalogueService.Models
{
    public class User
    {
        [Key]
        public string Username { get; set; }
        public string Password { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }
    }
}
