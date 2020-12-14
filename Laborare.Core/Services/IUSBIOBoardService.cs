namespace Laborare.Core.Services
{
    using System;
    using System.Runtime.InteropServices;
    using System.Text;

    public class IUSBIOBoardService
    {
        [DllImport("RP2005.dll")]
        public static extern UInt32 RP_ListDIO(ref UInt32 NumBrds, StringBuilder SN, StringBuilder Dsc);

        [DllImport("RP2005.dll")]
        public static extern UInt32 RP_OpenDIO(string SN, ref UInt32 hDIO);

        [DllImport("RP2005.dll")]
        public static extern UInt32 RP_CloseDIO(UInt32 hDIO);

        [DllImport("RP2005.dll")]
        public static extern UInt32 RP_GetVer(UInt32 hDIO, StringBuilder SwVer, StringBuilder ErrMsg);

        [DllImport("RP2005.dll")]
        public static extern UInt32 RP_ReadPort(UInt32 hDIO, byte ucPort, ref byte PVal, StringBuilder ErrMsg);

        [DllImport("RP2005.dll")]
        public static extern UInt32 RP_WritePort(UInt32 hDIO, byte ucPort, byte PVal, StringBuilder ErrMsg);
    }
}
