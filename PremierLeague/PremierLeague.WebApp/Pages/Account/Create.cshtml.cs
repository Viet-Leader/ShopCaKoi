using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PremierLeague.Repositories.Entities;

namespace PremierLeague.WebApp.Pages.Account
{
    public class CreateModel : PageModel
    {
        private readonly PremierLeague.Repositories.Entities.EnglishPremierLeague2024DbContext _context;

        public CreateModel(PremierLeague.Repositories.Entities.EnglishPremierLeague2024DbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public PremierLeagueAccount PremierLeagueAccount { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.PremierLeagueAccounts.Add(PremierLeagueAccount);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
