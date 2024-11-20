using BoxingAPI.Models;
using BoxingAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BoxingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FightController : ControllerBase
    {
        private readonly IFightRepository _fightRepository;

        public FightController(IFightRepository fightRepository)
        {
            _fightRepository = fightRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Boxer>> GetFightById(Guid id)
        {
            var boxer = await _fightRepository.GetByIdAsync(id);

            if (boxer == null)
            {
                return NotFound();
            }

            return Ok(boxer);
        }

        [HttpPost]
        public async Task<ActionResult> RegisterFightAsync(Fight fight)
        {
            if (!ModelState.IsValid || fight.WinnerBoxerId == fight.LoserBoxerId)
            {
                return BadRequest();
            }


            await _fightRepository.AddFightAsync(fight);

            return CreatedAtAction(nameof(GetFightById), new { id = fight.Id }, fight);
        }
    }
}
