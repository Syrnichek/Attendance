using Microsoft.AspNetCore.Authentication.Negotiate;
using QRGenerationService.Application.Commands;
using QRGenerationService.Application.Handlers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(
    typeof(GenerateQrCodeCommandHandler).Assembly,
    typeof(GenerateQrCodeCommand).Assembly
));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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