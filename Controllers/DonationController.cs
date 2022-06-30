using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ap_server.Models.Donation;
using ap_server.Services;

namespace ap_server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DonationController : Controller
    {
        private IDonationService _donationService;
        private IMapper _mapper;

        public DonationController(
            IDonationService donationService,
            IMapper mapper)
        {
            _donationService = donationService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var donation = _donationService.GetAll();
            return Ok(donation);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var donation = _donationService.GetById(id);
            return Ok(donation);
        }

        [HttpPost]
        public IActionResult Create(DonationCreateRequest model)
        {
            _donationService.Create(model);
            return Ok(new
            {
                message = "Donation created",
                Status = 200
            });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _donationService.Delete(id);
            return Ok(new
            {
                Message = "Donation deleted",
                Status = 200
            });
        }
    }
}
