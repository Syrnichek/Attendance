using AttendanceService.Core.Entities;

namespace AttendanceService.Core.Repositories;

public interface ITeacherRepository
{
    public Task<List<Teacher>> GetAllTeachers();
    
    public Task<Teacher> GetTeacherById(int id);

    public Task AddTeacher(Teacher teacher);
}