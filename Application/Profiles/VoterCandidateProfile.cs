﻿using Application.Dtos.VoterCandidate;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Profiles
{
    public class VoterCandidateProfile:Profile
    {
        public VoterCandidateProfile()
        {
            CreateMap<VoterCandidate, VoterCandidateDto>().ReverseMap();
            CreateMap<VoterCandidate, VoterCandidateForCreationDto>();
            CreateMap<VoterCandidateForCreationDto, VoterCandidate>();
        }
    }
}
