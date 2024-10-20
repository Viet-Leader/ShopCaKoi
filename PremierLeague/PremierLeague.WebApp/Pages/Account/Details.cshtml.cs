using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PremierLeague.Repositories.Entities;

namespace PremierLeague.WebApp.Pages.Account
{
    public class DetailsModel : PageModel
    {
        private readonly PremierLeague.Repositories.Entities.EnglishPremierLeague2024DbContext _context;

        public DetailsModel(PremierLeague.Repositories.Entities.EnglishPremierLeague2024DbContext context)
        {
            _context = context;
        }

        public PremierLeagueAccount PremierLeagueAccount { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var premierleagueaccount = await _context.PremierLeagueAccounts.FirstOrDefaultAsync(m => m.AccId == id);
            if (premierleagueaccount == null)
            {
                return NotFound();
            }
            else
            {
                PremierLeagueAccount = premierleagueaccount;
            }
            return Page();
        }
    }
}
