using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ap_server.Models.Contract;
using ap_server.Services;

namespace ap_server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContractController : Controller
    {
        private IContractService _contractService;
        private IMapper _mapper;

        public ContractController(
            IContractService contractService,
            IMapper mapper)
        {
            _contractService = contractService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var contract = _contractService.GetAll();
            return Ok(contract);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var contract = _contractService.GetById(id);
            return Ok(contract);
        }

        [HttpPost]
        public IActionResult Create(ContractCreateRequest model)
        {
            _contractService.Create(model);
            return Ok(new
            {
                message = "Contract created",
                Status = 200
            });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _contractService.Delete(id);
            return Ok(new
            {
                Message = "Contract deleted",
                Status = 200
            });
        }
    }
}
