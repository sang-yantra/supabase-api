using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Supabase.Microservices.Context;
using Supabase.Microservices.Services.Interface;
using Supabase.Microservices.Services.Implementations;
using Supabase.Microservices.DAL.Interfaces;
using Supabase.Microservices.DAL.Repos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var env = builder.Environment;

var config = builder.Configuration;
var services = builder.Services;


config.SetBasePath(AppDomain.CurrentDomain.BaseDirectory);
config.AddJsonFile($"appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);

/// logging

/// services
services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
});
services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddHttpContextAccessor();
services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        var allowedOrigins = config.GetSection("AllowedOrigins").Get<string[]>();
        builder.WithOrigins(allowedOrigins)
        .SetIsOriginAllowedToAllowWildcardSubdomains()
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials()
        ;
    });
});

services.AddDbContext<JiraDbContext>(options =>
{
    options.UseNpgsql(config.GetConnectionString("JiraSupabaseDb"));
});

services.AddMemoryCache();

//DI Services
services.AddScoped<ITaskInfo, TaskInfoServices>();

// DI DAL
services.AddScoped<ITaskInfoRepo, TaskInfoRepo>();



// configure middlewares
var app = builder.Build();
// Configure the HTTP request pipeline.

app.UseCors();
app.UseRouting();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseEndpoints(endpoints => endpoints.MapControllers());

// running the app
app.Run();
