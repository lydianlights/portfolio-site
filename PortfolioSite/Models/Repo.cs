using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioSite.Models
{
    public class Repo
    {
        public string Name { get; set; }
        public string Html_Url { get; set; }
        public int Stargazers_Count { get; set; }
        public DateTime Updated_At { get; set; }
        public string Language { get; set; }
    }
}