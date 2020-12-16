namespace Laborare.Core.Services
{
    using System;
    using System.IO;
    using System.IO.Ports;
    using System.Text;
    using System.Windows;

    using System.Threading;
    using System.Threading.Tasks;

    public class RS232ConnectionService : IConnectionService
    {
        private SerialPort _SerialConnection;
        private string _PortName;
        private int _BaudRate;
        private Handshake _Handshake = Handshake.None;
        private Parity _Parity = Parity.None;
        private int _DataBits;
        private StopBits _StopBits = StopBits.One;
        private int _ReadTimeout;
        private int _WriteTimeout;

        private string _ReceivedData;

        private int _Comms_Id;

        #region Getter/Setters
       
        #endregion

        public RS232ConnectionService(string port_name, int baud_rate, int data_bits,
            int read_timeout, int write_timeout, int comms_id)
        {
            _SerialConnection = new SerialPort();
            _PortName = port_name;
            _BaudRate = baud_rate;
            _DataBits = data_bits;
            _ReadTimeout = read_timeout;
            _WriteTimeout = write_timeout;
            _Comms_Id = comms_id;
            Connect();
        }

        public void Connect()
        {
            _SerialConnection.PortName = _PortName;
            _SerialConnection.BaudRate = _BaudRate;
            _SerialConnection.Handshake = _Handshake;
            _SerialConnection.Parity = _Parity;
            _SerialConnection.DataBits = _DataBits;
            _SerialConnection.StopBits = _StopBits;
            _SerialConnection.ReadTimeout = _ReadTimeout;
            _SerialConnection.WriteTimeout = _WriteTimeout;

            try
            {
                _SerialConnection.Open();
                _SerialConnection.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(Receive);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
        }

        public void Disconnect()
        {
            _SerialConnection.Close();
        }

        public async void Send(string data)
        {
            if (_SerialConnection.IsOpen)
            {
                try
                {
                    // Send the binary data out the port
                    byte[] hexstring = Encoding.ASCII.GetBytes(data);
                    /* There is an intermittent problem that I came across where
                     * if I write more than one byte in succession without a 
                     * delay, the PIC I'm communicating with will crash. I suspect
                     * this is due to PC timing issues and they are not directly connected
                     * to the COM port. The workaround is a small delay of 1ms in between
                     * characters.
                     */
                    foreach (byte hexval in hexstring)
                    {
                        byte[] _hexval = new byte[] { hexval }; // need to convert byte to byte[] to write
                        _SerialConnection.Write(_hexval, 0, 1);
                        System.Threading.Thread.Sleep(1);
                    }
                    _SerialConnection.Write("\r");
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.ToString());
                }
            }
            Thread.Sleep(50);
        }
        public void Receive(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                _ReceivedData = _SerialConnection.ReadLine();
                //Thread.Sleep(100);
            }
            catch (Exception er)
            {
                
            }
        }

        public string ReceiveMessage()
        {
            return _ReceivedData;
        }

    }
}
