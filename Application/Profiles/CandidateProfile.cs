using Application.Dtos.Candidate;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Profiles
{
    public class CandidateProfile : Profile
    {
        public CandidateProfile()
        {
            CreateMap<Candidate, CandidateForCreationDto>();
            CreateMap<CandidateForCreationDto, Candidate>();
            CreateMap<CandidateDto, Candidate>();
            CreateMap<Candidate, CandidateDto>();
        }
    }
}
