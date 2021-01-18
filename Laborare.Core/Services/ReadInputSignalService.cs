namespace Laborare.Core.Services
{
    using System;
    using System.Threading.Tasks;
    using System.Threading;
    using System.Collections.Generic;

    using Laborare.Core.Models;

    public class ReadInputSignalService
    {
        public CancellationTokenSource CancelReadInputSignalThread;
        public byte InputSignal_Port0, InputSignal_Port1;

        public int Delay;

        private IIOBoard _CurrentIOBoard;

        public ReadInputSignalService(IIOBoard io_board)
        {
            _CurrentIOBoard = io_board;
            Start();
        }

        /// <summary>
        /// This thread is responsible for constantly updating our IOBoard Models with the correct 
        /// boolean value based on our IOBoard input signals. Start this thread after RP2005 has completed
        /// detecting all of our boards and populating the dictionary which holds the active Io boards.
        /// Use the Stop function in the RP2005 destructor before it closes connection to the boards.
        /// </summary>
        public void Start()
        {
            CancelReadInputSignalThread = new CancellationTokenSource();

            Delay = Convert.ToInt32(MainHandlerService.Read_Io_Interval_Setting);

            var task = Task.Run(() =>
            {
                while (!CancelReadInputSignalThread.Token.IsCancellationRequested)
                {
                    uint isSuccess = USBIOBoardService.ReadPort(_CurrentIOBoard.BoardNum, 0, ref InputSignal_Port0);
                    _CurrentIOBoard.InputSignal_Port0 = InputSignal_Port0;
                    isSuccess = USBIOBoardService.ReadPort(_CurrentIOBoard.BoardNum, 1, ref InputSignal_Port1);
                    _CurrentIOBoard.InputSignal_Port1 = InputSignal_Port1;
                }
            }, CancelReadInputSignalThread.Token);
        }

        public void Stop()
        {
            CancelReadInputSignalThread.Cancel();
            CancelReadInputSignalThread.Dispose();
        }

        public void Restart()
        {
            Stop();
            // give the token some time to completely cancel and dispose before restarting the thread
            // to avoid exceptions.
            Thread.Sleep(500);
            Start();
        }
    }
}
