using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using PortfolioSite.Models;


namespace PortfolioSite.Data
{
    public static class GithubApiContext
    {
        private const string apiUrl = "https://api.github.com";
        private const string acceptHeader = "application/vnd.github.v3+json";
        private const string myUserName = "ranefields";

        public static async Task<List<Repo>> GetMyTop3StarredAsync()
        {
            var client = new RestClient(apiUrl);
            var request = new RestRequest("/search/repositories", Method.GET);
            request.AddHeader("Accept", acceptHeader);
            request.AddParameter("q", $"user:{myUserName} fork:true");
            request.AddParameter("sort", "stars");
            request.AddParameter("order", "desc");

            var response = await GetResponseAsync(client, request) as RestResponse;
            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response.Content);
            IQueryable<Repo> repoResults = JsonConvert.DeserializeObject<List<Repo>>(jsonResponse["items"].ToString()).AsQueryable();

            List<Repo> top3Repos = repoResults.Take(3).ToList();
            return top3Repos;
        }

        private static Task<IRestResponse> GetResponseAsync(RestClient client, RestRequest request)
        {
            var tcs = new TaskCompletionSource<IRestResponse>();
            client.ExecuteAsync(request, response => {
                tcs.SetResult(response);
            });
            return tcs.Task;
        }
    }
}
