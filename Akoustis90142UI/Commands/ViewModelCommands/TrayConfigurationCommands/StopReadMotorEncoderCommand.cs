namespace Akoustis90142UI.Commands.ViewModelCommands.TrayConfigurationCommands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Input;

    using Akoustis90142UI.ViewModels;

    public class StopReadMotorEncoderCommand : ICommand
    {
        public StopReadMotorEncoderCommand(TrayConfigurationViewModel view_model)
        {
            _ViewModel = view_model;
        }

        private TrayConfigurationViewModel _ViewModel;

        #region ICommand Members

        public bool CanExecute(object parameter)
        {
            // TODO: check if the update motor position service is active, if so, this 
            // should return false. otherwise return true;
            return true;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            _ViewModel.StopReadMotorEncoder();
        }

        #endregion
    }
}
