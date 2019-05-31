using System;

namespace CQ.Note.Core.Models
{
    public abstract class EntityBase<TKey>
        where TKey : IEquatable<TKey>
    {
        public TKey Id { get; set; }
    }
}
