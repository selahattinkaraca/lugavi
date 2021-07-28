using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lügavi.Models;
using Lügavi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lügavi.Pages.Users
{
    public class AdminModel : PageModel
    {
        public JsonProjectService JsonProjectService;
        public AdminModel(JsonProjectService jsonprojectservice)
        {
            JsonProjectService = jsonprojectservice;

        }

        [BindProperty]
        public ProjectModel Proje { get; set; }
        public void OnGet()
        {

        }
        public IActionResult OnPostForm()
        {
            JsonProjectService.AddProject(Proje);
            return RedirectToPage("/Index", new {  Status=true });
        }
        public void OnPostGetProjectByID()
        {
            Proje = JsonProjectService.GetProjectById(Proje.id);

        }

    }
}
