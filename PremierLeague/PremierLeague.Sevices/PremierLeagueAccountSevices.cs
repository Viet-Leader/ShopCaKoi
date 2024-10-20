using PremierLeague.Repositories;
using PremierLeague.Repositories.Entities;
using PremierLeague.Sevices.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremierLeague.Sevices
{
    public class PremierLeagueAccountSevices : IPremierLeagueAccountSevices
    {
        private readonly PremierLeagueAccountRepositories _repository;
        public PremierLeagueAccountSevices(PremierLeagueAccountRepositories _repository) 
        {
            this._repository = _repository;
        }

        public Task<List<PremierLeagueAccount>> PremierLeagueAccounts()
        {
            return _repository.GetAllPremierLeagueAccounts();
        }
    }
}
