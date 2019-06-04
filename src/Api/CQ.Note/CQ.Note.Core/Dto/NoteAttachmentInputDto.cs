namespace CQ.Note.Core.Dto
{
    public class NoteAttachmentInputDto
    {
        public string Name { get; set; }

        public string Base64 { get; set; }

        public string Type { get; set; }

        public int Size { get; set; }

        public string Md5 { get; set; }

    }
}