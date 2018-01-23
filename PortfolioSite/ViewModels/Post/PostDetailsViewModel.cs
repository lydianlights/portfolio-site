using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PortfolioSite.Models;

namespace PortfolioSite.ViewModels.Post
{
    public class PostDetailsViewModel
    {
        public BlogPost ThisPost { get; set; } = new BlogPost();
        public BlogPostComment NewComment { get; set; } = new BlogPostComment();
    }
}
