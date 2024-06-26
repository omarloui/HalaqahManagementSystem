using HalaqahModel.Context;
using HalaqahModel.Helpers;
using HalaqahModel.Models;
using HalaqahModel.Repository;
using HalaqahAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<HalaqahContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("HalaqahContext")));

builder.Services.AddScoped<UnitOfWork>();
builder.Services.AddScoped<IRepository<Halaqah>, GenericRepository<Halaqah>>();
builder.Services.AddScoped<IRepository<HalaqahRecord>, GenericRepository<HalaqahRecord>>();
builder.Services.AddScoped<IRepository<Masjid>, GenericRepository<Masjid>>();
builder.Services.AddScoped<IRepository<Person>, GenericRepository<Person>>();
builder.Services.AddScoped<IRepository<Record>, GenericRepository<Record>>();
builder.Services.AddScoped<IRepository<Segment>, GenericRepository<Segment>>();
builder.Services.AddScoped<IRepository<Semester>, GenericRepository<Semester>>();
builder.Services.AddScoped<IRepository<SemesterRecord>, GenericRepository<SemesterRecord>>();
builder.Services.AddScoped<IRepository<Student>, GenericRepository<Student>>();
builder.Services.AddScoped<IRepository<StudentAttendance>, GenericRepository<StudentAttendance>>();
builder.Services.AddScoped<IRepository<User>, GenericRepository<User>>();
builder.Services.AddScoped<IRepository<UserAttendance>, GenericRepository<UserAttendance>>();

builder.Services.AddScoped<HalaqahService>();
builder.Services.AddScoped<StudentService>();

builder.Services.AddScoped<EntityHelper>();

builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
