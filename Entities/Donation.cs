namespace ap_server.Entities
{
    public class Donation
    {
        public int Id { get; set; }
        public int? Profile_Id { get; set; }
        public int? Category_Id { get; set; }
        public double? Goal { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int? Likes { get; set; }
        public DateTime? Created_At { get; set; }
    }
}
