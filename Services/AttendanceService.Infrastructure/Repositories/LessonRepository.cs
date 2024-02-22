using AttendanceService.Core.Entities;
using AttendanceService.Core.Repositories;
using AttendanceService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AttendanceService.Infrastructure.Repositories;

public class LessonRepository : ILessonRepository
{
    private readonly ApplicationContext _applicationContext;

    public LessonRepository(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }

    public async Task<Lesson> GetLessonByGuid(Guid lessonId)
    {
        return await _applicationContext.Lessons.SingleOrDefaultAsync(l => l.LessonId == lessonId) ?? throw new InvalidOperationException();
    }

    public async Task AddLesson(Lesson lesson)
    {
        _applicationContext.Lessons.Add(lesson);
        await _applicationContext.SaveChangesAsync();
    }
}