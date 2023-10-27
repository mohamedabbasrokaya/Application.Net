using Application.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    public class CourceController : Controller
    {
        
        public CourceController(IUniteOfWork uniteOfWork)
        {
            UniteOfWork = uniteOfWork;
        }

        public IUniteOfWork UniteOfWork { get; }

        public IActionResult Index()
        {
            return View();
        }
    }
}
