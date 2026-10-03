using GenericRepository;
using Microsoft.EntityFrameworkCore;
using Patrify.MessageBus.RabbitMQ.Consumer;
using Patrify.MessageBus.RabbitMQ.Publish;
using Quartz;
using SAPIntegration.DTO;
using SAPIntegration.Entities.Context;
using SAPIntegration.Repositories.Job;
using SAPIntegration.Repositories.Nota;
using SAPIntegration.Services.Job;
using SAPIntegration.Services.Nota;
using SAPIntegration.Workers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<SQLServerContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));
builder.Services.AddHttpClient();
builder.Services.AddScoped<IUnitOfWork>(srv => srv.GetRequiredService<SQLServerContext>());
builder.Services.AddAutoMapper( a => a.AddMaps(typeof(Program).Assembly));

builder.Services.AddQuartz();

builder.Services.AddQuartzHostedService(options =>
{
    options.WaitForJobsToComplete = true;
});
builder.Services.AddScoped<IJobRepository, JobRepository>();
builder.Services.AddScoped<IJobService, JobService>();
builder.Services.AddScoped<SchedulerJobService>();
builder.Services.AddScoped<INotaService, NotaService>();
builder.Services.AddScoped<INotaRepository, NotaRepository>();

builder.Services.AddSingleton<IRabbitMQPublish, RabbitMQPublish>();

builder.Services.AddHostedService<GetJobsWorker>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
