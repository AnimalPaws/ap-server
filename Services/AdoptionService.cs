using ap_server.Entities;
using ap_server.Helpers;
using ap_server.Models.Adoption;
using AutoMapper;

namespace ap_server.Services
{
    public interface IAdoptionService
    {
        IEnumerable<Adoption> GetAll();
        Adoption GetById(int id);
        void Create(AdoptionCreateRequest model);
        void UpdateById(int id, AdoptionUpdateRequest model);
        void Update(AdoptionUpdateRequest model);
        void Delete(int id);

    }
    public class AdoptionService : IAdoptionService
    {
        private DataContext _context;
        private readonly IMapper _mapper;

        public AdoptionService(
            DataContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<Adoption> GetAll()
        {
            return _context.Adoption;
        }

        public Adoption GetById(int id)
        {
            return GetAdoption(id);
        }

        public void Create(AdoptionCreateRequest model)
        {
            var adoption = _mapper.Map<Adoption>(model);
            adoption.Created_At = DateNow();
            adoption.Likes = 0;
            _context.Adoption.Add(adoption);
            _context.SaveChanges();
        }
        public void UpdateById(int id, AdoptionUpdateRequest model)
        {
            var adoption = GetAdoption(id);
            _mapper.Map(model, adoption);
            _context.Adoption.Update(adoption);
            _context.SaveChanges();
        }

        public void Update(AdoptionUpdateRequest model)
        {
            var adoption = GetAll();
            _mapper.Map(model, adoption);
            _context.Adoption.Update((Adoption)adoption);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var adoption = GetAdoption(id);
            _context.Adoption.Remove(adoption);
            _context.SaveChanges();
        }

        // HELPER METHODS

        private Adoption GetAdoption(int id)
        {
            var adoption = _context.Adoption.Find(id);
            if (adoption == null) throw new KeyNotFoundException("Adoption not found");
            return adoption;
        }

        public static DateTime DateNow()
        {
            DateTime utcTime = DateTime.UtcNow;
            TimeZoneInfo myZone = TimeZoneInfo.CreateCustomTimeZone("COLOMBIA", new TimeSpan(-5, 0, 0), "Colombia", "Colombia");
            DateTime custDateTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, myZone);
            return custDateTime;
        }
    }
}
