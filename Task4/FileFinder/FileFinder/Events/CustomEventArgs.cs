namespace FileFinder.Events
{
    public class CustomEventArgs : EventArgs
    {
        public CustomEventArgs(string message) 
            => Message = message;

        public string Message { get; set; }
    }

    public class PromptFileEventArgs : EventArgs
    {
        public PromptFileEventArgs(string file) 
            => File = file;

        public bool StopSearch { get; set; }
        public bool ExcludeFromSearch { get; set; }
        public string File { get; }
    }
}