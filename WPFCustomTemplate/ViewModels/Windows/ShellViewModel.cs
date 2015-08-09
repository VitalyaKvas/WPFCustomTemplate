using System.Windows;
using System.Windows.Input;
using WPFCustomTemplate.Comands;

namespace WPFCustomTemplate.ViewModels
{
    public sealed class ShellViewModel : BaseViewModel
    {
        #region OpenTestsResults

        private DelegateCommand MousePressedCommand;

        public ICommand PressedMouseClick
        {
            get
            {
                if (MousePressedCommand == null)
                    MousePressedCommand = new DelegateCommand(p => MouseBinding());

                return MousePressedCommand;
            }
        }

        private void MouseBinding()
        {
            MessageBox.Show("MouseBinding");
        }

        #endregion

        #region OpenTestsResults

        private DelegateCommand KeyCommand;

        public ICommand KeyPressed
        {
            get
            {
                if (KeyCommand == null)
                    KeyCommand = new DelegateCommand(p => KeyBinding());

                return KeyCommand;
            }
        }

        private void KeyBinding()
        {
            MessageBox.Show("KeyBinding");
        }

        #endregion
    }
}
