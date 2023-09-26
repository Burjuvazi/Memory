using Memory.WebUI.BasketTransaction.BasketModels;

namespace Memory.WebUI.BasketTransaction
{
    public interface IBasketTransaction 
    {
        BasketDto GetOrCreateBasket();
        void SaveUpdateBasketItem(BasketItemDto basketItemDto);
        void RemoveOrDecrease(int notebookId);
        void DeleteItem(int notebookId);
        void DeleteBasket();
    }
}
