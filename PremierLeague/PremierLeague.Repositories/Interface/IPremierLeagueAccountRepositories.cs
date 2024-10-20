using PremierLeague.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremierLeague.Repositories.Interface
{
    public interface IPremierLeagueAccountRepositories
    {
        Task<List<PremierLeagueAccount>> GetAllPremierLeagueAccounts();
    }
}
