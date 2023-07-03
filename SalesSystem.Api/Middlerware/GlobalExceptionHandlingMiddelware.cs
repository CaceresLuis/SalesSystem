using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace SalesSystem.Api.Middlerware
{
    public class GlobalExceptionHandlingMiddelware : IMiddleware
    {
        private readonly ILogger<GlobalExceptionHandlingMiddelware> _logger;

        public GlobalExceptionHandlingMiddelware(ILogger<GlobalExceptionHandlingMiddelware> logger) => _logger = logger;

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                ProblemDetails problem = new()
                {
                    Status = (int)HttpStatusCode.InternalServerError,
                    Type = "Server Error",
                    Title = "Server Error",
                    Detail = "An internal server error has ocurred"
                };

                string json = JsonSerializer.Serialize(problem);

                context.Response.ContentType = "application/json";

                await context.Response.WriteAsync(json);
            }
        }
    }
}
