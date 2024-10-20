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
    public class IndexModel : PageModel
    {
        private readonly PremierLeague.Repositories.Entities.EnglishPremierLeague2024DbContext _context;

        public IndexModel(PremierLeague.Repositories.Entities.EnglishPremierLeague2024DbContext context)
        {
            _context = context;
        }

        public IList<PremierLeagueAccount> PremierLeagueAccount { get;set; } = default!;

        public async Task OnGetAsync()
        {
            PremierLeagueAccount = await _context.PremierLeagueAccounts.ToListAsync();
        }
    }
}
