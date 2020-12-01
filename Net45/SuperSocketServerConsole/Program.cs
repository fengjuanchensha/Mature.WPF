﻿using Mature.Socket;
using Mature.Socket.Common.SuperSocket;
using Mature.Socket.Common.SuperSocket.Compression;
using Mature.Socket.Common.SuperSocket.Validation;
using Mature.Socket.Server.SuperSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SuperSocketServerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ITCPServer server = new TCPServer();
            server.Start();
            server.NewSessionConnected += Server_NewSessionConnected;
            server.SessionClosed += Server_SessionClosed;
            server.NewRequestReceived += Server_NewRequestReceived;
            Console.ReadLine();
        }

        private static void Server_NewRequestReceived(ISessionWrapper arg1, RequestInfo arg2)
        {
            IContentBuilder contentBuilder = new ContentBuilder(new GZip(), new MD5DataValidation());
            Console.WriteLine($"接收到消息，Key：{arg2.Key} Body:{arg2.Body} MessageId:{arg2.Parameters[0]}");

            var data = contentBuilder.Builder(arg2.Key, arg2.Body, arg2.Parameters[0]);
            arg1.Send(data, 0, data.Length);
        }

        private static void Server_SessionClosed(object sender, SessionInfo e)
        {
            Console.WriteLine($"连接断开：{e.SessionID}");
        }

        private static void Server_NewSessionConnected(object sender, SessionInfo e)
        {
            Console.WriteLine($"新连接建立：{e.SessionID}");
        }
    }
}
