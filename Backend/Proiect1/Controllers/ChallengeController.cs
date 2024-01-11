using Microsoft.AspNetCore.Mvc;
using Proiect1.BLL.Interfaces;
using Proiect1.BLL.Models;
using System.Threading.Tasks;

namespace Proiect1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChallengeController : ControllerBase
    {
        private readonly IChallManager manager;

        public ChallengeController(IChallManager challManager)
        {
            this.manager = challManager;
        }

        [HttpGet("Select_all_chall")]
        public async Task<IActionResult> GetChallenges()
        {
            var challenges = manager.GetChallenges();
            return Ok(challenges);
        }

        [HttpGet("Select_newest_chall")]
        public async Task<IActionResult> GetNewestChallenge()
        {
            var newestChall = manager.GetNewestChallenge();
            return Ok(newestChall);
        }

        [HttpPost("Create_Challenge")]
        public async Task<IActionResult> CreateChallenge([FromBody] ChallengeModel challengeModel)
        {
            manager.CreateChallenge(challengeModel);
            return Ok();
        }

        [HttpPut("Update_Challenge_By_Id")]
        public async Task<IActionResult> UpdateChallenge([FromBody] ChallengeModel challengeModel)
        {
            manager.UpdateChallenge(challengeModel);
            return Ok();
        }

        [HttpDelete("Delete_Challenge_By_{id}")]
        public async Task<IActionResult> DeleteChallenge([FromRoute] int id)
        {
            manager.DeleteChallenge(id);
            return Ok();
        }
    }
}