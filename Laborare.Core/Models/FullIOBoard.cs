namespace Laborare.Core.Models
{
    using Laborare.Core.Services;

    using System;
    using System.ComponentModel;

    public class FullIOBoard : IIOBoard, INotifyPropertyChanged
    {
        public FullIOBoard(int boardNum, string serial_number, string model_name)
        {
            BoardNum = boardNum;
            SerialNumber = serial_number;
            ModelName = model_name;

            _ReadInputSignalService = new ReadInputSignalService(this);
        }

        private ReadInputSignalService _ReadInputSignalService;

        private byte _InputSignal_Port0;
        private byte _InputSignal_Port1;

        // full board port 0 input signals
        private bool _s0, _s1, _s2, _s3, _s4, _s5, _s6, _s7;

        // full board port 1 input signals
        private bool _s8, _s9, _s10, _s11, _s12, _s13, _s14, _s15;

        // full board port 0 output signals
        private bool _sol1, _sol2, _sol3, _sol4, _sol5, _sol6, _sol7, _sol8;

        // full board port 1 output signals
        private bool _sol9, _sol10, _sol11, _sol12, _sol13, _sol14, _sol15, _sol16;

        #region Binding variables
        public int BoardNum { get; set; }

        public string SerialNumber { get; set; }

        public string ModelName { get; set; }

        public ReadInputSignalService ReadInputSignalService
        {
            get
            {
                return _ReadInputSignalService;
            }
        }

        public byte InputSignal_Port0
        {
            get
            {
                return _InputSignal_Port0;
            }
            set
            {
                if (value != _InputSignal_Port0)
                {
                    _InputSignal_Port0 = value;
                    ConvertToBooleanSignals(0);
                }
            }
        }
        public byte InputSignal_Port1
        {
            get
            {
                return _InputSignal_Port1;
            }
            set
            {
                if (value != _InputSignal_Port1)
                {
                    _InputSignal_Port1 = value;
                    ConvertToBooleanSignals(1);
                }
            }
        }

        public bool s0
        {
            get
            {
                return _s0;
            }
            set
            {
                if (value != _s0)
                {
                    _s0 = value;
                    OnPropertyChanged("s0");
                }
            }
        }

        public bool s1
        {
            get
            {
                return _s1;
            }
            set
            {
                if (value != _s1)
                {
                    _s1 = value;
                    OnPropertyChanged("s1");
                }
            }
        }

        public bool s2
        {
            get
            {
                return _s2;
            }
            set
            {
                if (value != _s2)
                {
                    _s2 = value;
                    OnPropertyChanged("s2");
                }
            }
        }

        public bool s3
        {
            get
            {
                return _s3;
            }
            set
            {
                if (value != _s3)
                {
                    _s3 = value;
                    OnPropertyChanged("s3");
                }
            }
        }

        public bool s4
        {
            get
            {
                return _s4;
            }
            set
            {
                if (value != _s4)
                {
                    _s4 = value;
                    OnPropertyChanged("s4");
                }
            }
        }

        public bool s5
        {
            get
            {
                return _s5;
            }
            set
            {
                if (value != _s5)
                {
                    _s5 = value;
                    OnPropertyChanged("s5");
                }
            }
        }

        public bool s6
        {
            get
            {
                return _s6;
            }
            set
            {
                if (value != _s6)
                {
                    _s6 = value;
                    OnPropertyChanged("s6");
                }
            }
        }

        public bool s7
        {
            get
            {
                return _s7;
            }
            set
            {
                if (value != _s7)
                {
                    _s7 = value;
                    OnPropertyChanged("s7");
                }
            }
        }

        public bool s8
        {
            get
            {
                return _s8;
            }
            set
            {
                if (value != _s8)
                {
                    _s8 = value;
                    OnPropertyChanged("s8");
                }
            }
        }

        public bool s9
        {
            get
            {
                return _s9;
            }
            set
            {
                if (value != _s9)
                {
                    _s9 = value;
                    OnPropertyChanged("s9");
                }
            }
        }

        public bool s10
        {
            get
            {
                return _s10;
            }
            set
            {
                if (value != _s10)
                {
                    _s10 = value;
                    OnPropertyChanged("s10");
                }
            }
        }

        public bool s11
        {
            get
            {
                return _s11;
            }
            set
            {
                if (value != _s11)
                {
                    _s11 = value;
                    OnPropertyChanged("s11");
                }
            }
        }

        public bool s12
        {
            get
            {
                return _s12;
            }
            set
            {
                if (value != _s12)
                {
                    _s12 = value;
                    OnPropertyChanged("s12");
                }
            }
        }

        public bool s13
        {
            get
            {
                return _s13;
            }
            set
            {
                if (value != _s13)
                {
                    _s13 = value;
                    OnPropertyChanged("s13");
                }
            }
        }

        public bool s14
        {
            get
            {
                return _s14;
            }
            set
            {
                if (value != _s14)
                {
                    _s14 = value;
                    OnPropertyChanged("s14");
                }
            }
        }

        public bool s15
        {
            get
            {
                return _s15;
            }
            set
            {
                if (value != _s15)
                {
                    _s15 = value;
                    OnPropertyChanged("s15");
                }
            }
        }


        public bool sol1
        {
            get
            {
                return _sol1;
            }
            set
            {
                _sol1 = value;
                WriteToIoBoard(16);
            }
        }

        public bool sol2
        {
            get
            {
                return _sol2;
            }
            set
            {
                _sol2 = value;
                WriteToIoBoard(16);
            }
        }

        public bool sol3
        {
            get
            {
                return _sol3;
            }
            set
            {
                _sol3 = value;
                WriteToIoBoard(16);
            }
        }

        public bool sol4
        {
            get
            {
                return _sol4;
            }
            set
            {
                _sol4 = value;
                WriteToIoBoard(16);
            }
        }

        public bool sol5
        {
            get
            {
                return _sol5;
            }
            set
            {
                _sol5 = value;
                WriteToIoBoard(16);
            }
        }

        public bool sol6
        {
            get
            {
                return _sol6;
            }
            set
            {
                _sol6 = value;
                WriteToIoBoard(16);
            }
        }

        public bool sol7
        {
            get
            {
                return _sol7;
            }
            set
            {
                _sol7 = value;
                WriteToIoBoard(16);
            }
        }

        public bool sol8
        {
            get
            {
                return _sol8;
            }
            set
            {
                _sol8 = value;
                WriteToIoBoard(16);
            }
        }

        public bool sol9
        {
            get
            {
                return _sol9;
            }
            set
            {
                _sol9 = value;
                WriteToIoBoard(17);
            }
        }

        public bool sol10
        {
            get
            {
                return _sol10;
            }
            set
            {
                _sol10 = value;
                WriteToIoBoard(17);
            }
        }

        public bool sol11
        {
            get
            {
                return _sol11;
            }
            set
            {
                _sol11 = value;
                WriteToIoBoard(17);
            }
        }

        public bool sol12
        {
            get
            {
                return _sol12;
            }
            set
            {
                _sol12 = value;
                WriteToIoBoard(17);
            }
        }

        public bool sol13
        {
            get
            {
                return _sol13;
            }
            set
            {
                _sol13 = value;
                WriteToIoBoard(17);
            }
        }

        public bool sol14
        {
            get
            {
                return _sol14;
            }
            set
            {
                _sol14 = value;
                WriteToIoBoard(17);
            }
        }

        public bool sol15
        {
            get
            {
                return _sol15;
            }
            set
            {
                _sol15 = value;
                WriteToIoBoard(17);
            }
        }

        public bool sol16
        {
            get
            {
                return _sol16;
            }
            set
            {
                _sol16 = value;
                WriteToIoBoard(17);
            }
        }

        #endregion

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

        #region Write To I/O Board

        /// <summary>
        /// This function will be called any time any output signal is changed. It will create
        /// a byte array for either sol1 - sol8 (output port 0) or sol9 - sol16 (output port 1)
        /// and convert it into a byte to write to the Io board. Since our Io boards work in 
        /// reverse logic (i.e 1 means off and 0 means on) our starting result is 0xFF 
        /// or 1111 1111.
        /// 
        /// 16 = output port 0, 17 = output port 1
        /// </summary>
        private void WriteToIoBoard(byte port)
        {
            bool[] source;
            byte result = 0xFF;
            // This assumes the array never contains more than 8 elements.
            
            if (port == 16) // output port 0
            {
                source = new bool[8] { sol1, sol2, sol3, sol4, sol5, sol6, sol7, sol8 };
            }
            else // output port 1
            {
                source = new bool[8] { sol9, sol10, sol11, sol12, sol13, sol14, sol15, sol16 };
            }

            int index = 0;

            // convert the bool array to a byte
            foreach (bool b in source)
            {
                if (b)
                {
                    result &= (byte)~(1 << (index));
                }
                index++;
            }
            USBIOBoardService.WritePort(BoardNum, port, result);
        }
        #endregion

        #region Is Bit On Function
        /* IsBitOn(byte aByte, int pos)
         * 
         * aByte - the 8-bit signal (input signal most likely)
         * pos - 0 based bit position of the signal
         * 
         * NOTE: Our IO boards use reverse logic. This means 0 is ON and 1 is OFF. Therefore, IsBitOn returns true if 
         * the bit at the position is 0 and returns false if the bit at the position IS NOT 0.
         * 
         *              1               1               1               1                   1                  1                    1                   1
         *           pos = 7         pos = 6         pos = 5         pos = 4            pos = 3             pos = 2               pos = 1            pos = 0
         */
        public static bool IsBitOn(byte aByte, int pos)
        {
            // left-shift 1, then bitwise AND, then check for non-zero
            return ((aByte & (1 << pos)) != 0);
        }
        #endregion

        #region Update Boolean Signals
        private void ConvertToBooleanSignals(int port_number)
        {
            switch (port_number)
            {
                case 0:
                    s0 = IsBitOn(InputSignal_Port0, 0);
                    s1 = IsBitOn(InputSignal_Port0, 1);
                    s2 = IsBitOn(InputSignal_Port0, 2);
                    s3 = IsBitOn(InputSignal_Port0, 3);
                    s4 = IsBitOn(InputSignal_Port0, 4);
                    s5 = IsBitOn(InputSignal_Port0, 5);
                    s6 = IsBitOn(InputSignal_Port0, 6);
                    s7 = IsBitOn(InputSignal_Port0, 7);
                    break;

                case 1:
                    s8 = IsBitOn(InputSignal_Port1, 0);
                    s9 = IsBitOn(InputSignal_Port1, 1);
                    s10 = IsBitOn(InputSignal_Port1, 2);
                    s11 = IsBitOn(InputSignal_Port1, 3);
                    s12 = IsBitOn(InputSignal_Port1, 4);
                    s13 = IsBitOn(InputSignal_Port1, 5);
                    s14 = IsBitOn(InputSignal_Port1, 6);
                    s15 = IsBitOn(InputSignal_Port1, 7);
                    break;
            }
        }
        #endregion
    }
}
