//#nullable enable
using System;
using System.Threading.Tasks;


namespace Task3
{
    public class InvalidOperationException : Exception
    {
        public InvalidOperationException() {}

        public InvalidOperationException(string message) : base(message) {}
    }

    public static class UserErrors
    {
        public static void CheckUser(object argument)
        {
            switch (argument)
            {
                case null:
                    throw new UserNotFoundException();
                case <= 0:
                    throw new InvalidUserIdException();
            }
        }

        public static void CheckTasks(string actual, string exp)
        {
            if (string.Equals(actual, exp, StringComparison.OrdinalIgnoreCase))
                throw new AlreadyExistingTaskException();
        }
    }

    public class UserNotFoundException : InvalidOperationException
    {
        public override string Message => "User not found";
    }

    public class InvalidUserIdException : InvalidOperationException
    {
        public override string Message => "Invalid userId";
    }

    public class AlreadyExistingTaskException : InvalidOperationException
    {
        public override string Message => "The task already exists";
    }
}
