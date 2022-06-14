using ap_server.Entities;
using ap_server.Entities.User;
using ap_server.Models.Announcement;
using AutoMapper;

namespace ap_server.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // CreateRequest -> Announcement
            this.CreateMap<CreateRequest, Announcement>().ReverseMap();

            // UpdateRequest -> Announcement
            this.CreateMap<UpdateRequest, Announcement>()
                .ForAllMembers(x => x.Condition(
                    (src, dest, prop) =>
                    {
                        // ignore null & empty string properties
                        if (prop == null) return false;
                        if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                        return true;
                    }
                ));
        }
    }
}
