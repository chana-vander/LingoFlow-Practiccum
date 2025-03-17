using AutoMapper;
using LingoFlow.Api.Models;
using LingoFlow.Core.Dto;
using LingoFlow.Core.Models;
using LingoFlow.Core.Services;
using LingoFlow.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Numerics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LingoFlow.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConversationController : ControllerBase
    {
        private readonly IConversationService _conversationService;
        private readonly IMapper _mapper;
        public ConversationController(IConversationService conversationService,IMapper mapper)
        {
            _conversationService = conversationService;
            _mapper = mapper;
        }
        // GET: api/<UserController>
        [HttpGet]
        public async Task<IEnumerable<ConversationDto>> Get()
        {
            var conversationDto = await _conversationService.GetAllConversationsAsync();
            var conversations = new List<ConversationDto>();
            foreach (var conversation in conversationDto)
            {
                conversations.Add(_mapper.Map<ConversationDto>(conversation));
            }
            return conversations;
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            var conversation = await _conversationService.GetConversationByIdAsync(id);

            if (conversation == null)
            {
                return NotFound($"Conversation with ID {id} not found.");
            }

            return Ok(conversation);
        }

        // POST api/<ConversationController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ConversationPostModel conversation)
        {
            if (conversation == null)
            {
                return BadRequest("שיחה ריקה:("); // בדיקה אם המשתמש null
            }
            var conversationToPost = new Conversation();

            // הוספת שיחה על ידי קריאה לשירות
            var addedUser = await _conversationService.AddConversationAsync(conversationToPost);

            // החזרת תגובה עם קוד 201 (Created)
            //return CreatedAtAction(nameof(AddConversation), new { id = add.Id }, addedUser);
            return Ok(addedUser);
        }

        // PUT api/<ConversationController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ConversationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
