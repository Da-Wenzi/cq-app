using CQ.Note.Core.Config;
using System;
using System.IO;

namespace CQ.Note.Core.Providers.Impl
{
    public class DateFilePathProvider : FilePathProvider
    {

        private readonly IDateTimeProvider _dateTimeProvider;

        public DateFilePathProvider(AppSetting appSetting, IDateTimeProvider dateTimeProvider)
            : base(appSetting)
        {
            _dateTimeProvider = dateTimeProvider;
        }

        public override FilePathGenerateType Type => FilePathGenerateType.Date;

        protected override string BuildSrc()
        {
            DateTime date = _dateTimeProvider.Now;
            return Path.Combine(AppSetting.UploadFilePath, date.Year.ToString(), date.Month.ToString(), date.Day.ToString());
        }
    }
}
