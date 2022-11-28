using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Vote.Data.Context;
using Vote.Domain.Entities;

namespace Vote.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VotesController : ControllerBase
    {
        private readonly VoteDbContext _context;

        public VotesController(VoteDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Votes);
        }

        

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Domain.Entities.Vote vote)
        {
           await _context.Votes.AddAsync(vote);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Domain.Entities.Vote vote)
        {
            _context.Update(vote);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            //var vote = await _context.Votes.SingleOrDefaultAsync(v => (v.Id == id));
            //if(vote == null) { 

            //return NotFound();}

            //_context.Votes.Remove(vote);
            //await _context.SaveChangesAsync();
            //return Ok(vote);
            return Ok();
        }
    }
}
