using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Vote.Application.Common.Interfaces;
using Vote.Application.Dtos.Voting;

namespace Vote.Application.Votes.Queries.GetVotes
{
    public class GetVotesQuery : IRequest<VotesVm>
    {
    }

    public class GetVotesQueryHandler : IRequestHandler<GetVotesQuery, VotesVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetVotesQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<VotesVm> Handle(GetVotesQuery request, CancellationToken cancellationToken)
        {
            return new VotesVm
            {
                List = await _context.Votes.ProjectTo<VoteDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken)
            };
        }
    }
}
