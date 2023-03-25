﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public interface ILoginRepository
    {
        bool DoesUserExists(string username, string password);
    }
}
