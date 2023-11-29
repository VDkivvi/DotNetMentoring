namespace HPShop.Tests
{
    public class HarryPotterTestDataClass
    {
        public const double PriceOfBooks = 8;
        public static List<(Book book, double price, int numberOfBooks)> hpShopBooks = new()
        {
            (new Book("Harry Potter and the Philosopher's Stone"),PriceOfBooks, 100),
            (new Book("Harry Potter and the Chamber of Secrets"),  PriceOfBooks, 100),
            (new Book("Harry Potter and the Prisoner of Azkaban"), PriceOfBooks, 100),
            (new Book("Harry Potter and the Goblet of Fire"), PriceOfBooks, 100),
            (new Book("Harry Potter and the Order of the Phoenix"), PriceOfBooks, 100),
            (new Book("Harry Potter and the Half-Blood Prince"), PriceOfBooks, 1),
            (new Book("Harry Potter and the Deathly Hallows"), PriceOfBooks, 10)
        };

        public static List<(Book book, double price, int numberOfBooks)> hpShopBooks_2_book_titles = new()
        {
            (new Book("Harry Potter and the Philosopher's Stone"),PriceOfBooks, 2),
            (new Book("Harry Potter and the Half-Blood Prince"), PriceOfBooks, 1),
        };

        public static Dictionary<int, (Book book, double price, int numberOfBooks)> basket_no_disc = new()
        {
            [0] = (new Book("Harry Potter and the Philosopher's Stone"), 8, 1),
            [1] = (new Book("Harry Potter and the Chamber of Secrets"),  8, 14),
        };

        public static Dictionary<int, (Book book, double price, int numberOfBooks)> basket_10_pers_disc = new()
        {
            [0] = (new Book("Harry Potter and the Philosopher's Stone"), 8, 1),
            [1] = (new Book("Harry Potter and the Chamber of Secrets"),  8, 3),
            [2] = (new Book("Harry Potter and the Prisoner of Azkaban"), 8, 5)
        };


        public static Dictionary<int, (Book book, double price, int numberOfBooks)> basket_20_pers_disc = new()
        {
            [0] = (new Book("Harry Potter and the Philosopher's Stone"), 8, 1),
            [1] = (new Book("Harry Potter and the Chamber of Secrets"), 8, 4),
            [2] = (new Book("Harry Potter and the Prisoner of Azkaban"), 8, 1),
            [3] = (new Book("Harry Potter and the Goblet of Fire"), 8, 10)
        };


        public static Dictionary<int, (Book book, double price, int numberOfBooks)> basket_25_pers_disc1 = new()
        {
            [0] = (new Book("Harry Potter and the Philosopher's Stone"), 8, 4),
            [1] = (new Book("Harry Potter and the Chamber of Secrets"), 8, 2),
            [2] = (new Book("Harry Potter and the Prisoner of Azkaban"), 8, 1),
            [3] = (new Book("Harry Potter and the Half-Blood Prince"), 8, 1),
            [4] = (new Book("Harry Potter and the Goblet of Fire"), 8, 10)
        };

        public static Dictionary<int, (Book book, double price, int numberOfBooks)> basket_25_pers_disc2 = new()
        {
            [0] = (new Book("Harry Potter and the Philosopher's Stone"), 8, 4),
            [1] = (new Book("Harry Potter and the Chamber of Secrets"), 8, 2),
            [2] = (new Book("Harry Potter and the Prisoner of Azkaban"), 8, 1),
            [3] = (new Book("Harry Potter and the Half-Blood Prince"), 8, 1),
            [4] = (new Book("Harry Potter and the Goblet of Fire"), 8, 10),
            [5] = (new Book("Harry Potter and the Deathly Hallows"), 8, 1)
        };
    }
}
