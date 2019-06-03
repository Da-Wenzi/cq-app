using Microsoft.Extensions.FileProviders;
using System.IO;

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
            //using (FileStream memory = new FileStream())
            //{
                
            //}
        }
    }
}
