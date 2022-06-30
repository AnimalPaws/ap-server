using ap_server.Entities;
using ap_server.Helpers;
using ap_server.Models.Contract;
using AutoMapper;

namespace ap_server.Services
{
    public interface IContractService
    {
        IEnumerable<Contract> GetAll();
        Contract GetById(int id);
        void Create(ContractCreateRequest model);
        void Delete(int id);

    }
    public class ContractService : IContractService
    {
        private DataContext _context;
        private readonly IMapper _mapper;

        public ContractService(
            DataContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<Contract> GetAll()
        {
            return _context.Contract;
        }

        public Contract GetById(int id)
        {
            return GetContract(id);
        }

        public void Create(ContractCreateRequest model)
        {
            var custDateTime = DateNow();
            var contract = _mapper.Map<Contract>(model);
            contract.Created_At = custDateTime;
            _context.Contract.Add(contract);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var contract = GetContract(id);
            _context.Contract.Remove(contract);
            _context.SaveChanges();
        }

        // HELPER METHODS

        public static DateTime DateNow()
        {
            DateTime utcTime = DateTime.UtcNow;
            TimeZoneInfo myZone = TimeZoneInfo.CreateCustomTimeZone("COLOMBIA", new TimeSpan(-5, 0, 0), "Colombia", "Colombia");
            DateTime custDateTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, myZone);
            return custDateTime;
        }
        private Contract GetContract(int id)
        {
            var contract = _context.Contract.Find(id);
            if (contract == null) throw new KeyNotFoundException("Announcement not found");
            return contract;
        }
    }
}
