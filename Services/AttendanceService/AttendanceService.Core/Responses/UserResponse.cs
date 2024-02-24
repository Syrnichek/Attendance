using JwtParserService.Core.Entities;

namespace AttendanceService.Core.Responses;

public class UserResponse
{
    public int Id { get; set; }

    public string? UserName { get; set; }

    public UserRole UserRole { get; set; }
}