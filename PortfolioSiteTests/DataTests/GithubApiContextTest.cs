using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using PortfolioSite.Data;
using PortfolioSite.Models;
using System.Threading.Tasks;

namespace PortfolioSiteTests.DataTests
{
    [TestClass]
    public class GithubApiContextTest
    {
        [TestMethod]
        public async Task GetMyTop3StarredAsync_GetsTop3Repos_Repos()
        {
            List<Repo> results = await GithubApiContext.GetMyTop3StarredAsync();

            // Log the top 3 results since they are potentially hard to directly test
            foreach (Repo repo in results)
            {
                Console.WriteLine($"Repo: {repo.Name}");
                Console.WriteLine($"URL: {repo.Html_Url}");
                Console.WriteLine($"Updated: {repo.Updated_At}");
                Console.WriteLine($"Language: {repo.Language}");
                Console.WriteLine($"Stars: {repo.Stargazers_Count}");
                Console.WriteLine("");
            }

            Assert.AreEqual(3, results.Count);
        }
    }
}
