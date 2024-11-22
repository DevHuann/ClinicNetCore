using ClinicNetCore.Models;
using ClinicNetCore.Models.RequestModels.Review;
using ClinicNetCore.Models.ResponseModels.Review;

namespace ClinicNetCore.Services;

public interface IReviewService
{
    Task<CreateReviewResponse> CreateReview(CreateReviewRequest request);
    List<Review> GetListReviewByDoctorId(Guid id);
}