using AutoMapper;
using WebForum.Data.Models;
using WebForum.Models;

namespace WebForum.AutoMapper.Profiles
{
    public class ForumMappingProfile : Profile
    {
        public ForumMappingProfile()
        {
            CreateMap<Forum, ForumListingModel>();
        }
    }
}
