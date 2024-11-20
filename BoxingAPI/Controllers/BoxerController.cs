using BoxingAPI.Dtos;
using BoxingAPI.Models;
using BoxingAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BoxingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoxerController : ControllerBase
    {
        private readonly IBoxerRepository _boxerRepository;

        public BoxerController(IBoxerRepository boxerRepository)
        {
            _boxerRepository = boxerRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BoxerDto>> GetBoxerById(Guid id)
        {
            var boxer = await _boxerRepository.GetByIdAsync(id);

            if (boxer == null)
            {
                return NotFound();
            }

            return Ok(boxer);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BoxerDto>>> GetAllBoxersAsync()
        {
            return Ok(await _boxerRepository.GetAllAsync());
        }

        [HttpPost]
        public async Task<ActionResult> AddBoxerAsync(Boxer boxer)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }


            await _boxerRepository.AddBoxerAsync(boxer);

            return CreatedAtAction(nameof(GetBoxerById), new { id = boxer.Id }, boxer);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBoxerAsync(Guid id, Boxer boxer)
        {
            if(id != boxer.Id || !ModelState.IsValid)
            {
                return BadRequest();
            }

            await _boxerRepository.UpdateBoxerAsync(boxer);

            return CreatedAtAction(nameof(GetBoxerById), new { id = boxer.Id }, boxer);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBoxerAsync(Guid id)
        {
            try
            {
                await _boxerRepository.DeleteBoxerAsync(id);

                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
