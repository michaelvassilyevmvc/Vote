using System.Collections.Generic;
using Vote.Application.Dtos.Voting;
using Vote.Domain.Entities;

namespace Vote.Application.Votes.Queries.GetVotes
{
    public class VotesVm
    {
        public IList<VoteDto> List { get; set; }
    }
}
