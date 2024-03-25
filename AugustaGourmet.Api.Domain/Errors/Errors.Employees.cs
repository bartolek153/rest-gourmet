using ErrorOr;

namespace AugustaGourmet.Api.Domain.Errors;

public static partial class Errors
{
    public static class EmployeesIncidents
    {
        public static class Conflicts
        {
            public static Error OverlappingSchedules => Error.Conflict(
                code: "EmployeeIncident.OverlappingSchedules",
                description: "Já existe um registro de ocorrência para este funcionário no período informado.");
        }
    }
}