using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    public class ResultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
