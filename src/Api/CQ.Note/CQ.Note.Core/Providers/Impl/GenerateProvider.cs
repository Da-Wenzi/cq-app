using System;

namespace CQ.Note.Core.Providers.Impl
{
    public class GenerateProvider : IGenerateProvider
    {
        public Guid Generate => Guid.NewGuid();
    }
}
