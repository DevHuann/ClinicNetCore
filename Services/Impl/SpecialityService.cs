using ClinicNetCore.Data;
using ClinicNetCore.Models;
using ClinicNetCore.Models.RequestModels.Speciality;
using ClinicNetCore.Models.ResponseModels.Speciality;

namespace ClinicNetCore.Services.Impl;

public class SpecialityService :ISpecialityService
{
    private readonly ApplicationDbContext _context;

    public SpecialityService(ApplicationDbContext dbContext)
    {
        _context = dbContext;
    }
    
    public CreateSpecialityResponse CreateSpeciality(CreateSpecialityRequest request)
    {
        var speciality = new Speciality
        {
            SpecialityName = request.SpecialityName,
            SpecialityIcon = request.SpecialityIcon
        };
        _context.Specialities.Add(speciality);
        _context.SaveChanges();
        return new CreateSpecialityResponse
        {
            Id = speciality.Id,
            SpecialityName = speciality.SpecialityName,
            SpecialityIcon = speciality.SpecialityIcon
        };
    }

    public EditSpecialityResponse EditSpeciality(EditSpecialityRequest request)
    {
        var editSpeciality = _context.Specialities.FirstOrDefault(speciality => speciality.Id == request.Id);
        if (editSpeciality == null)
        {
            throw new Exception("speciality not exit!");
        }

        editSpeciality.SpecialityName = request.SpecialityName;
        editSpeciality.SpecialityIcon = request.SpecialityIcon;
        _context.SaveChanges();
        return new EditSpecialityResponse
        {   
            Id = editSpeciality.Id,
            SpecialityName = editSpeciality.SpecialityName,
            SpecialityIcon = editSpeciality.SpecialityIcon
        };
    }
    public List<Speciality> GetListSpeciality()
    {
        var speciality = _context.Specialities.Select(speciality => new Speciality
        {
            Id = speciality.Id,
            SpecialityName = speciality.SpecialityName,
            SpecialityIcon = speciality.SpecialityIcon
        }).ToList();
        return speciality;
    }
    public bool DeleteSpeciality(Guid id)
    {
        var deleteSpeciality = _context.Specialities.FirstOrDefault(speciality => speciality.Id == id);
        if (deleteSpeciality == null)
        {
            throw new Exception("speciality not exit!");
        }

        _context.Specialities.Remove(deleteSpeciality);
        _context.SaveChanges();
        return true;
    }
}