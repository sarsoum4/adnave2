﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server.Controler
{
    public interface ICommand
    {
        string Execute(string[] args, TcpClient client = null);
    }
}
