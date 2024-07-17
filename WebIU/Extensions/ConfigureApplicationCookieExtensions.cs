using Microsoft.AspNetCore.Authentication.Cookies;

namespace WebIU.Extensions
{
    public static class ConfigureApplicationCookieExtensions
    {
        public static IServiceCollection AddCustomConfigureApplicationCookie(this IServiceCollection services)
        {
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Account/Login";
                options.AccessDeniedPath = "/Home/Accessdenied";
                options.LogoutPath = "/Account/LogOut";
                options.ExpireTimeSpan = TimeSpan.FromHours(5);
                options.Cookie.HttpOnly = false;
                options.Cookie.Name = "UserActions.Account.Cookie";
                options.Cookie.Path = "/";
                options.Cookie.SameSite = SameSiteMode.Lax;
                options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
                options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
                options.SlidingExpiration = true;
            });
            return services;
        }
    }
}
