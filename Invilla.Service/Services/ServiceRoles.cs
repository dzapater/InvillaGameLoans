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
    public class ServiceRoles : IServiceRoles
    {

        private InvillaContext _invillaContext;       


        public async Task<IEnumerable<RoleViewModel>> Get()
        {

            _invillaContext = new InvillaContext();
                var lista = _invillaContext.Roles.Select(x =>
                new RoleViewModel()
                {
                    Id = x.Id,
                    Role = x.Role,
                                 
                }
            ).ToList();


            return lista;

        }

        public async Task<RoleViewModel> Post(JObject json)
        {
            _invillaContext = new InvillaContext();

            try
            {

                var model = JsonConvert.DeserializeObject<RoleViewModel>(json.ToString());
                model.RegistrationDate = DateTime.Now;
                var role = new RolesEntity
                {                    
                    Role = model.Role,
                    RegistrationDate = model.RegistrationDate
                };                
                _invillaContext.Add(role);
                _invillaContext.SaveChanges();

                return model;


            }
            catch (Exception ex)
            {
                return new RoleViewModel
                {
                    
                };
            }
        }

        public async Task<bool> Put(long id, JObject json)
        {
            try
            {
                var model = JsonConvert.DeserializeObject<RoleViewModel>(json.ToString());

                using (_invillaContext = new InvillaContext()) {

                    if (model.Id == null)
                    {
                        return false;
                    }

                    var roleDB = _invillaContext.Roles.Select(x => x).Where(x => x.Id == id).FirstOrDefault();

                    roleDB.Role = model.Role;
                    roleDB.RegistrationDate = DateTime.Now;

                    _invillaContext.Update(roleDB);
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

                var roleDB = _invillaContext.Roles.Select(x => x).Where(x => x.Id == id).FirstOrDefault();
                var loginDB = _invillaContext.Logins.Select(x => x).Where(x => x.IdRole == id).FirstOrDefault();
                
                if (loginDB != null)
                {
                    return false;
                }

                _invillaContext.Remove(roleDB);
                _invillaContext.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<object> GetRoleById(long id)
        {
            try
            {

                _invillaContext = new InvillaContext();

                var roleDB = _invillaContext.Roles.Select(x => x).Where(x => x.Id == id).FirstOrDefault();

                return roleDB;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
