using AttendanceService.Core.Entities;

namespace AttendanceService.Core.Data;

public interface IJwtParserClient
{
    public Task<UserBase> ParseJwtAsync(string data);
}