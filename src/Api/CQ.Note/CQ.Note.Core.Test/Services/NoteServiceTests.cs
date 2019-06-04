using AutoMapper;
using CQ.Note.Core.Config;
using CQ.Note.Core.Dto;
using CQ.Note.Core.Events;
using CQ.Note.Core.Profiles;
using CQ.Note.Core.Providers;
using CQ.Note.Core.Providers.Impl;
using CQ.Note.Core.Repositories;
using CQ.Note.Core.Repositories.Impl;
using CQ.Note.Core.Services.Impl;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using Xunit;

namespace CQ.Note.Core.Test.Services
{
    public class NoteServiceTests
    {
        [Fact]
        public void Save()
        {
            NoteService noteService = GetNoteService();


            NoteAttachmentInputDto attachmentInputDto = new NoteAttachmentInputDto
            {
                Name = "微信截图_20190523161714.png",
                Base64 = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAACIAAAAzCAYAAADyzdr8AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAJ1SURBVFhH7Ze/q7lRHMeVQUlkYMBCipQyKIQ/QDarlLvYlCx+DCb+AmxWpS6LhUFMZsq9k7Koa0DJIAuf732O87jOg+eer4fL8LzrXcf5nPPu1TnH85xHAgK13+9x63qbRiIIVyIIVyIIVyIIV68DwkwQ4t1u92ubxk9fkXa7DY1Ggw5kuVxCMplEzmQyuPcgISDVahVUKhVIJBK6rRmPx4fB35ZKpZBIJI41vq3pdrvgcrmOLpVKxzrjSCRyzKVakWAw+DPh24FAAFeur8J8PifmME6lUrh6UKFQALfbfajjPl5NJhMi8F4gjNbrNWSzWTqQUChEBN4ThBUVyGg0IgKfBvLIrWFFBRKNRonAp4H0+30i8BTE7/dDsVhEbT4Qp9OJnkfXRAVSqVSI0FtWxOfz4cplUYHodDoi9BYQJqPZbOLquf4MxOFwwHQ6xdVz/RnIy2zNXUBqtRoR+jQQ5s5wGur1emE2m6HaNRDuX/4uIPF4nAhlnM/nUe0SSKfTAa1WS4y/Cwhxb8C22+3w+fl5BtLr9cBoNJ6Nf8hhZa3RaECv14PBYEBm2mq1+uLYh4L8jy0WCwwGA5x4rptAbDYblMtlMJvNRD/rcDiMroWxWIzoF/zSOwWRy+Xw8fGB+pm7rFKpBIVCgWy1WmE4HMJisUDnZbVaod+sv76+0LxLumlFaJ4jp20+bbdbaLVazwWp1+voiwDl4j5ePQqEeCwwE37zJRC2xvddw7avOZfLgUwmO+RiOF498oyk0+nXANlsNvD+/k4H4vF4wGQyHf329oYrwkFYUYHwSQThSgThSgThSgTh6m4gzAQhFvLS+/Ee/gF4yfVO3Zyc/gAAAABJRU5ErkJggg==",
                Size = 736,
                Type = "image/png",
                Md5 = "040aa74099b5570dad1b3379dbca2489"
            };

            NoteInputDto dto = new NoteInputDto
            {
                Title = "单元测试",
                NoteAttachments = new List<NoteAttachmentInputDto> { attachmentInputDto }
            };

            noteService.Save(new List<NoteInputDto> { dto });

        }




        private NoteService GetNoteService()
        {
            IRepository<Models.Note, Guid> res = GetRepository();
            ILoggerFactory loggerFactory = new LoggerFactory();
            IUnitOfWork uow = GetUnitOfWork();
            IMapper mapper = GetMapper();
            EventBus eventBus = GetEventBus();
            IEventHandler<PersistentImg> eventHandler = GetEventHandler();
            IGenerateProvider generateProvider = GetGenerateProvider();

            return new NoteService(loggerFactory, uow, res, mapper, eventBus, eventHandler, generateProvider);
        }


        private IRepository<Models.Note, Guid> GetRepository()
        {
            IUnitOfWork uow = GetUnitOfWork();
            IDateTimeProvider dateTimeProvider = GetDateTimeProvider();

            return new Repository<Models.Note, Guid>(uow, dateTimeProvider);
        }


        private IUnitOfWork GetUnitOfWork()
        {
            return new UnitOfWork(new NoteDbContext(new DbContextOptionsBuilder<NoteDbContext>().UseSqlServer("Server=47.102.222.4,1433;Database=CQ.Note;Trusted_Connection=True;User=sa;Password=wolove##1314;Integrated Security=false;").Options));
        }


        private IDateTimeProvider GetDateTimeProvider()
        {
            return new DateTimeProvider();
        }


        private IMapper GetMapper()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<NoteProfile>();
            });
            IMapper mapper = config.CreateMapper();
            return mapper;
        }

        private EventBus GetEventBus()
        {
            return new EventBus();
        }

        private IEventHandler<PersistentImg> GetEventHandler()
        {
            IFileProvider fileProvider = GetFileProvider();

            return new PersistentImgHandler(fileProvider);
        }


        private AppSetting GetAppSetting()
        {
            Microsoft.Extensions.Configuration.IConfiguration cfg = GetConfiguration();

            return new AppSetting(cfg);
        }


        private Microsoft.Extensions.Configuration.IConfiguration GetConfiguration()
        {
            return new ConfigurationBuilder().Build();
        }


        private IFilePathProvider GetFilePathProvider()
        {
            AppSetting appSetting = GetAppSetting();
            IDateTimeProvider dateTimeProvider = GetDateTimeProvider();

            return new DateFilePathProvider(appSetting, dateTimeProvider);
        }


        private IFileProvider GetFileProvider()
        {
            IGenerateProvider generateProvider = GetGenerateProvider();
            IFilePathProvider filePathProvider = GetFilePathProvider();

            return new FileProvider(generateProvider, new List<IFilePathProvider>() { filePathProvider });
        }


        private IGenerateProvider GetGenerateProvider()
        {
            return new GenerateProvider();
        }



    }
}
