using System.ComponentModel.DataAnnotations;

namespace ap_server.Models.Donation
{
    public class DonationCreateRequest
    {
        [Required]
        public float Goal { get; set; }
        [Required]
        public int Profile_Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
