using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Vote.Application.Common.Exceptions;
using Vote.Application.Common.Interfaces;
using Vote.Domain.Entities;

namespace Vote.Application.Votes.Commands.UpdateVote
{
    public class UpdateVoteCommand: IRequest
    {
        public int PersonId { get; set; }
        public int ProductId { get; set; }
    }

    public class UpdateVoteCommandHandler:IRequestHandler<UpdateVoteCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateVoteCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateVoteCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Votes
                                .FirstOrDefaultAsync(x => x.ProductId == request.ProductId && x.PersonId == request.PersonId, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(VotePerson), new { request.PersonId, request.ProductId });
            }

            entity.PersonId = request.PersonId;
            entity.ProductId = request.ProductId;
            entity.VoteDate = DateTime.UtcNow;

            return Unit.Value;
        }
    }
}
