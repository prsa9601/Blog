using Blog.Infrastructure.Persistent.Ef;
using Blog.Query.Post.DTOs;
using Blog.Query.Role.DTOs;
using Common.Query;
using Microsoft.EntityFrameworkCore;

namespace Blog.Query.Post.GetBtId
{
    public class GetPostByIdQueryHandler : IQueryHandler<GetPostByIdQuery, PostDto>
    {
        private readonly BlogContext _context;

        public GetPostByIdQueryHandler(BlogContext context)
        {
            _context = context;
        }

        public async Task<PostDto> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
        {
            var post = await _context.Posts.FirstOrDefaultAsync(s => s.Id == request.postId);
           
            if (post == null) 
                return null;
            
            //return new PostDto()
            //{
            //    CategoryId = post.CategoryId,
            //    CreationDate = post.CreationDate,
            //    Description = post.Description,
            //    Id = post.Id,
            //    UserId = post.UserId,
            //    Slug = post.Slug,
            //    Title = post.Title,
            //    Visit = post.Visit,
            //    ImageName = post.ImageName,
            //    UserFullName = userFullName
            //};
            return post.Map(_context);
        }
    }
}
