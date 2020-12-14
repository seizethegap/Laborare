namespace Laborare.Core.Commands.IOCommands
{
    using Laborare.Core.Services;

    using System.Threading;
    using System.Windows.Input;

    public static class RestartIOServiceCommand
    {
        /// <summary>
        /// This command calls the Stop command in USBIOService which will close all connections 
        /// and removes the objects from our ActiveIoBoards dictionary. Then it will restart the 
        /// USBIOService which redetects any connected Io boards.
        /// </summary>
        public static void Execute()
        {
            USBIOBoardService.Stop();
            // lets give USBIOService half a second to handle its business
            Thread.Sleep(500);
            // now restart that
            USBIOBoardService.Start();
        }
    }
}
