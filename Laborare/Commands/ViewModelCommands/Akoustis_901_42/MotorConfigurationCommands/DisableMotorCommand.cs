﻿namespace Laborare.Commands.ViewModelCommands.MotorConfigurationCommands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Input;

    using Laborare.ViewModels.Akoustis_901_42;

    public class DisableMotorCommand : ICommand
    {
        public DisableMotorCommand(MotorConfigurationViewModel view_model)
        {
            _ViewModel = view_model;
        }

        private MotorConfigurationViewModel _ViewModel;


        #region ICommand Members

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            _ViewModel.DisableMotor();
        }

        #endregion
    }
}