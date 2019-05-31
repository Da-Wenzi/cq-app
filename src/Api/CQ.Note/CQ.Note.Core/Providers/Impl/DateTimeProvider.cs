using System;

namespace CQ.Note.Core.Providers.Impl
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime Now => DateTime.Now;
    }
}
