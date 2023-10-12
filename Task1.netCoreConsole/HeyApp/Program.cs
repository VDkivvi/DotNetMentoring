using CommandLine;
using MessageFormer;

namespace HeyApp;
internal class Program
{
    static void Main(string[] args)
    {
        Parser.Default.ParseArguments<Options>(args)
            .WithParsed(o => Console.WriteLine(new StringMessage().FormMessage(o.UserName)));
    }
}

public class Options
{
    [Option('n', "name", Required = true, HelpText = "name of the person")]
    public required string UserName { get; set; }
}