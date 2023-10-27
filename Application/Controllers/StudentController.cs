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

        public IActionResult Index()
        {
            var MappedStd = Mapper.Map<IEnumerable<Student>, IEnumerable<StudentViewModel>>(UniteOfWork.StudentRepo.GetAll());
            return View(MappedStd);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(StudentViewModel student)
        {
            if (ModelState.IsValid)
            {

                var mapperstudent = Mapper.Map<StudentViewModel, Student>(student);
                UniteOfWork.StudentRepo.Add(mapperstudent);

                return RedirectToAction("Index");
            }
            return View(student);

        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();
            var Student = UniteOfWork.StudentRepo.Get(id);
            if (Student == null)
                return NotFound();
            var Mappedstd = Mapper.Map<Student, StudentViewModel>(Student);
            return View(Mappedstd);
        }
        [HttpPost]
        public IActionResult Edit(int id, StudentViewModel student)
        {
            if (id != student.StudentId)
                return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    var MappedStd = Mapper.Map<StudentViewModel, Student>(student);
                    UniteOfWork.StudentRepo.Update(MappedStd);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    return View(student);
                }
            }
            return View(student);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();
            var Student = UniteOfWork.StudentRepo.Get(id);
            if (Student == null)
                return NotFound();
            var Mappedstd = Mapper.Map<Student, StudentViewModel>(Student);
            return View(Mappedstd);
        }
        [HttpPost]
        public IActionResult Delete(int id, StudentViewModel student)
        {
            if (id != student.StudentId)
                return NotFound();
           
                try
                {
                    var MappedStd = Mapper.Map<StudentViewModel, Student>(student);
                    UniteOfWork.StudentRepo.Delete(MappedStd);
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

