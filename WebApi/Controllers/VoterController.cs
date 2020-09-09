using Application.Dtos.Voter;
using Application.Features.CandidateFeatures.Queries;
using Application.Features.VoterFeatures.Commands;
using Application.Features.VoterFeatures.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Controllers.Base;

using static Application.Dtos.Voter.VoterDto;
using static Application.Dtos.Candidate.CandidateDto;
using static Application.Dtos.VoterCandidate.VoterCandidateDto;
using static CommonInfrastructure.Utility.ValidationConstants;
using Application.Features.VoterCandidateFeatures.Queries;
using Application.Features.VoterCandidateFeatures.Commands;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/voters")]
    public class VoterController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> CreateVoter(VoterForCreationDto voterForCreationDto)
        {
            var validateVoter = voterForCreationDto.ValidateVoter();

            if (validateVoter.Any())
            {
                return ValidationProblem(validateVoter.First());
            }

            var voterFromCommandHandler = await Mediator.Send(new CreateVoterCommand(voterForCreationDto));

            return CreatedAtRoute(
                new { voterId = voterFromCommandHandler.Id },
                voterFromCommandHandler);
        }

        [HttpDelete("{voterId}")]
        public async Task<IActionResult> DeleteVoter(int voterId)
        {
            var voterExists = await Mediator.Send(new VoterExistsQuery(voterId));

            if (!voterExists)
            {
                return ValidationProblem(NO_VOTER_FOUND);
            }

            //Actually it is not correct approaching to delete voter from db. 
            //We can just add STATUS property to it  and set it to DELETED.
            await Mediator.Send(new DeleteVoterCommand(voterId));

            return NoContent();
        }


        [Route("{voterId}/vote")]
        [HttpPost("{voterId}")]
        public async Task<IActionResult> VoteForCandidate(int voterId, VoteForCandidateDto voteForCandidateDto)
        {
            var voterFromQueryHandler = await Mediator.Send(new GetVoterByIdQuery(voterId)) ?? EmptyVoter;

            if (voterFromQueryHandler == EmptyVoter)
            {
                return ValidationProblem(NO_VOTER_FOUND);
            }

            var candidateFromQueryHandler = await Mediator.Send(new GetCandidateByIdQuery(voteForCandidateDto.CandidateId)) ?? EmptyCandidate;

            if (candidateFromQueryHandler == EmptyCandidate)
            {
                return ValidationProblem(NO_CANDIDATE_FOUND);
            }

            var voterHasAlreadyVotedForCategory = await Mediator.Send(new VoterHasVotedForCategoryQuery(voterId, candidateFromQueryHandler.CategoryId));

            if (voterHasAlreadyVotedForCategory)
            {
                return ValidationProblem(VOTER_ALREADY_VOTED_FOR_CANDIDATE);
            }

            var voterCandidateFromQueryHandler = await Mediator.Send(
                                                new GetVoterCandidateByVoterAndCandidateIdQuery(voteForCandidateDto.CandidateId, voterId)) ?? EmptyVoterCandidate;

            if (voterCandidateFromQueryHandler.VoterId == voterId)
            {
                return ValidationProblem(VOTER_ALREADY_VOTED_FOR_CANDIDATE);
            }

            var voterCandidateFromCommandHandler = await Mediator.Send(new CreateVoteCandidateCommand(voterId, voteForCandidateDto));

            return CreatedAtRoute(
              new { voterId = voterCandidateFromCommandHandler.Id },
              voterCandidateFromCommandHandler);
        }

        [HttpPut("{voterId}")]
        public async Task<IActionResult> ChangeVoterAgeForVoter(int voterId, VoterForUpdateDto voterForUpdateDto)
        {
            var validationErrors = voterForUpdateDto.Validate();

            if (validationErrors.Any())
            {
                return ValidationProblem(validationErrors.First());
            }


            var voterFromQuery = await Mediator.Send(new GetVoterByIdQuery(voterId)) ?? EmptyVoter;

            if (voterFromQuery == EmptyVoter)
            {
                return NotFound(NO_VOTER_FOUND);
            }

            await Mediator.Send(new UpdateVoterCommand(voterId, voterForUpdateDto));


            return NoContent();
        }

    }
}
