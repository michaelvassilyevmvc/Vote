using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Vote.Application.Persons.Commands.CreatePerson;
using Vote.Application.Persons.Commands.DeletePerson;
using Vote.Application.Persons.Commands.UpdatePerson;
using Vote.Application.Persons.Queries.GetPersons;

namespace Vote.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ApiController
    {
        [HttpGet]
        public async Task<ActionResult<PersonsVm>> Get()
        {
            return await Mediator.Send(new GetPersonsQuery());
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreatePersonCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeletePersonCommand { Id = id });
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdatePersonCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);
            return NoContent();
        }
    }
}
