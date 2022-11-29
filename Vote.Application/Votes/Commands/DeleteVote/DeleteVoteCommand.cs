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

namespace Vote.Application.Votes.Commands.DeleteVote
{
    public class DeleteVoteCommand: IRequest
    {
        public int PersonId { get; set; }
        public int ProductId { get; set; }

    }

    public class DeleteVoteCommandHandler: IRequestHandler<DeleteVoteCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteVoteCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteVoteCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Votes
                .Where(x => x.ProductId == request.ProductId && x.PersonId == request.PersonId)
                .SingleOrDefaultAsync(cancellationToken);
            if(entity == null)
            {
                throw new NotFoundException(nameof(VotePerson), new { request.PersonId, request.ProductId });
            }

            _context.Votes.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
