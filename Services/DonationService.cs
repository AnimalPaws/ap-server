using ap_server.Entities;
using ap_server.Helpers;
using ap_server.Models.Donation;
using AutoMapper;

namespace ap_server.Services
{
    public interface IDonationService
    {
        IEnumerable<Donation> GetAll();
        Donation GetById(int id);
        void Create(DonationCreateRequest model);
        void Delete(int id);

    }
    public class DonationService : IDonationService
    {
        private DataContext _context;
        private readonly IMapper _mapper;

        public DonationService(
            DataContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<Donation> GetAll()
        {
            return _context.Donation;
        }

        public Donation GetById(int id)
        {
            return GetDonation(id);
        }

        public void Create(DonationCreateRequest model)
        {
            var custDateTime = DateNow();
            var donation = _mapper.Map<Donation>(model);
            donation.Created_At = custDateTime;
            _context.Donation.Add(donation);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var donation = GetDonation(id);
            _context.Donation.Remove(donation);
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
        private Donation GetDonation(int id)
        {
            var donation = _context.Donation.Find(id);
            if (donation == null) throw new KeyNotFoundException("Announcement not found");
            return donation;
        }
    }
}
