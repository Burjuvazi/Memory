using Memory.WebUI.BasketTransaction.BasketModels;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Memory.WebUI.BasketTransaction
{
    public class BasketTransaction : IBasketTransaction
    {
        const string basketName = "basket";
        private readonly IHttpContextAccessor _httpContextAccessor;
        HttpContext _context;

        public BasketTransaction(IHttpContextAccessor httpContextAccessor)
        {

            _httpContextAccessor = httpContextAccessor;
        }
        public BasketDto GetOrCreateBasket()
        {
            bool response = _httpContextAccessor.HttpContext.Request.Cookies.ContainsKey(basketName);
            return response ? JsonConvert.DeserializeObject<BasketDto>(_context.Request.Cookies[basketName]) : new BasketDto() { BasketItems = new List<BasketItemDto>() };
        }
        public void SaveUpdateBasketItem(BasketItemDto basketItem)
        {
            BasketDto basketDto = GetOrCreateBasket();
            if (basketDto.BasketItems.Any(x => x.NotebookId == basketItem.NotebookId))
            {
                BasketItemDto basketItemDto = basketDto.BasketItems.FirstOrDefault(x => x.NotebookId == basketItem.NotebookId);
                basketItemDto.Quantity += 1;
            }
            else basketDto.BasketItems.Add(basketItem);
            {
                string basketSerialize = JsonConvert.SerializeObject(basketDto);
                _httpContextAccessor.HttpContext.Response.Cookies.Append(basketName, basketSerialize);
            }
        }
        public void RemoveOrDecrease(int notebookId)
        {
            bool response = _httpContextAccessor.HttpContext.Request.Cookies.ContainsKey(basketName);
            if (response)
            {
                BasketDto basketDto = GetOrCreateBasket();
                foreach (var item in basketDto.BasketItems)
                {
                    if (item.NotebookId == notebookId && item.Quantity > 1)
                        item.Quantity -= 1;
                    else basketDto.BasketItems.Remove(item);                   
                }
                string basketSerialize = JsonConvert.SerializeObject(basketDto);
                _httpContextAccessor.HttpContext.Response.Cookies.Append(basketName, basketSerialize);
            }
        }
        public void DeleteItem(int notebookId)
        {
            bool response = _httpContextAccessor.HttpContext.Request.Cookies.ContainsKey(basketName);
            if (response)
            {
                BasketDto basketDto = GetOrCreateBasket();
                BasketItemDto basketItemDto = basketDto.BasketItems.FirstOrDefault(x=>x.NotebookId == notebookId);
                basketDto.BasketItems.Remove(basketItemDto);
                string basketSerialize = JsonConvert.SerializeObject(basketDto);
                _httpContextAccessor.HttpContext.Response.Cookies.Append(basketName, basketSerialize);
            }
        }
        public void DeleteBasket()
        {
            _httpContextAccessor.HttpContext.Response.Cookies.Delete(basketName);
        }

       



    }
}
