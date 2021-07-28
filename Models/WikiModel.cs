using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lügavi.Models
{
    public class WikiModel
    {
        public string batchcomplete { get; set; }
        public Query query { get; set; }

    }
    public class Query
    {
        public Dictionary<string, pageval> pages { get; set; }

    }
    public class pageval
    {
        public int pageid { get; set; }
        public int ns { get; set; }
        public string title { get; set; }
        public string extract { get; set; }
    }
}
