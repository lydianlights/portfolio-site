using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PortfolioSite.Data;
using PortfolioSite.Models;

namespace PortfolioSite.Controllers
{
    public class HomeController : Controller
    {
        // TODO: Find a way to load rest of page while waiting for async api call
        [Route("/")]
        public async Task<IActionResult> Index()
        {
            List<Repo> model = await GithubApiContext.GetMyTop3StarredAsync();
            return View(model);
        }
    }
}
