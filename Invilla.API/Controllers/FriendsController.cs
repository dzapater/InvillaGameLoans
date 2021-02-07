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
    public class FriendsController : ControllerBase
    {

        private readonly ILogger<FriendsController> _logger;
        private readonly IServiceFriends _serviceFriends;

        public FriendsController(ILogger<FriendsController> logger)
        {
            _logger = logger;
            _serviceFriends = new ServiceFriends();
        }

        /// <summary>
        /// Get All Friends Action
        /// </summary>
        /// <returns>List of all Friends</returns>
        [HttpGet("Get")]
        public async Task<IEnumerable<FriendsViewModel>> Get()
        {
            
            return await Task.Run(() => _serviceFriends.Get());

        }

        /// <summary>
        /// Persist Friend on Database
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        [HttpPost("Post")]
        public async Task<IActionResult> Post([FromBody] JObject json)
        {

            var retorno = _serviceFriends.Post(json);

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


            if (await Task.Run(() => _serviceFriends.Put(id, json)))
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
        public async Task<IActionResult> Delete(long id)
        {
            if (await Task.Run(() => _serviceFriends.Delete(id)))
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
