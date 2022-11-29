using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Vote.Application.Common.Interfaces;
using Vote.Domain.Entities;

namespace Vote.Application.Votes.Commands.CreateVote
{
    public class CreateVoteCommand: IRequest
    {
        public int ProductId { get; set; }
        public int PersonId { get; set; }

    }

    public class CreateVoteCommandHandler:IRequestHandler<CreateVoteCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateVoteCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateVoteCommand request, CancellationToken cancellationToken)
        {
            var entity = new VotePerson
            {
                PersonId = request.PersonId,
                ProductId = request.ProductId,
            };
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
