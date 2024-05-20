using Common.Query.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Query.Role.DTOs
{
    public class RoleFilterParam : BaseFilterParam
    {
        public string? Title { get; set; }
    }
}
