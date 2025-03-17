using AutoMapper;
using LingoFlow.Core;
using LingoFlow.Core.Dto;
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
        private readonly IMapper _mapper;
        public WordController(IWordService wordService,IMapper mapper)
        {
           _wordService = wordService;
            _mapper = mapper;
        }
        // GET: api/<UserController>
        [HttpGet]
        public async Task<IEnumerable<WordDto>> Get()
        {
            var wordsDto=await _wordService.GetAllWordsAsync();
            var words=new List<WordDto>();
            foreach (var word in wordsDto) { 
                words.Add(_mapper.Map<WordDto>(word));
            }
            return words;
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Word>> Get(int id)
        {
            var word = await _wordService.GetWordByIdAsync(id);
            var wordDto=Mapping.MapToWordDto(word);
            if (wordDto == null)
            {
                return NotFound($"Word with ID {id} not found.");
            }

            return Ok(wordDto);
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
