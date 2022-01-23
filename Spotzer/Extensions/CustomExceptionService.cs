using Microsoft.AspNetCore.Builder;
using Spotzer.Middlewares;

namespace Spotzer.Extensions
{
    public static class CustomExceptionService
    {
        public static void UseExceptionMiddleware(this IApplicationBuilder application)
        {
            application.UseMiddleware<CustomExceptionMiddleware>();
        }
    }
}
