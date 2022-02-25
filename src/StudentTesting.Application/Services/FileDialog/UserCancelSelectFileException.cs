using System;

namespace StudentTesting.Application.Services.FileDialog
{
    public class UserCancelSelectFileException : Exception
    {
        public UserCancelSelectFileException() { }
        public UserCancelSelectFileException(string message) : base(message) { }
        public UserCancelSelectFileException(string message, Exception inner) : base(message, inner) { }
    }
}
