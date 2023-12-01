using Domain.Models;
using Domain.Request;
using Microsoft.AspNetCore.Mvc;

namespace Domain.Controllers
{
    public class PassagensController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Chose");
        }

        public IActionResult Chose()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IndexAsync(Filter filtro)
        {
            if (ModelState.IsValid)
            {
                Data data = new();
                APIRequest req = new();

                data.Passes = await req.GetPassesByGarageCode("garage", filtro.Codigo);
                data.PaymentForms = await req.GetAllPaymentFormats();
                data.Garagens = await req.GetGarageInformation("code", filtro.Codigo);

                data.EstimarValores();
                return View(data);
            }

            return View();
        }
    }
}
