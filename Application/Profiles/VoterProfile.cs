using Application.Dtos;
using Application.Dtos.Voter;
using AutoMapper;
using Domain.Entities;

namespace Application.Profiles
{
    public class VoterProfile : Profile
    {
        public VoterProfile()
        {
            CreateMap<Voter, VoterForUpdateDto>();
            CreateMap<VoterForUpdateDto, Voter>();
            CreateMap<Voter, VoterForCreationDto>();
            CreateMap<VoterForCreationDto, Voter>();
            CreateMap<VoterDto, Voter>();
            CreateMap<Voter, VoterDto>();
        }
    }
}
