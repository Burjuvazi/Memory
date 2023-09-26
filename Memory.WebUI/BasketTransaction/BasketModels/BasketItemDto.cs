namespace Memory.WebUI.BasketTransaction.BasketModels
{
    public class BasketItemDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int NotebookId { get; set; }
    }
}
