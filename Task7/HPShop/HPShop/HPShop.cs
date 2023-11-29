namespace HPShop
{
    public class HPShop : IShop, IClientBasket
    {
        List<(Book, int number)> _clientBasket;
        readonly List<(Book, double price, int numberOfBooks)> _booksInTheShop;


        public HPShop(List<(Book, double price, int numberOfBooks)> _assortiment)
            => _booksInTheShop = _assortiment;  


        public bool AddBookToBasket(int bookNumber)
        {
            throw new NotImplementedException();
        }


        public double GetDiscount()
        {
            throw new NotImplementedException();
        }

        public double GetOverallPrice()
        {
            throw new NotImplementedException();
        }

        public bool RemoveBookFromBasket(int bookNumber)
        {
            throw new NotImplementedException();
        }

        public List<(Book, int numberOfBooks)> Basket
        {
            get => _clientBasket;
            set => _clientBasket = value;
        }

        public List<(Book, double price, int numberOfBooks)> AvailableDenominations => _booksInTheShop;

        public string ShowBooks()
        {
            throw new NotImplementedException();
        }

        public string ShowBasket()
        {
            throw new NotImplementedException();
        }

        public void InitNewClient()
        {
            _clientBasket = new List<(Book, int numberOfBooks)>();
        }


        public int GetBookCountInTheShop(int bookID)
        {
            throw new NotImplementedException();
        }

        public int GetBooksCountInTheShop()
        {
            throw new NotImplementedException();
        }

        public int GetBooksCountInTheBasket()
        {
            throw new NotImplementedException();
        }
    }
}
