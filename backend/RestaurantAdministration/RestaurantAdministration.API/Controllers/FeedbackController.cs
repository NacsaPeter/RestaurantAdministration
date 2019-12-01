using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantAdministration.Application.Dtos;
using RestaurantAdministration.Application.Interfaces;

namespace RestaurantAdministration.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackAppService _service;

        public FeedbackController(IFeedbackAppService service)
        {
            _service = service;
        }

        [HttpGet("feedbacks")]
        public async Task<ActionResult<IEnumerable<FeedbackDto>>> GetAllFeedback()
        {
            return Ok(await _service.GetAllFeedbackAsync());
        }

        [HttpPost("feedback")]
        public async Task<ActionResult<FeedbackDto>> CreateFeedback([FromBody] FeedbackDto feedbackDto)
        {
            if(feedbackDto == null)
            {
                return BadRequest("Feedback data must be set!");
            }
            try
            {
                FeedbackDto created = await _service.CreateFeedbackAsync(feedbackDto);
                return Ok(created);
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }
    }
}