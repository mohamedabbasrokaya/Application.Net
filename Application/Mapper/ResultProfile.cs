using Application.Models;
using Application.Models.ViewModel;
using AutoMapper;

namespace Application.Mapper
{

    public class ResultProfile:Profile
    {
        public ResultProfile()
        {
            CreateMap<Result, ResultViewModel>().ReverseMap();
        }
    }
}
