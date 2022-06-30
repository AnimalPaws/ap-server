using System;
using System.Collections.Generic;

#nullable disable

namespace ap_server.Model
{
    public partial class Donation
    {
        public int Id { get; set; }
        public int? ProfileId { get; set; }
        public int? CategoryId { get; set; }
        public double? Goal { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public int? Likes { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
