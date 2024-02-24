using AttendanceService.Core.Entities;
using AttendanceService.Core.Repositories;
using AttendanceService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AttendanceService.Infrastructure.Repositories;

public class TeacherRepository : ITeacherRepository
{
    private readonly ApplicationContext _applicationContext;

    public TeacherRepository(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }

    public async Task<List<Teacher>> GetAllTeachers()
    {
        return await _applicationContext.Teachers.ToListAsync();
    }

    public async Task<Teacher> GetTeacherById(int id)
    {
        return await _applicationContext.Teachers.SingleOrDefaultAsync(t => t.Id == id) ?? throw new InvalidOperationException();
    }

    public async Task AddTeacher(Teacher teacher)
    {
        _applicationContext.Teachers.Add(teacher);
        await _applicationContext.SaveChangesAsync();
    }
}