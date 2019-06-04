using AutoMapper;
using CQ.Note.Core.Dto;
using CQ.Note.Core.Events;
using CQ.Note.Core.Models;
using CQ.Note.Core.Providers;
using CQ.Note.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CQ.Note.Core.Services.Impl
{
    public class NoteService : Service<Models.Note, Guid>, INoteService, IDisposable
    {
        private readonly ILogger<NoteService> _logger;
        private readonly IEventHandler<PersistentImg> _eventHandler;
        private readonly IGenerateProvider _generateProvider;
        private readonly EventBus _eventBus;

        public NoteService(ILoggerFactory loggerFactory,
            IUnitOfWork unitOfWork,
            IRepository<Models.Note, Guid> repository,
            IMapper mapper,
            EventBus eventBus,
            IEventHandler<PersistentImg> eventHandler,
            IGenerateProvider generateProvider)
            : base(unitOfWork, repository, mapper)
        {

            _eventBus = eventBus;
            _eventHandler = eventHandler;
            _logger = loggerFactory.CreateLogger<NoteService>();
            _generateProvider = generateProvider;

            eventBus.Subscribe(_eventHandler);
        }


        public void Dispose()
        {
            _eventBus.UnSubscribe(_eventHandler);
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
                    Repository.Update(entity);
                }
                else
                {
                    entity = Mapper.Map<Models.Note>(note);
                    Repository.Insert(entity);
                }

                if (note.NoteAttachments.Any())
                {

                    if (entity.NoteAttachments == null)
                    {
                        entity.NoteAttachments = new List<NoteAttachment>();
                    }


                    note.NoteAttachments.ForEach(n =>
                    {

                        if (!entity.NoteAttachments.Any(m => m.Md5 == n.Md5))
                        {
                            _eventBus.Publish(new PersistentImg
                            {
                                Base64 = n.Base64,
                                FileName = n.Name
                            }, (@event, success, ex) =>
                            {
                                if (success)
                                {
                                    entity.NoteAttachments.Add(new NoteAttachment
                                    {
                                        FileName = n.Name,
                                        Id = _generateProvider.Generate,
                                        NoteId = entity.Id,
                                        Path = @event.Path,
                                        Size = n.Size,
                                        Type = n.Type,
                                        Md5 = @event.Md5
                                    });
                                    Repository.Update(entity);
                                }
                                else
                                {
                                    _logger.LogError(ex, JsonConvert.SerializeObject(@event));
                                }
                            });
                        }
                    });
                }

            }

            UnitOfWork.Commit();
        }
    }
}
