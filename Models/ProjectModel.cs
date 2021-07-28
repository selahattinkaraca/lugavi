using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Lügavi.Models
{
    public class ProjectModel
    {
        public int id { get; set; }
        public int teamId { get; set; }
        public string projectName { get; set; }
        public string projectDescription { get; set; }
        public string[] members { get; set; }

        [JsonPropertyName("img")]
        public string image { get; set; }
        public string url { get; set; }

    }
}
