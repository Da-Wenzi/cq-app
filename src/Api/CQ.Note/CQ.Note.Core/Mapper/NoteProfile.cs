﻿using AutoMapper;
using CQ.Note.Core.Dto;
using CQ.Note.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CQ.Note.Core.Mapper
{
    public class NoteProfile : Profile
    {
        public NoteProfile()
        {
            CreateMap<Core.Models.Note, Core.Dto.NoteOutputDto>()
                .ForMember(m => m.Content, options =>
                {
                    options.MapFrom(n =>
                        string.Join(string.Empty, n.NoteContents.Select(s => s.Content).ToList())
                    );
                });
            CreateMap<Core.Dto.NoteInputDto, Core.Models.Note>()
                .ForMember(m => m.NoteContents, options => options.MapFrom<NoteContentResolver>());
        }
    }


    public class NoteContentResolver : IValueResolver<Core.Dto.NoteInputDto, Core.Models.Note, IEnumerable<NoteContent>>
    {
        public IEnumerable<NoteContent> Resolve(NoteInputDto source, Models.Note destination, IEnumerable<NoteContent> destMember, ResolutionContext context)
        {
            if (source.Content == null)
            {
                return new List<NoteContent>();
            }

            return Regex.Split(source.Content, @"(?<=\G.{8000})", RegexOptions.Singleline).Select(s => new NoteContent
            {
                Id = Guid.NewGuid(),
                Content = s
            });
        }
    }
}
