﻿using ap_server.Entities.User;
using ap_server.Helpers;
using ap_server.Models.Profile;
using AutoMapper;

namespace ap_server.Services
{
    public interface IProfileService
    {
        IEnumerable<User> GetAll();
        User GetById(int id);
        void Update(int id, UpdateRequest model);
        void Delete(int id);

    }
    public class ProfileService
    {
        public class AnnouncementService : IProfileService
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

            public IEnumerable<User> GetAll()
            {
                return _context.User;
            }

            public User GetById(int id)
            {
                return GetUser(id);
            }

            public void Update(int id, UpdateRequest model)
            {
                var user = GetUser(id);
                _mapper.Map(model, user);
                _context.User.Update(user);
                _context.SaveChanges();
            }

            public void Delete(int id)
            {
                var user = GetUser(id);
                _context.User.Remove(user);
                _context.SaveChanges();
            }

            // HELPER METHODS

            private User GetUser(int id)
            {
                var user = _context.User.Find(id);
                if (user == null) throw new KeyNotFoundException("Announcement not found");
                return user;
            }
        }
    }
}
