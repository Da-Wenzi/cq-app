using System;

namespace CQ.Note.Core.Events
{
    public class PersistentImg : IEvent
    {
        public string Base64 { get; set; }

        public string FileName { get; set; }

        public string Path { get; set; }


        public byte[] Bytes => Convert.FromBase64String(Base64);
    }
}
