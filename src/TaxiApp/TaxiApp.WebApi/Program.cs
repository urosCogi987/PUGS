using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using TaxiApp.Application.Abstractions;
using TaxiApp.Domain.Repositories;
using TaxiApp.Infrastructure.Services;
using TaxiApp.Kernel.Repositories;
using TaxiApp.Persistence;
using TaxiApp.Persistence.Repositories;
using TaxiApp.WebApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);
ConfigureServices(builder.Services);
var app = builder.Build();
ConfigureApp(app);
app.Run();
 
void ConfigureServices(IServiceCollection services)
{
    string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;
    services.AddDbContext<ApplicationDbContext>(options =>
        options.UseNpgsql(connectionString));

    services.AddControllers();

    services.AddFluentValidationAutoValidation();
    services.AddFluentValidationClientsideAdapters();
    services.AddValidatorsFromAssembly(TaxiApp.WebApi.AssemblyReference.Assembly);

    services.AddEndpointsApiExplorer();

    services.AddExceptionHandler<AppExceptionHandler>();

    services.AddSwaggerGen();

    ConfigureMediator(services);

    services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
    services.AddScoped<IUserRepository, UserRepository>();
    services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();

    services.AddScoped<IPasswordHasher, PasswordHasher>();
    services.AddScoped<IJwtProvider, JwtProvider>();
}

void ConfigureApp(WebApplication app)
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseExceptionHandler(_ => { });

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();
}

void ConfigureMediator(IServiceCollection services)
{
    services.AddMediatR(cfg =>
    {
        cfg.RegisterServicesFromAssembly(TaxiApp.Application.AssemblyReference.Assembly);
    });
}