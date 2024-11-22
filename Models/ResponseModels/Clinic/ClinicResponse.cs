namespace ClinicNetCore.Models.ResponseModels.Clinic;

public class ClinicResponse
{
    public List<ListClinicResponse> ListClinic { get; set; }
    public int TotalPage { get; set; }
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    public int TotalRecords { get; set; }
}