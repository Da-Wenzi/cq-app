using System;

namespace CQ.Note.Core.Providers
{
    public interface IDateTimeProvider
    {
        DateTime Now { get; }
    }
}
