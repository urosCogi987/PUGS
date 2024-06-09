using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using TaxiApp.Application.Abstractions;
using TaxiApp.Domain.Repositories;
using TaxiApp.Infrastructure.Authentication;
using TaxiApp.Infrastructure.HostedServices;
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

    ConfigureJwt(services);

    services.AddAuthorization();
    services.AddScoped<IPermissionService, PermissionService>();
    services.AddSingleton<IAuthorizationHandler, PermissionAuthorizationHandler>();
    services.AddSingleton<IAuthorizationPolicyProvider, PermissionAuthorizationPolicyProvider>();    

    services.AddControllers();

    services.AddFluentValidationAutoValidation();
    services.AddFluentValidationClientsideAdapters();
    services.AddValidatorsFromAssembly(TaxiApp.WebApi.AssemblyReference.Assembly);

    services.AddEndpointsApiExplorer();

    services.AddExceptionHandler<AppExceptionHandler>();    

    ConfigureSwagger(services);
    ConfigureMediator(services);

    services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
    services.AddScoped<IUserRepository, UserRepository>();
    services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
    services.AddScoped<IUserRoleRepository, UserRoleRepository>();
    services.AddScoped<IRoleRepository, RoleRepository>();
    services.AddScoped<IVerificationTokenRepository, VerificationTokenRepository>();

    services.AddScoped<IPasswordHasher, PasswordHasher>();
    services.AddScoped<IJwtProvider, JwtProvider>();
    services.AddScoped<IEmailProvider, EmailProvider>();
    services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
    services.AddScoped<IUserContext, UserContext>();
    services.AddScoped<IDriveCalculator, DriveCalculator>();

    services.AddHostedService<RefreshTokenDeletingService>();
    services.AddHostedService<VerificationTokenDeletingService>();
}

void ConfigureApp(WebApplication app)
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "TaxiApp");
        });
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

void ConfigureJwt(IServiceCollection services)
{
    services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = builder.Configuration["Jwt:Issuer"],
                ValidAudience = builder.Configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"]!))
            };
        });
}

void ConfigureSwagger(IServiceCollection services)
{
    services.AddSwaggerGen(c => {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "JWTToken_Auth_API",
            Version = "v1"
        });
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
        {
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
        });
        c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                }
            },
            new string[] {}
        }
        });
    });
}