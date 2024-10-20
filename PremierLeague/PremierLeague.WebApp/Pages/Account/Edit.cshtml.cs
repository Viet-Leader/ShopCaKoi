using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PremierLeague.Repositories.Entities;

namespace PremierLeague.WebApp.Pages.Account
{
    public class EditModel : PageModel
    {
        private readonly PremierLeague.Repositories.Entities.EnglishPremierLeague2024DbContext _context;

        public EditModel(PremierLeague.Repositories.Entities.EnglishPremierLeague2024DbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PremierLeagueAccount PremierLeagueAccount { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var premierleagueaccount =  await _context.PremierLeagueAccounts.FirstOrDefaultAsync(m => m.AccId == id);
            if (premierleagueaccount == null)
            {
                return NotFound();
            }
            PremierLeagueAccount = premierleagueaccount;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(PremierLeagueAccount).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PremierLeagueAccountExists(PremierLeagueAccount.AccId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PremierLeagueAccountExists(int id)
        {
            return _context.PremierLeagueAccounts.Any(e => e.AccId == id);
        }
    }
}
