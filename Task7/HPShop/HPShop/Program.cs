using static System.Int32;

namespace HPShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<(Book, double price, int numberOfBooks)> hpShopBooks = new()
            {
                (new Book("Harry Potter and the Philosopher's Stone"), 8, 100),
                (new Book("Harry Potter and the Chamber of Secrets"), 8, 100),
                (new Book("Harry Potter and the Prisoner of Azkaban"), 8, 100),
                (new Book("Harry Potter and the Goblet of Fire"), 8, 100),
                (new Book("Harry Potter and the Order of the Phoenix"), 8, 100),
                (new Book("Harry Potter and the Half-Blood Prince"), 8, 1),
                (new Book("Harry Potter and the Deathly Hallows"), 8, 10)
            };


        var shop = new HPShop(hpShopBooks);
            shop.InitNewClient();
            Console.WriteLine("Welcome To Harry Potter shop!");
            Console.WriteLine($"This is the list of our available books:\n{shop.ShowBooks()}");
            Console.WriteLine("What do you want to do?");
            string? command = Console.ReadLine();
            while (command != "exit")
            {
                if (command == null)
                {
                    Console.WriteLine("Write some command: Add {bookId}, Remove {bookId}, exit");
                }
                else if (command.StartsWith("Add") && TryParse(command.Split("Add ")[1], out int bookIdAdd))
                {
                    shop.AddBookToBasket(bookIdAdd);
                    Console.WriteLine($"Books in the basket:\n{shop.ShowBasket()}");
                    Console.WriteLine($"********************************");
                    Console.WriteLine($"Still available:\n{shop.ShowBooks()}");
                }
                else if (command.StartsWith("Remove") && TryParse(command.Split("Remove ")[1], out var bookIdRemove))
                {
                    shop.RemoveBookFromBasket(bookIdRemove);
                    Console.WriteLine($"Books in the basket:\n{shop.ShowBasket()}");
                    Console.WriteLine($"********************************");
                    Console.WriteLine($"Still available:\n{shop.ShowBooks()}");
                }
                else if (command.Equals("Clear"))
                {
                    shop.ClearBasket();
                    Console.WriteLine($"Still available:\n{shop.ShowBooks()}");
                    Console.WriteLine($"********************************");
                }

                Console.WriteLine("What do you want to do next? Commands: Buy {bookId}, Remove {bookId}, exit");
                command = Console.ReadLine();
            }
        }
    }
}