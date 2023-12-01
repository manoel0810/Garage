using Garage.Data;
using Garage.Data.Init;
using Garage.Models;
using Microsoft.AspNetCore.Mvc;

namespace Garage.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GarageController : Controller
    {
        private readonly ApplicationDbContext _db;

        public GarageController(ApplicationDbContext db)
        {
            _db = db;
            new InitGarageTable(db).Init();
        }

        [HttpGet()]
        public IActionResult GetAll()
        {
            IEnumerable<GarageFormModel> models = _db.Garages;

            if (models != null && !models.Any())
                return Ok(new
                {
                    message = "no garages avaible",
                    models
                });

            return Ok(new
            {
                datetime = DateTime.Now,
                models
            });
        }

        [HttpGet("/code/{garageCode}")]
        public IActionResult GetGarageByCode(string garageCode)
        {
            var garage = _db.Garages.Where(x => x.Codigo == garageCode);
            if (garage != null && garage.Any())
            {
                return Ok(new
                {
                    datetime = DateTime.Now,
                    garage
                });
            }

            return NotFound(new
            {
                message = $"no results for '{garageCode}'"
            });
        }
    }
}
