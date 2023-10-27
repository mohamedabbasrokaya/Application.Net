using Application.Models;
using Application.Models.ViewModel;
using AutoMapper;

namespace Application.Mapper
{
    public class CourcesProfile:Profile
    {
        public CourcesProfile()
        {
            CreateMap<Cource,CourcesViewModel>().ReverseMap();

        }
    }
}
