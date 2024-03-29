﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LambdaForums.Data.Models;

namespace LambdaForums.Data
{
    public interface IForum
    {
        Forum GetById(int id);
        IEnumerable<Forum> GetAll();
        IEnumerable<ApplicationUser> GetAllActiveUsers();

        Task Create(Forum forum);
        Task Delete(int forumid);
        Task UpdateForumTitle(int forumid, string newTitle);
        Task UpdateForumDescription(int forumid, string newDescription);
    }
}
