using Invilla.Data.Context;
using Invilla.Domain.Entity;
using Invilla.Domain.Model;
using Invilla.Domain.Service;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryInvilla.Invilla.Service.Services
{
    public class ServiceLoans : IServiceLoans
    {

        private InvillaContext _invillaContext;

        public async Task<IEnumerable<LoanViewModel>> Get()
        {

            _invillaContext = new InvillaContext();
            var lista = _invillaContext.Loans.Select(x =>
                new LoanViewModel()
                {
                    Friend = _invillaContext.Friends.Where(y => y.Id == x.Friend.Id).FirstOrDefault().FullName,
                    Game = _invillaContext.Games.Where(y => y.Id == x.Game.Id).FirstOrDefault().FullGameName, 
                    Id = x.Id,
                    LoanDateBegin = x.LoanDateBegin,
                    LoanDateEnd = x.LoanDateEnd
                }
            ).ToList();                                                          

            return lista;

        }

        public async Task<bool> Post(LoanViewModel model)
        {
            _invillaContext = new InvillaContext();

            try
            {

                foreach (var game in model.IdGame)
                {

                    if (await GetLoanGameById((long)game))
                    {
                        return false;
   
                    }

                    var loans = new LoansEntity
                    {
                        IdFriend = (long)model.IdFriend.FirstOrDefault(),
                        IdGames =  (long)game,
                        LoanDateBegin = (DateTime)model.LoanDateBegin
                    };

                    //Set Game Loaned
                    var gameDB = _invillaContext.Games.Select(x => x).Where(x => x.Id == game).FirstOrDefault();
                    gameDB.Loaned = true;

                    _invillaContext.Update(gameDB);
                    _invillaContext.Add(loans);
                    _invillaContext.SaveChanges();

                }

                return true;


            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Put(long id, JObject json)
        {

            try
            {

                _invillaContext = new InvillaContext();

                var model = JsonConvert.DeserializeObject<LoanViewModel>(json.ToString());

                if (model.LoanDateEnd == null)
                {
                    return false;
                }

                var loanDB = _invillaContext.Loans.Select(x => x).Where(x => x.Id == id).FirstOrDefault();
                loanDB.LoanDateEnd = model.LoanDateEnd;
                var gameDB = _invillaContext.Games.Select(x => x).Where(x => x.Id == loanDB.IdGames).FirstOrDefault();
                gameDB.Loaned = false;
                _invillaContext.Update(gameDB);
                _invillaContext.Update(loanDB);
                _invillaContext.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public async Task<bool> GetLoanGameById(long id)
        {

            try { 

                _invillaContext = new InvillaContext();
                var lista = _invillaContext.Loans.Where(x => x.IdGames == id).ToList();

                if (lista.Count > 0)
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Delete(long id)
        {
            try
            {

                _invillaContext = new InvillaContext();                

                if (id == null)
                {
                    return false;
                }

                var loanDB = _invillaContext.Loans.Select(x => x).Where(x => x.Id == id).FirstOrDefault();
                var gameDB = _invillaContext.Games.Select(x => x).Where(x => x.Id == loanDB.IdGames).FirstOrDefault();
                gameDB.Loaned = false;
                _invillaContext.Remove(loanDB);
                _invillaContext.Update(gameDB);
                _invillaContext.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Renew(long id)
        {

            try
            {
                _invillaContext = new InvillaContext();                

                if (id == null)
                {
                    return false;
                }
                var loanDB = _invillaContext.Loans.Select(x => x).Where(x => x.Id == id).FirstOrDefault();
                loanDB.LoanDateBegin = DateTime.Now;                
                _invillaContext.Update(loanDB);
                _invillaContext.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> GetLoanFriendById(long id)
        {
            try
            {

                _invillaContext = new InvillaContext();
                var lista = _invillaContext.Loans.Where(x => x.IdFriend == id).ToList();

                if (lista.Count > 0)
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
