using Invilla.Data.Context;
using Invilla.Domain.Entity;
using Invilla.Domain.Model;
using Invilla.Domain.Service;
using Invilla.Service.Security;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryInvilla.Invilla.Service.Services
{
    public class ServiceUsers : IServiceUsers
    {

        private InvillaContext _invillaContext;
        private IServiceLoans _serviceLoans;


        public async Task<IEnumerable<LoginViewModel>> Get()
        {

            _invillaContext = new InvillaContext();
                var lista = _invillaContext.Logins.Select(x =>
                new LoginViewModel()
                {
                    Id = x.Id,
                    FullName = x.FullName                                      
                }
            ).ToList();


            return lista;

        }

        public async Task<LoginViewModel> Post(JObject json)
        {
            _invillaContext = new InvillaContext();

            try
            {

                var model = JsonConvert.DeserializeObject<LoginViewModel>(json.ToString());
                model.RegistrationDate = DateTime.Now;
                model.Password = CryptoConfig.EncryptPassword(model.Password);

                var Users = new LoginsEntity
                {                    
                    FullName = model.FullName,
                    RegistrationDate = model.RegistrationDate,
                    Password = model.Password,
                    IdRole = 1
                };                
                _invillaContext.Add(Users);
                _invillaContext.SaveChanges();

                return model;


            }
            catch (Exception ex)
            {
                return new LoginViewModel
                {
                    
                };
            }
        }

        public async Task<bool> Put(long id, JObject json)
        {
            try
            {
                var model = JsonConvert.DeserializeObject<LoginViewModel>(json.ToString());

                using (_invillaContext = new InvillaContext()) {

                    if (model.Id == null)
                    {
                        return false;
                    }

                    var loginDB = _invillaContext.Logins.Select(x => x).Where(x => x.Id == id).FirstOrDefault();

                    loginDB.FullName = model.FullName;
                    loginDB.RegistrationDate = DateTime.Now;

                    _invillaContext.Update(loginDB);
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

                var loginDB = _invillaContext.Logins.Select(x => x).Where(x => x.Id == id).FirstOrDefault();
                var roleDB = _invillaContext.Roles.Select(x => x).Where(x => x.Id == loginDB.IdRole).FirstOrDefault();

                if (roleDB != null)
                {
                    return false;
                }

                _invillaContext.Remove(loginDB);
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
