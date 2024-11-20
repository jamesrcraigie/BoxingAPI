using BoxingAPI.Models;
using BoxingAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BoxingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GymController : ControllerBase
    {
        private readonly IGymRepository _gymRepository;

        public GymController(IGymRepository gymRepository)
        {
            _gymRepository = gymRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Gym>>> GetAllGymsAsync()
        {
            return Ok(await _gymRepository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Gym>> GetGymById(Guid id)
        {
            var gym = await _gymRepository.GetByIdAsync(id);

            if (gym == null)
            {
                return NotFound();
            }

            return Ok(gym); 
        }

        [HttpPost]
        public async Task<ActionResult> AddGymAsync(Gym gym)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _gymRepository.AddGymAsync(gym);

            return CreatedAtAction(nameof(GetGymById), new { id = gym.Id }, gym);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateGymAsync(Guid id, Gym gym)
        {
            if(!ModelState.IsValid || gym.Id != id)
            {
                return BadRequest();
            }

            await _gymRepository.UpdateGymAsync(gym);

            return CreatedAtAction(nameof(GetGymById), new { id = gym.Id }, gym);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteGymAsync(Guid id)
        {
            try
            {
                await _gymRepository.DeleteGymAsync(id);

                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
