using AugustaGourmet.Api.Application.DTOs.Holidays;
using AugustaGourmet.Api.Application.Features.Holidays.CreateHoliday;
using AugustaGourmet.Api.Application.Features.Holidays.UpdateHoliday;
using AugustaGourmet.Api.Domain.Entities.General;

using AutoMapper;

namespace AugustaGourmet.Api.Application.Profiles;

public class GeneralProfiles : Profile
{
    public GeneralProfiles()
    {
        CreateMap<Holiday, HolidayDto>();
        CreateMap<CreateHolidayCommand, Holiday>();
        CreateMap<UpdateHolidayCommand, Holiday>();
    }
}