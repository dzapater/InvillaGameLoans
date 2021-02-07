using Invilla.Domain.Model;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Invilla.Domain.Service
{
    public interface IServiceGames
    {
        Task<IEnumerable<GamesViewModel>> Get();

        Task<GamesViewModel> Post(JObject json);

        Task<bool> Put(long id, JObject json);

        Task<bool> Delete(long id);

    }
}
