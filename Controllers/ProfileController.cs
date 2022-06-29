using ap_server.Authorization;
using ap_server.Models.Profile;
using ap_server.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ap_server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfileController : Controller
    {
        private IProfileService _profileService;
        private IMapper _mapper;

        public ProfileController(
            IProfileService profileService,
            IMapper mapper)
        {
            _profileService = profileService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var announcements = _profileService.GetAll();
            return Ok(announcements);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var announcements = _profileService.GetById(id);
            return Ok(announcements);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, ProfileUpdateRequest model)
        {
            _profileService.Update(id, model);
            return Ok(new
            {
                message = "Profile updated",
                Status = 200
            });
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _profileService.Delete(id);
            return Ok(new
            {
                Message = "Profile deleted",
                Status = 200
            });
        }
    }
}