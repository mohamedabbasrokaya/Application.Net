using Application.interfaces;
using Application.Models.ViewModel;
using Application.Models;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    public class ViewResultController : Controller
    {
        public ViewResultController(IUniteOfWork uniteOfWork, IMapper mapper)
        {
            UniteOfWork = uniteOfWork;
            Mapper = mapper;
        }

        public IUniteOfWork UniteOfWork { get; }
        public IMapper Mapper { get; }

        public async Task<IActionResult> Index()
        {

            var MappedResult = Mapper.Map<IEnumerable<Result>, IEnumerable<ResultViewModel>>(UniteOfWork.ResultRepo.GetResultWithStudentsAndCourses());

            return View(MappedResult);
        }

    }
}
   
