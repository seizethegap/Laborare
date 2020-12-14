namespace Laborare.Core.Services
{
    public interface IConnectionService
    {
        void Connect();
        string ReceiveMessage();
        void Send(string msg);
        void Disconnect();
    }
}
