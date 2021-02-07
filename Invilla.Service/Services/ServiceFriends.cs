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
    public class ServiceFriends : IServiceFriends
    {

        private InvillaContext _invillaContext;
        private IServiceLoans _serviceLoans;


        public async Task<IEnumerable<FriendsViewModel>> Get()
        {

            _invillaContext = new InvillaContext();
                var lista = _invillaContext.Friends.Select(x =>
                new FriendsViewModel()
                {
                    Id = x.Id,
                    FullName = x.FullName,
                    Age = x.Age                    
                }
            ).ToList();


            return lista;

        }

        /// <summary>
        /// Persiste os dados da requisição
        /// </summary>
        /// <param name="json">Json do Controller</param>
        /// <returns>Modelo WeatherForeCast</returns>
        public async Task<FriendsViewModel> Post(JObject json)
        {
            _invillaContext = new InvillaContext();

            try
            {

                var modelo = JsonConvert.DeserializeObject<FriendsViewModel>(json.ToString());
                modelo.RegistrationDate = DateTime.Now;
                var friends = new FriendsEntity
                {
                    Age = modelo.Age,
                    FullName = modelo.FullName,
                    RegistrationDate = modelo.RegistrationDate
                };                
                _invillaContext.Add(friends);
                _invillaContext.SaveChanges();

                return modelo;


            }
            catch (Exception ex)
            {
                return new FriendsViewModel
                {
                    
                };
            }
        }

        public async Task<bool> Put(long id, JObject json)
        {
            try
            {
                var model = JsonConvert.DeserializeObject<FriendsViewModel>(json.ToString());

                using (_invillaContext = new InvillaContext()) {

                    if (model.Id == null)
                    {
                        return false;
                    }

                    var friendDB = _invillaContext.Friends.Select(x => x).Where(x => x.Id == id).FirstOrDefault();

                    friendDB.FullName = model.FullName;                    

                    _invillaContext.Update(friendDB);
                    _invillaContext.SaveChanges();

                    return true;
                }
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

                if (id == null || await _serviceLoans.GetLoanFriendById(id))
                {
                    return false;
                }

                var friendDB = _invillaContext.Friends.Select(x => x).Where(x => x.Id == id).FirstOrDefault();
                _invillaContext.Remove(friendDB);
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
