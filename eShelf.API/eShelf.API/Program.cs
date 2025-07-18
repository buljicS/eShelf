using eShelf.API.Middlewares;
using eShelf.Domain.Context;
using eShelf.Infrastructure.FileManager;
using eShelf.Services;
using eShelf.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// configure swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// configure database
builder.Services.AddDbContext<PdfShelfDbContext>(op =>
{
    op.UseSqlServer(builder.Configuration.GetConnectionString("MainDB"))
      .EnableDetailedErrors()
      .EnableSensitiveDataLogging();
});

//configure app pipline
builder.Services.AddSingleton<IFileHandler, FileManager>();
builder.Services.AddSingleton<FileServices>();

// configure http depnendt pipeline
builder.Services.AddTransient<ExceptionMiddleware>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
