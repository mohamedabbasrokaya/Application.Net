using Application.Models;
using Application.Models.ViewModel;
using AutoMapper;

namespace Application.Mapper
{
    public class StudentProfile:Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, StudentViewModel>().ReverseMap();
        }
    }
}
