using CQ.Note.Core.Dto;
using System;
using System.Collections.Generic;

namespace CQ.Note.Core.Services
{
    public interface INoteService : IService<Models.Note, Guid>
    {
        void Save(IEnumerable<NoteInputDto> notes);
    }
}
