using System;
using System.ComponentModel.DataAnnotations;

namespace CQ.Note.Core.Dto
{
    public class NoteInputDto
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string RenderContent { get; set; }

    }
}
