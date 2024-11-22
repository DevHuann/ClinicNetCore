using ClinicNetCore.Data;
using ClinicNetCore.Models;
using ClinicNetCore.Models.RequestModels.TreatmentType;
using ClinicNetCore.Models.ResponseModels.TreatmentType;

namespace ClinicNetCore.Services.Impl;

public class TreatmentTypeService : ITreatmentTypeService
{

    private readonly ApplicationDbContext _context;
    
    public TreatmentTypeService(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<TreatmentType> ListTreatmentTypeByDoctorId(Guid id)
    {
        var treatmentTypes = _context.TreatmentTypes.Where(t => t.DoctorId == id).ToList();
        if (treatmentTypes == null)
        {
            throw new Exception("TreatmentType not found!");
        }

        return treatmentTypes;
    }

    public CreateTreatmentTypeResponse CreateTreatmentType(CreateTreatmentTypeRequest request)
    {
        var doctor = _context.Doctors.FirstOrDefault(d => d.Id == request.DoctorId);
        if (doctor == null)
        {
            throw new Exception("Doctor not found!");
        }

        var newTreatmentType = new TreatmentType
        {
            TreatmentName = request.TreatmentName,
            DoctorId = request.DoctorId,
        };
        _context.TreatmentTypes.Add(newTreatmentType);
        _context.SaveChanges();
        return new CreateTreatmentTypeResponse
        {
            TreatmentName = newTreatmentType.TreatmentName,
            DoctorId = newTreatmentType.DoctorId
        };
    }

    public EditTreatmentTypeResponse EditTreatmentType(EditTreatmentTypeRequest request)
    {
        var editTreatmentType = _context.TreatmentTypes.FirstOrDefault(t => t.Id == request.Id);
        if (editTreatmentType == null)
        {
            throw new Exception("TreatmentType not found!");
        }

        var doctor = _context.Doctors.FirstOrDefault(d => d.Id == request.DoctorId);
        if (doctor == null)
        {
            throw new Exception("DoctorId not found!");

        }

        editTreatmentType.TreatmentName = request.TreatmentName;
        editTreatmentType.DoctorId = request.DoctorId;
        _context.SaveChanges();
        return new EditTreatmentTypeResponse
        {
            TreatmentName = editTreatmentType.TreatmentName,
            DoctorId = editTreatmentType.DoctorId,
        };
    }

    public bool DeleteTreatmentType(Guid id)
    {
        var delTreatmentType = _context.TreatmentTypes.FirstOrDefault(t => t.Id == id);
        if (delTreatmentType == null)
        {
            throw new Exception("TreatmentType not found!");
        }

        _context.Remove(delTreatmentType);
        _context.SaveChanges();
        return true;
    }
}