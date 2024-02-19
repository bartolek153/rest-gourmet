using ErrorOr;

namespace AugustaGourmet.Api.Domain.Errors;

public static partial class Errors
{
    public static class EmployeeAttendance
    {
        public static Error InvalidDateRange => Error.Failure(
            code: "EmployeeAttendance.InvalidDateRange",
            description: "From and To dates are required.");
    }
}