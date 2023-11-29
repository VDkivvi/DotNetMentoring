namespace HPShop.Tests
{
    public class HarryPotterTestDataClass
    {
        public const double priceOfBooks = 8;
        public static List<(Book, double price, int numberOfBooks)> hpShopBooks = new()
        {
            (new Book("Harry Potter and the Philosopher's Stone"), priceOfBooks, 100),
            (new Book("Harry Potter and the Chamber of Secrets"), priceOfBooks, 100),
            (new Book("Harry Potter and the Prisoner of Azkaban"), priceOfBooks, 100),
            (new Book("Harry Potter and the Goblet of Fire"), priceOfBooks, 100),
            (new Book("Harry Potter and the Order of the Phoenix"), priceOfBooks, 100),
            (new Book("Harry Potter and the Half-Blood Prince"), priceOfBooks, 1),
            (new Book("Harry Potter and the Deathly Hallows"), priceOfBooks, 10)
        };

        public static List<(Book, double price, int numberOfBooks)> hpShopBooks_2_book_titles = new()
        {
            (new Book("Harry Potter and the Philosopher's Stone"), priceOfBooks, 2),
            (new Book("Harry Potter and the Half-Blood Prince"), priceOfBooks, 1),
        };

        public static new List<(Book, int numberOfBooks)> basket_no_disc = new()
        {
            (new Book("Harry Potter and the Philosopher's Stone"), 1),
            (new Book("Harry Potter and the Chamber of Secrets"), 14),
        };

        public static new List<(Book, int numberOfBooks)> basket_10_pers_disc = new()
        {
            (new Book("Harry Potter and the Philosopher's Stone"), 1),
            (new Book("Harry Potter and the Chamber of Secrets"), 3),
            (new Book("Harry Potter and the Prisoner of Azkaban"), 5)
        };


        public static new List<(Book, int numberOfBooks)> basket_20_pers_disc = new()
        {
            (new Book("Harry Potter and the Philosopher's Stone"), 1),
            (new Book("Harry Potter and the Chamber of Secrets"), 4),
            (new Book("Harry Potter and the Prisoner of Azkaban"), 1),
            (new Book("Harry Potter and the Goblet of Fire"), 10)
        };


        public static new List<(Book, int numberOfBooks)> basket_25_pers_disc1 = new()
        {
            (new Book("Harry Potter and the Philosopher's Stone"), 4),
            (new Book("Harry Potter and the Chamber of Secrets"), 2),
            (new Book("Harry Potter and the Prisoner of Azkaban"), 1),
            (new Book("Harry Potter and the Half-Blood Prince"), 1),
            (new Book("Harry Potter and the Goblet of Fire"), 10)
        };

        public static new List<(Book, int numberOfBooks)> basket_25_pers_disc2 = new()
        {
            (new Book("Harry Potter and the Philosopher's Stone"), 4),
            (new Book("Harry Potter and the Chamber of Secrets"), 2),
            (new Book("Harry Potter and the Prisoner of Azkaban"), 1),
            (new Book("Harry Potter and the Half-Blood Prince"), 1),
            (new Book("Harry Potter and the Goblet of Fire"), 10),
            (new Book("Harry Potter and the Deathly Hallows"), 1)
        };
    }
}
