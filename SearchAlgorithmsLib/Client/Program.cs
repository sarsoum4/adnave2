using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {

            
            string port = ConfigurationManager.AppSettings["port"].ToString();
            int portInt = Convert.ToInt32(port);

            Client client = new Client(portInt);

            client.Connect();
            Console.ReadKey();
        }
    }
}
