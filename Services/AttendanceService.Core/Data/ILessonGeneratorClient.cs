using AttendanceService.Core.Entities;

namespace AttendanceService.Core.Data;

public interface ILessonGeneratorClient
{
    public Task<Lesson> GenerateLessonAsync(AddLessonResponse data);
}