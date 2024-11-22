namespace ClinicNetCore.Models.RequestModels.Review;

public class CreateReviewRequest
{
    public Guid AppointmentId { get; set; }
    public int Rating { get; set; }
    public string ReviewText { get; set; }
    
}