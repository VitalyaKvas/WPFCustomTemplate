using System;
using System.Windows.Input;

namespace WPFCustomTemplate.Comands
{
    public class DelegateCommand : ICommand
    {
        private readonly Action<object> executeMethod = null;
        private readonly Predicate<object> canExecute = null;

        public DelegateCommand(Action<object> executeMethod)
            : this(executeMethod, null)
        { }

        public DelegateCommand(Action<object> executeMethod, Predicate<object> canExecute)
        {
            if (executeMethod == null)
                throw new ArgumentNullException("executeMethod");

            this.executeMethod = executeMethod;
            this.canExecute = canExecute;
        }

        #region ICommand Members

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public bool CanExecute(object parameter)
        {
            if (canExecute == null)
                return true;

            return canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            executeMethod(parameter);
        }

        #endregion
    }
}
