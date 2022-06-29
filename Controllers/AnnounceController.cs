using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ap_server.Models.Announcement;
using ap_server.Services;

namespace ap_server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnnounceController : Controller
    {
        private IAnnouncementService _announcementService;
        private IMapper _mapper;

        public AnnounceController(
            IAnnouncementService announcementService,
            IMapper mapper)
        {
            _announcementService = announcementService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var announcements = _announcementService.GetAll();
            return Ok(announcements);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var announcements = _announcementService.GetById(id);
            return Ok(announcements);
        }

        [HttpPost]
        public IActionResult Create(AnnounceCreateRequest model)
        {
            _announcementService.Create(model);
            return Ok(new { 
                message = "Announcement created", 
                Status = 200
            });
        }

        [HttpPut("{id}")]
        public IActionResult UpdateById(int id, AnnounceUpdateRequest model)
        {
            _announcementService.UpdateById(id, model);
            return Ok(new
            {
                message = "Announcement updated",
                Status = 200
            });
        }

        [HttpPut]
        public IActionResult Update(AnnounceUpdateRequest model)
        {
            _announcementService.Update(model);
            return Ok(new
            {
                message = "Announcement updated",
                Status = 200
            });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _announcementService.Delete(id);
            return Ok(new
            {
                Message = "Announcement deleted",
                Status = 200
            });
        }
    }
}
