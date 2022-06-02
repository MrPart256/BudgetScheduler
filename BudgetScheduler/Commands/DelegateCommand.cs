using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace BudgetScheduler.Commands
{
    internal class DelegateCommand : ICommand
    {
        public DelegateCommand(Action executeMethod)
        {
            this._executeMethod = executeMethod;
        }

        public DelegateCommand(Action executeMethod, Func<bool> canExecute)
        {
            this._executeMethod = executeMethod;
            this._canExecuteMethod = canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return _canExecuteMethod != null ? _canExecuteMethod() : true;
        }

        public void Execute(object parameter)
        {
            _executeMethod?.Invoke();
        }

        private readonly Action _executeMethod = null;
        private readonly Func<bool> _canExecuteMethod = null;

        

    }
}
