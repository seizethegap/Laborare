namespace Akoustis90142UI.Commands.ViewModelCommands.IOCheckCommands
{
    using System.Windows.Input;

    using Akoustis90142UI.ViewModels;

    public class StopOutputSignalTestCommand : ICommand
    {
        public StopOutputSignalTestCommand(IOCheckViewModel view_model)
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
            _ViewModel.StopOutputTest();
        }

        #endregion
    }
}
