using AutoMapper;
using Memory.Entities.Concrete;
using Memory.Entities.Concrete.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory.Business.AutoMapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<City, CityDto>().ReverseMap();
            CreateMap<Notebook, NotebookDto>().ReverseMap();
            CreateMap<AppIdentityUser, RegisterDto>().ReverseMap();
        
        }
    }
}
