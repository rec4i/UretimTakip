using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business;
using Business.Abstract.Services;
using Business.Concrate.Services.Helpers;
using Business.Concrete.CustomValidation;
using Business.Concrete.Services;
using Business.Mappings;
using DataAccess.Concrete.EntityFramework.DbContexts;
using Entities.Concrete.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json.Serialization;
using WebIU.DependencyResolvers.Autofac;
using WebIU.Extensions;
using WebIU.Filters;

using WebIU.Mappings;
using WebIU.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation().AddViewLocalization();

builder.Services.AddSession();
//Mail Service
var emailConfig = builder.Configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>();
builder.Services.AddSingleton(emailConfig);

//builder.Logging.ClearProviders();



//Localizasyon process
builder.Services.AddLocalization(opt =>
{
    opt.ResourcesPath = "Resources";
});
builder.Services.Configure<RequestLocalizationOptions>(opt =>
{
    opt.DefaultRequestCulture = new("tr-TR");
    CultureInfo[] cultures = new CultureInfo[]
    {
        new CultureInfo("tr-TR"),
        new CultureInfo("en-US"),
        new CultureInfo("fr-FR"),
    };
    opt.SupportedCultures = cultures;
    opt.SupportedUICultures = cultures;
});

//AutoMapper Process
builder.Services.AddAutoMapper(typeof(GeneralMapping));
builder.Services.AddAutoMapper(typeof(ViewModelMapping));


//Permission Process
builder.Services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();
builder.Services.AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();
builder.Services.AddHttpContextAccessor();
// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("AppIdentityDbContextConnection") ?? throw new InvalidOperationException("Connection string 'AppIdentityDbContextConnection' not found.");
builder.Services.AddDbContext<AppIdentityDbContext>(options => options.UseSqlServer(connectionString));

//User Process
builder.Services.AddIdentity<AppIdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<AppIdentityDbContext>()
    .AddDefaultTokenProviders()
    .AddPasswordValidator<CustomPasswordValidator>()
    .AddUserValidator<CustomUserNameValidator>()
    .AddErrorDescriber<CustomIdentityErrorDescrible>();

//Autofac

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(opt => opt.RegisterModule(new AutofacDependencyResolve()));




builder.Services.AddRazorPages();

//Password and user policy
builder.Services.AddCustomPasswordPolicy();

//Identity Cookie
builder.Services.AddCustomConfigureApplicationCookie();

//IdentityDbContext Seed
await builder.Services.IdentityDbContextSeedAsync();

//Localization Process
builder.Services.AddScoped<RequestLocalizationCookiesMiddleware>();
builder.Services.AddScoped<DataProcessorService>();
builder.Services.AddSingleton<IWebSocketService, WebSocketService>();
//Nlog 

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});



//builder.Services.AddAuthentication();
var app = builder.Build();
app.UseWebSockets();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.Use(async (context, next) =>
{
    await next();
    if (context.Response.StatusCode == 404)
    {
        context.Request.Path = "/Home/Page404";
        await next();
    }
    if (context.Response.StatusCode == 500)
    {
        context.Request.Path = "/Home/Page500";
        await next();
    }


});
app.UseSession();
app.UseRequestLocalization();
app.UseRequestLocalizationCookies();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.Map("/ws", async context =>
    {
        if (context.WebSockets.IsWebSocketRequest)
        {
            var webSocket = await context.WebSockets.AcceptWebSocketAsync();
            var webSocketHandler = app.Services.GetRequiredService<IWebSocketService>();
            await webSocketHandler.HandleWebSocketConnection(webSocket);
        }
        else
        {
            context.Response.StatusCode = 400;
        }
    });
});

app.Run();




