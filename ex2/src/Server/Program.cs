using Server.Controler;
using Server.TheModel;
using Server.View;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {

            
            IModel model = new TheModel.Model();
            IController controler = new Controller(model);
            //controler.SetModel(model);
            IView view = new ClientHandler(controler);
            controler.SetView(view);
            
            string port = ConfigurationManager.AppSettings["port"].ToString();
            MVCServer server = new MVCServer(Convert.ToInt32(port), view);
            server.Start();
            Console.ReadKey();


        }
    }
}
