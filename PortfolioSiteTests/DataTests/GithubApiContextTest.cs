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

            Assert.AreEqual(3, results.Count);
        }
    }
}
