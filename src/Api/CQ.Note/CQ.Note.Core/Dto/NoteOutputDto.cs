using System;

namespace CQ.Note.Core.Dto
{
    public class NoteOutputDto
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        public string RenderContent { get; set; }
    }
}
