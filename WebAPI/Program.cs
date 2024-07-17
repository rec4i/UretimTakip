using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using Business.Concrete.CustomValidation;
using Business.Concrete.Services;
using Business.Mappings;
using DataAccess.Concrete.EntityFramework.DbContexts;
using Entities.Concrete.Identity;
using Entities.Concrete.Token;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebAPI.DependencyResolvers.Autofac;
using WebAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddNewtonsoftJson(options =>
options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
builder.Services.AddHttpContextAccessor();

//options patern
builder.Services.Configure<CustomTokenOption>(builder.Configuration.GetSection("TokenOption"));
builder.Services.Configure<List<Client>>(builder.Configuration.GetSection("Clients"));
//AutoMapper Process
builder.Services.AddAutoMapper(typeof(GeneralMapping));

//Autofac
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(opt => opt.RegisterModule(new AutofacDependencyResolve()));

var connectionString = builder.Configuration.GetConnectionString("AppIdentityDbContextConnection") ?? throw new InvalidOperationException("Connection string 'AppIdentityDbContextConnection' not found.");
builder.Services.AddDbContext<AppIdentityDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddIdentity<AppIdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<AppIdentityDbContext>()
    .AddDefaultTokenProviders()
    .AddPasswordValidator<CustomPasswordValidator>()
    .AddUserValidator<CustomUserNameValidator>()
    .AddErrorDescriber<CustomIdentityErrorDescrible>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Password and user policy
builder.Services.AddCustomPasswordPolicy();


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opt =>
{
    var tokenOptions = builder.Configuration.GetSection("TokenOption").Get<CustomTokenOption>();
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = tokenOptions.Issuer,
        ValidAudience = tokenOptions.Audience[0],
        IssuerSigningKey = SignService.GetSymmetricSecurityKey(tokenOptions.SecurityKey),
        ValidateIssuerSigningKey = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuer = true,
        ClockSkew = TimeSpan.Zero
    };
});
builder.Services.ModelStateResponseExtension();
builder.Services.SwaggerExtension();
var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}
app.UseSwagger();
app.UseSwaggerUI();

app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
