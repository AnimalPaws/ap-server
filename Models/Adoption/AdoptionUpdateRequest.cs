using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ap_server.Models.Announcement;
using ap_server.Services;
using System.ComponentModel.DataAnnotations;

namespace ap_server.Models.Adoption
{
    public class AdoptionUpdateRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
