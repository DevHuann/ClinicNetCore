namespace ClinicNetCore.Models.ResponseModels.Patient;

public class PatientResponse
{
    public List<ListPatientResponse> ListPatient { get; set; }
    public int TotalPage { get; set; }
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    public int TotalRecords { get; set; }
}