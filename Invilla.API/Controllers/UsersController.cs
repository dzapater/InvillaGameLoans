using InvillaGamesLoan.Attributes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Invilla.Domain.Service;
using Invilla.Domain.Model;
using RepositoryInvilla.Invilla.Service.Services;

namespace Invilla.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    [InvillaSecurity()]
    public class UsersController : ControllerBase
    {

        private readonly ILogger<UsersController> _logger;
        private readonly IServiceUsers _serviceUsers;

        public UsersController(ILogger<UsersController> logger)
        {
            _logger = logger;
            _serviceUsers = new ServiceUsers();
        }

        /// <summary>
        /// Get All Users Action
        /// </summary>
        /// <returns>List of all Users</returns>
        [HttpGet("Get")]
        public async Task<IEnumerable<LoginViewModel>> Get()
        {
            
            return await Task.Run(() => _serviceUsers.Get());

        }

        /// <summary>
        /// Persist Friend on Database
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        [HttpPost("Post")]
        public async Task<IActionResult> Post([FromBody] JObject json)
        {

            var retorno = _serviceUsers.Post(json);

            if (retorno != null)
            {
                return Ok("Alright");

            }
            else
            {
                return BadRequest("Something wrong");
            }

        }

        /// <summary>
        /// Update Friend Action
        /// </summary>
        /// <param name="id">Id of Loan</param>
        /// <param name="json">JSON of Requisition</param>
        /// <returns></returns>
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(long id, JObject json)
        {

            if (json == null)
            {
                return Ok();
            }


            if (await Task.Run(() => _serviceUsers.Put(id, json)))
            {
                return Ok("Alright");
            }
            else
            {
                return BadRequest("Some problem occurs on your requisition");

            }
        }

        /// <summary>
        /// Delete Friend Action
        /// </summary>
        /// <param name="id">Id of Loan</param>        
        /// <returns></returns>
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await Task.Run(() => _serviceUsers.Delete(id)))
            {
                return Ok("Alright");
            }
            else
            {
                return BadRequest("Some problem occurs on your requisition");

            }
        }
    }
}
