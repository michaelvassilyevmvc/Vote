using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Vote.Application.Common.Interfaces;
using Vote.Application.Dtos.Voting;

namespace Vote.Application.Persons.Queries.GetPersons
{
    public class GetPersonsQuery : IRequest<PersonsVm>
    {
    }

    public class GetPersonsQueryHandler : IRequestHandler<GetPersonsQuery, PersonsVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetPersonsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PersonsVm> Handle(GetPersonsQuery request, CancellationToken cancellationToken)
        {
            return new PersonsVm
            {
                List = await _context.Persons.ProjectTo<PersonDto>(_mapper.ConfigurationProvider)
                    .OrderBy(p => p.Name).ToListAsync(cancellationToken)
            };
        }
    }
}
