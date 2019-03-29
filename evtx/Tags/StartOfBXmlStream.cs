﻿using System;
using System.IO;
using NLog;

namespace evtx.Tags
{
    public class StartOfBXmlStream : IBinXml
    {
        public StartOfBXmlStream(long chunkOffset, long recordPosition, BinaryReader dataStream)
        {
            ChunkOffset = chunkOffset;
            RecordPosition = recordPosition;
            Size = 4;
            
            MajorVer = dataStream.ReadByte();
            
            MinorVer = dataStream.ReadByte();
            
            Flags = dataStream.ReadByte();

            var l = LogManager.GetLogger("BuildTag");
            l.Trace($"Major: {MajorVer} Minor: {MinorVer} Flags: {Flags}");
        }

        public int MajorVer { get; }
        public int MinorVer { get; }
        public int Flags { get; }

        public long ChunkOffset { get; }
        public long RecordPosition { get; }
        public int Size { get; }

        public string AsXml()
        {
            throw new NotImplementedException();
        }
    }
}