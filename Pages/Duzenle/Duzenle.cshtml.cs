using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lügavi.Models;
using Lügavi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lügavi.Pages.Duzenle
{
    public class DuzenleModel : PageModel
    {
        public JsonKelimeService JsonKelimeService;
        public DuzenleModel(JsonKelimeService jsonkelimeservice)
        {
            JsonKelimeService = jsonkelimeservice;
        }

        [BindProperty]
        public KelimeModel Kelime { get; set; }
        public void OnGet()
        {
        }

        public void OnPostForm()
        {
            
            
        }

        public IActionResult OnPostSilKelimeByName()
        {
            var kelimeler = JsonKelimeService.GetKelimeler();
            KelimeModel query = kelimeler.FirstOrDefault(x => x.KelimeAdi == Kelime.KelimeAdi);
            if(query==null)
            {
                return RedirectToPage("/Index", new { Status = 4 });

            }
            else
            {
                JsonKelimeService.SilKelime(Kelime.KelimeAdi);
                return RedirectToPage("/Index", new { Status = 2 });
            }
            
            
        }

        public IActionResult OnPostUpdateKelime()
        {
            JsonKelimeService.UpdateKelime(Kelime);
            return RedirectToPage("/Index", new { Status = 3 });
        }

        public void OnPostGetKelimeByName()
        {
            Kelime = JsonKelimeService.GetKelimeByName(Kelime.KelimeAdi);
        }
    }
}
