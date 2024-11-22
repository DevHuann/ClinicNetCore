namespace ClinicNetCore.Models.ResponseModels.Doctor;

public class DoctorResponse
{
    public List<ListDoctorResponse> ListDoctor { get; set; }
    public int TotalPage { get; set; }
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    public int TotalRecords { get; set; }
}