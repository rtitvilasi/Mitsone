﻿using LambdaForums.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LambdaForums.Data
{
    public interface IApplicationUser
    {
        ApplicationUser GetById(string id);
        IEnumerable<ApplicationUser> GetAll();
        

        Task UpdateUserRating(string id, Type type);
        Task SetProfileImage(string id, Uri uri);

    }
}
