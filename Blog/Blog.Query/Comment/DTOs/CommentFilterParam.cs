using Blog.Domain.CommentAgg;
using Common.Query.Filter;

namespace Blog.Query.Comment.DTOs;

public class CommentFilterParam : BaseFilterParam
{
    public long? UserId { get; set; }
    public long? PostId { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public CommentStatus? CommentStatus { get; set; }
    public OrderBy? OrderBy { get; set; }
 
}  
public class CommentFilterParamProduct : BaseFilterParam
{
    public long? PostId { get; set; }
 
}  
public enum OrderBy
{
    Latest,
}