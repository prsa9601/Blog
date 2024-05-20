
using Common.Query;

namespace Blog.Query.Post.DTOs
{
    public class PostDto : BaseDto
    {
        public long UserId { get; set; }
        public string UserFullName { get; set; }
      //  public string CategoryTitle { get; set; }       
        public long CategoryId { get; set; }
        public string Title { get; set; }
        public string ImageName { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public string MetaDescription { get; set; }
        public int Visit { get; set; }

    }
}
