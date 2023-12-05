using System.Text;

namespace HPShop
{
    public class HPShop : IShop, IClientBasket
    {
        private Dictionary<int, (Book book, double price, int numberOfBooks)> _clientBasket = new();
        private readonly Dictionary<int, (Book book, double price, int numberOfBooks)> _booksInTheShop = new();


        public HPShop(List<(Book book, double price, int numberOfBooks)> assortment)
        {
            var ind = 0;
            assortment.ForEach(x => _booksInTheShop.Add(ind++, x));
        }

        public bool AddBookToBasket(int bookNumber, bool withConsoleLog = true)
        {
            if (_booksInTheShop.ContainsKey(bookNumber))
            {
                var (book, price, numberOfBooks) = _booksInTheShop[bookNumber];
                if (numberOfBooks == 0)
                {
                    Console.WriteLine($"MESSAGE: Unfortunately, the book \'{book.Title}\' is out of stock now. You can add it to waiting list (actually not).");
                    Console.WriteLine("**************************");
                    return false;
                }
                if (_clientBasket.ContainsKey(bookNumber))
                {
                    var newNumb = _clientBasket[bookNumber].numberOfBooks;
                    _clientBasket[bookNumber] = (_clientBasket[bookNumber].book, _clientBasket[bookNumber].price, newNumb + 1);
                }
                else
                {
                    _clientBasket.Add(bookNumber, (book, price, 1));
                }
                _booksInTheShop[bookNumber] = (_booksInTheShop[bookNumber].book, _booksInTheShop[bookNumber].price, numberOfBooks - 1);

                return true;
            }

            if (!withConsoleLog)
                return false;
            Console.WriteLine("ERROR MESSAGE: You set wrong book ID, try again");
            Console.WriteLine("**************************");
            return false;
        }


        public double GetDiscount()
        {
            var countTitles = _clientBasket.Count();
            return countTitles switch
            {
                < 3 => 0,
                3 => 0.1,
                4 => 0.2,
                >= 3 => 0.25
            };
        }

        public double GetOverallPrice()
        {
            var numbWithDiscount = _clientBasket.Count <= 5 ? _clientBasket.Count : 5;
            var discount = GetDiscount();

            //as we try to help the customer get the highest benefit with the purchase, we select the most expensive books and apply the discount for them?

            var totalWithDiscount = _clientBasket.OrderByDescending(x => x.Value.price).Take(numbWithDiscount)
                .Aggregate(0d, (current, next)
                    => current + next.Value.price * (next.Value.numberOfBooks - discount));

            var other = _clientBasket.OrderByDescending(x => x.Value.price).Skip(numbWithDiscount)
                    .Aggregate(0d, (current, next) => current + next.Value.price);

            return totalWithDiscount + other;
        }

        public bool RemoveBookFromBasket(int bookNumber, bool withConsoleLog = true)
        {
            if (_clientBasket.ContainsKey(bookNumber))
            {
                var bookInShop = _booksInTheShop[bookNumber];
                var bookInBasket = _clientBasket[bookNumber];
                if (bookInBasket.numberOfBooks == 1)
                    _clientBasket.Remove(bookNumber);
                else
                    _clientBasket[bookNumber] = (bookInBasket.book, bookInBasket.price, bookInBasket.numberOfBooks - 1);
                
                _booksInTheShop[bookNumber] = (bookInShop.book, bookInShop.price, bookInShop.numberOfBooks + 1);
                return true;
            }

            if (!withConsoleLog) return false;

            Console.WriteLine($"ERROR MESSAGE: It seems you are trying to remove non existing item. Available numbers: {string.Join(",", _clientBasket.Keys)}");
            Console.WriteLine("****************************************");
            return false;
        }

        public Dictionary<int, (Book book, double price, int numberOfBooks)> Basket
        {
            get => _clientBasket;
            set => _clientBasket = value;
        }

        public Dictionary<int, (Book book, double price, int numberOfBooks)> AvailableDenominations => _booksInTheShop;


        public string ShowBooks()
        {
            return string.Join(Environment.NewLine, _booksInTheShop.Select(b => $"{b.Key}: \'{b.Value.book.Title}\'({b.Value.price}$). Available amount {b.Value.numberOfBooks}"));
        }

        public string ShowBasket()
        {
            var content = string.Join(Environment.NewLine, _clientBasket.Select(b => $"{b.Key}: \'{b.Value.book.Title}\'({b.Value.price}$). Available amount {b.Value.numberOfBooks}"));
            var basket = new StringBuilder().AppendLine();
            basket.Append(content);
            basket.AppendLine();
            basket.AppendLine($"You've got the discount: {GetDiscount()}.");
            basket.AppendLine($"Total price: {GetOverallPrice()}.");
            basket.AppendLine();
            return basket.ToString();
        }

        public void InitNewClient() 
            => _clientBasket = new Dictionary<int, (Book book, double price, int numberOfBooks)>();

        public void ClearBasket()
        {
            foreach (var bookId in _clientBasket.Keys)
            {
                var numb = _clientBasket[bookId].numberOfBooks;

                while (numb-- > 0)
                    RemoveBookFromBasket(bookId, false);
            }
        }


        public int GetBookCountInTheShop(int bookId)
        {
            if (!_booksInTheShop.ContainsKey(bookId))
                throw new IndexOutOfRangeException(nameof(bookId));
            return _booksInTheShop[bookId].numberOfBooks;
        }


        public int GetBooksCountInTheShop()
        {
            return _booksInTheShop.Values.Aggregate(0, (curr, next) => curr + next.numberOfBooks);
        }

        public int GetBooksCountInTheBasket()
        {
            return _clientBasket.Values.Aggregate(0, (curr, next) => curr + next.numberOfBooks);
        }
    }
}
