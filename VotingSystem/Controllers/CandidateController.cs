using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VotingSystem.Controllers.Base;

namespace VotingSystem.Controllers
{
    [ApiController]
    [Route("api/candidates")]
    public class CandidateController : BaseController
    {



        [HttpGet]
        public async Task<IActionResult> GetCandidates()
        {
            
        }
    }
}
