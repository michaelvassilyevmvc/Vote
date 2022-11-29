using AutoMapper;
using System;
using System.Collections.Generic;
using Vote.Application.Common.Mappings;
using Vote.Domain.Entities;

namespace Vote.Application.Dtos.Voting
{
    public class VoteDto: IMapFrom<VotePerson>
    {
        public int PersonId { get; set; }
        public int ProductId { get; set; }
        public DateTime VoteDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<VotePerson, VoteDto>()
                .ForMember(s => s.PersonId, d => d.MapFrom(x => x.PersonId))
                .ForMember(s => s.ProductId, d => d.MapFrom(x => x.ProductId))
                .ForMember(s => s.VoteDate, d => d.MapFrom(x => x.VoteDate));
        }
        

    }
}
