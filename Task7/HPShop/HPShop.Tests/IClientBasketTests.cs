namespace HPShop.Tests
{
    internal class IClientBasketTests
    {
        HPShop shop;

        static IEnumerable<(Dictionary<int, (Book book, double price, int numberOfBooks)>, double)> TestCasesGetPrice()
        {
            double price = HarryPotterTestDataClass.PriceOfBooks;
            yield return (HarryPotterTestDataClass.basket_no_disc, price * 15);
            yield return (HarryPotterTestDataClass.basket_10_pers_disc, price * (0.9 * 3 + 6));
            yield return (HarryPotterTestDataClass.basket_20_pers_disc, price * (0.8 * 4 + 12));
            yield return (HarryPotterTestDataClass.basket_25_pers_disc1, price * (0.75 * 5 + 13));
        }

        static IEnumerable<(Dictionary<int, (Book book, double price, int numberOfBooks)>, double)> TestCasesGetDiscount()
        {
            yield return (HarryPotterTestDataClass.basket_no_disc, 0);
            yield return (HarryPotterTestDataClass.basket_10_pers_disc, 0.1);
            yield return (HarryPotterTestDataClass.basket_20_pers_disc, 0.2);
            yield return (HarryPotterTestDataClass.basket_25_pers_disc1, 0.25);
            yield return (HarryPotterTestDataClass.basket_25_pers_disc2, 0.25);
        }

        [SetUp]
        public void Setup()
        {
            shop = new HPShop(HarryPotterTestDataClass.hpShopBooks);
        }


        [TestCaseSource(nameof(TestCasesGetPrice))]
        public void AddBookToBasket_get_price((Dictionary<int, (Book book, double price, int numberOfBooks)> whatInTheBasket, double expectedPrice) td)
        {
            shop.Basket = td.whatInTheBasket;
            var price = shop.GetOverallPrice();
            Assert.That(price, Is.EqualTo(td.expectedPrice));
        }

        [TestCaseSource(nameof(TestCasesGetDiscount))]
        public void AddBookToBasket_get_discount((Dictionary<int, (Book book, double price, int numberOfBooks)> whatInTheBasket, double expectedDiscount) td)
        {
            shop.Basket = td.whatInTheBasket;
            var discount = shop.GetDiscount();
            Assert.That(discount, Is.EqualTo(td.expectedDiscount));
        }

        [Test]
        public void AddBookToBasket_add_book_invalid_number()
        {
            var booksInBasket = shop.GetBooksCountInTheBasket();
            var successAdding = shop.AddBookToBasket(15);
            var booksInBasketAfter = shop.GetBooksCountInTheBasket();
            Assert.Multiple(() =>
            {
                Assert.That(booksInBasket, Is.EqualTo(booksInBasketAfter));
                Assert.That(successAdding, Is.False);
            });
        }

        [Test]
        public void AddBookToBasket_add_book_valid_number_out_of_stock()
        {
            shop.AddBookToBasket(5);
            var booksInBasket = shop.GetBooksCountInTheBasket();
            var successAdding = shop.AddBookToBasket(5);
            var booksInBasketAfter = shop.GetBooksCountInTheBasket();
            Assert.Multiple(() =>
            {
                Assert.That(booksInBasket, Is.EqualTo(booksInBasketAfter));
                Assert.That(successAdding, Is.False);
            });
        }

        [Test]
        public void FormBasket_remove_existing_book()
        {
            shop.AddBookToBasket(0);
            shop.AddBookToBasket(0);
            shop.AddBookToBasket(1);
            shop.RemoveBookFromBasket(0);
            var afterNumbOfBooksInBusket = shop.GetBooksCountInTheBasket();
            Assert.That(afterNumbOfBooksInBusket, Is.EqualTo(2));
        }

        [Test]
        public void FormBasket_remove_non_existing_book()
        {
            shop.AddBookToBasket(0);
            shop.AddBookToBasket(0);
            shop.AddBookToBasket(1);
            var removeResult = shop.RemoveBookFromBasket(10);
            var afterNumbOfBooksInBusket = shop.GetBooksCountInTheBasket();
            Assert.Multiple(() =>
            {
                Assert.That(afterNumbOfBooksInBusket, Is.EqualTo(3));
                Assert.That(removeResult, Is.EqualTo(false));
            });
        }

        [Test]
        public void ClearBasket_remove_non_existing_book()
        {
            shop.AddBookToBasket(0);
            shop.AddBookToBasket(0);
            shop.AddBookToBasket(1);
            shop.ClearBasket();
            Assert.That(shop.GetBooksCountInTheBasket(), Is.EqualTo(0));
        }

        [Test]
        public void ShowBooksInBasket()
        {
            shop = new HPShop(HarryPotterTestDataClass.hpShopBooks_2_book_titles);
            Assert.That(string.IsNullOrEmpty(shop.ShowBasket()), Is.False);
            shop.AddBookToBasket(0);
            shop.AddBookToBasket(0);
            shop.AddBookToBasket(1);
            Assert.That(string.IsNullOrEmpty(shop.ShowBasket()), Is.False);
        }
    }
}
