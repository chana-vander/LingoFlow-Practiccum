﻿using AutoMapper;
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
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService _feedbackService;
        private readonly IMapper _mapper;
        public FeedbackController(IFeedbackService feedbackService,IMapper mapper)
        {
            _feedbackService = feedbackService;
            _mapper = mapper;
        }
        // GET: api/<UserController>
        [HttpGet]
        public async Task<IEnumerable<FeedbackDto>> Get()
        {
            var feedbackDto = await _feedbackService.GetAllFeedbacksAsync();
            var feedbacks = new List<FeedbackDto>();
            foreach (var feedback in feedbackDto)
            {
                feedbacks.Add(_mapper.Map<FeedbackDto>(feedback));
            }
            return feedbacks;
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Feedback>> Get(int id)
        {
            var feedback = await _feedbackService.GetFeedbackByIdAsync(id);

            if (feedback == null)
            {
                return NotFound($"Feedback with ID {id} not found.");
            }

            return Ok(feedback);
        }

        // POST api/<FeedbackController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<FeedbackController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FeedbackController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
