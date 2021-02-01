namespace ServiceLifetimes
{
    using Microsoft.AspNetCore.Builder;

    public static class CustomMiddlewareExtensions
    {
        public static IApplicationBuilder AddCustomMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<CustomMiddleware>();

            return app;
        }
    }
}