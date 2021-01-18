namespace Akoustis90142UI.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Input;

    using Laborare.Core.Models;
    using Laborare.Core.Services;

    public class BowlFeederConfigurationViewModel
    {
        public BowlFeederConfigurationViewModel()
        {
            InspectionJobId = new List<int>();

            for (int i = 1; i < 32; i++)
            {
                InspectionJobId.Add(i);
            }
        }

        private int _SelectedInspectionJob;
        private string _SelectedBowlFeeder;

        private BowlFeeder _CurrentBowlFeeder;

        public List<int> InspectionJobId;

        public Dictionary<string, string[]> IOBoardInformation
        {
            get
            {
                return MainHandlerService.IoDevices;
            }
        }

        #region Binding variables
        public int SelectedInspectionJob
        {
            get
            {
                return _SelectedInspectionJob;
            }
            set
            {
                _SelectedInspectionJob = value;
                UpdateInspectionJobSignals();
            }
        }

        #endregion

        public void UpdateInspectionJobSignals()
        {
            switch (_SelectedInspectionJob)
            {
                case 0:
                    MainHandlerService.signalDecrypter.DisableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_0"]);
                    MainHandlerService.signalDecrypter.DisableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_1"]);
                    MainHandlerService.signalDecrypter.DisableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_2"]);
                    MainHandlerService.signalDecrypter.DisableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_3"]);
                    MainHandlerService.signalDecrypter.DisableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_4"]);
                    break;

                case 1:
                    MainHandlerService.signalDecrypter.EnableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_0"]);
                    MainHandlerService.signalDecrypter.DisableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_1"]);
                    MainHandlerService.signalDecrypter.DisableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_2"]);
                    MainHandlerService.signalDecrypter.DisableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_3"]);
                    MainHandlerService.signalDecrypter.DisableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_4"]);
                    break;

                case 2:
                    MainHandlerService.signalDecrypter.DisableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_0"]);
                    MainHandlerService.signalDecrypter.EnableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_1"]);
                    MainHandlerService.signalDecrypter.DisableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_2"]);
                    MainHandlerService.signalDecrypter.DisableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_3"]);
                    MainHandlerService.signalDecrypter.DisableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_4"]);
                    break;

                case 3:
                    MainHandlerService.signalDecrypter.EnableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_0"]);
                    MainHandlerService.signalDecrypter.EnableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_1"]);
                    MainHandlerService.signalDecrypter.DisableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_2"]);
                    MainHandlerService.signalDecrypter.DisableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_3"]);
                    MainHandlerService.signalDecrypter.DisableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_4"]);
                    break;

                case 4:
                    MainHandlerService.signalDecrypter.DisableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_0"]);
                    MainHandlerService.signalDecrypter.DisableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_1"]);
                    MainHandlerService.signalDecrypter.EnableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_2"]);
                    MainHandlerService.signalDecrypter.DisableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_3"]);
                    MainHandlerService.signalDecrypter.DisableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_4"]);
                    break;

                case 5:
                    MainHandlerService.signalDecrypter.EnableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_0"]);
                    MainHandlerService.signalDecrypter.DisableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_1"]);
                    MainHandlerService.signalDecrypter.EnableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_2"]);
                    MainHandlerService.signalDecrypter.DisableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_3"]);
                    MainHandlerService.signalDecrypter.DisableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_4"]);
                    break;

                case 6:
                    MainHandlerService.signalDecrypter.DisableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_0"]);
                    MainHandlerService.signalDecrypter.EnableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_1"]);
                    MainHandlerService.signalDecrypter.EnableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_2"]);
                    MainHandlerService.signalDecrypter.DisableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_3"]);
                    MainHandlerService.signalDecrypter.DisableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_4"]);
                    break;

                case 7:
                    MainHandlerService.signalDecrypter.EnableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_0"]);
                    MainHandlerService.signalDecrypter.EnableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_1"]);
                    MainHandlerService.signalDecrypter.EnableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_2"]);
                    MainHandlerService.signalDecrypter.DisableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_3"]);
                    MainHandlerService.signalDecrypter.DisableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_4"]);
                    break;

                case 8:
                    MainHandlerService.signalDecrypter.DisableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_0"]);
                    MainHandlerService.signalDecrypter.DisableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_1"]);
                    MainHandlerService.signalDecrypter.DisableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_2"]);
                    MainHandlerService.signalDecrypter.EnableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_3"]);
                    MainHandlerService.signalDecrypter.DisableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_4"]);
                    break;

                case 9:
                    MainHandlerService.signalDecrypter.EnableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_0"]);
                    MainHandlerService.signalDecrypter.DisableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_1"]);
                    MainHandlerService.signalDecrypter.DisableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_2"]);
                    MainHandlerService.signalDecrypter.EnableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_3"]);
                    MainHandlerService.signalDecrypter.DisableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_4"]);
                    break;

                case 10:
                    MainHandlerService.signalDecrypter.DisableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_0"]);
                    MainHandlerService.signalDecrypter.EnableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_1"]);
                    MainHandlerService.signalDecrypter.DisableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_2"]);
                    MainHandlerService.signalDecrypter.EnableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_3"]);
                    MainHandlerService.signalDecrypter.DisableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_4"]);
                    break;

                case 11:
                    MainHandlerService.signalDecrypter.EnableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_0"]);
                    MainHandlerService.signalDecrypter.EnableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_1"]);
                    MainHandlerService.signalDecrypter.DisableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_2"]);
                    MainHandlerService.signalDecrypter.EnableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_3"]);
                    MainHandlerService.signalDecrypter.DisableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_4"]);
                    break;

                case 12:
                    MainHandlerService.signalDecrypter.DisableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_0"]);
                    MainHandlerService.signalDecrypter.DisableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_1"]);
                    MainHandlerService.signalDecrypter.EnableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_2"]);
                    MainHandlerService.signalDecrypter.EnableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_3"]);
                    MainHandlerService.signalDecrypter.DisableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_4"]);
                    break;

                case 13:
                    MainHandlerService.signalDecrypter.EnableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_0"]);
                    MainHandlerService.signalDecrypter.DisableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_1"]);
                    MainHandlerService.signalDecrypter.EnableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_2"]);
                    MainHandlerService.signalDecrypter.EnableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_3"]);
                    MainHandlerService.signalDecrypter.DisableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_4"]);
                    break;

                case 14:
                    MainHandlerService.signalDecrypter.DisableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_0"]);
                    MainHandlerService.signalDecrypter.EnableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_1"]);
                    MainHandlerService.signalDecrypter.EnableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_2"]);
                    MainHandlerService.signalDecrypter.EnableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_3"]);
                    MainHandlerService.signalDecrypter.DisableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_4"]);
                    break;

                case 15:
                    MainHandlerService.signalDecrypter.EnableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_0"]);
                    MainHandlerService.signalDecrypter.EnableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_1"]);
                    MainHandlerService.signalDecrypter.EnableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_2"]);
                    MainHandlerService.signalDecrypter.EnableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_3"]);
                    MainHandlerService.signalDecrypter.DisableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_4"]);
                    break;

                case 16:
                    MainHandlerService.signalDecrypter.DisableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_0"]);
                    MainHandlerService.signalDecrypter.DisableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_1"]);
                    MainHandlerService.signalDecrypter.DisableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_2"]);
                    MainHandlerService.signalDecrypter.DisableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_3"]);
                    MainHandlerService.signalDecrypter.EnableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_4"]);
                    break;

                case 17:
                    MainHandlerService.signalDecrypter.EnableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_0"]);
                    MainHandlerService.signalDecrypter.DisableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_1"]);
                    MainHandlerService.signalDecrypter.DisableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_2"]);
                    MainHandlerService.signalDecrypter.DisableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_3"]);
                    MainHandlerService.signalDecrypter.EnableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_4"]);
                    break;

                case 18:
                    MainHandlerService.signalDecrypter.DisableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_0"]);
                    MainHandlerService.signalDecrypter.EnableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_1"]);
                    MainHandlerService.signalDecrypter.DisableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_2"]);
                    MainHandlerService.signalDecrypter.DisableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_3"]);
                    MainHandlerService.signalDecrypter.EnableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_4"]);
                    break;

                case 19:
                    MainHandlerService.signalDecrypter.EnableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_0"]);
                    MainHandlerService.signalDecrypter.EnableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_1"]);
                    MainHandlerService.signalDecrypter.DisableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_2"]);
                    MainHandlerService.signalDecrypter.DisableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_3"]);
                    MainHandlerService.signalDecrypter.EnableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_4"]);
                    break;

                case 20:
                    MainHandlerService.signalDecrypter.DisableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_0"]);
                    MainHandlerService.signalDecrypter.DisableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_1"]);
                    MainHandlerService.signalDecrypter.EnableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_2"]);
                    MainHandlerService.signalDecrypter.DisableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_3"]);
                    MainHandlerService.signalDecrypter.EnableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_4"]);
                    break;

                case 21:
                    MainHandlerService.signalDecrypter.EnableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_0"]);
                    MainHandlerService.signalDecrypter.DisableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_1"]);
                    MainHandlerService.signalDecrypter.EnableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_2"]);
                    MainHandlerService.signalDecrypter.DisableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_3"]);
                    MainHandlerService.signalDecrypter.EnableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_4"]);
                    break;

                case 22:
                    MainHandlerService.signalDecrypter.DisableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_0"]);
                    MainHandlerService.signalDecrypter.EnableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_1"]);
                    MainHandlerService.signalDecrypter.EnableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_2"]);
                    MainHandlerService.signalDecrypter.DisableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_3"]);
                    MainHandlerService.signalDecrypter.EnableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_4"]);
                    break;

                case 23:
                    MainHandlerService.signalDecrypter.EnableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_0"]);
                    MainHandlerService.signalDecrypter.EnableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_1"]);
                    MainHandlerService.signalDecrypter.EnableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_2"]);
                    MainHandlerService.signalDecrypter.DisableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_3"]);
                    MainHandlerService.signalDecrypter.EnableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_4"]);
                    break;

                case 24:
                    MainHandlerService.signalDecrypter.DisableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_0"]);
                    MainHandlerService.signalDecrypter.DisableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_1"]);
                    MainHandlerService.signalDecrypter.DisableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_2"]);
                    MainHandlerService.signalDecrypter.EnableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_3"]);
                    MainHandlerService.signalDecrypter.EnableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_4"]);
                    break;

                case 25:
                    MainHandlerService.signalDecrypter.EnableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_0"]);
                    MainHandlerService.signalDecrypter.DisableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_1"]);
                    MainHandlerService.signalDecrypter.DisableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_2"]);
                    MainHandlerService.signalDecrypter.EnableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_3"]);
                    MainHandlerService.signalDecrypter.EnableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_4"]);
                    break;

                case 26:
                    MainHandlerService.signalDecrypter.DisableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_0"]);
                    MainHandlerService.signalDecrypter.EnableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_1"]);
                    MainHandlerService.signalDecrypter.DisableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_2"]);
                    MainHandlerService.signalDecrypter.EnableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_3"]);
                    MainHandlerService.signalDecrypter.EnableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_4"]);
                    break;

                case 27:
                    MainHandlerService.signalDecrypter.EnableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_0"]);
                    MainHandlerService.signalDecrypter.EnableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_1"]);
                    MainHandlerService.signalDecrypter.DisableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_2"]);
                    MainHandlerService.signalDecrypter.EnableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_3"]);
                    MainHandlerService.signalDecrypter.EnableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_4"]);
                    break;

                case 28:
                    MainHandlerService.signalDecrypter.DisableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_0"]);
                    MainHandlerService.signalDecrypter.DisableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_1"]);
                    MainHandlerService.signalDecrypter.EnableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_2"]);
                    MainHandlerService.signalDecrypter.EnableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_3"]);
                    MainHandlerService.signalDecrypter.EnableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_4"]);
                    break;

                case 29:
                    MainHandlerService.signalDecrypter.EnableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_0"]);
                    MainHandlerService.signalDecrypter.DisableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_1"]);
                    MainHandlerService.signalDecrypter.EnableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_2"]);
                    MainHandlerService.signalDecrypter.EnableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_3"]);
                    MainHandlerService.signalDecrypter.EnableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_4"]);
                    break;

                case 30:
                    MainHandlerService.signalDecrypter.DisableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_0"]);
                    MainHandlerService.signalDecrypter.EnableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_1"]);
                    MainHandlerService.signalDecrypter.EnableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_2"]);
                    MainHandlerService.signalDecrypter.EnableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_3"]);
                    MainHandlerService.signalDecrypter.EnableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_4"]);
                    break;

                case 31:
                    MainHandlerService.signalDecrypter.EnableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_0"]);
                    MainHandlerService.signalDecrypter.EnableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_1"]);
                    MainHandlerService.signalDecrypter.EnableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_2"]);
                    MainHandlerService.signalDecrypter.EnableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_3"]);
                    MainHandlerService.signalDecrypter.EnableSignal(IOBoardInformation["BOWLFEEDER_PROGRAMMING_BIT_4"]);
                    break;
            }

        }
    }
}
