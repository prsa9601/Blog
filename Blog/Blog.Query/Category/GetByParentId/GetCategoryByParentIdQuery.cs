using Blog.Query.Category.DTOs;
using Common.Query;

namespace Blog.Query.Category.GetByParentId;

public record GetCategoryByParentIdQuery(long ParentId) : IQuery<List<ChildCategoryDto>>;