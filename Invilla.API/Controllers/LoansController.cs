using Invilla.Domain.Model;
using Invilla.Domain.Service;
using InvillaGamesLoan.Attributes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RepositoryInvilla.Invilla.Service.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Invilla.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    [InvillaSecurity()]
    public class LoansController : ControllerBase
    {

        private readonly ILogger<LoansController> _logger;
        private readonly IServiceLoans _serviceLoans;

        public LoansController(ILogger<LoansController> logger)
        {
            _logger = logger;
            _serviceLoans = new ServiceLoans();
        }

        /// <summary>
        /// Get ao Loans Games Action
        /// </summary>
        /// <returns>List of Loans</returns>
        [HttpGet("Get")]
        public async Task<IEnumerable<LoanViewModel>> Get()
        {
            var retorno = await Task.Run(() => _serviceLoans.Get());
            return retorno;

        }

        /// <summary>
        /// Persist Loan on Database Action
        /// </summary>
        /// <param name="json">Json of Request</param>
        /// <returns></returns>
        [HttpPost("Post")]
        public async Task<IActionResult> Post([FromBody] JObject json)
        {

            var model = JsonConvert.DeserializeObject<LoanViewModel>(json.ToString());

            if ((model.IdFriend == null) || (model.IdGame == null) || (model.LoanDateBegin == null))
            {
                return BadRequest("Invalid input data");
            }

            if (model.IdFriend.Length > 1)
            {
                return BadRequest("Only a unic friend can make a Loan");
            }

            if (await Task.Run(() => _serviceLoans.Post(model)))
            {
                return Ok("Alright");

            }
            else
            {
                return Problem("The game is already on loan or some error occurs on your requisition");
            }

        }

        /// <summary>
        /// Update Loan Action
        /// </summary>
        /// <param name="id">Id of Loan</param>
        /// <param name="json">JSON of Requisition</param>
        /// <returns></returns>
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(long id, JObject json)
        {

            if (await Task.Run(() => _serviceLoans.Put(id, json)))
            {
                return Ok("Alright");
            }
            else
            {
                return BadRequest("Some problem occurs on your requisition");

            }
        }

        /// <summary>
        /// Renew Loan Action
        /// </summary>
        /// <param name="id">Id of Loan</param>
        /// <param name="json">JSON of Requisition</param>
        /// <returns></returns>
        [HttpPut("Renew/{id}")]
        public async Task<IActionResult> Renew(long id)
        {

            if (await Task.Run(() => _serviceLoans.Renew(id)))
            {
                return Ok("Alright");
            }
            else
            {
                return BadRequest("Some problem occurs on your requisition");

            }
        }

        /// <summary>
        /// Delete Loan Action
        /// </summary>
        /// <param name="id">Id of Loan</param>        
        /// <returns></returns>
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            if (await Task.Run(() => _serviceLoans.Delete(id)))
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