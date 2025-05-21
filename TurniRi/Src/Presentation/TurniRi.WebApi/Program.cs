using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using TurniRi.Application;
using TurniRi.Application.Interfaces;
using TurniRi.Infrastructure.FileManager;
using TurniRi.Infrastructure.FileManager.Contexts;
using TurniRi.Infrastructure.Identity;
using TurniRi.Infrastructure.Identity.Contexts;
using TurniRi.Infrastructure.Identity.Models;
using TurniRi.Infrastructure.Identity.Seeds;
using TurniRi.Infrastructure.Persistence;
using TurniRi.Infrastructure.Persistence.Contexts;
using TurniRi.Infrastructure.Persistence.Seeds;
using TurniRi.Infrastructure.Resources;
using TurniRi.WebApi.Infrastructure.Extensions;
using TurniRi.WebApi.Infrastructure.Middlewares;
using TurniRi.WebApi.Infrastructure.Services;


var builder = WebApplication.CreateBuilder(args);

bool useInMemoryDatabase = builder.Configuration.GetValue<bool>("UseInMemoryDatabase");

builder.Services.AddApplicationLayer();
builder.Services.AddPersistenceInfrastructure(builder.Configuration, useInMemoryDatabase);
builder.Services.AddFileManagerInfrastructure(builder.Configuration, useInMemoryDatabase);
builder.Services.AddIdentityInfrastructure(builder.Configuration, useInMemoryDatabase);
builder.Services.AddResourcesInfrastructure();
builder.Services.AddScoped<IAuthenticatedUserService, AuthenticatedUserService>();
builder.Services.AddControllers();
builder.Services.AddVersioning();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddSwaggerWithVersioning();
builder.Services.AddAnyCors();
builder.Services.AddCustomLocalization(builder.Configuration);
builder.Services.AddHealthChecks();
builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    if (!useInMemoryDatabase)
    {
        await services.GetRequiredService<IdentityContext>().Database.MigrateAsync();
        await services.GetRequiredService<ApplicationDbContext>().Database.MigrateAsync();
        //await services.GetRequiredService<FileManagerDbContext>().Database.MigrateAsync();
    }

    //Seed Data
    //await DefaultRoles.SeedAsync(services.GetRequiredService<RoleManager<ApplicationRole>>());
    //await DefaultBasicUser.SeedAsync(services.GetRequiredService<UserManager<ApplicationUser>>());
    //await DefaultData.SeedAsync(services.GetRequiredService<ApplicationDbContext>());
}

app.UseCustomLocalization();
app.UseAnyCors();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseSwaggerWithVersioning();
app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseHealthChecks("/health");
app.MapControllers();
app.UseSerilogRequestLogging();

app.Run();

public partial class Program
{
}
