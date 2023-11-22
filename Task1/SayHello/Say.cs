using System;

namespace SayHello
{
    public static class Say
    {
        public static string GetGreetings(string userName)
            => $"{DateTime.Now: MM/dd/yyyy HH:ss}. Hello, {userName}!";
    }
}
