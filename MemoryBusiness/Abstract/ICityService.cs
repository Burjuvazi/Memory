using Memory.Entities.Concrete.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Memory.Business.Abstract
{
    public interface ICityService
    {
        Task<bool> AddCityAsync(CityDto cityDto);
        Task<bool> UpdateCityAsync(CityDto cityDto);
        Task<bool> DeleteCityAsync(CityDto cityDto);
        Task<CityDto> GetCityByIdAsync(int id);
        Task<List<CityDto>> GetAllCityAsync();
        Task<List<CityDto>> GetAllCityByRuleAsync(string cityName);
    }
}
