namespace Laborare.Core.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Reflection;

    using Laborare.Core.Models;

    public class IOBoardSignalDecrypterService
    {
        public IOBoardSignalDecrypterService(Dictionary<string, IIOBoard> io_boards)
        {
            IOBoards = io_boards;
        }

        public Dictionary<string, IIOBoard> IOBoards;

        

        /// <summary>
        /// The EnableSignal function will take in the string array passed from the given key of
        /// IoDeviceInfo from the MainHandlerService. It will then seek out the location of the 
        /// signal and enable it.
        /// </summary>
        /// <param name="command_value"></param>
        /// <returns></returns>
        public bool EnableSignal(string[] command_value)
        {
            if (IOBoards.ContainsKey(command_value[0]))
            {
                switch (command_value[1])
                {
                    case "sol1":
                        IOBoards[command_value[0]].sol1 = true;
                        break;

                    case "sol2":
                        IOBoards[command_value[0]].sol2 = true;
                        break;

                    case "sol3":
                        IOBoards[command_value[0]].sol3 = true;
                        break;

                    case "sol4":
                        IOBoards[command_value[0]].sol4 = true;
                        break;

                    case "sol5":
                        IOBoards[command_value[0]].sol5 = true;
                        break;

                    case "sol6":
                        IOBoards[command_value[0]].sol6 = true;
                        break;

                    case "sol7":
                        IOBoards[command_value[0]].sol7 = true;
                        break;

                    case "sol8":
                        IOBoards[command_value[0]].sol8 = true;
                        break;

                    case "sol9":
                        IOBoards[command_value[0]].sol9 = true;
                        break;

                    case "sol10":
                        IOBoards[command_value[0]].sol10 = true;
                        break;
                        
                    case "sol11":
                        IOBoards[command_value[0]].sol11 = true;
                        break;

                    case "sol12":
                        IOBoards[command_value[0]].sol12 = true;
                        break;

                    case "sol13":
                        IOBoards[command_value[0]].sol13 = true;
                        break;

                    case "sol14":
                        IOBoards[command_value[0]].sol14 = true;
                        break;

                    case "sol15":
                        IOBoards[command_value[0]].sol15 = true;
                        break;

                    case "sol16":
                        IOBoards[command_value[0]].sol16 = true;
                        break;
                }
                return true;
            }
            else
            {
                // display error msg because board does not exist.
                return false;
            }
        }

        public bool DisableSignal(string[] command_value)
        {
            if (IOBoards.ContainsKey(command_value[0]))
            {
                switch (command_value[1])
                {
                    case "sol1":
                        IOBoards[command_value[0]].sol1 = false;
                        break;

                    case "sol2":
                        IOBoards[command_value[0]].sol2 = false;
                        break;

                    case "sol3":
                        IOBoards[command_value[0]].sol3 = false;
                        break;

                    case "sol4":
                        IOBoards[command_value[0]].sol4 = false;
                        break;

                    case "sol5":
                        IOBoards[command_value[0]].sol5 = false;
                        break;

                    case "sol6":
                        IOBoards[command_value[0]].sol6 = false;
                        break;

                    case "sol7":
                        IOBoards[command_value[0]].sol7 = false;
                        break;

                    case "sol8":
                        IOBoards[command_value[0]].sol8 = false;
                        break;

                    case "sol9":
                        IOBoards[command_value[0]].sol9 = false;
                        break;

                    case "sol10":
                        IOBoards[command_value[0]].sol10 = false;
                        break;

                    case "sol11":
                        IOBoards[command_value[0]].sol11 = false;
                        break;

                    case "sol12":
                        IOBoards[command_value[0]].sol12 = false;
                        break;

                    case "sol13":
                        IOBoards[command_value[0]].sol13 = false;
                        break;

                    case "sol14":
                        IOBoards[command_value[0]].sol14 = false;
                        break;

                    case "sol15":
                        IOBoards[command_value[0]].sol15 = false;
                        break;

                    case "sol16":
                        IOBoards[command_value[0]].sol16 = false;
                        break;
                }
                return true;
            }
            else
            {
                // display error msg because board does not exist.
                return false;
            }
        }
    }
}
