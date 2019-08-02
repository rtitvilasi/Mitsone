using LambdaForums.Data;
using LambdaForums.Data.Models;
using LambdaForums.Models.Forum;
using LambdaForums.Models.Post;
using LambdaForums.Models.Search;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LambdaForums.Controllers
{
    public class SearchController : Controller
    {
        private readonly IPost _postService;
        private IEnumerable<PostListingModel> postListings;

        public SearchController(IPost postService)
        {
            _postService = postService;
        }

        public IActionResult Results(string searchQuery)
        {
            var posts = _postService.GetFilteredPosts(searchQuery);
            var areNoResults = (!string.IsNullOrEmpty(searchQuery) && !posts.Any()); 

            var postListingModel = posts.Select(post => new PostListingModel
            {
                Id = post.Id,
                AuthorId=post.User.Id,
                AuthorName=post.User.UserName,
                AuthorRating=post.User.Rating,
                Title=post.Title,
                DatePosted=post.Created.ToString(),
                RepliesCount=post.Replies.Count(),
                Forum=BuildForumListing(post)
            });
            var model = new SearchResultModel
            {
                Posts = postListingModel,
                SearchQuery = searchQuery,
                EmptySearchResults = areNoResults
            };
            return View(model);
        }

        private ForumListingModel BuildForumListing(Post post)
        {
                var forum = post.Forum;
            return new ForumListingModel
            {
                Id = forum.Id,
                ImageUrl=forum.ImageUrl,
                Name=forum.Title,
                Description=forum.Description
            };
  
        }

        [HttpPost]
        public IActionResult Search(string searchQuery)
        {
            return RedirectToAction("Results",new{searchQuery});
        }
    }
}
