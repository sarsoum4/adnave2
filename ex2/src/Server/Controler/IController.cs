using System.Net.Sockets;
using Server.TheModel;
using Server.View;


namespace Server.Controler
{
    public interface IController
    {
        string ExecuteCommand(string commandLine, TcpClient client);
        void SetView(IView view);
        void SetModel(IModel model);
    }
}