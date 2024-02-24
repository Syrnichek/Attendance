using AttendanceService.Application.Commands;
using AttendanceService.Core.Entities;
using AttendanceService.Core.Entities.Enums;
using AttendanceService.Core.Repositories;
using JwtParserService.Core.Entities;
using MediatR;

namespace AttendanceService.Application.Handlers;

public class AddUserCommandHandler : IRequestHandler<AddUserCommand>
{
    private readonly IStudentRepository _studentRepository;

    private readonly ITeacherRepository _teacherRepository;

    public AddUserCommandHandler(ITeacherRepository teacherRepository, IStudentRepository studentRepository)
    {
        _teacherRepository = teacherRepository;
        _studentRepository = studentRepository;
    }

    public async Task Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        if (request.UserRole == UserRole.Student)
        {
            await _studentRepository.AddStudent(new Student
            {
                UserName = request.UserName,
                UserRole = UserRoleEnum.Student,
                StudentFlagEnum = StudentFlagEnum.Absented,
                UserNote = request.UserNote
            });
        }
        else if (request.UserRole == UserRole.Teacher)
        {
            await _teacherRepository.AddTeacher(new Teacher
            {
                UserName = request.UserName,
                UserRole = UserRoleEnum.Teacher,
                TeacherGradeEnum = TeacherGradeEnum.Teacher,
                UserNote = request.UserNote
            });
        }
    }
}