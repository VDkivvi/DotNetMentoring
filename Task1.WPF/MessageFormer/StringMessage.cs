using System;

namespace MessageFormer
{
    public class StringMessage : IMessage
    {
        public string FormMessage(string userName)
        {
            return $"{DateTime.Now:dd/MM/yyyy hh:ss}. Hello, {userName}.";
        }
    }
}
