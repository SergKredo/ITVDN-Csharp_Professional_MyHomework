using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Currency_Info.ViewModels.Commands
{
    public class AsyncCommand : AsyncCommandBase
    {
        private readonly Func<Task> command;
        public AsyncCommand(Func<Task> command)
        {
            this.command = command;
        }
        public override bool CanExecute(object parameter)
        {
            return true;
        }
        public override Task ExecuteAsync(object parameter)
        {
            return command();
        }
    }
}
