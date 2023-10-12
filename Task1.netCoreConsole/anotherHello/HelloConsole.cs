namespace HelloWorld
{
    public class HelloConsole: IHell
    {
        public void WriteOutput(string username) 
            => Console.WriteLine($"{DateTime.Now:0:MM/dd/yy H:mm:ss} Hello, {username}!");
    }
}