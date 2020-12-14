namespace Laborare.Services
{
    using System;
    using System.Threading.Tasks;
    using System.Threading;
    using System.Collections.Generic;

    public static class ReadInputSignalService
    {
        public static CancellationTokenSource CancelReadInputSignalThread;
        public static byte InputSignal_Port0, InputSignal_Port1;

        public static int Delay;

        /// <summary>
        /// This thread is responsible for constantly updating our IOBoard Models with the correct 
        /// boolean value based on our IOBoard input signals. Start this thread after RP2005 has completed
        /// detecting all of our boards and populating the dictionary which holds the active Io boards.
        /// Use the Stop function in the RP2005 destructor before it closes connection to the boards.
        /// </summary>
        public static void Start()
        {
            CancelReadInputSignalThread = new CancellationTokenSource();

            Delay = Convert.ToInt32(MainHandlerService.Read_Io_Interval_Setting);

            var task = Task.Run(() =>
            {
                while (!CancelReadInputSignalThread.Token.IsCancellationRequested)
                {
                    foreach (var board in MainHandlerService.ActiveIOBoards)
                    {
                        uint isSuccess = USBIOBoardService.ReadPort(board.Value.BoardNum, 0, ref InputSignal_Port0);
                        board.Value.InputSignal_Port0 = InputSignal_Port0;
                        isSuccess = USBIOBoardService.ReadPort(board.Value.BoardNum, 1, ref InputSignal_Port1);
                        board.Value.InputSignal_Port1 = InputSignal_Port1;
                    }
                    // added a sleep here so that the thread won't overwhelm the usb board when parsing
                    Thread.Sleep(Delay);
                }
            }, CancelReadInputSignalThread.Token);
        }

        public static void Stop()
        {
            CancelReadInputSignalThread.Cancel();
            CancelReadInputSignalThread.Dispose();
        }

        public static void Restart()
        {
            Stop();
            // give the token some time to completely cancel and dispose before restarting the thread
            // to avoid exceptions.
            Thread.Sleep(500);
            Start();
        }
    }
}
