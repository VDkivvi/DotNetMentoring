namespace HPShop.Tests;

public class Tests
{
    HPShop shop;

    [SetUp]
    public void Setup()
    {
        shop = new HPShop(HarryPotterTestDataClass.hpShopBooks);
    }

    [TestCase(1, 4, 4)]
    [TestCase(5, 4, 1)]
    public void AddBookToBasket_add_book_valid_number(int bookId, int number, int diff)
    {
        var beforeAddingBooksToBasket = shop.GetBooksCountInTheShop();
        shop.InitNewClient();
        while (number-- > 0)
            shop.AddBookToBasket(bookId);
        var afterAddingBooksToBasket = shop.GetBooksCountInTheShop();
        Assert.Multiple(() =>
        {
            Assert.That(afterAddingBooksToBasket, Is.EqualTo(beforeAddingBooksToBasket - diff));
        });
        
    }


    [Test]
    public void AddBookToBasket_add_book_valid_number_count_book_by_id()
    {
        var beforeAddingBooksToBasket = shop.GetBookCountInTheShop(1);
        shop.AddBookToBasket(1);
        shop.AddBookToBasket(1);
        shop.AddBookToBasket(2);
        var afterAddingBooksToBasket = shop.GetBookCountInTheShop(1);
        Assert.That(afterAddingBooksToBasket, Is.EqualTo(beforeAddingBooksToBasket - 2));
    }


    [Test]
    public void AddBookToBasket_add_book_valid_number_out_of_stock()
    {
        shop.AddBookToBasket(5);
        var overallBooks = shop.GetBooksCountInTheShop();
        var successAdding = shop.AddBookToBasket(5);
        var overallBooksAfter = shop.GetBooksCountInTheShop();
        var booksOfId = shop.GetBookCountInTheShop(5);
        Assert.Multiple(() =>
        {
            Assert.That(overallBooks, Is.EqualTo(overallBooksAfter));
            Assert.That(booksOfId, Is.EqualTo(0));
            Assert.That(successAdding, Is.False);
        });
    }

    [Test]
    public void AddBookToBasket_add_book_invalid_number()
    {
        var booksCountBefore = shop.GetBooksCountInTheShop();
        var successAdding = shop.AddBookToBasket(15);
        var booksCountAfter = shop.GetBooksCountInTheShop();
        Assert.Multiple(() =>
        {
            Assert.That(booksCountAfter, Is.EqualTo(booksCountBefore));
            Assert.That(successAdding, Is.False);
        });
    }


    [Test]
    public void FormBasket_remove_existing_book()
    {
        shop.AddBookToBasket(0);
        shop.AddBookToBasket(0);
        shop.AddBookToBasket(1);
        var booksCountBefore = shop.GetBooksCountInTheShop();
        var bookIdCountBefore = shop.GetBookCountInTheShop(0);
        var successRemoving = shop.RemoveBookFromBasket(0);
        var booksCountAfter = shop.GetBooksCountInTheShop();
        var bookIdCountAfter = shop.GetBookCountInTheShop(0);
        Assert.Multiple(() =>
        {
            Assert.That(booksCountAfter, Is.EqualTo(booksCountBefore + 1));
            Assert.That(bookIdCountAfter, Is.EqualTo(bookIdCountBefore + 1));
            Assert.That(successRemoving, Is.True);
        });
    }

    [Test]
    public void FormBasket_remove_non_existing_book()
    {
        shop.AddBookToBasket(0);
        shop.AddBookToBasket(0);
        var booksCountBefore = shop.GetBooksCountInTheShop();
        var bookIdCountBefore = shop.GetBookCountInTheShop(0);
        var removeResult = shop.RemoveBookFromBasket(10);
        var booksCountAfter = shop.GetBooksCountInTheShop();
        var bookIdCountAfter = shop.GetBookCountInTheShop(0);

        Assert.Multiple(() =>
        {
            Assert.That(booksCountAfter, Is.EqualTo(booksCountBefore));
            Assert.That(bookIdCountAfter, Is.EqualTo(bookIdCountBefore));
            Assert.That(removeResult, Is.False);
        });
    }

    [Test]
    public void Books_list_not_null()
    {
        shop = new HPShop(HarryPotterTestDataClass.hpShopBooks_2_book_titles);
        Assert.That(shop.AvailableDenominations.Count(), Is.EqualTo(2));
        shop.AddBookToBasket(0);
        shop.AddBookToBasket(0);
        Assert.That(shop.AvailableDenominations.Count(), Is.EqualTo(1));
        shop.RemoveBookFromBasket(0);
        Assert.That(shop.AvailableDenominations.Count(), Is.EqualTo(2));
    }


    [Test]
    public void ShowBooks()
    {
        shop = new HPShop(HarryPotterTestDataClass.hpShopBooks_2_book_titles);
        shop.AddBookToBasket(0);
        shop.AddBookToBasket(0);
        shop.AddBookToBasket(1);
        Assert.That(shop.ShowBooks(), Is.EqualTo(string.Empty));
    }
}