using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using StayFitGym.Model;

namespace StayFitGym.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public UserDetails UserDetails { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
         
               var validUser = await _db.UserDetails.FindAsync(UserDetails.UserID);
             
                if(validUser != null && validUser.Password.Equals(UserDetails.Password))
                {
                    TempData["CurrentUserName"] = UserDetails.UserID;
                    return RedirectToPage("Welcome");
                }
                else
                {
                TempData["error"] = "Invalid Password";
                    return Page();
                }
               
          
        }
    }
}
