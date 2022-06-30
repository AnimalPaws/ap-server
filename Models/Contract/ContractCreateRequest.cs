using System.ComponentModel.DataAnnotations;

namespace ap_server.Models.Contract
{
    public class ContractCreateRequest
    {
        [Required]
        public string Names { get; set; }
        [Required]
        public string Last_Name { get; set; }
        [Required]
        public string Address { get; set; }
        public string Email { get; set; }
        [Required]
        public string Phone_Number { get; set; }
        [Required]
        public string Specie { get; set; }
        [Required]
        public string Breed { get; set; }
        [Required]
        public string Sex { get; set; }
        public float? Weight { get; set; }
        public bool? Is_Sterilized { get; set; }
        public bool? Is_Deworming { get; set; }
        [Required]
        public string Adopter_Firm { get; set; }
        [Required]
        public string Reporter_Firm { get; set; }
        public DateTime? Created_At { get; set; }
    }
}
