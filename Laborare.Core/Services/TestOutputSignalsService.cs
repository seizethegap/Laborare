namespace Laborare.Core.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using System.Threading;
    using System.Threading.Tasks;

    using Laborare.Core.Models;

    public class TestOutputSignalsService
    {
        private CancellationTokenSource CancelTestOutputSignals1;
        private CancellationTokenSource CancelTestOutputSignals2;
        private CancellationTokenSource CancelTestOutputSignals3;
        private CancellationTokenSource CancelTestOutputSignals4;
        private CancellationTokenSource CancelTestOutputSignals5;
        private CancellationTokenSource CancelTestOutputSignals6;
        private CancellationTokenSource CancelTestOutputSignals7;
        private CancellationTokenSource CancelTestOutputSignals8;
        private CancellationTokenSource CancelTestOutputSignals9;
        private CancellationTokenSource CancelTestOutputSignals10;
        private CancellationTokenSource CancelTestOutputSignals11;
        private CancellationTokenSource CancelTestOutputSignals12;
        private CancellationTokenSource CancelTestOutputSignals13;
        private CancellationTokenSource CancelTestOutputSignals14;
        private CancellationTokenSource CancelTestOutputSignals15;
        private CancellationTokenSource CancelTestOutputSignals16;


        public TestOutputSignalsService()
        {
            
        }

        public Dictionary<string, IIOBoard> IOBoards
        {
            get
            {
                return MainHandlerService.ActiveIOBoards;
            }
            set
            {
                MainHandlerService.ActiveIOBoards = value;
            }
        }

        public void Start()
        {
            TestSol1();
            TestSol2();
            TestSol3();
            TestSol4();
            TestSol5();
            TestSol6();
            TestSol7();
            TestSol8();
            TestSol9();
            TestSol10();
            TestSol11();
            TestSol12();
            TestSol13();
            TestSol14();
            TestSol15();
            TestSol16();
        }

        public void Stop()
        {
            CancelTestOutputSignals1.Cancel();
            CancelTestOutputSignals1.Dispose();
            Thread.Sleep(50);
            CancelTestOutputSignals2.Cancel();
            CancelTestOutputSignals2.Dispose();
            Thread.Sleep(50);
            CancelTestOutputSignals3.Cancel();
            CancelTestOutputSignals3.Dispose();
            Thread.Sleep(50);
            CancelTestOutputSignals4.Cancel();
            CancelTestOutputSignals4.Dispose();
            Thread.Sleep(50);
            CancelTestOutputSignals5.Cancel();
            CancelTestOutputSignals5.Dispose();
            Thread.Sleep(50);
            CancelTestOutputSignals6.Cancel();
            CancelTestOutputSignals6.Dispose();
            Thread.Sleep(50);
            CancelTestOutputSignals7.Cancel();
            CancelTestOutputSignals7.Dispose();
            Thread.Sleep(50);
            CancelTestOutputSignals8.Cancel();
            CancelTestOutputSignals8.Dispose();
            Thread.Sleep(50);
            CancelTestOutputSignals9.Cancel();
            CancelTestOutputSignals9.Dispose();
            Thread.Sleep(50);
            CancelTestOutputSignals10.Cancel();
            CancelTestOutputSignals10.Dispose();
            Thread.Sleep(50);
            CancelTestOutputSignals11.Cancel();
            CancelTestOutputSignals11.Dispose();
            Thread.Sleep(50);
            CancelTestOutputSignals12.Cancel();
            CancelTestOutputSignals12.Dispose();
            Thread.Sleep(50);
            CancelTestOutputSignals13.Cancel();
            CancelTestOutputSignals13.Dispose();
            Thread.Sleep(50);
            CancelTestOutputSignals14.Cancel();
            CancelTestOutputSignals14.Dispose();
            Thread.Sleep(50);
            CancelTestOutputSignals15.Cancel();
            CancelTestOutputSignals15.Dispose();
            Thread.Sleep(50);
            CancelTestOutputSignals16.Cancel();
            CancelTestOutputSignals16.Dispose();


        }

        private void TestSol1()
        {
            CancelTestOutputSignals1 = new CancellationTokenSource();
            var task = Task.Run(() =>
            {
                while (!CancelTestOutputSignals1.Token.IsCancellationRequested)
                {
                    foreach (var board in IOBoards)
                    {
                        board.Value.sol1 = true;
                        Thread.Sleep(40);
                        board.Value.sol1 = false;
                    }
                    Thread.Sleep(20);
                }
            }, CancelTestOutputSignals1.Token);
        }

        private void TestSol2()
        {
            CancelTestOutputSignals2 = new CancellationTokenSource();
            var task = Task.Run(() =>
            {
                while (!CancelTestOutputSignals2.Token.IsCancellationRequested)
                {
                    foreach (var board in IOBoards)
                    {
                        board.Value.sol2 = true;
                        Thread.Sleep(40);
                        board.Value.sol2 = false;
                    }
                    Thread.Sleep(30);
                }
            }, CancelTestOutputSignals2.Token);
        }

        private void TestSol3()
        {
            CancelTestOutputSignals3 = new CancellationTokenSource();
            var task = Task.Run(() =>
            {
                while (!CancelTestOutputSignals3.Token.IsCancellationRequested)
                {
                    foreach (var board in IOBoards)
                    {
                        board.Value.sol3 = true;
                        Thread.Sleep(40);
                        board.Value.sol3 = false;
                    }
                    Thread.Sleep(10);
                }
            }, CancelTestOutputSignals3.Token);
        }

        private void TestSol4()
        {
            CancelTestOutputSignals4 = new CancellationTokenSource();
            var task = Task.Run(() =>
            {
                while (!CancelTestOutputSignals4.Token.IsCancellationRequested)
                {
                    foreach (var board in IOBoards)
                    {
                        board.Value.sol4 = true;
                        Thread.Sleep(40);
                        board.Value.sol4 = false;
                    }
                    Thread.Sleep(60);
                }
            }, CancelTestOutputSignals4.Token);
        }

        private void TestSol5()
        {
            CancelTestOutputSignals5 = new CancellationTokenSource();
            var task = Task.Run(() =>
            {
                while (!CancelTestOutputSignals5.Token.IsCancellationRequested)
                {
                    foreach (var board in IOBoards)
                    {
                        board.Value.sol5 = true;
                        Thread.Sleep(40);
                        board.Value.sol5 = false;
                    }
                    Thread.Sleep(70);
                }
            }, CancelTestOutputSignals5.Token);
        }

        private void TestSol6()
        {
            CancelTestOutputSignals6 = new CancellationTokenSource();
            var task = Task.Run(() =>
            {
                while (!CancelTestOutputSignals6.Token.IsCancellationRequested)
                {
                    foreach (var board in IOBoards)
                    {
                        board.Value.sol6 = true;
                        Thread.Sleep(40);
                        board.Value.sol6 = false;
                    }
                    Thread.Sleep(60);
                }
            }, CancelTestOutputSignals6.Token);
        }

        private void TestSol7()
        {
            CancelTestOutputSignals7 = new CancellationTokenSource();
            var task = Task.Run(() =>
            {
                while (!CancelTestOutputSignals7.Token.IsCancellationRequested)
                {
                    foreach (var board in IOBoards)
                    {
                        board.Value.sol7 = true;
                        Thread.Sleep(40);
                        board.Value.sol7 = false;
                    }
                    Thread.Sleep(40);
                }
            }, CancelTestOutputSignals7.Token);
        }

        private void TestSol8()
        {
            CancelTestOutputSignals8 = new CancellationTokenSource();
            var task = Task.Run(() =>
            {
                while (!CancelTestOutputSignals8.Token.IsCancellationRequested)
                {
                    foreach (var board in IOBoards)
                    {
                        board.Value.sol8 = true;
                        Thread.Sleep(40);
                        board.Value.sol8 = false;
                    }
                    Thread.Sleep(50);
                }
            }, CancelTestOutputSignals8.Token);
        }

        private void TestSol9()
        {
            CancelTestOutputSignals9 = new CancellationTokenSource();
            var task = Task.Run(() =>
            {
                while (!CancelTestOutputSignals9.Token.IsCancellationRequested)
                {
                    foreach (var board in IOBoards)
                    {
                        board.Value.sol9 = true;
                        Thread.Sleep(40);
                        board.Value.sol9 = false;
                    }
                    Thread.Sleep(20);
                }
            }, CancelTestOutputSignals9.Token);
        }

        private void TestSol10()
        {
            CancelTestOutputSignals10 = new CancellationTokenSource();
            var task = Task.Run(() =>
            {
                while (!CancelTestOutputSignals10.Token.IsCancellationRequested)
                {
                    foreach (var board in IOBoards)
                    {
                        board.Value.sol10 = true;
                        Thread.Sleep(40);
                        board.Value.sol10 = false;
                    }
                    Thread.Sleep(30);
                }
            }, CancelTestOutputSignals10.Token);
        }

        private void TestSol11()
        {
            CancelTestOutputSignals11 = new CancellationTokenSource();
            var task = Task.Run(() =>
            {
                while (!CancelTestOutputSignals11.Token.IsCancellationRequested)
                {
                    foreach (var board in IOBoards)
                    {
                        board.Value.sol11 = true;
                        Thread.Sleep(40);
                        board.Value.sol11 = false;
                    }
                    Thread.Sleep(10);
                }
            }, CancelTestOutputSignals11.Token);
        }

        private void TestSol12()
        {
            CancelTestOutputSignals12 = new CancellationTokenSource();
            var task = Task.Run(() =>
            {
                while (!CancelTestOutputSignals12.Token.IsCancellationRequested)
                {
                    foreach (var board in IOBoards)
                    {
                        board.Value.sol12 = true;
                        Thread.Sleep(40);
                        board.Value.sol12 = false;
                    }
                    Thread.Sleep(60);
                }
            }, CancelTestOutputSignals12.Token);
        }

        private void TestSol13()
        {
            CancelTestOutputSignals13 = new CancellationTokenSource();
            var task = Task.Run(() =>
            {
                while (!CancelTestOutputSignals13.Token.IsCancellationRequested)
                {
                    foreach (var board in IOBoards)
                    {
                        board.Value.sol13 = true;
                        Thread.Sleep(40);
                        board.Value.sol13 = false;
                    }
                    Thread.Sleep(70);
                }
            }, CancelTestOutputSignals13.Token);
        }

        private void TestSol14()
        {
            CancelTestOutputSignals14 = new CancellationTokenSource();
            var task = Task.Run(() =>
            {
                while (!CancelTestOutputSignals14.Token.IsCancellationRequested)
                {
                    foreach (var board in IOBoards)
                    {
                        board.Value.sol14 = true;
                        Thread.Sleep(40);
                        board.Value.sol14 = false;
                    }
                    Thread.Sleep(60);
                }
            }, CancelTestOutputSignals14.Token);
        }

        private void TestSol15()
        {
            CancelTestOutputSignals15 = new CancellationTokenSource();
            var task = Task.Run(() =>
            {
                while (!CancelTestOutputSignals15.Token.IsCancellationRequested)
                {
                    foreach (var board in IOBoards)
                    {
                        board.Value.sol15 = true;
                        Thread.Sleep(40);
                        board.Value.sol15 = false;
                    }
                    Thread.Sleep(40);
                }
            }, CancelTestOutputSignals15.Token);
        }

        private void TestSol16()
        {
            CancelTestOutputSignals16 = new CancellationTokenSource();
            var task = Task.Run(() =>
            {
                while (!CancelTestOutputSignals16.Token.IsCancellationRequested)
                {
                    foreach (var board in IOBoards)
                    {
                        board.Value.sol16 = true;
                        Thread.Sleep(40);
                        board.Value.sol16 = false;
                    }
                    Thread.Sleep(50);
                }
            }, CancelTestOutputSignals16.Token);
        }
    }
}
