using CacheNQueue.Api.Middlewares.Filter.CacheNQueue.Api.Middlewares.Filter;

namespace CacheNQueue.Api.Middlewares.Filter
{
    public static class ConfigureExceptionMiddleware
    {
        public static void ConfigureExceptionHandlingMiddleware(this IApplicationBuilder app)
        {

            app.UseMiddleware<ExceptionMiddleware>();

        }
    }
}