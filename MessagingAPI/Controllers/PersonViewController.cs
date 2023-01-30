using MessagingAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MessagingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonViewController : ControllerBase
    {
        private readonly INRSContext db;
        public PersonViewController(INRSContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public async Task<ActionResult<List<PersonView>>> Get()
        {
            var persons = await db.PersonViews.Take(20).ToListAsync();
            return Ok(persons);
        }

        [Route("/api/[controller]/{pin}")]
        [HttpGet]
        public async Task<ActionResult> GetPerson(string? pin)
        {            
            var person = await db.PersonViews.FirstOrDefaultAsync(pv => pv.Pin == pin);
            return Ok(person);
        }
    }
}
