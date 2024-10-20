using PremierLeague.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremierLeague.Sevices.Interface
{
    public interface IPremierLeagueAccountSevices
    {
        Task<List<PremierLeagueAccount>> PremierLeagueAccounts();
    }
}
