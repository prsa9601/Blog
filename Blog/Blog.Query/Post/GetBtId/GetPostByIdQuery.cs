using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Query.Post.DTOs;
using Common.Query;

namespace Blog.Query.Post.GetBtId
{
    public record class GetPostByIdQuery(long postId) : IQuery<PostDto?>;

}
