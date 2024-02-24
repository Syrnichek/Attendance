using System.Text;
using AttendanceService.Application.Clients;
using AttendanceService.Application.Commands;
using AttendanceService.Application.Handlers;
using AttendanceService.Core.Data;
using AttendanceService.Core.Repositories;
using AttendanceService.Infrastructure.Data;
using AttendanceService.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

var connection = builder.Configuration.GetConnectionString("DatabaseSettings:DefaultConnection");

builder.Services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(connection));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(
    typeof(AddLessonComandHandler).Assembly,
    typeof(AddLessonCommand).Assembly,
    typeof(StudentAttendCommand).Assembly,
    typeof(StudentAttendCommandHandler).Assembly
));

builder.Services.AddHttpClient<IJwtParserClient, JwtParserClient>();
builder.Services.AddHttpClient<ILessonGeneratorClient, LessonGeneratorClient>();

builder.Services.AddScoped<ILessonRepository, LessonRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = "https://localhost:7145";
    });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();