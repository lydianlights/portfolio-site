using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioSite.Data;
using PortfolioSite.Models;
using PortfolioSite.ViewModels.Post;

namespace PortfolioSite.Controllers
{
    public class PostController : Controller
    {
        private readonly ApplicationDbContext _db;

        public PostController(ApplicationDbContext db)
        {
            _db = db;
        }

        [Route("/posts")]
        public IActionResult Index()
        {
            List<BlogPost> model =_db.BlogPosts.ToList();
            return View(model);
        }

        [Route("/posts/{postId}")]
        public IActionResult PostDetails(int postId)
        {
            var model = new PostDetailsViewModel();
            model.ThisPost = _db.BlogPosts
                .Include(m => m.Comments)
                .FirstOrDefault(m => m.Id == postId);
            return View(model);
        }

        [Route("/posts/add")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost, Route("/posts/add")]
        public IActionResult Add(BlogPost newPost)
        {
            _db.BlogPosts.Add(newPost);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
