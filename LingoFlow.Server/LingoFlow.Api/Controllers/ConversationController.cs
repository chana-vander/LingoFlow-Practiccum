using LingoFlow.Core.Models;
using LingoFlow.Core.Services;
using LingoFlow.Service;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LingoFlow.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConversationController : ControllerBase
    {
        private readonly IConversationService _conversationService;
        //private readonly IMapper _mapper;
        public ConversationController(IConversationService conversationService)
        {
            _conversationService = conversationService;
        }
        // GET: api/<UserController>
        [HttpGet]
        public async Task<IEnumerable<Conversation>> Get()
        {
            return await _conversationService.GetAllConversationsAsync();
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
        public async Task<ActionResult> Post(Conversation conversation)
        {
            if (conversation == null)
            {
                return BadRequest("שיחה לא נמצאת"); // בדיקה אם המשתמש null
            }

            // הוספת המשתמש על ידי קריאה לשירות
            var addedUser = await _conversationService.AddConversationAsync(conversation);

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
