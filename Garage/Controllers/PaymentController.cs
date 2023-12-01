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
                    models
                });

            return Ok(new
            {
                datetime = DateTime.Now,
                models
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
                    model
                });
            }

            return NotFound(new
            {
                message = $"no results for '{cod}'"
            });
        }

        /*
        // POST: Garage/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        */
    }
}
