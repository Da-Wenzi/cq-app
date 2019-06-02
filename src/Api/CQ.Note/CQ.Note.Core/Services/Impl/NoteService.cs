using AutoMapper;
using CQ.Note.Core.Dto;
using CQ.Note.Core.Models;
using CQ.Note.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CQ.Note.Core.Services.Impl
{
    public class NoteService : Service<Models.Note, Guid>, INoteService
    {



        public NoteService(IUnitOfWork unitOfWork,
            IRepository<Models.Note, Guid> repository,
            IMapper mapper)
            : base(unitOfWork, repository, mapper)
        {

        }


        public override IEnumerable<Models.Note> GetAll()
        {
            return Repository.NoTrackingEntities.Include(i => i.NoteContents).ToList();
        }

        public void Save(IEnumerable<NoteInputDto> notes)
        {
            List<Guid> noteIds = notes.Select(n => n.Id).ToList();
            List<Models.Note> entities = Repository.Entities.Include(i => i.NoteContents)
                .Where(n => noteIds.Contains(n.Id)).ToList();
            foreach (NoteInputDto note in notes)
            {
                Models.Note entity = entities.Find(e => e.Id == note.Id);
                if (entity != null)
                {
                    entity.NoteContents = new List<NoteContent>();
                    entity = Mapper.Map(note, entity);

                    if (note.NoteAttachments.Any())
                    {
                        if (entity.NoteAttachments == null)
                        {
                            entity.NoteAttachments = new List<NoteAttachment>();
                        }

                        Mapper.Map<List<NoteAttachment>>(note.NoteAttachments)
                            .ForEach(n => entity.NoteAttachments.Add(n));
                    }



                    Repository.Update(entity);
                }
                else
                {
                    Repository.Insert(Mapper.Map<Models.Note>(note));
                }
            }
            UnitOfWork.Commit();
        }
    }
}
