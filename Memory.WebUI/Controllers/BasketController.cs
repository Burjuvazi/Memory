using Memory.Business.Abstract;
using Memory.WebUI.BasketTransaction;
using Memory.WebUI.BasketTransaction.BasketModels;
using Microsoft.AspNetCore.Mvc;

namespace Memory.WebUI.Controllers
{
    public class BasketController : Controller
    {
        private readonly IBasketTransaction _basketTransaction;
        private readonly INotebookService _notebookService;

        public BasketController(IBasketTransaction basketTransaction, INotebookService notebookService)
        {
            _basketTransaction = basketTransaction;  
            _notebookService = notebookService;
        }
        public IActionResult Basket() 
        {
            BasketDto basketDto = _basketTransaction.GetOrCreateBasket();
            return View(basketDto);
        }
        [HttpGet]
        public IActionResult DecreaseQuantity(int notebookId) 
        {
            _basketTransaction.RemoveOrDecrease(notebookId);
            return RedirectToAction("Basket");
        }
        [HttpGet]
        public IActionResult DeleteItem(int id)
        {
            _basketTransaction.DeleteItem(id);
            return RedirectToAction("Basket");
        }

    }
}
