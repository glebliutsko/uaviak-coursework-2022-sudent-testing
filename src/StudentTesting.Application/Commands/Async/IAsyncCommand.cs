﻿using System.Threading.Tasks;
using System.Windows.Input;

namespace StudentTesting.Application.Commands.Async
{
    interface IAsyncCommand : ICommand
    {
        public bool IsRunning { get; }
        public Task ExecuteAsync(object parameter);
    }
}
