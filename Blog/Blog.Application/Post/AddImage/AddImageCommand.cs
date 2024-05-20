using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Application;
using Microsoft.AspNetCore.Http;

namespace Blog.Application.Post.AddImage
{
    public class AddImageCommand : IBaseCommand
    {
        public IFormFile ImageFile { get; set; }
        public long PostId { get; set; }
        //public int Sequence { get; set; }
    }
}
