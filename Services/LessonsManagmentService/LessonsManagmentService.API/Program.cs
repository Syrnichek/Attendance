using LessonsManagmentService.Application.Clients;
using LessonsManagmentService.Application.Commands;
using LessonsManagmentService.Application.Handlers;
using LessonsManagmentService.Core.Data;
using Microsoft.AspNetCore.Authentication.Negotiate;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(
    typeof(GenerateLessonCommandHandler).Assembly,
    typeof(GenerateLessonCommand).Assembly
));
builder.Services.AddHttpClient<IQrCodeGeneratorClient, QrCodeGeneratorClient>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
    .AddNegotiate();

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