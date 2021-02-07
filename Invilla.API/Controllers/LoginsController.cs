using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using Invilla.Domain.Service;
using RepositoryInvilla.Invilla.Service.Services;
using Microsoft.AspNetCore.Authorization;

namespace Invilla.API.Controllers
{

    [ApiController]
    [Route("[controller]")]    
    public class LoginsController : ControllerBase
    {

        private readonly ILogger<LoginsController> _logger;
        private readonly IServiceLogin _serviceLogin;        

        public LoginsController(ILogger<LoginsController> logger)
        {
            _logger = logger;
            _serviceLogin = new ServiceLogin();
            
        }


        /// <summary>
        /// Make login and persist Token on Database
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        [HttpPost("Post")]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] JObject json)
        {

            var retorno = _serviceLogin.GetLoginByName(json);

            if (retorno.Result)
            {
                return Ok("Alright");

            }
            else
            {
                return BadRequest("Something wrong");
            }

        }

    }
}
