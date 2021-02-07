using Invilla.Domain.Model;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace Invilla.Domain.Service
{
    public interface IServiceLogin
    {
        Task<bool> GetLoginByName(JObject json);

    }
}
