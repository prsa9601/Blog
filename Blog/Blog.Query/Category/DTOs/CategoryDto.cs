using Common.Query;

namespace Blog.Query.Category.DTOs
{
    public class CategoryDto : BaseDto
    {
        public string Title { get; set; }
        public string MetaTag { get; set; }
        public string MetaDescription { get; set; }
        public string Slug { get; set; }

    }
    public class CategoryForShopDto : BaseDto
    {
        public string Title { get; set; }
        public string MetaTag { get; set; }
        public string MetaDescription { get; set; }
        public string Slug { get; set; }
        public List<PostCategoryDto> posts { get; set; }

    }
    public class PostCategoryDto : BaseDto
    {
        public long UserId { get; set; }
        public string UserFullName { get; set; }
        //  public string CategoryTitle { get; set; }       
        public long CategoryId { get; set; }
        public string Title { get; set; }
        public string ImageName { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public int Visit { get; set; }

    }
}
