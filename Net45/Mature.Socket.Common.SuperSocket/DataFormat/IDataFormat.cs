﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mature.Socket.Common.SuperSocket.DataFormat
{
    public interface IDataFormat
    {
        string Format<T>(T source);
    }
}