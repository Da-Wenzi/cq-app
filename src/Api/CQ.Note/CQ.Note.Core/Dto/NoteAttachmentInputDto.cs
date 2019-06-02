using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CQ.Note.Core.Dto
{
    public class NoteAttachmentInputDto
    {
        public string FileName { get; set; }

        public string Base64 { get; set; }

        public string Type { get; set; }

        public int Size { get; set; }

    }
}