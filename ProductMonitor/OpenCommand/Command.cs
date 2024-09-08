using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProductMonitor.OpenCommand
{
    public class Command : ICommand
    {
        private Action action;
        public event EventHandler? CanExecuteChanged;

        public Command(Action action)
        {

            this.action = action;
        }
        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (action == null)
            {
                action();

            }
        }
    }
}
