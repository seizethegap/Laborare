namespace Akoustis90142UI.ViewModels
{
    using System.Collections;
    using System.Configuration;
    using System.Collections.Specialized;
    using System.Windows;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using System.Windows.Input;
    using System.ComponentModel;

    using Akoustis90142UI.Commands.ViewModelCommands.IOCheckCommands;
    using Laborare.Core.Commands.IOCommands;
    using Laborare.Core.Services;
    using Laborare.Core.Models;

    public class IOCheckViewModel : INotifyPropertyChanged
    {
        public IOCheckViewModel()
        {
            // if there is at least one board initialized, default to the first board
            if (IOBoards.Count > 0)
            {
                SelectedBoard = USBIOBoardService.SN[0];
            }
            else
            {
                MessageBox.Show("No IO boards detected.");
            }

            Test = new TestOutputSignalsService();
            // initialize read io interval from value in mainhandlerservice
            _Read_Io_Interval = MainHandlerService.Read_Io_Interval_Setting;

            // initialize commands for io check
            ReloadIoBoardCommand = new ReloadIoBoardsCommand(this);
            ApplyIoBoardIntervalSettingCommand = new ApplyIoBoardIntervalSettingCommand(this);
            StopOutputSignalTestCommand = new StopOutputSignalTestCommand(this);

        }

        private string _SelectedBoard;
        private IIOBoard _CurrentBoard;
        private string _Read_Io_Interval;

        private TestOutputSignalsService Test;

        private int ignoreLol;

        private string _s0_Desc, _s1_Desc, _s2_Desc, _s3_Desc, _s4_Desc, _s5_Desc, _s6_Desc, _s7_Desc;
        private string _s8_Desc, _s9_Desc, _s10_Desc, _s11_Desc, _s12_Desc, _s13_Desc, _s14_Desc, _s15_Desc;

        private string _sol1_Desc, _sol2_Desc, _sol3_Desc, _sol4_Desc, _sol5_Desc, _sol6_Desc, _sol7_Desc, _sol8_Desc;
        private string _sol9_Desc, _sol10_Desc, _sol11_Desc, _sol12_Desc, _sol13_Desc, _sol14_Desc, _sol15_Desc, _sol16_Desc;

        private bool _s0, _s1, _s2, _s3, _s4, _s5, _s6, _s7;
        private bool _s8, _s9, _s10, _s11, _s12, _s13, _s14, _s15;

        private bool _sol1, _sol2, _sol3, _sol4, _sol5, _sol6, _sol7, _sol8;
        private bool _sol9, _sol10, _sol11, _sol12, _sol13, _sol14, _sol15, _sol16;

        public Dictionary<string, IIOBoard> IOBoards
        {
            get
            {
                return MainHandlerService.ActiveIOBoards;
            }
            set
            {
                MainHandlerService.ActiveIOBoards = value;
                // relay to the ui that our list of ioboards have changed
                OnPropertyChanged("IOBoards");
            }
        }

        public Dictionary<string, string[]> IOBoardInformation
        {
            get
            {
                return MainHandlerService.IoDevices;
            }
        }

        #region Binding variables
        public ICommand ReloadIoBoardCommand
        {
            get;
            private set;
        }

        public ICommand ApplyIoBoardIntervalSettingCommand
        {
            get;
            private set;
        }

        public ICommand StopOutputSignalTestCommand
        {
            get;
            private set;
        }

        public string Read_Io_Interval
        {
            get
            {
                return _Read_Io_Interval;
            }
            set
            {
                _Read_Io_Interval = value;
            }
        }

        public string SelectedBoard 
        {
            get
            {
                return _SelectedBoard;
            }
            set
            {
                _SelectedBoard = value;
                _CurrentBoard = IOBoards[_SelectedBoard];
                _CurrentBoard.PropertyChanged += CurrentBoard_PropertyChanged;
                SynchronizeInputSignals();
                ResetSignalDescriptions();
                UpdateSignalDescriptions();
            }
        }

        public string s0_Desc
        {
            get
            {
                return _s0_Desc;
            }
            set
            {
                if (value != _s0_Desc)
                {
                    _s0_Desc = value;
                    OnPropertyChanged("s0_Desc");
                }
            }
        }

        public string s1_Desc
        {
            get
            {
                return _s1_Desc;
            }
            set
            {
                if (value != _s1_Desc)
                {
                    _s1_Desc = value;
                    OnPropertyChanged("s1_Desc");
                }
            }
        }

        public string s2_Desc
        {
            get
            {
                return _s2_Desc;
            }
            set
            {
                if (value != _s2_Desc)
                {
                    _s2_Desc = value;
                    OnPropertyChanged("s2_Desc");
                }
            }
        }

        public string s3_Desc
        {
            get
            {
                return _s3_Desc;
            }
            set
            {
                if (value != _s3_Desc)
                {
                    _s3_Desc = value;
                    OnPropertyChanged("s3_Desc");
                }
            }
        }

        public string s4_Desc
        {
            get
            {
                return _s4_Desc;
            }
            set
            {
                if (value != _s4_Desc)
                {
                    _s4_Desc = value;
                    OnPropertyChanged("s4_Desc");
                }
            }
        }

        public string s5_Desc
        {
            get
            {
                return _s5_Desc;
            }
            set
            {
                if (value != _s5_Desc)
                {
                    _s5_Desc = value;
                    OnPropertyChanged("s5_Desc");
                }
            }
        }

        public string s6_Desc
        {
            get
            {
                return _s6_Desc;
            }
            set
            {
                if (value != _s6_Desc)
                {
                    _s6_Desc = value;
                    OnPropertyChanged("s6_Desc");
                }
            }
        }

        public string s7_Desc
        {
            get
            {
                return _s7_Desc;
            }
            set
            {
                if (value != _s7_Desc)
                {
                    _s7_Desc = value;
                    OnPropertyChanged("s7_Desc");
                }
            }
        }

        public string s8_Desc
        {
            get
            {
                return _s8_Desc;
            }
            set
            {
                if (value != _s8_Desc)
                {
                    _s8_Desc = value;
                    OnPropertyChanged("s8_Desc");
                }
            }
        }

        public string s9_Desc
        {
            get
            {
                return _s9_Desc;
            }
            set
            {
                if (value != _s9_Desc)
                {
                    _s9_Desc = value;
                    OnPropertyChanged("s9_Desc");
                }
            }
        }

        public string s10_Desc
        {
            get
            {
                return _s10_Desc;
            }
            set
            {
                if (value != _s10_Desc)
                {
                    _s10_Desc = value;
                    OnPropertyChanged("s10_Desc");
                }
            }
        }

        public string s11_Desc
        {
            get
            {
                return _s11_Desc;
            }
            set
            {
                if (value != _s11_Desc)
                {
                    _s11_Desc = value;
                    OnPropertyChanged("s11_Desc");
                }
            }
        }

        public string s12_Desc
        {
            get
            {
                return _s12_Desc;
            }
            set
            {
                if (value != _s12_Desc)
                {
                    _s1_Desc = value;
                    OnPropertyChanged("s12_Desc");
                }
            }
        }

        public string s13_Desc
        {
            get
            {
                return _s13_Desc;
            }
            set
            {
                if (value != _s13_Desc)
                {
                    _s13_Desc = value;
                    OnPropertyChanged("s13_Desc");
                }
            }
        }

        public string s14_Desc
        {
            get
            {
                return _s14_Desc;
            }
            set
            {
                if (value != _s14_Desc)
                {
                    _s14_Desc = value;
                    OnPropertyChanged("s14_Desc");
                }
            }
        }

        public string s15_Desc
        {
            get
            {
                return _s15_Desc;
            }
            set
            {
                if (value != _s15_Desc)
                {
                    _s15_Desc = value;
                    OnPropertyChanged("s15_Desc");
                }
            }
        }

        public string sol1_Desc
        {
            get
            {
                return _sol1_Desc;
            }
            set
            {
                if (value != _sol1_Desc)
                {
                    _sol1_Desc = value;
                    OnPropertyChanged("sol1_Desc");
                }
            }
        }

        public string sol2_Desc
        {
            get
            {
                return _sol2_Desc;
            }
            set
            {
                if (value != _sol2_Desc)
                {
                    _sol2_Desc = value;
                    OnPropertyChanged("sol2_Desc");
                }
            }
        }

        public string sol3_Desc
        {
            get
            {
                return _sol3_Desc;
            }
            set
            {
                if (value != _sol3_Desc)
                {
                    _sol3_Desc = value;
                    OnPropertyChanged("sol3_Desc");
                }
            }
        }

        public string sol4_Desc
        {
            get
            {
                return _sol4_Desc;
            }
            set
            {
                if (value != _sol4_Desc)
                {
                    _sol4_Desc = value;
                    OnPropertyChanged("sol4_Desc");
                }
            }
        }

        public string sol5_Desc
        {
            get
            {
                return _sol5_Desc;
            }
            set
            {
                if (value != _sol5_Desc)
                {
                    _sol5_Desc = value;
                    OnPropertyChanged("sol5_Desc");
                }
            }
        }

        public string sol6_Desc
        {
            get
            {
                return _sol6_Desc;
            }
            set
            {
                if (value != _sol6_Desc)
                {
                    _sol6_Desc = value;
                    OnPropertyChanged("sol6_Desc");
                }
            }
        }

        public string sol7_Desc
        {
            get
            {
                return _sol7_Desc;
            }
            set
            {
                if (value != _sol7_Desc)
                {
                    _sol7_Desc = value;
                    OnPropertyChanged("sol7_Desc");
                }
            }
        }

        public string sol8_Desc
        {
            get
            {
                return _sol8_Desc;
            }
            set
            {
                if (value != _sol8_Desc)
                {
                    _sol8_Desc = value;
                    OnPropertyChanged("sol8_Desc");
                }
            }
        }

        public string sol9_Desc
        {
            get
            {
                return _sol9_Desc;
            }
            set
            {
                if (value != _sol9_Desc)
                {
                    _sol9_Desc = value;
                    OnPropertyChanged("sol9_Desc");
                }
            }
        }

        public string sol10_Desc
        {
            get
            {
                return _sol10_Desc;
            }
            set
            {
                if (value != _sol10_Desc)
                {
                    _sol10_Desc = value;
                    OnPropertyChanged("sol10_Desc");
                }
            }
        }

        public string sol11_Desc
        {
            get
            {
                return _sol11_Desc;
            }
            set
            {
                if (value != _sol11_Desc)
                {
                    _sol11_Desc = value;
                    OnPropertyChanged("sol11_Desc");
                }
            }
        }


        public string sol12_Desc
        {
            get
            {
                return _sol12_Desc;
            }
            set
            {
                if (value != _sol12_Desc)
                {
                    _sol12_Desc = value;
                    OnPropertyChanged("sol12_Desc");
                }
            }
        }

        public string sol13_Desc
        {
            get
            {
                return _sol13_Desc;
            }
            set
            {
                if (value != _sol13_Desc)
                {
                    _sol13_Desc = value;
                    OnPropertyChanged("sol13_Desc");
                }
            }
        }

        public string sol14_Desc
        {
            get
            {
                return _sol14_Desc;
            }
            set
            {
                if (value != _sol14_Desc)
                {
                    _sol14_Desc = value;
                    OnPropertyChanged("sol14_Desc");
                }
            }
        }

        public string sol15_Desc
        {
            get
            {
                return _sol15_Desc;
            }
            set
            {
                if (value != _sol15_Desc)
                {
                    _sol15_Desc = value;
                    OnPropertyChanged("sol15_Desc");
                }
            }
        }

        public string sol16_Desc
        {
            get
            {
                return _sol16_Desc;
            }
            set
            {
                if (value != _sol16_Desc)
                {
                    _sol16_Desc = value;
                    OnPropertyChanged("sol16_Desc");
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
                _CurrentBoard.sol1 = value;
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
                _CurrentBoard.sol2 = value;
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
                _CurrentBoard.sol3 = value;
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
                _CurrentBoard.sol4 = value;
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
                _CurrentBoard.sol5 = value;
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
                _CurrentBoard.sol6 = value;
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
                _CurrentBoard.sol7 = value;
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
                _CurrentBoard.sol8 = value;
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
                _CurrentBoard.sol9 = value;
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
                _CurrentBoard.sol10 = value;
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
                _CurrentBoard.sol11 = value;
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
                _CurrentBoard.sol12 = value;
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
                _CurrentBoard.sol13 = value;
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
                _CurrentBoard.sol14 = value;
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
                _CurrentBoard.sol15 = value;
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
               _CurrentBoard.sol16 = value;
            }
        }
        #endregion

        private void CurrentBoard_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "s0":
                    s0 = _CurrentBoard.s0;
                    break;

                case "s1":
                    s1 = _CurrentBoard.s1;
                    break;

                case "s2":
                    s2 = _CurrentBoard.s2;
                    break;

                case "s3":
                    s3 = _CurrentBoard.s3;
                    break;

                case "s4":
                    s4 = _CurrentBoard.s4;
                    break;

                case "s5":
                    s5 = _CurrentBoard.s5;
                    break;

                case "s6":
                    s6 = _CurrentBoard.s6;
                    break;

                case "s7":
                    s7 = _CurrentBoard.s7;
                    break;

                case "s8":
                    s8 = _CurrentBoard.s8;
                    break;

                case "s9":
                    s9 = _CurrentBoard.s9;
                    break;

                case "s10":
                    s10 = _CurrentBoard.s10;
                    break;

                case "s11":
                    s11 = _CurrentBoard.s11;
                    break;

                case "s12":
                    s12 = _CurrentBoard.s12;
                    break;

                case "s13":
                    s13 = _CurrentBoard.s13;
                    break;

                case "s14":
                    s14 = _CurrentBoard.s14;
                    break;
                    
                case "s15":
                    s15 = _CurrentBoard.s15;
                    break;
            }
        }

        private void SynchronizeInputSignals()
        {
            s0 = _CurrentBoard.s0;
            s1 = _CurrentBoard.s1;
            s2 = _CurrentBoard.s2;
            s3 = _CurrentBoard.s3;
            s4 = _CurrentBoard.s4;
            s5 = _CurrentBoard.s5;
            s6 = _CurrentBoard.s6;
            s7 = _CurrentBoard.s7;
            s8 = _CurrentBoard.s8;
            s9 = _CurrentBoard.s9;
            s10 = _CurrentBoard.s10;
            s11 = _CurrentBoard.s11;
            s12 = _CurrentBoard.s12;
            s13 = _CurrentBoard.s13;
            s14 = _CurrentBoard.s14;
            s15 = _CurrentBoard.s15;
        }

        /// <summary>
        /// Restarts the IOBoard service and updates the new IOboards to the UI.
        /// </summary>
        public void RefreshIoBoards()
        {
            RestartIOServiceCommand.Execute();
            IOBoards = MainHandlerService.ActiveIOBoards;
        }

        public void SaveIntervalSetting()
        {
            Test.Start();
        }

        public void StopOutputTest()
        {
            Test.Stop();
        }

        /// <summary>
        /// Update Signal Descriptions based on when the SelectedBoard is changed. Will also need to be initially 
        /// called in the constructor.
        /// </summary>
        private void UpdateSignalDescriptions()
        {
            if (SelectedBoard == null)
            {
                // do nothing
            }
            else
            {
                foreach (var signal in IOBoardInformation)
                {
                    // check the board serial number on the signal and see if it matches our SelectedBoard
                    if (signal.Value[0] == SelectedBoard)
                    {
                        string desc = signal.Value[2];
                        // okay so this signal does belong to this board, now check what signal it is
                        switch (signal.Value[1])
                        {
                            case "s0":
                                s0_Desc = desc;
                                break;

                            case "s1":
                                s1_Desc = desc;
                                break;

                            case "s2":
                                s2_Desc = desc;
                                break;

                            case "s3":
                                s3_Desc = desc;
                                break;

                            case "s4":
                                s4_Desc = desc;
                                break;

                            case "s5":
                                s5_Desc = desc;
                                break;

                            case "s6":
                                s6_Desc = desc;
                                break;

                            case "s7":
                                s7_Desc = desc;
                                break;

                            case "s8":
                                s8_Desc = desc;
                                break;

                            case "s9":
                                s9_Desc = desc;
                                break;

                            case "s10":
                                s10_Desc = desc;
                                break;

                            case "s11":
                                s11_Desc = desc;
                                break;

                            case "s12":
                                s12_Desc = desc;
                                break;

                            case "s13":
                                s13_Desc = desc;
                                break;

                            case "s14":
                                s14_Desc = desc;
                                break;

                            case "s15":
                                s15_Desc = desc;
                                break;

                            case "sol1":
                                sol1_Desc = desc;
                                break;

                            case "sol2":
                                sol2_Desc = desc;
                                break;

                            case "sol3":
                                sol3_Desc = desc;
                                break;

                            case "sol4":
                                sol4_Desc = desc;
                                break;

                            case "sol5":
                                sol5_Desc = desc;
                                break;

                            case "sol6":
                                sol6_Desc = desc;
                                break;

                            case "sol7":
                                sol7_Desc = desc;
                                break;

                            case "sol8":
                                sol8_Desc = desc;
                                break;

                            case "sol9":
                                sol9_Desc = desc;
                                break;

                            case "sol10":
                                sol10_Desc = desc;
                                break;

                            case "sol11":
                                sol11_Desc = desc;
                                break;

                            case "sol12":
                                sol12_Desc = desc;
                                break;

                            case "sol13":
                                sol13_Desc = desc;
                                break;

                            case "sol14":
                                sol14_Desc = desc;
                                break;

                            case "sol15":
                                sol15_Desc = desc;
                                break;

                            case "sol16":
                                sol16_Desc = desc;
                                break;

                        }
                    }
                }
            }
        }

        /// <summary>
        /// Reset Signal Descriptions every time the SelectedBoard is changed
        /// </summary>
        private void ResetSignalDescriptions()
        {
            s0_Desc = "";
            s1_Desc = "";
            s2_Desc = "";
            s3_Desc = "";
            s4_Desc = "";
            s5_Desc = "";
            s6_Desc = "";
            s7_Desc = "";
            s8_Desc = "";
            s9_Desc = "";
            s10_Desc = "";
            s11_Desc = "";
            s12_Desc = "";
            s13_Desc = "";
            s14_Desc = "";
            s15_Desc = "";
            sol1_Desc = "";
            sol2_Desc = "";
            sol3_Desc = "";
            sol4_Desc = "";
            sol5_Desc = "";
            sol6_Desc = "";
            sol7_Desc = "";
            sol8_Desc = "";
            sol9_Desc = "";
            sol10_Desc = "";
            sol11_Desc = "";
            sol12_Desc = "";
            sol13_Desc = "";
            sol14_Desc = "";
            sol15_Desc = "";
            sol16_Desc = "";
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
