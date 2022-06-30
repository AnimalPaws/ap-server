namespace ap_server.Entities
{
    public class Contract
    {
        public int Id { get; set; }
        public string Names { get; set; }
        public string Last_Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone_Number { get; set; }
        public string Specie { get; set; }
        public string Breed { get; set; }
        public string Sex { get; set; }
        public float? Weight { get; set; }
        public bool? Is_Sterilized { get; set; }
        public bool? Is_Deworming { get; set; }
        public string Adopter_Firm { get; set; }
        public string Reporter_Firm { get; set; }
        public DateTime? Created_At { get; set; }
    }
}
