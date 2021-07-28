using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lügavi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lügavi.Pages.Users
{
    public class SignupModel : PageModel
    {
        [BindProperty]
        public UserModel Kullanici { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("/Index",new { Name = Kullanici.Ad, Surname = Kullanici.Soyad });
        }
    }
}
