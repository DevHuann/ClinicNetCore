using ClinicNetCore.Data;
using ClinicNetCore.Models;
using ClinicNetCore.Models.RequestModels.Review;
using ClinicNetCore.Models.ResponseModels.Review;
using Microsoft.EntityFrameworkCore;

namespace ClinicNetCore.Services.Impl;

public class ReviewService :IReviewService
{
    private readonly ApplicationDbContext _context;

    public ReviewService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<CreateReviewResponse> CreateReview(CreateReviewRequest request)
    {
        var appointment = await _context.Appointments.FindAsync(request.AppointmentId);
        if (appointment == null)
        {
            throw new Exception("Appointment not found.");
        }

        if (appointment.IsReviewed == true)
        {
            throw new Exception("Reviewed!!");
        }
        
        var review = new Review
        {
            AppointmentId = appointment.Id,
            Rating = request.Rating,
            ReviewText = request.ReviewText,
            Date = DateTime.UtcNow, 
            DoctorId = appointment.DoctorId,
            PatientId = appointment.PatientId
        };

        _context.Reviews.Add(review);
        await _context.SaveChangesAsync();

        appointment.IsReviewed = true;
        await _context.SaveChangesAsync();

        return new CreateReviewResponse
        {
            Id = review.Id,
            Rating = review.Rating,
            ReviewText = review.ReviewText,
            Date = review.Date,
            DoctorId = review.DoctorId,
            PatientId = review.PatientId,
            Appointment = review.Appointment
        };
    }

    public List<Review> GetListReviewByDoctorId(Guid id)
    {
        var reviews = _context.Reviews
            .Include(a=>a.Patient)
            .OrderByDescending(a => a.Date)
            .Where(r => r.DoctorId == id).ToList();
        return reviews;
    }
}