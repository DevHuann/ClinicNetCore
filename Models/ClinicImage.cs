namespace ClinicNetCore.Models;

public class ClinicImage
{
    public Guid Id { get; set; }
    public string ClinicImageFilename { get; set; }
    public Guid ClinicId { get; set; }
}
