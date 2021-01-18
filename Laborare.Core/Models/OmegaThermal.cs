namespace Laborare.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.ComponentModel;

    using Laborare.Core.Services;
    
    public class OmegaThermal : INotifyPropertyChanged
    {
        public OmegaThermal(string device_name, int device_id, IConnectionService connection_service)
        {
            _Device_Name = device_name;
            _Device_Id = device_id;
            _Connection_Service = connection_service;
        }

        private double _CurrentTemperature;
        private string _Device_Name;
        private int _Device_Id;

        private IConnectionService _Connection_Service;

        #region Binding variables
        public double CurrentTemperature
        {
            get
            {
                return _CurrentTemperature;
            }
            set
            {
                if (value != _CurrentTemperature)
                {
                    _CurrentTemperature = value;
                    OnPropertyChanged("CurrentTemperature");
                }
            }
        }

        public string Device_Name
        {
            get
            {
                return _Device_Name;
            }
            set
            {
                _Device_Name = value;
                OnPropertyChanged("Device_Name");
            }
        }

        public int Device_Id
        {
            get
            {
                return _Device_Id;
            }
            set
            {
                _Device_Id = value;
                OnPropertyChanged("Device_Id");
            }
        }
        #endregion

        public void GetTemperature()
        {

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
