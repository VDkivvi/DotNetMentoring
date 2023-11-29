namespace HPShop
{
    public interface IClientBasket
    {
        void InitNewClient();
        string ShowBasket();
        List<(Book, int numberOfBooks)> Basket { get; set; }
        double GetDiscount();
        double GetOverallPrice();
        int GetBooksCountInTheBasket();
    }
}
