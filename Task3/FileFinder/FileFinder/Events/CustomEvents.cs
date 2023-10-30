namespace FileFinder.Events
{
    internal class CustomEvents
    {
        internal virtual void Notify_event(EventHandler? ev, ConsoleNotifyEventArgs e)
        {
            if (ev == null) return;
            e.Message += $" at {DateTime.Now}";
            Console.WriteLine(e.Message);
            ev(this, e);
        }


        internal virtual void Prompt_event(EventHandler? ev, PromptFileEventArgs e)
        {
            if (ev == null) return;
            Console.WriteLine("Do you want to continue search?");
            var yesNoContinue = Console.ReadLine();
            e.StopSearch = yesNoContinue == null || yesNoContinue.ToLower() == "no";

            Console.WriteLine($"Do you want to exclude this file from the final list? {e.File}");
            var yesNoExclude = Console.ReadLine();
            e.ExcludeFromSearch = yesNoExclude == null || yesNoExclude.ToLower() == "yes";
            ev(this, e);
        }
    }
}
