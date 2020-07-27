using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StayFitGym.Model;

namespace StayFitGym
{
    public class RegisterModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public RegisterModel(ApplicationDbContext db)
        {
            _db = db;
        }
     
        [BindProperty]
        public UserDetails UserDetailsForRegistration { get; set; }

    
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _db.UserDetails.AddAsync(UserDetailsForRegistration);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
            
        }
    }
}