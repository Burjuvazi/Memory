using AutoMapper;
using Memory.Business.Abstract;
using Memory.Entities.Concrete;
using Memory.Entities.Concrete.Dtos;
using Memory.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Memory.WebUI.Controllers
{
    public class CityController : Controller
    {
        private readonly ICityService _cityService;
        private readonly IMapper _mapper;

        public CityController(ICityService cityService, IMapper mapper)
        {
            _cityService = cityService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            List<CityDto> cities = await _cityService.GetAllCityAsync();
            return View(cities);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(CityDto cityDto)
        {
            bool isTrue = await _cityService.AddCityAsync(cityDto);
            return isTrue ? RedirectToAction("Index") : View();
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            CityDto cityDto = await _cityService.GetCityByIdAsync(id);
            return View(cityDto);
        }
        [HttpPost]
        public async Task<IActionResult> Update(CityDto cityDto)
        {
           bool isTrue = await _cityService.UpdateCityAsync(cityDto);
            return isTrue ? RedirectToAction("Index") : View();
        }
        [HttpGet]
        public async Task<IActionResult> Detail(int id=1)
        {
            CityDto cityDto = await _cityService.GetCityByIdAsync(id);
            return View(cityDto);
        }

       
        public async Task<IActionResult> Delete(int id)
        {
            CityDto cityDto = await _cityService.GetCityByIdAsync(id);
            var response = await _cityService.DeleteCityAsync(cityDto);
            return response ? RedirectToAction("Index") : RedirectToAction("Detail", cityDto.Id);
        }
    }

}
