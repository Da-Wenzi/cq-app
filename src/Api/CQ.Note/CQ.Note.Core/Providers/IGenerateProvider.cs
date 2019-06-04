using System;

namespace CQ.Note.Core.Providers
{
    public interface IGenerateProvider
    {
        Guid Generate { get; }
    }
}
