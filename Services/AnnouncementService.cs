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
        void UpdateById(int id, UpdateRequest model);
        void Update(UpdateRequest model);
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
            return _context.Announce;
        }

        public Announcement GetById(int id)
        {
            return GetAnnouncement(id);
        }

        public void Create(CreateRequest model)
        {
            var announcement = _mapper.Map<Announcement>(model);
            announcement.Likes = 0;
            _context.Announce.Add(announcement);
            _context.SaveChanges();
        }
        public void UpdateById(int id, UpdateRequest model)
        {
            var announcement = GetAnnouncement(id);
            _mapper.Map(model, announcement);
            _context.Announce.Update(announcement);
            _context.SaveChanges();
        }

        public void Update(UpdateRequest model)
        {
            var announcement = GetAll();
            _mapper.Map(model, announcement);
            _context.Announce.Update((Announcement)announcement);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var announcement = GetAnnouncement(id);
            _context.Announce.Remove(announcement);
            _context.SaveChanges();
        }

        // HELPER METHODS

        private Announcement GetAnnouncement(int id)
        {
            var announcement = _context.Announce.Find(id);
            if (announcement == null) throw new KeyNotFoundException("Announcement not found");
            return announcement;
        }
    }
}
