using Memory.Business.Abstract;
using Memory.Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Memory.WebUI.ViewComponents
{
    public class CityListComponent :  ViewComponent
    {
        private readonly ICityService _cityService;

        public CityListComponent(ICityService cityService)
        {
            _cityService = cityService;   
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<CityDto> cityDtos = await _cityService.GetAllCityAsync();
            return View(cityDtos);
        }
    }
    
}
