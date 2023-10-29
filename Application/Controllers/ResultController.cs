using Application.Models.ViewModel;
using Application.Models;
using Application.Reposaitry;
using Microsoft.AspNetCore.Mvc;
using Application.interfaces;
using AutoMapper;

namespace Application.Controllers
{
    public class ResultController : Controller
    {
        public ResultController(IUniteOfWork uniteOfWork, IMapper mapper)
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
        [HttpGet]
        public async Task<IActionResult> Create()
        {

            ViewBag.Students = UniteOfWork.StudentRepo.GetAllAsync().Result;
            ViewBag.Cources = UniteOfWork.CourcesRepo.GetAllAsync().Result;

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ResultViewModel result)
        {
            if (ModelState.IsValid)
            {
                Result mapperResult = Mapper.Map<ResultViewModel, Result>(result);
                await UniteOfWork.ResultRepo.AddAsync(mapperResult);
                return RedirectToAction("Index");
            }


            return View(result);

        }
        
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.Students = UniteOfWork.StudentRepo.GetAllAsync().Result;
            ViewBag.Cources = UniteOfWork.CourcesRepo.GetAllAsync().Result;
            if (id == null)
                return NotFound();
            var Result = await UniteOfWork.ResultRepo.GetAsync(id);
            if (Result == null)
                return NotFound();
            var Mappedresult = Mapper.Map<Result, ResultViewModel>(Result);


            return View(Mappedresult);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, ResultViewModel result)
        {
            if (id != result.ResultId)
                return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    var MappedResult = Mapper.Map<ResultViewModel, Result>(result);
                    await UniteOfWork.ResultRepo.UpdateAsync(MappedResult);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ViewBag.Students = UniteOfWork.StudentRepo.GetAllAsync().Result;
                    ViewBag.Cources = UniteOfWork.CourcesRepo.GetAllAsync().Result;

                    return View(result);
                }
            }
            ViewBag.Students = UniteOfWork.StudentRepo.GetAllAsync().Result;
            ViewBag.Cources = UniteOfWork.CourcesRepo.GetAllAsync().Result;


            return View(result);
        }
        public async Task<IActionResult> Delete(int? id , Result result)
        {
            ViewBag.Students = UniteOfWork.StudentRepo.GetAllAsync().Result;
            ViewBag.Cources = UniteOfWork.CourcesRepo.GetAllAsync().Result;
            if (id == null)
                return NotFound();
            var Result = await UniteOfWork.ResultRepo.GetAsync(id);
            if (Result == null)
                return NotFound();
            var MappedResult = Mapper.Map<Result, ResultViewModel>(Result);


            return View(MappedResult);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id, ResultViewModel result)
        {
            if (id != result.ResultId)
                return NotFound();

            try
            {
                var MappedResult = Mapper.Map<ResultViewModel, Result>(result);
                await UniteOfWork.ResultRepo.DeleteAsync(MappedResult);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                ViewBag.Students = UniteOfWork.StudentRepo.GetAllAsync().Result;
                ViewBag.Cources = UniteOfWork.CourcesRepo.GetAllAsync().Result;
                return View(result);

            }


            ViewBag.Students = UniteOfWork.StudentRepo.GetAllAsync().Result;
            ViewBag.Cources = UniteOfWork.CourcesRepo.GetAllAsync().Result;
            return View(result);


        }
        
        }
    }
    
    
