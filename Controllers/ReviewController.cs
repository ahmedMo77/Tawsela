using Microsoft.AspNetCore.Mvc;
using Tawsela.Entities;
using Tawsela.Services.Interfaces;

namespace Tawsela.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var reviews = await _reviewService.GetAllReviewsAsync();
            return Ok(reviews);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var review = await _reviewService.GetReviewByIdAsync(id);
            if (review == null)
                return NotFound();
            return Ok(review);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Review review)
        {
            await _reviewService.CreateReviewAsync(review);
            return CreatedAtAction(nameof(GetById), new { id = review.Id }, review);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Review review)
        {
            if (id != review.Id)
                return BadRequest("Mismatched review ID.");

            await _reviewService.UpdateReviewAsync(review);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _reviewService.DeleteReviewAsync(id);
            return NoContent();
        }
    }

}
