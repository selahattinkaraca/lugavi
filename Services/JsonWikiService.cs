using Lügavi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace Lügavi.Services
{
    public class JsonWikiService
    {
        public WikiModel GetWikiModel(string term)
        { 
            string url = string.Concat("https://tr.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&redirects=1&titles=",term);
            string json = new WebClient().DownloadString(url);
            return JsonSerializer.Deserialize<WikiModel>(json);
        }
    }
}
