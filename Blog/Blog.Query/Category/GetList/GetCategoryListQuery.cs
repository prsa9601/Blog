using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Query.Category.DTOs;
using Common.Query;

namespace Blog.Query.Category.GetList
{
    public record class GetCategoryListQuery:IQuery<List<CategoryDto?>>;

}
