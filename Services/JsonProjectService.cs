using Lügavi.Models;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Lügavi.Services
{
    public class JsonProjectService
    {
        public JsonProjectService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }


        public string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "projects.json"); }
        }

        public IEnumerable<ProjectModel> GetProjects()
        {
            using var json = File.OpenText(JsonFileName);
            
            return JsonSerializer.Deserialize<ProjectModel[]>(json.ReadToEnd());
        }

        public void AddProject(ProjectModel newproject)
        {
            var projects = GetProjects();
            newproject.id = projects.Max(x => x.id) + 1;
            var temp = projects.ToList();
            temp.Add(newproject);
            IEnumerable<ProjectModel> updatedprojects = temp.ToArray();
            using var json = File.OpenWrite(JsonFileName);
            JsonSerializer.Serialize<IEnumerable<ProjectModel>>(
                new Utf8JsonWriter(json,new JsonWriterOptions { Indented=true}),updatedprojects);

        }

        public ProjectModel GetProjectById(int id)
        {
            var projects = GetProjects();
            ProjectModel query = projects.FirstOrDefault(x => x.id == id);
            return query;
        }
    }
}
