using Garage.Data;
using Garage.Data.Init;
using Garage.Models;
using Microsoft.AspNetCore.Mvc;

namespace Garage.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class PaymentController : Controller
    {
        private readonly ApplicationDbContext _db;

        public PaymentController(ApplicationDbContext db)
        {
            _db = db;
            new InitPaymentTable(db).Init();
        }

        [HttpGet]
        public IActionResult GetAllMethods()
        {
            IEnumerable<PaymentFormModel> models = _db.PaymentFormats;

            if (models != null && !models.Any())
                return Ok(new
                {
                    message = "no formats avaible",
                    paymentsModel = models
                });

            return Ok(new
            {
                datetime = DateTime.Now,
                paymentsModel = models
            });
        }

        [HttpGet("{cod}")]
        public IActionResult GetPaymentFormat(string cod)
        {
            var model = _db.PaymentFormats.Where(x => x.Codigo == cod.ToUpper());
            if (model != null && model.Any())
            {
                return Ok(new
                {
                    datetime = DateTime.Now,
                    paymentsModel = model
                });
            }

            return NotFound(new
            {
                message = $"no results for '{cod}'"
            });
        }
    }
}
