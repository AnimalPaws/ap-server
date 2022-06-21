using ap_server.Entities;
using ap_server.Helpers;
using ap_server.Models.Announcement;
using AutoMapper;

namespace ap_server.Services
{
    public interface IAnnouncementService
    {
        IEnumerable<Announcement> GetAll();
        Announcement GetById(int id);
        void Create(CreateRequest model);
        void Update(int id, UpdateRequest model);
        void Delete(int id);

    }
    public class AnnouncementService : IAnnouncementService
    {
        private DataContext _context;
        private readonly IMapper _mapper;

        public AnnouncementService(
            DataContext context, 
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<Announcement> GetAll()
        {
            return _context.announce;
        }

        public Announcement GetById(int id)
        {
            return GetAnnouncement(id);
        }

        public void Create(CreateRequest model)
        {
            var announcement = _mapper.Map<Announcement>(model);
            _context.announce.Add(announcement);
            _context.SaveChanges();
        }
        public void Update(int id, UpdateRequest model)
        {
            var announcement = GetAnnouncement(id);
            _mapper.Map(model, announcement);
            _context.announce.Update(announcement);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var announcement = GetAnnouncement(id);
            _context.announce.Remove(announcement);
            _context.SaveChanges();
        }

        // HELPER METHODS

        private Announcement GetAnnouncement(int id)
        {
            var announcement = _context.announce.Find(id);
            if (announcement == null) throw new KeyNotFoundException("Announcement not found");
            return announcement;
        }
    }
}
