using Application.Dtos.Candidate;
using Application.Features.CandidateFeatures.Commands;
using Application.Features.CandidateFeatures.Queries;
using Application.Features.CategoryFeatures.Queries;
using CommonInfrastructure.Utility;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Controllers.Base;

using static Application.Dtos.Candidate.CandidateDto;
using static Application.Dtos.Category.CategoryDto;
using static CommonInfrastructure.Utility.ValidationConstants;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/candidates")]
    public class CandidateController: BaseController
    {
        [HttpPost]
        public async Task<IActionResult> CreateCandidate(CandidateForCreationDto candidateForCreationDto)
        {
            var validationInfos = candidateForCreationDto.ValidateCandidateForCreationDto();

            if (validationInfos.Any())
            {
                return ValidationProblem(validationInfos.First());
            }

            var categoryFromQueryHandler = await Mediator.Send(new GetCategoryByIdQuery(candidateForCreationDto.CategoryId)) ?? EmptyCategory;

            if (categoryFromQueryHandler == EmptyCategory)
            {
                return ValidationProblem(NO_CATEGORY_FOUND);
            }

            var candidateFromQueryHandler = await Mediator.Send(new GetCandidateByIDNumberQuery(candidateForCreationDto.IdNumber)) ?? EmptyCandidate;

            if(candidateFromQueryHandler != EmptyCandidate)
            {
                return ValidationProblem(CONFLICT_WITH_EXISTING_CANDIDATE);
            }

            var candidateDtoFromCommandHandlerToReturn = await Mediator.Send(new CreateCandidateCommand(candidateForCreationDto));

            return CreatedAtRoute(new { candidateId = candidateFromQueryHandler.Id },
                                candidateDtoFromCommandHandlerToReturn);
        }


        [HttpDelete("{candidateId}")]
        public async Task<IActionResult> DeleteCandidate(int candidateId)
        {
            var candidateFromQueryHandler = await Mediator.Send(new GetCandidateByIdQuery(candidateId)) ?? EmptyCandidate;

            if (candidateFromQueryHandler == EmptyCandidate)
            {
                return ValidationProblem(NO_CANDIDATE_FOUND);
            }

            await Mediator.Send(new DeleteCandidateCommand(candidateId));

            return NoContent();
        }

        [Route("{candidateId}/votes")]
        [HttpGet("{candidateId}")]
        public async Task<IActionResult> GetCandidates(int candidateId)
        {
            var candidateFromQueryHandler = await Mediator.Send(new GetCandidateByIdQuery(candidateId)) ?? EmptyCandidate;

            if (candidateFromQueryHandler == EmptyCandidate)
            {
                return ValidationProblem(NO_CANDIDATE_FOUND);
            }

            var sharpOfVotes = await Mediator.Send(new GetSharpsForCandidateQuery(candidateId));

            return Ok(sharpOfVotes);
        }
    }
}
