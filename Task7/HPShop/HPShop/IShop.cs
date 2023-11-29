namespace HPShop
{
    public interface IShop
    {
        string ShowBooks();
        Dictionary<int, (Book book, double price, int numberOfBooks)> AvailableDenominations { get; }
        bool AddBookToBasket(int bookNumber, bool withLogToConsole);
        bool RemoveBookFromBasket(int bookNumber, bool withLogToConsole);
        int GetBookCountInTheShop(int bookID);
        int GetBooksCountInTheShop();
    }
}
