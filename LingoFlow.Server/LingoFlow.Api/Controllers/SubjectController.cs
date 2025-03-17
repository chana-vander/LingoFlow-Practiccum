using AutoMapper;
using LingoFlow.Core.Dto;
using LingoFlow.Core.Models;
using LingoFlow.Core.Services;
using LingoFlow.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LingoFlow.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _subjectService;
        private readonly IMapper _mapper;
        public SubjectController(ISubjectService subjectService,IMapper mapper)
        {
            _subjectService= subjectService;
            _mapper= mapper;
        }
        // GET: api/<UserController>
        [HttpGet]
        public async Task<IEnumerable<SubjectDto>> Get()
        {
            var subjectDto = await _subjectService.GetAllSubjectsAsync();
            var subjects = new List<SubjectDto>();
            foreach (var subject in subjects)
            {
                subjects.Add(_mapper.Map<SubjectDto>(subject));
            }
            return subjects;
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Feedback>> Get(int id)
        {
            var subject = await _subjectService.GetSubjectByIdAsync(id);
            //var wordDto = Mapping.
            if (subject == null)
            {
                return NotFound($"Subject with ID {id} not found.");
            }

            return Ok(subject);
        }


        // POST api/<SubjectController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SubjectController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SubjectController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
