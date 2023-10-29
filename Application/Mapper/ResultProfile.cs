using Application.Models;
using Application.Models.ViewModel;
using AutoMapper;

namespace Application.Mapper
{

    public class ResultProfile:Profile
    {
        public ResultProfile()
        {
            CreateMap<Result, ResultViewModel>()
                .ForMember(dest => dest.student, opt => opt.MapFrom(src => src.StudentNoNavigation))
                .ForMember(dest => dest.Cources, opt => opt.MapFrom(src => src.CourceNoNavigation))

                .ReverseMap();
        }
    }
}
