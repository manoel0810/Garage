using Domain.Request;
using Microsoft.AspNetCore.Mvc;

namespace Domain.Controllers
{
    public class PassagensController : Controller
    {
        public async Task<IActionResult> IndexAsync()
        {
            APIRequest req = new();
            var response = await req.GetPassesAsync();

            return View(response);
        }
    }
}
