
using Application.interfaces;
using Application.Models;
using Application.Models.ViewModel;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    public class StudentController : Controller
    {
        public StudentController(IUniteOfWork uniteOfWork, IMapper mapper)
        {
            UniteOfWork = uniteOfWork;
            Mapper = mapper;
        }

        public IUniteOfWork UniteOfWork { get; }
        public IMapper Mapper { get; }

        public async Task<IActionResult> Index()
        {
            var MappedStd = Mapper.Map<IEnumerable<Student>, IEnumerable<StudentViewModel>>(await UniteOfWork.StudentRepo.GetAllAsync());
            return View(MappedStd);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(StudentViewModel student)
        {
            if (ModelState.IsValid)
            {

               Student mapperstudent = Mapper.Map<StudentViewModel, Student>(student);
               await UniteOfWork.StudentRepo.AddAsync(mapperstudent);

                return RedirectToAction("Index");
            }
            return View(student);

        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();
            var Student =await UniteOfWork.StudentRepo.GetAsync(id);
            if (Student == null)
                return NotFound();
            var Mappedstd = Mapper.Map<Student, StudentViewModel>(Student);
            return View(Mappedstd);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, StudentViewModel student)
        {
            if (id != student.StudentId)
                return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    var MappedStd = Mapper.Map<StudentViewModel, Student>(student);
                    await UniteOfWork.StudentRepo.UpdateAsync(MappedStd);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    return View(student);
                }
            }
            return View(student);
        }
        public async Task<IActionResult> Delete(int? id, Student student)
        {
            if (id == null)
                return NotFound();
            var Student = await UniteOfWork.StudentRepo.GetAsync(id);
            if (Student == null)
                return NotFound();
            var Mappedstd = Mapper.Map<Student, StudentViewModel>(Student);
            return View(Mappedstd);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id, StudentViewModel student)
        {
            if (id != student.StudentId)
                return NotFound();
           
                try
                {
                    var MappedStd = Mapper.Map<StudentViewModel, Student>(student);
                    await UniteOfWork.StudentRepo.DeleteAsync(MappedStd);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    return View(student);
                }
            return View(student);
        }
        

    }

    }

