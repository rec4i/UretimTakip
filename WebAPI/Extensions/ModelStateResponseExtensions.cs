using Entities.Concrete.Response;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Extensions
{
    public static class ModelStateResponseExtensions
    {
        public static IServiceCollection ModelStateResponseExtension(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var errors = context.ModelState.Values.Where(p => p.Errors.Count > 0).SelectMany(x => x.Errors).Select(x => x.ErrorMessage);
                    var response = Response<NoContent>.Fail(errors.ToList(), 400);
                    return new BadRequestObjectResult(response);
                };
            });
            return services;
        }
    }
}
