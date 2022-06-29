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
        void Create(AnnounceCreateRequest model);
        void UpdateById(int id, AnnounceUpdateRequest model);
        void Update(AnnounceUpdateRequest model);
        void Delete(int id);

    }
    public class AnnounceService : IAnnouncementService
    {
        private DataContext _context;
        private readonly IMapper _mapper;

        public AnnounceService(
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

        public void Create(AnnounceCreateRequest model)
        {
            var announcement = _mapper.Map<Announcement>(model);
            announcement.Created_At = DateTime.Now;
            announcement.Likes = 0;
            _context.Announce.Add(announcement);
            _context.SaveChanges();
        }
        public void UpdateById(int id, AnnounceUpdateRequest model)
        {
            var announcement = GetAnnouncement(id);
            _mapper.Map(model, announcement);
            _context.Announce.Update(announcement);
            _context.SaveChanges();
        }

        public void Update(AnnounceUpdateRequest model)
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
