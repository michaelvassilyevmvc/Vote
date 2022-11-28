using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Vote.Data.Context;
using Vote.Domain.Entities;

namespace Vote.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly VoteDbContext _context;

        public PersonsController(VoteDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Persons);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Person person)
        {
            await _context.Persons.AddAsync(person);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var person = await _context.Persons.FirstOrDefaultAsync(p => p.Id == id);
            if (person == null) { return NotFound(); }

            return Ok(person);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var person = await _context.Persons.FirstOrDefaultAsync(p =>p.Id == id);
            if (person == null) { return NotFound(); }
            _context.Persons.Remove(person);
            await _context.SaveChangesAsync();
            return Ok(person);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Person person)
        {
            _context.Update(person);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
