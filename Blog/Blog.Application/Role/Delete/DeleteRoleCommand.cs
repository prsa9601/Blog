using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Role.Delete
{
    public record class DeleteRoleCommand(long roleId):IBaseCommand;
}
