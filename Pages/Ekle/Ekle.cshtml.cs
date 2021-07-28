using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lügavi.Models;
using Lügavi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lügavi.Pages.Ekle
{
    public class EkleModel : PageModel
    {
        public JsonKelimeService JsonKelimeService;
        public EkleModel(JsonKelimeService jsonkelimeservice)
        {
            JsonKelimeService = jsonkelimeservice;
        }

        [BindProperty]
        public KelimeModel Kelime { get; set; }

        public void OnGet()
        {
            
        }

        public IActionResult OnPost()
        {
            JsonKelimeService.AddKelime(Kelime);
            return RedirectToPage("/Index", new { Status = 1 });
        }
    }
}
