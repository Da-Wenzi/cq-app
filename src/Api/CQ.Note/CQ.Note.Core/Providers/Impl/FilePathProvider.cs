using CQ.Note.Core.Config;

namespace CQ.Note.Core.Providers.Impl
{
    public abstract class FilePathProvider : IFilePathProvider
    {
        protected readonly AppSetting AppSetting;


        public FilePathProvider(AppSetting appSetting)
        {
            AppSetting = appSetting;
        }


        public string Src => BuildSrc();

        public abstract FilePathGenerateType Type { get; }

        protected abstract string BuildSrc();
    }

}
