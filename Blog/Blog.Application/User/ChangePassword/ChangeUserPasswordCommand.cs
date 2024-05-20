using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Application;

namespace Blog.Application.User.ChangePassword
{
    public class ChangeUserPasswordCommand : IBaseCommand
    {
        public long UserId { get; set; }
        public string CurrentPassword { get; set; }
        public string Password { get; set; }
    }
}
