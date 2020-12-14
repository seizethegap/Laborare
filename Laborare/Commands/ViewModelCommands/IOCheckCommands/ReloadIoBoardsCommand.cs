namespace Laborare.Commands.ViewModelCommands.IOCheckCommands
{
    using System.Windows.Input;

    using Laborare.Commands.IOCommands;
    using Laborare.ViewModels;

    public class ReloadIoBoardsCommand : ICommand
    {
        public ReloadIoBoardsCommand(IOCheckViewModel view_model)
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
            _ViewModel.RefreshIoBoards();
        }
        #endregion
    }
}
