﻿using System;
using System.Collections.Generic;

namespace Mature.Socket
{
    public interface ITCPServer
    {
        IEnumerable<SessionInfo> GetAllSession();
        SessionInfo GetSessionByID(string sessionID);
        bool Start();
        void Stop();
        event EventHandler<SessionInfo> NewSessionConnected;
        event Action<ISessionWrapper, StringPackageInfo> NewRequestReceived;
        event EventHandler<SessionInfo> SessionClosed;
    }
}
