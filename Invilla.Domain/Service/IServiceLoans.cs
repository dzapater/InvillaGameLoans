using Invilla.Domain.Model;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Invilla.Domain.Service
{
    public interface IServiceLoans
    {

        Task<IEnumerable<LoanViewModel>> Get();

        Task<bool> Post(LoanViewModel model);

        Task<bool> Put(long id, JObject json);

        Task<bool> Delete(long id);

        Task<bool> Renew(long id);

        Task<bool> GetLoanGameById(long id);

        Task<bool> GetLoanFriendById(long id);
    }
}
