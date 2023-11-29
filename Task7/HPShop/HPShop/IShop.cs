namespace HPShop
{
    public interface IShop
    {
        string ShowBooks();
        List<(Book, double price, int numberOfBooks)> AvailableDenominations { get; }
        bool AddBookToBasket(int bookNumber);
        bool RemoveBookFromBasket(int bookNumber);
        int GetBookCountInTheShop(int bookID);
        int GetBooksCountInTheShop();
    }
}
