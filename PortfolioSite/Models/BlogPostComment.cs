using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortfolioSite.Models
{
    [Table("BlogPostComments")]
    public class BlogPostComment
    {
        [Key]
        public int Id { get; set; }
        public string Author { get; set; }
        public string Body { get; set; }
        [ForeignKey("BlogPostId")]
        public virtual BlogPost ParentBlogPost { get; set; }
    }
}
