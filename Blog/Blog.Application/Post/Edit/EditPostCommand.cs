using Common.Application;
using Microsoft.AspNetCore.Http;


namespace Blog.Application.Post.Edit
{
    public class EditPostCommand : IBaseCommand
    {
        //public EditPostCommand(long categoryId, IFormFile imageFile, string title, string slug, string description, long id)
        //{
        //    CategoryId = categoryId;
        //    ImageFile = imageFile;
        //    Title = title;
        //    Slug = slug;
        //    Description = description;
        //    Id = id;
        //}
        public long Id { get; set; }
        public IFormFile ImageFile { get; set; }
        public long CategoryId { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public string MetaDescription { get; set; }

    }
}
