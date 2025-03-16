using LingoFlow.Core.Models;
using LingoFlow.Core.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LingoFlow.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _subjectService;
        //private readonly IMapper _mapper;
        public SubjectController(ISubjectService subjectService)
        {
            _subjectService= subjectService;
        }
        // GET: api/<UserController>
        [HttpGet]
        public async Task<IEnumerable<Subject>> Get()
        {
            return await _subjectService.GetAllSubjectsAsync();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Feedback>> Get(int id)
        {
            var subject = await _subjectService.GetSubjectByIdAsync(id);

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
