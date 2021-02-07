using Invilla.Data.Context;
using Invilla.Domain.Entity;
using Invilla.Domain.Model;
using Invilla.Domain.Service;
using Invilla.Service.Security;
using Invilla.Services.Security;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RepositoryInvilla.Invilla.Service.Services
{
    public class ServiceLogin : IServiceLogin
    {

        private InvillaContext _invillaContext;

        public async Task<bool> GetLoginByName(JObject json)
        {
            try
            {
                _invillaContext = new InvillaContext();
                var model = JsonConvert.DeserializeObject<LoginViewModel>(json.ToString());
                var loginDB = _invillaContext.Logins.Where(x => x.FullName == model.FullName).FirstOrDefault();
                var roleDB = _invillaContext.Roles.Where(x => x.Id == model.IdRole).FirstOrDefault();

                var role = (string.IsNullOrEmpty(roleDB.Role)) ? "admin" : roleDB.Role;

                model.Password = CryptoConfig.EncryptPassword(model.Password);

                if (model.FullName == loginDB.FullName && model.Password == loginDB.Password)
                {
                    var claims = new List<Claim>(){
                                    new Claim("UserLoan", model.FullName),
                                    new Claim("Password", model.Password),
                                    new Claim("Role", role)
                                };

                    var token = JwtTokenUtils.GenerateInvillaUserToken(claims);
                    loginDB.Token = token;
                    _invillaContext.Update(loginDB);
                    _invillaContext.SaveChanges();

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
