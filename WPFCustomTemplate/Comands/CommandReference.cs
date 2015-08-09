using System;
using System.Windows;
using System.Windows.Input;

namespace WPFCustomTemplate.Comands
{
    public class CommandReference : Freezable, ICommand
    {
        public static readonly DependencyProperty CommandProperty;

        static CommandReference()
        {
            CommandProperty = DependencyProperty.Register("Command", typeof(ICommand), typeof(CommandReference), new PropertyMetadata());
        }

        public CommandReference() { }

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
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
            if (Command != null)
                return Command.CanExecute(parameter);
            return false;
        }

        void ICommand.Execute(object parameter)
        {
            Command.Execute(parameter);
        }

        #endregion

        #region Freezable

        protected override Freezable CreateInstanceCore()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
