using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ap_server.Models.Adoption
{
    public class AdoptionCreateRequest
    {
        [Required]
        public int Profile_Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
