using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lügavi.Models;
using Lügavi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Lügavi.Pages.Listele
{
    public class ListeleModel : PageModel
    {
        private readonly ILogger<ListeleModel> _logger;
        public JsonKelimeService JsonKService;

        public IEnumerable<KelimeModel> Kelimeler;

        [BindProperty(SupportsGet = true)]
        public string kelimeAd { get; set; }

        [BindProperty(SupportsGet = true)]
        public int Status { get; set; }
        public ListeleModel(ILogger<ListeleModel> logger, JsonKelimeService jsonkservice)
        {
            _logger = logger;
            JsonKService = jsonkservice;
        }

        public void OnGet()
        {
            Kelimeler = JsonKService.GetKelimeler();
        }

        public void OnPost()
        {

        }
    }
}
