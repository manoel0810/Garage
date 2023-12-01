using Garage.Data;
using Garage.Data.Init;
using Garage.Models;
using Microsoft.AspNetCore.Mvc;

namespace Garage.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ClientController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ClientController(ApplicationDbContext db)
        {
            _db = db;
            new InitClientTable(db).Init();
        }

        [HttpGet()]
        public IActionResult GetAll()
        {
            IEnumerable<Pass> passes = _db.Passes;
            if (passes.Any())
            {
                return Ok(new
                {
                    date = DateTime.Now,
                    passes
                });
            }

            return Ok(new
            {
                message = "no data avaible",
                passes
            });
        }

        [HttpGet("/garage/{garageCode}")]
        public IActionResult GetRegistryByGarageCode(string garageCode)
        {
            IEnumerable<Pass> passes = _db.Passes.Where(x => x.Garagem == garageCode.ToUpper());

            if (passes != null && passes.Any())
            {
                return Ok(new
                {
                    datetime = DateTime.Now,
                    passes
                });
            }

            return NotFound(new
            {
                message = $"no results for '{passes}'"
            });
        }

        [HttpGet("/placa/{carCode}")]
        public IActionResult GetRegistryByCarCode(string carCode)
        {
            IEnumerable<Pass> passes = _db.Passes.Where(x => x.CarroPlaca == carCode.ToUpper());

            if (passes != null && passes.Any())
            {
                return Ok(new
                {
                    datetime = DateTime.Now,
                    passes
                });
            }

            return NotFound(new
            {
                message = $"no results for '{passes}'"
            });
        }
    }
}
