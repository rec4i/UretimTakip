using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;

namespace WebIU.Middlewares
{
    public class RequestLocalizationCookiesMiddleware : IMiddleware
    {
        private readonly CookieRequestCultureProvider _provider;
        public RequestLocalizationCookiesMiddleware(IOptions<RequestLocalizationOptions> options)
        {
            _provider = options.Value.RequestCultureProviders.Where(x => x is CookieRequestCultureProvider).Cast<CookieRequestCultureProvider>().FirstOrDefault();
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (_provider != null)
            {
                IRequestCultureFeature feature = context.Features.Get<IRequestCultureFeature>();
                if (feature != null)
                    context.Response.Cookies.Append(_provider.CookieName, CookieRequestCultureProvider.MakeCookieValue(feature.RequestCulture));
            }
            await next(context);

        }
    }
    public static class RequestLocalizationCookiesMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestLocalizationCookies(this IApplicationBuilder app)
            => app.UseMiddleware<RequestLocalizationCookiesMiddleware>();
    }
}
