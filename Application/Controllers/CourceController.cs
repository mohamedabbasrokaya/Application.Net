
using Application.interfaces;
using Application.Models;
using Application.Models.ViewModel;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    public class CourceController : Controller
     {

         public CourceController(IUniteOfWork uniteOfWork , IMapper mapper)
         {
             UniteOfWork = uniteOfWork;
             Mapper = mapper;
         }

         public IUniteOfWork UniteOfWork { get; }
         public IMapper Mapper { get; }

         public async Task<IActionResult> Index()
         {
             var MappedCource = Mapper.Map<IEnumerable<Cource>, IEnumerable<CourcesViewModel>>(await UniteOfWork.CourcesRepo.GetAllAsync());
             return View(MappedCource);
         }

         [HttpGet]
         public async Task<IActionResult> Create()
         {
             return View();
         }
         [HttpPost]
         public async Task<IActionResult> Create(CourcesViewModel cources)
         {
             if (ModelState.IsValid)
             {

                 Cource mapperCourse = Mapper.Map<CourcesViewModel,Cource >(cources);
                 await UniteOfWork.CourcesRepo.AddAsync(mapperCourse);

                 return RedirectToAction("Index");
             }
             return View(cources);

         }
         public async Task<IActionResult> Edit(int? id)
         {
             if (id == null)
                 return NotFound();
             var Cource = await UniteOfWork.CourcesRepo.GetAsync(id);
             if (Cource == null)
                 return NotFound();
             var Mappedcource = Mapper.Map<Cource, CourcesViewModel>(Cource);
             return View(Mappedcource);
         }
         [HttpPost]
         public async Task<IActionResult> Edit(int id, CourcesViewModel cources)
         {
             if (id != cources.CourcesId)
                 return NotFound();
             if (ModelState.IsValid)
             {
                 try
                 {
                     var MappedCourse = Mapper.Map<CourcesViewModel, Cource>(cources);
                     await UniteOfWork.CourcesRepo.UpdateAsync(MappedCourse);
                     return RedirectToAction("Index");
                 }
                 catch (Exception ex)
                 {
                     return View(cources);
                 }
             }
             return View(cources);
         }
         public async Task<IActionResult> Delete(int? id, Cource cource)
         {
             if (id == null)
                 return NotFound();
             var Cource = await UniteOfWork.CourcesRepo.GetAsync(id);
             if (Cource == null)
                 return NotFound();
             var MappedCource = Mapper.Map<Cource, CourcesViewModel>(Cource);
             return View(MappedCource);
         }
         [HttpPost]
         public async Task<IActionResult> Delete(int id, CourcesViewModel cources)
         {
             if (id != cources.CourcesId)
                 return NotFound();

             try
             {
                 var MappedCource = Mapper.Map<CourcesViewModel, Cource>(cources);
                 await UniteOfWork.CourcesRepo.DeleteAsync(MappedCource);
                 return RedirectToAction(nameof(Index));
             }
             catch (Exception ex)
             {
                 return View(cources);
             }
             return View(cources);
         }

   
}
}
