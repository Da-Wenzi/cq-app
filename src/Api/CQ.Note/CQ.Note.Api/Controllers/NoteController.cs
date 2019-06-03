using AutoMapper;
using CQ.Note.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace CQ.Note.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly INoteService _noteService;
        private readonly ILoggerFactory _loggerFactory;


        public NoteController(IMapper mapper, INoteService noteService, ILoggerFactory loggerFactory)
        {
            _mapper = mapper;
            _noteService = noteService;
            loggerFactory.CreateLogger<NoteController>().LogError("11111111111111111111111111111111");
        }



        // GET api/note
        [HttpGet]
        public ActionResult<IEnumerable<Core.Dto.NoteOutputDto>> Get()
        {
            return _mapper.Map<List<Core.Dto.NoteOutputDto>>(_noteService.GetAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post(List<Core.Dto.NoteInputDto> notes)
        {
            if (ModelState.IsValid)
            {
                _noteService.Save(notes);
            }
        }



        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] string value)
        {

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
