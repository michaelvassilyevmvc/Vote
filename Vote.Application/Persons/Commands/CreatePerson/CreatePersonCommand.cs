using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Vote.Application.Common.Interfaces;
using Vote.Domain.Entities;

namespace Vote.Application.Persons.Commands.CreatePerson
{
    public class CreatePersonCommand : IRequest<int>
    {
        public string Name { get; set; }
        public int Age { get; set; }

    }

    public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreatePersonCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            var entity = new Person
            {
                Name = request.Name,
                Age = request.Age
            };
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }
}
