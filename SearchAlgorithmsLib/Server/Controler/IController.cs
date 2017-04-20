using System.Net.Sockets;

namespace Server.Controler
{
    public interface IController
    {
        string ExecuteCommand(string commandLine, TcpClient client);
    }
}