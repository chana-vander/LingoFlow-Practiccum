using LingoFlow.Core.Models;
using LingoFlow.Core.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LingoFlow.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordController : ControllerBase
    {
        private readonly IWordService _wordService;
        //private readonly IMapper _mapper;
        public WordController(IWordService wordService)
        {
           _wordService = wordService;
        }
        // GET: api/<UserController>
        [HttpGet]
        public async Task<IEnumerable<Word>> Get()
        {
            return await _wordService.GetAllWordsAsync();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Word>> Get(int id)
        {
            var word = await _wordService.GetWordByIdAsync(id);

            if (word == null)
            {
                return NotFound($"Word with ID {id} not found.");
            }

            return Ok(word);
        }


        // POST api/<WordController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<WordController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<WordController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
