using ap_server.Entities.User;
using ap_server.Helpers;
using ap_server.Models.Profile;
using AutoMapper;

namespace ap_server.Services
{
    public interface IProfileService
    {
        IEnumerable<User> GetAll();
        User GetById(int id);
        void Update(int id, ProfileUpdateRequest model);
        void Delete(int id);

    }
    public class ProfileService : IProfileService
    {
        private DataContext _context;
        private readonly IMapper _mapper;

        public ProfileService(
            DataContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.user;
        }

        public User GetById(int id)
        {
            return GetUser(id);
        }

        public void Update(int id, ProfileUpdateRequest model)
        {
            var user = GetUser(id);
            _mapper.Map(model, user);
            _context.user.Update(user);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = GetUser(id);
            _context.user.Remove(user);
            _context.SaveChanges();
        }

        // HELPER METHODS

        private User GetUser(int id)
        {
            var user = _context.user.Find(id);
            if (user == null) throw new KeyNotFoundException("Announcement not found");
            return user;
        }
    }
}
