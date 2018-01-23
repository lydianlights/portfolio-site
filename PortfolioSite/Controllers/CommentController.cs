using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PortfolioSite.Data;

namespace PortfolioSite.Controllers
{
    public class CommentController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CommentController(ApplicationDbContext db)
        {
            _db = db;
        }

        [Route("/posts/{postId}/comments")]
        public IActionResult GetCommentsForPost(int postId)
        {
            return View();
        }

        [HttpPost, Route("/posts/{postId}/comments/add")]
        public IActionResult AddCommentToPost(int postId)
        {
            return View();
        }
    }
}
