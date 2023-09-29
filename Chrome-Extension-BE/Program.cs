using Chrome_Extension_BE.DataAccess.DataContext;
using Chrome_Extension_BE.Services.Interfaces;
using Chrome_Extension_BE.Services.Repositories;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IFileService, FileService>();

builder.Services.AddDbContext<FileContext>(options =>

    options.UseSqlServer(builder.Configuration.GetConnectionString("AppConnection"))
);

builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 55000000;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
