namespace FileFinder.Events
{
    public class ConsoleNotifyEventArgs : EventArgs
    {
        public ConsoleNotifyEventArgs(string message, params object?[] args) 
            => Message = string.Format(message, args);

        public string Message { get; set; }
    }


    public class PromptFileEventArgs : EventArgs
    {
        public bool StopSearch { get; set; }
        public bool ExcludeFromSearch { get; set; }
        public string? File { get; set; }
    }
}