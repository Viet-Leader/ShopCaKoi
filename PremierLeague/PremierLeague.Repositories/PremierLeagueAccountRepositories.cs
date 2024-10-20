using Microsoft.EntityFrameworkCore;
using PremierLeague.Repositories.Entities;
using PremierLeague.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremierLeague.Repositories 
{
    public class PremierLeagueAccountRepositories : IPremierLeagueAccountRepositories
    {
        private readonly EnglishPremierLeague2024DbContext _context;
        public PremierLeagueAccountRepositories(EnglishPremierLeague2024DbContext _context) 
        {
            this._context = _context;
        }
        public async Task<List<PremierLeagueAccount>> GetAllPremierLeagueAccounts()
        {
           return await _context.PremierLeagueAccounts.ToListAsync();
        }
    }
}
