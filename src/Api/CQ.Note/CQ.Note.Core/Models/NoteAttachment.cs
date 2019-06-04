using System;

namespace CQ.Note.Core.Models
{
    public class NoteAttachment : EntityBase<Guid>
    {

        public string FileName { get; set; }

        public string Path { get; set; }

        public string Type { get; set; }

        public int Size { get; set; }

        public Guid NoteId { get; set; }

        public string Md5 { get; set; }

        public virtual Note Note { get; set; }
    }
}
