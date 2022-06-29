using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ap_server.Models.Adoption;
using ap_server.Services;

namespace ap_server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdoptionController : Controller
    {
        private IAdoptionService _adoptionService;
        private IMapper _mapper;

        public AdoptionController(
            IAdoptionService adoptionService,
            IMapper mapper)
        {
            _adoptionService = adoptionService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var announcements = _adoptionService.GetAll();
            return Ok(announcements);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var announcements = _adoptionService.GetById(id);
            return Ok(announcements);
        }

        [HttpPost]
        public IActionResult Create(AdoptionCreateRequest model)
        {
            _adoptionService.Create(model);
            return Ok(new
            {
                message = "Announcement created",
                Status = 200
            });
        }

        [HttpPut("{id}")]
        public IActionResult UpdateById(int id, AdoptionUpdateRequest model)
        {
            _adoptionService.UpdateById(id, model);
            return Ok(new
            {
                message = "Announcement updated",
                Status = 200
            });
        }

        [HttpPut]
        public IActionResult Update(AdoptionUpdateRequest model)
        {
            _adoptionService.Update(model);
            return Ok(new
            {
                message = "Announcement updated",
                Status = 200
            });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _adoptionService.Delete(id);
            return Ok(new
            {
                Message = "Announcement deleted",
                Status = 200
            });
        }
    }
}
