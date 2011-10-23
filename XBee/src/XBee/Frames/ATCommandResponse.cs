﻿using System;
using System.Text;

namespace XBee.Frames
{
    public class ATCommandResponse : XBeeFrame
    {
        private readonly PacketParser parser;

        public AT Command { get; private set; }
        public byte CommandStatus { get; private set; }

        public ATCommandResponse(PacketParser parser)
        {
            this.parser = parser;
            CommandId = XBeeAPICommandId.AT_COMMAND_RESPONSE;
        }

        public ATCommandResponse()
        {
            CommandId = XBeeAPICommandId.AT_COMMAND_RESPONSE;
        }

        public override byte[] ToByteArray()
        {
            return new byte[] { };
        }

        public override void Parse()
        {
            FrameId = (byte)parser.ReadByte();
            Command = parser.ReadATCommand();
            CommandStatus = (byte)parser.ReadByte();

            if (parser.HasMoreData()) {
                Console.WriteLine("has data!");
            }
        }
    }
}
