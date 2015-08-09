using System;
using System.Windows.Input;

namespace WPFCustomTemplate.Comands
{
    public class DelegateCommand : ICommand
    {
        private readonly Action executeMethod = null;

        public DelegateCommand(Action executeMethod)
        {
            if (executeMethod == null)
                throw new ArgumentNullException("executeMethod");

            this.executeMethod = executeMethod;
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

        bool ICommand.CanExecute(object parameter)
        {
            return true;
        }

        void ICommand.Execute(object parameter)
        {
            if (executeMethod != null)
                executeMethod();
        }
        #endregion
    }
}
