namespace HPShop
{
    public interface IClientBasket
    {
        void InitNewClient();
        void ClearBasket();
        string ShowBasket();
        Dictionary<int, (Book book, double price, int numberOfBooks)> Basket { get; set; }
        double GetDiscount();
        double GetOverallPrice();
        int GetBooksCountInTheBasket();
    }
}
