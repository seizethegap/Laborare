namespace Laborare.Commands.ViewModelCommands.IOCheckCommands
{
    using System.Windows.Input;

    using Laborare.ViewModels;

    public class ApplyIoBoardIntervalSettingCommand : ICommand
    {
        public ApplyIoBoardIntervalSettingCommand(IOCheckViewModel view_model)
        {
            _ViewModel = view_model;
        }

        private IOCheckViewModel _ViewModel;

        #region ICommand Members

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event System.EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            _ViewModel.SaveIntervalSetting();
        }

        #endregion
    }
}
