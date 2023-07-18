using AutoMapper;
using Domain;
using Domain.Services;
using FluentValidation;
using habitica_backend.DTO;
using habitica_backend.Validators;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Task = Domain.Entities.Task;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<HabiticaContext>(
options =>
    options.UseSqlServer(ConfigurationExtensions.GetConnectionString(builder.Configuration, "HabiticaDb"),
        x => x.MigrationsAssembly("API")
    )
);

builder.Services.AddScoped<IUnityOfWork, UnityOfWork>();
builder.Services.AddScoped<TaskService, TaskService>();

var mapperConfig = new MapperConfiguration(cfg => cfg.CreateMap<CreateTaskDTO, Task>());

builder.Services.AddScoped<IValidator<Task>, TaskValidator>();


var config = new MapperConfiguration(cfg =>
{
    cfg.CreateMap<CreateTaskDTO, Task>();
});

IMapper mapper = config.CreateMapper();

builder.Services.AddSingleton(mapper);

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
