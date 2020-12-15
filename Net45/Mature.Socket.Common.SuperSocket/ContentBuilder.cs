﻿using Mature.Socket.Common.SuperSocket.Compression;
using Mature.Socket.Common.SuperSocket.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mature.Socket.Common.SuperSocket
{
    //数据完整性校验
    //数据压缩
    //报文格式：key（20位）压缩标志位（1位）报文长度（4位）校验位（16位）正文
    //对于报文中的数值类型的占位符，按照右面高位的格式传输（使用的是BitConverter转换和读取字节数组）
    public class ContentBuilder : IContentBuilder
    {
        ICompression compression;
        IDataValidation dataValidation;
        public Encoding Encoding { get; set; } = Encoding.UTF8;
        public ContentBuilder(ICompression compression, IDataValidation dataValidation)
        {
            this.compression = compression;
            this.dataValidation = dataValidation;
        }
        public byte[] Builder(string key, string body, string messageId)
        {
            return Builder(key, body, messageId, false);
        }

        public byte[] Builder(string key, string body, string messageId, bool isCompress)
        {
            byte[] bodyBuffer = Encoding.GetBytes(body);
            var validation = dataValidation.Validation(bodyBuffer);
            if (isCompress)
            {
                bodyBuffer = compression.Compress(bodyBuffer);
            }
            List<byte> data = new List<byte>();
            data.AddRange(Encoding.ASCII.GetBytes(key));
            data.AddRange(BitConverter.GetBytes(isCompress));
            data.AddRange(BitConverter.GetBytes(bodyBuffer.Length).Reverse());
            data.AddRange(Encoding.ASCII.GetBytes(messageId));
            data.AddRange(validation);
            data.AddRange(bodyBuffer);
            return data.ToArray();
        }
    }
}
