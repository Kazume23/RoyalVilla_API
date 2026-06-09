using Microsoft.AspNetCore.Mvc;
using RoyalVilla_API.Controllers.Data;
using RoyalVilla_API.Models;
using Microsoft.EntityFrameworkCore;

namespace RoyalVilla_API.Controllers
{
    [Route("api/villas")]
    [ApiController]
    public class VillaController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public VillaController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Villa>>> GetVilllas()
        {
            return Ok(await _db.Villa.ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<IEnumerable<Villa>>> GetVilllasById(int id)
        {
            try
            {
                if (id >= 0)
                {
                    return BadRequest("Villa Id must be greater than or equal to 0.");
                }

                var villa = await _db.Villa.FirstOrDefaultAsync(u => u.Id == id);
                if (villa == null)
                {
                    return NotFound($"Villa with ID {id} not found.");
                }
                return Ok(villa);
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"An error occurred while retrieving villa with ID {id}: {ex.Message}");
            }
            
        }
    }
}
