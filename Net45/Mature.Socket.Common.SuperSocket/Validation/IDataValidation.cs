﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mature.Socket.Common.SuperSocket.Validation
{
    public interface IDataValidation
    {
        int Length { get; }
        byte[] Validation(byte[] source);
    }
}
