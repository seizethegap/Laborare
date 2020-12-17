namespace Akoustis90142UI.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.ComponentModel;

    using Laborare.Core.Models;
    using Laborare.Core.Services;

    public class SetupParametersViewModel : INotifyPropertyChanged
    {
        public SetupParametersViewModel()
        {
            _DelayConfigurationComboBox = new List<string>();
            _SortInterfaceComboBox = new List<string>();

            PopulateDelayConfigurationComboBox();
            PopulateSortInterfaceComboBox();
        }

        private List<string> _DelayConfigurationComboBox;
        private List<string> _SortInterfaceComboBox;

        private string _DelayConfig_SelectedItem;
        private dynamic _DelayConfig_CurrentItem;

        private string _SortInterface_SelectedItem;
        private dynamic _SortInterface_CurrentItem;

        public Dictionary<string, Tray> Trays
        {
            get
            {
                return MainHandlerService.ActiveTrays;
            }
            set
            {
                if (value != MainHandlerService.ActiveTrays)
                {
                    MainHandlerService.ActiveTrays = value;
                    OnPropertyChanged("Trays");
                }
            }
        }

        public Dictionary<string, Precisor> Precisors
        {
            get
            {
                return MainHandlerService.ActivePrecisors;
            }
            set
            {
                if (value != MainHandlerService.ActivePrecisors)
                {
                    MainHandlerService.ActivePrecisors = value;
                    OnPropertyChanged("Precisors");
                }
            }
        }

        public Dictionary<string, TestSocket> TestSockets
        {
            get
            {
                return MainHandlerService.ActiveTestSockets;
            }
            set
            {
                if (value != MainHandlerService.ActiveTestSockets)
                {
                    MainHandlerService.ActiveTestSockets = value;
                    OnPropertyChanged("TestSockets");
                }
            }
        }

        public List<string> DelayConfigurationComboBox
        {
            get
            {
                return _DelayConfigurationComboBox;
            }
            set
            {
                if (value != _DelayConfigurationComboBox)
                {
                    _DelayConfigurationComboBox = value;
                    OnPropertyChanged("DelayConfigurationComboBox");
                }
            }
        }

        public List<string> SortInterfaceComboBox
        {
            get
            {
                return _SortInterfaceComboBox;
            }
            set
            {
                if (value != _SortInterfaceComboBox)
                {
                    _SortInterfaceComboBox = value;
                    OnPropertyChanged("SortInterfaceComboBox");
                }
            }
        }

        public string DelayConfig_SelectedItem
        {
            get
            {
                return _DelayConfig_SelectedItem;
            }
            set
            {
                _DelayConfig_SelectedItem = value;
                SetDelayConfigurationCurrentItem();
            }
        }

        public string SortInterface_SelectedItem
        {
            get
            {
                return _SortInterface_SelectedItem;
            }
            set
            {
                _SortInterface_SelectedItem = value;

            }
        }

        public void PopulateDelayConfigurationComboBox()
        {
            foreach (var tray in Trays)
            {
                DelayConfigurationComboBox.Add(tray.Key);
            }

            foreach (var precisor in Precisors)
            {
                DelayConfigurationComboBox.Add(precisor.Key);
            }

            foreach (var testsocket in TestSockets)
            {
                DelayConfigurationComboBox.Add(testsocket.Key);
            }
        }

        public void PopulateSortInterfaceComboBox()
        {
            foreach (var tray in Trays)
            {
                SortInterfaceComboBox.Add(tray.Key);
            }

            foreach (var precisor in Precisors)
            {
                SortInterfaceComboBox.Add(precisor.Key);
            }

            foreach (var testsocket in TestSockets)
            {
                SortInterfaceComboBox.Add(testsocket.Key);
            }   
        }

        public void SetDelayConfigurationCurrentItem()
        {
            if (_DelayConfig_SelectedItem.Contains("Tray"))
            {
                _DelayConfig_CurrentItem = Trays[_DelayConfig_SelectedItem];
            }
            else if (_DelayConfig_SelectedItem.Contains("Precisor"))
            {
                _DelayConfig_CurrentItem = Precisors[_DelayConfig_SelectedItem];
            }
            else if (_DelayConfig_SelectedItem.Contains("Test Socket"))
            {
                _DelayConfig_CurrentItem = TestSockets[_DelayConfig_SelectedItem];
            }
        }

        public void SetSortInterfaceCurrentItem()
        {
            if (_SortInterface_SelectedItem.Contains("Tray"))
            {
                _SortInterface_CurrentItem = Trays[_SortInterface_SelectedItem];
            }
            else if (_SortInterface_SelectedItem.Contains("Precisor"))
            {
                _SortInterface_CurrentItem = Precisors[_SortInterface_SelectedItem];
            }
            else if (_SortInterface_CurrentItem.Contains("Test Socket"))
            {
                _SortInterface_CurrentItem = TestSockets[_SortInterface_SelectedItem];
            }
        }


        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
