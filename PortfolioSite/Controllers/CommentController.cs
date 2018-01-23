using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PortfolioSite.Data;
using PortfolioSite.Models;
using PortfolioSite.ViewModels.Post;

namespace PortfolioSite.Controllers
{
    public class CommentController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CommentController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpPost, Route("/posts/{postId}/comments/add")]
        public IActionResult AddCommentToPost(PostDetailsViewModel model)
        {
            model.NewComment.ParentBlogPost = _db.BlogPosts.FirstOrDefault(p => p.Id == model.NewComment.ParentBlogPost.Id);
            _db.BlogPostComments.Add(model.NewComment);
            _db.SaveChanges();
            return RedirectToAction("PostDetails", "Post", new { model.NewComment.ParentBlogPost.Id });
        }
    }
}
