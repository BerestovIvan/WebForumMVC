﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebForumMVC.Configuration.Abstractions
{
    public interface IDbContextSeedData
    {
        public Task CreateAdmin();
    }
}