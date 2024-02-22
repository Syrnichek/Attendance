using AttendanceService.Core.Entities;
using AttendanceService.Core.Repositories;
using AttendanceService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AttendanceService.Infrastructure.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly ApplicationContext _applicationContext;

    public StudentRepository(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }

    public async Task<List<Student>> GetAllStudents()
    {
        return await _applicationContext.Students.ToListAsync();
    }

    public async Task<Student> GetStudentById(int id)
    {
        return await _applicationContext.Students.SingleOrDefaultAsync(s => s.Id == id) ?? throw new InvalidOperationException();
    }

    public async Task UpdateStudentFlagAttended(int id)
    {
        var student = await _applicationContext.Students.FindAsync(id);
        
        if (student != null)
        {
            student.StudentFlagEnum = StudentFlagEnum.Attended;
        }
    }
}