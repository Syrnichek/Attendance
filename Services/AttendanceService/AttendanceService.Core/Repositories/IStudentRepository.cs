using AttendanceService.Core.Entities;

namespace AttendanceService.Core.Repositories;

public interface IStudentRepository
{
    public Task<List<Student>> GetAllStudents();

    public Task<Student> GetStudentById(int id);

    public Task SaveStudent();

    public Task AddStudent(Student student);
}