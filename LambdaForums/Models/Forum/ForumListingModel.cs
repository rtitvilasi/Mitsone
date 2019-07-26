﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LambdaForums.Models.Post;

namespace LambdaForums.Models.Forum
{
    public class ForumListingModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public IEnumerable<PostListingModel> Posts { get; internal set; }
        public ForumListingModel Forum { get; internal set; }
    }
}
