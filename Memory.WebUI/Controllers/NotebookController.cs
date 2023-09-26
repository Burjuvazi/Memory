using Memory.Business.Abstract;
using Memory.DataAccess.Concrete.EntityFrameWork;
using Memory.Entities.Concrete.Dtos;
using Memory.WebUI.BasketTransaction;
using Memory.WebUI.BasketTransaction.BasketModels;
using Microsoft.AspNetCore.Mvc;

namespace Memory.WebUI.Controllers
{
    public class NotebookController : Controller
    {
        private readonly INotebookService _notebookService;
        private readonly ICityService _cityService;
        private readonly IBasketTransaction _basketTransaction;

        public NotebookController(INotebookService notebookService, ICityService cityService, IBasketTransaction basketTransaction)
        {
            _notebookService = notebookService;
            _cityService = cityService;
            _basketTransaction = basketTransaction;
        }
        public async Task<IActionResult> Index()
        {
            List<NotebookDto> notebooks = await _notebookService.GetAllNoteBookAsync();
            return View(notebooks);
        }
        public async Task<IActionResult> Detail(int id)
        {
            NotebookDto notebookDto = await _notebookService.GetNoteBookByIdAsync(id);
            ViewBag.Sehir = (await _cityService.GetCityByIdAsync(notebookDto.CityId)).Name;
            return View(notebookDto);
        }
        [HttpGet]
        public async Task<IActionResult> AddBasketItem(int id)
        {
            NotebookDto notebookDto = await _notebookService.GetNoteBookByIdAsync(id);
            if (notebookDto != null)
            {
                BasketItemDto basketItemDto = new BasketItemDto()
                {
                    Content = notebookDto.Content,
                    NotebookId = notebookDto.Id,
                    Price = notebookDto.Price,
                    Title = notebookDto.Title,
                    Quantity = 1
                };
                _basketTransaction.SaveUpdateBasketItem(basketItemDto);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Add(NotebookDto notebookDto)
        {
            bool response = await _notebookService.AddNotebookAsync(notebookDto);
            return response ? RedirectToAction("Index") : View();
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            NotebookDto notebookDto = await _notebookService.GetNoteBookByIdAsync(id);
            return View(notebookDto);
        }
        [HttpPost]
        public async Task<IActionResult> Update(NotebookDto notebookDto)
        {
            bool isTrue = await _notebookService.UpdateNotebookAsync(notebookDto);
            return isTrue ? RedirectToAction("Index") : View();
        }
        public async Task<IActionResult> Delete(int id)
        {
            NotebookDto notebookDto = await _notebookService.GetNoteBookByIdAsync(id);
            var response = await _notebookService.DeleteNotebookAsync(notebookDto);
            return response ? RedirectToAction("Index") : RedirectToAction("Detail", notebookDto.Id);
        }

    }

}
