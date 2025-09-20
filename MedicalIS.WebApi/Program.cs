using MedicalIS.Application;
using MedicalIS.Infrastructure;
using MedicalIS.WebApi.HostedServices;
using MedicalIS.WebApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(ApplicationAssemblyMarker).Assembly));
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddHostedService<DatabaseInitializerHostedService>();

var app = builder.Build();

app.MapDefaultEndpoints();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthorization();
app.MapControllers();

app.Run();
