using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Domain.CommentAgg;
using Common.Query;

namespace Blog.Query.Comment.DTOs
{
    public class CommentDto : BaseDto
    {

        public long UserId { get; set; }
        public long PostId { get; set; }
        public string Text { get; set; }
        public CommentStatus Status { get; set; }
        public DateTime UpdateDate { get; set; }

    }
}
