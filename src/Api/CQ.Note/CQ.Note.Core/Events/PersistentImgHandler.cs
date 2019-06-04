using CQ.Note.Core.Config;
using CQ.Note.Core.Providers;

namespace CQ.Note.Core.Events
{
    public class PersistentImgHandler : IEventHandler<PersistentImg>
    {
        private readonly IFileProvider _fileProvider;

        public PersistentImgHandler(IFileProvider fileProvider)
        {
            _fileProvider = fileProvider;
        }


        public void Handler(PersistentImg @event)
        {
            FileInfo fileInfo = _fileProvider.Save(@event.FileName, @event.Bytes, FilePathGenerateType.Date);
            @event.Path = fileInfo.FilePath;
            @event.FileName = fileInfo.FileName;
        }
    }
}
