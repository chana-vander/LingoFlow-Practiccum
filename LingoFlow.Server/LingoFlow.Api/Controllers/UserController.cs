using LingoFlow.Core.Models;
using LingoFlow.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LingoFlow.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;
        //private readonly IMapper _mapper;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        // GET: api/<UserController>
        [HttpGet]
        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            return await _userService.GetAllUsersAsync();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);

            if (user == null)
            {
                return NotFound($"User with ID {id} not found.");
            }

            return Ok(user);
        }

        // POST api/<UserController>
        // הוספת משתמש
        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("משתמש לא נמצא"); // בדיקה אם המשתמש null
            }

            // הוספת המשתמש על ידי קריאה לשירות
            var addedUser = await _userService.AddUserAsync(user);

            // החזרת תגובה עם קוד 201 (Created)
            return CreatedAtAction(nameof(AddUser), new { id = addedUser.Id }, addedUser);
        }
        //public async Task<ActionResult> Post(DoctorPostModel d)
        //{
        //    var dToPost = new Doctor { Doctor_name = d.Doctor_name, occupation = d.occupation, phone = d.phone };
        //    Doctor doctor = await _doctorsService.AddAsync(dToPost);
        //    return Ok(doctor);
        //    //_doctorsService.SaveChanges();
        //}
        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
