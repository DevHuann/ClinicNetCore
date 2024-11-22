using ClinicNetCore.Models.RequestModels.Review;
using ClinicNetCore.Models.ResponseModels.Review;
using ClinicNetCore.Services;
using ClinicNetCore.Services.Impl;
using Microsoft.AspNetCore.Mvc;

namespace ClinicNetCore.Controllers;
[ApiController]
[Route("[controller]")]
public class ReviewController:ControllerBase
{
    private readonly IReviewService _reviewService;
    public ReviewController(IReviewService reviewService)
    {
        _reviewService = reviewService;
    }

    [HttpPost("create-review")]
    public async Task<ActionResult<CreateReviewResponse>> CreateReview([FromBody] CreateReviewRequest request)
    {
        return Ok(await _reviewService.CreateReview(request));
    }

    [HttpGet("list-review-by-doctor-id/{id}")]
    public IActionResult GetListReviewByDoctorId(Guid id)
    {
        return Ok(_reviewService.GetListReviewByDoctorId(id));
    }
}