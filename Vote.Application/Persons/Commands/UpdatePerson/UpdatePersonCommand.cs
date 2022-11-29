using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Vote.Application.Common.Exceptions;
using Vote.Application.Common.Interfaces;
using Vote.Domain.Entities;

namespace Vote.Application.Persons.Commands.UpdatePerson
{
    public class UpdatePersonCommand: IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

    }

    public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdatePersonCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Persons.FindAsync(request.Id);
            if(entity == null)
            {
                throw new NotFoundException(nameof(Person), request.Id);
            }

            entity.Name = request.Name;
            entity.Age = request.Age;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
