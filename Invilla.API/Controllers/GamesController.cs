using Invilla.Domain.Model;
using Invilla.Domain.Service;
using InvillaGamesLoan.Attributes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using RepositoryInvilla.Invilla.Service.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Invilla.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    [InvillaSecurity()]
    public class GamesController : ControllerBase
    {

        private readonly ILogger<GamesController> _logger;
        private readonly IServiceGames _serviceGames;

        public GamesController(ILogger<GamesController> logger)
        {
            _logger = logger;
            _serviceGames = new ServiceGames();
        }
        /// <summary>
        /// Get all Games Action
        /// </summary>
        /// <returns>List of all Games</returns>
        [HttpGet("Get")]
        public async Task<IEnumerable<GamesViewModel>> Get()
        {

            return await Task.Run(() => _serviceGames.Get());

        }

        /// <summary>
        /// Persist Gaame on DataBase
        /// </summary>
        /// <param name="json"></param>
        /// <returns>StatusCode</returns>
        [HttpPost("Post")]
        public async Task<IActionResult> Post([FromBody] JObject json)
        {

            var retorno = _serviceGames.Post(json);

            if (retorno != null)
            {
                return Ok("Alright");

            }
            else
            {
                return BadRequest("Something Wrong");
            }

        }

        /// <summary>
        /// Update Game Action
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


            if (await Task.Run(() => _serviceGames.Put(id, json)))
            {
                return Ok("Alright");
            }
            else
            {
                return BadRequest("Some problem occurs on your requisition");

            }
        }

        /// <summary>
        /// Delete Game Action
        /// </summary>
        /// <param name="id">Id of Loan</param>        
        /// <returns></returns>
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            if (await Task.Run(() => _serviceGames.Delete(id)))
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