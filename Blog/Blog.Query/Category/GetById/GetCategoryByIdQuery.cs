using Blog.Query.Category.DTOs;
using Common.Query;

namespace Blog.Query.Category.GetById;

public record GetCategoryByIdQuery(long CategoryId) : IQuery<CategoryDto>;