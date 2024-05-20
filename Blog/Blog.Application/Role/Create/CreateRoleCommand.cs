using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Domain.RoleAgg.Enums;
using Common.Application;

namespace Blog.Application.Role.Create
{
    public record CreateRoleCommand(string Title, List<Permission> Permissions) : IBaseCommand;

}
