﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Application;

namespace Blog.Application.User.RemoveToken
{
    public record RemoveUserTokenCommand(long UserId, long TokenId) : IBaseCommand<string>;

}
