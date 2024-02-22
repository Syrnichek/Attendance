using AttendanceService.Core.Entities;

namespace AttendanceService.Core.Repositories;

public interface ILessonRepository
{
    public Task<Lesson> GetLessonByGuid(Guid lessonId);

    public Task AddLesson(Lesson lesson);
}