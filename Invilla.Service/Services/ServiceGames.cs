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
    public class ServiceGames : IServiceGames
    {

        private InvillaContext _invillaContext;
        private IServiceLoans _serviceLoans;

        public async Task<IEnumerable<GamesViewModel>> Get()
        {

            _invillaContext = new InvillaContext();
            var lista = _invillaContext.Games.Select(x =>
                new GamesViewModel()
                {
                    FullGameName = x.FullGameName,
                    Id = x.Id                   

                }
            ).ToList();

            return lista;

        }


        public async Task<GamesViewModel> Post(JObject json)
        {
            _invillaContext = new InvillaContext();

            try
            {

                var modelo = JsonConvert.DeserializeObject<GamesViewModel>(json.ToString());
                modelo.RegistrationDate = DateTime.Now;
                var Games = new GamesEntity
                {
                    FullGameName = modelo.FullGameName,
                    RegistrationDate = modelo.RegistrationDate                

                };
                _invillaContext.Add(Games);
                _invillaContext.SaveChanges();

                return modelo;


            }
            catch (Exception ex)
            {
                return new GamesViewModel
                {

                };
            }
        }

        public async Task<bool> Put(long id, JObject json)
        {
            try
            {

                _invillaContext = new InvillaContext();

                var model = JsonConvert.DeserializeObject<GamesViewModel>(json.ToString());

                if (model.Id == null)
                {
                    return false;
                }

                var gameDB = _invillaContext.Games.Select(x => x).Where(x => x.Id == id).FirstOrDefault();

                gameDB.FullGameName = model.FullGameName;
                gameDB.RegistrationDate = DateTime.Now;
                
                _invillaContext.Update(gameDB);                
                _invillaContext.SaveChanges();

                return true;
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
                _serviceLoans = new ServiceLoans();

                if (id == null || await _serviceLoans.GetLoanGameById(id))
                {
                    return false;
                }

                var gameDB = _invillaContext.Games.Select(x => x).Where(x => x.Id == id).FirstOrDefault();  
                _invillaContext.Remove(gameDB);                
                _invillaContext.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
