﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Application.Common.Interfaces
{
    public interface ICurrentUserService
    {
        string UserId { get; }
        bool IsAuthenticated { get; }
    }
}
