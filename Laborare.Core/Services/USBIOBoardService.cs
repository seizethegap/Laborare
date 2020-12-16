namespace Laborare.Core.Services
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    using Laborare.Core.Models;
    using Laborare.Core.Services;

    public static class USBIOBoardService
    {

        public static UInt32 numDevs; // number of devices
        public static string[] SN; // Serial Numbers of the I/O boards.
        public static string[] Desc; // I/O board descriptions
        public static UInt32[] hDIO; // handles to the I/O boards
        public static UInt32 listDevErrCode; // error code returned for listing the devices
        public static UInt32[] errCode; // last error code received. One error code per device.
        public static string[] errMsg; // last error message for the corresponding board.
        static StringBuilder tmpErrMsg = new StringBuilder(512);

        /* RP2005 Constructor
         * List of serial numbers passed in and parsed into StringBuilder sn and separated with commas, 
         * RP_OpenDIO will initialize all the boards in this string.
         *
         * Oct 29, 2020
         * Removing List<string> serial and the foreach to append user listed sn. This is pointless because
         * the ListDIO will find all connected devices and overwrite the list we created using user listed serial
         * numbers.
         * 
         */
        public static void Start()
        {
            // need to create temporary buffers to hold return string values for
            // board names and serial numbers
            StringBuilder sn = new StringBuilder(512);
            StringBuilder desc = new StringBuilder(512);

            try
            {
                numDevs = 0;
                listDevErrCode = IUSBIOBoardService.RP_ListDIO(ref numDevs, sn, desc);
            }
            catch
            {
                if (!System.IO.File.Exists(Environment.SystemDirectory + "\\RP2005.dll") &&
                    !System.IO.File.Exists(Directory.GetCurrentDirectory() + "\\RP2005.dll"))
                {
                    listDevErrCode = 500; // rp2005.dll not found
                }
                else
                {
                    listDevErrCode = 1000; // unknown error occured
                }
            }
            if (listDevErrCode == 0)
            {
                SN = sn.ToString().Split(',');
                Desc = desc.ToString().Split(',');
                hDIO = new uint[numDevs];
                errCode = new uint[numDevs];
                errMsg = new string[numDevs];

                for (int i = 0; i < numDevs; i++)
                { // open the boards
                    hDIO[i] = 0;
                    try
                    {
                        errCode[i] = IUSBIOBoardService.RP_OpenDIO(SN[i], ref hDIO[i]);
                        if (Desc[i].Contains("8DI 8DO")) // half board: single 8 bit input port, single 8 bit output port
                        {
                            // half board
                            MainHandlerService.ActiveIOBoards.Add(SN[i], new HalfIOBoard(i, SN[i], Desc[i]));
                        }
                        else if (Desc[i].Contains("16DI 16DO")) // full board: dual 8 bit input ports, dual 8 bit output ports
                        {
                            MainHandlerService.ActiveIOBoards.Add(SN[i], new FullIOBoard(i, SN[i], Desc[i]));
                        }
                        else
                        {
                            // custom board not yet implemented
                            throw new IOException();
                        }
                        
                    }
                    catch
                    {
                        errCode[i] = 1000;
                    }
                }
            }

            // Start the ReadInputSignalThread
            ReadInputSignalService.Start();
        }


        /* ReadPort - read a port.
         * Parameters:
         * brd - 0 based board number to read.
         * port - port number to read. 0 is input port 0, 1 is input port 1, 2 is input port 2.
         *        port 16 is output port 0, 17 is output port 1, 18 is output port 2.
         *        Note: reading outputs will not return actual state of the bit. it will return the last
         *        output value.
         * value - if the port read was successful, the "value" parameter will contain the value read from the port.
         * 
         * Return Value:
         * Returns 0 if successful, otherwise it returns false. You can read the error string 
         * for the operation by accessing the errMsg array using the brd number as the index 
         * into the array.
         */

        public static UInt32 ReadPort(int brd, byte port, ref byte value)
        {
            if (brd < numDevs)
            {
                errCode[brd] = IUSBIOBoardService.RP_ReadPort(hDIO[brd], port, ref value, tmpErrMsg);
                if (errCode[brd] == 0)
                {
                    return 0;
                }
                else
                {
                    errMsg[brd] = tmpErrMsg.ToString();
                    return errCode[brd];
                }
            }
            else
            {
                return 1001; // invalid number of boards
            }
        }
        /* WritePort - write data to a port
         * Parameters:
         * brd - 0 based board number to read.
         * port - output port 0 starts at 16. output port 1 is 17.
         * value - value to write to the port.
         */
        public static UInt32 WritePort(int brd, byte port, byte value)
        {
            if (brd < numDevs)
            {
                errCode[brd] = IUSBIOBoardService.RP_WritePort(hDIO[brd], port, value, tmpErrMsg);
                if (errCode[brd] == 0)
                {
                    return 0;
                }
                else
                {
                    errMsg[brd] = tmpErrMsg.ToString();
                    return errCode[brd];
                }
            }
            else
            {
                return 1001; // invalid board number. must be between 0 and the number of devices
            }
        }

        // destructor
        public static void Stop()
        {
            ReadInputSignalService.Stop();

            for (int i = 0; i < numDevs; i++)
            {
                // Remove the object from our dictionary before closing the connection.
                MainHandlerService.ActiveIOBoards.Remove(SN[i]);
                errCode[i] = IUSBIOBoardService.RP_CloseDIO(hDIO[i]);
            }
        }
    }
}
