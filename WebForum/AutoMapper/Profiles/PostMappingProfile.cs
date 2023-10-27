using AutoMapper;
using WebForum.Data.Models;
using WebForum.Models;

namespace WebForum.AutoMapper.Profiles
{
    public class PostMappingProfile : Profile
    {
        public PostMappingProfile()
        {
            CreateMap<Post, PostListingModel>()
                .ForMember(pm => pm.AuthorName, o => o
                    .MapFrom(p => p.User.UserName))
                .ForMember(pm => pm.AuthorRating, o => o
                    .MapFrom(p => p.User.Rating))
                .ForMember(pm => pm.AuthorId, o => o
                    .MapFrom(p => p.User.Id))
                .ForMember(pm => pm.DatePosted, o => o
                    .MapFrom(p => p.Created))
                .ForMember(pm => pm.RepliesCount, o => o
                    .MapFrom(p => p.Replies.Count()));

            CreateMap<Post, PostIndexModel>()
                .ConvertUsing<PostIndexModelConverter>();

            CreateMap<PostReply, PostReplyModel>()
                .ForMember(rm => rm.AuthorName, o => o
                    .MapFrom(r => r.User.UserName))
                .ForMember(rm => rm.AuthorRating, o => o
                    .MapFrom(r => r.User.Rating))
                .ForMember(rm => rm.AuthorId, o => o
                    .MapFrom(r => r.User.Id))
                .ForMember(rm=>rm.AuthorImageUrl,o=>o
                    .MapFrom(p=>p.User.ProfileImageUrl))
                .ForMember(rm => rm.ReplyContent, o => o
                    .MapFrom(p => p.Content))
                .ForMember(rm=>rm.PostId,o=>o
                    .MapFrom(r=> r.Id));

        }

        public class PostIndexModelConverter : ITypeConverter<Post, PostIndexModel>
        {
            public PostIndexModel Convert(Post source, PostIndexModel destination, ResolutionContext context)
            {
                destination = new PostIndexModel
                {
                    AuthorName = source.User.UserName,
                    AuthorRating = source.User.Rating,
                    AuthorId = source.User.Id,
                    AuthorImageUrl = source.User.ProfileImageUrl,
                    PostContent = source.Content,
                    Created = source.Created,
                    Title = source.Title,
                    Replies = source.Replies.Select(r => new PostReplyModel()
                    {
                        AuthorName = r.User.UserName,
                        AuthorRating = r.User.Rating,
                        AuthorId = r.User.Id,
                        AuthorImageUrl = r.User.ProfileImageUrl,
                        ReplyContent = r.Content,
                        PostId = r.Post.Id
                    })
                };
                return destination;
            }
        }
    }
}