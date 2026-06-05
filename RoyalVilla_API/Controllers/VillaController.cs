using Microsoft.AspNetCore.Mvc;

namespace RoyalVilla_API.Controllers
{
    [Route("api/villas")]
    [ApiController]
    public class VillaController : ControllerBase
    {
        [HttpGet]
        public string GetVilllas()
        {
            
            return "This is the list of villas";
        }

        [HttpGet("{id:int}")]
        public string GetVilllasById(int id)
        {

            return "This is the list of villas by ID" + id;
        }
    }
}
