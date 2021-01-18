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

        // pre-saved variables
        private int _VacuumOn;
        private int _VacuumOff;
        private int _AirBlowOn;
        private int _AirBlowOff;
        private int _ZPutBVO;
        private string _TestSortResult;

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

        public Dictionary<string, Bucket> Buckets
        {
            get
            {
                return MainHandlerService.ActiveBuckets;
            }
            set
            {
                if (value != MainHandlerService.ActiveBuckets)
                {
                    MainHandlerService.ActiveBuckets = value;
                    OnPropertyChanged("Buckets");
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

        #region Binding variables
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

        public dynamic DelayConfig_CurrentItem
        {
            get
            {
                return _DelayConfig_CurrentItem;
            }
            set
            {
                _DelayConfig_CurrentItem = value;
                SetDelayVariables();
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
                SetSortInterfaceCurrentItem();

            }
        }

        public dynamic SortInterface_CurrentItem
        {
            get
            {
                return _SortInterface_CurrentItem;
            }
            set
            {
                _SortInterface_CurrentItem = value;
                SetTestSortResult();
            }
        }

        public int VacuumOn
        {
            get
            {
                return _VacuumOn;
            }
            set
            {
                if (value != _VacuumOn)
                {
                    _VacuumOn = value;
                    OnPropertyChanged("VacuumOn");
                }
            }
        }

        public int VacuumOff
        {
            get
            {
                return _VacuumOff;
            }
            set
            {
                if (value != _VacuumOff)
                {
                    _VacuumOff = value;
                    OnPropertyChanged("VacuumOff");
                }
            }
        }

        public int AirBlowOn
        {
            get
            {
                return _AirBlowOn;
            }
            set
            {
                if (value != _AirBlowOn)
                {
                    _AirBlowOn = value;
                    OnPropertyChanged("AirBlowOn");
                }
            }
        }

        public int AirBlowOff
        {
            get
            {
                return _AirBlowOff;
            }
            set
            {
                if (value != _AirBlowOff)
                {
                    _AirBlowOff = value;
                    OnPropertyChanged("AirBlowOff");
                }
            }
        }

        public int ZPutBVO
        {
            get
            {
                return _ZPutBVO;
            }
            set
            {
                if (value != _ZPutBVO)
                {
                    _ZPutBVO = value;
                    OnPropertyChanged("ZPutBVO");
                }
            }
        }

        public string TestSortResult
        {
            get
            {
                return _TestSortResult;
            }
            set
            {
                if (value != _TestSortResult)
                {
                    _TestSortResult = value;
                    OnPropertyChanged("TestSortResult");
                }
            }
        }
        #endregion
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

            foreach (var bucket in Buckets)
            {
                SortInterfaceComboBox.Add(bucket.Key);
            }
        }

        public void SetDelayConfigurationCurrentItem()
        {
            if (DelayConfig_SelectedItem.Contains("Tray"))
            {
                DelayConfig_CurrentItem = Trays[DelayConfig_SelectedItem];
            }
            else if (DelayConfig_SelectedItem.Contains("Precisor"))
            {
                DelayConfig_CurrentItem = Precisors[DelayConfig_SelectedItem];
            }
            else if (DelayConfig_SelectedItem.Contains("Test Socket"))
            {
                DelayConfig_CurrentItem = TestSockets[DelayConfig_SelectedItem];
            }
        }

        public void SetSortInterfaceCurrentItem()
        {
            if (SortInterface_SelectedItem.Contains("Tray"))
            {
                SortInterface_CurrentItem = Trays[SortInterface_SelectedItem];
            }
            else if (SortInterface_SelectedItem.Contains("Bucket"))
            {
                SortInterface_CurrentItem = Buckets[SortInterface_SelectedItem];
            }
        }

        public void SetTestSortResult()
        {
            TestSortResult = SortInterface_CurrentItem.TestSortResult;
        }

        public void SetDelayVariables()
        {
            VacuumOn = DelayConfig_CurrentItem.VacuumOn_Delay;
            VacuumOff = DelayConfig_CurrentItem.VacuumOff_Delay;
            AirBlowOn = DelayConfig_CurrentItem.AirblowOn_Delay;
            AirBlowOff = DelayConfig_CurrentItem.AirblowOff_Delay;
            ZPutBVO = DelayConfig_CurrentItem.ZPut_Delay;
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
