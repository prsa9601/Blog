using Blog.Query.Category.DTOs;
using Common.Query;


namespace Blog.Query.Category.GetList;

public record GetCategoryListQuery:IQuery<List<CategoryDto>>;