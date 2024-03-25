using AugustaGourmet.Api.Application.DTOs.Employees;
using AugustaGourmet.Api.Application.Features.EmployeesIncidents.CreateEmployeeIncident;
using AugustaGourmet.Api.Domain.Entities.Employees;

using AutoMapper;

namespace AugustaGourmet.Api.Application.Profiles;

public class EmployeeProfiles : Profile
{
    public EmployeeProfiles()
    {
        CreateMap<Employee, EmployeeDto>();

        CreateMap<EmployeeIncidentLog, EmployeeIncidentLogDto>()
            .ForMember(dest => dest.EmployeeName, opt => opt.MapFrom(src => src.Employee!.Name))
            .ForMember(dest => dest.Reason, opt => opt.MapFrom(src => src.Reason.Description));
        CreateMap<CreateEmployeeIncidentCommand, EmployeeIncidentLog>();
    }
}