using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StayFitGym.Model;

namespace StayFitGym
{
    public class WelcomeModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public WelcomeModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Membership UserMembership { get; set; }

      
        public async Task OnGet(string Userid)
        {
            UserMembership = await _db.Membership.FindAsync(Userid);
        }

        public async Task<IActionResult> OnPost()
        {
                UserMembership.Location = Request.Form["Location"];
                UserMembership.Plan = Request.Form["Plan"];
                UserMembership.Payment = Request.Form["Payment"];
                UserMembership.Summary = SummaryForUser();
                TempData["Summary"] = SummaryForUser();


                await _db.Membership.AddAsync(UserMembership);
                await _db.SaveChangesAsync();
                return RedirectToPage("Terms_Conditions");
        }

        public string SummaryForUser()
        {
            string summary;
            if (UserMembership.Plan.ToString() == "DailyPass")
            {
                summary = "$9.99";
            }
            else if(UserMembership.Plan.ToString() == "Monthly")
            {
                summary = "$49.99";
            }
            else
            {
                summary = "$149.99";
            }

            return summary;
        }
    }
}